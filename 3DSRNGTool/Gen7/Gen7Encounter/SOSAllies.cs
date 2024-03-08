using System.Linq;
using System.Collections.Generic;

namespace Pk3DSRNGTool
{
    public class SOSAllies
    {
        private int Species;

        // Rules
        private byte slottype;
        private int[] Ally;
        private int Baby; // For baby mon, replace 5th slots
        private int[] getAllies(bool IsNight)
        {
            int[] Allies = Enumerable.Repeat(Species, 7).ToArray(); // Default
            if (Baby > 0)
                Allies[4] = Baby;
            switch (slottype)
            {
                case 1: // First 1
                    Allies[0] = Ally[0];
                    break;
                case 2: // All replaced
                    Allies = Enumerable.Repeat(Ally[0], 7).ToArray();
                    break;
                case 3: // First 3
                    int A = Ally[0];
                    if (IsNight && A == 196 || !IsNight && A == 367) // Espeon at night or Gorebyss at day
                        A++;
                    Allies[0] = Allies[1] = Allies[2] = A;
                    break;
                case 4: // First 4
                    Allies[0] = Allies[1] = Allies[2] = Allies[3] = Ally[0];
                    break;
                case 5: // 4/3
                    Allies[0] = Allies[1] = Allies[2] = Allies[3] = Ally[0];
                    Allies[4] = Allies[5] = Allies[6] = Ally[1];
                    break;
                case 6: // First 6
                    Allies[0] = Allies[1] = Allies[2] = Allies[3] = Allies[4] = Allies[5] = Ally[0];
                    break;
                case 7: // Last 1
                    Allies[6] = Ally[0];
                    break;
                case 8:
                    Allies[3] = Allies[4] = Ally[0];
                    break;
                case 9: // 1/3
                    Allies[0] = Ally[0];
                    Allies[1] = Allies[2] = Allies[3] = Ally[1];
                    break;
                case 10:
                    Allies[4] = Allies[5] = Ally[0];
                    break;
                case 11: // 3/4
                    Allies[0] = Allies[1] = Allies[2] = Ally[0];
                    Allies[3] = Allies[4] = Allies[5] = Allies[6] = Ally[1];
                    break;
            }
            return Allies;
        }

        // Special Spot
        private int[] Locations;
        private bool? Ultra = null;
        private bool Default => Ultra == null && Locations == null;
        private bool MeetRequire(int loc, bool IsUltra)
        {
            if (Locations == null)
                return IsUltra == Ultra;
            if (Ultra == null)
                return Locations.Contains(loc);
            return IsUltra == Ultra && Locations.Contains(loc);
        }

        public static int[] getAllies(int LocationIndex, int species, int Ver, bool IsNight)
        {
            if (PersonalTable.USUM.getFormeEntry(species & 0x7FF, species >> 11).EscapeRate == 0) // Zero call rate
                return new int[7];
            bool IsUltra = Ver > 6;
            if (IsUltra && LocationIndex == 124 && species != 0) // Haina Desert
            {
                var tmp = Enumerable.Repeat(species, 7).ToArray();
                tmp[5] = Ver == 7 ? 622 : 343;
                return tmp;
            }
            var candidacies = Table.Where(t => t.Species == species);
            if (candidacies.Count() == 0)
                return Enumerable.Repeat(species, 7).ToArray();
            var firstmatch = candidacies.FirstOrDefault(t => t.MeetRequire(LocationIndex & 0xFF, IsUltra));
            return (firstmatch ?? candidacies.FirstOrDefault(t => t.Default) ?? new SOSAllies { Species = species, }).getAllies(IsNight);
        }

        private static SOSAllies[] Table =
        {
            new SOSAllies{ Species = 010, Locations = new[] {006,008} },
            new SOSAllies{ Species = 010, slottype = 4, Ally = new[] {012}, },
            new SOSAllies{ Species = 011, slottype = 2, Ally = new[] {010}, Locations = new[] {006}, },
            new SOSAllies{ Species = 011, slottype = 5, Ally = new[] {012, 010}, },
            new SOSAllies{ Species = 041, slottype = 4, Ally = new[] {042}, Locations = new[] {076, 100}, Ultra = true},
            new SOSAllies{ Species = 042, slottype = 3, Ally = new[] {169}, Locations = new[] {090, 182}, },
            new SOSAllies{ Species = 2100, slottype = 4, Ally = new[] {2101}, Ultra = true, },
            new SOSAllies{ Species = 079, slottype = 3, Ally = new[] {080}, Locations = new[] {014}, Ultra = false, },
            new SOSAllies{ Species = 079, slottype = 9, Ally = new[] {199,080}, Locations = new[] {014}, Ultra = true, },
            new SOSAllies{ Species = 093, slottype = 1, Ally = new[] {094}, },
            new SOSAllies{ Species = 104, Baby = 115, },
            new SOSAllies{ Species = 113, slottype = 8, Ally = new[] {242}, Ultra = true, },
            new SOSAllies{ Species = 118, slottype = 4, Ally = new[] {119}, },
            new SOSAllies{ Species = 120, slottype = 3, Ally = new[] {121}, Locations = new[] {056}, Ultra = false, },
            new SOSAllies{ Species = 120, slottype = 3, Ally = new[] {121}, Ultra = true, },
            new SOSAllies{ Species = 128, slottype = 7, Ally = new[] {241}, },
            new SOSAllies{ Species = 129, slottype = 4, Ally = new[] {130}, },
            new SOSAllies{ Species = 133, slottype = 3, Ally = new[] {196}, },
            new SOSAllies{ Species = 147, slottype = 4, Ally = new[] {148}, },
            new SOSAllies{ Species = 147, slottype = 9, Ally = new[] {149,148}, Locations = new[] {170}, },
            new SOSAllies{ Species = 163, slottype = 4, Ally = new[] {164}, },
            new SOSAllies{ Species = 170, slottype = 4, Ally = new[] {171}, Ultra = true, },
            new SOSAllies{ Species = 172, slottype = 4, Ally = new[] {025}, Baby = 440, },
            new SOSAllies{ Species = 173, slottype = 4, Ally = new[] {035}, Baby = 440, Ultra = true,},
            new SOSAllies{ Species = 173, slottype = 4, Ally = new[] {035}, Baby = 113, Ultra = false,},
            new SOSAllies{ Species = 174, slottype = 4, Ally = new[] {039}, Baby = 440, },
            new SOSAllies{ Species = 177, slottype = 4, Ally = new[] {178}, },
            new SOSAllies{ Species = 190, slottype = 3, Ally = new[] {424}, },
            new SOSAllies{ Species = 222, slottype = 6, Ally = new[] {747}, },
            new SOSAllies{ Species = 223, slottype = 4, Ally = new[] {224}, },
            new SOSAllies{ Species = 238, slottype = 3, Ally = new[] {124}, Baby = 440, },
            new SOSAllies{ Species = 239, slottype = 4, Ally = new[] {125}, Baby = 440, Ultra = true, },
            new SOSAllies{ Species = 239, slottype = 4, Ally = new[] {125}, Baby = 113, Ultra = false,},
            new SOSAllies{ Species = 240, slottype = 4, Ally = new[] {126}, Baby = 440, Ultra = true,},
            new SOSAllies{ Species = 240, slottype = 4, Ally = new[] {126}, Ultra = false,},
            new SOSAllies{ Species = 241, slottype = 7, Ally = new[] {128}, },
            new SOSAllies{ Species = 318, slottype = 4, Ally = new[] {319}, },

            new SOSAllies{ Species = 339, slottype = 4, Ally = new[] {340}, },
            new SOSAllies{ Species = 341, slottype = 4, Ally = new[] {342}, },
            new SOSAllies{ Species = 361, slottype = 7, Ally = new[] {362}, Ultra = false, },
            new SOSAllies{ Species = 366, slottype = 3, Ally = new[] {367}, },
            new SOSAllies{ Species = 371, slottype = 3, Ally = new[] {372}, Locations = new[] {014}, },
            new SOSAllies{ Species = 371, slottype = 1, Ally = new[] {373}, Locations = new[] {010}, },
            new SOSAllies{ Species = 427, slottype = 3, Ally = new[] {428}, },
            new SOSAllies{ Species = 438, slottype = 3, Ally = new[] {185}, Baby = 440, Locations = new[] {008},},
            new SOSAllies{ Species = 438, slottype = 4, Ally = new[] {185}, Baby = 440, Locations = new[] {090},},
            new SOSAllies{ Species = 438, slottype = 4, Ally = new[] {185}, Baby = 440, Locations = new[] {090},},
            new SOSAllies{ Species = 439, slottype = 3, Ally = new[] {122}, Baby = 440, },
            new SOSAllies{ Species = 446, slottype = 1, Ally = new[] {143}, Baby = 440, },
            new SOSAllies{ Species = 447, slottype = 3, Ally = new[] {448}, Baby = 440, Ultra = true, },
            new SOSAllies{ Species = 447, slottype = 3, Ally = new[] {448}, Baby = 113, Ultra = false,},
            new SOSAllies{ Species = 458, slottype = 10, Ally = new[] {223}, },
            new SOSAllies{ Species = 568, slottype = 4, Ally = new[] {569}, Ultra = false, },
            new SOSAllies{ Species = 625, slottype = 2, Ally = new[] {624}, },
            new SOSAllies{ Species = 636, slottype = 1, Ally = new[] {637}, },
            new SOSAllies{ Species = 661, slottype = 4, Ally = new[] {662}, Ultra = true, },
            new SOSAllies{ Species = 674, slottype = 7, Ally = new[] {675}, },
            new SOSAllies{ Species = 702, slottype = 10, Ally = new[] {777}, Ultra = true, },
            new SOSAllies{ Species = 703, slottype = 7, Ally = new[] {302}, },
            new SOSAllies{ Species = 732, slottype = 2, Ally = new[] {731}, Locations = new[]{058}, Ultra = false, },
            new SOSAllies{ Species = 732, slottype = 4, Ally = new[] {733}, Locations = new[]{164,166}, Ultra = true, },
            new SOSAllies{ Species = 732, slottype = 3, Ally = new[] {733}, Locations = new[]{108}, Ultra = true, },
            new SOSAllies{ Species = 734, slottype = 4, Ally = new[] {735}, Locations = new[]{058}, Ultra = true, },
            new SOSAllies{ Species = 737, slottype = 11, Ally = new[] {738,736}, Locations = new[]{138}, Ultra = true, },
            new SOSAllies{ Species = 749, slottype = 4, Ally = new[] {750}, Ultra = true,},
            new SOSAllies{ Species = 757, slottype = 1, Ally = new[] {758}, Ultra = true,},
            new SOSAllies{ Species = 765, slottype = 2, Ally = new[] {732}, },
            new SOSAllies{ Species = 766, slottype = 2, Ally = new[] {732}, },
            new SOSAllies{ Species = 777, slottype = 10, Ally = new[] {702}, Ultra = true, },
            new SOSAllies{ Species = 782, slottype = 11, Ally = new[] {784,783}, },
        };


        private static readonly HashSet<int> WeatherLocations = new HashSet<int>
        {
            134, 090, 120, 184,
            114, 146,
            124,
        };
        public enum Weather
        {
            None, Rain, Hail, Sand,
        }
        public static int[] getWeatherAllies(int LocationIndex, int weather, bool IsUltra, bool IsNight)
        {
            int Location = LocationIndex & 0xFF;
            int Index = LocationIndex >> 8;
            if (weather == (int)Weather.None || !WeatherLocations.Contains(Location))
                return new int[2];
            int[] tmp = new[] {351, 351}; // Castform
            switch ((Weather)weather)
            {
                case Weather.Rain when Location == 134: tmp[0] = IsNight ? 186 : 062; tmp[1] = 061; break; // Poli Line
                case Weather.Rain when Location == 090 || Location == 120: tmp[1] = 704; break; // Goomy
                case Weather.Rain when Location == 184: tmp[1] = 705; break; // Siggoo
                case Weather.Hail when Location == 114 || Location == 146 && IsUltra && Index == 1: tmp[1] = 582; break; // Vanillite
                case Weather.Hail when Location == 146: if (IsUltra) tmp[0] = 584; tmp[1] = 583; break; // Vanillish + Vaniluxe
                case Weather.Sand when Location == 124: tmp[1] = 444; break; // Gabite
            }
            return tmp;
        }
    }
}
