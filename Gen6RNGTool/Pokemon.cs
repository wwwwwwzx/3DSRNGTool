using System.Linq;

namespace Gen6RNGTool
{
    class Pokemon : IPKM
    {
        public GameVersion Version = GameVersion.Any;
        public new byte Nature = 0xFF;
        public bool Gift;
        public bool Egg;
        public bool ShinyLocked;
        public bool Conceptual;
        //public bool Wild;
        //public byte Levelmin, Levelmax;

        #region Generated Attribute
        public int SpecForm => Species + (Form << 11);
        public bool AlwaysSync => Gift || Nature < 25;
        public bool IsEvent => Species == 151 && Conceptual;

        public override string ToString()
        {
            if (Conceptual)
                switch (Species)
                {
                    case 000: return "-";
                    case 151: return "Event";
                }
            if (Egg) return StringItem.species[Species] + " (" + StringItem.species[0] + ")";
            return StringItem.species[Species];
        }
        #endregion

        public class PokemonList
        {
            public string Text;
            public Pokemon[] List;
            public override string ToString() => Text;
        }

        public static Pokemon[] getSpecFormList(int Gameversion, int groupidx)
        {
            switch (Gameversion)
            {
                case 0: return Species_XY[groupidx].List.Where(s => s.Version.Contains(GameVersion.X)).ToArray();
                case 1: return Species_XY[groupidx].List.Where(s => s.Version.Contains(GameVersion.Y)).ToArray();
                case 2: return Species_ORAS[groupidx].List.Where(s => s.Version.Contains(GameVersion.OR)).ToArray();
                case 3: return Species_ORAS[groupidx].List.Where(s => s.Version.Contains(GameVersion.AS)).ToArray();
                default: return new Pokemon[0];
            }
        }

        public static PokemonList[] getCategoryList(int Gameversion)
        {
            switch (Gameversion)
            {
                case 0:
                case 1:
                    return Species_XY;
                case 2:
                case 3:
                    return Species_ORAS;
                default: return new PokemonList[0];
            }
        }

        #region tables (from PKHeX)
        public readonly static PokemonList Default = new PokemonList
        {
            Text = "-",
            List = new[]
            {
                new Pokemon { Conceptual = true, Species= 000, Level = 50, },
                new Pokemon { Conceptual = true, Species= 151, Level = 50, },
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
                    new Pokemon { Species = 380, Level = 30, Version = GameVersion.AS, Ability = 1, Gift = true, }, // Latias
                    new Pokemon { Species = 381, Level = 30, Version = GameVersion.OR, Ability = 1, Gift = true, }, // Latios

                    new Pokemon { Species = 381, Level = 30, Version = GameVersion.AS, }, // Latios
                    new Pokemon { Species = 380, Level = 30, Version = GameVersion.OR, }, // Latias

                    new Pokemon { Species = 382, Level = 45, ShinyLocked = true, Version = GameVersion.AS, }, // Kyogre
                    new Pokemon { Species = 383, Level = 45, ShinyLocked = true, Version = GameVersion.OR, }, // Groudon
                    new Pokemon { Species = 384, Level = 70, ShinyLocked = true, }, // Rayquaza
                    new Pokemon { Species = 386, Level = 80, ShinyLocked = true, }, // Deoxys

                    new Pokemon { Species = 377, Level = 40, }, // Regirock
                    new Pokemon { Species = 378, Level = 40, }, // Regice
                    new Pokemon { Species = 379, Level = 40, }, // Registeel
                }
            },
            new PokemonList
            {
                Text = "Johto Legendary",
                List = new[]
                {
                    new Pokemon { Species = 243, Level = 50, }, // Raikou
                    new Pokemon { Species = 244, Level = 50, }, // Entei
                    new Pokemon { Species = 245, Level = 50, }, // Suicune

                    new Pokemon { Species = 249, Level = 50, Version = GameVersion.AS, }, // Lugia
                    new Pokemon { Species = 250, Level = 50, Version = GameVersion.OR, }, // Ho-oh
                }
            },
            new PokemonList
            {
                Text = "Sinnoh Legendary",
                List = new[]
                {
                    new Pokemon { Species = 480, Level = 50, }, // Uxie
                    new Pokemon { Species = 481, Level = 50, }, // Mesprit
                    new Pokemon { Species = 482, Level = 50, }, // Azelf
            
                    new Pokemon { Species = 483, Level = 50, Version = GameVersion.AS, }, // Dialga
                    new Pokemon { Species = 484, Level = 50, Version = GameVersion.OR, }, // Palkia
                    
                    new Pokemon { Species = 485, Level = 50, }, // Heatran
                    new Pokemon { Species = 486, Level = 50, }, // Regigigas
                    new Pokemon { Species = 487, Level = 50, }, // Giratina
                    new Pokemon { Species = 488, Level = 50, }, // Cresselia
                }
            },
            new PokemonList
            {
                Text = "Unova Legendary",
                List = new[]
                {
                    new Pokemon { Species = 638, Level = 50, }, // Cobalion
                    new Pokemon { Species = 639, Level = 50, }, // Terrakion
                    new Pokemon { Species = 640, Level = 50, }, // Virizion

                    new Pokemon { Species = 641, Level = 50, Version = GameVersion.OR, }, // Tornadus
                    new Pokemon { Species = 642, Level = 50, Version = GameVersion.AS, }, // Thundurus
                    new Pokemon { Species = 645, Level = 50, }, // Landorus
            
                    new Pokemon { Species = 643, Level = 50, Version = GameVersion.OR, }, // Reshiram
                    new Pokemon { Species = 644, Level = 50, Version = GameVersion.AS, }, // Zekrom
                    new Pokemon { Species = 646, Level = 50, }, // Kyurem
                }
            },
            new PokemonList
            {
                Text = "Gift",
                List = new[]
                {
                    new Pokemon { Species = 360, Level = 1, Ability = 1, Gift = true, Egg = true,}, // Wynaut
                    new Pokemon { Species = 175, Level = 1, Ability = 1, Gift = true, Egg = true,}, // Togepi
                    new Pokemon { Species = 374, Level = 1, Ability = 1, IVs = new[] {-1, -1, 31, -1, -1, 31}, Gift = true }, // Beldum

                    new Pokemon { Species = 351, Level = 30, Nature = 09, Ability = 1, IVs = new[] {-1, -1, -1, -1, 31, -1}, Gift = true }, // Castform
                    new Pokemon { Species = 319, Level = 40, Gender = 1, Ability = 1, Nature = 03, Gift = true }, // Sharpedo
                    new Pokemon { Species = 323, Level = 40, Gender = 1, Ability = 1, Nature = 17, Gift = true }, // Camerupt
                    new Pokemon { Species = 025, Form = 1, Ability = 4, Gender = 2, Gift = true, ShinyLocked = true }, // Pikachu
                }
            },
            new PokemonList
            {
                Text = "Normal Stationary",
                List = new[]
                {
                    new Pokemon { Species = 352, Level = 30, }, // Kecleon @ Route 119
                    new Pokemon { Species = 101, Level = 40, }, // Electrode
                    new Pokemon { Species = 100, Level = 20, }, // Voltorb @ Route 119
                    new Pokemon { Species = 442, Level = 50, }, // Spiritomb @ Route 120
                }
            },
            new PokemonList
            {
                Text = "Starters",
                List = new[]
                {
                    new Pokemon { Gift = true, Species = 252, Level = 5, }, // Treeko
                    new Pokemon { Gift = true, Species = 255, Level = 5, }, // Torchic
                    new Pokemon { Gift = true, Species = 258, Level = 5, }, // Mudkip
            
                    new Pokemon { Gift = true, Species = 152, Level = 5, }, // Chikorita
                    new Pokemon { Gift = true, Species = 155, Level = 5, }, // Cyndaquil
                    new Pokemon { Gift = true, Species = 158, Level = 5, }, // Totodile

                    new Pokemon { Gift = true, Species = 387, Level = 5, }, // Turtwig
                    new Pokemon { Gift = true, Species = 390, Level = 5, }, // Chimchar
                    new Pokemon { Gift = true, Species = 393, Level = 5, }, // Piplup

                    new Pokemon { Gift = true, Species = 495, Level = 5, }, // Snivy
                    new Pokemon { Gift = true, Species = 498, Level = 5, }, // Tepig
                    new Pokemon { Gift = true, Species = 501, Level = 5, }, // Oshawott
                }
            },
            new PokemonList
            {
                Text = "Fossils",
                List = new[]
                {
                    new Pokemon { Gift = true, Species = 138, Level = 20, }, // Omanyte
                    new Pokemon { Gift = true, Species = 140, Level = 20, }, // Kabuto
                    new Pokemon { Gift = true, Species = 142, Level = 20, }, // Aerodactyl
                    new Pokemon { Gift = true, Species = 345, Level = 20, }, // Lileep
                    new Pokemon { Gift = true, Species = 347, Level = 20, }, // Anorith
                    new Pokemon { Gift = true, Species = 408, Level = 20, }, // Cranidos
                    new Pokemon { Gift = true, Species = 410, Level = 20, }, // Shieldon
                    new Pokemon { Gift = true, Species = 564, Level = 20, }, // Tirtouga
                    new Pokemon { Gift = true, Species = 566, Level = 20, }, // Archen
                    new Pokemon { Gift = true, Species = 696, Level = 20, }, // Tyrunt
                    new Pokemon { Gift = true, Species = 698, Level = 20, }, // Amaura
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
                    new Pokemon { Species = 716, Level = 50, ShinyLocked = true, Version = GameVersion.X, }, // Xerneas
                    new Pokemon { Species = 717, Level = 50, ShinyLocked = true, Version = GameVersion.Y, }, // Yveltal
                    new Pokemon { Species = 718, Level = 70, ShinyLocked = true }, // Zygarde

                    new Pokemon { Species = 150, Level = 70, ShinyLocked = true }, // Mewtwo

                    new Pokemon { Species = 144, Level = 70, ShinyLocked = true }, // Articuno
                    new Pokemon { Species = 145, Level = 70, ShinyLocked = true }, // Zapdos
                    new Pokemon { Species = 146, Level = 70, ShinyLocked = true }, // Moltres
                }
            },
            new PokemonList
            {
                Text = "Gift",
                List = new[]
                {
                    new Pokemon { Species = 448, Level = 32, Ability = 1, Nature = 11, Gender = 1, IVs = new[] {6, 25, 16, 31, 25, 19}, Gift = true, ShinyLocked = true }, // Lucario
                    new Pokemon { Species = 131, Level = 30, Nature = 6, IVs = new[] {31, 20, 20, 20, 20, 20}, Gift = true }, // Lapras
                }
            },
            new PokemonList
            {
                Text = "Normal Stationary",
                List = new[]
                {
                    new Pokemon { Species = 143, Level = 15,}, // Snorlax
                    //new Pokemon { Species = 568, Wild = true, Levelmin = 35, Levelmax = 38 }, // Trubbish
                    //new Pokemon { Species = 569, Wild = true, Levelmin = 46, Levelmax = 50 }, // Garbodor
                    //new Pokemon { Species = 354, Wild = true, Levelmin = 46, Levelmax = 50 }, // Banette
                    new Pokemon { Species = 479, Level = 38, }, // Rotom
                }
            },
            new PokemonList
            {
                Text = "Starters",
                List = new[]
                {
                    new Pokemon { Gift = true, Species = 650, Level = 5,}, // Chespin
                    new Pokemon { Gift = true, Species = 653, Level = 5,}, // Fennekin
                    new Pokemon { Gift = true, Species = 656, Level = 5,}, // Froakie

                    new Pokemon { Gift = true, Species = 1, Level = 10,}, // Bulbasaur
                    new Pokemon { Gift = true, Species = 4, Level = 10,}, // Charmander
                    new Pokemon { Gift = true, Species = 7, Level = 10,}, // Squirtle
                }
            },
            new PokemonList
            {
                Text = "Fossils",
                List = new[]
                {
                    new Pokemon { Gift = true, Species = 138, Level = 20, }, // Omanyte
                    new Pokemon { Gift = true, Species = 140, Level = 20, }, // Kabuto
                    new Pokemon { Gift = true, Species = 142, Level = 20, }, // Aerodactyl
                    new Pokemon { Gift = true, Species = 345, Level = 20, }, // Lileep
                    new Pokemon { Gift = true, Species = 347, Level = 20, }, // Anorith
                    new Pokemon { Gift = true, Species = 408, Level = 20, }, // Cranidos
                    new Pokemon { Gift = true, Species = 410, Level = 20, }, // Shieldon
                    new Pokemon { Gift = true, Species = 564, Level = 20, }, // Tirtouga
                    new Pokemon { Gift = true, Species = 566, Level = 20, }, // Archen
                    new Pokemon { Gift = true, Species = 696, Level = 20, }, // Tyrunt
                    new Pokemon { Gift = true, Species = 698, Level = 20, }, // Amaura
                }
            },
        };
        #endregion

        #region Formula
        public readonly static byte[] Reorder1 = { 1, 2, 5, 3, 4 };    // In-game index to Normal index
        public readonly static byte[] Reorder2 = { 0, 1, 2, 4, 5, 3 }; // Normal index to In-Game index

        public static void NatureAdjustment(int[] stats, int nature)
        {
            byte inc = Reorder1[nature / 5];
            byte dec = Reorder1[nature % 5];
            if (inc == dec)
                return;
            stats[inc] = (int)(1.1 * stats[inc]);
            stats[dec] = (int)(0.9 * stats[dec]);
        }

        public static int getHiddenPowerValue(int[] IVs)
        {
            return 15 * IVs.Select((iv, i) => (iv & 1) << Reorder2[i]).Sum() / 63;
        }

        public static int[] getStats(int[] IVs, int Nature, int Lv, int[] BS)
        {
            int[] Stats = new int[6];
            Stats[0] = (((BS[0] * 2 + IVs[0]) * Lv) / 100) + Lv + 10;
            for (int i = 1; i < 6; i++)
                Stats[i] = (((BS[i] * 2 + IVs[i]) * Lv) / 100) + 5;
            NatureAdjustment(Stats, Nature);
            return Stats;
        }
        #endregion
    }
}
