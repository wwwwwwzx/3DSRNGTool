namespace pkm3dsRNG
{
    public class PKM7 : Pokemon
    {
        public byte NPC;
        public short Delay;
        public bool NoBlink;

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
                   new PKM7 { Species = 791, Level = 55, ShinyLocked = true, NPC = 6, Delay = 288, Version = GameVersion.SN,},   // Solgaleo
                   new PKM7 { Species = 792, Level = 55, ShinyLocked = true, NPC = 6, Delay = 282, Version = GameVersion.MN,},   // Lunala
                   new PKM7 { Species = 789, Level = 05, ShinyLocked = true, NPC = 3, Delay = 34, Gift = true},    // Cosmog
                   new PKM7 { Species = 772, Level = 40, NPC = 8, Delay = 34, Gift = true,},    // Type:Null
                   new PKM7 { Species = 801, Level = 50, ShinyLocked = true, NPC = 6, Delay = 34, Gift = true,},    // Magearna
                   new PKM7 { Species = 718, Level = 50, ShinyLocked = true, NPC = 3, Delay = 32, Gift = true, Form = 1,},    // Zygarde-10%
                   new PKM7 { Species = 718, Level = 50, ShinyLocked = true, NPC = 3, Delay = 32, Gift = true, Form = 0,},    // Zygarde-50%
                }
            },
            new PokemonList
            {
                Text = "Gift",
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
                    new PKM7 { Species = 739, Level = 18, NPC = 1, Delay = 04, NoBlink = true, },    // Crabrawler
                    // new PKM7 { Species = 103, Level = 40, Form = 1, Delay = 88, },    // Exeggutor
                }
            },
            new PokemonList
            {
                Text = "Starters",
                List = new[]
                {
                    new PKM7 { Gift = true, Species = 722, Level = 5, Syncable = false, NPC = 5, Delay = 40, }, // Rowlet
                    new PKM7 { Gift = true, Species = 725, Level = 5, Syncable = false, NPC = 5, Delay = 40, }, // Litten
                    new PKM7 { Gift = true, Species = 728, Level = 5, Syncable = false, NPC = 5, Delay = 40, }, // Popplio
                }
            },
            new PokemonList
            {
                Text = "Fossils",
                List = new[]
                {
                    new PKM7 { Gift = true, Species = 138, Level = 20, NPC = 1, Delay = 40, }, // Omanyte
                    new PKM7 { Gift = true, Species = 140, Level = 20, NPC = 1, Delay = 40, }, // Kabuto
                    new PKM7 { Gift = true, Species = 142, Level = 20, NPC = 1, Delay = 40, }, // Aerodactyl
                    new PKM7 { Gift = true, Species = 345, Level = 20, NPC = 1, Delay = 40, }, // Lileep
                    new PKM7 { Gift = true, Species = 347, Level = 20, NPC = 1, Delay = 40, }, // Anorith
                    new PKM7 { Gift = true, Species = 408, Level = 20, NPC = 1, Delay = 40, }, // Cranidos
                    new PKM7 { Gift = true, Species = 410, Level = 20, NPC = 1, Delay = 40, }, // Shieldon
                    new PKM7 { Gift = true, Species = 564, Level = 20, NPC = 1, Delay = 40, }, // Tirtouga
                    new PKM7 { Gift = true, Species = 566, Level = 20, NPC = 1, Delay = 40, }, // Archen
                    new PKM7 { Gift = true, Species = 696, Level = 20, NPC = 1, Delay = 40, }, // Tyrunt
                    new PKM7 { Gift = true, Species = 698, Level = 20, NPC = 1, Delay = 40, }, // Amaura
                }
            },
        };

    }
}
