using Pk3DSRNGTool.RNG;

namespace Pk3DSRNGTool
{
    internal class TinyStatus
    {
        public TinyMT tinyrng = new TinyMT(0);
        public int Modelnumber;
        public byte[] remain_frame;
        public bool blink;

        public uint getrand => tinyrng.Nextuint();
        public PRNGState State => tinyrng.CurrentState();
        private bool getblink => getrand < 0x55555556; // rand(3) == 0
        private byte getcooldown1 => (byte)(((getrand * 60ul) >> 32) + 61);
        private byte getcooldown2 => (byte)(getblink ? 9 : 5);

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

        public void Copyto(TinyStatus des)
        {
            des.tinyrng.status = (uint[])tinyrng.status.Clone();
            des.Modelnumber = Modelnumber;
            des.remain_frame = (byte[])remain_frame.Clone();
            des.blink = blink;
        }
    }
}