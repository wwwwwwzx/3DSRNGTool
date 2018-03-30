using Pk3DSRNGTool.RNG;

namespace Pk3DSRNGTool
{
    public class PokeRadar
    {
        public static PokeRadarResult Generate(TinyMT src, int PKMNUM, int Chainlength, bool Music = true)
        {
            rng = new TinyMT(src.status);

            for (int i = 3 * PKMNUM; i > 0; i--)
                rng.Next();

            var rt = new PokeRadarResult();

            rt.music = getrand(100);

            byte ring = 0;
            for (; ring < 4; ring++)
            {
                rt.patches[ring] = new Patch
                {
                    Ring = ring,
                    Direction = getrand(4),
                    Location = getrand(ring * 2ul + 3ul),
                };
                if (getrand(100) < GoodRate[ring])
                {
                    advance();
                    if (Chainlength > 40)
                        Music = true;
                    ulong Chance = Music ? 100 : (ulong)(8100 - Chainlength * 200);
                    rt.patches[ring].state = (byte)(getrand(Chance) == 0 ? 2 : 1);
                }
            }

            ring = getrand(3);
            rt.patches[4] = new Patch
            {
                Ring = ring,
                Direction = getrand(4),
                Location = getrand(ring * 2ul + 3ul),
                state = 3,
            };

            return rt;
        }

        public static byte[] GoodRate = { 23, 43, 63, 83 }; // 33 53 73 93 when?

        private static TinyMT rng;
        private static byte getrand(ulong n) => (byte)((rng.Nextuint() * n) >> 32);
        private static void advance() => rng.Next();
    }
}
