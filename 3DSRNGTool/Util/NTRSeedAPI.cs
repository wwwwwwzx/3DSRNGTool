using System;
using System.Linq;
using System.Threading;

namespace Pk3DSRNGTool
{
    public partial class NtrClient
    {
        public byte gameversion;
        public byte pid;
        public uint Seed { get; private set; }

        public bool NewResult;
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

        private void byteToSeed(byte[] datBuf)
        {
            Write(0x8800000, datBuf, pid);
            Seed = BitConverter.ToUInt32(datBuf, 0);
            resume();
            NewResult = true;
        }
    }
}
