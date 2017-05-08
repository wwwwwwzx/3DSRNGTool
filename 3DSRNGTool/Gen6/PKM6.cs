namespace Pk3DSRNGTool
{
    public class PKM6 : Pokemon
    {
        public override GameVersion Version { get; protected set; } = GameVersion.Gen6;
        public override bool Syncable => !Gift || IV3 && !Egg; // Stationary encounter or undiscovered egg group non-egg gift

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

                    new PKM6 { Species = 381, Level = 30, Version = GameVersion.AS, }, // Latios
                    new PKM6 { Species = 380, Level = 30, Version = GameVersion.OR, }, // Latias

                    new PKM6 { Species = 382, Level = 45, ShinyLocked = true, Version = GameVersion.AS, Delay = 2700, Unstable = true, }, // Kyogre
                    new PKM6 { Species = 383, Level = 45, ShinyLocked = true, Version = GameVersion.OR, Delay = 2700, Unstable = true, }, // Groudon
                    new PKM6 { Species = 384, Level = 70, ShinyLocked = true, }, // Rayquaza
                    new PKM6 { Species = 386, Level = 80, ShinyLocked = true, Delay = 300, }, // Deoxys

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
                    new PKM6 { Species = 243, Level = 50, Delay = 16, }, // Raikou
                    new PKM6 { Species = 244, Level = 50, Delay = 16, }, // Entei
                    new PKM6 { Species = 245, Level = 50, Delay = 16, }, // Suicune

                    new PKM6 { Species = 249, Level = 50, Version = GameVersion.AS, Delay = 20, }, // Lugia
                    new PKM6 { Species = 250, Level = 50, Version = GameVersion.OR, Delay = 20, }, // Ho-oh
                }
            },
            new PokemonList
            {
                Text = "Sinnoh Legendary",
                List = new[]
                {
                    new PKM6 { Species = 480, Level = 50, Delay = 16, }, // Uxie
                    new PKM6 { Species = 481, Level = 50, Delay = 16, }, // Mesprit
                    new PKM6 { Species = 482, Level = 50, Delay = 16, }, // Azelf
            
                    new PKM6 { Species = 483, Level = 50, Delay = 88, Version = GameVersion.AS, }, // Dialga
                    new PKM6 { Species = 484, Level = 50, Delay = 88, Version = GameVersion.OR, }, // Palkia
                    
                    new PKM6 { Species = 485, Level = 50, Delay = 16, }, // Heatran
                    new PKM6 { Species = 486, Level = 50, }, // Regigigas
                    new PKM6 { Species = 487, Level = 50, Delay = 88, }, // Giratina
                    new PKM6 { Species = 488, Level = 50, Delay = 16, }, // Cresselia
                }
            },
            new PokemonList
            {
                Text = "Unova Legendary",
                List = new[]
                {
                    new PKM6 { Species = 638, Level = 50, Delay = 16, }, // Cobalion
                    new PKM6 { Species = 639, Level = 50, Delay = 16, }, // Terrakion
                    new PKM6 { Species = 640, Level = 50, Delay = 16, }, // Virizion

                    new PKM6 { Species = 641, Level = 50, Delay = 88, Version = GameVersion.OR, }, // Tornadus
                    new PKM6 { Species = 642, Level = 50, Delay = 88, Version = GameVersion.AS, }, // Thundurus
                    new PKM6 { Species = 645, Level = 50, Delay = 88, }, // Landorus
            
                    new PKM6 { Species = 643, Level = 50, Delay = 16, Version = GameVersion.OR, }, // Reshiram
                    new PKM6 { Species = 644, Level = 50, Delay = 16, Version = GameVersion.AS, }, // Zekrom
                    new PKM6 { Species = 646, Level = 50, Delay = 16, }, // Kyurem
                }
            },
            new PokemonList
            {
                Text = "Gift",
                List = new[]
                {
                    new PKM6 { Species = 360, Level = 1, Ability = 1, Gift = true, Egg = true,}, // Wynaut
                    new PKM6 { Species = 175, Level = 1, Ability = 1, Gift = true, Egg = true,}, // Togepi
                    new PKM6 { Species = 374, Level = 1, Ability = 1, Gift = true, IVs = new[] {-1, -1, 31, -1, 31, -1}, }, // Beldum

                    new PKM6 { Species = 351, Level = 30, Nature = 09, Ability = 1, Gift = true, IVs = new[] {-1, -1, -1, 31, -1, -1} }, // Castform
                    new PKM6 { Species = 319, Level = 40, Nature = 03, Ability = 1, Gift = true, Gender = 2, }, // Sharpedo
                    new PKM6 { Species = 323, Level = 40, Nature = 17, Ability = 1, Gift = true, Gender = 2, }, // Camerupt
                    new PKM6 { Species = 025, Level = 20, Form = 1, Ability = 4, Gender = 2, Gift = true, ShinyLocked = true }, // Pikachu
                }
            },
            new PokemonList
            {
                Text = "Normal Stationary",
                List = new[]
                {
                    new PKM6 { Species = 352, Level = 30, }, // Kecleon @ Route 120
                    new PKM6 { Species = 352, Level = 40, Gender = 2,}, // Kecleon @ Lavaridge
                    new PKM6 { Species = 352, Level = 45, Ability = 4,}, // Kecleon @ Mossdeeps
                    new PKM6 { Species = 101, Level = 40, Delay = 122, }, // Electrode @ Magma Hideout, Aqua Hideout
                    new PKM6 { Species = 100, Level = 20, Delay = 120, }, // Voltorb @ Route 119
                    new PKM6 { Species = 442, Level = 50, }, // Spiritomb @ Route 120
                }
            },
            new PokemonList
            {
                Text = "Starters",
                List = new[]
                {
                    new PKM6 { Gift = true, Species = 252, Level = 5, Delay = 186, }, // Treeko
                    new PKM6 { Gift = true, Species = 255, Level = 5, Delay = 138, }, // Torchic
                    new PKM6 { Gift = true, Species = 258, Level = 5, Delay = 138, }, // Mudkip
            
                    new PKM6 { Gift = true, Species = 152, Level = 5, Delay = 186, }, // Chikorita
                    new PKM6 { Gift = true, Species = 155, Level = 5, Delay = 138, }, // Cyndaquil
                    new PKM6 { Gift = true, Species = 158, Level = 5, Delay = 138, }, // Totodile

                    new PKM6 { Gift = true, Species = 387, Level = 5, Delay = 186, }, // Turtwig
                    new PKM6 { Gift = true, Species = 390, Level = 5, Delay = 138, }, // Chimchar
                    new PKM6 { Gift = true, Species = 393, Level = 5, Delay = 138, }, // Piplup

                    new PKM6 { Gift = true, Species = 495, Level = 5, Delay = 186, }, // Snivy
                    new PKM6 { Gift = true, Species = 498, Level = 5, Delay = 138, }, // Tepig
                    new PKM6 { Gift = true, Species = 501, Level = 5, Delay = 138, }, // Oshawott
                }
            },
            new PokemonList
            {
                Text = "Fossils",
                List = new[]
                {
                    new PKM6 { Gift = true, Species = 138, Level = 20, Delay = 80, }, // Omanyte
                    new PKM6 { Gift = true, Species = 140, Level = 20, Delay = 80, }, // Kabuto
                    new PKM6 { Gift = true, Species = 142, Level = 20, Delay = 80, }, // Aerodactyl
                    new PKM6 { Gift = true, Species = 345, Level = 20, Delay = 80, }, // Lileep
                    new PKM6 { Gift = true, Species = 347, Level = 20, Delay = 80, }, // Anorith
                    new PKM6 { Gift = true, Species = 408, Level = 20, Delay = 80, }, // Cranidos
                    new PKM6 { Gift = true, Species = 410, Level = 20, Delay = 80, }, // Shieldon
                    new PKM6 { Gift = true, Species = 564, Level = 20, Delay = 80, }, // Tirtouga
                    new PKM6 { Gift = true, Species = 566, Level = 20, Delay = 80, }, // Archen
                    new PKM6 { Gift = true, Species = 696, Level = 20, Delay = 80, }, // Tyrunt
                    new PKM6 { Gift = true, Species = 698, Level = 20, Delay = 80, }, // Amaura
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
                    new PKM6 { Gift = true, Species = 650, Level = 5, }, // Chespin
                    new PKM6 { Gift = true, Species = 653, Level = 5, }, // Fennekin
                    new PKM6 { Gift = true, Species = 656, Level = 5, }, // Froakie

                    new PKM6 { Gift = true, Species = 1, Level = 10, }, // Bulbasaur
                    new PKM6 { Gift = true, Species = 4, Level = 10, }, // Charmander
                    new PKM6 { Gift = true, Species = 7, Level = 10, }, // Squirtle
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
