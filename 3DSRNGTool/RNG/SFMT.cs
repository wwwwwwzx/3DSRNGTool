/*
 * Copyright (C) Rei HOBARA 2007
 * 
 * Name:
 *     SFMT.cs
 * Class:
 *     Rei.Random.SFMT
 * Purpose:
 *     A random number generator using SIMD-oriented Fast Mersenne Twister(SFMT).
 * Remark:
 *     This code is C# implementation of SFMT.
 *     SFMT was introduced by Mutsuo Saito and Makoto Matsumoto.
 *     See http://www.math.sci.hiroshima-u.ac.jp/~m-mat/MT/SFMT/index.html for detail of SFMT.
 * History:
 *     2007/10/6 initial release.
 * 
 */
namespace Pk3DSRNGTool.RNG
{
    /// <summary>
    /// SFMTの擬似乱数ジェネレータークラス。
    /// </summary>
    public class SFMT : IRNG64
    {
        #region Fields

        public const int MEXP = 19937;
        public const int POS1 = 122;
        public const int SL1 = 18;
        public const int SR1 = 11;
        public const uint MSK1 = 0xdfffffefU;
        public const uint MSK2 = 0xddfecb7fU;
        public const uint MSK3 = 0xbffaffffU;
        public const uint MSK4 = 0xbffffff6U;
        public readonly uint[] PARITY = { 1u, 0u, 0u, 0x13c9e684u };

        public const int N = MEXP / 128 + 1;
        public const int N32 = 4 * N;

        /// <summary>
        /// 内部状態ベクトル。
        /// </summary>
        public uint[] sfmt = new uint[N32];
        /// <summary>
        /// 内部状態ベクトルのうち、次に乱数として使用するインデックス。
        /// </summary>
        public int idx;

        #endregion

        /// <summary>
        /// seedを種とした、(2^19937-1)周期の擬似乱数ジェネレーターを初期化します。
        /// </summary>
        public SFMT(uint seed)
        {
            init_gen_rand(seed);
        }

        public SFMT(SFMT old)
        {
            idx = old.idx;
            old.sfmt.CopyTo(sfmt, 0);
        }

        /// <summary>
        /// 符号なし32bitの擬似乱数を取得します。
        /// </summary>
        public uint Nextuint()
        {
            if (idx >= N32)
            {
                gen_rand_all_19937();
                idx = 0;
            }
            return sfmt[idx++];
        }

        /// <summary>
        /// ジェネレーターを初期化します。
        /// </summary>
        /// <param name="seed"></param>
        public void init_gen_rand(uint seed)
        {
            int i;
            //内部状態配列初期化
            sfmt[0] = seed;
            for (i = 1; i < N32; i++)
                sfmt[i] = (uint)(1812433253 * (sfmt[i - 1] ^ (sfmt[i - 1] >> 30)) + i);
            //確認
            period_certification();
            //初期位置設定
            idx = N32;
        }

        /// <summary>
        /// 内部状態ベクトルが適切か確認し、必要であれば調節します。
        /// </summary>
        public void period_certification()
        {
            uint inner = 0;
            int i, j;
            uint work;

            for (i = 0; i < 4; i++) inner ^= sfmt[i] & PARITY[i];
            for (i = 16; i > 0; i >>= 1) inner ^= inner >> i;
            inner &= 1;
            // check OK
            if (inner == 1) return;
            // check NG, and modification
            for (i = 0; i < 4; i++)
            {
                work = 1;
                for (j = 0; j < 32; j++)
                {
                    if ((work & PARITY[i]) != 0)
                    {
                        sfmt[i] ^= work;
                        return;
                    }
                    work = work << 1;
                }
            }
        }

        /// <summary>
        /// gen_rand_allの(2^19937-1)周期用。
        /// </summary>
        private void gen_rand_all_19937()
        {
            int a, b, c, d;
            uint[] p = this.sfmt;

            a = 0;
            b = POS1 * 4;
            c = (N - 2) * 4;
            d = (N - 1) * 4;
            do
            {
                p[a + 3] = p[a + 3] ^ (p[a + 3] << 8) ^ (p[a + 2] >> 24) ^ (p[c + 3] >> 8) ^ ((p[b + 3] >> SR1) & MSK4) ^ (p[d + 3] << SL1);
                p[a + 2] = p[a + 2] ^ (p[a + 2] << 8) ^ (p[a + 1] >> 24) ^ (p[c + 3] << 24) ^ (p[c + 2] >> 8) ^ ((p[b + 2] >> SR1) & MSK3) ^ (p[d + 2] << SL1);
                p[a + 1] = p[a + 1] ^ (p[a + 1] << 8) ^ (p[a + 0] >> 24) ^ (p[c + 2] << 24) ^ (p[c + 1] >> 8) ^ ((p[b + 1] >> SR1) & MSK2) ^ (p[d + 1] << SL1);
                p[a + 0] = p[a + 0] ^ (p[a + 0] << 8) ^ (p[c + 1] << 24) ^ (p[c + 0] >> 8) ^ ((p[b + 0] >> SR1) & MSK1) ^ (p[d + 0] << SL1);
                c = d; d = a; a += 4; b += 4;
                if (b >= N32) b = 0;
            } while (a < N32);
        }

        #region IRNG64 Member
        public void Reseed(uint seed)
        {
            init_gen_rand(seed);
        }

        public ulong Nextulong()
        {
            return Nextuint() | ((ulong)Nextuint() << 32);
        }

        public void Next()
        {
            Nextuint();
            Nextuint();
        }
        #endregion
    }
}