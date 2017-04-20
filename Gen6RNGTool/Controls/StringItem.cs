using System.Linq;
using SMEncounterRNGTool.Controls;

namespace SMEncounterRNGTool
{
    class StringItem
    {
        public static string[] naturestr = new bool[25].Select(i => "").ToArray();
        public static string[] hpstr = new bool[18].Select(i => "").ToArray();

        public static string[] genderstr = { "-", "♂", "♀" };
        public static string[] abilitystr = { "-", "1", "2", "H" };

        public static ComboItem[] NatureList
            => naturestr.Select((str, i) => new ComboItem(str, i)).ToArray();

        public static ComboItem[] HiddenPowerList
            => hpstr.Skip(1).Take(16).Select((str, i) => new ComboItem(str, i)).ToArray();
    }
}