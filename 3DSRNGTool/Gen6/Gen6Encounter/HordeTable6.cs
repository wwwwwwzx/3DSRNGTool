using System;
using System.Linq;
using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public abstract class HordeArea : EncounterArea
    {
        public override int Locationidx => Location + (idx << 9);
        public override int[] Species { get; set; } = new int[3];
        protected byte Level;
    }

    public class HordeArea_XY : HordeArea
    {
        private readonly static int[] XList = { 311, 312, 335, 336, 304, 228 };
        private readonly static int[] YList = { 312, 311, 336, 335, 246, 309 };
        private readonly static int[][] SpecialHorde =
        {
            // Main, Alt, Slot of 5, Slot of horde(3)
           new[] { 311, 312, 3, 2 },
           new[] { 335, 336, 1, 1 },
           new[] { 032, 029, 4, 0 },
           new[] { 128, 241, 1, 2 },
           new[] { 524, 703, 3, 2 },
           new[] { 709, 185, 3, 2 },
           new[] { 632, 631, 3, 2 },
        };
        private readonly static int[] Special = SpecialHorde.Select(t => t[0]).ToArray();

        public override bool VersionDifference => Species.Any(i => XList.Contains(i));

        public int[] getSpecies(bool IsY, byte Slot)
        {
            int[] table = new int[5];
            int species = Species[Slot - 1];
            for (int i = 0; i < 5; i++)
                table[i] = species;
            int idx = Array.IndexOf(Special, species);
            if (idx > -1 && SpecialHorde[idx][3] == Slot)
                table[SpecialHorde[idx][2]] = SpecialHorde[idx][1];
            if (IsY && VersionDifference)  // Replace XY species
                for (int i = 0; i < 5; i++)
                {
                    idx = Array.IndexOf(XList, table[i]);
                    if (idx > -1)
                        table[i] = XList[idx];
                }
            return table;
        }

        public readonly HordeArea_XY[] Table =
        {
            new HordeArea_XY
            {
               Location = 028, // Route 5
               Species = new[] {316, 559, 311},
               Level = 5,
            },
            new HordeArea_XY
            {
               Location = 038, // Route 7
               Species = new[] {187, 054, 315},
               Level = 7,
            },
            new HordeArea_XY
            {
               Location = 042, // Route 8
               Species = new[] {278, 335, 276},
               Level = 7,
            },
            new HordeArea_XY
            {
               Location = 050, // Route 10
               Species = new[] {299, 193, 228},
               Level = 10,
            },
            new HordeArea_XY
            {
               Location = 054, // Route 11
               Species = new[] {032, 434, 396},
               Level = 11,
            },
            new HordeArea_XY
            {
               Location = 062, // Route 12
               Species = new[] {278, 179, 128},
               Level = 13,
            },
            new HordeArea_XY
            {
               Location = 068, // Route 14
               Species = new[] {069, 451, 023},
               Level = 16,
            },
            new HordeArea_XY
            {
               Location = 074, // Route 15
               Species = new[] {198, 590, 707},
               Level = 18,
            },
            new HordeArea_XY
            {
               Location = 078, // Route 16
               Species = new[] {198, 590, 707},
               Level = 18,
            },
            new HordeArea_XY
            {
               Location = 088, // Route 18
               Species = new[] {074, 632, 632},
               Level = 23,
            },
            new HordeArea_XY
            {
               Location = 092, // Route 19
               Species = new[] {070, 207, 024},
               Level = 24,
            },
            new HordeArea_XY
            {
               Location = 096, // Route 20
               Species = new[] {590, 709, 709},
               Level = 25,
            },
            new HordeArea_XY
            {
               Location = 100, // Route 21
               Species = new[] {327, 333, 123},
               Level = 26,
            },
            new HordeArea_XY
            {
               Location = 056, // Reflection Cave
               Species = new[] {439, 524, 524},
               Level = 11,
            },
            new HordeArea_XY
            {
               Location = 082, // Frost Cavern
               Species = new[] {582, 613, 238},
               Level = 20,
            },
            new HordeArea_XY
            {
               Location = 098, // Pokémon Village
               Species = new[] {590, 060, 271},
               Level = 25,
            },
            new HordeArea_XY
            {
               Location = 104, // Victory Road
               Species = new[] {074, 419, 108},
               Level = 28,
            },
            new HordeArea_XY
            {
               Location = 134, // Connecting Cave
               Species = new[] {293, 041, 610},
               Level = 7,
            },
            new HordeArea_XY
            {
               Location = 140, // Terminus Cave
               Species = new[] {632, 074, 304},
               Level = 23,
            },
            new HordeArea_XY
            {
               Location = 112, // Azure Bay
               Species = new[] {278, 079, 102},
               Level = 13,
            },
        };
    }

    public class HordeArea_ORAS : HordeArea
    {
        private readonly static int[] ORList = { 311, 312, 303, 109, 273 };
        private readonly static int[] ASList = { 312, 311, 302, 088, 270 };
        private readonly static int[][] SpecialHorde =
        {
            // Main, Alt, Slot of 5, Slot of horde(3), location
            new[] { 312, 311, 1, 2, 222},
            new[] { 043, 263, 4, 0, 236},
            new[] { 296, 074, 2, 1, 280},
            // Swablu in Lotad
        };
        private readonly static int[] Special = SpecialHorde.Select(t => t[0]).ToArray();

        public override bool VersionDifference => Species.Any(i => ORList.Contains(i));

        public int[] getSpecies(bool IsAS, byte Slot)
        {
            int[] table = new int[5];
            int species = Species[Slot - 1];
            for (int i = 0; i < 5; i++)
                table[i] = species;
            int idx = Array.IndexOf(Special, species);
            if (idx > -1 && SpecialHorde[idx][3] == Slot && SpecialHorde[idx][4] == Location)
                table[SpecialHorde[idx][2]] = SpecialHorde[idx][1];
            if (IsAS && VersionDifference)  // Replace ORAS species
            {
                for (int i = 0; i < 5; i++)
                {
                    idx = Array.IndexOf(ORList, table[i]);
                    if (idx > -1)
                        table[i] = ORList[idx];
                }
                if (Location == 230 && species == 270) //Route 114
                    table[3] = 333;
            }
            return table;
        }

        public readonly static HordeArea_ORAS[] table =
        {
            new HordeArea_ORAS
            {
                Location = 204, // Route 101
                Species = new[] {263, 263, 261},
                Level = 2,
            },
            new HordeArea_ORAS
            {
                Location = 206, // Route 102
                Species = new[] {263, 273, 280},
                Level = 2,
            },
            new HordeArea_ORAS
            {
                Location = 208, // Route 103
                Species = new[] {263, 261, 278},
                Level = 2,
            },
            new HordeArea_ORAS
            {
                Location = 210, idx = 1, // Route 104
                Species = new[] {263, 263, 276},
                Level = 3,
            },
            new HordeArea_ORAS
            {
                Location = 210, idx = 2, // Route 104
                Species = new[] {263, 263, 278},
                Level = 2,
            },
            new HordeArea_ORAS
            {
                Location = 222, // Route 110
                Species = new[] {081, 312, 312},
                Level = 6,
            },
            new HordeArea_ORAS
            {
                Location = 224, // Route 111
                Species = new[] {027, 027, 027},
                Level = 11,
            },
            new HordeArea_ORAS
            {
                Location = 226, // Route 112
                Species = new[] {322, 066, 322},
                Level = 8,
            },
            new HordeArea_ORAS
            {
                Location = 228, // Route 113
                Species = new[] {327, 327, 227},
                Level = 9,
            },
            new HordeArea_ORAS
            {
                Location = 230, // Route 114
                Species = new[] {333, 273, 333},
                Level = 9,
            },
            new HordeArea_ORAS
            {
                Location = 232, // Route 115
                Species = new[] {333, 333, 333},
                Level = 10,
            },
            new HordeArea_ORAS
            {
                Location = 234, // Route 116
                Species = new[] {263, 290, 300},
                Level = 4,
            },
            new HordeArea_ORAS
            {
                Location = 236, // Route 117
                Species = new[] {043, 315, 183},
                Level = 7,
            },
            new HordeArea_ORAS
            {
                Location = 238, // Route 118
                Species = new[] {309, 278, 352},
                Level = 12,
            },
            new HordeArea_ORAS
            {
                Location = 240, // Route 119
                Species = new[] {043, 043, 043},
                Level = 12,
            },
            new HordeArea_ORAS
            {
                Location = 242, // Route 120
                Species = new[] {043, 183, 352},
                Level = 13,
            },
            new HordeArea_ORAS
            {
                Location = 244, // Route 121
                Species = new[] {353, 278, 352},
                Level = 15,
            },
            new HordeArea_ORAS
            {
                Location = 248, // Route 123
                Species = new[] {353, 278, 352},
                Level = 15,
            },
            new HordeArea_ORAS
            {
                Location = 272, idx = 1, // Meteor Falls
                Species = new[] {041, 041, 041},
                Level = 9,
            },
            new HordeArea_ORAS
            {
                Location = 272, idx = 2, // Meteor Falls
                Species = new[] {041, 041, 371},
                Level = 20,
            },
            new HordeArea_ORAS
            {
                Location = 274, // Rusturf Tunnel
                Species = new[] {293, 293, 293},
                Level = 5,
            },
            new HordeArea_ORAS
            {
                Location = 280, idx = 1, // Granite Cave
                Species = new[] {041, 296, 296},
                Level = 6,
            },
            new HordeArea_ORAS
            {
                Location = 280, idx = 2, // Granite Cave
                Species = new[] {041, 304, 304},
                Level = 6,
            },
            new HordeArea_ORAS
            {
                Location = 280, idx = 3, // Granite Cave
                Species = new[] {041, 304, 303},
                Level = 6,
            },
            new HordeArea_ORAS
            {
                Location = 282, // Petalburg Woods
                Species = new[] {265, 263, 285},
                Level = 3,
            },
            new HordeArea_ORAS
            {
                Location = 286, // Jagged Pass
                Species = new[] {066, 325, 066},
                Level = 10,
            },
            new HordeArea_ORAS
            {
                Location = 288, // Fiery Path
                Species = new[] {322, 109, 218},
                Level = 8,
            },
            new HordeArea_ORAS
            {
                Location = 290, idx = 1, // Mt. Pyre
                Species = new[] {353, 353, 353},
                Level = 15,
            },
            new HordeArea_ORAS
            {
                Location = 290, idx = 2, // Mt. Pyre
                Species = new[] {353, 307, 037},
                Level = 15,
            },
            new HordeArea_ORAS
            {
                Location = 294, // Seafloor Cavern
                Species = new[] {041, 041, 041},
                Level = 18,
            },
            new HordeArea_ORAS
            {
                Location = 298, // Victory Road
                Species = new[] {041, 304, 294},
                Level = 20,
            },
            new HordeArea_ORAS
            {
                Location = 300, idx = 1, // Shoal Cave
                Species = new[] {041, 363, 363},
                Level = 17,
            },
            new HordeArea_ORAS
            {
                Location = 300, idx = 2, // Shoal Cave
                Species = new[] {363, 041, 041},
                Level = 17,
            },
            new HordeArea_ORAS
            {
                Location = 300, idx = 3, // Shoal Cave
                Species = new[] {041, 363, 361},
                Level = 17,
            },
            new HordeArea_ORAS
            {
                Location = 302, // New Mauville
                Species = new[] {100, 081, 100},
                Level = 12,
            },
            new HordeArea_ORAS
            {
                Location = 312, // Scorched Slab
                Species = new[] {041, 041, 041},
                Level = 14,
            },
            new HordeArea_ORAS
            {
                Location = 316, // Sky Pillar
                Species = new[] {042, 168, 333},
                Level = 23,
            },
            new HordeArea_ORAS
            {
                Location = 324, // Safari Zone
                Species = new[] {084, 043, 054},
                Level = 15,
            },
            new HordeArea_ORAS
            {
                Location = 296, // Cave of Origin
                Species = new[] {041, 041, 041},
                Level = 18,
            },
        };
    }
}