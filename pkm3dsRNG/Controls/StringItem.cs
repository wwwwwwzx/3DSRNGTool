using System.Linq;
using pkm3dsRNG.Controls;

namespace pkm3dsRNG
{
    class StringItem
    {
        public static string[] naturestr = new bool[25].Select(i => "").ToArray();
        public static string[] hpstr = new bool[18].Select(i => "").ToArray();
        public static string[] genderratio = new bool[7].Select(i => "").ToArray();

        public static string[] genderstr = { "-", "♂", "♀" };
        public static string[] abilitystr = { "-", "1", "2", "H" };
        public static string[] eventabilitystr = { "1/2", "1/2/H" };

        public static string[] gen7wildtypestr = { "-", "UB", "QR" };

        public static string[] species;
        public static string[] smlocation;
        public static string[] items;

        public static ComboItem[] NatureList
            => naturestr.Select((str, i) => new ComboItem(str, i)).ToArray();

        public static ComboItem[] HiddenPowerList
            => hpstr.Skip(1).Take(16).Select((str, i) => new ComboItem(str, i)).ToArray();

        private static byte[] genderratiodata = new byte[] { 0xFF, 0x7F, 0x1F, 0x3F, 0xBF, 0x00, 0xFE };

        public static ComboItem[] GenderRatioList
            => genderratio.Select((str, i) => new ComboItem(str, genderratiodata[i])).ToArray();

        public static string getSMlocationstr(int locationidx)
            => smlocation[locationidx & 0xFF] + LocationTable7.Table.FirstOrDefault(t => t.Locationidx == locationidx).mark;

        private static string[][] Translation =
        {
            new [] { "Legendary", "定点传说" },
            new [] { "Starters", "御三家" },
            new [] { "Gift", "礼物" },
            new [] { "Normal Stationary","普通定点" },
            new [] { "Fossils", "化石" },
            new [] { "Hoenn Legendary", "丰缘传说" },
            new [] { "Johto Legendary", "城都传说" },
            new [] { "Sinnoh Legendary", "神奥传说" },
            new [] { "Unova Legendary", "合众传说" },
            new [] { "Island Scan", "岛屿搜索" },
            new [] { "Normal Wild", "普通野外" },
        };

        public static string Translate(string input,int language)
        {
            if (0 >= language || language >= 2)
                return input;
            foreach (string[] a in Translation)
                if (input == a[0])
                    return a[language];
            return input;
        }
    }
}