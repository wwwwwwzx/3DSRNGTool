using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public class Pokerus6
    {
        private static uint getrand => RNGPool.getrand; // MersenneTwister
        private static void Advance() => RNGPool.Advance(1);

        public static byte getStrain()
        {
            // Check
            ushort low16bits = (ushort)getrand;
            if (!(low16bits == 0x4000 || low16bits == 0x8000 || low16bits == 0xC000))
                return 0;

            // Random slots
            Advance();

            // Calc Strain
            byte high8bits = 0;
            do { high8bits = (byte)(getrand >> 24); } while ((high8bits & 0x7) == 0);
            if ((high8bits & 0xF0) != 0)
                high8bits &= 0x7;

            return high8bits;
        }
    }
}