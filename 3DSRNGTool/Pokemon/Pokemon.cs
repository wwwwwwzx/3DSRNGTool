using System.Linq;

namespace Pk3DSRNGTool
{
    public class Pokemon : IPKM
    {
        public override byte Nature { get; set; } = 0xFF;
        public bool Gift { get; protected set; }
        public bool Egg { get; protected set; }
        public bool Conceptual { get; protected set; }
        public bool Unstable { get; protected set; }
        public virtual bool ShinyLocked { get; protected set; }
        public virtual short Delay { get; protected set; }
        public virtual bool Syncable { get; protected set; } = true;

        #region Generated Attribute
        public int SpecForm => Species + (Forme << 11);
        public byte GenderRatio => (byte)(Gender > 0 ? 2 - 2 * Gender : info.Gender); // 1/2 => 0/254
        public bool IsRandomGender => FuncUtil.IsRandomGender(GenderRatio);
        public byte SettingGender => FuncUtil.getGenderRatio(GenderRatio);
        public virtual bool AlwaysSync => Gift || Nature < 25;

        public override string ToString()
        {
            if (Conceptual) return "-";
            if ((this as PKM6)?.PokemonLink ?? false)
            {
                if (Species == 154) return "Johto Starters";
                if (Species == 377) return "Legendary Titans";
            }
            if (Egg) return StringItem.species[Species] + " (" + StringItem.species[0] + ")";
            if (Unstable) return  StringItem.species[Species] + "(?)";
            switch (Species)
            {
                case 718: return StringItem.species[718] + (Forme == 1 ? "-10%" : "-50%");
                default: return StringItem.species[Species];
            }
        }
        #endregion

        public class PokemonList
        {
            public string Text;
            public Pokemon[] List;
            public override string ToString() => Text;
        }

        public static Pokemon[] getSpecFormList(int Gameversion, int groupidx, int method)
        {
            var list = getCategoryList(Gameversion, method)[groupidx].List;
            switch (Gameversion)
            {
                case 0: return list.Where(s => s.Version.Contains(GameVersion.X)).ToArray();
                case 1: return list.Where(s => s.Version.Contains(GameVersion.Y)).ToArray();
                case 2: return list.Where(s => s.Version.Contains(GameVersion.OR)).ToArray();
                case 3: return list.Where(s => s.Version.Contains(GameVersion.AS)).ToArray();
                case 4: return list.Where(s => s.Version.Contains(GameVersion.SN)).ToArray();
                case 5: return list.Where(s => s.Version.Contains(GameVersion.MN)).ToArray();
                case 6: return list.Where(s => s.Version.Contains(GameVersion.US)).ToArray();
                case 7: return list.Where(s => s.Version.Contains(GameVersion.UM)).ToArray();
                default: return new Pokemon[0];
            }
        }

        public readonly static PokemonList[] NotImpled = {
            new PokemonList
            {
                Text = "Not Impled",
                List = new[]{ new Pokemon { Conceptual = true, Species= 000, Level = 50, },}
            },
        };

        public static PokemonList[] getCategoryList(int Gameversion, int method)
        {
            switch (Gameversion)
            {
                case 0:
                case 1:
                    return method == 0 ? PKM6.Species_XY : PKMW6.Species_XY;
                case 2:
                case 3:
                    return method == 0 ? PKM6.Species_ORAS : PKMW6.Species_ORAS;
                case 4:
                case 5:
                    return method == 0 ? PKM7.Species_SM : PKMW7.Species_SM;
                default: return NotImpled;
            }
        }

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

        #region Formcount correction
        public static readonly int[] BattleForms =
        {
            351, // Castform
            421, // Cherrim
            555, // Darmanitan
            648, // Meloetta
            681, // Aegislash
            716, // Xerneas
            746, // Wishiwashi
            778, // Mimikyu

            // XY Mega
            3,6,9,65,80,
            115,127,130,142,150,181,
            212,214,229,248,282,
            303,306,308,310,354,359,380,381,
            445,448,460,

            // AO Mega
            15,18,94,
            208,254,257,260,
            302,319,323,334,362,373,376,384,
            428,475,
            531,
            719,

            // Primal
            382, 383,

            // Others
            492, // Shaymin
            647, // Keldeo
            676, // Furfrou
            720, // Hoopa
        };
        #endregion
    }
}
