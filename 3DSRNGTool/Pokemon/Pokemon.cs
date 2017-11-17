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
        public bool IV3 => info.EggGroups[0] == 0xF && (Version.Contains(GameVersion.XY) || !BabyMons.Contains(Species));

        private static string[] speciestr => StringItem.speciestr;
        public override string ToString()
        {
            if (this is PKMW6 pmw6 && pmw6.IsFishing)
            {
                switch (pmw6.Type)
                {
                    case EncounterType.OldRod: return "Old Rod";
                    case EncounterType.GoodRod: return "Good Rod";
                    case EncounterType.SuperRod: return "Super Rod";
                }
            }
            if (Conceptual) return "-";
            if (this is PKM6 pm6 && pm6.Bank)
            {
                if (Species == 154) return "Johto Starters";
                if (Species == 377) return "Legendary Titans";
            }
            if (Egg) return speciestr[Species] + " (" + speciestr[0] + ")";
            if (Unstable) return speciestr[Species] + " (?)";
            switch (Species)
            {
                case 025 when this is PKM7 pm7 && pm7.Gift:
                    return speciestr[025] + (pm7.OTTSV == null ? " (Surf)" : " (Movie)");
                case 718 when Forme == 1 || Forme == 2:
                    return speciestr[718] + "-10%";
                case 718 when Forme == 3:
                    return speciestr[718] + "-50%";
                default: return speciestr[Species];
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
                case 4: return list;
                case 5: return list.Where(s => s.Version.Contains(GameVersion.SN)).ToArray();
                case 6: return list.Where(s => s.Version.Contains(GameVersion.MN)).ToArray();
                case 7: return list.Where(s => s.Version.Contains(GameVersion.US)).ToArray();
                case 8: return list.Where(s => s.Version.Contains(GameVersion.UM)).ToArray();
                default: return new Pokemon[0];
            }
        }

        public readonly static PokemonList[] NotImpled = {
            new PokemonList
            {
                Text = "None",
                List = new[]{ new Pokemon { Conceptual = true },}
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
                    return method == 0 ? PKM6.Species_VC : NotImpled;
                case 5:
                case 6:
                    return method == 0 ? PKM7.Species_SM : PKMW7.Species_SM;
                case 7:
                case 8:
                    return method == 0 ? PKM7.Species_USUM : PKMW7.Species_USUM;
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

        #region Enums
        public readonly static int[] BattleForms =
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

        // For undiscovered egg group without 3 perfect ivs
        public readonly static int[] BabyMons =
        {
            030, 031,
            172, 173, 174, 175, 201, 236, 238, 239, 240,
            298, 360,
            406, 433, 438, 439, 440, 446, 447, 458
        };

        public readonly static int[] AlolanForms = { 019, 020, 027, 037, 050, 051, 052, 074, 075, 088, 103, };
        #endregion
    }
}
