using System.Linq;
using Pk3DSRNGTool.RNG;

namespace Pk3DSRNGTool
{
    public class PokeRadar
    {
        // Result
        public byte music;
        public Patch[] patches = new Patch[5];
        public char Music => music < 2 ? 'A' : music > 49 ? 'M' : '-';
        public bool Shiny => patches.Any(p => p.state == 2);
        public string[] Overview
        {
            get
            {
                var a = new bool[9].Select(b => Enumerable.Repeat('#', 9).ToArray()).ToArray(); // 9x9 '#'
                a[4][4] = 'C'; // Center
                foreach (var p in patches)
                    if (a[p.Y][p.X] == '#')
                        a[p.Y][p.X] = p.State;
                return a.Select(t => new string(t)).ToArray();
            }
        }

        // RNG
        private static TinyMT rng;
        private static byte Rand(ulong n) => (byte)((rng.Nextuint() * n) >> 32);
        public PokeRadar(uint[] src, int PKMNUM, int Chainlength, bool Boost = true)
        {
            rng = new TinyMT(src);

            for (int i = 3 * PKMNUM; i > 0; i--)
                rng.Next();

            music = Rand(100);
            if (Boost && music < 50)
                Boost = false;

            // 4 Pokemon patches
            byte ring = 0;
            for (; ring < 4; ring++)
            {
                patches[ring] = new Patch
                {
                    Ring = ring,
                    Direction = Rand(4),
                    Location = Rand(ring * 2ul + 3ul),
                };
                if (Rand(100) < GoodRate[ring])
                {
                    rng.Next();
                    if (Chainlength > 40)
                        Boost = true;
                    ulong Chance = Boost ? 100 : (ulong)(8100 - Chainlength * 200);
                    patches[ring].state = (byte)(rng.Nextuint() * Chance <= uint.MaxValue ? 2 : 1);
                }
            }

            // 1 empty patch
            ring = Rand(3);
            patches[4] = new Patch
            {
                Ring = ring,
                Direction = Rand(4),
                Location = Rand(ring * 2ul + 3ul),
                state = 3,
            };
        }

        public static byte[] GoodRate = { 23, 43, 63, 83 }; // 33 53 73 93 when?
    }

    public struct Patch
    {
        private static string StateChars = "BGSX"; // Bad / Good / Shiny / Empty (Never step in)
        public byte Ring;
        public byte Direction;
        public byte Location;
        public byte state;
        public char State => StateChars[state];
        public int X
        {
            get
            {
                switch (Direction)
                {
                    case 0:
                    case 1:
                        return 3 - Ring + Location;
                    case 2:
                        return 3 - Ring;
                    case 3:
                        return 5 + Ring;
                }
                return 4;
            }
        }
        public int Y
        {
            get
            {
                switch (Direction)
                {
                    case 0:
                        return 3 - Ring;
                    case 1:
                        return 5 + Ring;
                    case 2:
                    case 3:
                        return 3 - Ring + Location;
                }
                return 4;
            }
        }
    }
}
