using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Pk3DSRNGTool.RNG;

namespace Pk3DSRNGTool
{
    public partial class TinyTimelineTool : Form
    {
        public TinyTimelineTool()
        {
            InitializeComponent();
            MainDGV.AutoGenerateColumns = false;
        }

        private List<Frame_Tiny> list = new List<Frame_Tiny>();

        private void B_Create_Click(object sender, EventArgs e)
        {
            list.Clear();
            list = new List<Frame_Tiny>();
            var state = gettimeline();
            list = state.Generate(10000);
            MainDGV.DataSource = list;
            MainDGV.CurrentCell = null;
        }

        public TinyTimeline gettimeline()
        {
            var line = new TinyTimeline()
            {
                Tinyrng = new TinyMT(Gen6Tiny),
                Startingframe = (int)Frame1.Value,
            };
            line.Add((int)Frame1.Value, 0);
            return line;
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

        private void B_update_Click(object sender, EventArgs e)
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
    }
}
