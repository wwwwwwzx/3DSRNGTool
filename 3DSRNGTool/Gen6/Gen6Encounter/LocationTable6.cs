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
                case EncounterType.OldRod:
                case EncounterType.GoodRod:
                case EncounterType.SuperRod:
                    TableNow = IsXY ? Fishing_XY : Fishing_ORAS;
                    break;
                default:
                    TableNow = IsXY ? null : ORASTable;
                    break;
            }
            return TableNow?.Select(t => t.Locationidx).ToArray();
        }

        public static readonly EncounterArea_ORAS[] ORASTable =
        {
            new EncounterArea_ORAS(),
            #region Mirage Spots
            new EncounterArea_ORAS
            {
                Location = 326, idx = 1,
                Species = new[] { 205, 205, 440, 440, },
            },
            new EncounterArea_ORAS
            {
                Location = 326, idx = 2,
                Species = new[] { 531, 531, 531, 191, },
            },
            new EncounterArea_ORAS
            {
                Location = 326, idx = 3,
                Species = new[] { 402, 402, 636, 636, },
            },
            new EncounterArea_ORAS
            {
                Location = 326, idx = 4,
                Species = new[] { 114, 432, 191, 548, },
            },
            new EncounterArea_ORAS
            {
                Location = 326, idx = 5,
                Species = new[] { 114, 432, 191, 037, },
            },
            new EncounterArea_ORAS
            {
                Location = 326, idx = 6,
                Species = new[] { 114, 431, 191, 572, },
            },
            new EncounterArea_ORAS
            {
                Location = 326, idx = 7,
                Species = new[] { 114, 432, 191, 421, },
            },
            new EncounterArea_ORAS
            {
                Location = 326, idx = 8,
                Species = new[] { 191, 191, 548, 531, },
            },
            new EncounterArea_ORAS
            {
                Location = 328, idx = 1,
                Species = new[] { 201, 201, 201, 201, },
            },
            new EncounterArea_ORAS
            {
                Location = 328, idx = 2,
                Species = new[] { 602, 530, 132, 132, },
            },
            new EncounterArea_ORAS
            {
                Location = 328, idx = 3,
                Species = new[] { 602, 602, 079, 079, },
            },
            new EncounterArea_ORAS
            {
                Location = 328, idx = 4,
                Species = new[] { 599, 599, 602, 602, },
            },
            new EncounterArea_ORAS
            {
                Location = 328, idx = 5,
                Species = new[] { 599, 602, 530, 095, },
            },
            new EncounterArea_ORAS
            {
                Location = 328, idx = 6,
                Species = new[] { 602, 602, 563, 079, },
            },
            new EncounterArea_ORAS
            {
                Location = 328, idx = 7,
                Species = new[] { 599, 599, 563, 563, },
            },
            new EncounterArea_ORAS
            {
                Location = 328, idx = 8,
                Species = new[] { 602, 602, 095, 095, },
            },
            new EncounterArea_ORAS
            {
                Location = 330, idx = 1,
                Species = new[] { 517, 517, 132, 132, },
            },
            new EncounterArea_ORAS
            {
                Location = 330, idx = 2,
                Species = new[] { 049, 523, 178, 114, },
            },
            new EncounterArea_ORAS
            {
                Location = 330, idx = 3,
                Species = new[] { 049, 523, 178, 053, },
            },
            new EncounterArea_ORAS
            {
                Location = 330, idx = 4,
                Species = new[] { 049, 523, 178, 555, },
            },
            new EncounterArea_ORAS
            {
                Location = 330, idx = 5,
                Species = new[] { 049, 523, 178, 556, },
            },
            new EncounterArea_ORAS
            {
                Location = 330, idx = 6,
                Species = new[] { 531, 531, 531, 178, },
            },
            new EncounterArea_ORAS
            {
                Location = 330, idx = 7,
                Species = new[] { 432, 432, 137, 137, },
            },
            new EncounterArea_ORAS
            {
                Location = 330, idx = 8,
                Species = new[] { 555, 555, 636, 636, },
            },
            new EncounterArea_ORAS
            {
                Location = 332, idx = 1,
                Species = new[] { 178, 178, 517, 137, },
            },
            new EncounterArea_ORAS
            {
                Location = 332, idx = 2,
                Species = new[] { 205, 232, 401, 627, },
            },
            new EncounterArea_ORAS
            {
                Location = 332, idx = 3,
                Species = new[] { 205, 232, 401, 629, },
            },
            new EncounterArea_ORAS
            {
                Location = 332, idx = 4,
                Species = new[] { 205, 232, 401, 203, },
            },
            new EncounterArea_ORAS
            {
                Location = 332, idx = 5,
                Species = new[] { 205, 232, 401, 234, },
            },
            new EncounterArea_ORAS
            {
                Location = 332, idx = 6,
                Species = new[] { 531, 531, 440, 114, },
            },
            new EncounterArea_ORAS
            {
                Location = 332, idx = 7,
                Species = new[] { 523, 523, 239, 239, },
            },
            new EncounterArea_ORAS
            {
                Location = 332, idx = 8,
                Species = new[] { 555, 555, 240, 240, },
            },
            #endregion
        };

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

        #region Fishing
        public static readonly FishingArea6[] Fishing_XY =
        {
            new FishingArea6
            {
                Location = 090, // Couriway Town
                Species = new[] { 60, 60, 60, 550, 61, 550, 61, 550, 61, },
                Level = new byte[] { 25, 25, 25, 35, 35, 35, 45, 45, 45, },
            },
            new FishingArea6
            {
                Location = 044, // Ambrette Town
                Species = new[] { 370, 370, 370, 692, 116, 692, 369, 693, 117, },
                Level = new byte[] { 15, 15, 15, 25, 25, 25, 35, 35, 35, },
            },
            new FishingArea6
            {
                Location = 040, // Cyllage City
                Species = new[] { 370, 370, 370, 692, 116, 692, 369, 693, 117, },
                Level = new byte[] { 15, 15, 15, 25, 25, 25, 35, 35, 35, },
            },
            new FishingArea6
            {
                Location = 058, // Shalour City
                Species = new[] { 370, 370, 370, 223, 170, 223, 594, 224, 171, },
                Level = new byte[] { 15, 15, 15, 25, 25, 25, 35, 35, 35, },
            },
            new FishingArea6
            {
                Location = 070, // Laverre City
                Species = new[] { 60, 60, 60, 550, 61, 550, 61, 550, 61, },
                Level = new byte[] { 15, 15, 15, 25, 25, 25, 35, 35, 35, },
            },
            new FishingArea6
            {
                Location = 016, // Route 3
                Species = new[] { 129, 129, 129, 118, 341, 118, 130, 119, 342, },
                Level = new byte[] { 15, 15, 15, 25, 25, 25, 35, 35, 35, },
            },
            new FishingArea6
            {
                Location = 042, // Route 8
                Species = new[] { 370, 370, 370, 692, 120, 692, 211, 693, 121, },
                Level = new byte[] { 15, 15, 15, 25, 25, 25, 35, 35, 35, },
            },
            new FishingArea6
            {
                Location = 062, // Route 12
                Species = new[] { 370, 370, 370, 223, 366, 223, 222, 224, 367, },
                Level = new byte[] { 15, 15, 15, 25, 25, 25, 35, 35, 35, },
            },
            new FishingArea6
            {
                Location = 068, // Route 14
                Species = new[] { 60, 60, 60, 339, 61, 339, 61, 340, 61, },
                Level = new byte[] { 15, 15, 15, 25, 35, 35, 35, 35, 35, },
            },
            new FishingArea6
            {
                Location = 074, // Route 15
                Species = new[] { 60, 60, 60, 550, 61, 550, 61, 550, 61, },
                Level = new byte[] { 15, 15, 15, 25, 25, 25, 35, 35, 35, },
            },
            new FishingArea6
            {
                Location = 078, // Route 16
                Species = new[] { 60, 60, 60, 550, 61, 550, 61, 550, 61, },
                Level = new byte[] { 15, 15, 15, 25, 25, 25, 35, 35, 35, },
            },
            new FishingArea6
            {
                Location = 092, // Route 19
                Species = new[] { 60, 60, 60, 339, 61, 339, 61, 340, 186, },
                Level = new byte[] { 25, 25, 25, 35, 35, 35, 45, 45, 50, },
            },
            new FishingArea6
            {
                Location = 100, // Route 21
                Species = new[] { 60, 60, 60, 550, 61, 147, 61, 550, 148, },
                Level = new byte[] { 30, 30, 30, 40, 40, 40, 50, 50, 50, },
            },
            new FishingArea6
            {
                Location = 102, // Route 22
                Species = new[] { 129, 129, 129, 118, 318, 118, 130, 119, 319, },
                Level = new byte[] { 15, 15, 15, 25, 25, 25, 35, 35, 35, },
            },
            new FishingArea6
            {
                Location = 036, // Parfum Palace
                Species = new[] { 129, 129, 129, 118, 341, 118, 130, 119, 342, },
                Level = new byte[] { 15, 15, 15, 25, 25, 25, 35, 35, 35, },
            },
            new FishingArea6
            {
                Location = 082, // Frost Cavern
                Species = new[] { 60, 60, 60, 550, 61, 550, 61, 550, 61, },
                Level = new byte[] { 20, 20, 20, 30, 30, 30, 40, 40, 40, },
            },
            new FishingArea6
            {
                Location = 098, // Pokémon Village
                Species = new[] { 60, 60, 60, 550, 61, 550, 61, 550, 61, },
                Level = new byte[] { 30, 30, 30, 40, 40, 40, 50, 50, 50, },
            },
            new FishingArea6
            {
                Location = 104, idx = 1, // Victory Road
                Species = new[] { 60, 60, 60, 550, 61, 550, 61, 550, 61, },
                Level = new byte[] { 35, 35, 35, 45, 45, 45, 55, 55, 55, },
            },
            new FishingArea6
            {
                Location = 104, idx = 2,
                Species = new[] { 60, 60, 60, 550, 61, 550, 61, 550, 62, },
                Level = new byte[] { 35, 35, 35, 45, 45, 45, 55, 55, 60, },
            },
            new FishingArea6
            {
                Location = 112, // Azure Bay
                Species = new[] { 370, 370, 370, 223, 170, 223, 594, 224, 171, },
                Level = new byte[] { 15, 15, 15, 25, 25, 25, 35, 35, 35, },
            },
        };
        public static readonly FishingArea6[] Fishing_ORAS =
        {
            new FishingArea6
            {
                Location = 174, // Dewford Town
                Species = new[] { 129, 72, 129, 129, 72, 320, 320, 320, 320, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 182, // Pacifidlog Town
                Species = new[] { 129, 72, 129, 129, 72, 320, 320, 320, 320, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 184,// Petalburg City
                Species = new[] { 129, 118, 129, 129, 118, 341, 341, 341, 341, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 186, // Slateport City
                Species = new[] { 129, 72, 129, 129, 72, 320, 320, 320, 320, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 194, // Lilycove City
                Species = new[] { 129, 72, 129, 129, 72, 320, 320, 320, 120, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 196, // Mossdeep City
                Species = new[] { 129, 72, 129, 129, 72, 320, 320, 320, 320, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 25, 30, 40, },
            },
            new FishingArea6
            {
                Location = 198, // Sootopolis City
                Species = new[] { 129, 129, 129, 129, 129, 129, 129, 129, 130, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 200, // Ever Grande City
                Species = new[] { 129, 72, 129, 129, 370, 320, 370, 320, 222, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 206, // Route 102
                Species = new[] { 129, 118, 129, 129, 118, 341, 341, 341, 341, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 208, // Route 103
                Species = new[] { 129, 72, 129, 129, 72, 320, 320, 320, 320, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 210, // Route 104
                Species = new[] { 129, 129, 129, 129, 129, 129, 129, 129, 129, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 212, // Route 105
                Species = new[] { 129, 72, 129, 129, 72, 320, 320, 320, 320, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 214, // Route 106
                Species = new[] { 129, 72, 129, 129, 72, 320, 320, 320, 320, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 216, // Route 107
                Species = new[] { 129, 72, 129, 129, 72, 320, 320, 320, 320, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 218, // Route 108
                Species = new[] { 129, 72, 129, 129, 72, 320, 320, 320, 320, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 220, // Route 109
                Species = new[] { 129, 72, 129, 129, 72, 320, 320, 320, 320, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 222, // Route 110
                Species = new[] { 129, 72, 129, 129, 72, 320, 320, 320, 320, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 224, // Route 111
                Species = new[] { 129, 118, 129, 129, 118, 339, 339, 339, 339, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 230, // Route 114
                Species = new[] { 129, 118, 129, 129, 118, 339, 339, 339, 339, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 232, // Route 115
                Species = new[] { 129, 72, 129, 129, 72, 320, 320, 320, 320, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 236, // Route 117
                Species = new[] { 129, 118, 129, 129, 118, 341, 341, 341, 342, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 238, // Route 118
                Species = new[] { 129, 72, 129, 129, 72, 318, 318, 318, 319, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 240, // Route 119
                Species = new[] { 129, 72, 349, 129, 318, 349, 318, 319, 349, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 40, 35, },
            },
            new FishingArea6
            {
                Location = 242, // Route 120
                Species = new[] { 129, 72, 129, 129, 72, 339, 339, 339, 339, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 246, // Route 122
                Species = new[] { 129, 72, 129, 129, 72, 320, 320, 320, 320, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 248, // Route 123
                Species = new[] { 129, 118, 129, 129, 118, 341, 341, 341, 342, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 250, // Route 124
                Species = new[] { 129, 72, 129, 129, 72, 320, 320, 320, 320, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 252, // Route 125
                Species = new[] { 129, 72, 129, 129, 72, 320, 320, 320, 320, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 254, // Route 126
                Species = new[] { 129, 72, 129, 129, 72, 320, 320, 320, 320, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 256, // Route 127
                Species = new[] { 129, 72, 129, 129, 72, 320, 320, 320, 320, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 258, // Route 128
                Species = new[] { 129, 72, 129, 129, 370, 320, 370, 320, 222, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 260, // Route 129
                Species = new[] { 129, 72, 129, 129, 72, 320, 320, 320, 320, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 262, // Route 130
                Species = new[] { 129, 72, 129, 129, 72, 320, 320, 116, 117, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 264, // Route 131
                Species = new[] { 129, 72, 129, 129, 72, 320, 320, 116, 117, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 266, // Route 132
                Species = new[] { 129, 72, 129, 129, 72, 320, 320, 116, 117, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 268, // Route 133
                Species = new[] { 129, 72, 129, 129, 72, 320, 320, 116, 117, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 270, // Route 134
                Species = new[] { 129, 72, 129, 129, 72, 320, 320, 116, 117, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 272, idx = 1, // Meteor Falls
                Species = new[] { 129, 118, 129, 129, 118, 339, 339, 339, 339, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 272, idx = 2, // Meteor Falls
                Species = new[] { 129, 118, 129, 129, 118, 339, 339, 339, 340, },
                Level = new byte[] { 10, 10, 5, 30, 30, 30, 30, 35, 40, },
            },
            new FishingArea6
            {
                Location = 292, // Team Aqua Hideout
                Species = new[] { 129, 72, 129, 129, 72, 320, 320, 320, 120, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 294, idx = 1, // Seafloor Cavern
                Species = new[] { 129, 72, 129, 129, 72, 320, 320, 320, 320, },
                Level = new byte[] { 10, 10, 5, 30, 30, 30, 30, 35, 40, },
            },
            new FishingArea6
            {
                Location = 294, idx = 2, // Seafloor Cavern
                Species = new[] { 129, 72, 129, 129, 72, 320, 320, 320, 320, },
                Level = new byte[] { 10, 5, 10, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 298, idx = 1, // Victory Road
                Species = new[] { 129, 72, 129, 129, 370, 320, 370, 320, 320, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 298, idx = 2, // Victory Road
                Species = new[] { 129, 118, 129, 129, 118, 339, 339, 339, 339, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 300, // Shoal Cave
                Species = new[] { 129, 72, 129, 129, 72, 320, 320, 320, 320, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 304, // Sea Mauville
                Species = new[] { 129, 72, 129, 129, 72, 320, 320, 320, 320, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 310, // Sealed Chamber
                Species = new[] { 129, 72, 129, 129, 72, 320, 320, 116, 116, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 312, // Scorched Slab
                Species = new[] { 129, 118, 129, 129, 118, 339, 339, 339, 339, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 314, // Team Magma Hideout
                Species = new[] { 129, 72, 129, 129, 72, 320, 320, 320, 120, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 318, // Battle Resort
                Species = new[] { 129, 72, 129, 129, 72, 223, 223, 223, 224, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
            new FishingArea6
            {
                Location = 324, // Safari Zone
                Species = new[] { 129, 118, 129, 129, 118, 129, 119, 119, 119, },
                Level = new byte[] { 10, 5, 15, 25, 25, 25, 35, 30, 40, },
            },
        };
        #endregion
    }
}
