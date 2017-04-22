using System.Linq;

namespace Gen6RNGTool.RNG
{
    class RNGFilters
    {
        public bool[] Nature;
        public bool[] HPType;
        public bool ShinyOnly;
        public byte Ability;
        public byte Gender;
        public int[] IVup, IVlow, Stats;
        public byte PerfectIVs;
        public bool Skip;
        public byte Lv;
        public int[] BS;

        public bool CheckIVs(RNGResult result)
        {
            for (int i = 0; i < 6; i++)
                if (IVlow[i] > result.IVs[i] || result.IVs[i] > IVup[i])
                    return false;
            if (result.IVs.Count(e => e == 31) < PerfectIVs)
                return false;
            return true;
        }

        public int[] getStats(int[] IVs, int Nature, int Lv)
        {
            int[] Stats = new int[6];
            Stats[0] = (((BS[0] * 2 + IVs[0]) * Lv) / 100) + Lv + 10;
            for (int i = 1; i < 6; i++)
                Stats[i] = (((BS[i] * 2 + IVs[i]) * Lv) / 100) + 5;
            Pokemon.NatureAdjustment(Stats, Nature);
            return Stats;
        }

        public bool CheckStats(RNGResult result)
        {
            result.Stats = getStats(result.IVs, result.Nature, result.Lv);
            for (int i = 0; i < 6; i++)
                if (Stats[i] != 0 && Stats[i] != result.Stats[i])
                    return false;
            return true;
        }

        public bool CheckNature(int resultnature)
        {
            if (Nature.All(n => !n)) return true;
            return Nature[resultnature];
        }

        public bool CheckHiddenPower(RNGResult result)
        {
            var val = Pokemon.getHiddenPowerValue(result.IVs);
            result.hiddenpower = (byte)val;
            if (HPType.All(n => !n)) return true;
            return HPType[val];
        }

        public bool CheckResult(RNGResult result)
        {
            if (Skip)
                return true;
            if (ShinyOnly && !result.Shiny)
                return false;
            if (BS == null ? !CheckIVs(result) : !CheckStats(result))
                return false;
            if (!CheckHiddenPower(result))
                return false;
            if (!CheckNature(result.Nature))
                return false;
            if (Gender != 0 && Gender != result.Gender)
                return false;
            if (Ability != 0 && Ability != result.Ability)
                return false;

            return true;
        }
    }
}
