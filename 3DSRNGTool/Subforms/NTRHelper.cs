using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PKHeX.Util;

namespace Pk3DSRNGTool
{
    public partial class NTRHelper : Form
    {
        public static NtrClient ntrclient;

        public NTRHelper()
        {
            InitializeComponent();
            IP.Text = Properties.Settings.Default.IP;
            ntrclient = new NtrClient();
            ntrclient.Connect += OnConnected;
            ntrclient.Message += OnMsgArrival;
            ntrclient.setServer(IP.Text, 8000);
        }
        private void NTRHelper_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;
        }

        private void B_Connect_Click(object sender, EventArgs e)
        {
            ntrclient.OneClick = sender == B_OneClick;
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

        public void B_Disconnect_Click(object sender, EventArgs e)
        {
            ntrclient.disconnect();
            OnDisconnected();
        }

        private void OnDisconnected(bool Success = true)
        {
            NTR_Timer.Enabled = false;
            B_Connect.Enabled = true;
            L_NTRLog.Text = Success ? "Disconnected" : "No Connection";
            B_BreakPoint.Enabled = B_Resume.Enabled = B_GetSeed.Enabled = B_Disconnect.Enabled = false;
            Program.mainform.OnConnected_Changed(false);
        }

        private void OnConnected(object sender, EventArgs e)
        {
            if (ntrclient.port == 8000)
            {
                NTR_Timer.Enabled = true;
                L_NTRLog.Text = "Console Connected";
                B_Connect.Enabled = false;
                B_Resume.Enabled = B_GetSeed.Enabled = B_Disconnect.Enabled = true;
                Program.mainform.OnConnected_Changed(true);
                Properties.Settings.Default.IP = IP.Text;
                ntrclient.listprocess();
            }
        }

        private void OnMsgArrival(object sender, NtrClient.InfoEventArgs e)
        {
            Invoke(new Action(() =>
            {
                Program.mainform.parseNTRInfo(e.info, e.data);
                if (e.info == null)
                    L_NTRLog.Text = (string)e.data;
                if (e.info == "Version" && (byte)e.data < 4)
                    B_BreakPoint.Enabled = true;
            }));
        }

        private void NTRTick(object sender, EventArgs e)
        {
            try { ntrclient.sendHeartbeatPacket(); } catch { }
        }

        private void B_BreakPoint_Click(object sender, EventArgs e)
        {
            try { ntrclient.SetBreakPoint(); ntrclient.resume(); } catch { }
        }

        private void B_Resume_Click(object sender, EventArgs e)
        {
            try { ntrclient.resume(); } catch { }
        }

        private void B_GetSeed_Click(object sender, EventArgs e)
        {
            try { ntrclient.ReadSeed(); ntrclient.resume(); } catch { }
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

        #region IDBot
        private void Start()
        {
            ntrclient.CheckSocket();
            B_MassA.Enabled = B_A.Enabled = B_Start.Enabled = false;
            B_Stop.Enabled = true;
        }

        private void B_Start_Click(object sender, EventArgs e)
        {
            try
            {
                int Ver = Program.mainform.Ver;
                if (Ver == 4)
                    return;
                if (Ver < 2)
                {
                    Error("Not implemented yet");
                    return;
                }
                Start();
                if (Ver > 4)
                    G7IDBot();
                if (Ver < 4)
                    G6IDBot();
            }
            catch { }
        }

        private void B_Stop_Click(object sender, EventArgs e)
        {
            B_MassA.Enabled = B_A.Enabled = B_Start.Enabled = true;
            B_Stop.Enabled = false;
        }

        private bool Botting => B_Stop.Enabled;
        private int delaylevel => 5 - (int)Speed.Value;
        private int Delay1 => 500 + 100 * delaylevel;
        private int Delay2 => 3800 + 200 * delaylevel;
        private int Delay3 => 2200 + 100 * delaylevel;
        private int Delay4 => 4800 + 200 * delaylevel;
        private int Delay5 => 1500 + 100 * delaylevel;

        private async void G7IDBot()
        {
            int CurrFrame = (int)StartFrame.Value;
            while (Botting && CurrFrame < (int)StopFrame.Value)
            {
                // Input "!"
                ntrclient.PressA(); L_NTRLog.Text = "A pressed";
                await Task.Delay(Delay1);
                // Confirm
                ntrclient.Confirm(); L_NTRLog.Text = "Enter pressed";
                await Task.Delay(Delay2);
                // Discard
                ntrclient.PressB(); L_NTRLog.Text = "B pressed";
                await Task.Delay(Delay3);
                StartFrame.Value = ++CurrFrame;
            }
            B_Stop_Click(null, null);
        }

        private async void G6IDBot()
        {
            int CurrFrame = (int)StartFrame.Value;
            while (Botting && CurrFrame < (int)StopFrame.Value - 1)
            {
                // Choose gender
                ntrclient.PressA(); L_NTRLog.Text = "A pressed - 1";
                await Task.Delay(Delay1);
                // Confirm gender
                ntrclient.PressA(); L_NTRLog.Text = "A pressed - 2";
                await Task.Delay(Delay5);
                StartFrame.Value = ++CurrFrame;
                // Input "!"
                ntrclient.PressA(); L_NTRLog.Text = "A pressed - 3";
                await Task.Delay(Delay1);
                // Dialogue-1 
                ntrclient.Confirm(); L_NTRLog.Text = "Enter pressed";
                await Task.Delay(Delay4);
                // Discard
                ntrclient.PressB(); L_NTRLog.Text = "B pressed";
                await Task.Delay(Delay5);
                // Dialogue-2
                ntrclient.PressA(); L_NTRLog.Text = "A pressed";
                await Task.Delay(Delay1);
            }
            B_Stop_Click(null, null);
        }

        private void B_A_Click(object sender, EventArgs e)
        {
            try { ntrclient.CheckSocket(); ntrclient.PressA(); } catch { }
        }
        private void B_MassA_Click(object sender, EventArgs e)
        {
            try { Start(); MassA(); } catch { }
        }
        private async void MassA()
        {
            while (Botting)
            {
                ntrclient.PressA(); L_NTRLog.Text = "A Spamming";
                await Task.Delay(Delay1);
            }
        }
        #endregion
    }
}
