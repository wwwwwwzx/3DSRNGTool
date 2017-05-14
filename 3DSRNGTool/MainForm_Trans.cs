using System;
using System.Linq;
using System.Windows.Forms;
using static PKHeX.Util;

namespace Pk3DSRNGTool
{
    public partial class MainForm : Form
    {
        private static readonly string[] ANY_STR = { "Any", "任意" };
        private static readonly string[] NONE_STR = { "None", "无" };
        private static readonly string[] SETTINGERROR_STR = { "Error at ", "出错啦0.0 发生在" };
        private static readonly string[] NORESULT_STR = { "No Result", "没有结果" };
        private static readonly string[] WAIT_STR = { "Please Wait...", "请稍后..." };
        private static readonly string[] NOSELECTION_STR = { "Please Select", "请选择" };
        private static readonly string[] FILEERRORSTR = { "Invalid file!", "文件格式不正确" };
        private static readonly string[,] PIDTYPE_STR =
        {
            { "Random", "Nonshiny", "Shiny", "Specified"},
            { "随机", "必不闪", "必闪", "特定"},
        };
        private static readonly string[,] PARENTS_STR =
        {
            { "-", "Male", "Female"},
            { "-", "父方", "母方"},
        };
        private static readonly string[,] GAMEVERSION_STR =
        {
            { "X", "Y", "OR", "AS", "Sun", "Moon" },
            { "X", "Y", "红宝石", "蓝宝石", "太阳", "月亮" },
        };
        private static readonly string[,] SYNC_STR =
        {
            { "Always Synced", "Can not be Synced" },
            { "必定同步", "不能同步" },
        };
        private static readonly string[,] EGGACCEPT_STR =
        {
            { "Accecpt", "Reject" },
            { "接受", "拒绝" },
        };
        private static readonly string[][] STATS_STR =
        {
            new string[] { "HP", "Atk", "Def", "SpA", "SpD", "Spe" },
            new string[] { "HP", "攻击", "防御", "特攻", "特防", "速度" },
        };

        private static readonly string[][] IVJUDGE_STR =
        {
            new string[] { "Perfect", "Fantastic", "Very Good", "Pretty Good", "Decent", "No Good" },
            new string[] { "最棒", "了不起", "非常好", "相当好", "一般般", "也许不行" },
        };

        private string curlanguage;

        private int lindex { get { return Lang.SelectedIndex; } set { Lang.SelectedIndex = value; } }
        private static readonly string[] langlist = { "en", "cn" };

        private void ChangeLanguage(object sender, EventArgs e)
        {
            string lang = langlist[lindex];

            if (lang == curlanguage)
                return;

            curlanguage = lang;
            TranslateInterface(this, curlanguage); // Translate the UI to language.
            Properties.Settings.Default.Language = curlanguage;
            Properties.Settings.Default.Save();
            TranslateInterface(this, lang);
            Text = Text + $" v{version}";

            StringItem.naturestr = getStringList("Natures", curlanguage);
            StringItem.hpstr = getStringList("Types", curlanguage);
            StringItem.species = getStringList("Species", curlanguage);
            StringItem.items = getStringList("Items", curlanguage);
            StringItem.genderratio = getStringList("Genderratio", curlanguage);
            StringItem.smlocation = getStringList("Location_sm", curlanguage);
            StringItem.gen6location = getStringList("Location_xy", curlanguage);

            for (int i = 0; i < 4; i++)
                Event_PIDType.Items[i] = PIDTYPE_STR[lindex, i];

            for (int i = 0; i < 3; i++)
                Ball.Items[i] = PARENTS_STR[lindex, i];

            for (int i = 0; i < 6; i++)
                Gameversion.Items[i] = GAMEVERSION_STR[lindex, i];

            IVInputer.Translate(IVJUDGE_STR[lindex], STATS_STR[lindex]);

            RefreshCategory();
            if (method == 2)
                RefreshLocation();

            Nature.Items.Clear();
            Nature.BlankText = ANY_STR[lindex];
            Nature.Items.AddRange(StringItem.NatureList);

            SyncNature.Items[0] = NONE_STR[lindex];
            for (int i = 0; i < StringItem.naturestr.Length; i++)
                Event_Nature.Items[i] = SyncNature.Items[i + 1] = StringItem.naturestr[i];

            for (int i = 0; i < StringItem.items.Length; i++)
                M_Items.Items[i] = F_Items.Items[i] = StringItem.items[i];

            HiddenPower.Items.Clear();
            HiddenPower.BlankText = ANY_STR[lindex];
            HiddenPower.Items.AddRange(StringItem.HiddenPowerList);

            GenderRatio.ValueMember = "Value";
            GenderRatio.DisplayMember = "Text";
            GenderRatio.DataSource = new BindingSource(StringItem.GenderRatioList, null);
            GenderRatio.SelectedIndex = 0;

            Egg_GenderRatio.ValueMember = "Value";
            Egg_GenderRatio.DisplayMember = "Text";
            Egg_GenderRatio.DataSource = new BindingSource(StringItem.GenderRatioList, null);
            Egg_GenderRatio.SelectedIndex = 1;

            Event_Species.Items.Clear();
            Event_Species.Items.AddRange(new string[] { "-" }.Concat(StringItem.species.Skip(1).Take(Gen6 ? 721 : 802)).ToArray());
            Event_Species.SelectedIndex = 0;

            // display something upon loading
            Nature.CheckBoxItems[0].Checked = true;
            Nature.CheckBoxItems[0].Checked = false;
            HiddenPower.CheckBoxItems[0].Checked = true;
            HiddenPower.CheckBoxItems[0].Checked = false;

            AlwaysSynced.Text = SYNC_STR[lindex, 0];
        }

        private string getEggListString(int eggnum, int rejectnum, bool path = false)
        {
            string tmp = "";
            if (eggnum < 0)
            {
                switch (lindex)
                {
                    case 0: return "Egg number is too small";
                    case 1: return "蛋数范围太小";
                }
            }
            switch (lindex)
            {
                case 0: tmp += $"Accepted {eggnum} eggs"; break;
                case 1: tmp += $"接受 {eggnum} 个蛋"; break;
            }
            if (rejectnum == 0)
                return tmp;
            switch (lindex)
            {
                case 0: tmp += path ? $".\nReject {rejectnum} times" : $",\nand then reject {rejectnum} times"; break;
                case 1: tmp += path ? $",\n拒绝 {rejectnum} 次" : $",\n然后拒绝 {rejectnum} 次"; break;
            }
            return tmp;
        }
    }
}
