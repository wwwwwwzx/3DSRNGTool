using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Pk3DSRNGTool.RNG;
using Pk3DSRNGTool.Core;
using Pk3DSRNGTool.Controls;

namespace Pk3DSRNGTool
{
    public partial class MiscRNGTool : Form
    {
        public MiscRNGTool()
        {
            InitializeComponent();
            UpdateInfo(updategame: true, updateseed: true);
            System.Reflection.PropertyInfo dgvPropertyInfo = typeof(DataGridView).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.SetProperty
                 | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            dgvPropertyInfo.SetValue(dataGridView1, true, null);
            dataGridView1.AutoGenerateColumns = false;
            Range.Maximum = Value.Maximum = uint.MaxValue;
            JumpFrame.Maximum =
            StartingFrame.Maximum = MaxResults.Maximum = FuncUtil.MAXFRAME;
            MaxResults.Value = 200000;

            BallBonus.DisplayMember = "Text";
            BallBonus.ValueMember = "Value";
            BallBonus.DataSource = new BindingSource(BallBonusList, null);

            DexBonus.DisplayMember = "Text";
            DexBonus.ValueMember = "Value";
            DexBonus.DataSource = new BindingSource(DexBonusList, null);

            Status.DisplayMember = "Text";
            Status.ValueMember = "Value";
            Status.DataSource = new BindingSource(StatusBonusList, null);

            CB_CallRate.DisplayMember = "Text";
            CB_CallRate.ValueMember = "Value";
            CB_CallRate.DataSource = new BindingSource(CallRateList, null);

            HPBarColor.DisplayMember = "Text";
            HPBarColor.ValueMember = "Value";
            HPBarColor.DataSource = new BindingSource(HPBarBonusList, null);

            Rank.SelectedIndex = 18;
            Stars.SelectedIndex = 0;
            NPCType.SelectedIndex = 0;
            Color.SelectedIndex = 0;

            OPower.SelectedIndex = 0;

            RNG_SelectedIndexChanged(null, null);
            L_TrainerName.Text = StringItem.ANY_STR[StringItem.language];
        }
        private void MiscRNGTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;
        }

        public void UpdateInfo(int catchrate = -1, int HP = -1, bool updateseed = false, bool updategame = false)
        {
            if (updateseed && RNG.SelectedIndex != 1)
                Seed.Value = (uint)Properties.Settings.Default.Seed;
            if (updategame)
            {
                RNG.SelectedIndex = Properties.Settings.Default.GameVersion > 4 ? 0 : 2;
                Game.SelectedIndex = Properties.Settings.Default.GameVersion > 4 ? Properties.Settings.Default.GameVersion - 5 : 0;
            }
            if (HP > -1)
                HPMax.Value = HP;
            if (catchrate > -1)
                CatchRate.Value = catchrate;
        }

        #region Core
        private List<Frame_Misc> Frames = new List<Frame_Misc>();
        private Misc_Filter filter;
        private void getFilter()
        {
            filter = new Misc_Filter
            {
                Pokerus = RB_Pokerus.Visible && RB_Pokerus.Checked && Filters.SelectedTab == TP_Misc,
                Capture = SuccessOnly.Checked && Filters.SelectedTab == TP_Capture,
                SOSCall = SuccessOnly.Checked && Filters.SelectedTab == TP_SOS,
                CurrentSeed = string.IsNullOrWhiteSpace(CurrentText.Text) || Filters.SelectedTab != TP_Misc ? null : CurrentText.Text.ToUpper(),
                Random = RB_Random.Checked && Filters.SelectedTab == TP_Misc,
                CompareType = (byte)Compare.SelectedIndex,
                Value = (int)Value.Value,
                FacilityFilter = getFacilityFilter,
                TrainerFilter = getTrainerFilter,
            };
        }
        private FPFacility getFacilityFilter => Filters.SelectedTab != TP_FP ? null : new FPFacility
        {
            Star = (byte)Stars.SelectedIndex,
            Type = (sbyte)(int)Facility.SelectedValue,
            NPC = (sbyte)(NPCType.SelectedIndex - 1),
            Color = (sbyte)(Color.SelectedIndex - 1),
        };
        private BTTrainer getTrainerFilter => Filters.SelectedTab != TP_BattleTree ? null : new BTTrainer
        {
            TrainerID = (byte)TrainerID.Value,
        };

        private void B_Calc_Click(object sender, EventArgs e)
        {
            Frames.Clear();
            Frames = new List<Frame_Misc>();
            getFilter();
            Frame_Misc.X64 = RNG.SelectedIndex == 0;
            switch (RNG.SelectedIndex)
            {
                case 0 when !Createtimeline.Checked: Search7(); break;
                case 0 when Createtimeline.Checked: Search7_Timeline(); break;
                case 1: Search7_Battle(); break;
                case 2: Search6(); break;
                case 3: Search6_Battle(); break;
            }
            AdjustDGVColumns();
            RNGPool.Clear();
            GC.Collect();
        }

        #region gen7main
        private bool FestivalPlaza => filter.FacilityFilter != null;
        private bool BattleTree => filter.TrainerFilter != null;
        private bool ShowCapture => Filters.SelectedTab == TP_Capture || Filters.SelectedTab == TP_Misc;
        private bool ShowSOS => Filters.SelectedTab == TP_SOS || Filters.SelectedTab == TP_Misc;
        private ulong N;
        private int Timedelay;
        private void setupgenerator()
        {
            Timedelay = (int)Delay.Value / 2;
            N = (ulong)Range.Value;
            if (FestivalPlaza)
            {
                FPFacility.GameVer = (byte)Game.SelectedIndex;
                FPFacility.Rank = (byte)Rank.SelectedIndex;
            }
            if (BattleTree)
            {
                BTTrainer.GameVer = (byte)Game.SelectedIndex;
                BTTrainer.Steak = (int)Streak.Value;
            }
        }
        private void getspecialinfo(Frame_Misc f)
        {
            RNGPool.time_elapse7(Timedelay);
            f.frameused = RNGPool.index;
            if (FestivalPlaza)
                f.frt = FPFacility.Generate();
            else if (BattleTree)
            {
                RNGPool.modelnumber = 2;
                RNGPool.ResetModelStatus();
                RNGPool.time_elapse7(2);
                f.frameused = RNGPool.index;
                f.trt = BTTrainer.Generate();
            }
            else if (filter.Random)
                f.RandN = (int)(RNGPool.getrand64 % N);
            else if (filter.Pokerus)
                f.Pokerus = Pokerus7.getStrain();
        }

        private void Search7()
        {
            SFMT sfmt = new SFMT(Seed.Value);
            int min = (int)StartingFrame.Value;
            int max = min + (int)MaxResults.Value;
            byte Modelnum = (byte)(NPC.Value + 1);
            setupgenerator();

            FuncUtil.getblinkflaglist(min, max, sfmt, Modelnum);

            for (int i = 0; i < min; i++)
                sfmt.Next();

            ModelStatus status = new ModelStatus(Modelnum, sfmt);
            ModelStatus stmp = new ModelStatus(Modelnum, sfmt);

            RNGPool.CreateBuffer(sfmt);

            int frameadvance;
            int realtime = 0;
            int frametime = 0;

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
                    var f = new Frame_Misc();
                    f.Frame = i;
                    f.Rand64 = RNGPool.getcurrent64;
                    f.Blink = FuncUtil.blinkflaglist[i - min];
                    f.realtime = 2 * frametime;
                    f.status = (int[])stmp.remain_frame.Clone();

                    RNGPool.Rewind(0); RNGPool.CopyStatus(stmp);
                    getspecialinfo(f);

                    RNGPool.AddNext(sfmt);
                    frameadvance--;
                    if (i++ > max)
                        return;
                    if (!filter.check(f))
                        continue;

                    Frames.Add(f);
                }
                while (frameadvance > 0);

                // Backup current status
                status.CopyTo(stmp);
                frametime = realtime;
            }
        }

        private void Search7_Timeline()
        {
            SFMT sfmt = new SFMT(Seed.Value);
            int frame = (int)StartingFrame.Value;
            int loopcount = (int)MaxResults.Value;
            int frameadvance;
            int FirstJumpFrame = (int)JumpFrame.Value;
            FirstJumpFrame = FirstJumpFrame >= frame && Fidget.Checked ? FirstJumpFrame : int.MaxValue;
            setupgenerator();

            FuncUtil.getblinkflaglist(frame, frame, sfmt, (byte)(NPC.Value + 1));

            for (int i = 0; i < frame; i++)
                sfmt.Next();
            ModelStatus status = new ModelStatus((byte)(NPC.Value + 1), sfmt);
            status.raining = Raining.Checked;
            status.IsBoy = Boy.Checked;

            RNGPool.CreateBuffer(sfmt);

            for (int i = 0; i <= loopcount; i++)
            {
                var f = new Frame_Misc();
                f.Frame = frame;
                f.Rand64 = RNGPool.getcurrent64;
                f.realtime = 2 * i;
                f.status = (int[])status.remain_frame.Clone();

                if (frame >= FirstJumpFrame) // Find the first call
                {
                    status.fidget_cd = 1;
                    FirstJumpFrame = int.MaxValue; // Disable this part
                }
                if (status.fidget_cd == 1)
                    f.Blink = 1;

                // USUM v1.1 sub_421E4C eyes closed
                if (status.remain_frame[0] == -3 || status.remain_frame[0] == 33)
                    f.Blink = 4;

                RNGPool.Rewind(0); RNGPool.CopyStatus(status);
                getspecialinfo(f);

                frameadvance = status.NextState();
                frame += frameadvance;
                for (int j = frameadvance; j > 0; j--)
                    RNGPool.AddNext(sfmt);

                if (!filter.check(f))
                    continue;

                Frames.Add(f);
            }
            if (Frames.FirstOrDefault()?.Frame == (int)StartingFrame.Value)
                Frames[0].Blink = FuncUtil.blinkflaglist[0];
        }
        #endregion

        private void Search7_Battle()
        {
            SFMT sfmt = new SFMT(Seed.Value);
            int frame = (int)StartingFrame.Value;
            int loopcount = (int)MaxResults.Value;
            int delay = (int)Delay.Value;
            ulong N = (ulong)Range.Value;

            CaptureResult.Details = SOSResult.Details = CB_Detail.Checked || Filters.SelectedTab == TP_Misc;
            var capture7 = new Capture7();
            if (Filters.SelectedTab == TP_Capture)
            {
                capture7.HPCurr = (uint)HPCurr.Value;
                capture7.HPMax = (uint)HPMax.Value;
                capture7.CatchRate = (byte)CatchRate.Value;
                capture7.StatusBonus = (uint)(int)Status.SelectedValue;
                capture7.BallBonus = (uint)(int)BallBonus.SelectedValue;
                capture7.DexBonus = (uint)(int)DexBonus.SelectedValue;
                capture7.OPowerBonus = RotoCatch.Checked ? 2.5f : 1.0f;
                capture7.Calc();
                var criticalchance = capture7.CriticalRate / 256.0;
                var shakechance = capture7.ShakeRate / 65536.0;
                var capturechance = criticalchance * shakechance + (1 - criticalchance) * Math.Pow(shakechance, 4);
                L_output.Text = CB_Detail.Checked ? string.Format("Critical {0:P}  \tShake {1:P}", criticalchance, shakechance)
                    : string.Format("Critical {0:P}  \tSuccess {1:P}", criticalchance, capturechance);
            }
            else if (Filters.SelectedTab == TP_SOS)
            {
                SOSRNG.ChainLength = (int)ChainLength.Value;
                SOSRNG.Weather = Weather.Checked;

                int Rate1 = (int)CB_CallRate.SelectedValue * (int)HPBarColor.SelectedValue;
                if (AO.Checked)
                    Rate1 *= 2;
                if (Rate1 > 100)
                    Rate1 = 100;
                SOSRNG.Rate1 = (byte)Rate1;

                double Rate2 = (int)CB_CallRate.SelectedValue * (Intimidate.Checked ? 0x4CCC : 0x4000) / 4096.0;
                if (SameCaller.Checked)
                    Rate2 *= 1.5;
                if (SupperEffective.Checked)
                    Rate2 *= 2;
                if (LastCallFail.Checked)
                    Rate2 *= 3;
                if (Rate2 > 100)
                    Rate2 = 100.0;
                SOSRNG.Rate2 = (byte)Math.Round(Rate2);
            }

            for (int i = 0; i < frame; i++)
                sfmt.Nextuint();

            RNGPool.CreateBuffer(sfmt, AutoCheck: false); // Force 32bit

            for (int i = 0; i < loopcount; i++, RNGPool.AddNext(sfmt, AutoCheck: false))
            {
                var f = new Frame_Misc();
                f.Frame = frame++;
                f.Rand32 = RNGPool.getcurrent;

                RNGPool.Rewind(0);
                RNGPool.Advance(delay);
                if (filter.Random)
                    f.RandN = (int)(RNGPool.getrand % N);
                if (ShowCapture)
                {
                    RNGPool.Rewind(0);
                    f.Crt = capture7.Catch();
                }
                if (ShowSOS)
                {
                    RNGPool.Rewind(0);
                    f.Srt = SOSRNG.Generate();
                }

                if (!filter.check(f))
                    continue;

                Frames.Add(f);
            }
        }

        private void Search6()
        {
            MersenneTwister MT = new MersenneTwister(Seed.Value);
            int frame = (int)StartingFrame.Value;
            int loopcount = (int)MaxResults.Value;
            int delay = (int)Delay.Value;
            ulong N = (ulong)Range.Value;

            for (int i = 0; i < frame; i++)
                MT.Next();

            RNGPool.CreateBuffer(MT);

            for (int i = 0; i < loopcount; i++, RNGPool.AddNext(MT))
            {
                var f = new Frame_Misc();
                f.Frame = frame++;
                f.Rand32 = RNGPool.getcurrent;
                f.realtime = i;
                f.st = RNGPool.getcurrentstate;

                RNGPool.Rewind(0);
                RNGPool.Advance(delay);
                if (filter.Random)
                    f.RandN = (int)((RNGPool.getrand * N) >> 32);
                else if (filter.Pokerus)
                    f.Pokerus = Pokerus6.getStrain();

                if (!filter.check(f))
                    continue;

                Frames.Add(f);
            }
        }

        private void Search6_Battle()
        {
            TinyMT tiny = new TinyMT(Seed.Value);
            int frame = (int)StartingFrame.Value;
            int loopcount = (int)MaxResults.Value;
            int delay = (int)Delay.Value;
            ulong N = (ulong)Range.Value;

            CaptureResult.Details = CB_Detail.Checked || Filters.SelectedTab == TP_Misc;
            var capture6 = new Capture6();
            if (Filters.SelectedTab == TP_Capture)
            {
                capture6.HPCurr = (uint)HPCurr.Value;
                capture6.HPMax = (uint)HPMax.Value;
                capture6.CatchRate = (byte)CatchRate.Value;
                capture6.StatusBonus = (uint)(int)Status.SelectedValue;
                capture6.BallBonus = (uint)(int)BallBonus.SelectedValue;
                capture6.DexBonus = (uint)(int)DexBonus.SelectedValue;
                capture6.OPowerBonus = OPowerList[OPower.SelectedIndex];
                capture6.Calc();
                var criticalchance = capture6.CriticalRate / 256.0;
                var shakechance = capture6.ShakeRate / 65536.0;
                var capturechance = criticalchance * shakechance + (1 - criticalchance) * Math.Pow(shakechance, 4);
                L_output.Text = CB_Detail.Checked ? string.Format("Critical {0:P}  \tShake {1:P}", criticalchance, shakechance)
                    : string.Format("Critical {0:P}  \tSuccess {1:P}", criticalchance, capturechance);
            }

            for (int i = 0; i < frame; i++)
                tiny.Nextuint();

            RNGPool.CreateBuffer(tiny);

            for (int i = 0; i < loopcount; i++, RNGPool.AddNext(tiny, AutoCheck: false))
            {
                var f = new Frame_Misc();
                f.Frame = frame++;
                f.Rand32 = RNGPool.getcurrent;
                f.st = RNGPool.getcurrentstate;

                RNGPool.Rewind(0);
                RNGPool.Advance(delay);
                if (filter.Random)
                    f.RandN = (int)(RNGPool.getrand % N);
                if (ShowCapture)
                {
                    RNGPool.Rewind(0);
                    f.Crt = capture6.Catch();
                }

                if (!filter.check(f))
                    continue;

                Frames.Add(f);
            }
        }

        private void AdjustDGVColumns()
        {
            dgv_trainer.Visible =
            dgv_facility.Visible =
            dgv_hit.Visible = dgv_status.Visible =
            dgv_clock.Visible = dgv_blink.Visible =
            dgv_rand64.Visible = RNG.SelectedIndex == 0;
            dgv_facility.Visible &= FestivalPlaza;
            dgv_trainer.Visible &= BattleTree;
            dgv_rand32.Visible = RNG.SelectedIndex != 0;
            dgv_hit.Visible &= Delay.Value > 1;
            dgv_pokerus.Visible = filter.Pokerus;
            dgv_capture.Visible = (RNG.SelectedIndex & 1) == 1 && ShowCapture;
            dgv_adv.Visible = Filters.SelectedTab == TP_SOS;
            dgv_SOS.Visible = RNG.SelectedIndex == 1 && ShowSOS;
            dgv_randn.Visible = filter.Random;
            dgv_realtime.Visible = (RNG.SelectedIndex & 1) == 0;
            dgv_status.Visible = RNG.SelectedIndex > 1;
            dgv_status.Width = RNG.SelectedIndex == 2 ? 78 : 260;
            dataGridView1.DataSource = Frames;
            dataGridView1.CurrentCell = null;
            if (Frames.Count > 0) dataGridView1.FirstDisplayedScrollingRowIndex = 0;
        }
        #endregion

        #region UI Logic
        private void RNG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender == Filters)
            {
                var selected = Filters.SelectedTab;
                if (selected == TP_Misc || selected == TP_Timeline)
                    selected.Controls.Add(B_ResetFrame);
                if (selected == TP_BattleTree || selected == TP_FP)
                    selected.Controls.Add(Game);
                selected.Controls.Add(B_Help);
                if (selected == TP_BattleTree)
                    HelpMdName = "BattleTree";
                else if (selected == TP_FP)
                    HelpMdName = "FestivalPlazaFacilities";
                else if (selected == TP_SOS)
                    HelpMdName = "SOSCall";
                else
                    selected.Controls.Remove(B_Help);
                if (selected == TP_Capture || selected == TP_SOS)
                {
                    selected.Controls.Add(CB_Detail);
                    selected.Controls.Add(SuccessOnly);
                }
            }
            RB_Random.Checked = true;
            RB_Pokerus.Visible = (RNG.SelectedIndex & 1) == 0;
            NPC.Visible = L_NPC.Visible = RNG.SelectedIndex == 0;
            ShowHideTab(TP_Timeline, RNG.SelectedIndex == 0, 0);
            Fidget.Enabled = Raining.Enabled = Boy.Enabled = Girl.Enabled = JumpFrame.Enabled = Createtimeline.Checked;
            ShowHideTab(TP_FP, RNG.SelectedIndex == 0, 2);
            ShowHideTab(TP_BattleTree, RNG.SelectedIndex == 0, 3);
            ShowHideTab(TP_Capture, (RNG.SelectedIndex & 1) == 1, 1);
            RotoCatch.Visible = RNG.SelectedIndex == 1;
            OPower.Visible = RNG.SelectedIndex == 3;
            ShowHideTab(TP_SOS, RNG.SelectedIndex == 1, 2);
        }

        private void ShowHideTab(TabPage tab, bool enable, int index = 1)
        {
            if (enable ^ Filters.TabPages.Contains(tab))
            {
                if (enable)
                    Filters.TabPages.Insert(Math.Min(Filters.TabPages.Count, index), tab);
                else
                    Filters.TabPages.Remove(tab);
            }
        }

        private void Method_CheckedChanged(object sender, EventArgs e)
        {
            Range.Enabled = Compare.Enabled = Value.Enabled = RB_Random.Checked;
        }

        private void B_ResetFrame_Click(object sender, EventArgs e)
        {
            if (Filters.SelectedTab == TP_Misc)
            {
                CurrentText.Text = string.Empty;
                Compare.SelectedIndex = -1;
                Value.Value = Range.Value = 100;
                RB_Random.Checked = true;
            }
            else if (Filters.SelectedTab == TP_Timeline)
            {
                Fidget.Checked = false;
                JumpFrame.Value = 0;
            }
        }

        private void Fidget_CheckedChanged(object sender, EventArgs e)
        {
            JumpFrame.Visible = Boy.Visible = Girl.Visible = Fidget.Checked;
        }

        private void HP_ValueChanged(object sender, EventArgs e)
        {
            if (HPCurr.Value > HPMax.Value)
                HPCurr.Value = HPMax.Value;
        }

        private void FacilityPool_Changed(object sender, EventArgs e)
        {
            int tmp = Facility.SelectedValue == null ? -1 : (int)Facility.SelectedValue;
            var List = FPFacility.getList((byte)Game.SelectedIndex, Stars.SelectedIndex).Select(t => new ComboItem(StringItem.FacilityName[t], t)).ToList();
            List.Insert(0, new ComboItem("-", -1));
            Facility.DisplayMember = "Text";
            Facility.ValueMember = "Value";
            Facility.DataSource = new BindingSource(List, null);
            if (List.Any(t => t.Value == tmp))
                Facility.SelectedValue = tmp;
        }

        private void Trainer_ValueChanged(object sender, EventArgs e)
        {
            L_TrainerName.Text = 192 <= TrainerID.Value ? TrainerID.Value <= 205 ? StringItem.TrainerName[(int)TrainerID.Value - 192] : StringItem.ANY_STR[StringItem.language]
                                                        : string.Empty;
        }

        private void B_Help_Click(object sender, EventArgs e)
            => System.Diagnostics.Process.Start(string.Format(StringItem.GITHUB + "blob/master/Data/{0}.md", HelpMdName));
        private string HelpMdName = "BattleTree";
        #endregion

        #region Control
        private static readonly ComboItem[] StatusBonusList =
        {
            new ComboItem("None", 0x1000),
            new ComboItem("Poisoned", 0x1800),
            new ComboItem("Paralyzed", 0x1800),
            new ComboItem("Burned", 0x1800),
            new ComboItem("Asleep", 0x2800),
            new ComboItem("Frozen", 0x2800),
        };
        private static readonly ComboItem[] BallBonusList =
        {
            new ComboItem("x1.0", 0x1000), // Poke
            new ComboItem("x1.5", 0x1800), // Great Level
            new ComboItem("x2.0", 0x2000), // Ultra
            new ComboItem("x3.0", 0x3000), // Past-gen
            new ComboItem("x3.5", 0x3800), // Net Repeat Dive Dusk
            new ComboItem("x4.0", 0x4000), // Level Moon Fast Timer
            new ComboItem("x5.0", 0x5000), // Lure Quick Beast
            new ComboItem("x8.0", 0x8000), // Level Love Nest
            new ComboItem("x0.1", 0x019A), // UB
        };
        private static readonly ComboItem[] DexBonusList =
        {
            new ComboItem(">600", 0x2800),
            new ComboItem("451-600", 0x2000),
            new ComboItem("301-450", 0x1800),
            new ComboItem("151-300", 0x1000),
            new ComboItem("031-150", 0x0800),
            new ComboItem("<=30", 0x0000),
        };
        private static readonly float[] OPowerList = { 1.0f, 1.5f, 2.0f, 2.5f };

        private static readonly ComboItem[] CallRateList = new[] { 3, 6, 9, 15, 0, }.Select(t => new ComboItem(t.ToString(), t)).ToArray();
        private static readonly ComboItem[] HPBarBonusList =
        {
            new ComboItem("Red <=1/5", 5),
            new ComboItem("Yellow 1/5~1/2", 3),
            new ComboItem("Green >1/2", 1),
        };
        #endregion
    }
}
