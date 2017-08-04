namespace Pk3DSRNGTool
{
    public class PKM7 : Pokemon
    {
        public override GameVersion Version { get; protected set; } = GameVersion.Gen7;
        public override short Delay { get; protected set; }
        public byte NPC;
        public bool NoBlink;
        public bool IsPelago;

        public readonly static PokemonList Default = new PokemonList
        {
            Text = "-",
            List = new[]
            {
                new PKM7 { Conceptual = true, Species= 000, Level = 50, },
            }
        };

        public readonly static PokemonList[] Species_SM =
        {
            Default,
            new PokemonList
            {
                Text = "Legendary",
                List = new[]
                {
                   new PKM7 { Species = 785, Level = 60, ShinyLocked = true },              // Tapu Koko
                   new PKM7 { Species = 786, Level = 60, ShinyLocked = true },              // Tapu Lele
                   new PKM7 { Species = 787, Level = 60, ShinyLocked = true },              // Tapu Bulu
                   new PKM7 { Species = 788, Level = 60, ShinyLocked = true, NPC = 1, },    // Tapu Fini
                   new PKM7 { Species = 791, Level = 55, ShinyLocked = true, NPC = 6, Delay = 288, Version = GameVersion.SN, Unstable = true, },   // Solgaleo
                   new PKM7 { Species = 792, Level = 55, ShinyLocked = true, NPC = 6, Delay = 282, Version = GameVersion.MN, Unstable = true, },   // Lunala
                   new PKM7 { Species = 789, Level = 05, ShinyLocked = true, NPC = 3, Delay = 34, Gift = true},    // Cosmog
                   new PKM7 { Species = 772, Level = 40, NPC = 8, Delay = 34, Gift = true,},    // Type:Null
                   new PKM7 { Species = 801, Level = 50, ShinyLocked = true, NPC = 6, Delay = 34, Gift = true,},    // Magearna
                   new PKM7 { Species = 718, Level = 50, ShinyLocked = true, NPC = 3, Delay = 32, Gift = true, Forme = 1,},    // Zygarde-10%
                   new PKM7 { Species = 718, Level = 50, ShinyLocked = true, NPC = 3, Delay = 32, Gift = true, Forme = 0,},    // Zygarde-50%
                }
            },
            new PokemonList
            {
                Text = "In-Game Gift",
                List = new[]
                {
                    new PKM7 { Species = 142, Level = 40, NPC = 3, Delay = 34, Gift = true,},    // Aerodactyl
                    new PKM7 { Species = 137, Level = 30, NPC = 4, Delay = 34, Gift = true,},    // Porygon
                    new PKM7 { Species = 133, Level = 01, NPC = 5, Delay = 04, Gift = true, Syncable = false, Egg = true,},    // Gift Eevee Egg
                }
            },
            new PokemonList
            {
                Text = "Normal Stationary",
                List = new[]
                {
                    new PKM7 { Species = 739, NPC = 1, Delay = 04, NoBlink = true, },    // Crabrawler
                    new PKM7 { Species = 731, Level = 03, NPC = 1, Delay = 16, ShinyLocked = true, IVs = new[] { -1, -1, -1, -1, -1, 1 }, }, // Pikipek
                    new PKM7 { Species = 103, Level = 40, Forme = 1, Delay = 88, Unstable = true, },  // Exeggutor
                }
            },
            new PokemonList
            {
                Text = "Starters",
                List = new[]
                {
                    new PKM7 { Gift = true, Species = 722, Level = 5, Syncable = false, NPC = 5, Delay = 40, Unstable = true, }, // Rowlet
                    new PKM7 { Gift = true, Species = 725, Level = 5, Syncable = false, NPC = 5, Delay = 40, Unstable = true, }, // Litten
                    new PKM7 { Gift = true, Species = 728, Level = 5, Syncable = false, NPC = 5, Delay = 40, Unstable = true, }, // Popplio
                }
            },
            new PokemonList
            {
                Text = "Poke Pelago",
                List = new[]
                {
                    new PKM7 { Gift = true, IsPelago = true, Species = 021, Syncable = false, Delay = 8, }, // Spearow
                    new PKM7 { Gift = true, IsPelago = true, Species = 041, Syncable = false, Delay = 8, }, // Zubat
                    new PKM7 { Gift = true, IsPelago = true, Species = 090, Syncable = false, Delay = 8, }, // Shellder
                    new PKM7 { Gift = true, IsPelago = true, Species = 278, Syncable = false, Delay = 8, }, // Wingull
                    new PKM7 { Gift = true, IsPelago = true, Species = 731, Syncable = false, Delay = 8, }, // Pikipek

                    new PKM7 { Gift = true, IsPelago = true, Species = 064, Syncable = false, Delay = 8, }, // Kadabra
                    new PKM7 { Gift = true, IsPelago = true, Species = 081, Syncable = false, Delay = 8, }, // Magnemite
                    new PKM7 { Gift = true, IsPelago = true, Species = 092, Syncable = false, Delay = 8, }, // Gastly
                    new PKM7 { Gift = true, IsPelago = true, Species = 198, Syncable = false, Delay = 8, }, // Murkrow
                    new PKM7 { Gift = true, IsPelago = true, Species = 426, Syncable = false, Delay = 8, }, // Drifblim
                    new PKM7 { Gift = true, IsPelago = true, Species = 703, Syncable = false, Delay = 8, }, // Carbink

                    new PKM7 { Gift = true, IsPelago = true, Species = 060, Syncable = false, Delay = 8, }, // Poliwag
                    new PKM7 { Gift = true, IsPelago = true, Species = 120, Syncable = false, Delay = 8, }, // Staryu
                    new PKM7 { Gift = true, IsPelago = true, Species = 127, Syncable = false, Delay = 8, }, // Pinsir
                    new PKM7 { Gift = true, IsPelago = true, Species = 661, Syncable = false, Delay = 8, }, // Fletchling
                    new PKM7 { Gift = true, IsPelago = true, Species = 709, Syncable = false, Delay = 8, }, // Trevenant
                    new PKM7 { Gift = true, IsPelago = true, Species = 771, Syncable = false, Delay = 8, }, // Pyukumuku

                    new PKM7 { Gift = true, IsPelago = true, Species = 227, Syncable = false, Delay = 8, }, // Skarmory
                    new PKM7 { Gift = true, IsPelago = true, Species = 375, Syncable = false, Delay = 8, }, // Metang
                    new PKM7 { Gift = true, IsPelago = true, Species = 707, Syncable = false, Delay = 8, }, // Klefki

                    new PKM7 { Gift = true, IsPelago = true, Species = 123, Syncable = false, Delay = 8, }, // Scyther
                    new PKM7 { Gift = true, IsPelago = true, Species = 131, Syncable = false, Delay = 8, }, // Lapras
                    new PKM7 { Gift = true, IsPelago = true, Species = 429, Syncable = false, Delay = 8, }, // Mismagius
                    new PKM7 { Gift = true, IsPelago = true, Species = 587, Syncable = false, Delay = 8, }, // Emolga

                    new PKM7 { Gift = true, IsPelago = true, Species = 627, Syncable = false, Delay = 8, Version = GameVersion.SN, }, // Ruffle
                    new PKM7 { Gift = true, IsPelago = true, Species = 629, Syncable = false, Delay = 8, Version = GameVersion.MN, }, // Vullaby
                }
            },
            new PokemonList
            {
                Text = "Fossils",
                List = new[]
                {
                    new PKM7 { Gift = true, Species = 408, Level = 15, NPC = 1, Delay = 40, }, // Cranidos
                    new PKM7 { Gift = true, Species = 410, Level = 15, NPC = 1, Delay = 40, }, // Shieldon
                    new PKM7 { Gift = true, Species = 564, Level = 15, NPC = 1, Delay = 40, }, // Tirtouga
                    new PKM7 { Gift = true, Species = 566, Level = 15, NPC = 1, Delay = 40, }, // Archen
                    new PKM7 { Gift = true, Species = 138, Level = 15, NPC = 1, Delay = 40, }, // Omanyte
                    new PKM7 { Gift = true, Species = 140, Level = 15, NPC = 1, Delay = 40, }, // Kabuto
                    new PKM7 { Gift = true, Species = 142, Level = 15, NPC = 1, Delay = 40, }, // Aerodactyl
                    new PKM7 { Gift = true, Species = 345, Level = 15, NPC = 1, Delay = 40, }, // Lileep
                    new PKM7 { Gift = true, Species = 347, Level = 15, NPC = 1, Delay = 40, }, // Anorith
                    new PKM7 { Gift = true, Species = 696, Level = 15, NPC = 1, Delay = 40, }, // Tyrunt
                    new PKM7 { Gift = true, Species = 698, Level = 15, NPC = 1, Delay = 40, }, // Amaura
                }
            },
        };

    }
}
