using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using Gen6RNGTool.RNG;
using System.Windows.Forms;
using static PKHeX.Util;

namespace Gen6RNGTool
{
    public partial class MainForm : Form
    {
        #region global variables
        private string version = "0.10";
        private static readonly string[] ANY_STR = { "Any", "任意" };
        private static readonly string[] NONE_STR = { "None", "无" };
        private static readonly string[] SETTINGERROR_STR = { "Error at ", "出错啦0.0 发生在" };

        private Pokemon[] Pokemonlist;
        private Pokemon iPM => RNGSetting.PM;
        private RNGSetting setting = new RNGSetting();
        private RNGFilters filter = new RNGFilters();
        #endregion

        public MainForm()
        {
            InitializeComponent();
        }
        #region HexNumericFunction
        private void NumericUpDown_Enter(object sender, EventArgs e)
        {
            NumericUpDown NumericUpDown = sender as NumericUpDown;
            NumericUpDown.Select(0, NumericUpDown.Text.Length);
        }

        private void NumericUpDown_Check(object sender, CancelEventArgs e)
        {
            NumericUpDown NumericUpDown = sender as NumericUpDown;
            Control ctrl = NumericUpDown;
            if (ctrl == null)
                return;
            if (!string.IsNullOrEmpty(NumericUpDown.Text))
                return;
            foreach (var box in ((NumericUpDown)ctrl).Controls.OfType<TextBox>())
            {
                box.Undo();
                break;
            }
        }
        #endregion
        #region Controls Grouping
        private int[] IVup
        {
            get { return new[] { (int)ivmax0.Value, (int)ivmax1.Value, (int)ivmax2.Value, (int)ivmax3.Value, (int)ivmax4.Value, (int)ivmax5.Value, }; }
            set
            {
                if (value.Length < 6) return;
                ivmax0.Value = value[0]; ivmax1.Value = value[1]; ivmax2.Value = value[2];
                ivmax3.Value = value[3]; ivmax4.Value = value[4]; ivmax5.Value = value[5];
            }
        }
        private int[] IVlow
        {
            get { return new[] { (int)ivmin0.Value, (int)ivmin1.Value, (int)ivmin2.Value, (int)ivmin3.Value, (int)ivmin4.Value, (int)ivmin5.Value, }; }
            set
            {
                if (value.Length < 6) return;
                ivmin0.Value = value[0]; ivmin1.Value = value[1]; ivmin2.Value = value[2];
                ivmin3.Value = value[3]; ivmin4.Value = value[4]; ivmin5.Value = value[5];
            }
        }
        private int[] BS
        {
            get { return new[] { (int)BS_0.Value, (int)BS_1.Value, (int)BS_2.Value, (int)BS_3.Value, (int)BS_4.Value, (int)BS_5.Value, }; }
            set
            {
                if (value.Length < 6) return;
                BS_0.Value = value[0]; BS_1.Value = value[1]; BS_2.Value = value[2];
                BS_3.Value = value[3]; BS_4.Value = value[4]; BS_5.Value = value[5];
            }
        }
        private int[] Stats
        {
            get { return new[] { (int)Stat0.Value, (int)Stat1.Value, (int)Stat2.Value, (int)Stat3.Value, (int)Stat4.Value, (int)Stat5.Value, }; }
            set
            {
                if (value.Length < 6) return;
                Stat0.Value = value[0]; Stat1.Value = value[1]; Stat2.Value = value[2];
                Stat3.Value = value[3]; Stat4.Value = value[4]; Stat5.Value = value[5];
            }
        }
        private List<DataGridViewRow> dgvrowlist = new List<DataGridViewRow>();
        #endregion

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
            Text = Text + $" v{version} @wwwwwwzx";

            StringItem.naturestr = getStringList("Natures", curlanguage);
            StringItem.hpstr = getStringList("Types", curlanguage);
            StringItem.species = getStringList("Species", curlanguage);

            LoadSpecies();

            Nature.Items.Clear();
            Nature.BlankText = ANY_STR[lindex];
            Nature.Items.AddRange(StringItem.NatureList);

            SyncNature.Items[0] = NONE_STR[lindex];
            for (int i = 0; i < StringItem.naturestr.Length; i++)
                SyncNature.Items[i + 1] = StringItem.naturestr[i];

            HiddenPower.Items.Clear();
            HiddenPower.BlankText = ANY_STR[lindex];
            HiddenPower.Items.AddRange(StringItem.HiddenPowerList);

            // display something upon loading
            Nature.CheckBoxItems[0].Checked = true;
            Nature.CheckBoxItems[0].Checked = false;
            HiddenPower.CheckBoxItems[0].Checked = true;
            HiddenPower.CheckBoxItems[0].Checked = false;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            DGV.Columns["dgv_Rand"].DefaultCellStyle.Font = new Font("Consolas", 9);
            DGV.Columns["dgv_PID"].DefaultCellStyle.Font = new Font("Consolas", 9);
            DGV.Columns["dgv_EC"].DefaultCellStyle.Font = new Font("Consolas", 9);
            Type dgvtype = typeof(DataGridView);
            System.Reflection.PropertyInfo dgvPropertyInfo = dgvtype.GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            dgvPropertyInfo.SetValue(DGV, true, null);

            Gender.Items.AddRange(StringItem.genderstr);

            GenderRatio.DisplayMember = "Text";
            GenderRatio.ValueMember = "Value";
            GenderRatio.DataSource = new BindingSource(StringItem.GenderRatioList, null);
            GenderRatio.SelectedIndex = 0;

            for (int i = 0; i <= StringItem.naturestr.Length; i++)
                SyncNature.Items.Add("");

            string l = Properties.Settings.Default.Language;
            int lang = Array.IndexOf(langlist, l);
            if (lang < 0) lang = Array.IndexOf(langlist, "en");

            lindex = lang;
            ChangeLanguage(null, null);

            Gender.SelectedIndex = 0;
            Ability.SelectedIndex = 0;
            SyncNature.SelectedIndex = 0;

            GameVersion.SelectedIndex = Properties.Settings.Default.GameVersion;
            Poke.SelectedValue = Properties.Settings.Default.Pokemon;
            Seed.Value = Properties.Settings.Default.Seed;
            ShinyCharm.Checked = Properties.Settings.Default.ShinyCharm;
            TSV.Value = Properties.Settings.Default.TSV;
            Advanced.Checked = Properties.Settings.Default.Advance;

            ByIVs.Checked = true;
        }

        private void LoadSpecies()
        {
            Pokemonlist = Pokemon.getSpecFormList(GameVersion.SelectedIndex);
            var List = Pokemonlist.Select(s => new Controls.ComboItem(StringItem.species[s.Species], s.SpecForm));
            List = new[] { new Controls.ComboItem("-", 0) }.Concat(List);
            Poke.DisplayMember = "Text";
            Poke.ValueMember = "Value";
            Poke.DataSource = new BindingSource(List, null);
            Poke.SelectedIndex = 0;
        }

        #region Basic UI
        private void TSV_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TSV = (short)TSV.Value;
            Properties.Settings.Default.Save();
        }

        private void ShinyCharm_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShinyCharm = ShinyCharm.Checked;
            Properties.Settings.Default.Save();
        }

        private void Advanced_CheckedChanged(object sender, EventArgs e)
        {
            dgv_research.Visible = Advanced.Checked;
            Properties.Settings.Default.Advance = Advanced.Checked;
            Properties.Settings.Default.Save();
        }

        private void Seed_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Seed = Seed.Value;
            Properties.Settings.Default.Save();
        }

        private void GameVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.GameVersion = (byte)GameVersion.SelectedIndex;
            Properties.Settings.Default.Save();
            LoadSpecies();
        }

        private void SearchMethod_CheckedChanged(object sender, EventArgs e)
        {
            IVPanel.Visible = ByIVs.Checked;
            StatPanel.Visible = ByStats.Checked;
            ShowStats.Enabled = ShowStats.Checked = ByStats.Checked;
        }

        private void SyncNature_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AlwaysSynced.Checked)
            {
                Nature.ClearSelection();
                if (SyncNature.SelectedIndex > 0)
                    Nature.CheckBoxItems[SyncNature.SelectedIndex].Checked = true;
            }
        }
        #endregion
        #region DataEntry

        private void SetPersonalInfo(int Species, int Form)
        {
            SyncNature.Enabled = !(iPM?.Nature >= 0);
            if (Species == 0)
                return;

            // Load from personal table
            var t = PersonalTable.ORAS.getFormeEntry(Species, Form);
            BS = new[] { t.HP, t.ATK, t.DEF, t.SPA, t.SPD, t.SPE };
            GenderRatio.SelectedValue = t.Gender;
            Fix3v.Checked = t.EggGroups[0] == 0x0F; //Undiscovered Group

            // Load from Pokemonlist
            if (iPM == null)
                return;
            Lv_Search.Value = iPM.Level;
            AlwaysSynced.Checked = iPM.AlwaysSync;
            ShinyLocked.Checked = iPM.ShinyLocked;
            GenderRatio.SelectedValue = (int)iPM.GenderRatio;
            if (iPM.Nature >= 0)
                SyncNature.SelectedIndex = (int)iPM.Nature + 1;
        }
        private void SetPersonalInfo(int SpecForm) => SetPersonalInfo(SpecForm & 0x7FF, SpecForm >> 11);

        private void Poke_SelectedIndexChanged(object sender, EventArgs e)
        {
            int specform = (int)(Poke.SelectedValue);
            Properties.Settings.Default.Pokemon = specform;
            Properties.Settings.Default.Save();
            RNGSetting.PM = Pokemonlist.FirstOrDefault(p => p.SpecForm == specform);
            SetPersonalInfo(specform);
            ShinyLocked.Enabled = Fix3v.Enabled = GenderRatio.Enabled = AlwaysSynced.Enabled = Poke.SelectedIndex == 0;
        }
        #endregion

        #region UI communication
        private void getsetting(MersenneTwister mt)
        {
            dgvrowlist.Clear();
            DGV.Rows.Clear();

            filter = FilterSettings;
            RefreshRNGSettings(mt);
            setting = new RNGSetting();
        }

        private RNGFilters FilterSettings => new RNGFilters
        {
            Nature = Nature.CheckBoxItems.Skip(1).Select(e => e.Checked).ToArray(),
            HPType = HiddenPower.CheckBoxItems.Skip(1).Select(e => e.Checked).ToArray(),
            Gender = (byte)Gender.SelectedIndex,
            Ability = (byte)Ability.SelectedIndex,
            IVlow = IVlow,
            IVup = IVup,
            BS = ByStats.Checked ? BS : null,
            Stats = ByStats.Checked ? Stats : null,
            ShinyOnly = ShinyOnly.Checked,
            Skip = DisableFilters.Checked,
            Lv = (byte)Lv_Search.Value,
            PerfectIVs = (byte)PerfectIVs.Value,
        };

        private void RefreshRNGSettings(MersenneTwister mt)
        {
            RNGSetting.CreateBuffer(200, mt);

            RNGSetting.Synchro_Stat = (byte)(SyncNature.SelectedIndex - 1);
            RNGSetting.TSV = (int)TSV.Value;
            RNGSetting.ShinyCharm = ShinyCharm.Checked;

            // Load from template
            if (RNGSetting.HasTemplate)
            {
                RNGSetting.UseTemplate();
                return;
            }

            // Load from UI
            int gender = (int)GenderRatio.SelectedValue;
            RNGSetting.Fix3v = Fix3v.Checked;
            RNGSetting.Gender = RNGSetting.getGenderRatio(gender);
            RNGSetting.RandomGender = RNGSetting.IsRandomGender(gender);
            RNGSetting.AlwaysSync = AlwaysSynced.Checked;
            RNGSetting.PokeLv = (byte)Lv_Search.Value;
            RNGSetting.IsShinyLocked = ShinyLocked.Checked;
        }
        #endregion

        #region Start Calculation
        private void CalcList_Click(object sender, EventArgs e)
        {
            if (ivmin0.Value > ivmax0.Value)
                Error(SETTINGERROR_STR[lindex] + L_H.Text);
            else if (ivmin1.Value > ivmax1.Value)
                Error(SETTINGERROR_STR[lindex] + L_A.Text);
            else if (ivmin2.Value > ivmax2.Value)
                Error(SETTINGERROR_STR[lindex] + L_B.Text);
            else if (ivmin3.Value > ivmax3.Value)
                Error(SETTINGERROR_STR[lindex] + L_C.Text);
            else if (ivmin4.Value > ivmax4.Value)
                Error(SETTINGERROR_STR[lindex] + L_D.Text);
            else if (ivmin5.Value > ivmax5.Value)
                Error(SETTINGERROR_STR[lindex] + L_S.Text);
            else if (Frame_min.Value > Frame_max.Value)
                Error(SETTINGERROR_STR[lindex] + L_frame.Text);
            else
                StationarySearch();
        }

        private DataGridViewRow getRow(int i, RNGResult result)
        {
            string true_nature = StringItem.naturestr[result.Nature];
            string SynchronizeFlag = result.Synchronize ? "O" : "X";
            string PSV = result.PSV.ToString("D4");
            string Lv = result.Lv == 0 ? "-" : result.Lv.ToString();
            string randstr = result.RandNum.ToString("X8");
            string PID = result.PID.ToString("X8");
            string EC = result.EC.ToString("X8");

            int[] Status = ShowStats.Checked ? result.Stats : result.IVs;

            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(DGV);

            string research = (result.RandNum % 6).ToString() + " " + (result.RandNum >> 27).ToString("D2") + " " + (result.RandNum % 100).ToString("D2") + " " + (result.RandNum % 252).ToString("D3");

            row.SetValues(
                i,
                Status[0], Status[1], Status[2], Status[3], Status[4], Status[5],
                true_nature, SynchronizeFlag, StringItem.hpstr[result.hiddenpower + 1], PSV, StringItem.genderstr[result.Gender], StringItem.abilitystr[result.Ability],
                randstr, PID, EC, research
                );

            if (result.Shiny)
                row.DefaultCellStyle.BackColor = Color.LightCyan;

            Font BoldFont = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            for (int k = 0; k < 6; k++)
            {
                if (result.IVs[k] < 1)
                {
                    row.Cells[1 + k].Style.Font = BoldFont;
                    row.Cells[1 + k].Style.ForeColor = Color.OrangeRed;
                }
                else if (result.IVs[k] > 29)
                {
                    row.Cells[1 + k].Style.Font = BoldFont;
                    row.Cells[1 + k].Style.ForeColor = Color.MediumSeaGreen;
                }
            }
            return row;
        }

        private void StationarySearch()
        {
            MersenneTwister mt = new MersenneTwister((uint)Seed.Value);
            int max, min;
            min = (int)Frame_min.Value;
            max = (int)Frame_max.Value;
            // Advance
            for (int i = 0; i < min; i++)
                mt.Nextuint();
            // Prepare
            getsetting(mt);
            // Start
            for (int i = min; i <= max; i++, RNGSetting.RandList.RemoveAt(0), RNGSetting.RandList.Add(mt.Nextuint()))
            {
                RNGResult result = setting.Generate();
                if (!filter.CheckResult(result))
                    continue;
                dgvrowlist.Add(getRow(i, result));
                if (dgvrowlist.Count > 100000)
                    break;
            }
            DGV.Rows.AddRange(dgvrowlist.ToArray());
            DGV.CurrentCell = null;
        }

        #endregion
    }
}
