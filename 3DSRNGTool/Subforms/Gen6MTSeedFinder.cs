using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static Pk3DSRNGTool.FormUtil;

namespace Pk3DSRNGTool
{
    public partial class Gen6MTSeedFinder : Form
    {
        private MTSeedFinder mtfinder;

        public Gen6MTSeedFinder()
        {
            InitializeComponent();
            this.TranslateInterface();
            DGV_Seed.AutoGenerateColumns = false;
            Wild_Nature.Items.AddRange(StringItem.naturestr);
            Wild_Nature.SelectedIndex = 0;
        }
        private void Gen6MTSeedFinder_FormClosing(object sender, FormClosingEventArgs e)
            => mtfinder?.Abort();

        private void B_MTSearch_Click(object sender, EventArgs e)
        {
            if (mtfinder == null)
            {
                mtfinder = new MTSeedFinder();
                mtfinder.Update += UpdateProgressBar6;
                mtfinder.NewResult += UpdateDGV6;
            }
            var seedmin = Seed_min.Value;
            var seedmax = Seed_max.Value;
            if (RB_2Wild.Checked)
            {
                var IV1 = FuncUtil.parseIVs(WildIV1.Text);
                var IV2 = FuncUtil.parseIVs(WildIV2.Text);
                var min1 = (int)Wild1_Fmin.Value;
                var max1 = (int)Wild1_Fmax.Value;
                var min2 = (int)Wild2_Fmin.Value;
                var max2 = (int)Wild2_Fmax.Value;
                if (IV1 == null || IV2 == null || min1 > max1 || max1 > min2 || min2 > max2 || seedmin > seedmax)
                {
                    Error("Invalid Input");
                    return;
                }
                mtfinder.setFinder(IV1, min1, max1, IV2, min2, max2);
            }
            else if (RB_1Wild.Checked)
            {
                var IVupper = FuncUtil.parseIVs(Wild_upper.Text);
                var IVlower = FuncUtil.parseIVs(Wild_lower.Text);
                var min = (int)Wild_min.Value;
                var max = (int)Wild_max.Value;
                var nature = (byte)Wild_Nature.SelectedIndex;
                if (IVupper == null || IVlower == null || min > max || seedmin > seedmax)
                {
                    Error("Invalid Input");
                    return;
                }
                for (int i = 0; i < 6; i++)
                    if (IVupper[i] < IVlower[i] || IVupper[i] > IVlower[i] + 2)
                    {
                        Error("Improper IVs Range");
                        return;
                    }
                if (seedmax > seedmin + 0x10000000ul)
                {
                    Error("Seed Range too large");
                    return;
                }
                mtfinder.setFinder2(IVlower, IVupper, min, max, nature);
            }
            else
                return;
            Gen6PBar.Value = 0;
            L_Progress6.Text = "0.00%";
            mtfinder.Clear();
            mtfinder.Search(seedmin, seedmax, RB_2Wild.Checked);
            Gen6PBar.Maximum = mtfinder.Max;
            AdjustDGVSeedColumn();
            DGV_Seed.CurrentCell = null;
            DGV_Seed.DataSource = new BindingSource(new List<Frame_Seed>(), null);
            B_Search.Visible = false;
            B_Abort.Visible = true;
            RB_1Wild.Enabled = RB_2Wild.Enabled = false;
        }

        private void B_Abort6_Click(object sender, EventArgs e)
        {
            mtfinder.Abort();
            B_Search.Visible = true;
            B_Abort.Visible = false;
            RB_1Wild.Enabled = RB_2Wild.Enabled = true;
            L_Progress6.Text = sender == B_Abort ? "Cancelled" : "Done";
            if (mtfinder.seedlist.Count == 1)
                Program.mainform.globalseed = mtfinder.seedlist[0].Seed;
            Alert($"Found {mtfinder.seedlist.Count} Frame(s)");
        }

        private void UpdateProgressBar6(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                Gen6PBar.Value = mtfinder.Cnt;
                L_Progress6.Text = (mtfinder.Cnt / (mtfinder.Max / 100.00)).ToString("F2") + "%";
                if (mtfinder.Cnt == mtfinder.Max)
                    B_Abort6_Click(null, null);
            }));
        }

        private void UpdateDGV6(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                DGV_Seed.DataSource = new BindingSource(mtfinder.seedlist, null);
                DGV_Seed.CurrentCell = null;
            }));
        }

        private void AdjustDGVSeedColumn()
        {
            DGV_Seed.Columns["dgv_Seed_frame2"].Visible = DGV_Seed.Columns["dgv_Seed_nature2"].Visible = RB_2Wild.Checked;
            DGV_Seed.Columns["dgv_Seed_gender"].Visible = RB_1Wild.Checked;
        }
        
        private void RB_CheckedChanged(object sender, EventArgs e)
        {
            WildPanel1.Visible = RB_1Wild.Checked;
            WildPanel2.Visible = RB_2Wild.Checked;
        }
    }
}
