using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Pk3DSRNGTool.Controls;

namespace Pk3DSRNGTool
{
    public partial class TinyTimelineTool : Form
    {
        #region Basic UI
        public static readonly int[] typelist = { -1, 0, 1, 3, 4, 5, 6, };
        private const string FRAME = "Frame";
        private const string TYPE = "Type";
        public static readonly string[] typestrlist = { "-", "Blink(+2)", "Blink(+1)", "Stretch", "Soaring", "XY ID", "Running NPC", };
        private IEnumerable<ComboBox> getTypeList()
        {
            for (int i = 1; i <= TypeNum.Maximum; i++)
                yield return ((ComboBox)Controls.Find(TYPE + i.ToString(), true).First());
        }
        private IEnumerable<NumericUpDown> getFrameList()
        {
            for (int i = 1; i <= TypeNum.Maximum; i++)
                yield return ((NumericUpDown)Controls.Find(FRAME + i.ToString(), true).First());
        }

        private static readonly string[] methodlist = { "Instant Sync", "Cutscenes Sync", "Horde", "Friend Safari", "Poke Radar", "Fishing", "Rock Smash", "Cave Shadow", "Normal Wild", "XY ID RNG" };
        public TinyTimelineTool()
        {
            InitializeComponent();
            MainDGV.AutoGenerateColumns = false;
            TypeNum.Maximum = 4; TypeNum.Minimum = 1;
            UpdateTypeComboBox(typelist);
            TargetFrame.Maximum = FuncUtil.MAXFRAME;
            foreach (var c in getFrameList())
            {
                c.Maximum = FuncUtil.MAXFRAME;
                c.Value = 500;
            }
        }
        public void Translate()
        {
            this.TranslateInterface();
            Method.Items.Clear();
            Method.Items.AddRange(methodlist.Select(s => StringItem.Translate(s)).ToArray());
            Method.SelectedIndex = 0;
        }
        public void UpdateTypeComboBox(int[] type)
        {
            var List = typelist.Select((t, i) => new ComboItem(typestrlist[i], t)).Where(t => type.Contains(t.Value));
            foreach (var c in getTypeList())
            {
                c.DisplayMember = "Text";
                c.ValueMember = "Value";
                c.DataSource = new BindingSource(List.Skip(c == Type1 ? 1 : 0), null);
                c.SelectedIndex = 0;
            }
        }
        private void TinyTimelineTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;
        }
        public uint[] Gen6Tiny
        {
            get => new[] { tiny0.Value, tiny1.Value, tiny2.Value, tiny3.Value };
            set
            {
                if (value.Length < 4) return;
                tiny0.Value = value[0]; tiny1.Value = value[1];
                tiny2.Value = value[2]; tiny3.Value = value[3];
            }
        }
        private bool IsORAS => Program.mainform.IsORAS && new[] { 2, 5, 6, 8 }.Contains(Method.SelectedIndex);
        public bool HasSeed => Gen6Tiny.Any(t => t != 0);
        private void Update_Click(object sender, EventArgs e)
        {
            if (!NTRHelper.ntrclient?.Connected ?? true)
            {
                Program.mainform.TryToConnectNTR(false);
                return;
            }
            if (B_Stop.Visible)
                return;
            NTRHelper.ntrclient.ReadTiny("TTT");
        }
        public List<int> SkipList = new List<int>();
        public void Calibrate(int type, int Curr, int Next)
        {
            if (SkipList.Count == TypeNum.Value || type < 0 || type > 6)    // All used
            {
                B_Stop_Click(null, null);
                return;
            }
            if (SkipList.IndexOf(Curr) > -1) // Skip
                SkipList[SkipList.IndexOf(Curr)] = Next;
            else
            {
                SkipList.Add(Next);
                ((NumericUpDown)Controls.Find(FRAME + SkipList.Count.ToString(), true).FirstOrDefault()).Value = Curr;
                try { ((ComboBox)Controls.Find(TYPE + SkipList.Count.ToString(), true).FirstOrDefault()).SelectedValue = type; } catch { };
                B_Create_Click(null, null);
            }
            return;
        }

        private void B_Cali_Click(object sender, EventArgs e)
        {
            if (!NTRHelper.ntrclient?.DebuggerEnabled ?? true)
            {
                if (FormUtil.Prompt(MessageBoxButtons.RetryCancel, "Connection lost, please double check your setup:\n(1) Disable PSS communications.\n(2) Use One Click function.") == DialogResult.Retry)
                    Program.mainform.TryToConnectNTR(true);
                return;
            }
            NTRHelper.ntrclient.ReadTiny("TTT");
            B_Stop.Visible = true;
            B_Cali.Visible = false;
            SkipList.Clear();
            foreach (var c in getTypeList().Skip(1))
                c.SelectedValue = -1;
            NTRHelper.ntrclient.EnableBP((int)Type1.SelectedValue == 4);
        }
        private void Cry_EnabledChanged(object sender, EventArgs e)
        {
            Cry.Checked &= Cry.Enabled;
        }
        private void B_Stop_Click(object sender, EventArgs e)
        {
            B_Stop.Visible = false;
            B_Cali.Visible = true;
            NTRHelper.ntrclient.DisableBP();
            SkipList.Clear();
        }
        private void TypeNum_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 1; i <= TypeNum.Maximum; i++)
            {
                Controls.Find(FRAME + i.ToString(), true).First().Enabled = i <= TypeNum.Value;
                Controls.Find(TYPE + i.ToString(), true).First().Enabled = i <= TypeNum.Value;
            }
        }
        private void Type_EnabledChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox type && type.Enabled == false)
                type.SelectedValue = -1;
        }
        #endregion

        private List<Frame_Tiny> list = new List<Frame_Tiny>();

        private void B_Create_Click(object sender, EventArgs e)
        {
            list.Clear();
            list = new List<Frame_Tiny>();
            Frame_Tiny.Startingframe = (int)Frame1.Value;
            var state = gettimeline();
            state.Generate(splittimeline: ConsiderDelay.Checked);
            list = state.results;
            MainDGV.DataSource = list;
            MainDGV.CurrentCell = null;
            int target = (int)TargetFrame.Value;
            if (ConsiderDelay.Checked && list.Count > 0)
            {
                int targetframeindex = list.FindIndex(t => t.framemin < target && target <= t.framemax);
                if (targetframeindex > 0)
                {
                    MainDGV.FirstDisplayedScrollingRowIndex = Math.Max(0, targetframeindex - 5);
                    MainDGV.Rows[targetframeindex].Selected = true;
                }
            }
            Method_Changed();
        }

        public TinyTimeline gettimeline()
        {
            var line = new TinyTimeline(Gen6Tiny)
            {
                Startingframe = (int)Frame1.Value,
                Maxframe = (int)TargetFrame.Value + 5000,
                CryFrame = Cry.Checked ? (int)CryFrame.Value : -1,
                Delay = ConsiderDelay.Checked ? (int)Delay.Value : 0,
                Method = (byte)Method.SelectedIndex,
                P1 = (int)Parameter1.Value,
                P2 = Parameter2.Visible ? (int)Parameter2.Value : 0,
                IsORAS = IsORAS,
                Boost = Boost.Checked,
            };
            line.Add((int)Frame1.Value, (int)Type1.SelectedValue);
            var frame = Frame1.Value;
            for (int i = 2; i <= TypeNum.Maximum; i++)
            {
                var f = (NumericUpDown)Controls.Find(FRAME + i.ToString(), true).First();
                var t = (ComboBox)Controls.Find(TYPE + i.ToString(), true).First();
                if (!f.Enabled || f.Value < frame || (int)t.SelectedValue == -1)
                    return line;
                frame = f.Value;
                line.Add((int)f.Value, (int)t.SelectedValue);
            }
            return line;
        }

        private void MainDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int index = e.RowIndex;
            if (list.Count <= index)
                return;
            var row = MainDGV.Rows[index];
            if (tiny_enctr.Visible && list[index].enctr < Frame_Tiny.thershold && Frame_Tiny.thershold < 50)
                row.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
            if (!Boost.Checked && list[index].radar?.music < 2)
                row.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
            if (list[index].radar?.Shiny == true)
                row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
        }

        private void SetAsCurrent_Click(object sender, EventArgs e)
        {
            try
            {
                var seed = (string)MainDGV.CurrentRow.Cells["dgv_state"].Value;
                Gen6Tiny = FuncUtil.SeedStr2Array(seed) ?? Gen6Tiny;
            }
            catch (NullReferenceException)
            {
            }
        }

        private void Method_Changed()
        {
            int method = Method.SelectedIndex;
            bool Wild = method > 1 && method != 9;
            tiny_enctr.Visible = method == 3 || method > 4 && method != 9;
            dgv_slot.Visible = dgv_item.Visible = Wild;
            bool horde = method == 2;
            tiny_ha.Visible = horde;
            tiny_flute.Width = horde ? 60 : 40;
            dgv_item.Width = horde ? 125 : 40;
            dgv_bgm.Visible = method == 4;
            tiny_flute.Visible = IsORAS;
            tiny_rand100.Visible = !ConsiderDelay.Checked;
            tiny_hitidx.Visible = ConsiderDelay.Checked;
        }

        private void MainDGV_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    var hti = MainDGV.HitTest(e.X, e.Y);
                    MainDGV.ClearSelection();
                    MainDGV.CurrentCell = MainDGV.Rows[hti.RowIndex].Cells[hti.ColumnIndex];
                }
            }
            catch { };
        }

        private void Method_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boost.Visible =
            L_PartySize.Visible = L_SlotNum.Visible = L_Rate.Visible = L_Length.Visible = false;
            ConsiderDelay.Enabled = Delay.Enabled = true;
            Cry.Enabled = CryFrame.Enabled = false;
            Cry.Checked = false;
            CryFrame.Value = 0;
            TypeNum.Value = 1;
            UpdateTypeComboBox(new[] { -1, 0, 1, 3 });
            switch (Method.SelectedIndex)
            {
                case 0: // Instant Sync
                    Cry.Enabled = CryFrame.Enabled = true;
                    break;
                case 1: // Portal/soaring
                    L_PartySize.Visible = true;
                    UpdateTypeComboBox(new[] { -1, 0, 1, 3, 4 });
                    Cry.Enabled = CryFrame.Enabled = true;
                    break;
                case 2: // Horde
                    L_PartySize.Visible = true;
                    ConsiderDelay.Enabled = Delay.Enabled = false;
                    ConsiderDelay.Checked = false;
                    Delay.Value = 0;
                    break;
                case 3: // FS
                    L_SlotNum.Visible = L_Rate.Visible = true;
                    Parameter2.Value = 13;
                    Delay.Value = 6;
                    break;
                case 4: // Pokeradar
                    Boost.Visible =
                    L_PartySize.Visible =
                    L_Length.Visible = true;
                    Delay.Value = 14;
                    break;
                case 5: // Fishing
                    L_PartySize.Visible = L_Rate.Visible = true;
                    Parameter2.Value = 98;
                    UpdateTypeComboBox(new[] { -1, 0, 1 });
                    Delay.Enabled = false;
                    ConsiderDelay.Checked = true;
                    Delay.Value = 14;
                    break;
                case 6: // Rock Smash
                    UpdateTypeComboBox(new[] { -1, 0, 1 });
                    ConsiderDelay.Checked = true;
                    break;
                case 7: // Cave Shadow
                    TypeNum.Value = 2;
                    Delay.Enabled = false;
                    Delay.Value = 78;
                    Cry.Checked = true;
                    CryFrame.Value = 32;
                    break;
                case 8: // Normal Wilds
                    L_Rate.Visible = true;
                    Parameter2.Value = 1;
                    UpdateTypeComboBox(new[] { -1, 0, 1, 3, 6 });
                    Delay.Value = 6;
                    break;
                case 9: // XY ID
                    TypeNum.Value = 4;
                    UpdateTypeComboBox(new[] { -1, 5 });
                    Delay.Value = 724;
                    break;
            }
        }

        private void MainDGV_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                DGVToolTip.Hide(this);
                DGVToolTip.ToolTipTitle = null;
                return;
            }
            System.Drawing.Rectangle cellRect = MainDGV.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            if (list[e.RowIndex].radar != null)
            {
                DGVToolTip.ToolTipTitle = $"Pokeradar Result of Index{list[e.RowIndex].Index}:";
                DGVToolTip.Show(string.Format(string.Join("\n", list[e.RowIndex].radar.Overview))
                    , this,
                    MainDGV.Location.X + cellRect.X + cellRect.Size.Width,
                    MainDGV.Location.Y + cellRect.Y + cellRect.Size.Height,
                    8000);
                return;
            }
            DGVToolTip.Hide(this);
        }

        private void L_PartySize_VisibleChanged(object sender, EventArgs e)
        {
            if (Parameter1.Visible = L_PartySize.Visible)
            {
                Parameter1.Maximum = 6;
                Parameter1.Minimum = 1;
                Parameter1.Value = 6;
            }
        }
        private void L_SlotNum_VisibleChanged(object sender, EventArgs e)
        {
            if (Parameter1.Visible = L_SlotNum.Visible)
            {
                Parameter1.Maximum = 3;
                Parameter1.Minimum = 2;
                Parameter1.Value = 3;
            }
        }
        private void L_Rate_VisibleChanged(object sender, EventArgs e)
        {
            if (Parameter2.Visible = L_Rate.Visible)
                Parameter2.Maximum = 99;
        }
        private void L_Length_VisibleChanged(object sender, EventArgs e)
        {
            if (Parameter2.Visible = L_Length.Visible)
                Parameter2.Maximum = 255;
        }
    }
}
