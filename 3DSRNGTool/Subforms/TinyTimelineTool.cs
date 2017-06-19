using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pk3DSRNGTool.RNG;

namespace Pk3DSRNGTool
{
    public partial class TinyTimelineTool : Form
    {
        public TinyTimelineTool()
        {
            InitializeComponent();
        }

        private List<Frame_Tiny> list = new List<Frame_Tiny>();

        private void B_Create_Click(object sender, EventArgs e)
        {
            list.Clear();
            list = new List<Frame_Tiny>();
            var state = new TinyMT(new[] { (uint)tiny0.Value, (uint)tiny1.Value, (uint)tiny2.Value, (uint)tiny3.Value });
            var NextCall = new TinyCallList();
            int mainframe = (int)Frame1.Value - 2;
            NextCall.Add((int)Frame1.Value, 0);
            for (int i = 0; i < 10000; i++)
            {
                var newdata = new Frame_Tiny();
                newdata.Frame = i;
                newdata.state = state.CurrentState();
                newdata.framemin = mainframe;
                var call = NextCall.First();
                mainframe = newdata.framemax = call.frame;
                newdata.rand = state.Nextuint();
                switch (call.type)
                {
                    case 0:
                        NextCall.Addfront(mainframe, newdata.rand < 0x55555556 ? 1 : 2);
                        break;
                    case 1:
                        NextCall.Addfront(mainframe + getcooldown2(newdata.rand), 2);
                        break;
                    case 2:
                        NextCall.Addfront(mainframe + getcooldown1(newdata.rand), 0);
                        break;
                    case 3:
                        NextCall.Addfront(mainframe + 180, 3);
                        break;
                }
                list.Add(newdata);
            }
            MainDGV.DataSource = list;
            MainDGV.CurrentCell = null;
        }

        public static int getcooldown1(uint rand) => (int)((((rand * 60ul) >> 32) * 2 + 124));
        public static int getcooldown2(uint rand) => rand < 0x55555556 ? 20 : 12;
        
        private void Update(uint[] tiny)
        {
            tiny0.Value = tiny[0];
            tiny1.Value = tiny[1];
            tiny2.Value = tiny[2];
            tiny3.Value = tiny[3];
        }

        private void B_update_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.ntrclient.connectToServer();
                byte[] tiny = MainForm.ntrclient.ReadTiny();
                if (tiny == null) { return; }
                Update(new uint[]
                {
                BitConverter.ToUInt32(tiny, 0),
                BitConverter.ToUInt32(tiny, 4),
                BitConverter.ToUInt32(tiny, 8),
                BitConverter.ToUInt32(tiny, 12),
                });
            }
            catch
            {
            }
        }
    }
}
