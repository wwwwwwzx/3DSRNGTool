using System.Linq;

namespace Gen6RNGTool
{
    class Pokemon
    {
        public ushort Species;
        public byte Form;
        public int[] IVs;
        public byte Level;
        public GameVersion Version = GameVersion.Any;
        public byte Gender;
        public byte Ability;
        public Nature Nature = Nature.Random;
        public bool Gift;
        public bool ShinyLocked;
        //public bool Wild;
        //public byte Levelmin, Levelmax;

        #region Generated Attribute
        public int SpecForm => Species + (Form << 11);
        public PKHeX.Core.PersonalInfo info => PersonalTable.ORAS.getFormeEntry(Species, Form);
        public bool AlwaysSync => Gift;
        public bool IV3 => info.EggGroups[0] == 0xF;
        public byte GenderRatio => (byte)(Gender > 0 ? 2 - 2 * Gender : info.Gender); // 1/2 => 0/254
        #endregion

        public static Pokemon[] getSpecFormList(int Gameversion)
        {
            switch (Gameversion)
            {
                case 0: return Species_XY.Where(s => s.Version.Contains(GameVersion.X)).ToArray();
                case 1: return Species_XY.Where(s => s.Version.Contains(GameVersion.Y)).ToArray();
                case 2: return Species_ORAS.Where(s => s.Version.Contains(GameVersion.OR)).ToArray();
                case 3: return Species_ORAS.Where(s => s.Version.Contains(GameVersion.AS)).ToArray();
                default: return new Pokemon[0];
            }
        }

        #region tables
        public readonly static Pokemon[] Species_ORAS =
        {
            // Starters and Fossil

            //new Pokemon { Species = 360, Level = 1, Ability = 1, Gift = true,}, // Wynaut
            //new Pokemon { Species = 175, Level = 1, Ability = 1, Gift = true,}, // Togepi
            //new Pokemon { Species = 374, Level = 1, Ability = 1, IVs = new[] {-1, -1, 31, -1, -1, 31}, Gift = true }, // Beldum

            //new Pokemon { Species = 351, Level = 30, Nature = Nature.Lax, Ability = 1, IVs = new[] {-1, -1, -1, -1, 31, -1}, Gift = true }, // Castform
            //new Pokemon { Species = 319, Level = 40, Gender = 1, Ability = 1, Nature = Nature.Adamant, Gift = true }, // Sharpedo
            //new Pokemon { Species = 323, Level = 40, Gender = 1, Ability = 1, Nature = Nature.Quiet, Gift = true }, // Camerupt
            //new Pokemon { Species = 352, Level = 30, }, // Kecleon @ Route 119
            //new Pokemon { Species = 101, Level = 40, }, // Electrode
            //new Pokemon { Species = 100, Level = 20, }, // Voltorb @ Route 119
            //new Pokemon { Species = 442, Level = 50, }, // Spiritomb @ Route 120

            new Pokemon { Species = 025, Form = 1, Ability = 4, Gender = 2, Gift = true, ShinyLocked = true }, // Pikachu
            
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
            new Pokemon { Species = 486, Level = 50, }, // Regigigas
            
            new Pokemon { Species = 249, Level = 50, Version = GameVersion.AS, }, // Lugia
            new Pokemon { Species = 250, Level = 50, Version = GameVersion.OR, }, // Ho-oh

            new Pokemon { Species = 483, Level = 50, Version = GameVersion.AS, }, // Dialga
            new Pokemon { Species = 484, Level = 50, Version = GameVersion.OR, }, // Palkia

            new Pokemon { Species = 644, Level = 50, Version = GameVersion.AS, }, // Zekrom
            new Pokemon { Species = 643, Level = 50, Version = GameVersion.OR, }, // Reshiram

            new Pokemon { Species = 642, Level = 50, Version = GameVersion.AS, }, // Thundurus
            new Pokemon { Species = 641, Level = 50, Version = GameVersion.OR, }, // Tornadus

            new Pokemon { Species = 485, Level = 50, }, // Heatran
            new Pokemon { Species = 487, Level = 50, }, // Giratina
            new Pokemon { Species = 488, Level = 50, }, // Cresselia
            new Pokemon { Species = 645, Level = 50, }, // Landorus
            new Pokemon { Species = 646, Level = 50, }, // Kyurem
            
            new Pokemon { Species = 243, Level = 50, }, // Raikou
            new Pokemon { Species = 244, Level = 50, }, // Entei
            new Pokemon { Species = 245, Level = 50, }, // Suicune

            new Pokemon { Species = 480, Level = 50, }, // Uxie
            new Pokemon { Species = 481, Level = 50, }, // Mesprit
            new Pokemon { Species = 482, Level = 50, }, // Azelf

            new Pokemon { Species = 638, Level = 50, }, // Cobalion
            new Pokemon { Species = 639, Level = 50, }, // Terrakion
            new Pokemon { Species = 640, Level = 50, }, // Virizion
        };

        public readonly static Pokemon[] Species_XY =
        {
            // Starters and Fossil

            //new Pokemon { Species = 448, Level = 32, Ability = 1, Nature = Nature.Hasty, Gender = 0, IVs = new[] {6, 25, 16, 31, 25, 19}, Gift = true, ShinyLocked = true }, // Lucario
            new Pokemon { Species = 131, Level = 30, Nature = Nature.Docile, IVs = new[] {31, 20, 20, 20, 20, 20}, Gift = true }, // Lapras
            
            //new Pokemon { Species = 143, Level = 15,}, // Snorlax
            //new Pokemon { Species = 568, Wild = true, Levelmin = 35, Levelmax = 38 }, // Trubbish
            //new Pokemon { Species = 569, Wild = true, Levelmin = 46, Levelmax = 50 }, // Garbodor
            //new Pokemon { Species = 354, Wild = true, Levelmin = 46, Levelmax = 50 }, // Banette
            //new Pokemon { Species = 479, Level = 38, }, // Rotom
            
            new Pokemon { Species = 716, Level = 50, ShinyLocked = true, Version = GameVersion.X, }, // Xerneas
            new Pokemon { Species = 717, Level = 50, ShinyLocked = true, Version = GameVersion.Y, }, // Yveltal
            new Pokemon { Species = 718, Level = 70, ShinyLocked = true }, // Zygarde
            new Pokemon { Species = 150, Level = 70, ShinyLocked = true }, // Mewtwo
            new Pokemon { Species = 144, Level = 70, ShinyLocked = true }, // Articuno
            new Pokemon { Species = 145, Level = 70, ShinyLocked = true }, // Zapdos
            new Pokemon { Species = 146, Level = 70, ShinyLocked = true }, // Moltres
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
        #endregion
    }

    public enum GameVersion
    {
        // Not actually stored values, but assigned as properties.
        Any = -1,

        // Version IDs, also stored in PKM structure
        /*Gen6*/
        X = 24, Y = 25, AS = 26, OR = 27,

        // Game Groupings (SaveFile type)
        XY = 106,
        ORAS = 108,
    }

    public static class Extension
    {
        public static bool Contains(this GameVersion g1, GameVersion g2)
        {
            if (g1 == g2 || g1 == GameVersion.Any)
                return true;

            switch (g1)
            {
                case GameVersion.XY: return g2 == GameVersion.X || g2 == GameVersion.Y;
                case GameVersion.ORAS: return g2 == GameVersion.OR || g2 == GameVersion.AS;
                default: return false;
            }
        }
    }
}
