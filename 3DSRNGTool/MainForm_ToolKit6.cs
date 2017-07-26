using System;
using System.Windows.Forms;
using System.Collections.Generic;
using static PKHeX.Util;

namespace Pk3DSRNGTool
{
    public partial class MainForm : Form
    {
        #region NTR Client
        private void B_Connect_Click(object sender, EventArgs e)
        {
            L_NTRLog.Text = "Connecting...";
            ntrclient.setServer(IP.Text, 8000);
            try
            {
                ntrclient.connectToServer();
            }
            catch
            {
                OnDisconnected(false);
                Error("Unable to connect the console");
            }
        }

        private void B_Disconnect_Click(object sender, EventArgs e)
        {
            ntrclient.disconnect();
            OnDisconnected();
        }

        private void OnDisconnected(bool Success = true)
        {
            timercounter = 0;
            NTR_Timer.Enabled = false;
            ntrclient.phase = 0;
            B_Connect.Enabled = true;
            L_NTRLog.Text = Success ? "Disconnected" : "No Connection";
            B_GetTiny.Enabled = B_BreakPoint.Enabled = B_Resume.Enabled = B_GetGen6Seed.Enabled = B_Disconnect.Enabled = false;
        }

        private void OnConnected(object sender, EventArgs e)
        {
            NTR_Timer.Enabled = true;
            NTR_Timer.Interval = 1000;
            if (ntrclient.port == 8000)
                ntrclient.listprocess();
            L_NTRLog.Text = "Console Connected";
            B_Connect.Enabled = false;
            B_GetTiny.Enabled = B_BreakPoint.Enabled = B_Resume.Enabled = B_GetGen6Seed.Enabled = B_Disconnect.Enabled = true;
            Properties.Settings.Default.IP = IP.Text;
        }

        private void B_OneClick_Click(object sender, EventArgs e)
        {
            ntrclient.phase = 1;
            B_Connect_Click(null, null);
        }

        private void NTRTick(object sender, EventArgs e)
        {
            try
            {
                if (ntrclient.VersionDetected)
                {
                    Gameversion.SelectedIndex = ntrclient.Gameversion;
                    ntrclient.VersionDetected = false;
                    if (ntrclient.phase == 1 && Ver < 4) // One Click mode start
                    {
                        B_BreakPoint_Click(null, null);
                        ntrclient.phase = 2;
                        timercounter = Ver < 2 ? -3 : -4;
                    }
                }
                if (ntrclient.phase > 1 && timercounter++ > 0) // To detect freeze
                {
                    L_NTRLog.Text = "Waiting..";
                    ushort tableindex = BitConverter.ToUInt16(ntrclient.ReadIndex(), 0);
                    if (lasttableindex != tableindex)
                        lasttableindex = tableindex;
                    else
                    {
                        if (ntrclient.phase == 3) // the console reaches the breakpoint
                            B_GetGen6Seed_Click(null, null);
                        if (ntrclient.phase == 2) // the (2nd) freeze after setting breakpoint
                        {
                            B_gettiny_Click(null, null);
                            B_Resume_Click(null, null);
                            NTR_Timer.Interval = 500;
                            ntrclient.phase = 3;
                            timercounter = Ver < 2 ? -8 : -10;
                        }
                    }
                }
                ntrclient.sendHeartbeatPacket();
            }
            catch { }
        }

        private void B_BreakPoint_Click(object sender, EventArgs e)
        {
            try
            {
                ntrclient.SetBreakPoint();
                L_NTRLog.Text = "Break Point Set";
            }
            catch
            {
                OnDisconnected(false);
                Error("Unable to connect the console.");
            }
        }

        private void B_Resume_Click(object sender, EventArgs e)
        {
            try
            {
                ntrclient.resume();
            }
            catch
            {
            }
        }

        private void B_GetGen6Seed_Click(object sender, EventArgs e)
        {
            byte[] seed_ay = ntrclient.ReadSeed();
            if (seed_ay == null) { Error("Timeout"); return; }
            Seed.Value = BitConverter.ToUInt32(seed_ay, 0);
            ntrclient.resume();
            B_Disconnect_Click(null, null);
        }

        private void B_gettiny_Click(object sender, EventArgs e)
        {
            byte[] tiny = ntrclient.ReadTiny();
            if (tiny == null) { Error("Timeout"); return; }
            ID_Tiny0.Value = BitConverter.ToUInt32(tiny, 0);
            ID_Tiny1.Value = BitConverter.ToUInt32(tiny, 4);
            ID_Tiny2.Value = BitConverter.ToUInt32(tiny, 8);
            ID_Tiny3.Value = BitConverter.ToUInt32(tiny, 12);
        }
        #endregion

        #region Bruteforce Seed Finder
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
            B_MTSearch.Visible = false;
            B_Abort6.Visible = true;
            RB_1Wild.Enabled = RB_2Wild.Enabled = false;
        }

        private void B_Abort6_Click(object sender, EventArgs e)
        {
            mtfinder.Abort();
            B_MTSearch.Visible = true;
            B_Abort6.Visible = false;
            RB_1Wild.Enabled = RB_2Wild.Enabled = true;
            L_Progress6.Text = sender == B_Abort6 ? "Cancelled" : "Done";
            if (mtfinder.seedlist.Count == 1)
                Seed.Value = mtfinder.seedlist[0].Seed;
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
                DGV_Seed.DataSource = new BindingSource(tinyfinder.seedlist, null);
                DGV_Seed.CurrentCell = null;
            }));
        }

        private void AdjustDGVSeedColumn()
        {
            DGV_Seed.Columns["dgv_Seed_frame2"].Visible = DGV_Seed.Columns["dgv_Seed_nature2"].Visible = RB_2Wild.Checked;
            DGV_Seed.Columns["dgv_Seed_gender"].Visible = RB_1Wild.Checked;
        }
        #endregion
    }
}
