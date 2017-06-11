using System.Linq;
using Pk3DSRNGTool.RNG;

namespace Pk3DSRNGTool
{
    internal class TinyStatus
    {
        public TinyMT tinyrng = new TinyMT(0);
        public int Modelnumber;
        public byte[] remain_frame;
        public bool blink;

        private byte getcooldown1 => (byte)(((tinyrng.Nextuint() * 60ul) >> 32) + 61);
        private byte getcooldown2 => (byte)(getblink ? 9 : 5);
        private bool getblink => ((tinyrng.Nextuint() * 3ul) >> 32) == 0;

        public TinyStatus(uint[] status, int n = 1)
        {
            tinyrng.status = (uint[])status.Clone();
            Modelnumber = n;
            remain_frame = new byte[n];
        }

        public void NextState()
        {
            for (int i = 0; i < Modelnumber; i++)
            {
                if (remain_frame[i]-- == 0)
                {
                    if (blink)
                    {
                        remain_frame[i] = getcooldown1;
                        blink = false;
                        continue;
                    }
                    remain_frame[i] = (blink = getblink) ? getcooldown2 : getcooldown1;
                }
            }
        }

        public void frameshift(int n)
        {
            for (int i = 0; i < n; i++)
                tinyrng.Next();
        }

        public uint getrand => tinyrng.Nextuint();

        public void Copyto(TinyStatus des)
        {
            des.tinyrng.status = (uint[])tinyrng.status.Clone();
            des.Modelnumber = Modelnumber;
            des.remain_frame = (byte[])remain_frame.Clone();
            des.blink = blink;
        }

        public PRNGState State => tinyrng.CurrentState();
    }
}