using System.Linq;

namespace Pk3DSRNGTool.Core
{
    public class RNGFilters
    {
        public bool[] Nature;
        public bool[] HPType;
        public bool ShinyOnly;
        public bool SquareShinyOnly;
        public byte Ability;
        public byte Gender;
        public int[] IVup, IVlow, Stats;
        public byte PerfectIVValue;
        public byte PerfectIVCount;
        public bool Skip;
        public int[] BS;

        public byte Level;
        public bool[] Slot;
        public bool SpecialOnly;

        public byte Ball;
        public byte NatureInheritance;

        private bool CheckIVs(RNGResult result)
        {
            for (int i = 0; i < 6; i++)
                if (IVlow[i] > result.IVs[i] || result.IVs[i] > IVup[i])
                    return false;
            if (result.IVs.Count(e => e >= PerfectIVValue) < PerfectIVCount)
                return false;
            return true;
        }

        private bool CheckStats(RNGResult result)
        {
            result.Stats = Pokemon.getStats(result.IVs, result.Nature, result.Level, BS);
            for (int i = 0; i < 6; i++)
                if (Stats[i] != 0 && Stats[i] != result.Stats[i])
                    return false;
            return true;
        }

        private bool CheckNature(int resultnature)
        {
            if (Nature.All(n => !n)) return true;
            return Nature[resultnature];
        }

        private bool CheckHiddenPower(RNGResult result)
        {
            var val = Pokemon.getHiddenPowerValue(result.IVs);
            result.hiddenpower = (byte)val;
            if (HPType.All(n => !n)) return true;
            return HPType[val];
        }

        private bool CheckSlot(int slot)
        {
            if (Slot.All(n => !n)) return true;
            return Slot[slot];
        }

        public bool CheckResult(RNGResult result)
        {
            if (!RNGResult.IsPokemon)
                return false;
            if (Skip)
            {
                result.hiddenpower = (byte)Pokemon.getHiddenPowerValue(result.IVs);
                if (BS != null) result.Stats = Pokemon.getStats(result.IVs, result.Nature, result.Level, BS);
                return true;
            }
            if (result is EggResult egg)
                 if (Ball != 0 && Ball != egg.Ball || 
                    NatureInheritance != 0 && (egg.BE_InheritParents == true ? 1 : 2) != NatureInheritance)
                    return false;
            if (ShinyOnly)
            {
                if (!result.Shiny)
                    return false;
                if (SquareShinyOnly && !result.SquareShiny)
                    return false;
            }
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
            
            if (result is WildResult wildresult)
            {
                if (Level != 0 && Level != result.Level)
                    return false;
                if (SpecialOnly && !wildresult.IsSpecial)
                    return false;
                if (!CheckSlot(wildresult.Slot))
                    return false;
            }

            return true;
        }

        public string[] SettingString()
        {
            return new[]
            {
                "Nature = " + string.Join(",", StringItem.naturestr.Where((str,i) => Nature[i])),
                "HiddenPower = " + string.Join(",", StringItem.hpstr.Where((str,i) => i > 0 && i < 17 && HPType[i - 1])),
                "ShinyOnly = " + (ShinyOnly ? "T": "F"),
                "Ability = " +  Ability.ToString(),
                "Gender = " +  Gender.ToString(),
                "IVup = " + string.Join(",", IVup),
                "IVlow = " + string.Join(",", IVlow),
                "Number of Perfect IVs = " +  PerfectIVCount.ToString(),
            };
        }
    }
}
