using System;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Pk3DSRNGTool.RNG;
using static PKHeX.Util;

namespace Pk3DSRNGTool
{
    public partial class MainForm : Form
    {

        #region SearchSeedFunction
        private void Clear_Click(object sender, EventArgs e)
        {
            ((QRInput.Checked) ? QRList : Clock_List).Text = "";
        }

        private void Back_Click(object sender, EventArgs e)
        {
            TextBox tmp = QRInput.Checked ? QRList : Clock_List;
            string str = tmp.Text;
            if (tmp.Text != "")
            {
                if (str.LastIndexOf(',') != -1)
                    str = str.Remove(str.LastIndexOf(','));
                else
                    str = "";
            }
            tmp.Text = str;
        }

        private void Get_Clock_Number(object sender, EventArgs e)
        {
            TextBox tmp = QRInput.Checked ? QRList : Clock_List;
            string str = ((Button)sender).Name;
            string n = str.Remove(0, 6);

            if (tmp.Text != "") tmp.Text += ",";
            tmp.Text += !EndClockInput.Checked || QRInput.Checked ? n : ((Convert.ToInt32(n) + 13) % 17).ToString();

            if (QRInput.Checked)
            {
                if (QRList.Text.Count(c => c == ',') < 3)
                    return;
                QRSearch_Click(null, null);
                return;
            }
            SearchforSeed(null, null);
        }

        private void SearchforSeed(object sender, EventArgs e)
        {
            if (Clock_List.Text.Count(c => c == ',') < 7)
            {
                SeedResults.Text = "";
                return;
            }
            var text = "";
            try
            {
                SeedResults.Text = WAIT_STR[lindex];
                var results = SFMTSeedAPI.request(Clock_List.Text, RB_ID.Checked);
                if (!results?.Any() ?? true)
                    text = NORESULT_STR[lindex];
                else
                {
                    text = string.Join(" ", results.Select(r => r.seed));
                    if (results.Count() == 1)
                    {
                        if (RB_Main.Checked)
                            Frame_min.Value = Time_min.Value = 418 + Clock_List.Text.Count(c => c == ',');
                        else
                        {
                            Frame_min.Value = 1012; //keep full range to check the value
                            Clk_Correction.Value = results.FirstOrDefault().add;
                        }
                        if (uint.TryParse(text, System.Globalization.NumberStyles.HexNumber, null, out uint s0))
                            Seed.Value = s0;
                    }
                }
            }
            catch (Exception exc)
            {
                text = exc.Message;
            }
            finally
            {
                SeedResults.Text = text;
            }
        }

        private void QRSearch_Click(object sender, EventArgs e)
        {
            uint InitialSeed = Seed.Value;
            int min = (int)Frame_min.Value;
            int max = (int)Frame_max.Value;
            if (QRList.Text == "")
                return;
            string[] str = QRList.Text.Split(',');
            try
            {
                int[] Clk_List = str.Select(s => int.Parse(s)).ToArray();
                int[] temp_List = new int[Clk_List.Length];

                SFMT sfmt = new SFMT(InitialSeed);
                SFMT seed = (SFMT)sfmt.DeepCopy();

                QRResult.Items.Clear();

                for (int i = 0; i < min; i++)
                    sfmt.Next();

                int tmp = 0;
                for (int i = min; i <= max; i++, sfmt.Next())
                {
                    seed = (SFMT)sfmt.DeepCopy();

                    for (int j = 0; j < Clk_List.Length; j++)
                        temp_List[j] = (int)(seed.Nextulong() % 17);

                    if (temp_List.SequenceEqual(Clk_List))
                    {
                        switch (lindex)
                        {
                            case 0: QRResult.Items.Add($"The last clock is at {i + Clk_List.Length - 1}F, you're at {i + Clk_List.Length + 1}F after quiting QR"); break;
                            case 1: QRResult.Items.Add($"最后的指针在 {i + Clk_List.Length - 1} 帧，退出QR后在 {i + Clk_List.Length + 1} 帧"); break;
                        }
                        tmp = i + Clk_List.Length + 1;
                    }
                }

                if (QRResult.Items.Count == 1)
                    Time_min.Value = tmp;
            }
            catch
            {
                Error(SETTINGERROR_STR[lindex] + L_QRList.Text);
            }
        }

        private void RB_Gen7_CheckedChanged(object sender, EventArgs e)
        {
            StartClockInput.Enabled = EndClockInput.Enabled = RB_Main.Checked && BySaveScreen.Checked;
            (StartClockInput.Enabled ? EndClockInput : StartClockInput).Checked = true;
        }

        private void API_Click(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked) BySaveScreen.Checked = true;
        }
        #endregion

        #region TimerCalculateFunction
        private int[] CalcFrame(int min, int max)
        {
            if (min > max)
                return CalcFrame(max, min).Select(t => -t).ToArray();

            uint InitialSeed = Seed.Value;
            SFMT sfmt = new SFMT(InitialSeed);

            for (int i = 0; i < min; i++)
                sfmt.Next();

            //total_frame[0] Start; total_frame[1] Duration
            int[] total_frame = new int[2];
            int n_count = 0;
            int timer = 0;
            ModelStatus status = new ModelStatus(Modelnum, sfmt);

            while (min + n_count <= max)
            {
                n_count += status.NextState();
                total_frame[timer]++;
                if (min + n_count == max)
                    timer = 1;
            }
            return total_frame;
        }

        private void CalcTime_Output(int min, int max)
        {
            int[] totaltime = CalcFrame(min, max);
            double realtime = totaltime[0] / 30.0;
            string str = $" {totaltime[0] * 2}F ({realtime.ToString("F")}s) <{totaltime[1] * 2}F>. ";
            switch (lindex)
            {
                case 0: str = "Set Eontimer for" + str; break;
                case 1: str = "计时器设置为" + str; break;
            }
            MessageBox.Show(str, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CalcTime(object sender, EventArgs e)
        {
            int min = (int)Time_min.Value;
            int max = (int)TargetFrame.Value;
            CalcTime_Output(min, max);
        }
        #endregion

        #region Egg Seed Finder
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
            {
                Status = FuncUtil.SeedStr2Array(seed);
                B_Backup_Click(null, null);
            }
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
            tinyfinder.SetFinder(nature, ShinyCharm.Checked);
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
                {
                    Status = FuncUtil.SeedStr2Array(seed);
                    B_Backup_Click(null, null);
                }
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

        private void B_BackNature_Click(object sender, EventArgs e)
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
                {
                    Status = FuncUtil.SeedStr2Array(seed);
                    B_Backup_Click(null, null);
                }
            }
            catch
            { }
        }
        #endregion
    }
}
