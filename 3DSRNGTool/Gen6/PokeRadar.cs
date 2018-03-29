using Pk3DSRNGTool.RNG;

namespace Pk3DSRNGTool
{
    public class PokeRadar
    {
        public static PokeRadarResult Generate(TinyMT src, int PKMNUM, int Chainlength, bool Music = true)
        {
            rng = new TinyMT(src.status);

            var rt = new PokeRadarResult();
            
            rt.Music = getrand(100);

            for (ulong ring = 0; ring < 4; ring++)
            {
                rt.Direction[ring] = getrand(4);
                rt.Location[ring] = getrand(ring * 2 + 3);
                if (getrand(100) < GoodRate[ring])
                {
                    advance();
                    ulong Chance = Music ? 100 : (ulong)(8100 - Chainlength * 200);
                    rt.State[ring] = (byte)(getrand(Chance) == 0 ? 2 : 1);
                }
            }

            return rt;
        }

        public static byte[] GoodRate = { 23, 43, 63, 83 };

        private static TinyMT rng;
        private static byte getrand(ulong n) => (byte)((rng.Nextuint() * n) >> 32);
        private static void advance() => rng.Next();
    }
}
