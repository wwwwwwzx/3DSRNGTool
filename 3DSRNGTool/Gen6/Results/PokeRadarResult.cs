using System.Linq;

namespace Pk3DSRNGTool
{
    public class PokeRadarResult
    {
        public byte music;
        public Patch[] patches = new Patch[5];

        public char Music => music < 2 ? 'A' : music > 49 ? 'M' : '-';
        public bool Shiny => patches.Any(p => p.state == 2);
        public string[] Overview
        {
            get
            {
                var a = new[]
                {
                    "#########",
                    "#########",
                    "#########",
                    "#########",
                    "####C####",
                    "#########",
                    "#########",
                    "#########",
                    "#########",
                }.Select(str => str.ToCharArray()).ToArray();
                foreach (var p in patches)
                    if (a[p.Y][p.X] == '#')
                        a[p.Y][p.X] = p.State;
                return a.Select(t => new string(t)).ToArray();
            }
        }
    }

    public struct Patch
    {
        public static string StateChars = "BGSX"; // Bad / Good / Shiny / Empty (Never step in)
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