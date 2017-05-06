namespace Pk3DSRNGTool
{
    public class PKM6 : Pokemon
    {
        public override GameVersion Version { get; set; } = GameVersion.Gen6;
        public override short Delay { get; set; } = 16;

        public readonly static PokemonList Default = new PokemonList
        {
            Text = "-",
            List = new[]
            {
                new PKM6 { Conceptual = true, Species= 000, Level = 50, },
            }
        };

        public readonly static PokemonList[] Species_ORAS =
        {
            Default,
            new PokemonList
            {
                Text = "Hoenn Legendary",
                List = new[]
                {
                    new PKM6 { Species = 380, Level = 30, Version = GameVersion.AS, Ability = 1, Gift = true, }, // Latias
                    new PKM6 { Species = 381, Level = 30, Version = GameVersion.OR, Ability = 1, Gift = true, }, // Latios

                    new PKM6 { Species = 381, Level = 30, Version = GameVersion.AS, Delay = 0, }, // Latios
                    new PKM6 { Species = 380, Level = 30, Version = GameVersion.OR, Delay = 0, }, // Latias

                    new PKM6 { Species = 382, Level = 45, ShinyLocked = true, Version = GameVersion.AS, Unstable = true, }, // Kyogre
                    new PKM6 { Species = 383, Level = 45, ShinyLocked = true, Version = GameVersion.OR, Unstable = true, }, // Groudon
                    new PKM6 { Species = 384, Level = 70, ShinyLocked = true, }, // Rayquaza
                    new PKM6 { Species = 386, Level = 80, ShinyLocked = true, }, // Deoxys

                    new PKM6 { Species = 377, Level = 40, Delay = 158, }, // Regirock
                    new PKM6 { Species = 378, Level = 40, Delay = 154, Unstable = true,  }, // Regice
                    new PKM6 { Species = 379, Level = 40, Delay = 164, }, // Registeel
                }
            },
            new PokemonList
            {
                Text = "Johto Legendary",
                List = new[]
                {
                    new PKM6 { Species = 243, Level = 50, }, // Raikou
                    new PKM6 { Species = 244, Level = 50, }, // Entei
                    new PKM6 { Species = 245, Level = 50, }, // Suicune

                    new PKM6 { Species = 249, Level = 50, Version = GameVersion.AS, Delay = 20, }, // Lugia
                    new PKM6 { Species = 250, Level = 50, Version = GameVersion.OR, Delay = 20, }, // Ho-oh
                }
            },
            new PokemonList
            {
                Text = "Sinnoh Legendary",
                List = new[]
                {
                    new PKM6 { Species = 480, Level = 50, }, // Uxie
                    new PKM6 { Species = 481, Level = 50, }, // Mesprit
                    new PKM6 { Species = 482, Level = 50, }, // Azelf
            
                    new PKM6 { Species = 483, Level = 50, Delay = 90, Version = GameVersion.AS, }, // Dialga
                    new PKM6 { Species = 484, Level = 50, Delay = 90, Version = GameVersion.OR, }, // Palkia
                    
                    new PKM6 { Species = 485, Level = 50, }, // Heatran
                    new PKM6 { Species = 486, Level = 50, }, // Regigigas
                    new PKM6 { Species = 487, Level = 50, Delay = 88, }, // Giratina
                    new PKM6 { Species = 488, Level = 50, }, // Cresselia
                }
            },
            new PokemonList
            {
                Text = "Unova Legendary",
                List = new[]
                {
                    new PKM6 { Species = 638, Level = 50, }, // Cobalion
                    new PKM6 { Species = 639, Level = 50, }, // Terrakion
                    new PKM6 { Species = 640, Level = 50, }, // Virizion

                    new PKM6 { Species = 641, Level = 50, Delay = 90, Version = GameVersion.OR, }, // Tornadus
                    new PKM6 { Species = 642, Level = 50, Delay = 90, Version = GameVersion.AS, }, // Thundurus
                    new PKM6 { Species = 645, Level = 50, Delay = 90, }, // Landorus
            
                    new PKM6 { Species = 643, Level = 50, Version = GameVersion.OR, }, // Reshiram
                    new PKM6 { Species = 644, Level = 50, Version = GameVersion.AS, }, // Zekrom
                    new PKM6 { Species = 646, Level = 50, }, // Kyurem
                }
            },
            new PokemonList
            {
                Text = "Gift",
                List = new[]
                {
                    new PKM6 { Species = 360, Level = 1, Ability = 1, Gift = true, Egg = true,}, // Wynaut
                    new PKM6 { Species = 175, Level = 1, Ability = 1, Gift = true, Egg = true,}, // Togepi
                    new PKM6 { Species = 374, Level = 1, Ability = 1, IVs = new[] {-1, -1, 31, -1, 31, -1}, Gift = true }, // Beldum

                    new PKM6 { Species = 351, Level = 30, Nature = 09, Ability = 1, IVs = new[] {-1, -1, -1, 31, -1, -1}, Gift = true }, // Castform
                    new PKM6 { Species = 319, Level = 40, Gender = 1, Ability = 1, Nature = 03, Gift = true }, // Sharpedo
                    new PKM6 { Species = 323, Level = 40, Gender = 1, Ability = 1, Nature = 17, Gift = true }, // Camerupt
                    new PKM6 { Species = 025, Level = 20, Delay = 0, Form = 1, Ability = 4, Gender = 2, Gift = true, ShinyLocked = true }, // Pikachu
                }
            },
            new PokemonList
            {
                Text = "Normal Stationary",
                List = new[]
                {
                    new PKM6 { Species = 352, Level = 30, Delay = 0,}, // Kecleon @ Route 120
                    new PKM6 { Species = 352, Level = 40, Delay = 0, Gender = 2,}, // Kecleon @ Lavaridge
                    new PKM6 { Species = 352, Level = 45, Delay = 0, Ability = 4,}, // Kecleon @ Mossdeeps
                    new PKM6 { Species = 101, Level = 40, Delay = 122, }, // Electrode @ Magma Hideout, Aqua Hideout
                    new PKM6 { Species = 100, Level = 20, Delay = 120, }, // Voltorb @ Route 119
                    new PKM6 { Species = 442, Level = 50, Delay = 0, }, // Spiritomb @ Route 120
                }
            },
            new PokemonList
            {
                Text = "Starters",
                List = new[]
                {
                    new PKM6 { Gift = true, Species = 252, Level = 5, Delay = 186, Syncable = false,}, // Treeko
                    new PKM6 { Gift = true, Species = 255, Level = 5, Delay = 138, Syncable = false,}, // Torchic
                    new PKM6 { Gift = true, Species = 258, Level = 5, Delay = 138, Syncable = false,}, // Mudkip
            
                    new PKM6 { Gift = true, Species = 152, Level = 5, }, // Chikorita
                    new PKM6 { Gift = true, Species = 155, Level = 5, }, // Cyndaquil
                    new PKM6 { Gift = true, Species = 158, Level = 5, }, // Totodile

                    new PKM6 { Gift = true, Species = 387, Level = 5, }, // Turtwig
                    new PKM6 { Gift = true, Species = 390, Level = 5, }, // Chimchar
                    new PKM6 { Gift = true, Species = 393, Level = 5, }, // Piplup

                    new PKM6 { Gift = true, Species = 495, Level = 5, }, // Snivy
                    new PKM6 { Gift = true, Species = 498, Level = 5, }, // Tepig
                    new PKM6 { Gift = true, Species = 501, Level = 5, }, // Oshawott
                }
            },
            new PokemonList
            {
                Text = "Fossils",
                List = new[]
                {
                    new PKM6 { Gift = true, Species = 138, Level = 20, Delay = 80, Syncable = false, }, // Omanyte
                    new PKM6 { Gift = true, Species = 140, Level = 20, Delay = 80, Syncable = false, }, // Kabuto
                    new PKM6 { Gift = true, Species = 142, Level = 20, Delay = 80, Syncable = false, }, // Aerodactyl
                    new PKM6 { Gift = true, Species = 345, Level = 20, Delay = 80, Syncable = false, }, // Lileep
                    new PKM6 { Gift = true, Species = 347, Level = 20, Delay = 80, Syncable = false, }, // Anorith
                    new PKM6 { Gift = true, Species = 408, Level = 20, Delay = 80, Syncable = false, }, // Cranidos
                    new PKM6 { Gift = true, Species = 410, Level = 20, Delay = 80, Syncable = false, }, // Shieldon
                    new PKM6 { Gift = true, Species = 564, Level = 20, Delay = 80, Syncable = false, }, // Tirtouga
                    new PKM6 { Gift = true, Species = 566, Level = 20, Delay = 80, Syncable = false, }, // Archen
                    new PKM6 { Gift = true, Species = 696, Level = 20, Delay = 80, Syncable = false, }, // Tyrunt
                    new PKM6 { Gift = true, Species = 698, Level = 20, Delay = 80, Syncable = false, }, // Amaura
                }
            },
        };

        public readonly static PokemonList[] Species_XY =
        {
            Default,
            new PokemonList
            {
                Text = "Legendary",
                List = new[]
                {
                    new PKM6 { Species = 716, Level = 50, ShinyLocked = true, Version = GameVersion.X, }, // Xerneas
                    new PKM6 { Species = 717, Level = 50, ShinyLocked = true, Version = GameVersion.Y, }, // Yveltal
                    new PKM6 { Species = 718, Level = 70, ShinyLocked = true }, // Zygarde

                    new PKM6 { Species = 150, Level = 70, ShinyLocked = true }, // Mewtwo

                    new PKM6 { Species = 144, Level = 70, ShinyLocked = true }, // Articuno
                    new PKM6 { Species = 145, Level = 70, ShinyLocked = true }, // Zapdos
                    new PKM6 { Species = 146, Level = 70, ShinyLocked = true }, // Moltres
                }
            },
            new PokemonList
            {
                Text = "Gift",
                List = new[]
                {
                    new PKM6 { Species = 448, Level = 32, Ability = 1, Nature = 11, Gender = 1, IVs = new[] {6, 25, 16, 25, 19, 31}, Gift = true, ShinyLocked = true }, // Lucario
                    new PKM6 { Species = 131, Level = 30, Nature = 6, IVs = new[] {31, 20, 20, 20, 20, 20}, Gift = true }, // Lapras
                }
            },
            new PokemonList
            {
                Text = "Normal Stationary",
                List = new[]
                {
                    new PKM6 { Species = 143, Level = 15,}, // Snorlax
                    //new PKM6 { Species = 568, Wild = true, Levelmin = 35, Levelmax = 38 }, // Trubbish
                    //new PKM6 { Species = 569, Wild = true, Levelmin = 46, Levelmax = 50 }, // Garbodor
                    //new PKM6 { Species = 354, Wild = true, Levelmin = 46, Levelmax = 50 }, // Banette
                    new PKM6 { Species = 479, Level = 38, }, // Rotom
                }
            },
            new PokemonList
            {
                Text = "Starters",
                List = new[]
                {
                    new PKM6 { Gift = true, Species = 650, Level = 5, Syncable = false, }, // Chespin
                    new PKM6 { Gift = true, Species = 653, Level = 5, Syncable = false, }, // Fennekin
                    new PKM6 { Gift = true, Species = 656, Level = 5, Syncable = false, }, // Froakie

                    new PKM6 { Gift = true, Species = 1, Level = 10,}, // Bulbasaur
                    new PKM6 { Gift = true, Species = 4, Level = 10,}, // Charmander
                    new PKM6 { Gift = true, Species = 7, Level = 10,}, // Squirtle
                }
            },
            new PokemonList
            {
                Text = "Fossils",
                List = new[]
                {
                    new PKM6 { Gift = true, Species = 138, Level = 20, }, // Omanyte
                    new PKM6 { Gift = true, Species = 140, Level = 20, }, // Kabuto
                    new PKM6 { Gift = true, Species = 142, Level = 20, }, // Aerodactyl
                    new PKM6 { Gift = true, Species = 345, Level = 20, }, // Lileep
                    new PKM6 { Gift = true, Species = 347, Level = 20, }, // Anorith
                    new PKM6 { Gift = true, Species = 408, Level = 20, }, // Cranidos
                    new PKM6 { Gift = true, Species = 410, Level = 20, }, // Shieldon
                    new PKM6 { Gift = true, Species = 564, Level = 20, }, // Tirtouga
                    new PKM6 { Gift = true, Species = 566, Level = 20, }, // Archen
                    new PKM6 { Gift = true, Species = 696, Level = 20, }, // Tyrunt
                    new PKM6 { Gift = true, Species = 698, Level = 20, }, // Amaura
                }
            },
        };
    }
}
