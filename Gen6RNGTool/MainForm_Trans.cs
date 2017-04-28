using System;
using System.Windows.Forms;
using static PKHeX.Util;

namespace Gen6RNGTool
{
    public partial class MainForm : Form
    {
        private static readonly string[] ANY_STR = { "Any", "任意" };
        private static readonly string[] NONE_STR = { "None", "无" };
        private static readonly string[] SETTINGERROR_STR = { "Error at ", "出错啦0.0 发生在" };
        private static readonly string[] FILEERRORSTR = { "Invalid file!", "文件格式不正确" };
        private static readonly string[,] PIDTYPE_STR =
        {
            { "Random", "Nonshiny", "Shiny","Specified"},
            { "随机", "必不闪", "必闪","特定"}
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
            StringItem.genderratio = getStringList("Genderratio", curlanguage);

            for (int i = 0; i < 4; i++)
                Event_PIDType.Items[i] = PIDTYPE_STR[lindex, i];

            LoadCategory();

            Nature.Items.Clear();
            Nature.BlankText = ANY_STR[lindex];
            Nature.Items.AddRange(StringItem.NatureList);

            SyncNature.Items[0] = NONE_STR[lindex];
            for (int i = 0; i < StringItem.naturestr.Length; i++)
                Event_Nature.Items[i] = SyncNature.Items[i + 1] = StringItem.naturestr[i];

            for (int i = 1; i < StringItem.species.Length; i++)
                Event_Species.Items[i] = StringItem.species[i];

            HiddenPower.Items.Clear();
            HiddenPower.BlankText = ANY_STR[lindex];
            HiddenPower.Items.AddRange(StringItem.HiddenPowerList);

            GenderRatio.DisplayMember = "Text";
            GenderRatio.ValueMember = "Value";
            GenderRatio.DataSource = new BindingSource(StringItem.GenderRatioList, null);
            GenderRatio.SelectedIndex = 0;

            // display something upon loading
            Nature.CheckBoxItems[0].Checked = true;
            Nature.CheckBoxItems[0].Checked = false;
            HiddenPower.CheckBoxItems[0].Checked = true;
            HiddenPower.CheckBoxItems[0].Checked = false;
        }
    }
}
