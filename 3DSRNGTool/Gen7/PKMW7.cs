namespace Pk3DSRNGTool
{
    public class PKMW7 : Pokemon
    {
        public override GameVersion Version { get; protected set; } = GameVersion.Gen7;
        public override short Delay { get; protected set; } = 8;
        public byte[] Rate;
        public int[] Location;

        public readonly static PokemonList[] Species_SM =
        {
            new PokemonList
            {
                Text = "Normal Wild",
                List = new[]
                {
                   new PKMW7 { Species = 000, Conceptual = true },
                }
            },
            new PokemonList
            {
                Text = "UB",
                List = new[]
                {
                    new PKMW7 { Species = 000, Level = 55, Conceptual = true, Rate = new byte[] { 30 } },

                    new PKMW7 { Species = 793, Level = 55, Location = new []{100,082}, Rate = new byte[]{80,30},},    // Nihilego
                    new PKMW7 { Species = 794, Level = 65, Location = new []{040}, Rate = new byte[]{30}, Version = GameVersion.SN,},    // Buzzwole
                    new PKMW7 { Species = 795, Level = 60, Location = new []{046}, Rate = new byte[]{50}, Version = GameVersion.MN,},   // Pheromosa
                    new PKMW7 { Species = 796, Level = 65, Location = new []{346,076}, Rate = new byte[]{15,30},},    // Xurkitree
                    new PKMW7 { Species = 797, Level = 65, Location = new []{134,124}, Rate = new byte[]{30,30}, Version = GameVersion.MN,},    // Celesteela
                    new PKMW7 { Species = 798, Level = 60, Location = new []{134,376,632}, Rate = new byte[]{30,30,30}, Version = GameVersion.SN,},    // Kartana
                    new PKMW7 { Species = 799, Level = 70, Location = new []{694}, Rate = new byte[]{80},},    // Guzzlord
                    new PKMW7 { Species = 800, Level = 75, Location = new []{548}, Rate = new byte[]{05},},    // Necrozma
                }
            },
            new PokemonList
            {
                Text = "Island Scan",
                List = new[]
                {
                    new PKMW7 { Species = 000, Level = 12, Conceptual = true },

                    // Melemele Island
                    new PKMW7 { Species = 155, Level = 12, Location = new[]{ 266, 522 }, }, // Cyndaquil @ Route 3
                    new PKMW7 { Species = 158, Level = 12, Location = new[]{ 298 }, }, // Totodile @ Seaward Cave
                    new PKMW7 { Species = 633, Level = 13, Location = new[]{ 290 }, }, // Deino @ Ten Carat Hill
                    new PKMW7 { Species = 116, Level = 18, Location = new[]{ 526 }, }, // Horsea @ Kala'e Bay
                    new PKMW7 { Species = 599, Level = 08, Location = new[]{ 021 }, }, // Klink @ Hau'oli City
                    new PKMW7 { Species = 152, Level = 10, Location = new[]{ 268, 524 }, }, // Chikorita @ Route 2
                    new PKMW7 { Species = 607, Level = 10, Location = new[]{ 038 }, }, // Litwick @ Hau'oli Cemetery
                                                                                                                       
                    // Akala Island                                                                                            
                    new PKMW7 { Species = 574, Level = 17, Location = new[]{ 310, 566 }, }, // Gothita @ Route 6
                    new PKMW7 { Species = 363, Level = 19, Location = new[]{ 056 }, }, // Spheal @ Route 7
                    new PKMW7 { Species = 404, Level = 20, Location = new[]{ 314 }, }, // Luxio @ Route 8
                    new PKMW7 { Species = 679, Level = 23, Location = new[]{ 094 }, }, // Honedge @ Akala Outskirts
                    new PKMW7 { Species = 543, Level = 14, Location = new[]{ 050 }, }, // Venipede @ Route 4
                    new PKMW7 { Species = 069, Level = 16, Location = new[]{ 308, 564 }, }, // Bellsprout @ Route 5
                    new PKMW7 { Species = 183, Level = 17, Location = new[]{ 342, 344 }, }, // Marill @ Brooklet Hill
                                                                                                                       
                    // Ula'ula Island                                                                                          
                    new PKMW7 { Species = 111, Level = 30, Location = new[]{ 394, 650 }, }, // Rhyhorn @ Blush Mountain
                    new PKMW7 { Species = 220, Level = 31, Location = new[]{ 114 }, }, // Swinub @ Tapu Village
                    new PKMW7 { Species = 578, Level = 33, Location = new[]{ 118 }, }, // Duosion @ Route 16
                    new PKMW7 { Species = 315, Level = 34, Location = new[]{ 128 }, }, // Roselia @ Ula'ula Meadow
                    new PKMW7 { Species = 397, Level = 27, Location = new[]{ 106 }, }, // Staravia @ Route 10
                    new PKMW7 { Species = 288, Level = 27, Location = new[]{ 108 }, }, // Vigoroth @ Route 11
                    new PKMW7 { Species = 610, Level = 28, Location = new[]{ 136 }, }, // Axew @ Mount Hokulani
                                                                                                                       
                    // Poni Island                                                                                             
                    new PKMW7 { Species = 604, Level = 55, Location = new[]{ 164 }, }, // Eelektross @ Poni Grove
                    new PKMW7 { Species = 534, Level = 57, Location = new[]{ 422, 678, 934, 1190 }, }, // Conkeldurr @ Poni Plains
                    new PKMW7 { Species = 468, Level = 59, Location = new[]{ 170 }, }, // Togekiss @ Poni Gauntlet
                    new PKMW7 { Species = 542, Level = 57, Location = new[]{ 156 }, }, // Leavanny @ Poni Meadow
                    new PKMW7 { Species = 497, Level = 43, Location = new[]{ 184 }, }, // Serperior @ Exeggutor Island
                    new PKMW7 { Species = 503, Level = 43, Location = new[]{ 414 }, }, // Samurott @ Poni Wilds
                    new PKMW7 { Species = 500, Level = 43, Location = new[]{ 160 }, }, // Emboar @ Ancient Poni Path
                },
            },
        };

        public readonly static PokemonList[] Species_USUM =
        {
            new PokemonList
            {
                Text = "Normal Wild",
                List = new[]
                {
                   new PKMW7 { Species = 000, Conceptual = true },
                }
            },
            new PokemonList
            {
                Text = "UB",
                List = new[]
                {
                    new PKMW7 { Species = 000, Level = 60, Conceptual = true, Rate = new byte[] { 30 } },

                    new PKMW7 { Species = 805, Level = 60, Location = new []{164}, Rate = new byte[]{30}, Version = GameVersion.US,},    // Stakataka
                    new PKMW7 { Species = 806, Level = 60, Location = new []{164}, Rate = new byte[]{30}, Version = GameVersion.UM,},    // Blacephalon
                }
            },
            new PokemonList
            {
                Text = "Island Scan",
                List = new[]
                {
                    new PKMW7 { Species = 000, Level = 12, Conceptual = true },
                    
                    // Melemele Island
                    new PKMW7 { Species = 004, Level = 12, Location = new[] {266, 522}, }, // Charmander @ Route 3
                    new PKMW7 { Species = 007, Level = 12, Location = new[] {298}, }, // Squirtle @ Seaward Cave
                    new PKMW7 { Species = 095, Level = 14, Location = new[] {290}, }, // Onix @ Ten Carat Hill
                    new PKMW7 { Species = 116, Level = 18, Location = new[] {526}, }, // Horsea @ Kala'e Bay
                    new PKMW7 { Species = 664, Level = 09, Location = new[] {021}, }, // Scatterbug @ Hau'oli City
                    new PKMW7 { Species = 001, Level = 10, Location = new[] {268,524}, }, // Bulbasaur @ Route 2
                    new PKMW7 { Species = 607, Level = 09, Location = new[] {038}, }, // Litwick @ Hau'oli Cemetery
			
                    // Akala Island
                    new PKMW7 { Species = 280, Level = 17, Location = new[] {310,566}, }, // Ralts @ Route 6
                    new PKMW7 { Species = 363, Level = 19, Location = new[] {056}, }, // Spheal @ Route 7
                    new PKMW7 { Species = 256, Level = 20, Location = new[] {314}, }, // Combusken @ Route 8
                    new PKMW7 { Species = 679, Level = 24, Location = new[] {094}, }, // Honedge @ Akala Outskirts
                    new PKMW7 { Species = 015, Level = 14, Location = new[] {050}, }, // Beedrill @ Route 4
                    new PKMW7 { Species = 253, Level = 16, Location = new[] {308,564}, }, // Grovyle @ Route 5
                    new PKMW7 { Species = 259, Level = 17, Location = new[] {342,344}, }, // Marshtomp @ Brooklet Hill
			
                    // Ula'ula Island
                    new PKMW7 { Species = 111, Level = 32, Location = new[] {394,650}, }, // Rhyhorn @ Blush Mountain
                    new PKMW7 { Species = 220, Level = 33, Location = new[] {114}, }, // Swinub @ Tapu Village
                    new PKMW7 { Species = 394, Level = 35, Location = new[] {118}, }, // Prinplup @ Route 16
                    new PKMW7 { Species = 388, Level = 36, Location = new[] {128}, }, // Grotle @ Ula'ula Meadow
                    new PKMW7 { Species = 018, Level = 29, Location = new[] {106}, }, // Pidgeot @ Route 10
                    new PKMW7 { Species = 391, Level = 29, Location = new[] {108}, }, // Monferno @ Route 11
                    new PKMW7 { Species = 610, Level = 30, Location = new[] {136}, }, // Axew @ Mount Hokulani
			
                    // Poni Island
                    new PKMW7 { Species = 604, Level = 55, Location = new[] {164}, }, // Eelektross @ Poni Grove
                    new PKMW7 { Species = 306, Level = 57, Location = new[] {422, 678, 934, 1190}, }, // Aggron @ Poni Plains
                    new PKMW7 { Species = 479, Level = 61, Location = new[] {170}, }, // Rotom @ Poni Gauntlet
                    new PKMW7 { Species = 542, Level = 57, Location = new[] {156}, }, // Leavanny @ Poni Meadow
                    new PKMW7 { Species = 652, Level = 45, Location = new[] {184}, }, // Chesnaught @ Exeggutor Island
                    new PKMW7 { Species = 658, Level = 44, Location = new[] {414}, }, // Greninja @ Poni Wilds
                    new PKMW7 { Species = 655, Level = 44, Location = new[] {160}, }, // Delphox @ Ancient Poni Path
                }
            },
        };
    }
}
