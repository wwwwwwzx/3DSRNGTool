namespace Gen6RNGTool.RNG
{
    public class TinyMT : IRNG
    {
        public TinyMT(uint[] status)
        {
            this.status = new uint[4];
            for (int i = 0; i < 4; i++)
            {
                this.status[i] = status[i];
            }
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
                status[1] ^= param.mat1;
                status[2] ^= param.mat2;
            }
        }

        public uint temper()
        {
            uint t0 = status[3];
            uint t1 = status[0] + (status[2] >> TINYMT32_SH8);

            t0 ^= t1;
            if ((t1 & 1) == 1)
            {
                t0 ^= param.tmat;
            }
            return t0;
        }

        #region IRNG Member
        public uint Next()
        {
            return temper();
        }

        public uint Nextuint()
        {
            return temper();
        }

        public void Reseed(uint seed)
        {
            return; // Todo
        }
        #endregion

        private const uint TINYMT32_MASK = 0x7FFFFFFF;
        private const int TINYMT32_SH0 = 1;
        private const int TINYMT32_SH1 = 10;
        private const int TINYMT32_SH8 = 8;

        public uint[] status { get; set; }

        private class TinyMTParameter
        {
            public TinyMTParameter(uint mat1, uint mat2, uint tmat)
            {
                this.mat1 = mat1;
                this.mat2 = mat2;
                this.tmat = tmat;
            }

            public uint mat1 { get; }
            public uint mat2 { get; }
            public uint tmat { get; }
        }
        private readonly TinyMTParameter param = new TinyMTParameter(0x8f7011ee, 0xfc78ff1f, 0x3793fdff);
    }
}
