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
using System;

namespace Pk3DSRNGTool.RNG
{
    /// <summary>
    /// SFMTの擬似乱数ジェネレータークラス。
    /// </summary>
    [Serializable()]
    public class SFMT : IRNG64
    {
        #region Fields

        /// <summary>
        /// 周期を表す指数。
        /// </summary>
        public int MEXP;
        /// <summary>
        /// MTを決定するパラメーターの一つ。
        /// </summary>
        public int POS1;
        /// <summary>
        /// MTを決定するパラメーターの一つ。
        /// </summary>
        public int SL1;
        /// <summary>
        /// MTを決定するパラメーターの一つ。
        /// </summary>
        public int SL2;
        /// <summary>
        /// MTを決定するパラメーターの一つ。
        /// </summary>
        public int SR1;
        /// <summary>
        /// MTを決定するパラメーターの一つ。
        /// </summary>
        public int SR2;
        /// <summary>
        /// MTを決定するパラメーターの一つ。
        /// </summary>
        public uint MSK1;
        /// <summary>
        /// MTを決定するパラメーターの一つ。
        /// </summary>
        public uint MSK2;
        /// <summary>
        /// MTを決定するパラメーターの一つ。
        /// </summary>
        public uint MSK3;
        /// <summary>
        /// MTを決定するパラメーターの一つ。
        /// </summary>
        public uint MSK4;
        /// <summary>
        /// MTの周期を保証するための確認に用いるパラメーターの一つ。
        /// </summary>
        public uint PARITY1;
        /// <summary>
        /// MTの周期を保証するための確認に用いるパラメーターの一つ。
        /// </summary>
        public uint PARITY2;
        /// <summary>
        /// MTの周期を保証するための確認に用いるパラメーターの一つ。
        /// </summary>
        public uint PARITY3;
        /// <summary>
        /// MTの周期を保証するための確認に用いるパラメーターの一つ。
        /// </summary>
        public uint PARITY4;

        /// <summary>
        /// 各要素を128bitとしたときの内部状態ベクトルの個数。
        /// </summary>
        public int N;
        /// <summary>
        /// 各要素を32bitとしたときの内部状態ベクトルの個数。
        /// </summary>
        public int N32;
        /// <summary>
        /// 計算の高速化用。
        /// </summary>
        public int SL2_x8;
        /// <summary>
        /// 計算の高速化用。
        /// </summary>
        public int SR2_x8;
        /// <summary>
        /// 計算の高速化用。
        /// </summary>
        public int SL2_ix8;
        /// <summary>
        /// 計算の高速化用。
        /// </summary>
        public int SR2_ix8;

        /// <summary>
        /// 内部状態ベクトル。
        /// </summary>
        public uint[] sfmt;
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
            MEXP = 19937;
            POS1 = 122;
            SL1 = 18;
            SL2 = 1;
            SR1 = 11;
            SR2 = 1;
            MSK1 = 0xdfffffefU;
            MSK2 = 0xddfecb7fU;
            MSK3 = 0xbffaffffU;
            MSK4 = 0xbffffff6U;
            PARITY1 = 0x00000001U;
            PARITY2 = 0x00000000U;
            PARITY3 = 0x00000000U;
            PARITY4 = 0x13c9e684U;
            init_gen_rand(seed);
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
            //変数初期化
            N = MEXP / 128 + 1;
            N32 = N * 4;
            SL2_x8 = SL2 * 8;
            SR2_x8 = SR2 * 8;
            SL2_ix8 = 64 - SL2 * 8;
            SR2_ix8 = 64 - SR2 * 8;
            //内部状態配列確保
            sfmt = new uint[N32];
            //内部状態配列初期化
            sfmt[0] = (uint)seed;
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
            uint[] PARITY = new uint[] { PARITY1, PARITY2, PARITY3, PARITY4 };
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

            const int cMEXP = 19937;
            const int cPOS1 = 122;
            const uint cMSK1 = 0xdfffffefU;
            const uint cMSK2 = 0xddfecb7fU;
            const uint cMSK3 = 0xbffaffffU;
            const uint cMSK4 = 0xbffffff6U;
            const int cSL1 = 18;
            const int cSR1 = 11;
            const int cN = cMEXP / 128 + 1;
            const int cN32 = cN * 4;

            a = 0;
            b = cPOS1 * 4;
            c = (cN - 2) * 4;
            d = (cN - 1) * 4;
            do
            {
                p[a + 3] = p[a + 3] ^ (p[a + 3] << 8) ^ (p[a + 2] >> 24) ^ (p[c + 3] >> 8) ^ ((p[b + 3] >> cSR1) & cMSK4) ^ (p[d + 3] << cSL1);
                p[a + 2] = p[a + 2] ^ (p[a + 2] << 8) ^ (p[a + 1] >> 24) ^ (p[c + 3] << 24) ^ (p[c + 2] >> 8) ^ ((p[b + 2] >> cSR1) & cMSK3) ^ (p[d + 2] << cSL1);
                p[a + 1] = p[a + 1] ^ (p[a + 1] << 8) ^ (p[a + 0] >> 24) ^ (p[c + 2] << 24) ^ (p[c + 1] >> 8) ^ ((p[b + 1] >> cSR1) & cMSK2) ^ (p[d + 1] << cSL1);
                p[a + 0] = p[a + 0] ^ (p[a + 0] << 8) ^ (p[c + 1] << 24) ^ (p[c + 0] >> 8) ^ ((p[b + 0] >> cSR1) & cMSK1) ^ (p[d + 0] << cSL1);
                c = d; d = a; a += 4; b += 4;
                if (b >= cN32) b = 0;
            } while (a < cN32);
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