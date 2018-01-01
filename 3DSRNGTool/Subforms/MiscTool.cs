using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Pk3DSRNGTool.RNG;
using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool.Subforms
{
    public partial class MiscTool : Form
    {
        public MiscTool()
        {
            InitializeComponent();
            RNG.SelectedIndex = Program.mainform.Ver > 4 ? 0 : 2;
            Seed.Value = Program.mainform.globalseed;
            System.Reflection.PropertyInfo dgvPropertyInfo = typeof(DataGridView).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.SetProperty
                 | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            dgvPropertyInfo.SetValue(dataGridView1, true, null);
            dataGridView1.AutoGenerateColumns = false;
            Range.Maximum = Value.Maximum = uint.MaxValue;
            JumpFrame.Maximum =
            StartingFrame.Maximum = MaxResults.Maximum = FuncUtil.MAXFRAME;
            MaxResults.Value = 200000;
        }

        private List<Frame_Misc> Frames = new List<Frame_Misc>();
        private Misc_Filter filter;
        private void getFilter()
        {
            filter = new Misc_Filter
            {
                Pokerus = RB_Pokerus.Visible && RB_Pokerus.Checked,
                Capture = RB_Capture.Visible && RB_Capture.Checked,
                CurrentSeed = string.IsNullOrWhiteSpace(CurrentText.Text) ? null : CurrentText.Text.ToUpper(),
                Random = RB_Random.Checked,
                CompareType = (byte)Compare.SelectedIndex,
                Value = (int)Value.Value,
            };
        }

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
            }
            AdjustDGVColumns();
            RNGPool.Clear();
            GC.Collect();
        }

        private void Search7()
        {
            SFMT sfmt = new SFMT(Seed.Value);
            int min = (int)StartingFrame.Value;
            int max = min + (int)MaxResults.Value;
            int delay = (int)Delay.Value / 2;
            ulong N = (ulong)Range.Value;
            byte Modelnum = (byte)(NPC.Value + 1);

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
                    RNGPool.time_elapse7(delay);
                    f.frameused = RNGPool.index;
                    if (filter.Random)
                        f.RandN = (int)(RNGPool.getrand64 % N);
                    else if (filter.Pokerus)
                        f.Pokerus = Pokerus7.getStrain();

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
            int delay = (int)Delay.Value / 2;
            ulong N = (ulong)Range.Value;
            int frameadvance;
            int FirstJumpFrame = (int)JumpFrame.Value;
            FirstJumpFrame = FirstJumpFrame >= frame && Fidget.Checked ? FirstJumpFrame : int.MaxValue;

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
                RNGPool.time_elapse7(delay);
                f.frameused = RNGPool.index;
                if (filter.Random)
                    f.RandN = (int)(RNGPool.getrand64 % N);
                else if (filter.Pokerus)
                    f.Pokerus = Pokerus7.getStrain();

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

        private void Search7_Battle()
        {
            SFMT sfmt = new SFMT(Seed.Value);
            int frame = (int)StartingFrame.Value;
            int loopcount = (int)MaxResults.Value;
            int delay = (int)Delay.Value;
            ulong N = (ulong)Range.Value;

            var capture7 = new Capture7();

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
                else if (filter.Capture)
                    f.Crt = capture7.Catch();

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

        private void AdjustDGVColumns()
        {
            dgv_hit.Visible = dgv_status.Visible =
            dgv_clock.Visible = dgv_blink.Visible =
            dgv_rand64.Visible = RNG.SelectedIndex == 0;
            dgv_rand32.Visible = RNG.SelectedIndex != 0;
            dgv_hit.Visible &= Delay.Value > 1;
            dgv_pokerus.Visible = filter.Pokerus;
            dgv_capture.Visible = filter.Capture;
            dgv_randn.Visible = filter.Random;
            dgv_realtime.Visible = RNG.SelectedIndex != 1;
            dataGridView1.DataSource = Frames;
            dataGridView1.CurrentCell = null;
            if (Frames.Count > 0) dataGridView1.FirstDisplayedScrollingRowIndex = 0;
        }

        private void RNG_SelectedIndexChanged(object sender, EventArgs e)
        {
            RB_Random.Checked = true;
            Fidget.Enabled = Raining.Enabled = Boy.Enabled = Girl.Enabled = JumpFrame.Enabled = Createtimeline.Checked;
            RB_Pokerus.Visible = RNG.SelectedIndex != 1;
            RB_Capture.Visible = RNG.SelectedIndex == 1;
            Createtimeline.Checked &=
            L_NPC.Visible = NPC.Visible = Createtimeline.Enabled = RNG.SelectedIndex == 0;
        }

        private void Method_CheckedChanged(object sender, EventArgs e)
        {
            Range.Enabled = Compare.Enabled = Value.Enabled = RB_Random.Checked;
        }

        private void B_ResetFrame_Click(object sender, EventArgs e)
        {
            switch (Filters.SelectedIndex)
            {
                case 0:
                    CurrentText.Text = string.Empty;
                    Compare.SelectedIndex = -1;
                    Value.Value = Range.Value = 100;
                    RB_Random.Checked = true;
                    break;
                case 1:
                    Fidget.Checked = false;
                    JumpFrame.Value = 0;
                    break;
            }
        }

        private void Fidget_CheckedChanged(object sender, EventArgs e)
        {
            JumpFrame.Visible = Boy.Visible = Girl.Visible = Fidget.Checked;
        }
    }
}
