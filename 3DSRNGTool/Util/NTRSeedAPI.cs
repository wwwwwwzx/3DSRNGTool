using System;
using System.Linq;
using System.Threading;
using Pk3DSRNGTool.RNG;

namespace Pk3DSRNGTool
{
    public partial class NtrClient
    {
        public byte Gameversion { get; private set; }
        public byte Pid { get; private set; } = 0x28;
        private uint BPOffset;
        private uint MTOffset;
        private uint SFMTOffset;
        private uint TinyOffset;
        private uint IDOffset;
        private uint NfcOffset;
        private uint TinyBPOffset;
        private uint TinySoaringOffset;
        private bool DataReady;
        public byte[] Data { get; private set; }
        public bool OneClick;

        public class InfoEventArgs : EventArgs
        {
            public string info;
            public object data;
        }
        public event EventHandler<InfoEventArgs> Message;
        protected virtual void SendMsg(InfoEventArgs e) => Message?.Invoke(this, e);
        private object MsgLock = new object();
        private void SendMsg(object _data, string _info = null)
            => SendMsg(new InfoEventArgs { info = _info, data = _data });

        private void parseLogMsg(string logmsg)
        {
            getGame(logmsg);
            getBP(logmsg);
        }

        private static string[] pnamestr = { "kujira-1", "kujira-2", "sango-1", "sango-2", "salmon", "niji_loc", "niji_loc", "momiji", "momiji" };
        private static string[] titleidstr = { "175e00", "1b5100" };
        private bool getGame(string logmsg)
        {
            string pname;
            if (null == (pname = pnamestr.FirstOrDefault(logmsg.Contains)))
                return false;
            Gameversion = (byte)Array.IndexOf(pnamestr, pname);
            pname = ", pname:" + pname.PadLeft(9);
            string pidaddr = logmsg.Substring(logmsg.IndexOf(pname, StringComparison.Ordinal) - 10, 10);
            Pid = Convert.ToByte(pidaddr, 16);
            if (Gameversion > 4 && titleidstr.Any(logmsg.Contains)) // Moon or UM
                Gameversion++;
            switch (Gameversion)
            {
                case 0:
                case 1:
                    TinyBPOffset = 0x174DB4;
                    BPOffset = 0x1254F8; MTOffset = 0x8c52848; TinyOffset = 0x08c52808; IDOffset = 0x08C79C3C; break;
                case 2:
                case 3:
                    TinyBPOffset = 0x175CEC; TinySoaringOffset = 0x164714;
                    BPOffset = 0x125EC8; MTOffset = 0x8c59e44; TinyOffset = 0x08c59E04; IDOffset = 0x08C81340; break;
                case 4:
                    break;
                case 5:
                case 6:
                    NfcOffset = 0x3E14C0;
                    WriteWifiPatch(); SFMTOffset = 0x325A3878; TinyOffset = 0x3313EDDC; IDOffset = 0x330D67D0; break;
                case 7:
                case 8:
                    NfcOffset = Gameversion == 7 ? 0x3F3424u : 0x3F3428u;
                    WriteWifiPatch(); SFMTOffset = 0x32663BF0; TinyOffset = 0x3307B1EC; IDOffset = 0x33012818; break;
            }
            SendMsg(Gameversion, "Version");
            if (Gameversion < 4)
            {
                ReadTSV();
                if (OneClick)
                    DebuggerMode();
            }
            if (Gameversion == 4)
                SendMsg(null, "Disconnect");
            if (Gameversion > 4)
            {
                ReadTiny("EggSeed");
                ReadSeed();
                ReadTSV();
                if (OneClick)
                    SendMsg(null, "Disconnect");
            }
            return true;
        }

        private byte BPReached;
        private bool getBP(string logmsg)
        {
            string BPSTR = "breakpoint ";
            if (!(logmsg.Contains(BPSTR) && logmsg.Contains(" hit")))
                return false;
            uint bpnum = getvalue(logmsg, BPSTR, 1);
            if (bpnum == 1)
            {
                BPReached = 0; SetBreakPoint();
            }
            else if (bpnum == 2)
            {
                if (MTOffset == getvalue(logmsg, "r0:"))
                    SendMsg(getvalue(logmsg, "r1:"), "Seed");
                if (BPReached++ <= 1)
                    ReadTSV();
            }
            else
                SendMsg(getvalue(logmsg, " lr:"), "BreakPoint");
            resume();
            return true;
        }

        private uint getvalue(string logmsg, string key, int digit = 8)
            => Convert.ToUInt32("0x" + logmsg.Substring(logmsg.IndexOf(key, StringComparison.Ordinal) + key.Length, digit), 16);

        public void DebuggerMode()
        {
            if (DebuggerEnabled) // Already enabled
                return;
            setServer(host, 5000 + Pid);
            try { connectToServer(); } catch { SendMsg(null, "Disconnect"); }
        }

        public void SetBreakPoint()
        {
            bpadd(BPOffset, "code"); // Add break point
            bpadd(TinyBPOffset, "code"); bpdis(3);
            if (Gameversion == 2 || Gameversion == 3)
            { bpadd(TinySoaringOffset, "code"); bpdis(4); }
            SendMsg("Breakpoint Set");
        }

        public void EnableBP(bool Soaring = false) => bpena(Soaring ? 4u : 3u);
        public void DisableBP() { bpdis(3); bpdis(4); resume(); }

        public byte[] SingleThreadRead(uint addr, uint size = 4)
        {
            DataReady = false;
            Read(addr, size, Pid);
            int timeout = 20;
            do { Thread.Sleep(100); timeout--; } while (!DataReady && timeout > 0); // Try thread later
            if (timeout == 0) return null;
            return Data;
        }

        private void GetData(byte[] datBuf)
        {
            Data = (byte[])datBuf.Clone();
            DataReady = true;
        }

        // Gen7 Connection Patch
        private const uint nfcVal = 0xE3A01000; // MOV R1 #0 ; R1 = 0
        private void WriteWifiPatch()
        {
            byte[] command = BitConverter.GetBytes(nfcVal);
            Write(NfcOffset, command, Pid);
            SendMsg("NFC Patched!");
        }

        public byte[] ReadIndex() => SingleThreadRead(MTOffset, 0x2);
        public byte[] ReadTiny() => SingleThreadRead(TinyOffset, 0x10);

        public void ReadSeed()
        {
            var seed_ay = SingleThreadRead(SFMTOffset, 0x4); // SFMT
            if (seed_ay == null)
                return;
            uint seed = BitConverter.ToUInt32(seed_ay, 0);
            SendMsg(seed, "Seed");
        }

        public void ReadTiny(string Name)
        {
            byte[] tiny = ReadTiny();
            if (tiny == null)
                return;
            uint[] tinyseeds =
            {
                BitConverter.ToUInt32(tiny, 0),
                BitConverter.ToUInt32(tiny, 4),
                BitConverter.ToUInt32(tiny, 8),
                BitConverter.ToUInt32(tiny, 12),
             };
            SendMsg(tinyseeds, Name);
        }

        public TinyMT ReadTinyRNG()
        {
            byte[] tiny = ReadTiny();
            if (tiny == null)
                return null;
            return new TinyMT(new[]
            {
                BitConverter.ToUInt32(tiny, 0),
                BitConverter.ToUInt32(tiny, 4),
                BitConverter.ToUInt32(tiny, 8),
                BitConverter.ToUInt32(tiny, 12),
             });
        }

        public void ReadTSV()
        {
            var FullID = SingleThreadRead(IDOffset, 0x4);
            if (FullID == null)
                return;
            var TID = BitConverter.ToUInt16(FullID, 0);
            var SID = BitConverter.ToUInt16(FullID, 2);
            SendMsg((TID ^ SID) >> 4, "TSV");
            if (TID == 0 && SID == 0 && Gameversion < 4) // New gen6 save
                ReadTiny("IDSeed");
        }

        public const int FrameMax = 10000000;
        public int getCurrentFrame()
        {
            try
            {
                MersenneTwister rng = new MersenneTwister(Program.mainform.globalseed);
                var RAM = SingleThreadRead(MTOffset, 0x8);
                int Index = BitConverter.ToUInt16(RAM, 0);
                uint Status = BitConverter.ToUInt32(RAM, 4);
                var Period = 0;
                for (int i = 0; i < 624; i++)
                    rng.Next();
                while (Status.ToString("X8") != rng.CurrentState().ToString() && Period * 624 < FrameMax)
                {
                    for (int i = 0; i < 624; i++)
                        rng.Next();
                    Period++;
                }
                if (Index == 0)
                    Period++;
                return Math.Min(Period * 624 + Index - 1, FrameMax);
            }
            catch
            {
                return FrameMax;
            }
        }
    }
}
