using System.Linq;

namespace pkm3dsRNG
{
    public class Pokemon : IPKM
    {
        public new byte Nature = 0xFF;
        public bool Gift;
        public bool Egg;
        public bool ShinyLocked;
        public bool Syncable = true;
        public bool Conceptual;

        #region Generated Attribute
        public int SpecForm => Species + (Form << 11);
        public bool AlwaysSync => Gift || Nature < 25;
        public bool IsEvent => Species == 151 && Conceptual;

        public override string ToString()
        {
            if (Conceptual) return "-";
            if (Egg) return StringItem.species[Species] + " (" + StringItem.species[0] + ")";
            switch (Species)
            {
                case 718: return StringItem.species[718] + (Form == 1 ? "-10%" : "-50%");
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

        public static Pokemon[] getSpecFormList(int Gameversion, int groupidx)
        {
            switch (Gameversion)
            {
                case 0: return PKM6.Species_XY[groupidx].List.Where(s => s.Version.Contains(GameVersion.X)).ToArray();
                case 1: return PKM6.Species_XY[groupidx].List.Where(s => s.Version.Contains(GameVersion.Y)).ToArray();
                case 2: return PKM6.Species_ORAS[groupidx].List.Where(s => s.Version.Contains(GameVersion.OR)).ToArray();
                case 3: return PKM6.Species_ORAS[groupidx].List.Where(s => s.Version.Contains(GameVersion.AS)).ToArray();
                case 4: return PKM7.Species_SM[groupidx].List.Where(s => s.Version.Contains(GameVersion.SN)).ToArray();
                case 5: return PKM7.Species_SM[groupidx].List.Where(s => s.Version.Contains(GameVersion.MN)).ToArray();
                default: return new Pokemon[0];
            }
        }

        public static PokemonList[] getCategoryList(int Gameversion)
        {
            switch (Gameversion)
            {
                case 0:
                case 1:
                    return PKM6.Species_XY;
                case 2:
                case 3:
                    return PKM6.Species_ORAS;
                case 4:
                case 5:
                    return PKM7.Species_SM;
                default: return new PokemonList[0];
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
    }
}
