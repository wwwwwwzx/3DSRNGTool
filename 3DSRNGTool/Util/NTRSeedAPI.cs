using System;
using System.Linq;
using System.Threading;

namespace Pk3DSRNGTool
{
    public partial class NtrClient
    {
        public byte gameversion { get; private set; }
        public byte pid { get; private set; }
        public byte[] Data { get; private set; }

        public bool DataReady;
        public bool ToSetBP;

        private static string[] pnamestr = { "kujira-1", "kujira-2", " sango-1", " sango-2", "niji_loc" };
        private void getGame(string log)
        {
            string pname;
            if (null == (pname = pnamestr.FirstOrDefault(str => log.Contains(str))))
                return;
            gameversion = (byte)Array.IndexOf(pnamestr, pname);
            pname = ", pname: " + pname;

            ToSetBP = gameversion < 4;
            string splitlog = log.Substring(log.IndexOf(pname) - 8, log.Length - log.IndexOf(pname));
            pid = Convert.ToByte("0x" + splitlog.Substring(0, 8), 16);
        }

        public void SetBreakPoint()
        {
            setServer(host, 5000 + pid);
            connectToServer();
            bpadd(0x1e790c, "code"); // Add break point
            resume();
            Thread.Sleep(6000);
            resume();
        }

        public byte[] SingleThreadRead(uint addr, uint size = 4, int pid = -1)
        {
            Read(addr, size, pid);
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
    }
}
