using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Pk3DSRNGTool.RNG;
using Pk3DSRNGTool.Controls;

namespace Pk3DSRNGTool
{
    public partial class TinyTimelineTool : Form
    {

        #region Basic UI
        public TinyTimelineTool()
        {
            InitializeComponent();
            MainDGV.AutoGenerateColumns = false;
            int[] typelist = { -1, 0, 2, 3, 4 };
            string[] typestrlist = { "-", "Blink(+2)", "Blink(+1)", "Stretch", "Soaring", };
            var List = typelist.Select((t, i) => new ComboItem(typestrlist[i], t));
            Type1.DisplayMember = "Text";
            Type1.ValueMember = "Value";
            Type1.DataSource = new BindingSource(List.Skip(1), null);
            Type2.DisplayMember = "Text";
            Type2.ValueMember = "Value";
            Type2.DataSource = new BindingSource(List, null);
            Type3.DisplayMember = "Text";
            Type3.ValueMember = "Value";
            Type3.DataSource = new BindingSource(List, null);
            Method.SelectedIndex =
            Type3.SelectedIndex =
            Type2.SelectedIndex = 
            Type1.SelectedIndex = 0;
        }
        private void TinyTimelineTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;
        }
        public uint[] Gen6Tiny
        {
            get => new[] { (uint)tiny0.Value, (uint)tiny1.Value, (uint)tiny2.Value, (uint)tiny3.Value };
            private set
            {
                if (value.Length < 4) return;
                tiny0.Value = value[0]; tiny1.Value = value[1];
                tiny2.Value = value[2]; tiny3.Value = value[3];
            }
        }
        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.ntrclient.connectToServer();
                byte[] tiny = MainForm.ntrclient.ReadTiny();
                if (tiny == null) { return; }
                Gen6Tiny = new[]
                {
                BitConverter.ToUInt32(tiny, 0),
                BitConverter.ToUInt32(tiny, 4),
                BitConverter.ToUInt32(tiny, 8),
                BitConverter.ToUInt32(tiny, 12),
                };
            }
            catch
            {
            }
        }
        #endregion

        private List<Frame_Tiny> list = new List<Frame_Tiny>();

        private void B_Create_Click(object sender, EventArgs e)
        {
            list.Clear();
            list = new List<Frame_Tiny>();
            var state = gettimeline();
            state.Generate();
            switch (Method.SelectedIndex)
            {
                case 0: state.MarkFS(); break;
                case 2: state.MarkSync(); break;
            }
            list = state.results;
            MainDGV.DataSource = list;
            MainDGV.CurrentCell = null;
            Method_Changed();
        }

        public TinyTimeline gettimeline()
        {
            var line = new TinyTimeline()
            {
                Tinyrng = new TinyMT(Gen6Tiny),
                Startingframe = (int)Frame1.Value,
                Maxframe = (int)Frame_max.Value,
            };
            line.Add((int)Frame1.Value, (int)Type1.SelectedValue);
            line.Add((int)Frame2.Value, (int)Type2.SelectedValue);
            line.Add((int)Frame3.Value, (int)Type3.SelectedValue);
            for (int i = (int)Shift.Value; i > 0; i--)
                line.Add((int)Frame_J.Value, 5);
            return line;
        }

        private void MainDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int index = e.RowIndex;
            if (list.Count <= index)
                return;
            var row = MainDGV.Rows[index];
            if (Method.SelectedIndex == 0 && list[index]._fs > 0)
                row.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
            if (Method.SelectedIndex == 1 && list[index].High16bit < 9)
                row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
            if (Method.SelectedIndex == 2 && list[index]._sync)
                row.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
        }

        private void copyStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var seed = (string)MainDGV.CurrentRow.Cells["tiny_state"].Value;
                Gen6Tiny = FuncUtil.SeedStr2Array(seed) ?? Gen6Tiny;
            }
            catch (NullReferenceException)
            {
            }
        }

        private void Method_Changed()
        {
            tiny_friendsafari.Visible = Method.SelectedIndex == 0;
            tiny_high16bit.Visible = Method.SelectedIndex == 1;
            tiny_slot.Visible = Method.SelectedIndex == 1;
            tiny_portalsync.Visible = Method.SelectedIndex == 2;
            tiny_sync.Visible = Method.SelectedIndex != 2;
        }
    }
}
