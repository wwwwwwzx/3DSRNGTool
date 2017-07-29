using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static PKHeX.Util;

namespace Pk3DSRNGTool
{
    public partial class Gen7EggSeedFinder : Form
    {
        private TinySeedFinder tinyfinder;

        public Gen7EggSeedFinder()
        {
            InitializeComponent();
            TranslateInterface(this, Properties.Settings.Default.Language);
            NatureInput.Items.AddRange(StringItem.naturestr.Select((str,i) => i.ToString("D2") + " - " + str).ToArray());
        }
        private void Gen7EggSeedFinder_FormClosing(object sender, FormClosingEventArgs e)
        {
            tinyfinder?.Abort();
        }

        private void SetNewEggSeed(string seed) => Program.mainform.SetNewEggSeed(seed);
        private void B_EggSeed127_Click(object sender, EventArgs e)
        {
            string inlist = RTB_EggSeed.Text;
            inlist = Regex.Replace(inlist, @"\s", "");

            if (inlist == "" || !Regex.IsMatch(inlist, @"^[01]+$"))
            {
                Alert("Do not input characters other than '0''1'");
                return;
            }
            if (inlist.Length != 127)
            {
                Alert($"Please input 127 '0','1'(now you have {inlist.Length})");
                return;
            }
            var seed = MagikarpCalc.calc(inlist);
            if (Prompt(MessageBoxButtons.YesNo, $"Your Current Egg Seed is \"{seed}\"\nSet as Current Status in Egg RNG Tab?") == DialogResult.Yes)
                SetNewEggSeed(seed);
        }

        private void B_TinySearch_Click(object sender, EventArgs e)
        {
            var nature = FuncUtil.parseNatureList(NatureList.Text);
            if (nature == null)
            {
                Error("Invalid Input");
                return;
            }
            if (nature.Length != 8)
            {
                Error("Incorrect number of natures");
                return;
            }
            if (tinyfinder == null)
            {
                tinyfinder = new TinySeedFinder();
                tinyfinder.Update += UpdateProgressBar7;
                tinyfinder.NewResult += UpdateList7;
            }
            Gen7PBar.Value = 0;
            Gen7PBar.Maximum = tinyfinder.Max;
            L_Progress7.Text = "0.00%";
            EggSeedList.Items.Clear();
            tinyfinder.Clear();
            tinyfinder.SetFinder(nature, Properties.Settings.Default.ShinyCharm);
            tinyfinder.Search();
            B_TinySearch.Visible = false;
            B_Abort7.Visible = true;
        }

        private void B_Abort7_Click(object sender, EventArgs e)
        {
            tinyfinder.Abort();
            B_TinySearch.Visible = true;
            B_Abort7.Visible = false;
            L_Progress7.Text = sender == B_Abort7 ? "Cancelled" : "Done";
            if (tinyfinder.seedlist.Count == 1)
            {
                var seed = tinyfinder.seedlist[0];
                if (Prompt(MessageBoxButtons.YesNo, $"Your Egg Seed is \"{seed}\"\nSet as Current Status in Egg RNG Tab?") == DialogResult.Yes)
                    SetNewEggSeed(seed);
                return;
            }
            Alert($"Found {tinyfinder.seedlist.Count} Frame(s)");
        }

        private void UpdateProgressBar7(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                Gen7PBar.Value = tinyfinder.Cnt;
                L_Progress7.Text = (tinyfinder.Cnt / (tinyfinder.Max / 100.00)).ToString("F2") + "%";
                if (tinyfinder.Cnt == tinyfinder.Max)
                    B_Abort7_Click(null, null);
            }));
        }

        private void UpdateList7(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                EggSeedList.Items.Clear();
                EggSeedList.Items.AddRange(tinyfinder.seedlist.ToArray());
                EggSeedList.Refresh();
            }));
        }

        private void NatureInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NatureList.Text != "") NatureList.Text += ",";
            NatureList.Text += NatureInput.SelectedIndex.ToString();
        }

        private void B_DelNature_Click(object sender, EventArgs e)
        {
            var str = NatureList.Text;
            if (str != "")
            {
                if (str.LastIndexOf(',') != -1)
                    str = str.Remove(str.LastIndexOf(','));
                else if (str.LastIndexOf(' ') != -1)
                    str = str.Remove(str.LastIndexOf(' '));
                else
                    str = "";
            }
            NatureList.Text = str;
        }

        private void EggSeedList_Click(object sender, EventArgs e)
        {
            try
            {
                var seed = EggSeedList.SelectedItem.ToString();
                if (Prompt(MessageBoxButtons.YesNo, $"Your Selected Egg Seed is \"{seed}\"\nSet as Current Status in Egg RNG Tab?") == DialogResult.Yes)
                    SetNewEggSeed(seed);
            }
            catch
            { }
        }
    }
}
