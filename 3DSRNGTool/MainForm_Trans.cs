using System;
using System.Linq;
using System.Windows.Forms;
using static PKHeX.Util;
using static Pk3DSRNGTool.StringItem;

namespace Pk3DSRNGTool
{
    public partial class MainForm : Form
    {
        private string curlanguage;
        private static readonly string[] langlist = { "en", "cn" };

        public int lindex { get => Lang.SelectedIndex; set => Lang.SelectedIndex = value; }

        private void ChangeLanguage(object sender, EventArgs e)
        {
            string lang = langlist[lindex];

            if (lang == curlanguage)
                return;

            curlanguage = lang;
            TranslateInterface(this, curlanguage); // Translate the UI to language.
            Properties.Settings.Default.Language = curlanguage;
            Properties.Settings.Default.Save();
            TranslateInterface(TTT, lang);
            TranslateInterface(gen7tool, lang);
            TranslateInterface(ntrhelper, lang);
            Text = Text + $" v{version}";

            naturestr = getStringList("Natures", curlanguage);
            hpstr = getStringList("Types", curlanguage);
            speciestr = getStringList("Species", curlanguage);
            items = getStringList("Items", curlanguage);
            genderratio = getStringList("Genderratio", curlanguage);
            smlocation = getStringList("Location_sm", curlanguage);
            gen6location = getStringList("Location_xy", curlanguage);

            for (int i = 0; i < 4; i++)
                Event_PIDType.Items[i] = PIDTYPE_STR[lindex, i];

            for (int i = 0; i < 3; i++)
                Ball.Items[i] = PARENTS_STR[lindex, i];

            for (int i = 0; i < Gameversion.Items.Count; i++)
                Gameversion.Items[i] = GAMEVERSION_STR[lindex, i];

            IVInputer.Translate(IVJUDGE_STR[lindex], STATS_STR[lindex]);
            Frame.Parents[1] = PARENTS_STR[lindex, 1];
            Frame.Parents[2] = PARENTS_STR[lindex, 2];
            dgv_wurmpleevo.HeaderText = speciestr[265];

            RefreshCategory();
            if (Method == 2)
                RefreshLocation();

            Nature.Items.Clear();
            Nature.BlankText = ANY_STR[lindex];
            Nature.Items.AddRange(NatureList);

            SyncNature.Items[0] = NONE_STR[lindex];
            for (int i = 0; i < naturestr.Length; i++)
                Event_Nature.Items[i] = SyncNature.Items[i + 1] = naturestr[i];

            for (int i = 0; i < items.Length; i++)
                M_Items.Items[i] = F_Items.Items[i] = items[i];

            HiddenPower.Items.Clear();
            HiddenPower.BlankText = ANY_STR[lindex];
            HiddenPower.Items.AddRange(HiddenPowerList);

            GenderRatio.ValueMember = "Value";
            GenderRatio.DisplayMember = "Text";
            GenderRatio.DataSource = new BindingSource(GenderRatioList, null);
            GenderRatio.SelectedIndex = 0;

            Egg_GenderRatio.ValueMember = "Value";
            Egg_GenderRatio.DisplayMember = "Text";
            Egg_GenderRatio.DataSource = new BindingSource(GenderRatioList, null);
            Egg_GenderRatio.SelectedIndex = 1;

            Event_Species.Items.Clear();
            Event_Species.Items.AddRange(new string[] { "-" }.Concat(speciestr.Skip(1).Take(Gen6 ? 721 : 802)).ToArray());
            Event_Species.SelectedIndex = 0;

            // display something upon loading
            Nature.CheckBoxItems[0].Checked = true;
            Nature.CheckBoxItems[0].Checked = false;
            HiddenPower.CheckBoxItems[0].Checked = true;
            HiddenPower.CheckBoxItems[0].Checked = false;

            AlwaysSynced.Text = SYNC_STR[lindex, 0];
        }
    }
}
