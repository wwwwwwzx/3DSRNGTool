using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using static PKHeX.Util;
using static Pk3DSRNGTool.StringItem;

namespace Pk3DSRNGTool
{
    public partial class KeyBV : Form
    {
        public KeyBV()
        {
            InitializeComponent();
        }
        private static int lindex => Program.mainform.lindex;

        private void B_Dump_Click(object sender, EventArgs e)
        {
            var dumper = new BVBreaker(Video1.Text, Video2.Text);
            if (dumper.gen == -1)
            {
                Alert(FILEERRORSTR[lindex]);
                return;
            }
            dumper.Break();
            var pkx = dumper.TryGetPKM(0);
            int species;
            if (pkx == null || (species = BitConverter.ToUInt16(pkx, 0x8)) == 0)
            {
                Alert("Dump failed! Please check your battle video files are correct");
                return;
            }
            string output = speciestr[species] + " TSV: " + BVBreaker.getTSV(pkx).ToString("D4");
            if (null != (pkx = dumper.TryGetPKM(1)) && (species = BitConverter.ToUInt16(pkx, 0x8)) != 0)
                output += '\n' + speciestr[species] + " TSV: " + BVBreaker.getTSV(pkx).ToString("D4");
            MessageBox.Show(output, "Successful Dump!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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