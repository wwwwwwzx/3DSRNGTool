using System;
using System.Linq;
using Pk3DSRNGTool.RNG;
using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public static class SOSRNG
    {
        private static uint rand => RNGPool.getrand;
        public static byte Rate1 = 3;
        public static byte Rate2 = 3;
        public static SOSResult Generate()
        {
            var rt = new SOSResult();
            
            // First 2 frames for sos call
            rt.Call1 = (byte)(rand % 100);
            rt.Call2 = (byte)(rand % 100);
            
            // Generate SOS Pokemon (sync, slot, level, held item)
            rt.Sync = rand % 100 >= 50;
            if (Weather)
                rt.Slot = getWeatherSlot(rand % 100);
            if (rt.Slot == 0)
                rt.Slot = getSOSSlot(rand % 100);
            rt.Level = (byte)(rand % 4);
            Advance(1);

            rt.HeldItem = (byte)(rand % 100);

            // Chaining bonus
            while (rt.BumpedIVs.Count(iv => iv) < FlawlessCount)
                rt.BumpedIVs[rand % 6] = true;
            rt.HA = rand % 100 < HARate;
            return rt;
        }

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
        public static byte getWeatherSlot(uint tmp)
        {
            if (tmp < 1)  // 1%
                return 8;
            if (tmp <= 10) // 10%
                return 9;
            return 0;
        }

        public static byte getSOSSlot(uint tmp)
        {
            if (tmp < 3)  // 1%
                return (byte)(tmp + 1); // 1/2/3
            if (tmp < 33) // 10%
                return (byte)((tmp - 3) / 10 + 4); // 4/5/6
            return 7;
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
