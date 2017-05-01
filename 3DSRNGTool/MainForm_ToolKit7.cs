using System;
using System.Linq;
using System.Windows.Forms;
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
                if (str.LastIndexOf(",") != -1)
                    str = str.Remove(str.LastIndexOf(","));
                else
                    str = "";
            }
            tmp.Text = str;
        }

        private void Get_Clock_Number(object sender, EventArgs e)
        {
            TextBox tmp = QRInput.Checked ? QRList : Clock_List;
            string str = ((Button)sender).Name;
            string n = str.Remove(0, str.IndexOf("button") + 6);

            if (tmp.Text != "") tmp.Text += ",";
            tmp.Text += !EndClockInput.Checked || QRInput.Checked ? n : ((Convert.ToInt32(n) + 13) % 17).ToString();

            if (QRInput.Checked)
            {
                if (QRList.Text.Count(c => c == ',') < 3)
                    return;
                QRSearch_Click(null, null);
            }
            else
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
                var results = SFMTSeedAPI.request(Clock_List.Text);
                if (results == null || results.Count() == 0)
                    text = NORESULT_STR[lindex];
                else
                {
                    text = string.Join(" ", results.Select(r => r.seed));
                    if (results.Count() == 1)
                    {
                        Time_min.Value = 418 + Clock_List.Text.Count(c => c == ',');
                        uint s0;
                        if (uint.TryParse(text, System.Globalization.NumberStyles.HexNumber, null, out s0))
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
            uint InitialSeed = (uint)Seed.Value;
            int min = (int)Frame_min.Value;
            int max = (int)Frame_max.Value;
            if (QRList.Text == "")
                return;
            string[] str = QRList.Text.Split(',');
            try
            {
                int[] Clock_List = str.Select(s => int.Parse(s)).ToArray();
                int[] temp_List = new int[Clock_List.Length];

                SFMT sfmt = new SFMT(InitialSeed);
                SFMT seed = (SFMT)sfmt.DeepCopy();
                bool flag = false;

                QRResult.Items.Clear();

                for (int i = 0; i < min; i++)
                    sfmt.Next();

                int cnt = 0;
                int tmp = 0;
                for (int i = min; i <= max; i++, sfmt.Next())
                {
                    seed = (SFMT)sfmt.DeepCopy();

                    for (int j = 0; j < Clock_List.Length; j++)
                        temp_List[j] = (int)(seed.Nextulong() % 17);

                    if (temp_List.SequenceEqual(Clock_List))
                        flag = true;

                    if (flag)
                    {
                        flag = false;
                        switch (lindex)
                        {
                            case 0: QRResult.Items.Add($"The last clock is at {i + Clock_List.Length - 1}F, you're at {i + Clock_List.Length + 1}F after quiting QR"); break;
                            case 1: QRResult.Items.Add($"最后的指针在 {i + Clock_List.Length - 1} 帧，退出QR后在 {i + Clock_List.Length + 1} 帧"); break;
                        }
                        cnt++;
                        tmp = i + Clock_List.Length + 1;
                    }
                }

                if (cnt == 1)
                    Time_min.Value = tmp;
            }
            catch
            {
                Error(SETTINGERROR_STR[lindex] + L_QRList.Text);
            }
        }
        #endregion

        #region TimerCalculateFunction
        private int[] CalcFrame(int min, int max)
        {
            uint InitialSeed = (uint)Seed.Value;
            SFMT sfmt = new SFMT(InitialSeed);

            for (int i = 0; i < min; i++)
                sfmt.Next();

            //total_frame[0] Start; total_frame[1] Duration
            int[] total_frame = new int[2];
            int n_count = 0;
            int timer = 0;
            ModelStatus status = new ModelStatus((byte)(NPC.Value + 1), sfmt);

            while (min + n_count <= max)
            {
                n_count += status.NextState();
                total_frame[timer]++;
                if (min + n_count == max)
                    timer = 1;
            }
            return total_frame;
        }

        bool ShowDelay => !ConsiderDelay.Checked;

        private void CalcTime_Output(int min, int max)
        {
            int[] totaltime = CalcFrame(min, max);
            double realtime = totaltime[0] / 30.0;
            string str = $" {totaltime[0] * 2}F ({realtime.ToString("F")}s) <{totaltime[1] * 2}F>. ";
            switch (lindex)
            {
                case 0: str = "Set Eontimer for" + str + (ShowDelay ? $" Hit frame {max}" : ""); break;
                case 1: str = "计时器设置为" + str + (ShowDelay ? $" 在 {max} 帧按A" : ""); break;
            }
            TimeResult.Items.Add(str);
        }

        private void CalcTime(object sender, EventArgs e)
        {
            TimeResult.Items.Clear();
            int min = (int)Time_min.Value;
            int max = (int)TargetFrame.Value;
            if (!ShowDelay)
            {
                CalcTime_Output(min, max);
                return;
            }
            int[] tmptimer = new int[2];
            int delaytime = (int)Timedelay.Value / 2;
            for (int tmp = max - (byte)(NPC.Value + 1) * delaytime; tmp <= max; tmp++)
            {
                tmptimer = CalcFrame(tmp, max);
                if (tmptimer[0] + tmptimer[1] > delaytime && tmptimer[0] <= delaytime)
                    CalcTime_Output(min, tmp - (int)Correction.Value);
                if (tmptimer[0] == delaytime && tmptimer[1] == 0)
                    CalcTime_Output(min, tmp - (int)Correction.Value);
            }
        }
        #endregion

    }
}
