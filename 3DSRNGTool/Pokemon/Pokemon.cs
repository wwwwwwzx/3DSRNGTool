using System.Linq;
using System.Collections.Generic;

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
                case 132 when Nature < 25:
                    return speciestr[132] + " (" + StringItem.naturestr[Nature] + ")";
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

        public static uint getTSV(uint RN) => ((RN >> 16) ^ (RN & 0xFFFF)) >> 4;
        #endregion

        #region Enums
        public const int electric = 12;
        public const int steel = 08;

        public readonly static HashSet<int> BattleForms = new HashSet<int>
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

            // USUM
            800, // Ultra Necrozma

            // Others
            492, // Shaymin
            647, // Keldeo
            676, // Furfrou
            720, // Hoopa
        };

        // For undiscovered egg group without 3 perfect ivs
        public readonly static HashSet<int> BabyMons = new HashSet<int>
        {
            030, 031,
            172, 173, 174, 175, 201, 236, 238, 239, 240,
            298, 360,
            406, 433, 438, 439, 440, 446, 447, 458
        };

        public readonly static HashSet<int> AlolanForms = new HashSet<int> { 019, 020, 026, 027, 028, 037, 038, 050, 051, 052, 053, 074, 075, 076, 088, 089, 103, 105, };

        private readonly static HashSet<int> AlolanDex_SM = new HashSet<int>
        {
            010, 011, 012, 021, 022, 025, 035, 036, 039, 040, 041, 042,
            046, 047, 054, 055, 056, 057, 058, 059, 060, 061, 062, 063,
            064, 065, 066, 067, 068, 072, 073, 079, 080, 081, 082, 090,
            091, 092, 093, 094, 096, 097, 102, 104, 113, 115, 118, 119,
            120, 121, 123, 125, 126, 127, 128, 129, 130, 131, 132, 133,
            134, 135, 136, 137, 142, 143, 147, 148, 149, 165, 166, 167,
            168, 169, 170, 171, 172, 173, 174, 185, 186, 196, 197, 198,
            199, 200, 209, 210, 212, 215, 222, 225, 227, 233, 235, 239,
            240, 241, 242, 278, 279, 283, 284, 296, 297, 299, 302, 318,
            319, 320, 321, 324, 327, 328, 329, 330, 339, 340, 349, 350,
            351, 359, 361, 362, 369, 370, 371, 372, 373, 374, 375, 376,
            408, 409, 410, 411, 422, 423, 425, 426, 429, 430, 438, 440,
            443, 444, 445, 446, 447, 448, 456, 457, 461, 462, 466, 467,
            470, 471, 474, 476, 478, 506, 507, 508, 524, 525, 526, 546,
            547, 548, 549, 551, 552, 553, 564, 565, 566, 567, 568, 569,
            582, 583, 584, 587, 594, 627, 628, 629, 630, 661, 662, 663,
            674, 675, 700, 703, 704, 705, 706, 707, 708, 709, 718, 000,
        };

        private readonly static HashSet<int> AlolanDex_USUM = new HashSet<int>
        {
            023, 024, 086, 087, 108, 122, 124, 138, 139, 140, 141, 163,
            164, 177, 178, 179, 180, 181, 190, 204, 205, 206, 207, 214,
            223, 224, 226, 228, 229, 238, 246, 247, 248, 309, 310, 341,
            342, 343, 344, 345, 346, 347, 348, 352, 353, 354, 357, 366,
            367, 368, 424, 427, 428, 439, 458, 463, 550, 559, 560, 570,
            571, 572, 573, 592, 593, 605, 606, 619, 620, 621, 622, 623,
            624, 625, 636, 637, 667, 668, 669, 670, 671, 676, 686, 687,
            690, 691, 692, 693, 696, 697, 698, 699, 701, 702, 714, 715,
        };

        public static bool InAlolanDex(int Species, bool IsUltra) => AlolanForms.Contains(Species) || AlolanDex_SM.Contains(Species) || IsUltra && AlolanDex_USUM.Contains(Species);
        #endregion
    }
}
