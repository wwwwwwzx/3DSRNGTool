using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public class Pokerus7
    {
        private static ulong getrand => RNGPool.getrand64;
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
            byte low8bits = 0;
            do { low8bits = (byte)getrand; } while ((low8bits & 0x7) == 0);
            if ((low8bits & 0xF0) != 0)
                low8bits &= 0x7;

            return low8bits;
        }
    }
}