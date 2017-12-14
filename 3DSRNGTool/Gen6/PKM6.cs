namespace Pk3DSRNGTool
{
    public class PKM6 : Pokemon
    {
        public override GameVersion Version { get; protected set; } = GameVersion.Gen6;
        public override bool Syncable => !Bank && (!Gift || IV3 && !Egg); // Stationary encounter or undiscovered egg group non-egg gift
        public override bool ShinyLocked { get => Bank || _ShinyLocked || OTTSV != null; protected set => _ShinyLocked = value; }
        public override bool AlwaysSync => base.AlwaysSync || Bank;

        public bool IsSoaring => Delay == 88; 
        public bool Bank; // Bank = PokemonLink or Transporter
        public byte NumOfPkm = 1; // number of Pokemon Generated
        public byte Cry = 0xFF; // Cry delay
        public bool InstantSync;
        private bool _ShinyLocked;

        public ushort? OTTSV; // In-game trade

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

                    new PKM6 { Species = 381, Level = 30, Version = GameVersion.AS, InstantSync = true, }, // Latios
                    new PKM6 { Species = 380, Level = 30, Version = GameVersion.OR, InstantSync = true, }, // Latias

                    new PKM6 { Species = 382, Level = 45, ShinyLocked = true, Version = GameVersion.AS, Delay = 3300, Unstable= true, }, // Kyogre
                    new PKM6 { Species = 383, Level = 45, ShinyLocked = true, Version = GameVersion.OR, Delay = 3300, Unstable= true, }, // Groudon
                    new PKM6 { Species = 384, Level = 70, ShinyLocked = true, InstantSync = true, }, // Rayquaza
                    new PKM6 { Species = 386, Level = 80, ShinyLocked = true, Delay = 300, Cry = 0, }, // Deoxys

                    new PKM6 { Species = 377, Level = 40, Delay = 158, Cry = 8, }, // Regirock
                    new PKM6 { Species = 378, Level = 40, Delay = 154, Cry = 8, }, // Regice
                    new PKM6 { Species = 379, Level = 40, Delay = 164, Cry = 8, }, // Registeel
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
                Text = "Pokemon Link",
                List = new[]
                {
                    new PKM6 { Bank = true, Species = 377, Level = 50, Delay = 16, Ability = 4, NumOfPkm = 3, }, // Legendary Titans 
                    new PKM6 { Bank = true, Species = 154, Level = 50, Delay = 16, Ability = 4, NumOfPkm = 3, }, // Johto Starters
                }
            },
            new PokemonList
            {
                Text = "In-Game Gift",
                List = new[]
                {
                    new PKM6 { Species = 360, Level = 1, Ability = 1, Gift = true, Egg = true,}, // Wynaut
                    new PKM6 { Species = 175, Level = 1, Ability = 1, Gift = true, Egg = true,}, // Togepi
                    new PKM6 { Species = 374, Level = 1, Ability = 1, Gift = true, IVs = new[] {-1, -1, 31, -1, 31, -1}, }, // Beldum

                    new PKM6 { Species = 351, Level = 30, Nature = 09, Ability = 1, Gift = true, Gender = 2, IVs = new[] {-1, -1, -1, 31, -1, -1} }, // Castform
                    new PKM6 { Species = 319, Level = 40, Nature = 03, Ability = 1, Gift = true, Gender = 2, }, // Sharpedo
                    new PKM6 { Species = 323, Level = 40, Nature = 17, Ability = 1, Gift = true, Gender = 2, }, // Camerupt
                    new PKM6 { Species = 025, Level = 20, Forme = 1, Ability = 4, Gender = 2, Gift = true, ShinyLocked = true }, // Pikachu
                }
            },
            new PokemonList
            {
                Text = "In-Game Trade",
                List = new[]
                {
                    new PKM6 { Species = 296, Level = 09, Ability = 2, Gender = 1, OTTSV = 1920, Nature = 02, IVs = new[] {-1, 31, -1, -1, -1, -1}, }, // Makuhita
                    new PKM6 { Species = 300, Level = 30, Ability = 1, Gender = 2, OTTSV = 0202, Nature = 04, IVs = new[] {-1, -1, -1, -1, -1, 31}, }, // Skitty
                    new PKM6 { Species = 222, Level = 50, Ability = 4, Gender = 2, OTTSV = 0020, Nature = 20, IVs = new[] {31, -1, -1, -1, 31, -1}, }, // Corsola
                }
            },
            new PokemonList
            {
                Text = "Normal Stationary",
                List = new[]
                {
                    new PKM6 { Species = 352, Level = 30, InstantSync = true, }, // Kecleon @ Route 120
                    new PKM6 { Species = 352, Level = 40, Gender = 2, InstantSync = true,}, // Kecleon @ Lavaridge
                    new PKM6 { Species = 352, Level = 45, Ability = 4, InstantSync = true, }, // Kecleon @ Mossdeeps
                    new PKM6 { Species = 101, Level = 40, Delay = 122, InstantSync = true, }, // Electrode @ Magma Hideout, Aqua Hideout
                    new PKM6 { Species = 100, Level = 20, Delay = 120, InstantSync = true, }, // Voltorb @ Route 119
                    new PKM6 { Species = 442, Level = 50, }, // Spiritomb @ Route 120
                    new PKM6 { Species = 265, Level = 03, Delay = 14, ShinyLocked = true, }, // Wurmple
                    new PKM6 { Species = 261, Level = 05, Delay = 8, }, // Poochyena (DexNav)
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
            
                    new PKM6 { Gift = true, Species = 152, Level = 5, }, // Chikorita
                    new PKM6 { Gift = true, Species = 155, Level = 5, }, // Cyndaquil
                    new PKM6 { Gift = true, Species = 158, Level = 5, }, // Totodile

                    new PKM6 { Gift = true, Species = 495, Level = 5, }, // Snivy
                    new PKM6 { Gift = true, Species = 498, Level = 5, }, // Tepig
                    new PKM6 { Gift = true, Species = 501, Level = 5, }, // Oshawott

                    new PKM6 { Gift = true, Species = 387, Level = 5, }, // Turtwig
                    new PKM6 { Gift = true, Species = 390, Level = 5, }, // Chimchar
                    new PKM6 { Gift = true, Species = 393, Level = 5, }, // Piplup
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
                    new PKM6 { Species = 716, Level = 50, Ability = 1, ShinyLocked = true, Delay = 158, Version = GameVersion.X, Cry = 0, }, // Xerneas
                    new PKM6 { Species = 717, Level = 50, Ability = 1, ShinyLocked = true, Delay = 208, Version = GameVersion.Y, Cry = 0, }, // Yveltal
                    new PKM6 { Species = 718, Level = 70, Ability = 1, ShinyLocked = true }, // Zygarde

                    new PKM6 { Species = 150, Level = 70, Ability = 1, ShinyLocked = true, Delay = 2, }, // Mewtwo

                    new PKM6 { Species = 144, Level = 70, Ability = 1, ShinyLocked = true, Delay = 114, }, // Articuno
                    new PKM6 { Species = 145, Level = 70, Ability = 1, ShinyLocked = true, Delay = 114, }, // Zapdos
                    new PKM6 { Species = 146, Level = 70, Ability = 1, ShinyLocked = true, Delay = 114, }, // Moltres
                }
            },
            new PokemonList
            {
                Text = "Pokemon Link",
                List = new[]
                {
                    new PKM6 { Bank = true, Species = 251, Level = 10, Delay = 16, Ability = 1, }, // Bank Celebi
                    new PKM6 { Bank = true, Species = 377, Level = 50, Delay = 16, Ability = 4, NumOfPkm = 3,}, // Legendary Titans
                    new PKM6 { Bank = true, Species = 154, Level = 50, Delay = 16, Ability = 4, NumOfPkm = 3,}, // Johto Starters
                }
            },
            new PokemonList
            {
                Text = "In-Game Gift",
                List = new[]
                {
                    new PKM6 { Species = 131, Level = 30, Ability = 1, Nature = 06, IVs = new[] {31, 20, 20, 20, 20, 20}, Gift = true, Delay = 18, }, // Lapras
                    new PKM6 { Species = 448, Level = 32, Ability = 1, Nature = 11, IVs = new[] {06, 25, 16, 25, 19, 31}, Gift = true, Delay = 20, ShinyLocked = true, Gender = 1, }, // Lucario
                }
            },
            new PokemonList
            {
                Text = "Normal Stationary",
                List = new[]
                {
                    new PKM6 { Species = 016, Level = 03, Ability = 1, Delay = 14, ShinyLocked = true, }, // Pidgey
                    new PKM6 { Species = 143, Level = 15, ShinyLocked = true, }, // Snorlax
                }
            },
            new PokemonList
            {
                Text = "Starters",
                List = new[]
                {
                    new PKM6 { Gift = true, Species = 650, Level = 5, Delay = 280, Unstable= true, }, // Chespin
                    new PKM6 { Gift = true, Species = 653, Level = 5, Delay = 280, Unstable= true, }, // Fennekin
                    new PKM6 { Gift = true, Species = 656, Level = 5, Delay = 330, Unstable= true, }, // Froakie

                    new PKM6 { Gift = true, Species = 1, Level = 10, Delay = 4,}, // Bulbasaur
                    new PKM6 { Gift = true, Species = 4, Level = 10, Delay = 4,}, // Charmander
                    new PKM6 { Gift = true, Species = 7, Level = 10, Delay = 4,}, // Squirtle
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
            new PokemonList
            {
                Text = "In-Game Trade",
                List = new[]
                {
                    new PKM6 { Species = 129, Level = 05, Ability = 1, Gender = 1, OTTSV = 2767, Nature = 03, }, // Magikarp
                    new PKM6 { Species = 133, Level = 05, Ability = 1, Gender = 2, OTTSV = 1830, Nature = 06, }, // Eevee

                    new PKM6 { Species = 083, Level = 10, Ability = 1, Gender = 1, OTTSV = 0011, Nature = 13, IVs = new[] {-1, -1, -1, -1, -1, 31}, }, // Farfetch'd
                    new PKM6 { Species = 208, Level = 20, Ability = 1, Gender = 2, OTTSV = 1203, Nature = 08, IVs = new[] {-1, -1, 31, -1, -1, -1}, }, // Steelix
                    new PKM6 { Species = 625, Level = 50, Ability = 1, Gender = 1, OTTSV = 0215, Nature = 03, IVs = new[] {-1, 31, -1, -1, -1, -1}, }, // Bisharp

                    // Starters from Shauna and Ralts have nothing to RNG
                    new PKM6 { Species = 656, Level = 5, Ability = 1, Gender = 1, OTTSV = 0002, Nature = 13, IVs = new[] {20, 20, 20, 20, 20, 31}, }, // Froakie
                    new PKM6 { Species = 650, Level = 5, Ability = 1, Gender = 1, OTTSV = 0002, Nature = 03, IVs = new[] {20, 31, 20, 20, 20, 20}, }, // Chespin
                    new PKM6 { Species = 653, Level = 5, Ability = 1, Gender = 1, OTTSV = 0002, Nature = 15, IVs = new[] {20, 20, 20, 31, 20, 20}, }, // Fennekin

                    new PKM6 { Species = 280, Level = 5, Ability = 1, Gender = 2, OTTSV = 2319, Nature = 15, IVs = new[] {20, 20, 20, 31, 20, 31}, }, // Ralts
                }
            },
            new PokemonList
            {
                Text = "Berry Tree",
                List = new[]
                {
                    new PKM6 { Species = 165, }, // Ledyba @ Red
                    new PKM6 { Species = 313, }, // Volbeat @ Blue
                    new PKM6 { Species = 314, }, // Illumise @ Purple
                    new PKM6 { Species = 412, }, // Burmy @ Green
                    new PKM6 { Species = 415, }, // Combee @ Yellow
                    new PKM6 { Species = 665, }, // Spewpa @ Pink
                }
            },
            new PokemonList
            {
                Text = "Cave Drop",
                List = new[]
                {
                   new PKM6 { Species = 527, Delay = 76 }, // Woobat
                   new PKM6 { Species = 597, Delay = 76 }, // Ferroseed
                   new PKM6 { Species = 168, Delay = 76 }, // Ariados
                   new PKM6 { Species = 714, Delay = 76 }, // Noibat
                   new PKM6 { Species = 075, Delay = 76 }, // Graveler
                }
            },
            new PokemonList
            {
                Text = "Rustling Bush",
                List = new[]
                {
                   new PKM6 { Species = 543, Delay = 54 }, // Venipede
                   new PKM6 { Species = 531, Delay = 54 }, // Audino
                   new PKM6 { Species = 632, Delay = 54 }, // Durant
                   new PKM6 { Species = 631, Delay = 54 }, // Heatmor
                }
            },
            new PokemonList
            {
                Text = "Trash Can",
                List = new[]
                {
                    new PKM6 { Species = 568, Delay = 18, Unstable = true, }, // Trubbish
                    new PKM6 { Species = 569, Delay = 18, Unstable = true, }, // Garbodor
                    new PKM6 { Species = 354, Delay = 18, Unstable = true, }, // Banette
                    new PKM6 { Species = 479, Delay = 18, Unstable = true, }, // Rotom
                }
            },
        };

        public readonly static PokemonList[] Species_VC =
        {
            new PokemonList
            {
                Text = "Poke Transporter",
                List = new[]
                {
                    new PKM6 { Bank = true, Species = 150, Ability = 4, NumOfPkm = 20, Conceptual = true, }, // Transporter 
                    new PKM6 { Bank = true, Species = 151, Ability = 1, NumOfPkm = 20, }, // Mew
                    new PKM6 { Bank = true, Species = 251, Ability = 1, NumOfPkm = 20, }, // Celebi
                }
            },
        };
    }
}
