using System.Linq;
using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public static class LocationTable7
    {
        public static EncounterArea[] TableNow;

        public static int[] getLocation(int category, bool IsUltra)
        {
            TableNow = IsUltra ? USUMTable : SMTable;
            switch (category)
            {
                case 1:
                case 2:
                    return (IsUltra ? PKMW7.Species_USUM : PKMW7.Species_SM)[category].List
                           .Skip(1).SelectMany(pk => (pk as PKMW7).Location).ToArray();
                case 3:
                    TableNow = IsUltra ? Fishing_USUM : Fishing_SM;
                    goto default;
                case 4:
                    TableNow = IsUltra ? Misc_USUM : Misc_SM;
                    goto default;
                case 5:
                    TableNow = CrabrawlerSpots.Select(loc => new EncounterArea_Crabrawler((short)loc, IsUltra)).ToArray();
                    return CrabrawlerSpots;
                default: return TableNow.Select(t => t.Locationidx).ToArray();
            }
        }

        public readonly static EncounterArea7[] SMTable =
        {
            #region MeleMele
            new EncounterArea_SM
            {
                Location = 008, idx = 1,
                Correction = 15,
                LevelMin = 02, LevelMax = 03,
                Species = new[] {0,734,731,010,165},
            },
            new EncounterArea_SM
            {
                Location = 008, idx = 2,
                Correction = 15,
                LevelMin = 03, LevelMax = 05,
                Species = new[] {1,734,731,736,010,011,165,172},
            },
            new EncounterArea_SM
            {
                Location = 008, idx = 3,
                Correction = 15, NPC = 1,
                LevelMin = 10,
                Species = new[] {2,734,731,438,010,011,165,446},
            },
            new EncounterArea_SM
            {
                Location = 006, // Outskirts
                Correction = 23, NPC = 1,
                LevelMin = 05, LevelMax = 07,
                Species = new[] {0,734,278,278,079},
            },
            new EncounterArea_SM
            {
                Location = 231, //Trainer School
                Correction = 09,
                LevelMin = 06, LevelMax = 08,
                Species = new[] {0,052,081,088,081},
            },
            new EncounterArea_SM
            {
                Location = 016, idx = 1, mark = "E",
                Correction = 09, NPC = 1,
                LevelMin = 15,
                Species = new[] {15,072,278,456},
            },
            new EncounterArea_SM
            {
                Location = 016, idx = 2, mark = "W",
                Correction = 05, NPC = 1,
                LevelMin = 15,
                Species = new[] {15,072,278,456},
            },
            new EncounterArea_SM
            {
                Location = 012, idx = 1,
                Correction = 19, NPC = 0,
                LevelMin = 07,
                Species = new[] {16,096,052,734,235,063},
            },
            new EncounterArea_SM
            {
                Location = 012, idx = 2,
                Correction = 19, NPC = 1,
                LevelMin = 07,
                Species = new[] {17,742,058,734,021,235},
            },
            new EncounterArea_SM
            {
                Location = 046, // Verdant Cavern
                Correction = 05,
                LevelMin = 08,
                Species = new[] {0,041,050,041,041},
            },
            new EncounterArea_SM
            {
                Location = 010, idx = 1,
                Correction = 11, NPC = 0,
                LevelMin = 09,
                Species = new[] {18,742,021,734,225,056},
            },
            new EncounterArea_SM
            {
                Location = 010, idx = 2,
                Correction = 11, NPC = 0,
                LevelMin = 09,
                Species = new[] {19,742,021,734,056,371},
            },
            new EncounterArea_SM
            {
                Location = 018,
                Correction = 17, NPC = 1,
                LevelMin = 15,
                Species = new[] {15,072,278,456},
            },
            new EncounterArea_SM
            {
                Location = 020,
                Correction = 27,
                LevelMin = 05,
                Species = new[] {20,734,278,063,088,081,052,172},
            },
            new EncounterArea_SM
            {
                Location = 038,
                Correction = 06, NPC = 3,
                LevelMin = 07,
                Species = new[] {0,092,425,092,041},
            },
            new EncounterArea_SM
            {
                Location = 040, // Melemele Meadow
                Correction = 05,
                LevelMin = 09,
                Species = new[] {5,742,546,741,010,011,012},
            },
            new EncounterArea_SM
            {
                Location = 042, idx = 1, mark = "Cave",
                LevelMin = 09,
                Species = new[] {0,041,050,041,041},
            },
            new EncounterArea_SM
            {
                Location = 042, idx = 2, mark = "Water",
                Correction = 02, NPC = 1,
                LevelMin = 15,
                Species = new[] {14,041,054,041,041,041},
            },
            new EncounterArea_SM
            {
                Location = 014, idx = 1, mark = "Grass",
                LevelMin = 15,
                Species = new[] {22,734,278,278,371,079},
            },
            new EncounterArea_SM
            {
                Location = 014, idx = 2, mark = "Water",
                Correction = 02, NPC = 1,
                LevelMin = 15,
                Species = new[] {15,072,278,456},
            },
            new EncounterArea_SM
            {
                Location = 034, idx = 1, mark = "Cave", //Ten Carat Hill - Cave
                Correction = 02,
                LevelMin = 10,
                Species = new[] {14,041,052,524,524,703},
            },
            new EncounterArea_SM
            {
                Location = 034, idx = 2, mark = "Grass", //Ten Carat Hill - Grass
                LevelMin = 10,
                Species = new[] {14,066,744,327,524,703},
            },
            new EncounterArea_SM
            {
                Location = 034, idx = 3, mark = "Water", //Ten Carat Hill - Water
                Correction = 03, NPC = 1,
                LevelMin = 15,
                Species = new[] {14,041,054,041,041,041},
            },
            #endregion
            #region  Akala
            new EncounterArea_SM(),
            new EncounterArea_SM
            {
                Location = 050, //4
                Correction = 06, NPC = 1,
                LevelMin = 11,
                Species = new[] {23,506,749,736,734,731,174,133},
            },
            new EncounterArea_SM
            {
                Location = 078,
                Correction = 23, NPC = 2,
                LevelMin = 12,
                Species = new[] {24,506,749,128,241},
            },
            new EncounterArea_SM
            {
                Location = 052, idx = 1, //5
                Correction = 20,
                LevelMin = 13,
                Species = new[] {3,506,731,753,736,010,011,012},
            },
            new EncounterArea_SM
            {
                Location = 052, idx = 2, //5
                Correction = 20, NPC = 1,
                LevelMin = 18,
                Species = new[] {4,753,732,438,736,010,011,012},
            },
            new EncounterArea_SM
            {
                Location = 090, idx = 1, mark = "S",//Lush Jungle - S
                Correction = 07,
                LevelMin = 18,
                Species = new[] {9,753,732,438,010,011,046,766,764},
            },
            new EncounterArea_SM
            {
                Location = 090, idx = 2, mark = "W",//Lush Jungle - W
                Correction = 02,
                LevelMin = 18,
                Species = new[] {10,753,732,761,046,766,764},
            },
            new EncounterArea_SM
            {
                Location = 090, idx = 3, mark = "N",//Lush Jungle - N
                Correction = 02,
                LevelMin = 18,
                Species = new[] {11,753,732,046,127,764,766},
            },
            new EncounterArea_SM
            {
                Location = 090, idx = 4, mark = "Cave", //Lush Jungle - Cave
                Correction = 02,
                LevelMin = 18,
                Species = new[] {0,041,050,041,041},
            },
            new EncounterArea_SM
            {
                Location = 086, idx = 1, mark = "Grass1", //Brooklet Hill
                Correction = 07, NPC = 1,
                LevelMin = 14,
                Species = new[] {6,506,054,751,060,278,046},
            },
            new EncounterArea_SM
            {
                Location = 086, idx = 2, mark = "Water1",//Brooklet Hill
                Correction = 08, NPC = 1,
                LevelMin = 14,
                Species = new[] {22,060,751,060,751,054},
            },
            new EncounterArea_SM
            {
                Location = 086, idx = 3, mark = "Grass2",//Brooklet Hill
                Correction = 05, NPC = 1,
                LevelMin = 14,
                Species = new[] {25,751,060,054,278},
            },
            new EncounterArea_SM
            {
                Location = 086, idx = 4, mark = "Water2",//Brooklet Hill
                Correction = 06, NPC = 1,
                LevelMin = 14,
                Species = new[] {22,060,751,060,751,054},
            },
            new EncounterArea_SM
            {
                Location = 088, // Brooklet Hill (Totems' Den)
                Correction = 03, NPC = 1,
                LevelMin = 14,
                Species = new[] {15,072,278,456},
            },
            new EncounterArea_SM
            {
                Location = 054, idx = 1, //6
                Correction = 11, NPC = 2,
                LevelMin = 14,
                Species = new[] {23,506,749,736,734,731,174,133},
            },
            new EncounterArea_SM
            {
                Location = 054, idx = 2, //6
                Correction = 11, NPC = 2,
                LevelMin = 14,
                Species = new[] {23,506,741,736,734,731,174,133},
            },
            new EncounterArea_SM
            {
                Location = 056, //7
                Correction = 9, NPC = 1,
                LevelMin = 16,
                Species = new[] {26,072,456,278,771},
            },
            new EncounterArea_SM
            {
                Location = 058, idx = 1, mark = "Grass",//8
                Correction = 15,
                LevelMin = 17,
                Species = new[] {27,734,732,757,662,759},
            },
            new EncounterArea_SM
            {
                Location = 058, idx = 2, mark = "Water",//8
                Correction = 16, NPC = 1,
                LevelMin = 17,
                Species = new[] {15,072,278,456},
            },
            new EncounterArea_SM
            {
                Location = 064,
                Correction = 20, NPC = 1,
                LevelMin = 21,
                Species = new[] {26,072,456,278,771},
            },
            new EncounterArea_SM
            {
                Location = 082, //Wela Volcano
                Correction = 09,
                LevelMin = 16,
                Species = new[] {8,757,661,104,240,115},
            },
            new EncounterArea_SM
            {
                Location = 100, //Diglett's Tunnel
                Correction = 12,
                LevelMin = 19,
                Species = new[] {0,041,050,041,041},
            },
            new EncounterArea_SM
            {
                Location = 076, //Memorial Hill
                Correction = 12, NPC = 1,
                LevelMin = 20,
                Species = new[] {0,092,708,092,041},
            },
            new EncounterArea_SM
            {
                Location = 094,
                Correction = 07, NPC = 2,
                LevelMin = 20,
                Species = new[] {27,735,278,278,299,759},
            },
            #endregion
            #region Ula'ula
            new EncounterArea_SM(),
            new EncounterArea_SM
            {
                Location = 132, //Malie City
                Correction = 09, NPC = 0,
                LevelMin = 24,
                Species = new[] {13,568,088,735,081},
            },
            new EncounterArea_SM
            {
                Location = 134, //Malie Garden
                Correction = 26,
                LevelMin = 24,
                Species = new[] {12,060,052,546,054,752,166},
            },
            new EncounterArea_SM
            {
                Location = 106, //10
                Correction = 19, NPC = 1,
                LevelMin = 24,
                Species = new[] {22,735,022,674,227,166},
            },
            new EncounterArea_SM
            {
                Location = 136, // Ditto
                Correction = 16,
                LevelMin = 25,
                Species = new[] {21,022,774,374,227,173,132},
                Reverse = true, // Cleffa at night
            },
            new EncounterArea_SM
            {
                Location = 108, //11
                Correction = 10,
                LevelMin = 24,
                Species = new[] {12,735,732,046,775,674,166},
            },
            new EncounterArea_SM
            {
                Location = 122, idx = 1,//12
                Correction = 11,
                LevelMin = 26,
                Species = new[] {21,074,749,324,324,074,239},
            },
            new EncounterArea_SM
            {
                Location = 122, idx = 2,//12
                Correction = 11, NPC = 1,
                LevelMin = 25,
                Species = new[] {21,074,749,324,324,074,239},
            },
            new EncounterArea_SM
            {
                Location = 110,
                Correction = 12, NPC = 1,
                LevelMin = 27,
                Species = new[] {15,072,279,456},
            },
            new EncounterArea_SM
            {
                Location = 138, idx = 1,
                Correction = 3, NPC = 1,
                LevelMin = 27, lvldiff = -1,
                Species = new[] {7,074,749,737,324,776,777,239},
            },
            new EncounterArea_SM
            {
                Location = 138, idx = 2,
                Correction = 3, NPC = 1,
                LevelMin = 27, lvldiff = -1,
                Species = new[] {7,074,749,737,324,776,777,239},
            },
            new EncounterArea_SM
            {
                Location = 124, //Haina Desert
                LevelMin = 28,
                Species = new[] {0,551,051,551,551},
            },
            new EncounterArea_SM
            {
                Location = 114, //Tapu Village
                Correction = 11,
                LevelMin = 28,
                Species = new[] {22,735,279,359,037,361},
            },
            new EncounterArea_SM
            {
                Location = 126, //14
                Correction = 12, NPC = 1,
                LevelMin = 28,
                Species = new[] {15,072,279,456},
            },
            new EncounterArea_SM
            {
                Location = 150, //Megamart
                LevelMin = 29,
                Species = new[] {28,093,042,707,778},
            },
            new EncounterArea_SM
            {
                Location = 116, idx = 1, mark = "Grass", //15
                Correction = 20, NPC = 1,
                LevelMin = 30,
                Species = new[] {22,735,279,279,279,079},
            },
            new EncounterArea_SM
            {
                Location = 116, idx = 2, mark = "Water", //15
                Correction = 21, NPC = 1,
                LevelMin = 30,
                Species = new[] {15,072,279,456},
            },
            new EncounterArea_SM
            {
                Location = 118, //16
                Correction = 10,
                LevelMin = 30,
                Species = new[] {22,735,279,279,279,079},
            },
            new EncounterArea_SM
            {
                Location = 128, //Meadow
                Correction = 08,
                LevelMin = 31,
                Species = new[] {22,743,546,741,741,166},
            },
            new EncounterArea_SM
            {
                Location = 120, idx = 1, //17
                Correction = 10, Raining = true,
                LevelMin = 31,
                Species = new[] {22,735,022,674,674,166},
            },
            new EncounterArea_SM
            {
                Location = 120, idx = 2, //17
                Correction = 10, Raining = true,
                LevelMin = 31,
                Species = new[] {21,735,022,674,075,075,227},
            },
            new EncounterArea_SM
            {
                Location = 146, idx = 1,
                LevelMin = 42,
                Species = new[] {22,037,361,359,359,215},
            },
            new EncounterArea_SM
            {
                Location = 146, idx = 2,
                LevelMin = 42,
                Species = new[] {22,042,361,359,780,215},
                Reverse = true,
            },
            new EncounterArea_SM
            {
                Location = 146, idx = 3,
                LevelMin = 45, lvldiff = -3,
                Species = new[] {22,037,361,359,359,215},
            },
            #endregion
            #region Poni
            new EncounterArea_SM(),
            new EncounterArea_SM
            {
                Location = 184, // Exeggutor Island
                Correction = 03,
                LevelMin = 40,
                Species = new[] {29,103,279,102,423},
            },
            new EncounterArea_SM
            {
                Location = 158, idx = 1, mark = "Grass", // Poni Wilds
                Correction = 09,
                LevelMin = 40,
                Species = new[] {5,735,279,210,423,102,102},
            },
            new EncounterArea_SM
            {
                Location = 158, idx = 2, mark = "Water", // Poni Wilds
                Correction = 10, NPC = 1,
                LevelMin = 40,
                Species = new[] {30,073,423,279,457,131},
            },
            new EncounterArea_SM
            {
                Location = 160,
                Correction = 20, NPC = 3,
                LevelMin = 40,
                Species = new[] {5,735,279,210,423,102,102},
            },
            new EncounterArea_SM
            {
                Location = 174, idx = 1, mark = "Inside",
                Correction = 6, NPC = 1,
                LevelMin = 41,
                Species = new[] {14,042,051,525,525,703},
            },
            new EncounterArea_SM
            {
                Location = 174, idx = 2, mark = "Top",
                LevelMin = 41,
                Species = new[] {1,067,745,227,525,198,703,782},
            },
            new EncounterArea_SM
            {
                Location = 174, idx = 3, mark = "2F",
                Correction = 4,
                LevelMin = 41,
                Species = new[] {14,042,051,525,525,703},
            },
            new EncounterArea_SM
            {
                Location = 174, idx = 4, mark = "3F",
                Correction = 6,
                LevelMin = 41,
                Species = new[] {14,042,051,525,525,703},
            },
            new EncounterArea_SM
            {
                Location = 174, idx = 5, mark = "Under Tree",
                Correction = 15,
                LevelMin = 41,
                Species = new[] {1,067,745,227,525,198,703,782},
            },
            new EncounterArea_SM
            {
                Location = 174, idx = 6, mark = "B1F-C",
                Correction = 8,
                LevelMin = 41,
                Species = new[] {14,042,051,525,525,703},
            },
            new EncounterArea_SM
            {
                Location = 174, idx = 7, mark = "B1F-W",
                Correction = 9, NPC = 1,
                LevelMin = 41,
                Species = new[] {14,042,055,042,042,042},
            },
            new EncounterArea_SM
            {
                Location = 164, // Poni Grove
                Correction = 4,
                LevelMin = 52,
                Species = new[] {5,735,732,210,127,447,447},
            },
            new EncounterArea_SM
            {
                Location = 166, idx = 1, // Poni Plains
                Correction = 5, NPC = 1,
                LevelMin = 54,
                Species = new[] {7,735,279,732,546,128,241,546},
            },
            new EncounterArea_SM
            {
                Location = 166, idx = 2, // Poni Plains
                Correction = 5, NPC = 0,
                LevelMin = 54,
                Species = new[] {21,735,732,546,128,241,546},
            },
            new EncounterArea_SM
            {
                Location = 166, idx = 3, // Poni Plains
                Correction = 5, NPC = 0,
                LevelMin = 54,
                Species = new[] {7,735,097,732,546,128,241,546},
            },
            new EncounterArea_SM
            {
                Location = 166, idx = 4, // Poni Plains
                Correction = 5, NPC = 0,
                LevelMin = 54,
                Species = new[] {31,735,732,750,022,546,128,241},
            },
            new EncounterArea_SM
            {
                Location = 156, // Meadow
                Correction = 5,
                LevelMin = 54,
                Species = new[] {0,743,546,741,546},
            },
            new EncounterArea_SM
            {
                Location = 182, idx = 1, mark = "1F", //Resolution Cave
                Correction = 3,
                LevelMin = 54,
                Species = new[] {0,042,051,042,042},
            },
            new EncounterArea_SM
            {
                Location = 182, idx = 2, mark = "B1F", //Resolution Cave
                LevelMin = 54,
                Species = new[] {0,042,051,042,042},
            },
            new EncounterArea_SM
            {
                Location = 170, // Poni Gauntlet
                Correction = 11, NPC = 3,
                LevelMin = 56,
                Species = new[] {27,735,279,210,055,760},
            },
            #endregion
        };

        public readonly static EncounterArea7[] USUMTable =
        {
            #region MeleMele
            new EncounterArea_USUM
            {
                Location = 008, idx = 1,
                Correction = 13,
                LevelMin = 02, LevelMax = 03,
                Species = new[] {33,734,731,427,165,736,010,172},
            },
            new EncounterArea_USUM
            {
                Location = 008, idx = 2,
                Correction = 13, NPC = 0,
                LevelMin = 02, LevelMax = 03,
                Species = new[] {11,734,010,427,010,734,010},
            },
            new EncounterArea_USUM
            {
                Location = 008, idx = 3,
                Correction = 13, NPC = 1,
                LevelMin = 11,
                Species = new[] {09,734,731,438,438,438,744,446,446},
            },
            new EncounterArea_USUM
            {
                Location = 006, // Outskirts
                Correction = 18,
                LevelMin = 04,
                Species = new[] {0,686,278,278,079},
            },
            new EncounterArea_USUM
            {
                Location = 231, //Trainer School
                Correction = 15,
                LevelMin = 05,
                Species = new[] {1,052,570,570,088,081,052,052},
            },
            new EncounterArea_USUM
            {
                Location = 016, idx = 1, mark = "E",
                Correction = 9, NPC = 1,
                LevelMin = 15,
                Species = new[] {34,072,278,456,458},
            },
            new EncounterArea_USUM
            {
                Location = 016, idx = 2, mark = "W",
                Correction = 4, NPC = 1,
                LevelMin = 15,
                Species = new[] {34,072,278,456,458},
            },
            new EncounterArea_USUM
            {
                Location = 012, idx = 1,
                Correction = 30, NPC = 1,
                LevelMin = 07,
                Species = new[] {35,296,023,676,052,235,734,063,096},
            },
            new EncounterArea_USUM
            {
                Location = 012, idx = 2,
                Correction = 30,
                LevelMin = 07,
                Species = new[] {35,296,023,058,742,235,734,021,096},
            },
            new EncounterArea_USUM
            {
                Location = 012, idx = 3,
                Correction = 30, NPC = 1,
                LevelMin = 07,
                Species = new[] {35,021,742,058,742,235,734,021,734},
            },
            new EncounterArea_USUM
            {
                Location = 200,
                Correction = 2,
                LevelMin = 06,
                Species = new[] {0,054,041,041,041},
            },
            new EncounterArea_USUM
            {
                Location = 046, // Verdant Cavern
                Correction = 09,
                LevelMin = 08,
                Species = new[] {36,041,050,714},
            },
            new EncounterArea_USUM
            {
                Location = 010, idx = 1,
                Correction = 15,
                LevelMin = 09,
                Species = new[] {35,742,021,056,701,056,056,742,021},
            },
            new EncounterArea_USUM
            {
                Location = 010, idx = 2,
                Correction = 15, NPC = 1,
                LevelMin = 09,
                Species = new[] {37,742,021,056,701,056,742,021,371},
            },
            new EncounterArea_USUM
            {
                Location = 018,
                Correction = 18, NPC = 1,
                LevelMin = 15,
                Species = new[] {34,072,278,456,458},
            },
            new EncounterArea_USUM
            {
                Location = 021, idx = 1,
                Correction = 30,
                LevelMin = 06,
                Species = new[] {44,278,278,063,439,676,081,052,088,676,676},
            },
            new EncounterArea_USUM
            {
                Location = 021, idx = 2,
                Correction = 30,
                LevelMin = 06,
                Species = new[] {38,676,063,439,088,081,052,278},
            },
            new EncounterArea_USUM
            {
                Location = 038,
                Correction = 11, NPC = 3,
                LevelMin = 06,
                Species = new[] {28,092,425,041,041},
            },
            new EncounterArea_USUM
            {
                Location = 040, // Melemele Meadow
                Correction = 06,
                LevelMin = 09,
                Species = new[] {39,742,546,669,741,010,011,012},
            },
            new EncounterArea_USUM
            {
                Location = 042, idx = 1, mark = "Cave",
                Correction = 06,
                LevelMin = 09,
                Species = new[] {11,054,225,238,041,041,041},
            },
            new EncounterArea_USUM
            {
                Location = 042, idx = 2, mark = "Water",
                Correction = 07, NPC = 1,
                LevelMin = 15,
                Species = new[] {40,041,086,225,041,054},
            },
            new EncounterArea_USUM
            {
                Location = 014, idx = 1, mark = "Grass",
                Correction = 02,
                LevelMin = 15,
                Species = new[] {22,734,278,278,371,079},
            },
            new EncounterArea_USUM
            {
                Location = 014, idx = 2, mark = "Water",
                Correction = 03, NPC = 1,
                LevelMin = 15,
                Species = new[] {34,072,278,456,458},
            },
            new EncounterArea_USUM
            {
                Location = 034, idx = 1, mark = "Cave", //Ten Carat Hill - Cave
                LevelMin = 11,
                Species = new[] {35,703,303,054,524,524,303,041,041},
            },
            new EncounterArea_USUM
            {
                Location = 034, idx = 2, mark = "Grass", //Ten Carat Hill - Grass
                Correction = 02,
                LevelMin = 11,
                Species = new[] {35,066,327,744,066,744,327,524,703},
            },
            new EncounterArea_USUM
            {
                Location = 034, idx = 3, mark = "Water", //Ten Carat Hill - Water
                Correction = 02, NPC = 1,
                LevelMin = 15,
                Species = new[] {40,041,041,041,041,054},
            },
            #endregion
            #region  Akala
            new EncounterArea_USUM(),
            new EncounterArea_USUM
            {
                Location = 050, //4
                Correction = 08, NPC = 0,
                LevelMin = 11,
                Species = new[] {41,506,749,736,174,734,731,174,133},
            },
            new EncounterArea_USUM
            {
                Location = 078,
                Correction = 24, NPC = 2,
                LevelMin = 12,
                Species = new[] {42,179,749,506,749,179,128,241},
            },
            new EncounterArea_USUM
            {
                Location = 052, idx = 1, //5
                Correction = 22,
                LevelMin = 13,
                Species = new[] {43,506,731,736,753,010,011,012},
            },
            new EncounterArea_USUM
            {
                Location = 052, idx = 2, //5
                Correction = 22, NPC = 1,
                LevelMin = 18,
                Species = new[] {37,753,732,438,753,736,010,011,012},
            },
            new EncounterArea_USUM
            {
                Location = 086, idx = 1, mark = "Grass", //Brooklet Hill
                Correction = 08, NPC = 1,
                LevelMin = 14,
                Species = new[] {39,751,060,054,278,046,046,046},
            },
            new EncounterArea_USUM
            {
                Location = 086, idx = 2, mark = "Water",//Brooklet Hill
                Correction = 07, NPC = 1,
                LevelMin = 14,
                Species = new[] {22,060,751,060,751,054},
            },
            new EncounterArea_USUM
            {
                Location = 088, // Brooklet Hill(Totem's Den)
                Correction = 03, NPC = 1,
                LevelMin = 14,
                Species = new[] {15,072,278,456},
            },
            new EncounterArea_USUM
            {
                Location = 090, idx = 1, mark = "S",//Lush Jungle - S
                Correction = 10,
                LevelMin = 19,
                Species = new[] {44,753,732,438,011,762,046,764,766,127,732},
            },
            new EncounterArea_USUM
            {
                Location = 090, idx = 2, mark = "W",//Lush Jungle - W
                Correction = 04, NPC = 2,
                LevelMin = 19,
                Species = new[] {44,753,732,438,011,762,046,764,766,127,732},
            },
            new EncounterArea_USUM
            {
                Location = 090, idx = 3, mark = "N",//Lush Jungle - N
                Correction = 09,
                LevelMin = 19,
                Species = new[] {44,753,732,438,011,762,046,764,766,127,732},
            },
            new EncounterArea_USUM
            {
                Location = 090, idx = 4, mark = "Cave", //Lush Jungle - Cave
                Correction = 02,
                LevelMin = 41,
                Species = new[] {37,042,051,042,051,757,757,042,636},
            },
            new EncounterArea_USUM
            {
                Location = 054, idx = 1, //6
                Correction = 12, NPC = 3,
                LevelMin = 14,
                Species = new[] {41,506,749,174,736,734,731,174,133},
            },
            new EncounterArea_USUM
            {
                Location = 054, idx = 2, //6
                Correction = 12, NPC = 2,
                LevelMin = 14,
                Species = new[] {41,506,741,174,736,734,731,174,133},
            },
            new EncounterArea_USUM
            {
                Location = 056, //7
                Correction = 11, NPC = 1,
                LevelMin = 16,
                Species = new[] {26,072,456,278,771},
            },
            new EncounterArea_USUM
            {
                Location = 058, idx = 1, mark = "Grass",//8
                Correction = 25,
                LevelMin = 17,
                Species = new[] {45,734,732,757,759,661,757},
            },
            new EncounterArea_USUM
            {
                Location = 058, idx = 2, mark = "Water",//8
                Correction = 26, NPC = 1,
                LevelMin = 17,
                Species = new[] {34,072,278,456,458},
            },
            new EncounterArea_USUM
            {
                Location = 064,
                Correction = 25, NPC = 1,
                LevelMin = 21,
                Species = new[] {35,072,456,278,771,072,456,771,771},
            },
            new EncounterArea_USUM
            {
                Location = 082, //Wela Volcano
                Correction = 11,
                LevelMin = 16,
                Species = new[] {8,757,661,104,240,115},
            },
            new EncounterArea_USUM
            {
                Location = 100, //Diglett's Tunnel
                Correction = 12,
                LevelMin = 20,
                Species = new[] {21,041,050,041,041,041,246},
            },
            new EncounterArea_USUM
            {
                Location = 076, //Memorial Hill
                Correction = 12, NPC = 1,
                LevelMin = 21,
                Species = new[] {0,092,708,092,041},
            },
            new EncounterArea_USUM
            {
                Location = 094,
                Correction = 10, NPC = 2,
                LevelMin = 21,
                Species = new[] {46,735,177,759,278,278,299,759},
            },
            #endregion
            #region Ula'ula
            new EncounterArea_USUM(),
            new EncounterArea_USUM
            {
                Location = 132, //Malie City
                Correction = 10, NPC = 0,
                LevelMin = 25,
                Species = new[] {13,568,088,572,081},
            },
            new EncounterArea_USUM
            {
                Location = 134, //Malie Garden
                Correction = 32,
                LevelMin = 24,
                Species = new[] {12,061,052,546,054,752,166},
            },
            new EncounterArea_USUM
            {
                Location = 106, //10
                Correction = 19, NPC = 1,
                LevelMin = 26,
                Species = new[] {22,735,022,674,227,166},
            },
            new EncounterArea_USUM
            {
                Location = 136, idx = 1, // Hokulani
                Correction = 27,
                LevelMin = 27,
                Species = new[] {37,605,774,774,173,374,173,132,132},
                Reverse = true, // Cleffa at night
            },
            new EncounterArea_USUM
            {
                Location = 136, idx = 2, // Hokulani
                Correction = 27,
                LevelMin = 27,
                Species = new[] {35,605,173,022,774,374,227,239,132},
                Reverse = true, // Cleffa at night
            },
            new EncounterArea_USUM
            {
                Location = 108, //11
                Correction = 12,
                LevelMin = 26,
                Species = new[] {12,735,732,047,775,674,166},
            },
            new EncounterArea_USUM
            {
                Location = 122, //12
                Correction = 13,
                LevelMin = 29,
                Species = new[] {21,075,749,324,324,229,229},
            },
            new EncounterArea_USUM
            {
                Location = 138,
                Correction = 6, NPC = 1,
                LevelMin = 29,
                Species = new[] {35,075,749,702,737,324,776,777,239},
            },
            new EncounterArea_USUM
            {
                Location = 124, //Haina Desert
                LevelMin = 32,
                Species = new[] {0,552,051,552,552},
            },
            new EncounterArea_USUM
            {
                Location = 114, //Tapu Village
                Correction = 17,
                LevelMin = 30,
                Species = new[] {22,735,279,359,037,361},
            },
            new EncounterArea_USUM
            {
                Location = 126, //14
                Correction = 22, NPC = 1,
                LevelMin = 30,
                Species = new[] {35,073,592,279,279,073,456,456,456},
            },
            new EncounterArea_USUM
            {
                Location = 150, //Megamart
                Correction = 02, NPC = 0,
                LevelMin = 31,
                Species = new[] {46,093,042,093,353,353,707,778},
            },
            new EncounterArea_USUM
            {
                Location = 116, idx = 1, mark = "Grass", //15
                Correction = 26, NPC = 1,
                LevelMin = 30,
                Species = new[] {22,735,279,279,279,079},
            },
            new EncounterArea_USUM
            {
                Location = 116, idx = 2, mark = "Water", //15
                Correction = 27, NPC = 1,
                LevelMin = 32,
                Species = new[] {15,073,279,456},
            },
            new EncounterArea_USUM
            {
                Location = 118, //16
                Correction = 12,
                LevelMin = 32,
                Species = new[] {32,735,559,279,279,079,079},
            },
            new EncounterArea_USUM
            {
                Location = 128, //Meadow
                Correction = 10, NPC = 0,
                LevelMin = 33,
                Species = new[] {39,743,546,670,741,166,166,166},
            },
            new EncounterArea_USUM
            {
                Location = 120, idx = 1, //17
                Correction = 09, Raining = true,
                LevelMin = 33,
                Species = new[] {10,735,022,559,166,166,166},
            },
            new EncounterArea_USUM
            {
                Location = 120, idx = 2, //17
                Correction = 09, Raining = true,
                LevelMin = 33,
                Species = new[] {47,735,022,559,227,075,227,625},
            },
            new EncounterArea_USUM
            {
                Location = 146, idx = 1, mark = "Base",
                Correction = 07, NPC = 5,
                LevelMin = 30,
                Species = new[] {35,037,361,735,735,359,037,361,359},
            },
            new EncounterArea_USUM
            {
                Location = 146, idx = 2, mark = "Mt Side",
                Correction = 02,
                LevelMin = 47,
                Species = new[] {22,037,362,359,359,215},
            },
            new EncounterArea_USUM
            {
                Location = 146, idx = 3, mark = "West Room",
                Correction = 08,
                LevelMin = 47,
                Species = new[] {22,042,362,359,359,215},
            },
            new EncounterArea_USUM
            {
                Location = 146, idx = 4, mark = "Outside",
                Correction = 05, NPC = 3,
                LevelMin = 47,
                Species = new[] {22,037,362,359,780,215},
                Reverse = true,
            },
            new EncounterArea_USUM
            {
                Location = 146, idx = 5, mark = "Cave",
                Correction = 07, NPC = 0,
                LevelMin = 48,
                Species = new[] {22,042,362,359,780,215},
                Reverse = true,
            },
            new EncounterArea_USUM
            {
                Location = 146, idx = 6, mark = "Mid-Point",
                LevelMin = 48,
                Species = new[] {22,037,362,359,780,215},
                Reverse = true,
            },
            #endregion
            #region Poni
            new EncounterArea_USUM(),
            new EncounterArea_USUM
            {
                Location = 184, // Exeggutor Island
                Correction = 09, NPC = 4,
                LevelMin = 42,
                Species = new[] {35,103,279,102,357,357,127,423,102},
            },
            new EncounterArea_USUM
            {
                Location = 158, // Poni Wilds
                Correction = 13,
                LevelMin = 41,
                Species = new[] {37,676,279,686,279,210,423,686,686},
            },
            new EncounterArea_USUM
            {
                Location = 160,
                Correction = 19, NPC = 3,
                LevelMin = 41,
                Species = new[] {37,676,279,686,279,210,423,686,686},
            },
            new EncounterArea_USUM
            {
                Location = 174, idx = 1, mark = "Inside",
                Correction = 6, NPC = 1,
                LevelMin = 42,
                Species = new[] {14,042,051,525,525,703},
            },
            new EncounterArea_USUM
            {
                Location = 174, idx = 2, mark = "Top",
                LevelMin = 42,
                Species = new[] {48,067,745,619,227,525,619,703,782},
            },
            new EncounterArea_USUM
            {
                Location = 174, idx = 3, mark = "2F",
                Correction = 4, NPC = 0,
                LevelMin = 42,
                Species = new[] {14,042,051,525,525,703},
            },
            new EncounterArea_USUM
            {
                Location = 174, idx = 4, mark = "3F",
                Correction = 7,
                LevelMin = 42,
                Species = new[] {14,042,051,525,525,703},
            },
            new EncounterArea_USUM
            {
                Location = 174, idx = 5, mark = "Under Tree",
                Correction = 20, NPC = 1,
                LevelMin = 42,
                Species = new[] {48,067,745,619,227,525,619,703,782},
            },
            new EncounterArea_USUM
            {
                Location = 174, idx = 6, mark = "B1F-C",
                Correction = 9,
                LevelMin = 42,
                Species = new[] {14,042,051,525,525,703},
            },
            new EncounterArea_USUM
            {
                Location = 174, idx = 7, mark = "B1F-W",
                Correction = 10, NPC = 1,
                LevelMin = 42,
                Species = new[] {14,042,055,042,042,042},
            },
            new EncounterArea_USUM
            {
                Location = 162,
                Correction = 07, NPC = 1,
                LevelMin = 41,
                Species = new[] {41,073,423,279,279,457,457,073,131},
            },
            new EncounterArea_USUM
            {
                Location = 164, // Poni Grove
                Correction = 9,
                LevelMin = 52,
                Species = new[] {32,427,732,214,571,127,447},
            },
            new EncounterArea_USUM
            {
                Location = 166, idx = 1, // Poni Plains
                Correction = 10, NPC = 1,
                LevelMin = 54,
                Species = new[] {7,735,279,732,546,128,241,546},
            },
            new EncounterArea_USUM
            {
                Location = 166, idx = 2, // Poni Plains
                Correction = 10, NPC = 0,
                LevelMin = 54,
                Species = new[] {21,735,732,546,128,241,546},
            },
            new EncounterArea_USUM
            {
                Location = 166, idx = 3, // Poni Plains
                Correction = 10, NPC = 2,
                LevelMin = 54,
                Species = new[] {7,735,297,732,546,128,241,097},
            },
            new EncounterArea_USUM
            {
                Location = 166, idx = 4, // Poni Plains
                Correction = 10, NPC = 0,
                LevelMin = 54,
                Species = new[] {31,735,732,750,022,546,128,241},
            },
            new EncounterArea_USUM
            {
                Location = 156, // Meadow
                Correction = 6,
                LevelMin = 54,
                Species = new[] {39,743,546,670,741,200,166,166},
                Reverse = true,
            },
            new EncounterArea_USUM
            {
                Location = 182, idx = 1, mark = "1F", //Resolution Cave
                Correction = 4,
                LevelMin = 56,
                Species = new[] {49,042,051,715,621},
            },
            new EncounterArea_USUM
            {
                Location = 182, idx = 2, mark = "B1F", //Resolution Cave
                Correction = 2,
                LevelMin = 56,
                Species = new[] {39,715,051,042,715,621,621,621},
            },
            new EncounterArea_USUM
            {
                Location = 170, // Poni Gauntlet
                Correction = 11, NPC = 2,
                LevelMin = 58,
                Species = new[] {44,108,279,686,760,210,210,055,279,686,686},
            },
            #endregion
        };

        public readonly static FishingArea7[] Fishing_SM =
        {
            new FishingArea7
            {
                Location = 172, // Seafolk Village
                NPC = 1, Longdelay = true,
                LevelMax = 43,
                SlotType = 37,
                Species = new[] {129,320,781},
            },
            new FishingArea7
            {
                Location = 042, // Seaward Cave
                NPC = 1, Lapras = true,
                LevelMax = 15,
                SlotType = 25,
                Species = new[] {129,339},
            },
            new FishingArea7
            {
                Location = 014, // Kala'e Bay
                LevelMax = 15,
                SlotType = 27,
                Species = new[] {129,746,090},
            },
            new FishingArea7
            {
                Location = 016, // Melemele Sea
                NPC = 2, Lapras = true,
                LevelMax = 18,
                SlotType = 29,
                Species = new[] {129,746,370,222},
            },
            new FishingArea7
            {
                Location = 068, // Paniola Town
                NPC = 6,
                LevelMax = 18,
                SlotType = 25,
                Species = new[] {129,339},
            },
            new FishingArea7
            {
                Location = 086, // Brooklet Hill
                NPC = 2, Lapras = true,
                LevelMax = 15,
                SlotType = 31,
                Species = new[] {129,118,349},
            },
            new FishingArea7
            {
                Location = 088, // Brooklet Hill - Totem's Den
                NPC = 1, Lapras = true,
                LevelMax = 15,
                SlotType = 27,
                Species = new[] {129,746,594},
            },
            new FishingArea7
            {
                Location = 056, // Route 7
                LevelMax = 19,
                SlotType = 33,
                Species = new[] {129,746,120},
            },
            new FishingArea7
            {
                Location = 058, // Route 8
                NPC = 3, Lapras = true,
                LevelMax = 20,
                SlotType = 33,
                Species = new[] {129,746,170},
            },
            new FishingArea7
            {
                Location = 060, // Route 9
                NPC = 3, Longdelay = true,
                LevelMax = 23,
                SlotType = 35,
                Species = new[] {129,746,370,222},
            },
            new FishingArea7
            {
                Location = 094, // Akala Outskirts
                Longdelay = true,
                LevelMax = 23,
                SlotType = 33,
                Species = new[] {129,746,170},
            },
            new FishingArea7
            {
                Location = 134, // Malie Garden
                LevelMax = 27,
                SlotType = 48,
                Species = new[] {129,118},
            },
            new FishingArea7
            {
                Location = 110, // Secluded Shore
                NPC = 7, Lapras = true,
                LevelMax = 30,
                SlotType = 27,
                Species = new[] {129,746,779},
            },
            new FishingArea7
            {
                Location = 112, // Route 13
                NPC = 3, Longdelay = true,
                LevelMax = 30,
                SlotType = 27,
                Species = new[] {129,746,779},
            },
            new FishingArea7
            {
                Location = 126, // Route 14
                NPC = 1, Lapras = true,
                LevelMax = 31,
                SlotType = 27,
                Species = new[] {129,746,779},
            },
            new FishingArea7
            {
                Location = 116, // Route 15
                NPC = 1, Lapras = true,
                LevelMax = 33,
                SlotType = 27,
                Species = new[] {129,746,779},
            },
            new FishingArea7
            {
                Location = 158, // Poni Wilds
                NPC = 1, Lapras = true,
                LevelMax = 43,
                SlotType = 37,
                Species = new[] {129,320,369},
            },
            new FishingArea7
            {
                Location = 162, // Poni Breaker Coast
                NPC = 2,
                LevelMax = 43,
                SlotType = 37,
                Species = new[] {129,320,319},
            },
            new FishingArea7
            {
                Location = 174, // Vast Poni Canyon
                NPC = 2, Lapras = true,
                LevelMax = 44,
                SlotType = 23,
                Species = new[] {129,339,147},
            },
            new FishingArea7
            {
                Location = 156, // Poni Meadow
                NPC = 2,
                LevelMax = 57,
                SlotType = 23,
                Species = new[] {129,339,147},
            },
            new FishingArea7
            {
                Location = 170, // Poni Gauntlet
                NPC = 7, Longdelay = true,
                LevelMax = 59,
                SlotType = 23,
                Species = new[] {129,339,147},
            },
        };

        public readonly static FishingArea7[] Fishing_USUM =
        {
            new FishingArea7
            {
                Location = 172,  // Seafolk Village
                NPC = 1, Longdelay = true,
                LevelMax = 44,
                SlotType = 13,
                Species = new[] {129,320,781},
            },
            new FishingArea7
            {
                Location = 042, // Seaward Cave
                NPC = 6, Lapras = true,
                LevelMax = 17,
                SlotType = 5,
                Species = new[] {129,339},
            },
            new FishingArea7
            {
                Location = 014, // Kala'e Bay
                LevelMax = 17,
                SlotType = 7,
                Species = new[] {129,746,090,223},
            },
            new FishingArea7
            {
                Location = 016, // Melemele Sea
                NPC = 3, Lapras = true,
                LevelMax = 17,
                SlotType = 9,
                Species = new[] {129,746,370,222,366,223},
            },
            new FishingArea7
            {
                Location = 068, // Paniola Town
                NPC = 4,
                LevelMax = 18,
                SlotType = 5,
                Species = new[] {129,339},
            },
            new FishingArea7
            {
                Location = 086, // Brooklet Hill
                NPC = 2, Lapras = true,
                LevelMax = 16,
                SlotType = 11,
                Species = new[] {129,118,349,550},
            },
            new FishingArea7
            {
                Location = 088, // Brooklet Hill - Totem's Den
                NPC = 1, Lapras = true,
                LevelMax = 16,
                SlotType = 13,
                Species = new[] {129,746,594},
            },
            new FishingArea7
            {
                Location = 056, // Route 7
                LevelMax = 18,
                SlotType = 50,
                Species = new[] {129,746,120},
            },
            new FishingArea7
            {
                Location = 058, // Route 8
                NPC = 5, Lapras = true,
                LevelMax = 20,
                SlotType = 15,
                Species = new[] {129,746,170,223},
            },
            new FishingArea7
            {
                Location = 060, // Route 9
                NPC = 2, Longdelay = true,
                LevelMax = 23,
                SlotType = 17,
                Species = new[] {129,746,370,222},
            },
            new FishingArea7
            {
                Location = 094, // Akala Outskirts
                NPC = 1, Longdelay = true,
                LevelMax = 24,
                SlotType = 13,
                Species = new[] {129,746,170},
            },
            new FishingArea7
            {
                Location = 134, // Malie Garden
                LevelMax = 28,
                SlotType = 46,
                Species = new[] {129,118,550,130},
            },
            new FishingArea7
            {
                Location = 112, // Route 13
                NPC = 4, Longdelay = true,
                LevelMax = 33,
                SlotType = 13,
                Species = new[] {129,746,779},
            },
            new FishingArea7
            {
                Location = 126, // Route 14
                NPC = 1, Lapras = true,
                LevelMax = 34,
                SlotType = 13,
                Species = new[] {129,746,779},
            },
            new FishingArea7
            {
                Location = 116, // Route 15
                NPC = 3, Lapras = true,
                LevelMax = 35,
                SlotType = 19,
                Species = new[] {129,746,779,366},
            },
            new FishingArea7
            {
                Location = 162, // Poni Breaker Coast
                NPC = 2,
                LevelMax = 44,
                SlotType = 52,
                Species = new[] {129,320,318,369},
            },
            new FishingArea7
            {
                Location = 174, // Vast Poni Canyon
                NPC = 2, Lapras = true,
                LevelMax = 46,
                SlotType = 21,
                Species = new[] {129,339,341,550},
            },
            new FishingArea7
            {
                Location = 156, // Poni Meadow
                NPC = 2,
                LevelMax = 57,
                SlotType = 23,
                Species = new[] {129,339,147},
            },
            new FishingArea7
            {
                Location = 170, // Poni Gauntlet
                NPC = 7, Longdelay = true,
                LevelMax = 61,
                SlotType = 23,
                Species = new[] {129,339,147},
            },
        };

        public readonly static MiscEncounter7[] Misc_USUM =
        {
            new MiscEncounter7
            {
                Location = 012, // Route 2
                NPC = 1, LevelMin = 07,
                SlotType = 43, Species = new[] {023, 206, 296, 096},
            },
            new MiscEncounter7
            {
                Location = 010, // Route 3
                NPC = 2, LevelMin = 10,
                DelayType2 = 1, Delay2 = 138,
                SlotType = 40, Species = new[] {021, 627},
            },
            new MiscEncounter7
            {
                Location = 052, // Route 5
                NPC = 1, LevelMin = 18,
                SlotType = 42, Species = new[] {050},
            },
            new MiscEncounter7
            {
                Location = 056, // Route 7
                NPC = 2, LevelMin = 16,
                SlotType = 42, Species = new[] {050},
            },
            new MiscEncounter7
            {
                Location = 232, idx = 1, // Dividing Peak Tunnel
                NPC = 2, LevelMin = 17,
                SlotType = 42, Species = new[] {352},
            },
            new MiscEncounter7
            {
                Location = 232, idx = 2, // Dividing Peak Tunnel
                NPC = 5, LevelMin = 17,
                SlotType = 42, Species = new[] {767},
            },
            new MiscEncounter7
            {
                Location = 058, // Route 8
                NPC = 3, LevelMin = 17,
                SlotType = 42, Species = new[] {767},
            },
            new MiscEncounter7
            {
                Location = 090, // Lush Jungle
                NPC = 1, LevelMin = 19,
                SlotType = 40, Species = new[] {762,766},
            },
            new MiscEncounter7
            {
                Location = 100, // Diglett's Tunnel
                NPC = 1, LevelMin = 20,
                SlotType = 42, Species = new[] {050},
            },
            new MiscEncounter7
            {
                Location = 064, idx = 1, // Hano Beach
                NPC = 3, LevelMin = 22,
                DelayType1 = 3,
                SlotType = 40, Species = new[] {120, 769},
            },
            new MiscEncounter7
            {
                Location = 064, idx = 2, // Hano Beach
                NPC = 2, LevelMin = 22,
                SlotType = 42, Species = new[] {072},
            },
            new MiscEncounter7
            {
                Location = 106, // Route 10
                NPC = 2, LevelMin = 26,
                DelayType1 = 3,
                DelayType2 = 0, Delay2 = 162,
                SlotType = 28, Species = new[] {022, 204, 227},
            },
            new MiscEncounter7
            {
                Location = 124, // Haina Desert
                NPC = 1, LevelMin = 32,
                SlotType = 44, Species = new[] {551, 051, 328},
            },
            new MiscEncounter7
            {
                Location = 174, // Vast Poni Canyon
                NPC = 1, LevelMin = 42,
                SlotType = 42, Species = new[] {051},
            },
            new MiscEncounter7
            {
                Location = 162, idx = 1, // Poni Breaker Coast
                NPC = 1, LevelMin = 41,
                SlotType = 42, Species = new[] {767},
            },
            new MiscEncounter7
            {
                Location = 162, idx = 2, // Poni Breaker Coast
                NPC = 3, LevelMin = 41,
                SlotType = 45, Species = new[] {320, 321, 693},
            },
            new MiscEncounter7
            {
                Location = 166, idx = 1, // Poni Plains
                NPC = 2, LevelMin = 54,
                DelayType1 = 3,
                DelayType2 = 0, Delay2 = 162,
                SlotType = 28, Species = new[] {546, 123, 113},
            },
            new MiscEncounter7
            {
                Location = 166, idx = 2, // Poni Plains
                NPC = 2, LevelMin = 54,
                DelayType1 = 3,
                DelayType2 = 0, Delay2 = 162,
                SlotType = 34, Species = new[] {057, 190, 587},
            },
            new MiscEncounter7
            {
                Location = 166, idx = 3, // Poni Plains
                NPC = 2, LevelMin = 54,
                DelayType2 = 1, Delay2 = 138,
                SlotType = 40, Species = new[] {022, 628},
            },
            new MiscEncounter7
            {
                Location = 166, idx = 4, // Poni Plains
                NPC = 4, LevelMin = 54,
                SlotType = 40, Species = new[] {735, 668},
            },
            new MiscEncounter7
            {
                Location = 168, // Poni Coast
                NPC = 5, LevelMin = 56,
                SlotType = 42, Species = new[] {051},
            },
        };

        public readonly static MiscEncounter7[] Misc_SM =
        {
            new MiscEncounter7
            {
                Location = 012, // Route 2
                NPC = 1, LevelMin = 09, LevelMax = 10,
                SlotType = 40, Species = new[] {023, 296},
            },
            new MiscEncounter7
            {
                Location = 010, // Route 3
                NPC = 2, LevelMin = 11, LevelMax = 12,
                DelayType2 = 1, Delay2 = 138,
                SlotType = 40, Species = new[] {021, 627},
            },
            new MiscEncounter7
            {
                Location = 052, // Route 5
                NPC = 1, LevelMin = 18,
                SlotType = 42, Species = new[] {050},
            },
            new MiscEncounter7
            {
                Location = 056, // Route 7
                NPC = 2, LevelMin = 16,
                SlotType = 42, Species = new[] {050},
            },
            new MiscEncounter7
            {
                Location = 058, // Route 8
                NPC = 3, LevelMin = 17,
                SlotType = 42, Species = new[] {767},
            },
            new MiscEncounter7
            {
                Location = 090, // Lush Jungle
                NPC = 1, LevelMin = 18,
                DelayType1 = 3,
                DelayType2 = 0, Delay2 = 162,
                SlotType = 42, Species = new[] {753},
            },
            new MiscEncounter7
            {
                Location = 100, // Diglett's Tunnel
                NPC = 1, LevelMin = 19,
                SlotType = 42, Species = new[] {050},
            },
            new MiscEncounter7
            {
                Location = 064, // Hano Beach
                NPC = 5, LevelMin = 21,
                DelayType1 = 3,
                SlotType = 41, Species = new[] {120, 769},
            },
            new MiscEncounter7
            {
                Location = 106, // Route 10
                NPC = 2, LevelMin = 24,
                DelayType1 = 3,
                DelayType2 = 0, Delay2 = 162,
                SlotType = 41, Species = new[] {022, 227},
            },
            new MiscEncounter7
            {
                Location = 124, // Haina Desert
                NPC = 1, LevelMin = 28,
                SlotType = 44, Species = new[] {551, 051, 328},
            },
            new MiscEncounter7
            {
                Location = 158, idx = 1, // Poni Wilds
                NPC = 1, LevelMin = 40,
                SlotType = 05, Species = new[] {320, 321},
            },
            new MiscEncounter7
            {
                Location = 158, idx = 2, // Poni Wilds
                NPC = 1, LevelMin = 40,
                SlotType = 42, Species = new[] {767},
            },
            new MiscEncounter7
            {
                Location = 162, // Poni Breaker Coast
                NPC = 1, LevelMin = 40,
                SlotType = 42, Species = new[] {767},
            },
            new MiscEncounter7
            {
                Location = 174, // Vast Poni Canyon
                NPC = 1, LevelMin = 41,
                SlotType = 42, Species = new[] {051},
            },
            new MiscEncounter7
            {
                Location = 166, idx = 1, // Poni Plains
                NPC = 2, LevelMin = 54,
                DelayType1 = 3,
                DelayType2 = 0, Delay2 = 162,
                SlotType = 40, Species = new[] {546, 123},
            },
            new MiscEncounter7
            {
                Location = 166, idx = 2, // Poni Plains
                NPC = 2, LevelMin = 54,
                DelayType1 = 3,
                DelayType2 = 0, Delay2 = 162,
                SlotType = 41, Species = new[] {057, 587},
            },
            new MiscEncounter7
            {
                Location = 166, idx = 3, // Poni Plains
                NPC = 2, LevelMin = 54,
                DelayType2 = 1, Delay2 = 138,
                SlotType = 40, Species = new[] {022, 628},
            },
            new MiscEncounter7
            {
                Location = 166, idx = 4, // Poni Plains
                NPC = 4, LevelMin = 54,
                SlotType = 40, Species = new[] {735, 297},
            },
            new MiscEncounter7
            {
                Location = 168, // Poni Coast
                NPC = 5, LevelMin = 56,
                SlotType = 42, Species = new[] {051},
            },
        };

        public readonly static int[] RustlingSpots = { 012, 046, 052, 058, 064, 158, 166 };

        public readonly static int[] FishingNPCChangeSpots = { 056, 126, 172 };

        public readonly static int[] CrabrawlerSpots = { 012, 010, 050, 052, 058, 106, 110, 118, 120, 158, 166 };
    }
}
