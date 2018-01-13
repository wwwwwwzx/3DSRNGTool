using System;
using System.Linq;
using Pk3DSRNGTool.RNG;
using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public static class SOSRNG
    {
        // First 2 frames for sos call
        private static uint rand => RNGPool.getrand;
        public static byte Rate1;
        public static byte Rate2;
        public static bool Call() => rand % 100 < Rate1 && rand % 100 < Rate2;

        // Generate SOS Pokemon (sync, slot, level, held item)
        private static uint[] Buffer;
        private static byte index;
        private const int BufferSize = 256;
        public static void Reset() => index = 0;
        public static void Advance(byte n) => index += n;
        public static uint getrand => Buffer[index++]; // Output
        public static void SetBuffer(uint seed, int frame)
        {
            Buffer = new uint[BufferSize];
            SFMT sfmt = new SFMT(seed);
            for (int i = 0; i < frame; i++)
                sfmt.Nextuint();
            for (int i = 0; i < BufferSize; i++)
                Buffer[i] = sfmt.Nextuint();
        }

        public static bool Weather;
        public static byte getWeatherSlot()
        {
            var tmp = getrand % 100;
            if (tmp < 1)  // 1%
                return 8;
            if (tmp <= 10) // 10%
                return 9;
            return 0;
        }
        
        public static int PIDBonus;
        private static int HARate;
        private static int FlawlessCount;
        public static int ChainLength
        {
            set
            {
                PIDBonus = Math.Min(12, (value - 1) / 10 * 4);
                FlawlessCount = value > 10 ? Math.Min(4, value / 10 + 1) : value / 5;
                HARate = Math.Min(15, value / 10 * 5);
            }
        }

        public static void PostGeneration(ResultW7 rt)
        {
            while (rt.IVs.Count(iv => iv == 31) < FlawlessCount)
                rt.IVs[getrand % 6] = 31;
            
            if (getrand % 100 < HARate)
                rt.Ability = 3;
        }
    }
}
