using System;
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

        private int ver { get { return Gameversion.SelectedIndex; } set { Gameversion.SelectedIndex = value; } }
        private Pokemon[] Pokemonlist;
        private Pokemon iPM => RNGPool.PM;
        private EventRule rule => RNGPool.e;
        private bool IsEvent => iPM.IsEvent;
        private RNGFilters filter = new RNGFilters();
        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        #region Form Loading
        private void MainForm_Load(object sender, EventArgs e)
        {
            DGV.Columns["dgv_Rand"].DefaultCellStyle.Font = new Font("Consolas", 9);
            DGV.Columns["dgv_PID"].DefaultCellStyle.Font = new Font("Consolas", 9);
            DGV.Columns["dgv_EC"].DefaultCellStyle.Font = new Font("Consolas", 9);
            Type dgvtype = typeof(DataGridView);
            System.Reflection.PropertyInfo dgvPropertyInfo = dgvtype.GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            dgvPropertyInfo.SetValue(DGV, true, null);

            Seed.Value = Properties.Settings.Default.Seed;
            var LastGameversion = Properties.Settings.Default.GameVersion;
            var Lastpkm = Properties.Settings.Default.PKM;
            ShinyCharm.Checked = Properties.Settings.Default.ShinyCharm;
            TSV.Value = Properties.Settings.Default.TSV;
            Advanced.Checked = Properties.Settings.Default.Advance;

            for (int i = 0; i < 6; i++)
                EventIV[i].Enabled = false;

            Gender.Items.AddRange(StringItem.genderstr);
            Event_Gender.Items.AddRange(StringItem.genderstr);
            Event_Nature.Items.AddRange(StringItem.naturestr);
            for (int i = 0; i <= 721; i++)
                Event_Species.Items.Add("-");
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
            Event_Species.SelectedIndex = Event_PIDType.SelectedIndex = Event_Nature.SelectedIndex = 0;
            Event_Ability.SelectedIndex = Event_Gender.SelectedIndex = 0;
            Gameversion.SelectedIndex = LastGameversion;
            FindSetting(Lastpkm);

            ByIVs.Checked = true;
        }

        private void FindSetting(int Lastpkm)
        {
            var Category = Pokemon.getCategoryList(ver);
            for (int i = 0; i < Category.Length; i++)
                if (Category[i].List.Any(t => t.SpecForm == Lastpkm))
                {
                    CB_Category.SelectedIndex = i;
                    Poke.SelectedValue = Lastpkm;
                    return;
                }
            CB_Category.SelectedIndex = 0;
        }

        private void LoadSpecies()
        {
            Pokemonlist = Pokemon.getSpecFormList(ver, CB_Category.SelectedIndex);
            var List = Pokemonlist.Select(s => new Controls.ComboItem(s.ToString(), s.SpecForm));
            Poke.DisplayMember = "Text";
            Poke.ValueMember = "Value";
            Poke.DataSource = new BindingSource(List, null);
            Poke.SelectedIndex = 0;
        }

        private void LoadCategory()
        {
            ver = Math.Max(ver, 0);
            CB_Category.Items.Clear();
            var Category = Pokemon.getCategoryList(ver).Select(t => StringItem.Translate(t.ToString(), lindex)).ToArray();
            CB_Category.Items.AddRange(Category);
            CB_Category.SelectedIndex = 0;
            LoadSpecies();
        }
        #endregion

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
            Properties.Settings.Default.GameVersion = (byte)Gameversion.SelectedIndex;
            Properties.Settings.Default.Save();
            LoadCategory();
        }

        private void Category_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void Reset_Click(object sender, EventArgs e)
        {
            IVlow = new int[6];
            IVup = new[] { 31, 31, 31, 31, 31, 31 };
            Stats = new int[6];
            Filter_Lv.Value = 0;

            Nature.ClearSelection();
            HiddenPower.ClearSelection();
            Gender.SelectedIndex = Ability.SelectedIndex = 0;

            ShinyOnly.Checked = DisableFilters.Checked = false;
        }
        #endregion

        #region DataEntry

        private void SetPersonalInfo(int Species, int Form)
        {
            SyncNature.Enabled = !(iPM?.Nature < 25);
            if (Species == 0)
                return;

            // Load from personal table
            var t = PersonalTable.ORAS.getFormeEntry(Species, Form);
            BS = new[] { t.HP, t.ATK, t.DEF, t.SPA, t.SPD, t.SPE };
            GenderRatio.SelectedValue = t.Gender;
            Fix3v.Checked = t.EggGroups[0] == 0x0F; //Undiscovered Group

            // Load from Pokemonlist
            if (IsEvent || iPM == null)
                return;
            Filter_Lv.Value = iPM.Level;
            AlwaysSynced.Checked = iPM.AlwaysSync;
            ShinyLocked.Checked = iPM.ShinyLocked;
            GenderRatio.SelectedValue = (int)iPM.GenderRatio;
            if (iPM.Nature < 25)
                SyncNature.SelectedIndex = iPM.Nature + 1;
            if (iPM.IVs != null)
            {
                IVlow = iPM.IVs.Select(iv => iv >= 0 ? iv : 0).ToArray();
                IVup = iPM.IVs.Select(iv => iv >= 0 ? iv : 31).ToArray();
            }
        }
        private void SetPersonalInfo(int SpecForm) => SetPersonalInfo(SpecForm & 0x7FF, SpecForm >> 11);

        private void Poke_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reset_Click(null, null);
            int specform = (int)(Poke.SelectedValue);
            Properties.Settings.Default.PKM = specform;
            Properties.Settings.Default.Save();
            RNGPool.PM = Pokemonlist.FirstOrDefault(p => p.SpecForm == specform);
            SetPersonalInfo(specform);
            ShinyLocked.Enabled = Fix3v.Enabled = GenderRatio.Enabled = AlwaysSynced.Enabled = specform == 0;
        }
        #endregion

        #region UI communication
        private void getsetting(IRNG rng)
        {
            dgvrowlist.Clear();
            DGV.Rows.Clear();

            filter = FilterSettings;
            RNGPool.CreateBuffer(200, rng);
            RNGPool.e = IsEvent ? geteventsetting() : null;
            RNGPool.rngsetting = getRNGSettings();
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
            Lv = (byte)Filter_Lv.Value,
            PerfectIVs = (byte)PerfectIVs.Value,
        };

        private RNGSetting getRNGSettings()
        {
            RNGSetting setting = new RNGSetting();
            setting.Synchro_Stat = (byte)(SyncNature.SelectedIndex - 1);
            setting.TSV = (int)TSV.Value;
            setting.ShinyCharm = ShinyCharm.Checked;
            // Load from template
            if (!iPM.Conceptual)
            {
                setting.UseTemplate(RNGPool.PM);
                return setting;
            }

            // Load from UI
            int gender = (int)GenderRatio.SelectedValue;
            setting.IV3 = Fix3v.Checked;
            setting.Gender = FuncUtil.getGenderRatio(gender);
            setting.RandomGender = FuncUtil.IsRandomGender(gender);
            setting.AlwaysSync = AlwaysSynced.Checked;
            setting.Level = (byte)Filter_Lv.Value;
            setting.IsShinyLocked = ShinyLocked.Checked;
            return setting;
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
            uint[] status = new uint[] { 0xBEEFFACE, 0xDEADBEEF, 0xDEADFACE, 0x12345678, };
            var rng = new TinyMT(status);
            //var rng = new MersenneTwister((uint)Seed.Value);
            int max, min;
            min = (int)Frame_min.Value;
            max = (int)Frame_max.Value;
            // Advance
            for (int i = 0; i < min; i++)
                rng.Next();
            // Prepare
            getsetting(rng);
            // Start
            for (int i = min; i <= max; i++, RNGPool.Next(rng.Nextuint()))
            {
                RNGResult result = RNGPool.Generate();
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
