using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using static PKHeX.Util;
using Pk3DSRNGTool.RNG;

namespace Pk3DSRNGTool
{
    public partial class MainForm : Form
    {
        private void B_EggReset_Click(object sender, EventArgs e)
        {
            IV_Male = new[] { 31, 31, 31, 31, 31, 31 };
            IV_Female = new[] { 31, 31, 31, 31, 31, 31 };
            Egg_GenderRatio.SelectedIndex = 1;
            Homogeneity.Checked = NidoType.Checked = MM.Checked =
            M_ditto.Checked = F_ditto.Checked = false;
            M_Items.SelectedIndex = F_Items.SelectedIndex =
            M_ability.SelectedIndex = F_ability.SelectedIndex = 0;
        }

        private void B_Fast_Click(object sender, EventArgs e)
        {
            B_EggReset_Click(null, null);
            IV_Female = new int[6];
            M_Items.SelectedIndex = 2;
            MM.Checked = Homogeneity.Checked = true;
        }

        private void Ditto_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox)?.Checked ?? false)
            {
                (sender == F_ditto ? M_ditto : F_ditto).Checked =
                Homogeneity.Enabled = Homogeneity.Checked = false;
            }
            else
                Homogeneity.Enabled = !NidoType.Checked;
        }

        private void NidoType_CheckedChanged(object sender, EventArgs e)
        {
            Homogeneity.Enabled = !(NidoType.Checked || M_ditto.Checked || F_ditto.Checked);
            if (NidoType.Checked)
                Homogeneity.Checked = false;
        }

        private void MM_CheckedChanged(object sender, EventArgs e)
        {
            MainRNGEgg.Visible = method == 3 && !ShinyCharm.Checked && !MM.Checked;
            if (MainRNGEgg.Checked)
            {
                NPC.Value = 4;
                Timedelay.Value = 38;
            }
        }

        private void B_Backup_Click(object sender, EventArgs e)
        {
            string backupfile = "Backup_" + DateTime.Now.ToString("yyMMdd_HHmmss") + ".txt";
            File.WriteAllLines(backupfile, new[] { St3.Text, St2.Text, St1.Text, St0.Text, });
            Alert(backupfile + " saved");
        }

        private void B_Load_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog OFD = new OpenFileDialog();
                DialogResult result = OFD.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string file = OFD.FileName;
                    if (File.Exists(file))
                    {
                        string[] list = File.ReadAllLines(file);

                        uint s3, s2, s1, s0;

                        uint.TryParse(list[3], System.Globalization.NumberStyles.HexNumber, null, out s0);
                        uint.TryParse(list[2], System.Globalization.NumberStyles.HexNumber, null, out s1);
                        uint.TryParse(list[1], System.Globalization.NumberStyles.HexNumber, null, out s2);
                        uint.TryParse(list[0], System.Globalization.NumberStyles.HexNumber, null, out s3);
                        Status = new[] { s0, s1, s2, s3 };
                    }
                }
            }
            catch
            {
                Error(FILEERRORSTR[lindex]);
            }
        }

        private void B_TSVList_Click(object sender, EventArgs e)
        {
            var editor = new TSVListForm(list2str(OtherTSVList));
            editor.ShowDialog();
            if (editor.other_tsv.Count > 0)
                OtherTSVList = editor.other_tsv;
            Properties.Settings.Default.TSVList = list2str(OtherTSVList);
            Properties.Settings.Default.Save();
        }

        private void loadlist(string tsvstr)
        {
            OtherTSVList.Clear();
            try
            {
                string[] lines = tsvstr.Split(',');
                for (int i = 0; i < lines.Length; i++)
                {
                    int val;
                    if (!int.TryParse(lines[i], out val))
                        continue;

                    if (0 > val || val > 4095)
                        continue;

                    OtherTSVList.Add(val);
                }
            }
            catch
            {
            }
        }

        private string list2str(List<int> list)
        {
            return string.Join(",", list.Select(i => i.ToString()).ToArray());
        }

        #region DGV menu
        private void SetAsCurrent_Click(object sender, EventArgs e)
        {
            try
            {
                var seed = (string)DGV.CurrentRow.Cells["dgv_status"].Value;
                Status = SeedStr2Array(seed) ?? Status;
            }
            catch (NullReferenceException)
            {
                Error(NOSELECTION_STR[lindex]);
            }
        }

        private uint[] SeedStr2Array(string seed)
        {
            try
            {
                string[] Data = seed.Split(',');
                uint[] St = new uint[4];
                St[3] = Convert.ToUInt32(Data[0], 16);
                St[2] = Convert.ToUInt32(Data[1], 16);
                St[1] = Convert.ToUInt32(Data[2], 16);
                St[0] = Convert.ToUInt32(Data[3], 16);
                return St;
            }
            catch
            {
                return null;
            }
        }

        private void SetAsAfter_Click(object sender, EventArgs e)
        {
            try
            {
                var seed = (string)DGV.CurrentRow.Cells["dgv_status"].Value;
                var adv = Convert.ToInt32((string)DGV.CurrentRow.Cells["dgv_adv"].Value);
                uint[] St = SeedStr2Array(seed);
                TinyMT tmt = new TinyMT(St);
                for (int i = adv; i > 0; i--)
                    tmt.Next();
                Status = tmt.status;
            }
            catch
            { }
        }
        #endregion
    }
}
