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
        private uint BPOffset { get; set; }
        private uint MTOffset { get; set; }
        private uint TinyOffset { get; set; }

        private bool DataReady;
        public bool VersionDetected;
        public byte phase;

        private bool parseLogMsg(string logmsg)
        {
            if (getGame(logmsg))
                return true;
            return false;
        }

        private static string[] pnamestr = { "kujira-1", "kujira-2", " sango-1", " sango-2", "niji_loc" };
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
                    BPOffset = 0x1d4088; MTOffset = 0x8c52848; TinyOffset = 0x8c52808; break;
                case 2:
                case 3:
                    BPOffset = 0x1e790c; MTOffset = 0x8c59e44; TinyOffset = 0x8c59E04; break;
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

        public byte[] ReadIndex() => SingleThreadRead(MTOffset, 0x2);
        public byte[] ReadSeed() => SingleThreadRead(MTOffset + 4, 0x4);  // MT[0]
        public byte[] ReadTiny() => SingleThreadRead(TinyOffset, 0x10);
    }
}
