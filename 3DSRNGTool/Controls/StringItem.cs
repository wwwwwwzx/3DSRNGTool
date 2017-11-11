using System.Linq;
using Pk3DSRNGTool.Controls;

namespace Pk3DSRNGTool
{
    internal static class StringItem
    {
        public static string[] naturestr = new bool[25].Select(i => "").ToArray();
        public static string[] hpstr = new bool[18].Select(i => "").ToArray();
        public static string[] genderratio = new bool[7].Select(i => "").ToArray();

        public readonly static string[] genderstr = { "-", "♂", "♀" };
        public readonly static string[] abilitystr = { "-", "1", "2", "H" };
        public readonly static string[] eventabilitystr = { "1/2", "1/2/H" };
        public readonly static string[] helditemStr = { "50%", "5%", "1%", "---" };

        public readonly static string[] gen7wildtypestr = { "-", "UB", "QR" };

        public static string[] speciestr;
        public static string[] smlocation, gen6location;
        public static string[] items;

        public static ComboItem[] NatureList
            => naturestr.Select((str, i) => new ComboItem(str, i)).ToArray();

        public static ComboItem[] HiddenPowerList
            => hpstr.Skip(1).Take(16).Select((str, i) => new ComboItem(str, i)).ToArray();

        private readonly static byte[] genderratiodata = new byte[] { 0xFF, 0x7F, 0x1F, 0x3F, 0xBF, 0xE1, 0x00, 0xFE };

        public static ComboItem[] GenderRatioList
            => genderratio.Select((str, i) => new ComboItem(str, genderratiodata[i])).ToArray();

        public static string getlocationstr(int locationidx, int ver)
        {
            if (ver < 4)
                return gen6location[locationidx & 0x1FF] + LocationTable6.TableNow.FirstOrDefault(t => t.Locationidx == locationidx).mark;
            else if (4 < ver && ver < 9)
                return smlocation[locationidx & 0xFF] + LocationTable7.TableNow.FirstOrDefault(t => t.Locationidx == locationidx).mark;
            return "-";
        }

        private readonly static string[][] Translation_Table =
        {
            // Translation for category
            // en fr es zh
            new [] { "Legendary",           "Legendary",        "Legendary",        "定点传说" },
            new [] { "Starters",            "Starters",         "Starters",         "御三家" },
            new [] { "In-Game Gift",        "In-Game Gift",     "In-Game Gift",     "礼物" },
            new [] { "In-Game Trade",       "In-Game Trade",    "In-Game Trade",    "游戏内交换" },
            new [] { "Pokemon Link",        "Pokemon Link",     "Pokemon Link",     "宝可梦连接" },
            new [] { "Poke Transporter",    "Poke Transporter", "Poke Transporter", "宝可虚拟传送" },
            new [] { "Normal Stationary",   "Normal Stationary", "Normal Stationary", "普通定点" },
            new [] { "Fossils",             "Fossils",          "Fossils",          "复原化石" },
            new [] { "Kanto Legendary",     "Kanto Legendary",  "Kanto Legendary",  "关都传说" },
            new [] { "Johto Legendary",     "Johto Legendary",  "Johto Legendary",  "城都传说" },
            new [] { "Hoenn Legendary",     "Hoenn Legendary",  "Hoenn Legendary",  "丰缘传说" },
            new [] { "Sinnoh Legendary",    "Sinnoh Legendary", "Sinnoh Legendary", "神奥传说" },
            new [] { "Unova Legendary",     "Unova Legendary",  "Unova Legendary",  "合众传说" },
            new [] { "Kalos Legendary",     "Kalos Legendary",  "Kalos Legendary",  "卡洛斯传说" },
            new [] { "Alola Legendary",     "Alola Legendary",  "Alola Legendary",  "阿罗拉传说" },
            new [] { "Ultra Space Wilds",   "Ultra Space Wilds", "Ultra Space Wilds", "究极之洞" },
            new [] { "Totem",               "Totem",            "Totem",            "霸主" },
            new [] { "Island Scan",         "Island Scan",      "Island Scan",      "岛屿搜索" },
            new [] { "Normal Wild",         "Normal Wild",      "Normal Wild",      "普通野外" },
            new [] { "Berry Tree",          "Berry Tree",       "Berry Tree",       "果树" },
            new [] { "Cave Drop",           "Cave Drop",        "Cave Drop",        "洞窟坠物" },
            new [] { "Rustling Bush",       "Rustling Bush",    "Rustling Bush",    "晃动树影" },
            new [] { "Friend Safari",       "Friend Safari",    "Friend Safari",    "朋友狩猎区" },
            new [] { "Cave Shadows",        "Cave Shadows",     "Cave Shadows",     "洞窟阴影" },
            new [] { "Trap",                "Trap",             "Trap",             "沙尘" },
            new [] { "Poke Pelago",         "Poke Pelago",      "Poke Pelago",      "宝可度假地" },
            new [] { "Johto Starters",      "Johto Starters",   "Johto Starters",   "城都御三家" },
            new [] { "Legendary Titans",    "Legendary Titans", "Legendary Titans", "三神柱" },
            new [] { "Trash Can",           "Trash Can",        "Trash Can",        "垃圾桶" },
            new [] { "Rock Smash",          "Rock Smash",       "Rock Smash",       "碎岩" },
            new [] { "Horde",               "Horde",            "Horde",            "群战" },
            new [] { "Poke Radar",          "Poke Radar",       "Poke Radar",       "宝可雷达" },
            new [] { "Fishing",             "Fishing",          "Fishing",          "钓鱼" },
            new [] { "None",                "None",             "None",             "无" },
        };

        public static string Translate(string input, int language)
        {
            if (0 >= language || language >= Translation_Table[1].Length)
                return input;
            foreach (string[] a in Translation_Table)
                if (input == a[0])
                    return a[language];
            return input;
        }

        public static readonly string[,] GAMEVERSION_STR =
        {
            { "X", "Y", "OR", "AS", "Transporter", "Sun", "Moon", "Ultra Sun", "Ultra Moon" },
            { "X", "Y", "OR", "AS", "Transporter", "Soleil", "Lune", "Ultra Sun", "Ultra Moon" },
            { "X", "Y", "OR", "AS", "Transporter", "Sol", "Luna", "Ultra Sun", "Ultra Moon" },
            { "X", "Y", "红宝石", "蓝宝石", "虚拟传送", "太阳", "月亮", "究极之日", "究极之月" },
        };

        public static readonly string[] ANY_STR = { "Any", "Any", "Any", "任意" };
        public static readonly string[] NONE_STR = { "None", "None", "None", "无" };
        public static readonly string[] SETTINGERROR_STR = { "Error at ", "Error at ", "Error at ", "出错啦0.0 发生在" };
        public static readonly string[] NOSELECTION_STR = { "Please Select", "Please Select", "Please Select", "请选择" };
        public static readonly string[] FILEERRORSTR = { "Invalid file!", "Invalid file!", "Invalid file!", "文件格式不正确" };
        public static readonly string[] NORESULT_STR = { "No Result", "No Result", "No Result", "没有结果" };
        public static readonly string[] WAIT_STR = { "Please Wait...", "Please Wait...", "Please Wait...", "请稍后..." };
        public static readonly string[] INVALID_STR = { "Invalid Input", "Invalid Input", "Invalid Input", "输入格式不正确" };
        public static readonly string[,] PIDTYPE_STR =
        {
            { "Random", "Nonshiny", "Shiny", "Specified"},
            { "Random", "Nonshiny", "Shiny", "Specified"},
            { "Random", "Nonshiny", "Shiny", "Specified"},
            { "随机", "必不闪", "必闪", "特定"},
        };
        public static readonly string[,] PARENTS_STR =
        {
            { "-", "Male", "Female"},
            { "-", "Mâle", "Femelle"},
            { "-", "Macho", "Hembra"},
            { "-", "父方", "母方"},
        };
        public static readonly string[,] SYNC_STR =
        {
            { "Always Synced", "Can not be Synced" },
            { "Always Synced", "Can not be Synced" },
            { "Always Synced", "Can not be Synced" },
            { "必定同步", "不能同步" },
        };
        public static readonly string[,] EGGACCEPT_STR =
        {
            { "Accept", "Reject" },
            { "Accept", "Reject" },
            { "Accept", "Reject" },
            { "接受", "拒绝" },
        };
        public static readonly string[][] STATS_STR =
        {
            new string[] { "HP", "Atk", "Def", "SpA", "SpD", "Spe" },
            new string[] { "PV", "Attaque", "Defense", "Atq Spé", "Def Spé", "Vitesse" },
            new string[] { "PS", "Ata", "Def", "AtEsp", "DfEsp", "Vel" },
            new string[] { "HP", "攻击", "防御", "特攻", "特防", "速度" },
        };
        public static readonly string[][] IVJUDGE_STR =
        {
            new string[] { "Perfect", "Fantastic", "Very Good", "Pretty Good", "Decent", "No Good" },
            new string[] { "Perfect", "Fantastic", "Very Good", "Pretty Good", "Decent", "No Good" },
            new string[] { "Perfect", "Fantastic", "Very Good", "Pretty Good", "Decent", "No Good" },
            new string[] { "最棒", "了不起", "非常好", "相当好", "一般般", "也许不行" },
        };
        public static readonly string[][] COLUMN_STR =
        {
            new string[] { "Random Number", "Egg Seed", "Tiny State"},
            new string[] { "Random Number", "Egg Seed", "Tiny State"},
            new string[] { "Random Number", "Egg Seed", "Tiny State"},
            new string[] { "随机数", "蛋乱数种子","Tiny 状态" },
        };
    }
}