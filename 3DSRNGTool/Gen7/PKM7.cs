namespace Pk3DSRNGTool
{
    public class PKM7 : Pokemon
    {
        public override GameVersion Version { get; protected set; } = GameVersion.Gen7;
        public override short Delay { get; protected set; }
        public override bool ShinyLocked { get => _ShinyLocked ?? Totem || UltraWormhole || OTTSV != null; protected set => _ShinyLocked = value; }
        private bool? _ShinyLocked;
        public byte DelayType;
        public byte NPC;
        public bool IsPelago;
        public bool Raining;
        public bool Totem, UltraWormhole;
        public bool iv3 => Totem || UltraWormhole;
        public ushort? OTTSV;

        public readonly static PokemonList Default = new PokemonList
        {
            Text = "-",
            List = new[]
            {
                new PKM7 { Conceptual = true, Species= 000, Level = 50, },
            }
        };

        public readonly static PokemonList[] Species_USUM =
        {
            Default,
            new PokemonList
            {
                Text = "Alola Legendary",
                List = new[]
                {
                   new PKM7 { Species = 785, Level = 60, ShinyLocked = true },              // Tapu Koko
                   new PKM7 { Species = 786, Level = 60, ShinyLocked = true },              // Tapu Lele
                   new PKM7 { Species = 787, Level = 60, ShinyLocked = true },              // Tapu Bulu
                   new PKM7 { Species = 788, Level = 60, ShinyLocked = true, NPC = 1, },    // Tapu Fini
                   new PKM7 { Species = 789, Level = 05, ShinyLocked = true, NPC = 3, Delay = 20, Gift = true, Ability = 2, },    // Cosmog
                   
                   new PKM7 { Species = 791, Level = 60, ShinyLocked = true, NPC = 8, Delay = 166, DelayType = 09, Version = GameVersion.US, },   // Solgaleo
                   new PKM7 { Species = 792, Level = 60, ShinyLocked = true, NPC = 8, Delay = 160, DelayType = 10, Version = GameVersion.UM, },   // Lunala
                   new PKM7 { Species = 800, Level = 65, ShinyLocked = true, NPC = 2, },        // Necrozma

                   new PKM7 { Species = 793, Level = 60, NPC = 1, DelayType = 11, Delay = 134, },    // Nihilego
                   new PKM7 { Species = 794, Level = 60, NPC = 1, DelayType = 12, Delay = 178, Version = GameVersion.US,},    // Buzzwole
                   new PKM7 { Species = 795, Level = 60, NPC = 1, DelayType = 13, Delay = 150, Version = GameVersion.UM,},    // Pheromosa
                   new PKM7 { Species = 796, Level = 60, NPC = 1, DelayType = 14, Delay = 134, },    // Xurkitree
                   new PKM7 { Species = 797, Level = 60, NPC = 1, DelayType = 15, Delay = 186, Version = GameVersion.UM,},    // Celesteela
                   new PKM7 { Species = 798, Level = 60, NPC = 1, DelayType = 16, Delay = 130, Version = GameVersion.US,},    // Kartana
                   new PKM7 { Species = 799, Level = 60, NPC = 1, DelayType = 17, Delay = 124, },    // Guzzlord
                   
                   new PKM7 { Species = 772, Level = 60, NPC = 3, Delay = 20, Gift = true,},    // Type:Null
                   new PKM7 { Species = 801, Level = 50, NPC = 6, Delay = 20, Gift = true, ShinyLocked = true, Ability = 2, },    // Magearna
                   new PKM7 { Species = 803, Level = 40, NPC = 5, Delay = 20, Gift = true,},    // Poipole
                }
            },
            new PokemonList
            {
                Text = "Kanto Legendary",
                List = new[]
                {
                    new PKM7 { Species = 144, Level = 60, NPC = 1, Delay = 150, DelayType = 4, }, // Articuno
                    new PKM7 { Species = 145, Level = 60, NPC = 1, Delay = 151, DelayType = 4, }, // Zapdos
                    new PKM7 { Species = 146, Level = 60, NPC = 1, Delay = 150, DelayType = 4, }, // Moltres
                    new PKM7 { Species = 150, Level = 60, NPC = 1, Delay = 156, DelayType = 4, }, // Mewtwo
                }
            },
            new PokemonList
            {
                Text = "Johto Legendary",
                List = new[]
                {
                    new PKM7 { Species = 243, Level = 60, NPC = 1, Delay = 156, DelayType = 4, Version = GameVersion.US, }, // Raikou
                    new PKM7 { Species = 244, Level = 60, NPC = 1, Delay = 156, DelayType = 4, Version = GameVersion.UM, }, // Entei
                    new PKM7 { Species = 245, Level = 60, NPC = 1, Delay = 156, DelayType = 4, }, // Suicune

                    new PKM7 { Species = 249, Level = 60, NPC = 1, Delay = 156, DelayType = 4, Version = GameVersion.UM, }, // Lugia
                    new PKM7 { Species = 250, Level = 60, NPC = 1, Delay = 150, DelayType = 4, Version = GameVersion.US, }, // Ho-oh
                }
            },
            new PokemonList
            {
                Text = "Hoenn Legendary",
                List = new[]
                {
                    new PKM7 { Species = 377, Level = 60, NPC = 1, Delay = 156, DelayType = 4, }, // Regirock
                    new PKM7 { Species = 378, Level = 60, NPC = 1, Delay = 156, DelayType = 4, }, // Regice
                    new PKM7 { Species = 379, Level = 60, NPC = 1, Delay = 156, DelayType = 4, }, // Registeel

                    new PKM7 { Species = 380, Level = 60, NPC = 1, Delay = 156, DelayType = 4, Version = GameVersion.UM, }, // Latias
                    new PKM7 { Species = 381, Level = 60, NPC = 1, Delay = 156, DelayType = 4, Version = GameVersion.US, }, // Latios

                    new PKM7 { Species = 382, Level = 60, NPC = 1, Delay = 156, DelayType = 4, Version = GameVersion.UM, }, // Kyogre
                    new PKM7 { Species = 383, Level = 60, NPC = 1, Delay = 156, DelayType = 4, Version = GameVersion.US, }, // Groudon
                    new PKM7 { Species = 384, Level = 60, NPC = 0, Delay = 150, DelayType = 4, }, // Rayquaza
                }
            },
            new PokemonList
            {
                Text = "Sinnoh Legendary",
                List = new[]
                {
                    new PKM7 { Species = 480, Level = 60, NPC = 1, Delay = 156, DelayType = 4, }, // Uxie
                    new PKM7 { Species = 481, Level = 60, NPC = 1, Delay = 156, DelayType = 4, }, // Mesprit
                    new PKM7 { Species = 482, Level = 60, NPC = 1, Delay = 156, DelayType = 4, }, // Azelf
            
                    new PKM7 { Species = 483, Level = 60, NPC = 1, Delay = 156, DelayType = 4, Version = GameVersion.US, }, // Dialga
                    new PKM7 { Species = 484, Level = 60, NPC = 1, Delay = 156, DelayType = 4, Version = GameVersion.UM, }, // Palkia
                    
                    new PKM7 { Species = 485, Level = 60, NPC = 1, Delay = 156, DelayType = 4, Version = GameVersion.US, }, // Heatran
                    new PKM7 { Species = 486, Level = 60, NPC = 1, Delay = 156, DelayType = 4, Version = GameVersion.UM, }, // Regigigas
                    new PKM7 { Species = 487, Level = 60, NPC = 1, Delay = 156, DelayType = 4, }, // Giratina
                    new PKM7 { Species = 488, Level = 60, NPC = 1, Delay = 150, DelayType = 4, }, // Cresselia
                }
            },
            new PokemonList
            {
                Text = "Unova Legendary",
                List = new[]
                {
                    new PKM7 { Species = 638, Level = 60, NPC = 1, Delay = 156, DelayType = 4, }, // Cobalion
                    new PKM7 { Species = 639, Level = 60, NPC = 1, Delay = 156, DelayType = 4, }, // Terrakion
                    new PKM7 { Species = 640, Level = 60, NPC = 1, Delay = 156, DelayType = 4, }, // Virizion

                    new PKM7 { Species = 641, Level = 60, NPC = 1, Delay = 150, DelayType = 4, Version = GameVersion.US, }, // Tornadus
                    new PKM7 { Species = 642, Level = 60, NPC = 1, Delay = 150, DelayType = 4, Version = GameVersion.UM, }, // Thundurus
                    new PKM7 { Species = 645, Level = 60, NPC = 1, Delay = 150, DelayType = 4, }, // Landorus
            
                    new PKM7 { Species = 643, Level = 60, NPC = 1, Delay = 156, DelayType = 4, Version = GameVersion.US, }, // Reshiram
                    new PKM7 { Species = 644, Level = 60, NPC = 1, Delay = 156, DelayType = 4, Version = GameVersion.UM, }, // Zekrom
                    new PKM7 { Species = 646, Level = 60, NPC = 1, Delay = 156, DelayType = 4, }, // Kyurem
                }
            },
            new PokemonList
            {
                Text = "Kalos Legendary",
                List = new[]
                {
                    new PKM7 { Species = 716, Level = 60, NPC = 1, Delay = 156, DelayType = 4, Version = GameVersion.US, }, // Xerneas
                    new PKM7 { Species = 717, Level = 60, NPC = 1, Delay = 150, DelayType = 4, Version = GameVersion.UM, }, // Yveltal
                    new PKM7 { Species = 718, Level = 60, NPC = 1, ShinyLocked = true, }, // Zygarde
                    new PKM7 { Species = 718, Level = 63, NPC = 7, Delay = 020, ShinyLocked = true, Gift = true, Forme = 2,},    // Zygarde-10%
                    new PKM7 { Species = 718, Level = 50, NPC = 7, Delay = 022, ShinyLocked = true, Gift = true, Forme = 1,},    // Zygarde-10%
                    new PKM7 { Species = 718, Level = 50, NPC = 7, Delay = 022, ShinyLocked = true, Gift = true, Forme = 3,},    // Zygarde-50%
                }
            },
            new PokemonList
            {
                Text = "Ultra Space Wilds",
                List = new[]
                {
                    new PKM7 { Species = 334, Level = 60, UltraWormhole = true, NPC = 1, Delay = 94, DelayType = 4, Ability = 0xFF }, // Altaria
                    new PKM7 { Species = 469, Level = 60, UltraWormhole = true, NPC = 1, Delay = 94, DelayType = 4, Ability = 0xFF }, // Yanmega
                    new PKM7 { Species = 561, Level = 60, UltraWormhole = true, NPC = 1, Delay = 94, DelayType = 4, Ability = 0xFF }, // Sigilyph
                    new PKM7 { Species = 581, Level = 60, UltraWormhole = true, NPC = 1, Delay = 94, DelayType = 4, Ability = 0xFF }, // Swanna
                    new PKM7 { Species = 277, Level = 60, UltraWormhole = true, NPC = 1, Delay = 94, DelayType = 4, Ability = 0xFF }, // Swellow
                    new PKM7 { Species = 452, Level = 60, UltraWormhole = true, NPC = 1, Delay = 94, DelayType = 4, Ability = 0xFF }, // Drapion
                    new PKM7 { Species = 531, Level = 60, UltraWormhole = true, NPC = 1, Delay = 94, DelayType = 4, Ability = 0xFF }, // Audino
                    new PKM7 { Species = 695, Level = 60, UltraWormhole = true, NPC = 1, Delay = 94, DelayType = 4, Ability = 0xFF }, // Heliolisk
                    new PKM7 { Species = 274, Level = 60, UltraWormhole = true, NPC = 1, Delay = 94, DelayType = 4, Ability = 0xFF }, // Nuzleaf
                    new PKM7 { Species = 326, Level = 60, UltraWormhole = true, NPC = 1, Delay = 94, DelayType = 4, Ability = 0xFF }, // Grumpig
                    new PKM7 { Species = 460, Level = 60, UltraWormhole = true, NPC = 1, Delay = 94, DelayType = 4, Ability = 0xFF }, // Abomasnow
                    new PKM7 { Species = 308, Level = 60, UltraWormhole = true, NPC = 1, Delay = 94, DelayType = 4, Ability = 0xFF }, // Medicham
                    new PKM7 { Species = 450, Level = 60, UltraWormhole = true, NPC = 1, Delay = 94, DelayType = 4, Ability = 0xFF }, // Hippowdon
                    new PKM7 { Species = 558, Level = 60, UltraWormhole = true, NPC = 1, Delay = 94, DelayType = 4, Ability = 0xFF }, // Crustle
                    new PKM7 { Species = 219, Level = 60, UltraWormhole = true, NPC = 1, Delay = 94, DelayType = 4, Ability = 0xFF }, // Magcargo
                    new PKM7 { Species = 689, Level = 60, UltraWormhole = true, NPC = 1, Delay = 94, DelayType = 4, Ability = 0xFF }, // Barbaracle
                    new PKM7 { Species = 271, Level = 60, UltraWormhole = true, NPC = 1, Delay = 94, DelayType = 4, Ability = 0xFF }, // Lombre
                    new PKM7 { Species = 618, Level = 60, UltraWormhole = true, NPC = 1, Delay = 94, DelayType = 4, Ability = 0xFF }, // Stunfisk
                    new PKM7 { Species = 419, Level = 60, UltraWormhole = true, NPC = 1, Delay = 94, DelayType = 4, Ability = 0xFF }, // Floatzel
                    new PKM7 { Species = 195, Level = 60, UltraWormhole = true, NPC = 1, Delay = 94, DelayType = 4, Ability = 0xFF }, // Quagsire
                }
            },
            new PokemonList
            {
                Text = "Totem", // Totem-Sized Gifts @ Heahea Beach
                List = new[]
                {
                    new PKM7 { Gift = true, Species = 735, Level = 20, Ability = 4, Forme = 1, Totem = true, NPC = 7, Delay = 20, Version = GameVersion.US }, // Gumshoos
                    new PKM7 { Gift = true, Species = 020, Level = 20, Ability = 4, Forme = 2, Totem = true, NPC = 7, Delay = 20, Version = GameVersion.UM }, // Raticate
                    new PKM7 { Gift = true, Species = 105, Level = 25, Ability = 4, Forme = 2, Totem = true, NPC = 7, Delay = 20, Version = GameVersion.US }, // Marowak
                    new PKM7 { Gift = true, Species = 752, Level = 25, Ability = 1, Forme = 1, Totem = true, NPC = 7, Delay = 20, Version = GameVersion.UM }, // Araquanid
                    new PKM7 { Gift = true, Species = 754, Level = 30, Ability = 2, Forme = 1, Totem = true, NPC = 7, Delay = 20, Version = GameVersion.US }, // Lurantis
                    new PKM7 { Gift = true, Species = 758, Level = 30, Ability = 1, Forme = 1, Totem = true, NPC = 7, Delay = 20, Version = GameVersion.UM }, // Salazzle
                    new PKM7 { Gift = true, Species = 738, Level = 35, Ability = 1, Forme = 1, Totem = true, NPC = 7, Delay = 20, Version = GameVersion.US }, // Vikavolt
                    new PKM7 { Gift = true, Species = 777, Level = 35, Ability = 4, Forme = 1, Totem = true, NPC = 7, Delay = 20, Version = GameVersion.UM }, // Togedemaru
                    new PKM7 { Gift = true, Species = 778, Level = 40, Ability = 1, Forme = 2, Totem = true, NPC = 7, Delay = 20, },                          // Mimikyu
                    new PKM7 { Gift = true, Species = 743, Level = 50, Ability = 4, Forme = 1, Totem = true, NPC = 7, Delay = 20, Version = GameVersion.US }, // Ribombee
                    new PKM7 { Gift = true, Species = 784, Level = 50, Ability = 4, Forme = 1, Totem = true, NPC = 7, Delay = 20, Version = GameVersion.UM }, // Kommo-o
                }
            },
            new PokemonList
            {
                Text = "Starters",
                List = new[]
                {
                    new PKM7 { Gift = true, Species = 722, Level = 5, Syncable = false, NPC = 1, Delay = 20, }, // Rowlet
                    new PKM7 { Gift = true, Species = 725, Level = 5, Syncable = false, NPC = 1, Delay = 20, }, // Litten
                    new PKM7 { Gift = true, Species = 728, Level = 5, Syncable = false, NPC = 1, Delay = 20, }, // Popplio
                }
            },
            new PokemonList
            {
                Text = "Normal Stationary",
                List = new[]
                {
                    new PKM7 { Species = 736, Level = 04, NPC = 01, ShinyLocked = true, Delay = 12, }, // Grubbin
                    new PKM7 { Species = 092, Level = 19, ShinyLocked = true, Ability = 0xFF }, // Gastly @ Route 1 Trainers' School
                    new PKM7 { Species = 425, Level = 19, NPC = 02, ShinyLocked = true, Ability = 0xFF }, // Drifloon @ Route 1 Trainers' School
                    new PKM7 { Species = 760, Level = 28, NPC = 10, ShinyLocked = true, Ability = 0xFF }, // Bewear @ Hau'oli City
                    new PKM7 { Species = 097, Level = 29, NPC = 04, Delay = 102, ShinyLocked = true, Ability = 0xFF }, // Hypno @ Hau'oli City
                    new PKM7 { Species = 132, Level = 29, NPC = 02, IVs = new[] {-1,-1,31,30,-1,00}, Ability = 0xFF, Nature = 05, }, // Ditto @ Route 9
                    new PKM7 { Species = 132, Level = 29, NPC = 03, IVs = new[] {-1,-1,30,30,-1,31}, Ability = 0xFF, Nature = 13, }, // Ditto @ Konikoni City
                    new PKM7 { Species = 132, Level = 29, NPC = 06, IVs = new[] {-1,31,30,-1,-1,30}, Ability = 0xFF, Nature = 03, }, // Ditto @ Konikoni City
                    new PKM7 { Species = 132, Level = 29, NPC = 08, IVs = new[] {-1,00,-1,31,30,-1}, Ability = 0xFF, Nature = 15, }, // Ditto @ Konikoni City
                    new PKM7 { Species = 132, Level = 29, NPC = 01, IVs = new[] {-1,30,-1,-1,30,31}, Ability = 0xFF, Nature = 10, }, // Ditto @ Konikoni City
                    new PKM7 { Species = 592, Level = 34, NPC = 07, ShinyLocked = true, Ability = 0xFF, Gender = 2, Delay = -4, }, // Frillish @ Route 14
                    new PKM7 { Species = 769, Level = 30, NPC = 02, ShinyLocked = true, Ability = 0xFF, Version = GameVersion.UM, }, // Sandygast @ Route 15
                    new PKM7 { Species = 127, NPC = 5, Raining = true, ShinyLocked = true, Ability = 0xFF, Unstable = true},  // Pinsir
                    new PKM7 { Species = 101, Level = 60, Delay = 152, ShinyLocked = true, Unstable = true }, // Electrode @ Team Rocket's Castle
                }
            },
            new PokemonList
            {
                Text = "In-Game Gift",
                List = new[]
                {
                    new PKM7 { Species = 025, Level = 40, NPC = 02, Delay = 20, Gift = true, Totem = true, ShinyLocked = false, },    // Surf Pikachu (Totem flag for iv3)
                    new PKM7 { Species = 025, Level = 21, NPC = 15, Delay = 20, Gift = true, OTTSV = 1009, ShinyLocked = false, Nature = 0, Ability = 1, Gender = 1, }, // Moive Pikachu (forme omitted for correct ivs)
                    new PKM7 { Species = 137, Level = 30, NPC = 04, Delay = 20, Gift = true,},    // Porygon
                    new PKM7 { Species = 142, Level = 40, NPC = 03, Delay = 20, Gift = true,},    // Aerodactyl
                    new PKM7 { Species = 133, Level = 01, NPC = 06, Delay = 20, Gift = true, Syncable = false, Egg = true,},    // Gift Eevee Egg
                }
            },
            new PokemonList
            {
                Text = "Fossils",
                List = new[]
                {
                    new PKM7 { Gift = true, Species = 408, Level = 15, NPC = 1, Delay = 26, }, // Cranidos
                    new PKM7 { Gift = true, Species = 410, Level = 15, NPC = 1, Delay = 26, }, // Shieldon
                    new PKM7 { Gift = true, Species = 564, Level = 15, NPC = 1, Delay = 26, }, // Tirtouga
                    new PKM7 { Gift = true, Species = 566, Level = 15, NPC = 1, Delay = 26, }, // Archen
                    new PKM7 { Gift = true, Species = 138, Level = 15, NPC = 1, Delay = 26, }, // Omanyte
                    new PKM7 { Gift = true, Species = 140, Level = 15, NPC = 1, Delay = 26, }, // Kabuto
                    new PKM7 { Gift = true, Species = 142, Level = 15, NPC = 1, Delay = 26, }, // Aerodactyl
                    new PKM7 { Gift = true, Species = 345, Level = 15, NPC = 1, Delay = 26, }, // Lileep
                    new PKM7 { Gift = true, Species = 347, Level = 15, NPC = 1, Delay = 26, }, // Anorith
                    new PKM7 { Gift = true, Species = 696, Level = 15, NPC = 1, Delay = 26, }, // Tyrunt
                    new PKM7 { Gift = true, Species = 698, Level = 15, NPC = 1, Delay = 26, }, // Amaura
                }
            },
            new PokemonList
            {
                Text = "In-Game Trade",
                List = new[]
                {
                    new PKM7 { Species = 701, Level = 08, Ability = 2, OTTSV = 0025, IVs = new[] {-1,31,-1,-1,-1,-1}, Gender = 1, Nature = 02, Delay = 4, NPC = 7, }, // Hawlucha
                    new PKM7 { Species = 714, Level = 19, Ability = 1, OTTSV = 1292, IVs = new[] {-1,-1,-1,31,-1,-1}, Gender = 1, Nature = 15, Delay = 4, NPC = 8, }, // Noibat
                    new PKM7 { Species = 339, Level = 21, Ability = 2, OTTSV = 0068, IVs = new[] {31,-1,-1,-1,-1,-1}, Gender = 2, Nature = 04, Delay = 4, NPC = 6, }, // Barboach
                    new PKM7 { Species = 024, Level = 22, Ability = 1, OTTSV = 0682, IVs = new[] {-1,-1,31,-1,-1,-1}, Gender = 2, Nature = 08, Delay = 4, NPC = 9, }, // Arbok
                    new PKM7 { Species = 709, Level = 33, Ability = 1, OTTSV = 1298, IVs = new[] {-1,-1,-1,-1,31,-1}, Gender = 1, Nature = 20, Delay = 4, NPC = 8, }, // Phantump EvolveOnTrade
                    new PKM7 { Species = 422, Level = 44, Ability = 2, OTTSV = 1292, IVs = new[] {-1,-1,31,-1,-1,-1}, Gender = 2, Nature = 17, Delay = 4, NPC = 1, }, // Shellos
                    new PKM7 { Species = 128, Level = 59, Ability = 1, OTTSV = 3545, IVs = new[] {-1,-1,-1,-1,-1,31}, Gender = 1, Nature = 13, Delay = 4, NPC = 4, }, // Tauros
                }
            },
            new PokemonList
            {
                Text = "UB (First Encounter)",
                List = new[]
                {
                   new PKM7 { Species = 793, Level = 60, NPC = 1, DelayType = 21, Delay = 0702, },    // Nihilego
                   new PKM7 { Species = 794, Level = 60, NPC = 1, DelayType = 22, Delay = 1654, Version = GameVersion.US,},    // Buzzwole
                   new PKM7 { Species = 795, Level = 60, NPC = 1, DelayType = 23, Delay = 0150, Version = GameVersion.UM,},    // Pheromosa
                   new PKM7 { Species = 796, Level = 60, NPC = 1, DelayType = 24, Delay = 0958, },    // Xurkitree
                   new PKM7 { Species = 797, Level = 60, NPC = 1, DelayType = 25, Delay = 1170, Version = GameVersion.UM,},    // Celesteela
                   new PKM7 { Species = 798, Level = 60, NPC = 1, DelayType = 26, Delay = 1618, Version = GameVersion.US,},    // Kartana
                   new PKM7 { Species = 799, Level = 60, NPC = 1, DelayType = 27, Delay = 0968, },    // Guzzlord
                }
            },
            new PokemonList
            {
                Text = "Poke Pelago",
                List = new[]
                {
                    new PKM7 { Gift = true, IsPelago = true, Species = 731, Syncable = false, Delay = 8, }, // Pikipek
                    new PKM7 { Gift = true, IsPelago = true, Species = 278, Syncable = false, Delay = 8, }, // Wingull
                    new PKM7 { Gift = true, IsPelago = true, Species = 041, Syncable = false, Delay = 8, }, // Zubat
                    new PKM7 { Gift = true, IsPelago = true, Species = 742, Syncable = false, Delay = 8, }, // Cutiefly
                    new PKM7 { Gift = true, IsPelago = true, Species = 086, Syncable = false, Delay = 8, }, // Seel

                    new PKM7 { Gift = true, IsPelago = true, Species = 079, Syncable = false, Delay = 8, }, // Slowpoke
                    new PKM7 { Gift = true, IsPelago = true, Species = 120, Syncable = false, Delay = 8, }, // Staryu
                    new PKM7 { Gift = true, IsPelago = true, Species = 222, Syncable = false, Delay = 8, }, // Corsola
                    new PKM7 { Gift = true, IsPelago = true, Species = 122, Syncable = false, Delay = 8, }, // Mr. Mime
                    new PKM7 { Gift = true, IsPelago = true, Species = 180, Syncable = false, Delay = 8, }, // Flaaffy
                    new PKM7 { Gift = true, IsPelago = true, Species = 124, Syncable = false, Delay = 8, }, // Jynx

                    new PKM7 { Gift = true, IsPelago = true, Species = 127, Syncable = false, Delay = 8, }, // Pinsir
                    new PKM7 { Gift = true, IsPelago = true, Species = 177, Syncable = false, Delay = 8, }, // Natu
                    new PKM7 { Gift = true, IsPelago = true, Species = 764, Syncable = false, Delay = 8, }, // Comfey
                    new PKM7 { Gift = true, IsPelago = true, Species = 163, Syncable = false, Delay = 8, }, // Hoothoot
                    new PKM7 { Gift = true, IsPelago = true, Species = 771, Syncable = false, Delay = 8, }, // Pyukumuku
                    new PKM7 { Gift = true, IsPelago = true, Species = 701, Syncable = false, Delay = 8, }, // Hawlucha

                    new PKM7 { Gift = true, IsPelago = true, Species = 131, Syncable = false, Delay = 8, }, // Lapras
                    new PKM7 { Gift = true, IsPelago = true, Species = 354, Syncable = false, Delay = 8, }, // Banette
                    new PKM7 { Gift = true, IsPelago = true, Species = 200, Syncable = false, Delay = 8, }, // Misdreavus

                    new PKM7 { Gift = true, IsPelago = true, Species = 209, Syncable = false, Delay = 8, }, // Snubbull
                    new PKM7 { Gift = true, IsPelago = true, Species = 667, Syncable = false, Delay = 8, }, // Litleo
                    new PKM7 { Gift = true, IsPelago = true, Species = 357, Syncable = false, Delay = 8, }, // Tropius
                    new PKM7 { Gift = true, IsPelago = true, Species = 430, Syncable = false, Delay = 8, }, // Honchkrow

                    new PKM7 { Gift = true, IsPelago = true, Species = 228, Syncable = false, Delay = 8, Version = GameVersion.US, }, // Houndour
                    new PKM7 { Gift = true, IsPelago = true, Species = 309, Syncable = false, Delay = 8, Version = GameVersion.UM, }, // Electrike
                }
            },
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
                   new PKM7 { Species = 791, Level = 55, ShinyLocked = true, NPC = 6, Delay = 288, Version = GameVersion.SN, DelayType = 1, },   // Solgaleo
                   new PKM7 { Species = 792, Level = 55, ShinyLocked = true, NPC = 6, Delay = 282, Version = GameVersion.MN, DelayType = 2, },   // Lunala
                   new PKM7 { Species = 789, Level = 05, ShinyLocked = true, NPC = 3, Delay = 34, Gift = true, Ability = 2, },    // Cosmog
                   new PKM7 { Species = 772, Level = 40, NPC = 8, Delay = 34, Gift = true,},    // Type:Null
                   new PKM7 { Species = 801, Level = 50, ShinyLocked = true, NPC = 6, Delay = 34, Gift = true, Ability = 2, },    // Magearna
                   new PKM7 { Species = 718, Level = 50, ShinyLocked = true, NPC = 3, Delay = 32, Gift = true, Forme = 1,},    // Zygarde-10%
                   new PKM7 { Species = 718, Level = 50, ShinyLocked = true, NPC = 3, Delay = 32, Gift = true, Forme = 3,},    // Zygarde-50%
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
                    new PKM7 { Species = 731, Level = 03, NPC = 1, Delay = 16, ShinyLocked = true, IVs = new[] { -1, -1, -1, -1, -1, 1 }, }, // Pikipek
                    new PKM7 { Species = 103, Level = 40, Forme = 1, Delay = 88, Unstable = true, DelayType = 3, },  // Exeggutor
                }
            },
            new PokemonList
            {
                Text = "Starters",
                List = new[]
                {
                    new PKM7 { Gift = true, Species = 722, Level = 5, Syncable = false, NPC = 5, Delay = 40, DelayType = 05, }, // Rowlet
                    new PKM7 { Gift = true, Species = 725, Level = 5, Syncable = false, NPC = 5, Delay = 40, DelayType = 05, }, // Litten
                    new PKM7 { Gift = true, Species = 728, Level = 5, Syncable = false, NPC = 5, Delay = 40, DelayType = 05, }, // Popplio
                }
            },
            new PokemonList
            {
                Text = "In-Game Trade",
                List = new[]
                {
                    new PKM7 { Species = 066, Level = 09, Ability = 2, OTTSV = 0025, IVs = new[] {-1,31,-1,-1,-1,-1}, Gender = 1, Nature = 02, Delay = 4, NPC = 7, }, // Machop
                    new PKM7 { Species = 761, Level = 16, Ability = 1, OTTSV = 1292, IVs = new[] {-1,31,-1,-1,-1,-1}, Gender = 2, Nature = 03, Delay = 4, NPC = 6, }, // Bounsweet
                    new PKM7 { Species = 061, Level = 22, Ability = 2, OTTSV = 0068, IVs = new[] {31,-1,-1,-1,-1,-1}, Gender = 2, Nature = 04, Delay = 4, NPC = 6, }, // Poliwhirl
                    new PKM7 { Species = 440, Level = 27, Ability = 2, OTTSV = 0982, IVs = new[] {-1,-1,-1,31,-1,-1}, Gender = 2, Nature = 20, Delay = 4, NPC = 6, }, // Happiny
                    new PKM7 { Species = 076, Level = 32, Ability = 1, OTTSV = 1298, IVs = new[] {-1,-1,31,-1,-1,-1}, Gender = 1, Nature = 08, Delay = 4, NPC = 7, Forme = 1, }, // Graveler-1 * evloved
                    new PKM7 { Species = 762, Level = 43, Ability = 1, OTTSV = 1292, IVs = new[] {-1,-1,-1,-1,31,-1}, Gender = 2, Nature = 23, Delay = 4, NPC = 4, }, // Steenee
                    new PKM7 { Species = 663, Level = 59, Ability = 4, OTTSV = 3545, IVs = new[] {-1,-1,-1,-1,-1,31}, Gender = 1, Nature = 13, Delay = 4, NPC = 3, }, // Talonflame
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
