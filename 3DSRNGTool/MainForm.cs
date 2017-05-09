using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using Pk3DSRNGTool.Controls;
using Pk3DSRNGTool.RNG;
using Pk3DSRNGTool.Core;
using System.Windows.Forms;
using static PKHeX.Util;

namespace Pk3DSRNGTool
{
    public partial class MainForm : Form
    {
        #region global variables
        private string version = "0.4.0";

        private int ver { get { return Gameversion.SelectedIndex; } set { Gameversion.SelectedIndex = value; } }
        private Pokemon[] Pokemonlist;
        private Pokemon iPM => RNGPool.PM;
        private byte method => (byte)RNGMethod.SelectedIndex;
        private bool IsEvent => method == 1;
        private bool IsPokemonLink => (iPM as PKM6)?.PokemonLink ?? false;
        private bool Gen6 => ver < 4;
        private bool Gen7 => 4 <= ver && ver < 6;
        private byte lastgen;
        private EncounterArea ea = null;
        private bool IsNight => Night.Checked;
        private int[] slotspecies => ea?.getSpecies(ver, IsNight) ?? new int[0];
        private byte modelnum => (byte)(NPC.Value + 1);
        private RNGFilters filter = new RNGFilters();
        private int Standard;
        private int lastpkm;
        private byte lastmethod;
        List<int> OtherTSVList = new List<int>();
        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        #region Form Loading
        private void MainForm_Load(object sender, EventArgs e)
        {
            DGV_ID.Columns["dgv_ID_state"].DefaultCellStyle.Font = new Font("Consolas", 9);
            DGV_ID.Columns["dgv_ID_rand64"].DefaultCellStyle.Font = new Font("Consolas", 9);
            DGV_ID.Columns["dgv_ID_rand"].DefaultCellStyle.Font = new Font("Consolas", 9);
            DGV.Columns["dgv_rand64"].DefaultCellStyle.Font = new Font("Consolas", 9);
            DGV.Columns["dgv_rand"].DefaultCellStyle.Font = new Font("Consolas", 9);
            DGV.Columns["dgv_PID"].DefaultCellStyle.Font = new Font("Consolas", 9);
            DGV.Columns["dgv_EC"].DefaultCellStyle.Font = new Font("Consolas", 9);
            DGV.Columns["dgv_status"].DefaultCellStyle.Font = new Font("Consolas", 9);
            Type dgvtype = typeof(DataGridView);
            System.Reflection.PropertyInfo dgvPropertyInfo = dgvtype.GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            dgvPropertyInfo.SetValue(DGV, true, null);
            dgvPropertyInfo.SetValue(DGV_ID, true, null);

            IVInputer = new IVRange(this);

            Seed.Value = Properties.Settings.Default.Seed;
            var LastGameversion = Properties.Settings.Default.GameVersion;
            lastpkm = Properties.Settings.Default.PKM;
            var LastMethod = Properties.Settings.Default.Method;
            ShinyCharm.Checked = Properties.Settings.Default.ShinyCharm;
            TSV.Value = Properties.Settings.Default.TSV;
            loadlist(Properties.Settings.Default.TSVList);
            Advanced.Checked = Properties.Settings.Default.Advance;
            Status = new uint[] { Properties.Settings.Default.ST0, Properties.Settings.Default.ST1, Properties.Settings.Default.ST2, Properties.Settings.Default.ST3 };

            for (int i = 0; i < 6; i++)
                EventIV[i].Enabled = false;

            Gender.Items.AddRange(StringItem.genderstr);
            Ball.Items.AddRange(StringItem.genderstr);
            Event_Gender.Items.AddRange(StringItem.genderstr);
            Event_Nature.Items.AddRange(StringItem.naturestr);
            for (int i = 0; i <= StringItem.naturestr.Length; i++)
                SyncNature.Items.Add("");

            string l = Properties.Settings.Default.Language;
            int lang = Array.IndexOf(langlist, l);
            if (lang < 0) lang = Array.IndexOf(langlist, "en");

            lindex = lang;
            ChangeLanguage(null, null);

            Gender.SelectedIndex =
            Ball.SelectedIndex =
            Ability.SelectedIndex =
            SyncNature.SelectedIndex =
            Event_Species.SelectedIndex = Event_PIDType.SelectedIndex =
            Event_Ability.SelectedIndex = Event_Gender.SelectedIndex =
            M_ability.SelectedIndex = F_ability.SelectedIndex =
            M_Items.SelectedIndex = F_Items.SelectedIndex =
            0;
            Egg_GenderRatio.SelectedIndex = 1;

            Gameversion.SelectedIndex = LastGameversion;
            RNGMethod.SelectedIndex = LastMethod;
            RNGMethod_Changed(null, null);

            FindSetting(lastpkm);

            ByIVs.Checked = true;
            B_ResetFrame_Click(null, null);
        }

        private void FindSetting(int Lastpkm)
        {
            var Category = Pokemon.getCategoryList(ver, method);
            for (int i = 0; i < Category.Length; i++)
                if (Category[i].List.Any(t => t.SpecForm == Lastpkm))
                {
                    CB_Category.SelectedIndex = i;
                    Poke.SelectedValue = Lastpkm;
                    return;
                }
            CB_Category.SelectedIndex = 0;
        }

        private void RefreshPKM()
        {
            Pokemonlist = Pokemon.getSpecFormList(ver, CB_Category.SelectedIndex, method);
            var List = Pokemonlist.Select(s => new ComboItem(StringItem.Translate(s.ToString(),lindex), s.SpecForm));
            Poke.DisplayMember = "Text";
            Poke.ValueMember = "Value";
            Poke.DataSource = new BindingSource(List, null);
            Poke.SelectedIndex = 0;
        }

        private void RefreshCategory()
        {
            ver = Math.Max(ver, 0);
            CB_Category.Items.Clear();
            var Category = Pokemon.getCategoryList(ver, method).Select(t => StringItem.Translate(t.ToString(), lindex)).ToArray();
            CB_Category.Items.AddRange(Category);
            CB_Category.SelectedIndex = 0;
            RefreshPKM();
        }

        private void RefreshLocation()
        {
            int[] locationlist = null;
            if (Gen6)
                locationlist = iPM.Conceptual ? LocationTable6.Table_ORAS.Select(loc => loc.Locationidx).ToArray() : null;
            else if (Gen7)
                locationlist = iPM.Conceptual ? LocationTable7.getSMLocation(CB_Category.SelectedIndex) : (iPM as PKMW7)?.Location;

            if (locationlist == null)
                return;
            Locationlist = locationlist.Select(loc => new ComboItem(StringItem.getlocationstr(loc, ver), loc)).ToList();

            MetLocation.DisplayMember = "Text";
            MetLocation.ValueMember = "Value";
            MetLocation.DataSource = new BindingSource(Locationlist, null);

            RefreshWildSpecies();
        }

        private void RefreshWildSpecies()
        {
            int tmp = SlotSpecies.SelectedIndex;
            var species = slotspecies;
            var List = Gen7 ? species.Skip(1).Distinct().Select(SpecForm => new ComboItem(StringItem.species[SpecForm & 0x7FF], SpecForm))
                : species.Distinct().Select(SpecForm => new ComboItem(StringItem.species[SpecForm & 0x7FF], SpecForm));
            List = new[] { new ComboItem("-", 0) }.Concat(List);
            SlotSpecies.DisplayMember = "Text";
            SlotSpecies.ValueMember = "Value";
            SlotSpecies.DataSource = new BindingSource(List, null);
            if (0 <= tmp && tmp < SlotSpecies.Items.Count)
                SlotSpecies.SelectedIndex = tmp;
        }

        private void LoadSlotSpeciesInfo()
        {
            int SpecForm = (int)SlotSpecies.SelectedValue;
            List<int> Slotidx = new List<int>();
            for (int i = Array.IndexOf(slotspecies, SpecForm); i > -1; i = Array.IndexOf(slotspecies, SpecForm, i + 1))
                Slotidx.Add(i);
            if (Gen6)
            {
                for (int i = 0; i < 12; i++)
                    Slot.CheckBoxItems[i + 1].Checked = Slotidx.Contains(i);
            }
            else
            {
                byte[] Slottype = EncounterArea7.SlotType[slotspecies[0]];
                for (int i = 0; i < 10; i++)
                    Slot.CheckBoxItems[i + 1].Checked = Slotidx.Contains(Slottype[i]);
            }

            SetPersonalInfo(SpecForm > 0 ? SpecForm : iPM.SpecForm, skip: SlotSpecies.SelectedIndex != 0);
        }
        #endregion

        #region Basic UI

        private void VisibleTrigger(object sender, EventArgs e)
        {
            if ((sender as Control).Visible == false)
                (sender as CheckBox).Checked = false;
        }

        private void Status_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ST0 = (uint)St0.Value;
            Properties.Settings.Default.ST1 = (uint)St1.Value;
            Properties.Settings.Default.ST2 = (uint)St2.Value;
            Properties.Settings.Default.ST3 = (uint)St3.Value;
            Properties.Settings.Default.Save();
        }

        private void TSV_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TSV = (short)TSV.Value;
            Properties.Settings.Default.Save();
        }

        private void ShinyCharm_CheckedChanged(object sender, EventArgs e)
        {
            MM_CheckedChanged(null, null);
            Properties.Settings.Default.ShinyCharm = ShinyCharm.Checked;
            Properties.Settings.Default.Save();
        }

        private void Advanced_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Advance = Advanced.Checked;
            Properties.Settings.Default.Save();
        }

        private void Seed_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Seed = Seed.Value;
            Properties.Settings.Default.Save();
        }

        private void Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshPKM();
            Poke_SelectedIndexChanged(null, null);
            SpecialOnly.Visible = method == 2 && Gen7 && CB_Category.SelectedIndex > 0;
        }

        private void SearchMethod_CheckedChanged(object sender, EventArgs e)
        {
            IVPanel.Visible = ByIVs.Checked;
            StatPanel.Visible = ByStats.Checked;
            ShowStats.Enabled = ShowStats.Checked = ByStats.Checked;
        }

        private void SyncNature_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SyncNature.SelectedIndex > 0)
            {
                CompoundEyes.Checked = false;
                if (AlwaysSynced.Checked)
                {
                    Nature.ClearSelection();
                    Nature.CheckBoxItems[SyncNature.SelectedIndex].Checked = true;
                }
            }
            CompoundEyes.Enabled = SyncNature.SelectedIndex == 0;
        }

        private void Fix3v_CheckedChanged(object sender, EventArgs e)
        {
            PerfectIVs.Value = Fix3v.Checked ? 3 : 0;
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            PerfectIVs.Value = method == 0 && Fix3v.Checked ? 3 : 0;
            IVlow = new int[6];
            IVup = new[] { 31, 31, 31, 31, 31, 31 };
            Stats = new int[6];
            if (method == 2)
                Filter_Lv.Value = 0;

            Nature.ClearSelection();
            HiddenPower.ClearSelection();
            Slot.ClearSelection();
            Ball.SelectedIndex = Gender.SelectedIndex = Ability.SelectedIndex = 0;

            IVInputer.Reset();

            BlinkFOnly.Checked = SafeFOnly.Checked = SpecialOnly.Checked =
            ShinyOnly.Checked = DisableFilters.Checked = false;
        }

        private void GameVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.GameVersion = (byte)Gameversion.SelectedIndex;

            byte currentgen = (byte)(Gen6 ? 6 : 7);
            if (currentgen != lastgen)
            {
                var slotnum = new bool[Gen6 ? 12 : 10].Select((b, i) => (i + 1).ToString()).ToArray();
                Slot.Items.Clear();
                Slot.BlankText = "-";
                Slot.Items.AddRange(slotnum);
                Slot.CheckBoxItems[0].Checked = true;
                Slot.CheckBoxItems[0].Checked = false;

                Event_Species.Items.Clear();
                Event_Species.Items.AddRange(new string[] { "-" }.Concat(StringItem.species.Skip(1).Take(Gen6 ? 721 : 802)).ToArray());
                Event_Species.SelectedIndex = 0;

                lastgen = currentgen;
            }

            RNGMethod_Changed(null, null);
        }

        private void RNGMethod_Changed(object sender, EventArgs e)
        {
            Properties.Settings.Default.Method = method;
            Properties.Settings.Default.Save();

            RB_FrameRange.Checked = true;
            if (method < 4)
                RNGMethod.TabPages[method].Controls.Add(this.Filters);

            RNGMethod.TabPages[method].Controls.Add(this.RNGInfo);

            DGV.Visible = method < 4;
            DGV_ID.Visible = method == 4;

            // Contorls in RNGInfo
            AroundTarget.Visible = method < 3 || MainRNGEgg.Checked;
            timedelaypanel.Visible = method < 3 || MainRNGEgg.Checked || method == 5;
            L_Correction.Visible = Correction.Visible = Gen7 && method == 2; // Honey
            ConsiderDelay.Visible = Timedelay.Visible = label10.Visible = method < 4; // not show in toolkit
            label10.Text = Gen7 ? "+4F" : "F";
            L_NPC.Visible = NPC.Visible = Gen7 || method == 5; // not show in gen6
            EggPanel.Visible = EggNumber.Visible = method == 3 && !MainRNGEgg.Checked;
            CreateTimeline.Visible = TimeSpan.Visible = Gen7 && method < 3 || MainRNGEgg.Checked;
            B_Search.Enabled = Gen7 || method < 2 || 3 < method || method == 2 && ver > 1;

            if (method > 4)
                return;

            if (0 == method || method == 2)
            {
                int currmethod = (method << 3) | ver;
                if (lastmethod != currmethod)
                {
                    RefreshCategory();
                    Poke_SelectedIndexChanged(null, null);
                    lastmethod = (byte)currmethod;
                }
            }

            SpecialOnly.Visible = method == 2 && Gen7 && CB_Category.SelectedIndex > 0;
            L_Ball.Visible = Ball.Visible = Gen7 && method == 3;
            L_Slot.Visible = Slot.Visible = method == 2;
            ByIVs.Enabled = ByStats.Enabled = method < 3;
            BlinkFOnly.Visible = SafeFOnly.Visible = Gen7 && method < 3 || MainRNGEgg.Checked;

            SetAsCurrent.Visible = SetAsAfter.Visible = Gen7 && method == 3 && !MainRNGEgg.Checked;

            Sta_AbilityLocked.Visible =
            RNGPanel.Visible = Gen6;
            B_IVInput.Visible = Gen7 && ByIVs.Checked;
            Lv_max.Visible = Lv_min.Visible = L_Lv.Visible = label9.Visible = 
            GB_RNGGEN7ID.Visible =
            BlinkWhenSync.Visible =
            Filter_G7TID.Visible = Gen7;

            MM_CheckedChanged(null, null);

            switch (method)
            {
                case 0: Sta_Setting.Controls.Add(EnctrPanel); return;
                case 1: NPC.Value = 4; Event_CheckedChanged(null, null); return;
                case 2: Wild_Setting.Controls.Add(EnctrPanel); return;
                case 3: ByIVs.Checked = true; break;
                case 4: (Gen7 ? Filter_G7TID : Filter_TID).Checked = true; break;
            }
        }

        private void CreateTimeline_CheckedChanged(object sender, EventArgs e)
        {
            Frame_max.Visible = label7.Visible =
            ConsiderDelay.Enabled = !(L_StartingPoint.Visible = CreateTimeline.Checked);

            if (CreateTimeline.Checked) ConsiderDelay.Checked = true;
        }

        private void B_ResetFrame_Click(object sender, EventArgs e)
        {
            if (Gen7)
                Frame_min.Value = method < 3 || MainRNGEgg.Checked ? 418 : method == 4 ? 1012 : 0;
            else
                Frame_min.Value = 0;
            TargetFrame.Value = Frame_max.Value = 5000;
            if (0 == method || method == 2)
                Poke_SelectedIndexChanged(null, null);
        }

        private void NPC_ValueChanged(object sender, EventArgs e)
        {
            if (!Gen7)
                return;
            (NPC.Value == 0 ? BlinkFOnly : SafeFOnly).Visible = true;
            (NPC.Value == 0 ? SafeFOnly : BlinkFOnly).Visible = false;
        }

        // Wild RNG
        private void MetLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Gen7)
            {
                ea = LocationTable7.Table.FirstOrDefault(t => t.Locationidx == (int)MetLocation.SelectedValue);
                var tmp = ea as EncounterArea7;
                NPC.Value = tmp.NPC;
                Correction.Value = tmp.Correction;

                Lv_min.Value = ea.VersionDifference && ver == 5 ? tmp.LevelMinMoon : tmp.LevelMin;
                Lv_max.Value = ea.VersionDifference && ver == 5 ? tmp.LevelMaxMoon : tmp.LevelMax;
            }
            else
                ea = (ver > 1 ? LocationTable6.Table_ORAS : null)?.FirstOrDefault(t => t.Locationidx == (int)MetLocation.SelectedValue);

            RefreshWildSpecies();
        }

        private void SlotSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SlotSpecies.SelectedIndex > 0 && (Filter_Lv.Value > Lv_max.Value || Filter_Lv.Value < Lv_min.Value))
                Filter_Lv.Value = 0;
            LoadSlotSpeciesInfo();
        }

        private void Special_th_ValueChanged(object sender, EventArgs e)
        {
            L_Rate.Visible = Special_th.Visible = Special_th.Value > 0;
        }

        private void DayNight_CheckedChanged(object sender, EventArgs e)
        {
            if (ea.DayNightDifference)
                RefreshWildSpecies();
        }

        private void SetAsTarget_Click(object sender, EventArgs e)
        {
            try
            {
                TargetFrame.Value = Convert.ToDecimal(DGV.CurrentRow.Cells["dgv_Frame"].Value);
            }
            catch (NullReferenceException)
            {
                Error(NOSELECTION_STR[lindex]);
            }
        }

        private void B_IVInput_Click(object sender, EventArgs e)
        {
            IVInputer.ShowDialog();
        }

        private void Sta_AbilityLocked_CheckedChanged(object sender, EventArgs e)
        {
            Sta_Ability.Visible = Sta_AbilityLocked.Checked;
        }
        #endregion

        #region DataEntry

        private void SetPersonalInfo(int Species, int Form, bool skip = false)
        {
            SyncNature.Enabled = !(iPM?.Nature < 25) && iPM.Syncable;

            // Load from personal table
            var t = Gen6 ? PersonalTable.ORAS.getFormeEntry(Species, Form) : PersonalTable.SM.getFormeEntry(Species, Form);
            BS = new[] { t.HP, t.ATK, t.DEF, t.SPA, t.SPD, t.SPE };
            GenderRatio.SelectedValue = t.Gender;
            Fix3v.Checked = t.EggGroups[0] == 0x0F; //Undiscovered Group

            // Load from Pokemonlist
            if (iPM == null || IsEvent || skip)
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
            AlwaysSynced.Text = SYNC_STR[lindex, iPM.Syncable && iPM.Nature > 25 ? 0 : 1];
            if (!iPM.Syncable)
                SyncNature.SelectedIndex = 0;
            if (iPM.Nature < 25)
                SyncNature.SelectedIndex = iPM.Nature + 1;
            Fix3v.Checked &= !iPM.Egg;
            Timedelay.Value = iPM.Delay;

            if (Gen7 && method == 0)
            {
                NPC.Value = (iPM as PKM7)?.NPC ?? 0;
                BlinkWhenSync.Checked = !(iPM.AlwaysSync || ((iPM as PKM7)?.NoBlink ?? false));
                return;
            }
            if (Gen6 && method == 0)
                if (Sta_AbilityLocked.Checked = (iPM as PKM6)?.Ability > 0)
                    Sta_Ability.SelectedIndex = (iPM as PKM6).Ability >> 1; // 1/2/4 -> 0/1/2
        }

        private void SetPersonalInfo(int SpecForm, bool skip = false) => SetPersonalInfo(SpecForm & 0x7FF, SpecForm >> 11, skip);

        private void Poke_SelectedIndexChanged(object sender, EventArgs e)
        {
            int specform = (int)(Poke.SelectedValue);
            Properties.Settings.Default.PKM = specform;
            Properties.Settings.Default.Save();
            // Reset_Click(null, null);
            RNGPool.PM = Pokemonlist[Poke.SelectedIndex];
            SetPersonalInfo(specform);
            if (method == 2)
            {
                RefreshLocation();
                if (Gen7) // For UB
                {
                    var tmp = iPM as PKMW7;
                    Special_th.Value = tmp?.Rate?[MetLocation.SelectedIndex] ?? (byte)(CB_Category.SelectedIndex == 2 ? 50 : 0);
                    Correction.Enabled = Special_th.Enabled = iPM.Conceptual;
                }
                return;
            }

            Sta_AbilityLocked.Enabled = Sta_Ability.Enabled =
            BlinkWhenSync.Enabled = AlwaysSynced.Enabled =
            ShinyLocked.Enabled = Fix3v.Enabled = GenderRatio.Enabled = iPM.Conceptual;
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
                case 2: RNGPool.wild_rng = getWildSetting(); break;
                case 3: RNGPool.egg_rng = getEggRNG(); break;
            }

            if (MainRNGEgg.Checked) // Get first egg
            {
                RNGPool.sta_rng = getStaSettings();
                TinyMT tmt = new TinyMT(Status);
                RNGPool.CreateBuffer(50, tmt);
                RNGPool.firstegg = RNGPool.GenerateEgg7() as EggResult;
            }

            int buffersize = 150;
            if (Gen7)
            {
                RNGPool.modelnumber = modelnum;
                RNGPool.IsSolgaleo = method == 0 && iPM.Species == 791;
                RNGPool.IsLunala = method == 0 && iPM.Species == 792;
                RNGPool.IsExeggutor = method == 0 && iPM.Species == 103;
                RNGPool.DelayTime = (int)Timedelay.Value / 2;
                RNGPool.route17 = ModelStatus.route17 = method == 2 && ea.Location == 120;
                RNGPool.PreHoneyCorrection = (int)Correction.Value;

                if (method == 2)
                    buffersize += RNGPool.modelnumber * 100;
                if (RNGPool.Considerdelay = ConsiderDelay.Checked)
                    buffersize += RNGPool.modelnumber * RNGPool.DelayTime;
                if (method < 3 || MainRNGEgg.Checked)
                    Standard = CalcFrame((int)(AroundTarget.Checked ? TargetFrame.Value - 100 : Frame_min.Value), (int)TargetFrame.Value)[0] * 2;
            }
            if (Gen6)
            {
                RNGPool.DelayTime = (int)Timedelay.Value;
                if (RNGPool.Considerdelay = ConsiderDelay.Checked)
                    buffersize += RNGPool.DelayTime;
                if (method < 3)
                    Standard = (int)TargetFrame.Value - (int)(AroundTarget.Checked ? TargetFrame.Value - 100 : Frame_min.Value);
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
            PerfectIVs = (byte)PerfectIVs.Value,

            Level = (byte)Filter_Lv.Value,
            Slot = Slot.CheckBoxItems.Select(e => e.Checked).ToArray(),
            SpecialOnly = SpecialOnly.Checked,

            BlinkFOnly = BlinkFOnly.Checked,
            SafeFOnly = SafeFOnly.Checked,

            Ball = (byte)Ball.SelectedIndex,
        };

        private IDFilters getIDFilter()
        {
            IDFilters f = new IDFilters();
            if (Filter_SID.Checked) f.IDType = 1;
            else if (Filter_G7TID.Checked) f.IDType = 2;
            f.Skip = ID_Disable.Checked;
            f.RE = ID_RE.Checked;
            f.IDList = ID_List.Lines;
            f.TSVList = TSV_List.Lines;
            f.RandList = RandList.Lines;
            return f;
        }

        private StationaryRNG getStaSettings()
        {
            StationaryRNG setting = Gen6 ? new Stationary6() : (StationaryRNG)new Stationary7();
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

            if (Gen7)
                (setting as Stationary7).blinkwhensync = BlinkWhenSync.Checked;
            else
                (setting as Stationary6).Ability = (byte)(AbilityLocked.Checked ? Ability.SelectedIndex + 1 : 0);

            return setting;
        }

        private EventRNG getEventSetting()
        {
            int[] IVs = new[] { -1, -1, -1, -1, -1, -1 };
            for (int i = 0; i < 6; i++)
                if (EventIVLocked[i].Checked)
                    IVs[i] = (int)EventIV[i].Value;
            if (IVsCount.Value > 0 && IVs.Count(iv => iv >= 0) + IVsCount.Value > 5)
            {
                Error(SETTINGERROR_STR[lindex] + L_IVsCount.Text);
                IVs = new[] { -1, -1, -1, -1, -1, -1 };
            }
            EventRNG e = Gen6 ? (EventRNG)new Event6() : new Event7();
            e.Species = (short)Event_Species.SelectedIndex;
            e.Form = (byte)Event_Forme.SelectedIndex;
            e.Level = (byte)Filter_Lv.Value;
            e.IVs = (int[])IVs.Clone();
            e.IVsCount = (byte)IVsCount.Value;
            e.YourID = YourID.Checked;
            e.PIDType = (byte)Event_PIDType.SelectedIndex;
            e.AbilityLocked = AbilityLocked.Checked;
            e.NatureLocked = NatureLocked.Checked;
            e.GenderLocked = GenderLocked.Checked;
            e.OtherInfo = OtherInfo.Checked;
            e.EC = (uint)Event_EC.Value;
            e.Ability = (byte)Event_Ability.SelectedIndex;
            e.Nature = (byte)Event_Nature.SelectedIndex;
            e.Gender = (byte)Event_Gender.SelectedIndex;
            e.IsEgg = IsEgg.Checked;
            if (e.YourID)
                e.TSV = (ushort)TSV.Value;
            else
            {
                e.TID = (ushort)Event_TID.Value;
                e.SID = (ushort)Event_SID.Value;
                e.TSV = (ushort)((e.TID ^ e.SID) >> 4);
                e.PID = (uint)Event_PID.Value;
            }
            e.GetGenderSetting();
            return e;
        }

        private WildRNG getWildSetting()
        {
            WildRNG setting = Gen6 ? new Wild6() : (WildRNG)new Wild7();
            setting.Synchro_Stat = (byte)(SyncNature.SelectedIndex - 1);
            setting.TSV = (int)TSV.Value;
            setting.ShinyCharm = ShinyCharm.Checked;

            int slottype = 0;
            if (Gen7)
            {
                var setting7 = setting as Wild7;
                if (ea.Locationidx == 1190) slottype = 1; // Poni Plains -4
                setting7.Levelmin = (byte)Lv_min.Value;
                setting7.Levelmax = (byte)Lv_max.Value;
                setting7.SpecialEnctr = (byte)Special_th.Value;
                setting7.UB = CB_Category.SelectedIndex == 1;
                setting7.SpecForm = new int[11];
                setting7.CompoundEye = CompoundEyes.Checked;
                for (int i = 1; i < 11; i++)
                    setting7.SpecForm[i] = slotspecies[EncounterArea7.SlotType[slotspecies[0]][i - 1]];
                if (setting7.SpecialEnctr > 0)
                {
                    setting7.SpecForm[0] = iPM.SpecForm;
                    setting7.SpecialLevel = iPM.Level;
                }
            }
            else if (Gen6)
            {
                var setting6 = setting as Wild6;
                var area = ea as EncounterArea6;
                setting6.SpecForm = new int[13];
                setting6.SlotLevel = new byte[13];
                for (int i = 1; i < 13; i++)
                {
                    setting6.SpecForm[i] = slotspecies[i - 1];
                    setting6.SlotLevel[i] = area.Level[i - 1];
                }
                slottype = 2;
            }

            setting.Markslots();
            setting.SlotSplitter = WildRNG.SlotDistribution[slottype];

            return setting;
        }

        private EggRNG getEggRNG()
        {
            var setting = Gen6 ? null : new Egg7();
            setting.FemaleIVs = IV_Female;
            setting.MaleIVs = IV_Male;
            setting.MaleItem = (byte)M_Items.SelectedIndex;
            setting.FemaleItem = (byte)F_Items.SelectedIndex;
            setting.ShinyCharm = ShinyCharm.Checked;
            setting.TSV = (ushort)TSV.Value;
            setting.Gender = FuncUtil.getGenderRatio((int)Egg_GenderRatio.SelectedValue);
            (setting as Egg7).Homogeneous = Homogeneity.Checked;
            (setting as Egg7).FemaleIsDitto = F_ditto.Checked;
            setting.InheritAbility = (byte)(F_ditto.Checked ? M_ability.SelectedIndex : F_ability.SelectedIndex);
            setting.MMethod = MM.Checked;
            setting.NidoType = NidoType.Checked;

            setting.ConsiderOtherTSV = ConsiderOtherTSV.Checked;
            setting.OtherTSVs = OtherTSVList.ToArray();

            setting.MarkItem();
            return setting;
        }
        #endregion

        #region Start Calculation
        private void AdjustDGVColumns()
        {
            if (method == 4)
            {
                dgv_ID_rand64.Visible = dgv_clock.Visible = dgv_gen7ID.Visible = Gen7;
                dgv_ID_rand.Visible = Gen6;
                dgv_ID_state.Visible = MT.Checked && Gen6;
                return;
            }
            dgv_synced.Visible = method < 3;
            dgv_item.Visible = dgv_Lv.Visible = dgv_slot.Visible = method == 2;
            dgv_rand.Visible = Gen6 || Gen7 && method == 3 && !MainRNGEgg.Checked;
            dgv_status.Visible = Gen6 && method < 2 || Gen7 && method == 3 && !MainRNGEgg.Checked;
            dgv_status.Width = Gen6 ? 65 : 260;
            dgv_ball.Visible = Gen7 && method == 3;
            dgv_adv.Visible = method == 3 && !MainRNGEgg.Checked || IsPokemonLink;
            dgv_shift.Visible = dgv_time.Visible = !IsPokemonLink && (method < 3 || MainRNGEgg.Checked);
            dgv_delay.Visible = dgv_mark.Visible = dgv_rand64.Visible = Gen7 && method < 3 || MainRNGEgg.Checked;
            dgv_eggnum.Visible = EggNumber.Checked;
            dgv_pid.Visible = dgv_psv.Visible = !MainRNGEgg.Visible || MainRNGEgg.Checked;
        }

        private void Search_Click(object sender, EventArgs e)
        {
            if (method == 5) // Gen7 ToolKit
            {
                CalcTime(null, null);
                return;
            }
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
            else
            {
                if (Gen6)
                    Search6();
                else
                    Search7();
                AdjustDGVColumns();
            }
        }

        private static readonly string[] blinkmarks = { "-", "★", "?", "? ★" };
        private static Font BoldFont = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);

        private DataGridViewRow getRow(int i, RNGResult result, int eggnum = -1, int time = -1)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(DGV);

            string true_nature = StringItem.naturestr[result.Nature];
            if (null != ((result as EggResult)?.BE_InheritParents))
                true_nature = ((result as EggResult).BE_InheritParents == true) ? M_ditto.Text : F_ditto.Text;
            string EggNum = eggnum > 0 ? eggnum.ToString() : null;
            string advance = (result as EggResult)?.FramesUsed.ToString("+#") ?? (result as Result6)?.FrameUsed.ToString("+00");
            string delay = (result as Result7)?.FrameDelayUsed.ToString("+#;-#;0");
            byte blink = (result as Result7)?.Blink ?? 0;
            string Mark = blink < 4 ? blinkmarks[blink] : blink.ToString();
            string SynchronizeFlag = result.Synchronize ? "O" : "X";
            string PSV = result.PSV.ToString("D4");

            string slots = (result as WildResult)?.IsSpecial ?? false ? StringItem.gen7wildtypestr[CB_Category.SelectedIndex] : (result as WildResult)?.Slot.ToString();
            string Lv = result.Level == 0 ? "-" : result.Level.ToString();
            string item = (result as WildResult)?.ItemStr;

            string ball = PARENTS_STR[lindex, (result as EggResult)?.Ball ?? (result as MainRNGEgg)?.Ball ?? 0];
            string randstr = (result as Result6)?.RandNum.ToString("X8") ?? (result as EggResult)?.RandNum.ToString("X8");
            string rand64str = (result as Result7)?.RandNum.ToString("X16");
            string shift = time > -1 ? (time - Standard).ToString("+#;-#;0") : null;
            string realtime = time > -1 ? FuncUtil.Convert2timestr(time / 60.0) : null;
            row.Cells[02].Style.Alignment =                                           // Shift
            row.Cells[27].Style.Alignment = DataGridViewContentAlignment.MiddleRight; // Realtime

            string seed = (result as EggResult)?.Status ?? (result as Result6)?.Status;

            int[] Status = ShowStats.Checked ? result.Stats : result.IVs;

            row.SetValues(
                eggnum, i, shift, Mark, advance,
                Status[0], Status[1], Status[2], Status[3], Status[4], Status[5],
                true_nature, SynchronizeFlag, StringItem.hpstr[result.hiddenpower + 1], PSV, StringItem.genderstr[result.Gender], StringItem.abilitystr[result.Ability], delay,
                slots, Lv, ball, item,
                randstr, rand64str, result.PID.ToString("X8"), result.EC.ToString("X8"), seed, realtime
                );

            if (result.Shiny)
                row.DefaultCellStyle.BackColor = Color.LightCyan;

            bool?[] ivsflag = (result as EggResult)?.InheritMaleIV ?? (result as MainRNGEgg)?.InheritMaleIV;
            const int ivstart = 5;
            if (ivsflag != null)
            {
                for (int k = 0; k < 6; k++)
                {
                    if (ivsflag[k] != null)
                    { row.Cells[ivstart + k].Style.ForeColor = (ivsflag[k] == true) ? Color.Blue : Color.DeepPink; continue; }
                    if (result.IVs[k] > 29)
                    { row.Cells[ivstart + k].Style.ForeColor = Color.MediumSeaGreen; row.Cells[ivstart + k].Style.Font = BoldFont; }
                }
                return row;
            }
            for (int k = 0; k < 6; k++)
            {
                if (result.IVs[k] < 1)
                {
                    row.Cells[ivstart + k].Style.Font = BoldFont;
                    row.Cells[ivstart + k].Style.ForeColor = Color.OrangeRed;
                }
                else if (result.IVs[k] > 29)
                {
                    row.Cells[ivstart + k].Style.Font = BoldFont;
                    row.Cells[ivstart + k].Style.ForeColor = Color.MediumSeaGreen;
                }
            }
            return row;
        }

        private DataGridViewRow getIDRow(int i, IDResult rt)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(DGV_ID);
            row.SetValues(
                i, (rt as ID7)?.G7TID.ToString("D6"), rt.TSV.ToString("D4"),
                rt.TID.ToString("D5"), rt.SID.ToString("D5"), (((rt as ID7)?.Clock + Clk_Correction.Value) % 17).ToString(),
                (rt as ID6)?.RandNum.ToString("X8"), (rt as ID7)?.RandNum.ToString("X16"),
                (rt as ID6)?.Status
                );
            return row;
        }
        #endregion

        #region Gen6 Search
        private void Search6()
        {
            if (method == 4)
            {
                Search6_ID();
                return;
            }
            Search6_Normal();
        }

        private IRNG getRNGSource()
        {
            if (MTFast.Checked)
                return new MersenneTwisterFast((uint)Seed.Value, 227);
            if (MTUntempered.Checked)
                return new MersenneTwisterUntempered((int)Seed.Value);

            return new MersenneTwister((uint)Seed.Value);
        }

        private void Search6_Normal()
        {
            var rng = new MersenneTwister((uint)Seed.Value);
            int max, min;
            min = (int)Frame_min.Value;
            max = (int)Frame_max.Value;
            if (AroundTarget.Checked)
            {
                min = (int)TargetFrame.Value - 100; max = (int)TargetFrame.Value + 100;
            }
            // Advance
            for (int i = 0; i < min; i++)
                rng.Next();
            // Prepare
            getsetting(rng);
            // Start
            for (int i = min; i <= max; i++, RNGPool.Next(rng))
            {
                RNGResult result = RNGPool.Generate6();
                if (!filter.CheckResult(result))
                    continue;
                dgvrowlist.Add(getRow(i, result, time: i - min));
                if (dgvrowlist.Count > 100000)
                    break;
            }
            DGV.Rows.AddRange(dgvrowlist.ToArray());
            DGV.CurrentCell = null;
        }

        private void Search6_ID()
        {
            bool tweak = true; // tmp tweak
            var rng = getRNGSource();
            int min = (int)Frame_min.Value;
            int max = (int)Frame_max.Value;
            dgvrowlist.Clear();
            DGV_ID.Rows.Clear();
            IDFilters filter = getIDFilter();
            for (int i = 0; i < min; i++)
                rng.Next();
            for (int i = min; i <= max; i++)
            {
                var result = new ID6(str: (rng as RNGState)?.CurrentState(), rand: rng.Nextuint());
                if (!filter.CheckResult(result))
                    continue;
                if (tweak)
                { Frame_min.Value = i; tweak = false; };
                dgvrowlist.Add(getIDRow(i, result));
                if (dgvrowlist.Count > 100000)
                    break;
            }
            DGV_ID.Rows.AddRange(dgvrowlist.ToArray());
            DGV_ID.CurrentCell = null;
        }
        #endregion

        #region Gen7 Search
        private void Search7()
        {
            if (method == 4)
            {
                Search7_ID();
                return;
            }
            if (method == 3 && !MainRNGEgg.Checked)
            {
                if (EggNumber.Checked)
                    Search7_EggList();
                else
                    Search7_Egg();
                return;
            }
            // method 0-2 & MainRNGEgg
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
                min = (int)TargetFrame.Value - 100; max = (int)TargetFrame.Value + 100;
            }
            min = Math.Max(min, 418);
            // Blinkflag
            FuncUtil.getblinkflaglist(min, max, sfmt, modelnum);
            // Advance
            for (int i = 0; i < min; i++)
                sfmt.Next();
            // Prepare
            ModelStatus status = new ModelStatus(modelnum, sfmt);
            ModelStatus stmp = new ModelStatus(modelnum, sfmt);
            getsetting(sfmt);
            int frameadvance;
            int realtime = 0;
            int frametime = 0;
            // Start
            for (int i = min; i <= max;)
            {
                do
                {
                    frameadvance = status.NextState();
                    realtime++;
                }
                while (frameadvance == 0); // Keep the starting status of a longlife frame(for npc=0 case)
                do
                {
                    RNGPool.CopyStatus(stmp);
                    var result = RNGPool.Generate7() as Result7;

                    RNGPool.Next(sfmt);

                    frameadvance--;
                    i++;
                    if (i <= min || i > max + 1)
                        continue;

                    FuncUtil.MarkResults(result, i - min - 1);

                    if (!filter.CheckResult(result))
                        continue;
                    dgvrowlist.Add(getRow(i - 1, result, time: frametime * 2));
                }
                while (frameadvance > 0);
                if (dgvrowlist.Count > 100000) break;

                // Backup status of frame
                status.CopyTo(stmp);
                frametime = realtime;
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

                var result = RNGPool.Generate7() as Result7;
                FuncUtil.MarkResults(result, i);

                frameadvance = status.NextState();
                frame += frameadvance;
                for (int j = 0; j < frameadvance; j++)
                    RNGPool.Next(sfmt);

                if (!filter.CheckResult(result))
                    continue;

                dgvrowlist.Add(getRow(Currentframe, result, time: i * 2));

                if (dgvrowlist.Count > 100000)
                    break;
            }
            DGV.Rows.AddRange(dgvrowlist.ToArray());
            DGV.CurrentCell = null;
        }

        private void Search7_Egg()
        {
            var rng = new TinyMT(Status);
            int max, min;
            min = (int)Frame_min.Value;
            max = (int)Frame_max.Value;
            // Advance
            for (int i = 0; i < min; i++)
                rng.Next();
            // Prepare
            getsetting(rng);
            // Start
            for (int i = min; i <= max; i++, RNGPool.Next(rng))
            {
                var result = RNGPool.GenerateEgg7() as EggResult;
                if (!filter.CheckResult(result))
                    continue;
                dgvrowlist.Add(getRow(i, result));
                if (dgvrowlist.Count > 100000)
                    break;
            }
            DGV.Rows.AddRange(dgvrowlist.ToArray());
            DGV.CurrentCell = null;
        }

        private void Search7_EggList()
        {
            var rng = new TinyMT(Status);
            int max, min;
            min = (int)Egg_min.Value;
            max = (int)Egg_max.Value;
            int target = (int)TargetFrame.Value;
            bool gotresult = false;
            // Advance
            for (int i = 0; i < min; i++)
                rng.Next();
            TinyMT Seedrng = (TinyMT)rng.DeepCopy();
            // Prepare
            getsetting(rng);
            // Start
            int frame = 0;
            int advance = 0;
            for (int i = 0; i <= max; i++)
            {
                var result = RNGPool.GenerateEgg7() as EggResult;
                advance = result.FramesUsed;
                if (!gotresult && frame <= target && target < frame + advance)
                {
                    Egg_Instruction.Text = getEggListString(i, target - frame);
                    gotresult = true;
                };
                frame += advance;
                for (int j = advance; j > 0; j--)
                    RNGPool.Next(rng);
                if (i < min || !filter.CheckResult(result))
                    continue;
                dgvrowlist.Add(getRow(frame - advance, result, eggnum: i + 1));
                if (dgvrowlist.Count > 100000)
                    break;
            }
            DGV.Rows.AddRange(dgvrowlist.ToArray());
            DGV.CurrentCell = null;
            if (!gotresult)
                Egg_Instruction.Text = getEggListString(-1, -1);
        }

        private void Search7_ID()
        {
            SFMT rng = new SFMT((uint)Seed.Value);
            int min = (int)Frame_min.Value;
            int max = (int)Frame_max.Value;
            dgvrowlist.Clear();
            DGV_ID.Rows.Clear();
            IDFilters filter = getIDFilter();
            for (int i = 0; i < min; i++)
                rng.Next();
            for (int i = min; i <= max; i++)
            {
                var result = new ID7(rng.Nextulong());
                if (!filter.CheckResult(result))
                    continue;
                dgvrowlist.Add(getIDRow(i, result));
                if (dgvrowlist.Count > 100000)
                    break;
            }
            DGV_ID.Rows.AddRange(dgvrowlist.ToArray());
            DGV_ID.CurrentCell = null;
        }

        #endregion
    }
}