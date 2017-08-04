using System;
using System.Linq;
using System.Threading;

namespace Pk3DSRNGTool
{
    public partial class NtrClient
    {
        public byte Gameversion { get; private set; }
        public byte Pid { get; private set; }
        public byte[] Data { get; private set; }
        private uint BPOffset;
        private uint MTOffset;
        private uint SFMTOffset;
        private uint TinyOffset;
        private uint IDOffset;
        private uint NfcOffset;

        private bool DataReady;
        public bool VersionDetected;
        public byte phase;

        private bool parseLogMsg(string logmsg)
        {
            if (getGame(logmsg))
                return true;
            return false;
        }

        private static string[] pnamestr = { "kujira-1", "kujira-2", " sango-1", " sango-2", "----", "niji_loc", "niji_loc" };
        private bool getGame(string logmsg)
        {
            string pname;
            if (null == (pname = pnamestr.FirstOrDefault(logmsg.Contains)))
                return false;
            Gameversion = (byte)Array.IndexOf(pnamestr, pname);
            pname = ", pname: " + pname;
            string splitlog = logmsg.Substring(logmsg.IndexOf(pname, StringComparison.Ordinal) - 8, logmsg.Length - logmsg.IndexOf(pname, StringComparison.Ordinal));
            Pid = Convert.ToByte("0x" + splitlog.Substring(0, 8), 16);
            VersionDetected = true;
            switch (Gameversion)
            {
                case 0:
                case 1:
                    BPOffset = 0x1d4088; MTOffset = 0x8c52848; TinyOffset = 0x08c52808; IDOffset = 0x08C79C3C; break;
                case 2:
                case 3:
                    BPOffset = 0x1e790c; MTOffset = 0x8c59e44; TinyOffset = 0x08c59E04; IDOffset = 0x08C81340; break;
                case 5:
                case 6:
                    NfcOffset = 0x3E14C0; // 1.0 offset was 0x3DFFD0
                    WriteWifiPatch(); SFMTOffset = 0x325A3878; TinyOffset = 0x3313EDDC; IDOffset = 0x330D67D0; break;
            }
            return true;
        }

        public void SetBreakPoint()
        {
            setServer(host, 5000 + Pid);
            connectToServer();
            bpadd(BPOffset, "code"); // Add break point
            resume();
        }

        public byte[] SingleThreadRead(uint addr, uint size = 4)
        {
            Read(addr, size, Pid);
            int timeout = 10;
            do { Thread.Sleep(100); timeout--; } while (!DataReady && timeout > 0); // Try thread later
            if (timeout == 0) return null;
            DataReady = false;
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
        public byte[] ReadSeed() => SingleThreadRead(Gameversion < 5 ? MTOffset + 4 : SFMTOffset, 0x4);  // MT[0]/SFMT
        public byte[] ReadTiny() => SingleThreadRead(TinyOffset, 0x10);
        public int ReadTSV()
        {
            var FullID = SingleThreadRead(IDOffset, 0x4);
            var TID = BitConverter.ToUInt16(FullID, 0);
            var SID = BitConverter.ToUInt16(FullID, 2);
            return (TID ^ SID) >> 4;
        }
    }
}
