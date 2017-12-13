namespace Pk3DSRNGTool
{
    partial class NTRHelper
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            ntrclient?.disconnect();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.B_OneClick = new System.Windows.Forms.Button();
            this.L_NTRLog = new System.Windows.Forms.Label();
            this.B_Disconnect = new System.Windows.Forms.Button();
            this.B_Connect = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.IP = new System.Windows.Forms.TextBox();
            this.NTR_Timer = new System.Windows.Forms.Timer(this.components);
            this.B_Help = new System.Windows.Forms.Button();
            this.IDBot = new System.Windows.Forms.GroupBox();
            this.JPN = new System.Windows.Forms.CheckBox();
            this.B_MashA = new System.Windows.Forms.Button();
            this.B_A = new System.Windows.Forms.Button();
            this.L_Speed = new System.Windows.Forms.Label();
            this.B_Stop = new System.Windows.Forms.Button();
            this.B_Start = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.StopFrame = new System.Windows.Forms.NumericUpDown();
            this.StartFrame = new System.Windows.Forms.NumericUpDown();
            this.Speed = new System.Windows.Forms.NumericUpDown();
            this.IDBot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StopFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Speed)).BeginInit();
            this.SuspendLayout();
            // 
            // B_OneClick
            // 
            this.B_OneClick.Location = new System.Drawing.Point(162, 21);
            this.B_OneClick.Name = "B_OneClick";
            this.B_OneClick.Size = new System.Drawing.Size(143, 25);
            this.B_OneClick.TabIndex = 120;
            this.B_OneClick.Text = "One Click";
            this.B_OneClick.UseVisualStyleBackColor = true;
            this.B_OneClick.Click += new System.EventHandler(this.B_Connect_Click);
            // 
            // L_NTRLog
            // 
            this.L_NTRLog.AutoSize = true;
            this.L_NTRLog.Location = new System.Drawing.Point(207, 65);
            this.L_NTRLog.Name = "L_NTRLog";
            this.L_NTRLog.Size = new System.Drawing.Size(38, 13);
            this.L_NTRLog.TabIndex = 116;
            this.L_NTRLog.Text = "Ready";
            // 
            // B_Disconnect
            // 
            this.B_Disconnect.Enabled = false;
            this.B_Disconnect.Location = new System.Drawing.Point(115, 59);
            this.B_Disconnect.Name = "B_Disconnect";
            this.B_Disconnect.Size = new System.Drawing.Size(69, 25);
            this.B_Disconnect.TabIndex = 117;
            this.B_Disconnect.Text = "Disconnect";
            this.B_Disconnect.UseVisualStyleBackColor = true;
            this.B_Disconnect.Click += new System.EventHandler(this.B_Disconnect_Click);
            // 
            // B_Connect
            // 
            this.B_Connect.Location = new System.Drawing.Point(25, 59);
            this.B_Connect.Name = "B_Connect";
            this.B_Connect.Size = new System.Drawing.Size(69, 25);
            this.B_Connect.TabIndex = 114;
            this.B_Connect.Text = "Connect";
            this.B_Connect.UseVisualStyleBackColor = true;
            this.B_Connect.Click += new System.EventHandler(this.B_Connect_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(23, 27);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 13);
            this.label18.TabIndex = 113;
            this.label18.Text = "IP";
            // 
            // IP
            // 
            this.IP.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IP.Location = new System.Drawing.Point(46, 23);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(102, 22);
            this.IP.TabIndex = 112;
            this.IP.Text = "192.168.0.1";
            // 
            // NTR_Timer
            // 
            this.NTR_Timer.Interval = 1000;
            this.NTR_Timer.Tick += new System.EventHandler(this.NTRTick);
            // 
            // B_Help
            // 
            this.B_Help.Image = global::Pk3DSRNGTool.Properties.Resources.Info;
            this.B_Help.Location = new System.Drawing.Point(311, 21);
            this.B_Help.Name = "B_Help";
            this.B_Help.Size = new System.Drawing.Size(24, 25);
            this.B_Help.TabIndex = 121;
            this.B_Help.UseVisualStyleBackColor = true;
            this.B_Help.Click += new System.EventHandler(this.B_Help_Click);
            // 
            // IDBot
            // 
            this.IDBot.Controls.Add(this.JPN);
            this.IDBot.Controls.Add(this.B_MashA);
            this.IDBot.Controls.Add(this.B_A);
            this.IDBot.Controls.Add(this.L_Speed);
            this.IDBot.Controls.Add(this.B_Stop);
            this.IDBot.Controls.Add(this.B_Start);
            this.IDBot.Controls.Add(this.label1);
            this.IDBot.Controls.Add(this.StopFrame);
            this.IDBot.Controls.Add(this.StartFrame);
            this.IDBot.Location = new System.Drawing.Point(12, 100);
            this.IDBot.Name = "IDBot";
            this.IDBot.Size = new System.Drawing.Size(323, 110);
            this.IDBot.TabIndex = 122;
            this.IDBot.TabStop = false;
            this.IDBot.Text = "ID Bot";
            // 
            // JPN
            // 
            this.JPN.AutoSize = true;
            this.JPN.Location = new System.Drawing.Point(252, 0);
            this.JPN.Name = "JPN";
            this.JPN.Size = new System.Drawing.Size(46, 17);
            this.JPN.TabIndex = 126;
            this.JPN.Text = "JPN";
            this.JPN.UseVisualStyleBackColor = true;
            // 
            // B_MashA
            // 
            this.B_MashA.Location = new System.Drawing.Point(248, 67);
            this.B_MashA.Name = "B_MashA";
            this.B_MashA.Size = new System.Drawing.Size(50, 25);
            this.B_MashA.TabIndex = 125;
            this.B_MashA.Text = "MashA";
            this.B_MashA.UseVisualStyleBackColor = true;
            this.B_MashA.Click += new System.EventHandler(this.B_MashA_Click);
            // 
            // B_A
            // 
            this.B_A.Location = new System.Drawing.Point(207, 67);
            this.B_A.Name = "B_A";
            this.B_A.Size = new System.Drawing.Size(26, 25);
            this.B_A.TabIndex = 123;
            this.B_A.Text = "A";
            this.B_A.UseVisualStyleBackColor = true;
            this.B_A.Click += new System.EventHandler(this.B_A_Click);
            // 
            // L_Speed
            // 
            this.L_Speed.AutoSize = true;
            this.L_Speed.Location = new System.Drawing.Point(201, 32);
            this.L_Speed.Name = "L_Speed";
            this.L_Speed.Size = new System.Drawing.Size(57, 13);
            this.L_Speed.TabIndex = 123;
            this.L_Speed.Text = "Bot Speed";
            // 
            // B_Stop
            // 
            this.B_Stop.Enabled = false;
            this.B_Stop.Location = new System.Drawing.Point(115, 67);
            this.B_Stop.Name = "B_Stop";
            this.B_Stop.Size = new System.Drawing.Size(69, 25);
            this.B_Stop.TabIndex = 124;
            this.B_Stop.Text = "Stop";
            this.B_Stop.UseVisualStyleBackColor = true;
            this.B_Stop.Click += new System.EventHandler(this.B_Stop_Click);
            // 
            // B_Start
            // 
            this.B_Start.Location = new System.Drawing.Point(18, 67);
            this.B_Start.Name = "B_Start";
            this.B_Start.Size = new System.Drawing.Size(69, 25);
            this.B_Start.TabIndex = 123;
            this.B_Start.Text = "Start";
            this.B_Start.UseVisualStyleBackColor = true;
            this.B_Start.Click += new System.EventHandler(this.B_Start_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 100;
            this.label1.Text = "->";
            // 
            // StopFrame
            // 
            this.StopFrame.AccessibleName = "";
            this.StopFrame.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopFrame.Location = new System.Drawing.Point(115, 28);
            this.StopFrame.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.StopFrame.Name = "StopFrame";
            this.StopFrame.Size = new System.Drawing.Size(73, 22);
            this.StopFrame.TabIndex = 99;
            this.StopFrame.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // StartFrame
            // 
            this.StartFrame.AccessibleName = "";
            this.StartFrame.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartFrame.Location = new System.Drawing.Point(18, 28);
            this.StartFrame.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.StartFrame.Name = "StartFrame";
            this.StartFrame.Size = new System.Drawing.Size(75, 22);
            this.StartFrame.TabIndex = 98;
            this.StartFrame.Value = new decimal(new int[] {
            1012,
            0,
            0,
            0});
            // 
            // Speed
            // 
            this.Speed.Location = new System.Drawing.Point(278, 129);
            this.Speed.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(32, 20);
            this.Speed.TabIndex = 125;
            this.Speed.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // NTRHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 222);
            this.Controls.Add(this.Speed);
            this.Controls.Add(this.IDBot);
            this.Controls.Add(this.B_Help);
            this.Controls.Add(this.B_OneClick);
            this.Controls.Add(this.L_NTRLog);
            this.Controls.Add(this.B_Disconnect);
            this.Controls.Add(this.B_Connect);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.IP);
            this.MaximumSize = new System.Drawing.Size(360, 260);
            this.MinimumSize = new System.Drawing.Size(360, 260);
            this.Name = "NTRHelper";
            this.Text = "NTRHelper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NTRHelper_FormClosing);
            this.IDBot.ResumeLayout(false);
            this.IDBot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StopFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Speed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_OneClick;
        private System.Windows.Forms.Label L_NTRLog;
        private System.Windows.Forms.Button B_Disconnect;
        private System.Windows.Forms.Button B_Connect;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox IP;
        private System.Windows.Forms.Timer NTR_Timer;
        private System.Windows.Forms.Button B_Help;
        private System.Windows.Forms.GroupBox IDBot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown StopFrame;
        private System.Windows.Forms.NumericUpDown StartFrame;
        private System.Windows.Forms.Button B_Stop;
        private System.Windows.Forms.Button B_Start;
        private System.Windows.Forms.Label L_Speed;
        private System.Windows.Forms.Button B_A;
        private System.Windows.Forms.NumericUpDown Speed;
        private System.Windows.Forms.Button B_MashA;
        private System.Windows.Forms.CheckBox JPN;
    }
}