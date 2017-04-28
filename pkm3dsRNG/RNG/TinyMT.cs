namespace pkm3dsRNG.RNG
{
    public class TinyMT : IRNG
    {
        public uint[] status { get; set; }
        public uint mat1 { get; } = 0x8f7011ee;
        public uint mat2 { get; } = 0xfc78ff1f;
        public uint tmat { get; } = 0x3793fdff;

        private const int MIN_LOOP = 8;
        private const int PRE_LOOP = 8;

        private const uint TINYMT32_MASK = 0x7FFFFFFF;
        private const int TINYMT32_SH0 = 1;
        private const int TINYMT32_SH1 = 10;
        private const int TINYMT32_SH8 = 8;

        public TinyMT(uint seed)
        {
            init(seed);
        }

        public TinyMT(uint[] st)
        {
            status = new uint[4];
            st.CopyTo(status, 0);
        }

        public void init(uint seed)
        {
            status = new uint[] { seed, mat1, mat2, tmat };

            for (int i = 1; i < MIN_LOOP; i++)
                status[i & 3] ^= (uint)i + 1812433253U * (status[(i - 1) & 3] ^ (status[(i - 1) & 3] >> 30));

            period_certification();

            for (int i = 0; i < PRE_LOOP; i++)
                nextState();
        }

        public void nextState()
        {
            uint y = status[3];
            uint x = (status[0] & TINYMT32_MASK) ^ status[1] ^ status[2];
            x ^= (x << TINYMT32_SH0);
            y ^= (y >> TINYMT32_SH0) ^ x;
            status[0] = status[1];
            status[1] = status[2];
            status[2] = x ^ (y << TINYMT32_SH1);
            status[3] = y;

            if ((y & 1) == 1)
            {
                status[1] ^= mat1;
                status[2] ^= mat2;
            }
        }

        public uint temper()
        {
            uint t0 = status[3];
            uint t1 = status[0] + (status[2] >> TINYMT32_SH8);

            t0 ^= t1;
            if ((t1 & 1) == 1)
            {
                t0 ^= tmat;
            }
            return t0;
        }

        #region IRNG Member
        public void Next()
        {
            nextState();
        }

        public uint Nextuint()
        {
            nextState();
            return temper();
        }

        public void Reseed(uint seed)
        {
            init(seed);
        }
        #endregion

        private void period_certification()
        {
            if ((status[0] & TINYMT32_MASK) == 0 && status[1] == 0 && status[2] == 0 && status[3] == 0)
                status = new uint[] { 'T', 'I', 'N', 'Y' };
        }
    }
}
