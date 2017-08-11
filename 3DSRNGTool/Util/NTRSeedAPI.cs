using System;
using System.Linq;
using System.Threading;

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

        private static string[] pnamestr = { "kujira-1", "kujira-2", "sango-1", "sango-2", "salmon", "niji_loc", "niji_loc" };
        private bool getGame(string logmsg)
        {
            string pname;
            if (null == (pname = pnamestr.FirstOrDefault(logmsg.Contains)))
                return false;
            Gameversion = (byte)Array.IndexOf(pnamestr, pname);
            pname = ", pname:" + pname.PadLeft(9);
            string pidaddr = logmsg.Substring(logmsg.IndexOf(pname, StringComparison.Ordinal) - 10, 10);
            Pid = Convert.ToByte(pidaddr, 16);
            switch (Gameversion)
            {
                case 0:
                case 1:
                    BPOffset = 0x1d4088; MTOffset = 0x8c52848; TinyOffset = 0x08c52808; IDOffset = 0x08C79C3C; break;
                case 2:
                case 3:
                    BPOffset = 0x1e790c; MTOffset = 0x8c59e44; TinyOffset = 0x08c59E04; IDOffset = 0x08C81340; break;
                case 4:
                    break;
                case 5:
                case 6:
                    NfcOffset = 0x3E14C0; // 1.0 offset was 0x3DFFD0
                    WriteWifiPatch(); SFMTOffset = 0x325A3878; TinyOffset = 0x3313EDDC; IDOffset = 0x330D67D0; break;
            }
            SendMsg(Gameversion, "Version");
            if (Gameversion < 4)
            {
                if (OneClick)
                {
                    DebuggerMode();
                    SetBreakPoint();
                }
                else
                    DebuggerMode();
            }
            if (Gameversion == 4)
                disconnect();
            if (Gameversion > 4)
            {
                ReadSeed();
                ReadTiny("EggSeed");
                ReadTSV();
            }
            if (Gameversion < 4)
            {
                ReadTiny("IDSeed");
                ReadTSV();
            }
            return true;
        }

        private bool getBP(string logmsg)
        {
            if (!(logmsg.Contains("breakpoint ") && logmsg.Contains(" hit")))
                return false;
            string bpid = " lr:";
            string splitlog = "0x" + logmsg.Substring(logmsg.IndexOf(bpid, StringComparison.Ordinal) + bpid.Length, 8);
            uint address = Convert.ToUInt32(splitlog, 16);
            switch (address)
            {
                case 0:
                    resume(); break;
                case 0x07003130: //XY
                case 0x07003158: //OARS
                    ReadSeed(); resume();
                    ReadTSV();
                    ReadTiny("IDSeed");
                    break;
                default:
                    SendMsg(address, "BreakPoint"); break;
            }
            return true;
        }

        public void DebuggerMode()
        {
            if (5000 < port && port < 8000 && Connected) // Already enabled
                return;
            setServer(host, 5000 + Pid);
            connectToServer();
        }

        public void SetBreakPoint()
        {
            bpadd(BPOffset, "code"); // Add break point
            resume();
            SendMsg("Breakpoint Set");
        }

        public byte[] SingleThreadRead(uint addr, uint size = 4)
        {
            DataReady = false;
            Read(addr, size, Pid);
            int timeout = 10;
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
        private const uint nfcVal = 0xE3A01000;
        private void WriteWifiPatch()
        {
            byte[] command = BitConverter.GetBytes(nfcVal);
            Write(NfcOffset, command, Pid);
            SendMsg("NFC Patched!");
        }

#if DEBUG
        public void WriteTiny(uint[] tiny)
        {
            Write(TinyOffset, BitConverter.GetBytes(tiny[0]), Pid);
            Write(TinyOffset + 4, BitConverter.GetBytes(tiny[1]), Pid);
            Write(TinyOffset + 8, BitConverter.GetBytes(tiny[2]), Pid);
            Write(TinyOffset + 12, BitConverter.GetBytes(tiny[3]), Pid);
        }
#endif

        public byte[] ReadIndex() => SingleThreadRead(MTOffset, 0x2);
        public byte[] ReadTiny() => SingleThreadRead(TinyOffset, 0x10);

        public void ReadSeed()
        {
            var seed_ay = SingleThreadRead(Gameversion < 5 ? MTOffset + 4 : SFMTOffset, 0x4);// MT[0]/SFMT
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
            uint[] tinyseeds = new[]
            {
                BitConverter.ToUInt32(tiny, 0),
                BitConverter.ToUInt32(tiny, 4),
                BitConverter.ToUInt32(tiny, 8),
                BitConverter.ToUInt32(tiny, 12),
             };
            SendMsg(tinyseeds, Name);
        }

        public void ReadTSV()
        {
            var FullID = SingleThreadRead(IDOffset, 0x4);
            if (FullID == null)
                return;
            var TID = BitConverter.ToUInt16(FullID, 0);
            var SID = BitConverter.ToUInt16(FullID, 2);
            SendMsg((TID ^ SID) >> 4, "TSV");
        }
    }
}
