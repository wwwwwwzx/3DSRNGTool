using Pk3DSRNGTool.RNG;

namespace Pk3DSRNGTool
{
    internal class ModelStatus
    {
        private SFMT sfmt;
        private int cnt;
        private ulong getrand { get { cnt++; return sfmt.Nextulong(); } }

        public byte Modelnumber;
        public int[] remain_frame;
        public bool phase;

        public bool IsBoy;
        public int fidget_cd = -1; // fidget cooldown. -1 to ignore fidget
        public int Xurkitree = -1; // Xurkitree countdown. -1 to ignore

        public bool raining;

        public ModelStatus(byte n, SFMT st)
        {
            sfmt = (SFMT)st.DeepCopy();
            Modelnumber = n;
            remain_frame = new int[n];
        }

        public int NextState()
        {
            cnt = 0;
            if (fidget_cd > 0 && --fidget_cd == 0)
                fidget_cd = fidget();
            if (Xurkitree > 0 && --Xurkitree == 0)
                XurkitreeCycle();
            for (int i = 0; i < Modelnumber; i++)
            {
                if (remain_frame[i] > 1)                       //Cooldown 2nd part
                {
                    remain_frame[i]--;
                    continue;
                }
                if (remain_frame[i] < 0)                       //Cooldown 1st part
                {
                    if (++remain_frame[i] == 0)                //Blinking
                        remain_frame[i] = getrand % 3 == 0 ? 36 : 30;
                    continue;
                }
                if ((int)(getrand & 0x7F) == 0)                //Not Blinking
                    remain_frame[i] = -5;
            }
            if (raining && (phase = !phase))
                frameshift(2);
            return cnt;
        }

        private int[] Delay_M = new[] { 407, 412 };
        private int[] Delay_F = new[] { 402, 407 };
        private int fidget() // For more precise timeline
        {
            int delay1 = (int)(getrand % 90); // Random delay
            int delay2 = IsBoy ? Delay_M[getrand & 1] : Delay_F[getrand & 1]; // Decide movement type non-jump/jump
            return delay1 + delay2;
        }

        public int X1 = 193;
        private int X2 => 321 - X1;
        private void XurkitreeCycle()
        {
            if (Modelnumber == 2)
            {
                ChangeModelNumber(3);
                Xurkitree = X2;
            }
            else if (Modelnumber == 3)
            {
                ChangeModelNumber(2, true);
                Xurkitree = X1;
            }
        }

        private void ChangeModelNumber(byte N, bool Reset = false)
        {
            Modelnumber = N;
            if (N > remain_frame.Length)
            {
                int[] tmp = new int[N];
                remain_frame.CopyTo(tmp, 0);
                remain_frame = (int[])tmp.Clone();
            }
            else if (Reset)
            {
                for (int i = N; i < remain_frame.Length; i++)
                    remain_frame[i] = 0;
            }
        }

        public void frameshift(int n)
        {
            for (int i = 0; i < n; i++)
                sfmt.Next();
            cnt += n;
        }

        public void CopyTo(ModelStatus st)
        {
            st.remain_frame = (int[])remain_frame.Clone();
            st.phase = phase;
        }
    }
}