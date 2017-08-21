using System.Linq;
using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public static class LocationTable6
    {
        public static EncounterArea[] TableNow;

        public static int[] getLocation(PKMW6 pm, bool IsXY = true)
        {
            EncounterType? type = pm?.Type;
            switch (type)
            {
                case EncounterType.Horde:
                    TableNow = IsXY ? (EncounterArea[])Horde_XY : Horde_ORAS;
                    break;
                case EncounterType.RockSmash:
                    TableNow = IsXY ? RockSmash_XY : RockSmash_ORAS;
                    break;
                case EncounterType.CaveShadow:
                    TableNow = IsXY ? Shadow_XY : null;
                    break;
                case EncounterType.Trap:
                    TableNow = IsXY ? Trap_XY : null;
                    break;
                default:
                    TableNow = null; return null;
            }
            return TableNow.Select(t => t.Locationidx).ToArray();
        }

        #region Horde
        public readonly static HordeArea_ORAS[] Horde_ORAS =
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
        public static readonly HordeArea_XY[] Horde_XY =
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
        #endregion

        #region Rock Smash
        public static readonly RockSmashArea6[] RockSmash_ORAS =
        {
            new RockSmashArea6
            {
               Location = 194, // Lilycove City
               Species = new[]{ 075, 075, 075, 075, 075 },
               Level = new byte[]{ 28, 29, 30, 31, 31 },
            },
            new RockSmashArea6
            {
               Location = 224, // Route 111
               Species = new[]{ 074, 074, 074, 074, 074 },
               Level = new byte[]{ 13, 14, 15, 16, 16 },
            },
            new RockSmashArea6
            {
               Location = 230, // Route 114
               Species = new[]{ 074, 074, 074, 074, 074 },
               Level = new byte[]{ 15, 10, 20, 5, 5 },
            },
            new RockSmashArea6
            {
               Location = 274, // Rusturf Tunnel
               Species = new[]{ 074, 074, 074, 074, 074 },
               Level = new byte[]{ 14, 15, 16, 17, 17 },
            },
            new RockSmashArea6
            {
               Location = 280, // Granite Cave
               Species = new[]{ 074, 074, 299, 074, 299 },
               Level = new byte[]{ 10, 11, 10, 12, 12 },
            },
            new RockSmashArea6
            {
               Location = 294, // Seafloor Cavern
               Species = new[]{ 075, 075, 075, 075, 075 },
               Level = new byte[]{ 33, 34, 35, 36, 36 },
            },
            new RockSmashArea6
            {
               Location = 300, // Shoal Cave
               Species = new[]{ 075, 075, 075, 075, 075 },
               Level = new byte[]{ 31, 32, 33, 34, 34 },
            },
            new RockSmashArea6
            {
               Location = 326, // Mirage Forest
               Species = new[]{ 075, 075, 075, 075, 075 },
               Level = new byte[]{ 33, 34, 35, 36, 36 },
            },
            new RockSmashArea6
            {
               Location = 328, // Mirage Cave
               Species = new[]{ 075, 075, 525, 075, 075 },
               Level = new byte[]{ 35, 36, 37, 37, 38 },
            },
            new RockSmashArea6
            {
               Location = 330, // Mirage Island
               Species = new[]{ 075, 075, 688, 075, 075 },
               Level = new byte[]{ 35, 36, 37, 37, 38 },
            },
            new RockSmashArea6
            {
               Location = 332, // Mirage Mountain
               Species = new[]{ 075, 075, 558, 075, 075 },
               Level = new byte[]{ 35, 36, 37, 37, 38 },
            },
        };
        public static readonly RockSmashArea6[] RockSmash_XY =
        {
            new RockSmashArea6
            {
               Location = 044, // Ambrette Town
               Species = new[]{ 557, 688, 557, 688, 557 },
               Level = new byte[]{ 18, 18, 19, 20, 20 },
            },
            new RockSmashArea6
            {
               Location = 040, // Cyllage City
               Species = new[]{ 557, 095, 557, 095, 095 },
               Level = new byte[]{ 15, 15, 17, 16, 17 },
            },
            new RockSmashArea6
            {
               Location = 042, // Route 8
               Species = new[]{ 557, 688, 557, 688, 557 },
               Level = new byte[]{ 18, 18, 19, 20, 20 },
            },
            new RockSmashArea6
            {
               Location = 062, // Route 12
               Species = new[]{ 557, 688, 557, 688, 557 },
               Level = new byte[]{ 23, 23, 24, 25, 25 },
            },
            new RockSmashArea6
            {
               Location = 066, // Route 13
               Species = new[]{ 075, 218, 075, 218, 075 },
               Level = new byte[]{ 26, 26, 27, 28, 28 },
            },
            new RockSmashArea6
            {
               Location = 088, // Route 18
               Species = new[]{ 075, 075, 075, 213, 213 },
               Level = new byte[]{ 44, 45, 46, 44, 46 },
            },
            new RockSmashArea6
            {
               Location = 132, // Glittering Cave
               Species = new[]{ 557, 095, 557, 095, 095 },
               Level = new byte[]{ 15, 15, 17, 16, 17 },
            },
            new RockSmashArea6
            {
               Location = 104, // Victory Road
               Species = new[]{ 075, 075, 075, 213, 213 },
               Level = new byte[]{ 57, 58, 59, 57, 59 },
            },
            new RockSmashArea6
            {
               Location = 140, // Terminus Cave
               Species = new[]{ 075, 075, 075, 213, 213 },
               Level = new byte[]{ 44, 45, 46, 44, 46 },
            },
            new RockSmashArea6
            {
               Location = 112, // Azure Bay
               Species = new[]{ 557, 688, 557, 688, 557 },
               Level = new byte[]{ 23, 23, 24, 25, 25 },
            },
        };
        #endregion

        public static readonly EncounterArea_XY[] Shadow_XY =
        {
            new EncounterArea_XY
            {
                Location = 132,
                Species = new[] { 066, 066, 066, 111, 095, 104, 104, 337, 338, 115, 303, 303,},
                Level = new byte[] { 15, 16, 17, 17, 17, 15, 16, 17, 17, 17, 15, 16 },
            },
        };
        public static readonly EncounterArea_XY[] Trap_XY =
        {
            new EncounterArea_XY
            {
                Location = 066, // Route 13
                Species = new[] { 051, 051, 051, 051, 328, 328, 328, 328, 443, 443, 443, 443,},
                Level = new byte[] { 26, 27, 27, 28, 26, 27, 27, 28, 26, 27, 27, 28},
            },
        };
    }
}
