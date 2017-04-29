using System.Linq;

namespace SMEncounter
{
    class LocationTable
    {
        public readonly static EncounterArea[] Table =
        {
            #region MeleMele
            new EncounterArea
            {
                Location = 006, idx = 1,
                Correction = 15,
                LevelMin = 02, LevelMax = 03,
                Species = new[] {0,734,731,010,165},
            },
            new EncounterArea
            {
                Location = 006, idx = 2,
                Correction = 15,
                LevelMin = 03, LevelMax = 05,
                Species = new[] {1,734,731,736,010,011,165,172},
            },
            new EncounterArea
            {
                Location = 006, idx = 3,
                Correction = 15, NPC = 2,
                LevelMin = 10,
                Species = new[] {2,734,731,438,010,011,165,446},
            },
            new EncounterArea
            {
                Location = 007, // Outskirts
                Correction = 23, NPC = 1,
                LevelMin = 05, LevelMax = 07,
                Species = new[] {0,734,278,278,079},
            },
            new EncounterArea
            {
                Location = 008, idx = 4, //Trainer School
                Correction = 09,
                LevelMin = 06, LevelMax = 08,
                Species = new[] {0,052,081,088,081},
            },
            new EncounterArea
            {
                Location = 016, idx = 1, mark = "E",
                Correction = 09, NPC = 1,
                LevelMin = 15,
                Species = new[] {15,072,278,456},
            },
            new EncounterArea
            {
                Location = 016, idx = 2, mark = "W",
                Correction = 05, NPC = 1,
                LevelMin = 15,
                Species = new[] {15,072,278,456},
            },
            new EncounterArea
            {
                Location = 012, idx = 1,
                Correction = 21, NPC = 0,
                LevelMin = 07,
                Species = new[] {16,096,052,734,235,063},
            },
            new EncounterArea
            {
                Location = 012, idx = 2,
                Correction = 21, NPC = 1,
                LevelMin = 07,
                Species = new[] {17,742,058,734,021,235},
            },
            new EncounterArea
            {
                Location = 046, // Verdant Cavern
                Correction = 05,
                LevelMin = 08,
                Species = new[] {0,041,050,041,041},
            },
            new EncounterArea
            {
                Location = 010, idx = 1,
                Correction = 15, NPC = 0,
                LevelMin = 09,
                Species = new[] {18,742,021,734,225,056},
            },
            new EncounterArea
            {
                Location = 010, idx = 2,
                Correction = 15, NPC = 1,
                LevelMin = 09,
                Species = new[] {19,742,021,734,056,371},
            },
            new EncounterArea
            {
                Location = 019,
                Correction = 17, NPC = 1,
                LevelMin = 15,
                Species = new[] {15,072,278,456},
            },
            new EncounterArea
            {
                Location = 021,
                Correction = 27,
                LevelMin = 05,
                Species = new[] {20,734,278,063,088,081,052,172},
            },
            new EncounterArea
            {
                Location = 038,
                Correction = 06, NPC = 3,
                LevelMin = 07,
                Species = new[] {0,092,425,092,041},
            },
            new EncounterArea
            {
                Location = 040, // Melemele Meadow
                Correction = 05,
                LevelMin = 09,
                Species = new[] {5,742,546,741,010,011,012},
            },
            new EncounterArea
            {
                Location = 042, idx = 1, mark = "Cave",
                LevelMin = 09,
                Species = new[] {0,041,050,041,041},
            },
            new EncounterArea
            {
                Location = 042, idx = 2, mark = "Water",
                Correction = 02, NPC = 1,
                LevelMin = 15,
                Species = new[] {14,041,054,041,041,041},
            },
            new EncounterArea
            {
                Location = 014, idx = 1, mark = "Grass",
                LevelMin = 15,
                Species = new[] {22,734,278,278,371,079},
            },
            new EncounterArea
            {
                Location = 014, idx = 2, mark = "Water",
                Correction = 02, NPC = 1,
                LevelMin = 15,
                Species = new[] {15,072,278,456},
            },
            new EncounterArea
            {
                Location = 034, idx = 1, mark = "Cave", //Ten Carat Hill - Cave
                Correction = 02,
                LevelMin = 10,
                Species = new[] {14,041,052,524,524,703},
            },
            new EncounterArea
            {
                Location = 036, idx = 2, mark = "Grass", //Ten Carat Hill - Grass
                LevelMin = 10,
                Species = new[] {14,066,744,327,524,703},
            },
            new EncounterArea
            {
                Location = 034, idx = 3, mark = "Water", //Ten Carat Hill - Water
                Correction = 03, NPC = 1,
                LevelMin = 15,
                Species = new[] {14,041,054,041,041,041},
            },
            #endregion
            #region  Akala
            new EncounterArea(),
            new EncounterArea
            {
                Location = 050, //4
                Correction = 06, NPC = 1,
                LevelMin = 11,
                Species = new[] {23,506,749,736,734,731,174,133},
            },
            new EncounterArea
            {
                Location = 078,
                Correction = 23, NPC = 2,
                LevelMin = 12,
                Species = new[] {24,506,749,128,241},
            },
            new EncounterArea
            {
                Location = 052, idx = 1, //5
                Correction = 21,
                LevelMin = 13,
                Species = new[] {3,506,731,753,736,010,011,012},
            },
            new EncounterArea
            {
                Location = 052, idx = 2, //5
                Correction = 21, NPC = 1,
                LevelMin = 18,
                Species = new[] {4,753,732,438,736,010,011,012},
            },
            new EncounterArea
            {
                Location = 090, idx = 1, mark = "S",//Lush Jungle - S
                Correction = 07,
                LevelMin = 18,
                Species = new[] {9,753,732,438,010,011,046,766,764},
            },
            new EncounterArea
            {
                Location = 090, idx = 2, mark = "W",//Lush Jungle - W
                Correction = 02,
                LevelMin = 18,
                Species = new[] {10,753,732,761,046,766,764},
            },
            new EncounterArea
            {
                Location = 090, idx = 3, mark = "N",//Lush Jungle - N
                Correction = 02,
                LevelMin = 18,
                Species = new[] {11,753,732,046,127,764,766},
            },
            new EncounterArea
            {
                Location = 090, idx = 4, mark = "Cave", //Lush Jungle - Cave
                Correction = 02,
                LevelMin = 18,
                Species = new[] {0,041,050,041,041},
            },
            new EncounterArea
            {
                Location = 086, idx = 1, mark = "Grass1", //Brooklet Hill
                Correction = 07, NPC = 1,
                LevelMin = 14,
                Species = new[] {6,506,054,751,060,278,046},
            },
            new EncounterArea
            {
                Location = 086, idx = 2, mark = "Water1",//Brooklet Hill
                Correction = 08, NPC = 1,
                LevelMin = 14,
                Species = new[] {22,060,751,060,751,054},
            },
            new EncounterArea
            {
                Location = 088, idx = 1, mark = "Grass2",//Brooklet Hill
                Correction = 05, NPC = 1,
                LevelMin = 14,
                Species = new[] {25,751,060,054,278},
            },
            new EncounterArea
            {
                Location = 088, idx = 2, mark = "Water2",//Brooklet Hill
                Correction = 06, NPC = 1,
                LevelMin = 14,
                Species = new[] {22,060,751,060,751,054},
            },
            new EncounterArea
            {
                Location = 089, mark = "Water", //Brooklet Hill
                Correction = 03, NPC = 1,
                LevelMin = 14,
                Species = new[] {15,072,278,456},
            },
            new EncounterArea
            {
                Location = 054, idx = 1, //6
                Correction = 11, NPC = 2,
                LevelMin = 14,
                Species = new[] {23,506,749,736,734,731,174,133},
            },
            new EncounterArea
            {
                Location = 054, idx = 2, //6
                Correction = 11, NPC = 2,
                LevelMin = 14,
                Species = new[] {23,506,741,736,734,731,174,133},
            },
            new EncounterArea
            {
                Location = 056, //7
                Correction = 11, NPC = 1,
                LevelMin = 16,
                Species = new[] {26,072,456,278,771},
            },
            new EncounterArea
            {
                Location = 058, idx = 1, mark = "Grass",//8
                Correction = 15,
                LevelMin = 17,
                Species = new[] {27,734,732,757,662,759},
            },
            new EncounterArea
            {
                Location = 058, idx = 2, mark = "Water",//8
                Correction = 16, NPC = 3,
                LevelMin = 17,
                Species = new[] {15,072,278,456},
            },
            new EncounterArea
            {
                Location = 064,
                Correction = 24, NPC = 1,
                LevelMin = 21,
                Species = new[] {26,072,456,278,771},
            },
            new EncounterArea
            {
                Location = 082, //Wela Volcano
                Correction = 09,
                LevelMin = 16,
                Species = new[] {8,757,661,104,240,115},
            },
            new EncounterArea
            {
                Location = 100, //Diglett's Tunnel
                Correction = 13,
                LevelMin = 19,
                Species = new[] {0,041,050,041,041},
            },
            new EncounterArea
            {
                Location = 076, //Memorial Hill
                Correction = 12, NPC = 1,
                LevelMin = 20,
                Species = new[] {0,092,708,092,041},
            },
            new EncounterArea
            {
                Location = 094,
                Correction = 07, NPC = 2,
                LevelMin = 20,
                Species = new[] {27,735,278,278,299,759},
            },
            #endregion
            #region Ula'ula
            new EncounterArea(),
            new EncounterArea
            {
                Location = 132, //Malie City
                Correction = 09, NPC = 4,
                LevelMin = 24,
                Species = new[] {13,568,088,735,081},
            },
            new EncounterArea
            {
                Location = 134, //Malie Garden
                Correction = 26,
                LevelMin = 24,
                Species = new[] {12,060,052,546,054,752,166},
            },
            new EncounterArea
            {
                Location = 106, //10
                Correction = 19, NPC = 2,
                LevelMin = 24,
                Species = new[] {22,735,022,674,227,166},
            },
            new EncounterArea
            {
                Location = 136, // Ditto
                Correction = 16,
                LevelMin = 25,
                Species = new[] {21,022,774,374,227,173,132},
                Reverse = true, // Cleffa at night
            },
            new EncounterArea
            {
                Location = 108, //11
                Correction = 10,
                LevelMin = 24,
                Species = new[] {12,735,732,046,775,674,166},
            },
            new EncounterArea
            {
                Location = 122, idx = 1,//12
                Correction = 11,
                LevelMin = 26,
                Species = new[] {21,074,749,324,324,074,239},
            },
            new EncounterArea
            {
                Location = 122, idx = 2,//12
                Correction = 11, NPC = 1,
                LevelMin = 25,
                Species = new[] {21,074,749,324,324,074,239},
            },
            new EncounterArea
            {
                Location = 110,
                Correction = 12, NPC = 1,
                LevelMin = 27,
                Species = new[] {15,072,279,456},
            },
            new EncounterArea
            {
                Location = 138, idx = 1,
                Correction = 3, NPC = 1,
                LevelMin = 27, lvldiff = -1,
                Species = new[] {7,074,749,737,324,776,777,239},
            },
            new EncounterArea
            {
                Location = 138, idx = 2,
                Correction = 3, NPC = 1,
                LevelMin = 27,
                Species = new[] {7,074,749,737,324,776,777,239},
            },
            new EncounterArea
            {
                Location = 124, //Haina Desert
                LevelMin = 28,
                Species = new[] {0,551,051,551,551},
            },
            new EncounterArea
            {
                Location = 114, //Tapu Village
                Correction = 11,
                LevelMin = 28,
                Species = new[] {22,735,279,359,037,361},
            },
            new EncounterArea
            {
                Location = 126, //14
                Correction = 12, NPC = 1,
                LevelMin = 28,
                Species = new[] {15,072,279,456},
            },
            new EncounterArea
            {
                Location = 150, //Megamart
                LevelMin = 29,
                Species = new[] {28,093,042,707,778},
            },
            new EncounterArea
            {
                Location = 116, idx = 1, mark = "Grass", //15
                Correction = 20, NPC = 1,
                LevelMin = 30,
                Species = new[] {22,735,279,279,279,079},
            },
            new EncounterArea
            {
                Location = 116, idx = 2, mark = "Water", //15
                Correction = 21, NPC = 1,
                LevelMin = 30,
                Species = new[] {15,072,279,456},
            },
            new EncounterArea
            {
                Location = 118, //16
                Correction = 10,
                LevelMin = 30,
                Species = new[] {22,735,279,279,279,079},
            },
            new EncounterArea
            {
                Location = 128, //Meadow
                Correction = 08,
                LevelMin = 31,
                Species = new[] {22,734,546,741,741,166},
            },
            new EncounterArea
            {
                Location = 120, idx = 1, //17
                Correction = 10,
                LevelMin = 31,
                Species = new[] {22,735,022,674,674,166},
            },
            new EncounterArea
            {
                Location = 120, idx = 2, //17
                Correction = 10,
                LevelMin = 31,
                Species = new[] {21,735,022,674,075,075,227},
            },
            new EncounterArea
            {
                Location = 146, idx = 1,
                LevelMin = 42,
                Species = new[] {22,037,361,359,359,215},
            },
            new EncounterArea
            {
                Location = 146, idx = 2,
                LevelMin = 42,
                Species = new[] {22,042,361,359,780,215},
                Reverse = true,
            },
            new EncounterArea
            {
                Location = 146, idx = 3,
                LevelMin = 45, lvldiff = -3,
                Species = new[] {22,037,361,359,359,215},
            },
            #endregion
            #region Poni
            new EncounterArea(),
            new EncounterArea
            {
                Location = 184, // Exeggutor Island
                Correction = 03,
                LevelMin = 40,
                Species = new[] {29,103,279,102,423},
            },
            new EncounterArea
            {
                Location = 158, idx = 1, mark = "Grass", // Poni Wilds
                Correction = 09,
                LevelMin = 40,
                Species = new[] {5,735,279,210,423,102,102},
            },
            new EncounterArea
            {
                Location = 158, idx = 2, mark = "Water", // Poni Wilds
                Correction = 10, NPC = 1,
                LevelMin = 40,
                Species = new[] {30,073,423,279,457,131},
            },
            new EncounterArea
            {
                Location = 160,
                Correction = 20, NPC = 3,
                LevelMin = 40,
                Species = new[] {5,735,279,210,423,102,102},
            },
            new EncounterArea
            {
                Location = 174, idx = 1, mark = "Inside",
                Correction = 6, NPC = 1,
                LevelMin = 41,
                Species = new[] {14,042,051,525,525,703},
            },
            new EncounterArea
            {
                Location = 174, idx = 2, mark = "Top",
                LevelMin = 41,
                Species = new[] {1,067,745,227,525,198,703,782},
            },
            new EncounterArea
            {
                Location = 174, idx = 3, mark = "2F",
                Correction = 4,
                LevelMin = 41,
                Species = new[] {14,042,051,525,525,703},
            },
            new EncounterArea
            {
                Location = 174, idx = 4, mark = "3F",
                Correction = 8,
                LevelMin = 41,
                Species = new[] {14,042,051,525,525,703},
            },
            new EncounterArea
            {
                Location = 174, idx = 5, mark = "Under Tree",
                Correction = 15,
                LevelMin = 41,
                Species = new[] {1,067,745,227,525,198,703,782},
            },
            new EncounterArea
            {
                Location = 174, idx = 6, mark = "B1F-C",
                Correction = 8,
                LevelMin = 41,
                Species = new[] {14,042,055,055,055},
            },
            new EncounterArea
            {
                Location = 174, idx = 7, mark = "B1F-W",
                Correction = 9, NPC = 1,
                LevelMin = 41,
                Species = new[] {14,042,055,042,042,042},
            },
            new EncounterArea
            {
                Location = 164, // Poni Grove
                Correction = 4,
                LevelMin = 52,
                Species = new[] {5,735,732,210,127,447,447},
            },

            new EncounterArea
            {
                Location = 166, idx = 1, // Poni Plains
                Correction = 5, NPC = 1,
                LevelMin = 54,
                Species = new[] {7,735,279,732,546,128,241,546},
            },
            new EncounterArea
            {
                Location = 166, idx = 2, // Poni Plains
                Correction = 5, NPC = 1,
                LevelMin = 54,
                Species = new[] {21,735,732,546,128,241,546},
            },
            new EncounterArea
            {
                Location = 166, idx = 3, // Poni Plains
                Correction = 5, NPC = 1,
                LevelMin = 54,
                Species = new[] {7,735,097,732,546,128,241,546},
            },
            new EncounterArea
            {
                Location = 166, idx = 4, // Poni Plains
                Correction = 5, NPC = 1,
                LevelMin = 54,
                Species = new[] {31,735,732,750,022,546,128,241},
            },
            new EncounterArea
            {
                Location = 156, // Meadow
                Correction = 5,
                LevelMin = 54,
                Species = new[] {0,743,546,741,546},
            },
            new EncounterArea
            {
                Location = 182, idx = 1, mark = "1F", //Resolution Cave
                Correction = 3,
                LevelMin = 54,
                Species = new[] {0,042,051,042,042},
            },
            new EncounterArea
            {
                Location = 182, idx = 2, mark = "B1F", //Resolution Cave
                LevelMin = 54,
                Species = new[] {0,042,051,042,042},
            },
            new EncounterArea
            {
                Location = 170, // Poni Gauntlet
                Correction = 11, NPC = 4,
                LevelMin = 56,
                Species = new[] {27,735,279,210,055,760},
            },
            #endregion
        };

        public readonly static int[] SMLocationList = Table.Select(t => t.Locationidx).ToArray();

        // public readonly static int[] QRLocationList = Pokemon.QRScanSpecies.Skip(1).SelectMany(pk => pk.Location).ToArray();
    }
}
