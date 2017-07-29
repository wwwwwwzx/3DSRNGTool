using System;
using System.Windows.Forms;
using static PKHeX.Util;

namespace Pk3DSRNGTool
{
    public partial class NTRHelper : Form
    {
        public static NtrClient ntrclient;
        private int timercounter;
        private ushort lasttableindex;
        private static int Ver { get => Program.mainform.Ver; set => Program.mainform.Ver = value; }

        public NTRHelper()
        {
            InitializeComponent();
            IP.Text = Properties.Settings.Default.IP;
            ntrclient = new NtrClient();
            ntrclient.Connected += OnConnected;
        }
        private void NTRHelper_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;
        }

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
            B_BreakPoint.Enabled = B_Resume.Enabled = B_GetSeed.Enabled = B_Disconnect.Enabled = false;
            Program.mainform.OnConnected_Changed(false);
        }

        private void OnConnected(object sender, EventArgs e)
        {
            NTR_Timer.Enabled = true;
            NTR_Timer.Interval = 1000;
            if (ntrclient.port == 8000)
                ntrclient.listprocess();
            L_NTRLog.Text = "Console Connected";
            B_Connect.Enabled = false;
            B_GetSeed.Enabled = B_Disconnect.Enabled = true;
            Program.mainform.OnConnected_Changed(true);
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
                    Ver = ntrclient.Gameversion;
                    B_BreakPoint.Enabled = B_Resume.Enabled = Ver < 4;
                    ntrclient.VersionDetected = false;
                    if (Ver > 4)
                    {
                        Program.mainform.SyncGen7EggSeed(null, null);
                        B_GetSeed_Click(null, null);
                    }
                    if (ntrclient.phase == 1) // One Click mode start
                    {
                        if (Ver < 4)
                        {
                            B_BreakPoint_Click(null, null);
                            ntrclient.phase = 2;
                            timercounter = Ver < 2 ? -3 : -4;
                        }
                        else
                            B_Disconnect_Click(null, null);
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
                        {
                            B_GetSeed_Click(null, null);
                            B_Disconnect_Click(null, null);
                        }
                        if (ntrclient.phase == 2) // the (2nd) freeze after setting breakpoint
                        {
                            Program.mainform.B_gettiny_Click(null, null);
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

        private void B_GetSeed_Click(object sender, EventArgs e)
        {
            byte[] seed_ay = ntrclient.ReadSeed();
            if (seed_ay == null) { Error("Timeout"); return; }
            Program.mainform.globalseed = BitConverter.ToUInt32(seed_ay, 0);
            ntrclient.resume();
        }

        private readonly static string[] HElP_STR =
        {
            "For X, Y(1.5), Omega Ruby, Alpha Sapphire(1.4), Sun, Moon(1.2)\n\n" +
            "Usage:\n" +
            "(1) Look for your 3DS' IP using FBI/Homebrew/Luma, input your console IP address. Make sure your PC running this tool and your console are in the same network.\n" +
            "(2) Install and start NTR-CFW (3.4 or above) before you start the game.\n"+
            "(3) Gen6: Hold the left arrow key of your console while the game is starting, until the screen flashes 3 times. It will stay at 3DS logo, don't worry.\n"+
            "Gen7: Proceed the game normally, stop at title screen or continue screen. Enable NTR Debugger via NTR menu (Press X+Y) \n"+
            "(4) Click 'One Click' button, the tool will try to connect the console and the game will proceed normally.\n"+
            "(5) If gen7 skip this step. Press A or Select/Start to skip the title screen until you get to the continue screen.\n"+
            "(6) All done. The tool will help you grab the initial seed (also egg seed for gen7) and wrap up everything. Enjoy!\n\n"+
            "- You can also keep the connection via 'Connect' button, and double click one of the labels of TinyMT status textboxes (in TTT or Egg RNG tab) to sync them.\n"+
            "- Moon version game will be recognized as Sun, it's normal.",

            "如何使用:\n" +
            "(1) 通过FBI/Homebrew/Luma 查看3DS的IP地址, 输入此处, 并确保打开本程序的软件与3DS处在同一网络下\n" +
            "(2) 安装并在开始游戏前打开 NTR-CFW (需破解)\n"+
            "(3) 6代：在游戏启动时按住左键,直至屏幕闪烁三次并停在3DS图标处,此时游戏不会继续,为正常现象\n"+
            "7代：进入游戏,在封面或读档界面按X+Y调出NTR菜单,选择Enable Debugger\n"+
            "(4) 点击\"一键完成\"本程序将自动连接并继续游戏\n"+
            "(5) 7代跳过此步骤。不断按A直至读档界面\n"+
            "(6) 完成.软件会自动读取初始Seed并断开连接",
        };

        private void B_Help_Click(object sender, EventArgs e) => Alert(HElP_STR[Program.mainform.lindex]);
    }
}
