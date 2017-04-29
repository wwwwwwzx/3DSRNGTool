using System;
using System.Drawing;
using System.Linq;
using pkm3dsRNG.RNG;
using pkm3dsRNG.Core;
using System.Windows.Forms;
using static PKHeX.Util;

namespace pkm3dsRNG
{
    public partial class MainForm : Form
    {
        #region global variables
        private string version = "0.20";

        private int ver { get { return Gameversion.SelectedIndex; } set { Gameversion.SelectedIndex = value; } }
        private Pokemon[] Pokemonlist;
        private Pokemon iPM => RNGPool.PM;
        private byte method => (byte)RNGMethod.SelectedIndex;
        private bool IsEvent => method == 1;
        private bool Gen6 => ver < 4;
        private bool Gen7 => ver > 3;
        private byte modelnum => (byte)(NPC.Value + 1);
        private RNGFilters filter = new RNGFilters();
        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        #region Form Loading
        private void MainForm_Load(object sender, EventArgs e)
        {
            DGV.Columns["dgv_rand64"].DefaultCellStyle.Font = new Font("Consolas", 9);
            DGV.Columns["dgv_rand"].DefaultCellStyle.Font = new Font("Consolas", 9);
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
            for (int i = 0; i <= 802; i++)
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
            var Category = Pokemon.getCategoryList(ver, method);
            for (int i = 0; i < Category.Length; i++)
                if (Category[i].List.Any(t => t.SpecForm == Lastpkm))
                {
                    CB_Category.SelectedIndex = i;
                    Sta_Poke.SelectedValue = Lastpkm;
                    return;
                }
            CB_Category.SelectedIndex = 0;
        }

        private void LoadSpecies()
        {
            Pokemonlist = Pokemon.getSpecFormList(ver, CB_Category.SelectedIndex, method);
            var List = Pokemonlist.Select(s => new Controls.ComboItem(s.ToString(), s.SpecForm));
            Sta_Poke.DisplayMember = "Text";
            Sta_Poke.ValueMember = "Value";
            Sta_Poke.DataSource = new BindingSource(List, null);
            Sta_Poke.SelectedIndex = 0;
        }

        private void LoadCategory()
        {
            ver = Math.Max(ver, 0);
            CB_Category.Items.Clear();
            var Category = Pokemon.getCategoryList(ver, method).Select(t => StringItem.Translate(t.ToString(), lindex)).ToArray();
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
            Timedelay.Enabled = Advanced.Checked;
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
            Frame_min.Value = Gen7 ? 418 : 0;

            dgv_rand.Visible = Gen6;

            BlinkFOnly.Visible = SafeFOnly.Visible =
            CreateTimeline.Visible = TimeSpan.Visible =
            Gen7timepanel.Visible = dgv_delay.Visible = dgv_blink.Visible = dgv_rand64.Visible = Gen7;

            if (Gen6 && CreateTimeline.Checked)
                RB_FrameRange.Checked = true;
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

        private void RNGMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            RNGMethod.TabPages[method].Controls.Add(this.Filters);
            RNGMethod.TabPages[method].Controls.Add(this.RNGInfo);
            switch (method)
            {
                case 0: Poke_SelectedIndexChanged(null, null); Sta_Setting.Controls.Add(EnctrPanel); LoadCategory(); return;
                case 1: Event_CheckedChanged(null, null); NPC.Value = 4; return;
                case 2: Poke_SelectedIndexChanged(null, null); Wild_Setting.Controls.Add(EnctrPanel); LoadCategory(); return;
            }
        }

        private void CreateTimeline_CheckedChanged(object sender, EventArgs e)
        {
            ConsiderDelay.Enabled = !CreateTimeline.Checked;
            if (CreateTimeline.Checked) ConsiderDelay.Checked = true;
        }

        private void NPC_ValueChanged(object sender, EventArgs e)
        {
            if (Gen7)
            {
                var ControlON = NPC.Value == 0 ? BlinkFOnly : SafeFOnly;
                var ControlOFF = NPC.Value == 0 ? SafeFOnly : BlinkFOnly;
                ControlON.Visible = true;
                ControlOFF.Visible = ControlOFF.Checked = false;
            }
        }
        #endregion

        #region DataEntry

        private void SetPersonalInfo(int Species, int Form)
        {
            SyncNature.Enabled = !(iPM?.Nature < 25) && iPM.Syncable;
            if (Species == 0)
                return;

            // Load from personal table
            var t = Gen6 ? PersonalTable.ORAS.getFormeEntry(Species, Form) : PersonalTable.SM.getFormeEntry(Species, Form);
            BS = new[] { t.HP, t.ATK, t.DEF, t.SPA, t.SPD, t.SPE };
            GenderRatio.SelectedValue = t.Gender;
            Fix3v.Checked = t.EggGroups[0] == 0x0F; //Undiscovered Group

            // Load from Pokemonlist
            if (iPM == null || IsEvent)
                return;
            Filter_Lv.Value = iPM.Level;
            AlwaysSynced.Checked = iPM.AlwaysSync;
            ShinyLocked.Checked = iPM.ShinyLocked;
            GenderRatio.SelectedValue = (int)iPM.GenderRatio;
            if (iPM.IVs != null)
            {
                IVlow = iPM.IVs.Select(iv => iv >= 0 ? iv : 0).ToArray();
                IVup = iPM.IVs.Select(iv => iv >= 0 ? iv : 31).ToArray();
            }
            if (!iPM.Syncable)
                SyncNature.SelectedIndex = 0;
            if (iPM.Nature < 25)
                SyncNature.SelectedIndex = iPM.Nature + 1;
            Timedelay.Value = (iPM as PKM7)?.Delay ?? 0;
            NPC.Value = (iPM as PKM7)?.NPC ?? 1;
            if (iPM is PKMW7)
            {
                // load location and slots
            }
        }

        private void SetPersonalInfo(int SpecForm) => SetPersonalInfo(SpecForm & 0x7FF, SpecForm >> 11);

        private void Poke_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reset_Click(null, null);
            int specform = (int)(Sta_Poke.SelectedValue);
            Properties.Settings.Default.PKM = specform;
            Properties.Settings.Default.Save();
            RNGPool.PM = Pokemonlist.FirstOrDefault(p => p.SpecForm == specform);
            SetPersonalInfo(specform);
            AlwaysSynced.Enabled = iPM.Conceptual && specform == 0;
            ShinyLocked.Enabled = Fix3v.Enabled = GenderRatio.Enabled = iPM.Conceptual && (specform == 0 || specform == 151);
        }
        #endregion

        #region UI communication
        private void getsetting(IRNG rng)
        {
            dgvrowlist.Clear();
            DGV.Rows.Clear();

            filter = FilterSettings;
            RNGPool.RNGmethod = method;
            switch (RNGPool.RNGmethod)
            {
                case 0: RNGPool.sta_rng = getStaSettings(); break;
                case 1: RNGPool.event_rng = getEventSetting(); break;
            }

            int buffersize = 150;
            if (Gen7)
            {
                RNGPool.modelnumber = modelnum;
                RNGPool.IsSolgaleo = method == 0 && iPM.Species == 791;
                RNGPool.IsLunala = method == 0 && iPM.Species == 792;
                RNGPool.SolLunaReset = (RNGPool.IsSolgaleo || RNGPool.IsLunala) && RNGPool.modelnumber == 7;
                RNGPool.delaytime = (int)Timedelay.Value / 2;

                if (RNGPool.Considerdelay = ConsiderDelay.Checked)
                    buffersize += RNGPool.modelnumber * (method < 2 ? RNGPool.delaytime : 100);
            }
            RNGPool.CreateBuffer(buffersize, rng);
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

            BlinkFOnly = BlinkFOnly.Checked,
            SafeFOnly = SafeFOnly.Checked,
        };

        private StationaryRNG getStaSettings()
        {
            StationaryRNG setting = Gen6 ? (StationaryRNG)new Stationary6() : (StationaryRNG)new Stationary7();
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
                Error(SETTINGERROR_STR[lindex] + RB_FrameRange.Text);
            else if (Gen6)
                Search6();
            else
                Search7();
        }

        private static readonly string[] blinkmarks = { "-", "★", "?", "? ★" };
        private DataGridViewRow getRow(int i, RNGResult result)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(DGV);

            string true_nature = StringItem.naturestr[result.Nature];
            byte blink = (result as Result7)?.Blink ?? 0;
            string delay = (result as Result7)?.frameshift.ToString("+#;-#;0") ?? "";
            string BlinkFlag = blink < 4 ? blinkmarks[blink] : blink.ToString();
            string SynchronizeFlag = result.Synchronize ? "O" : "X";
            string PSV = result.PSV.ToString("D4");
            string Lv = result.Level == 0 ? "-" : result.Level.ToString();
            string randstr = (result as Result6)?.RandNum.ToString("X8") ?? "";
            string rand64str = (result as Result7)?.RandNum.ToString("X16") ?? "";
            string PID = result.PID.ToString("X8");
            string EC = result.EC.ToString("X8");

            int[] Status = ShowStats.Checked ? result.Stats : result.IVs;

            row.SetValues(
                i, BlinkFlag, delay,
                Status[0], Status[1], Status[2], Status[3], Status[4], Status[5],
                true_nature, SynchronizeFlag, StringItem.hpstr[result.hiddenpower + 1], PSV, StringItem.genderstr[result.Gender], StringItem.abilitystr[result.Ability],
                randstr, rand64str, PID, EC
                );

            if (result.Shiny)
                row.DefaultCellStyle.BackColor = Color.LightCyan;

            Font BoldFont = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            for (int k = 0; k < 6; k++)
            {
                if (result.IVs[k] < 1)
                {
                    row.Cells[3 + k].Style.Font = BoldFont;
                    row.Cells[3 + k].Style.ForeColor = Color.OrangeRed;
                }
                else if (result.IVs[k] > 29)
                {
                    row.Cells[3 + k].Style.Font = BoldFont;
                    row.Cells[3 + k].Style.ForeColor = Color.MediumSeaGreen;
                }
            }
            return row;
        }
        #endregion

        private void Search6()
        {
            var rng = new TinyMT((uint)Seed.Value);
            int max, min;
            min = (int)Frame_min.Value;
            max = (int)Frame_max.Value;
            if (AroundTarget.Checked)
            {
                min = (int)Frame_max.Value - 100; max = (int)Frame_max.Value + 100;
            }
            // Advance
            for (int i = 0; i < min; i++)
                rng.Next();
            // Prepare
            getsetting(rng);
            // Start
            for (int i = min; i <= max; i++, RNGPool.Next(rng.Nextuint()))
            {
                RNGResult result = RNGPool.Generate6();
                if (!filter.CheckResult(result))
                    continue;
                dgvrowlist.Add(getRow(i, result));
                if (dgvrowlist.Count > 100000)
                    break;
            }
            DGV.Rows.AddRange(dgvrowlist.ToArray());
            DGV.CurrentCell = null;
        }

        #region Gen7 Search
        private void Search7()
        {
            if (CreateTimeline.Checked)
                Search7_Timeline();
            else
                Search7_Normal();
        }

        private void Search7_Normal()
        {
            SFMT sfmt = new SFMT((uint)Seed.Value);
            int min = (int)Frame_min.Value;
            int max = (int)Frame_max.Value;
            if (AroundTarget.Checked)
            {
                min = (int)Frame_max.Value - 100; max = (int)Frame_max.Value + 100;
            }
            // Blinkflag
            FuncUtil.getblinkflaglist(min, max, sfmt, modelnum);
            // Advance
            int StartFrame = (int)Frame_min.Value;
            for (int i = 0; i < StartFrame; i++)
                sfmt.Next();
            // Prepare
            ModelStatus status = new ModelStatus(modelnum, sfmt);
            ModelStatus stmp = new ModelStatus(modelnum, sfmt);
            getsetting(sfmt);
            int frameadvance;
            int realtime = 0;
            // Start
            for (int i = StartFrame; i <= max;)
            {
                status.CopyTo(stmp);
                frameadvance = status.NextState();

                while (frameadvance > 0)
                {
                    RNGPool.CopyStatus(stmp);
                    var result = RNGPool.Generate7();

                    RNGPool.Next(sfmt.Nextulong());

                    frameadvance--;
                    i++;
                    if (i <= min || i > max)
                        continue;

                    FuncUtil.MarkResults((result as Result7), i - min - 1, realtime);

                    if (!filter.CheckResult(result))
                        continue;
                    dgvrowlist.Add(getRow(i - 1, result));
                }
                realtime++;
                if (dgvrowlist.Count > 100000) break;
            }
            DGV.Rows.AddRange(dgvrowlist.ToArray());
            DGV.CurrentCell = null;
        }

        private void Search7_Timeline()
        {
            SFMT sfmt = new SFMT((uint)Seed.Value);
            int start_frame = (int)Frame_min.Value;
            FuncUtil.getblinkflaglist(start_frame, start_frame, sfmt, modelnum);
            // Advance
            for (int i = 0; i < start_frame; i++)
                sfmt.Next();
            // Prepare
            ModelStatus status = new ModelStatus(modelnum, sfmt);
            getsetting(sfmt);
            int totaltime = (int)TimeSpan.Value * 30;
            int frame = (int)Frame_min.Value;
            int frameadvance, Currentframe;
            // Start
            for (int i = 0; i <= totaltime; i++)
            {
                Currentframe = frame;

                RNGPool.CopyStatus(status);

                var result = RNGPool.Generate7();
                FuncUtil.MarkResults((result as Result7), i, i);

                frameadvance = status.NextState();
                frame += frameadvance;
                for (int j = 0; j < frameadvance; j++)
                    RNGPool.Next(sfmt.Nextulong());

                if (!filter.CheckResult(result))
                    continue;

                dgvrowlist.Add(getRow(Currentframe, result));

                if (dgvrowlist.Count > 100000)
                    break;
            }
            DGV.Rows.AddRange(dgvrowlist.ToArray());
            DGV.CurrentCell = null;
        }
        #endregion
    }
}
