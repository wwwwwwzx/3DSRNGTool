using System.Linq;
using Pk3DSRNGTool.Controls;

namespace Pk3DSRNGTool
{
    internal static class StringItem
    {
        public static int language => Program.mainform.lindex;
        public static readonly string[] langlist = { "en", "ja", "fr", "de", "es", "zh" };
        public static string[] naturestr = new bool[25].Select(i => string.Empty).ToArray();
        public static string[] hpstr = new bool[18].Select(i => string.Empty).ToArray();
        public static string[] genderratio = new bool[7].Select(i => string.Empty).ToArray();

        public readonly static string[] genderstr = { "-", "♂", "♀" };
        public readonly static string[] abilitynumstr = { "-", "1", "2", "H" };
        public readonly static string[] eventabilitystr = { "1/2", "1/2/H" };
        public readonly static string[] helditemStr = { "50%", "5%", "1%", "---" };

        public readonly static string[] gen7wildtypestr = { "-", "UB", "QR", "XX" };

        public static string[] abilitystr;
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

        private readonly static int[] LeadAbilityIndex = { 000, 028, 056, 056, 009, 042, 014, 021, 046, };

        public static ComboItem[] LeadAbilityList
        {
            get
            {
                var list = LeadAbilityIndex.Select((t, i) => new ComboItem(abilitystr[t], i)).ToArray();
                list[2].Text += genderstr[1];
                list[3].Text += genderstr[2];
                list[7].Text += " | " + abilitystr[60]; // Suction cups|Sticky Hold
                list[8].Text += " | " + abilitystr[55] + " | " + abilitystr[72]; // Pressure|Hustle|Vital Spirit
                return list;
            }
        }

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
            // en ja fr de es zh
            new [] { "Legendary",           "伝説のポケモン",     "Légendaires",      "Legendäre",        "Legendario",       "定点传说" },
            new [] { "Starters",            "御三家",            "Starters",         "Starters",         "Starters",         "御三家" },
            new [] { "In-Game Gift",        "In-Game Gift",     "Cadeaux",          "In-Game Gift",     "In-Game Gift",     "礼物" },
            new [] { "In-Game Trade",       "In-Game Trade",    "Echanges en jeu",  "In-Game Trade",    "In-Game Trade",    "游戏内交换" },
            new [] { "Pokemon Link",        "ポケモンリンク",     "Pokemon Link",    "Pokémon-Link",     "Nexo Pokémon",     "宝可梦连接" },
            new [] { "Poke Transporter",    "ポケムーバー",      "Poke Transfert",   "PokeMover",        "Poké Trasladador", "宝可虚拟传送" },
            new [] { "Normal Stationary",   "Normal Stationary", "Fixes",           "Normal Stationary", "Normal Stationary", "普通定点" },
            new [] { "Fossils",             "カセキ",           "Fossiles",         "Fossils",           "Fósils",         "复原化石" },
            new [] { "Kanto Legendary",     "カントーの伝説",  "Kanto Légendaires", "Kanto Legendäre", "Kanto Legendario",  "关都传说" },
            new [] { "Johto Legendary",     "ジョウトの伝説",  "Johto Légendaires", "Johto Legendäre", "Johto Legendario",  "城都传说" },
            new [] { "Hoenn Legendary",     "ホウエンの伝説",  "Hoenn Légendaires", "Hoenn Legendäre", "Hoenn Legendario",  "丰缘传说" },
            new [] { "Sinnoh Legendary",    "シンオウの伝説", "Sinnoh Légendaires", "Sinnoh Legendäre", "Sinnoh Legendario", "神奥传说" },
            new [] { "Unova Legendary",     "イッシュの伝説",  "Unova Légendaires", "Unova Legendäre", "Unova Legendario",  "合众传说" },
            new [] { "Kalos Legendary",     "カロスの伝説",    "Kalos Légendaires", "Kalos Legendäre", "Kalos Legendario",  "卡洛斯传说" },
            new [] { "Alola Legendary",     "アローラの伝説",  "Alola Légendaires", "Alola Legendäre", "Alola Legendario",  "阿罗拉传说" },
            new [] { "Ultra Space Wilds",   "ウルトラホール", "Ultra-Dimension Sauvages", "Ultrapforte", "Ultraumbral",      "究极之洞" },
            new [] { "Totem",               "ぬしポケモン",      "Dominants",         "Herrscher",        "Dominante",       "霸主" },
            new [] { "Island Scan",         "QRスキャン",        "Scanner des îles", "nsel-Scanner",    "Escáner Insular",   "岛屿扫描" },
            new [] { "Normal Wild",         "Normal Wild",      "Normal Sauvage",   "Normal Wild",    "Normal Wild",        "普通野外" },
            new [] { "Berry Tree",          "Berry Tree",       "Arbre à baies",    "Berry Tree",       "Berry Tree",       "果树" },
            new [] { "Cave Drop",           "Cave Drop",        "Chutes (Grottes)", "Cave Drop",        "Cave Drop",        "洞窟坠物" },
            new [] { "Rustling Bush",       "Rustling Bush",    "Buisson",    "Rustling Bush",    "Rustling Bush",          "晃动树影" },
            new [] { "Friend Safari",       "フレンドサファリ",  "Safari des amis", "Kontaktsafari",    "Kontaktsafari",     "朋友狩猎区" },
            new [] { "Cave Shadows",        "Cave Shadows",     "Ombres (Grottes)",     "Cave Shadows",     "Cave Shadows", "洞窟阴影" },
            new [] { "Trap",                "Trap",             "Poussières",             "Trap",       "Trap",             "沙尘" },
            new [] { "Poke Pelago",         "ポケリゾート",      "Poké Loisir",      "Pokémon-Resort",   "Poké Resort",      "宝可度假地" },
            new [] { "Johto Starters",      "ジョウトの御三家",  "Johto Starters",   "Johto Starters",   "Johto Starters",   "城都御三家" },
            new [] { "Legendary Titans",    "伝説のゴーレム",    "Regis",            "Legendary Titans", "Legendary Titans", "三神柱" },
            new [] { "Trash Can",           "ゴミ箱",            "Poubelles",        "Mülleimer",        "Papelera",        "垃圾桶" },
            new [] { "Rock Smash",          "いわくだき",        "Eclat'roc",        "Zertrümmerer",     "Golpe Roca",       "碎岩" },
            new [] { "Horde",               "群れバトル",        "Horde",            "Massenbegegnungen","Horda",            "群战" },
            new [] { "Poke Radar",          "ポケトレ",          "Poke Radar",       "Pokéradar",        "Pokéradar",        "宝可雷达" },
            new [] { "Fishing",             "釣り",              "Pêche",           "Angeln",           "Pescar",          "钓鱼" },
            new [] { "None",                "なし",              "None",            "None",             "None",             "无" },
        };

        public static string Translate(string input)
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
            { "X", "Y", "ルビー", "サファイア", "ポケムーバー", "サン", "ムーン", "ウルトラサン", "ウルトラムーン" },
            { "X", "Y", "OR", "AS", "Transfert", "Soleil", "Lune", "Ultra-Soleil", "Ultra-Lune" },
            { "X", "Y", "OR", "AS", "PokeMover", "Sonne", "Mond", "Ultrasonne", "Ultramond" },
            { "X", "Y", "OR", "AS", "Trasladador", "Sol", "Luna", "Ultrasol", "Ultraluna" },
            { "X", "Y", "红宝石", "蓝宝石", "虚拟传送", "太阳", "月亮", "究极之日", "究极之月" },
        };

        public static readonly string[] ANY_STR = { "Any", "指定なし", "N'importe", "Any", "Any", "任意" };
        public static readonly string[] NONE_STR = { "None", "なし", "Aucun", "None", "None", "无" };
        public static readonly string[] SETTINGERROR_STR = { "Error at ", "Error at ", "Erreur", "Error at ", "Error at ", "出错啦0.0 发生在" };
        public static readonly string[] NOSELECTION_STR = { "Please Select", "選択されていません", "Choisissez", "Please Select", "Please Select", "请选择" };
        public static readonly string[] FILEERRORSTR = { "Invalid file!", "Invalid file!", "Fichier invalide", "Invalid file!", "Invalid file!", "文件格式不正确" };
        public static readonly string[] NORESULT_STR = { "No Result", "No Result", "Aucun résultat", "No Result", "No Result", "没有结果" };
        public static readonly string[] WAIT_STR = { "Please Wait...", "お待ちください...", "Patientez...", "Please Wait...", "Please Wait...", "请稍后..." };
        public static readonly string[] INVALID_STR = { "Invalid Input", "不正な値が含まれています", "Input invalide", "Invalid Input", "Invalid Input", "输入格式不正确" };
        public static readonly string[,] PIDTYPE_STR =
        {
            { "Random", "Nonshiny", "Shiny", "Specified"},
            { "Random", "Nonshiny", "Shiny", "Specified"},
            { "Hasard", "Non-shiny", "Shiny", "Spécifié"},
            { "Random", "Nonshiny", "Shiny", "Specified"},
            { "Random", "Nonshiny", "Shiny", "Specified"},
            { "随机", "必不闪", "必闪", "特定"},
        };
        public static readonly string[,] PARENTS_STR =
        {
            { "-", "Male", "Female"},
            { "-", "先親", "後親"},
            { "-", "Mâle", "Femelle"},
            { "-", "Männl.", "Weibl."},
            { "-", "Macho", "Hembra"},
            { "-", "父方", "母方"},
        };
        public static readonly string[,] SYNC_STR =
        {
            { "Always Synced", "Can not be Synced" },
            { "Always Synced", "Can not be Synced" },
            { "Synchro garanti", "Ne peut être Synchro" },
            { "Immer Synchro", "Can not be Synced" },
            { "Siempre Sincronizado", "Can not be Synced" },
            { "必定同步", "不能同步" },
        };
        public static readonly string[,] SHINY_STR =
        {
            { "Shiny Locked", "Forced Shiny" },
            { "Shiny Locked", "Forced Shiny" },
            { "Shiny Locké", "Shiny Forcé" },
            { "Shiny Sperre", "Forced Shiny" },
            { "Bloqueo Variocolor", "Forced Shiny" },
            { "必定不闪", "必定闪" },
        };
        public static readonly string[,] EGGACCEPT_STR =
        {
            { "Accept", "Reject" },
            { "受取", "拒否" },
            { "Accepter", "Rejeter" },
            { "Accept", "Reject" },
            { "Accept", "Reject" },
            { "接受", "拒绝" },
        };
        public static readonly string[][] STATS_STR =
        {
            new string[] { "HP", "Atk", "Def", "SpA", "SpD", "Spe" },
            new string[] { "HP", "攻撃", "防御", "特攻", "特防", "素早さ" },
            new string[] { "PV", "Attaque", "Defense", "Atq Spé", "Def Spé", "Vitesse" },
            new string[] { "KP", "Atk", "Def", "SpA", "SpD", "Spe" },
            new string[] { "PS", "Ata", "Def", "AtEsp", "DfEsp", "Vel" },
            new string[] { "HP", "攻击", "防御", "特攻", "特防", "速度" },
        };
        public static readonly string[][] IVJUDGE_STR =
        {
            new string[] { "Perfect", "Fantastic", "Very Good", "Pretty Good", "Decent", "No Good" },
            new string[] { "さいこう", "すばらしい", "すごくいい", "かなりいい", "まあまあ", "ダメかも" },
            new string[] { "Exceptionnel", "Fantastique", "Très bon", "Bon", "Passable", "Pas top" },
            new string[] { "Sensationell", "Fantastisch", "Sehr gut", "Gut", "Nicht übel", "Schlecht" },
            new string[] { "Inmejorable", "Espectacular", "Genial", "Notable", "No está mal", "Cojea un poco" },
            new string[] { "最棒", "了不起", "非常好", "相当好", "一般般", "也许不行" },
        };
        public static readonly string[][] COLUMN_STR =
        {
            new string[] { "Random Number", "Egg Seed", "Tiny State"},
            new string[] { "乱数列", "孵化用Seed", "Tiny State"},
            new string[] { "Nombre aléatoire", "Egg Seed", "Tiny State"},
            new string[] { "Random Number", "Egg Seed", "Tiny State"},
            new string[] { "Número Aleatorio", "Egg Seed", "Tiny State"},
            new string[] { "随机数", "蛋乱数种子","Tiny 状态" },
        };
        public static readonly string[] QR_STR =
        {
            "The last clock is at {0}F, you're at {1}F after quiting QR",
            "末尾の針の位置は {0} 番目, 次は {1} ",
            "La dernière horloge est à {0}F, vous êtes à {1}F après avoir fermé le QR",
            "The last clock is at {0}F, you're at {1}F after quiting QR",
            "The last clock is at {0}F, you're at {1}F after quiting QR",
            "最后的指针在 {0} 帧，退出QR后在 {1} 帧",
        };
        public static readonly string[] TIMER_STR =
        {
            "Set Eontimer for {0}",
            "設定するFrame(EmTimer) {0}",
            "Régler Eontimer pour {0}",
            "Set Eontimer for {0}",
            "Set Eontimer for {0}",
            "计时器设置为 {0}"
        };
        public static readonly string[] LOWEGGNUM_STR =
        {
            "Egg number is too small",
            "目標消費を小さく設定して下さい。",
            "Le nombre d'oeuf est trop petit",
            "Egg number is too small",
            "Egg number is too small",
            "蛋数范围太小",
        };
        public static readonly string[] ACCEPTEGGNUM_STR =
        {
            "Accept {0} eggs",
            "消費：{0} 回受け取り",
            "Acceptez {0} oeufs",
            "Accept {0} eggs",
            "Accept {0} eggs",
            "接受 {0} 个蛋",
        };
        public static readonly string[,] REJECTEGGNUM_STR =
        {
            {".\nReject {0} times",",\nand then reject {0} times" },
            {".\n{0} 回拒否する", ",\n{0} 回拒否する"},
            {".\nRejetez {0} fois",",\nand puis rejetez {0} fois" },
            {".\nReject {0} times",",\nand then reject {0} times" },
            {".\nReject {0} times",",\nand then reject {0} times" },
            {".\n拒绝 {0} 次", ",\n然后拒绝 {0} 次" },
        };
        public readonly static string[] FacilityName =
        {
            "Big Dream","Gold Rush","Treasure Hunt",
            "Ghosts Den","Trick Room","Confuse Ray",
            "Ball Shop","General Shop","Battle Shop","Soft Drink","Pharmacy",
            "Rare Kitchen","Battle Table", "Friendship Cafe", "Friendship Parlor",
            "Thump-Bump","Clink-Clunk","Stomp-Stomp",
            "Kanto Tent","Johto Tent","Hoenn Tent","Sinnoh Tent","Unova Tent","Kalos Tent","Pokemon House",
            "Team Red","Team Yellow","Team Green","Team Blue","Team Orange","Team NavyBlue","Team Purple","Team Pink",
            "Switcheroo",
        };
    }
}
