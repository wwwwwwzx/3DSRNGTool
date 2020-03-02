using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using static Pk3DSRNGTool.StringItem;

namespace Pk3DSRNGTool
{
    public partial class KeyBV : Form
    {
        public KeyBV()
        {
            InitializeComponent();
        }

        private void B_Dump_Click(object sender, EventArgs e)
        {
            var dumper = new BVBreaker(Video1.Text, Video2.Text);
            if (dumper.gen == -1)
            {
                FormUtil.Alert(FILEERRORSTR[language]);
                return;
            }

            // get the keystream
            dumper.Break();

            // Try to get the tsv
            PKX pkx;
            int slot = 0;
            string output = string.Empty;
            while (slot < 6 && null != (pkx = dumper.TryGetPKM(slot++)) && pkx.species != 0)
                output += (slot == 1 ? string.Empty : Environment.NewLine)
                    + speciestr[pkx.species] + "\tTSV: " + pkx.TSV.ToString("D4")
                    +"\tTRV: " + pkx.TSV.ToString("X1");
            if (output.Length > 0)
                MessageBox.Show(output, "Successful Dump!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                FormUtil.Alert("Dump failed! Please check your battle video files are correct");
        }

        private void FileDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            (sender == panel1 ? Video1 : Video2).Text = files[0];
        }

        private void DropEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void B_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog()
            {
                Title = "Select a Battle Video File"
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                (sender == B_V1 ? Video1 : Video2).Text = openFileDialog1.FileName;
        }

        private void CheckFile(object sender, EventArgs e)
        {
            int size;
            try { size = File.ReadAllBytes((sender as TextBox).Text).Length; } catch { size = -1; };
            (sender == Video1 ? panel1 : panel2).BackColor = BVBreaker.checkvideosize(size) ? Color.LightGreen : Color.LightPink;
            B_Dump.Enabled = panel1.BackColor == Color.LightGreen && panel2.BackColor == Color.LightGreen;
        }
    }
}