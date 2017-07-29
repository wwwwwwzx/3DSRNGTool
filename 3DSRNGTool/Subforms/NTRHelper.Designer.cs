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
            this.B_BreakPoint = new System.Windows.Forms.Button();
            this.L_NTRLog = new System.Windows.Forms.Label();
            this.B_Resume = new System.Windows.Forms.Button();
            this.B_Disconnect = new System.Windows.Forms.Button();
            this.B_Connect = new System.Windows.Forms.Button();
            this.B_GetGen6Seed = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.IP = new System.Windows.Forms.TextBox();
            this.NTR_Timer = new System.Windows.Forms.Timer(this.components);
            this.B_Help = new System.Windows.Forms.Button();
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
            this.B_OneClick.Click += new System.EventHandler(this.B_OneClick_Click);
            // 
            // B_BreakPoint
            // 
            this.B_BreakPoint.Enabled = false;
            this.B_BreakPoint.Location = new System.Drawing.Point(25, 98);
            this.B_BreakPoint.Name = "B_BreakPoint";
            this.B_BreakPoint.Size = new System.Drawing.Size(90, 25);
            this.B_BreakPoint.TabIndex = 119;
            this.B_BreakPoint.Text = "Set BreakPoint";
            this.B_BreakPoint.UseVisualStyleBackColor = true;
            this.B_BreakPoint.Click += new System.EventHandler(this.B_BreakPoint_Click);
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
            // B_Resume
            // 
            this.B_Resume.Enabled = false;
            this.B_Resume.Location = new System.Drawing.Point(133, 98);
            this.B_Resume.Name = "B_Resume";
            this.B_Resume.Size = new System.Drawing.Size(69, 25);
            this.B_Resume.TabIndex = 118;
            this.B_Resume.Text = "Resume";
            this.B_Resume.UseVisualStyleBackColor = true;
            this.B_Resume.Click += new System.EventHandler(this.B_Resume_Click);
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
            // B_GetGen6Seed
            // 
            this.B_GetGen6Seed.Enabled = false;
            this.B_GetGen6Seed.Location = new System.Drawing.Point(223, 98);
            this.B_GetGen6Seed.Name = "B_GetGen6Seed";
            this.B_GetGen6Seed.Size = new System.Drawing.Size(102, 25);
            this.B_GetGen6Seed.TabIndex = 115;
            this.B_GetGen6Seed.Text = "Get Initial Seed";
            this.B_GetGen6Seed.UseVisualStyleBackColor = true;
            this.B_GetGen6Seed.Click += new System.EventHandler(this.B_GetGen6Seed_Click);
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
            this.B_Help.Location = new System.Drawing.Point(311, 22);
            this.B_Help.Name = "B_Help";
            this.B_Help.Size = new System.Drawing.Size(24, 25);
            this.B_Help.TabIndex = 121;
            this.B_Help.Text = "?";
            this.B_Help.UseVisualStyleBackColor = true;
            this.B_Help.Click += new System.EventHandler(this.B_Help_Click);
            // 
            // NTRHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 137);
            this.Controls.Add(this.B_Help);
            this.Controls.Add(this.B_OneClick);
            this.Controls.Add(this.B_BreakPoint);
            this.Controls.Add(this.L_NTRLog);
            this.Controls.Add(this.B_Resume);
            this.Controls.Add(this.B_Disconnect);
            this.Controls.Add(this.B_Connect);
            this.Controls.Add(this.B_GetGen6Seed);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.IP);
            this.MaximumSize = new System.Drawing.Size(360, 175);
            this.MinimumSize = new System.Drawing.Size(360, 175);
            this.Name = "NTRHelper";
            this.Text = "NTRHelper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NTRHelper_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_OneClick;
        private System.Windows.Forms.Button B_BreakPoint;
        private System.Windows.Forms.Label L_NTRLog;
        private System.Windows.Forms.Button B_Resume;
        private System.Windows.Forms.Button B_Disconnect;
        private System.Windows.Forms.Button B_Connect;
        private System.Windows.Forms.Button B_GetGen6Seed;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox IP;
        private System.Windows.Forms.Timer NTR_Timer;
        private System.Windows.Forms.Button B_Help;
    }
}