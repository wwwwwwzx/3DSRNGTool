using System.Linq;
using Pk3DSRNGTool.RNG;

namespace Pk3DSRNGTool
{
    internal class TinyStatus
    {
        public TinyMT tinyrng = new TinyMT(0);
        private byte getcooldown1 => (byte)(((tinyrng.Nextuint() * 60ul) >> 32) + 62);
        private byte getcooldown2 => (byte)(getblink ? 10 : 6);
        private bool getblink => ((tinyrng.Nextuint() * 3ul) >> 32) == 0;

        public int Modelnumber;
        public byte[] remain_frame;
        public bool blink;

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
                        remain_frame[i] = getcooldown2;
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

        public uint getrand()
        {
            return tinyrng.Nextuint();
        }

        public override string ToString()
        {
            return string.Join(",", tinyrng.status.Select(v => v.ToString("X8")).Reverse());
        }
    }
}