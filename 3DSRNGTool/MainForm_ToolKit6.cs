using System;
using System.Windows.Forms;
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
            B_BreakPoint.Enabled = B_Resume.Enabled = B_GetGen6Seed.Enabled = B_Disconnect.Enabled = false;
        }

        private void OnConnected(object sender, EventArgs e)
        {
            NTR_Timer.Enabled = true;
            NTR_Timer.Interval = 1000;
            if (ntrclient.port == 8000)
                ntrclient.listprocess();
            L_NTRLog.Text = "Console Connected";
            B_Connect.Enabled = false;
            B_BreakPoint.Enabled = B_Resume.Enabled = B_GetGen6Seed.Enabled = B_Disconnect.Enabled = true;
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
                        timercounter = -4;
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
                            B_Resume_Click(null, null);
                            NTR_Timer.Interval = 500;
                            ntrclient.phase = 3;
                            timercounter = -10;
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
            ntrclient.Write(0x8800000, seed_ay, ntrclient.Pid);
            Seed.Value = BitConverter.ToUInt32(seed_ay, 0);
            ntrclient.resume();
            B_Disconnect_Click(null, null);
        }
        #endregion
    }
}
