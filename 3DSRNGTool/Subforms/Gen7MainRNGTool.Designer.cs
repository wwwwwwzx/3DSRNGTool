namespace Pk3DSRNGTool
{
    partial class Gen7MainRNGTool
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RB_SaveScreen = new System.Windows.Forms.RadioButton();
            this.InputBox = new System.Windows.Forms.GroupBox();
            this.button16 = new System.Windows.Forms.Button();
            this.EndClockInput = new System.Windows.Forms.RadioButton();
            this.L_clocklist = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.StartClockInput = new System.Windows.Forms.RadioButton();
            this.Clock_List = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button0 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.L_StartingFrame = new System.Windows.Forms.Label();
            this.Time_min = new System.Windows.Forms.NumericUpDown();
            this.SearchSeedBox = new System.Windows.Forms.GroupBox();
            this.RB_QR = new System.Windows.Forms.RadioButton();
            this.SeedResults = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ListResults = new System.Windows.Forms.ListBox();
            this.RB_ID = new System.Windows.Forms.RadioButton();
            this.Frame_max = new System.Windows.Forms.NumericUpDown();
            this.L_SeedResult = new System.Windows.Forms.Label();
            this.Search = new System.Windows.Forms.Button();
            this.Frame_min = new System.Windows.Forms.NumericUpDown();
            this.TargetFrame = new System.Windows.Forms.NumericUpDown();
            this.TimeCalculator = new System.Windows.Forms.GroupBox();
            this.L_TargetFrame = new System.Windows.Forms.Label();
            this.B_Calc = new System.Windows.Forms.Button();
            this.NPC = new System.Windows.Forms.NumericUpDown();
            this.L_NPC = new System.Windows.Forms.Label();
            this.InputBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Time_min)).BeginInit();
            this.SearchSeedBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Frame_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Frame_min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetFrame)).BeginInit();
            this.TimeCalculator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NPC)).BeginInit();
            this.SuspendLayout();
            // 
            // RB_SaveScreen
            // 
            this.RB_SaveScreen.AutoSize = true;
            this.RB_SaveScreen.Checked = true;
            this.RB_SaveScreen.Location = new System.Drawing.Point(11, 23);
            this.RB_SaveScreen.Name = "RB_SaveScreen";
            this.RB_SaveScreen.Size = new System.Drawing.Size(146, 17);
            this.RB_SaveScreen.TabIndex = 38;
            this.RB_SaveScreen.TabStop = true;
            this.RB_SaveScreen.Text = "读档指针序列检索Seed";
            this.RB_SaveScreen.UseVisualStyleBackColor = false;
            this.RB_SaveScreen.CheckedChanged += new System.EventHandler(this.RB_CheckedChanged);
            // 
            // InputBox
            // 
            this.InputBox.Controls.Add(this.button16);
            this.InputBox.Controls.Add(this.EndClockInput);
            this.InputBox.Controls.Add(this.L_clocklist);
            this.InputBox.Controls.Add(this.button9);
            this.InputBox.Controls.Add(this.button8);
            this.InputBox.Controls.Add(this.Clear);
            this.InputBox.Controls.Add(this.StartClockInput);
            this.InputBox.Controls.Add(this.Clock_List);
            this.InputBox.Controls.Add(this.button10);
            this.InputBox.Controls.Add(this.Back);
            this.InputBox.Controls.Add(this.button7);
            this.InputBox.Controls.Add(this.button11);
            this.InputBox.Controls.Add(this.button6);
            this.InputBox.Controls.Add(this.button12);
            this.InputBox.Controls.Add(this.button5);
            this.InputBox.Controls.Add(this.button0);
            this.InputBox.Controls.Add(this.button13);
            this.InputBox.Controls.Add(this.button1);
            this.InputBox.Controls.Add(this.button4);
            this.InputBox.Controls.Add(this.button14);
            this.InputBox.Controls.Add(this.button2);
            this.InputBox.Controls.Add(this.button3);
            this.InputBox.Controls.Add(this.button15);
            this.InputBox.Location = new System.Drawing.Point(12, 12);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(803, 137);
            this.InputBox.TabIndex = 39;
            this.InputBox.TabStop = false;
            this.InputBox.Text = "输入工具";
            // 
            // button16
            // 
            this.button16.BackgroundImage = global::Pk3DSRNGTool.Properties.Resources.Clock_16;
            this.button16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button16.Location = new System.Drawing.Point(749, 31);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(40, 40);
            this.button16.TabIndex = 15;
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.Get_Clock_Number);
            // 
            // EndClockInput
            // 
            this.EndClockInput.AutoSize = true;
            this.EndClockInput.Checked = true;
            this.EndClockInput.Location = new System.Drawing.Point(18, 109);
            this.EndClockInput.Name = "EndClockInput";
            this.EndClockInput.Size = new System.Drawing.Size(73, 17);
            this.EndClockInput.TabIndex = 18;
            this.EndClockInput.TabStop = true;
            this.EndClockInput.Text = "结束位置";
            this.EndClockInput.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EndClockInput.UseVisualStyleBackColor = true;
            // 
            // L_clocklist
            // 
            this.L_clocklist.AutoSize = true;
            this.L_clocklist.Location = new System.Drawing.Point(392, 101);
            this.L_clocklist.Name = "L_clocklist";
            this.L_clocklist.Size = new System.Drawing.Size(55, 13);
            this.L_clocklist.TabIndex = 22;
            this.L_clocklist.Text = "指针序列";
            // 
            // button9
            // 
            this.button9.BackgroundImage = global::Pk3DSRNGTool.Properties.Resources.Clock_09;
            this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button9.Location = new System.Drawing.Point(427, 31);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(40, 40);
            this.button9.TabIndex = 8;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.Get_Clock_Number);
            // 
            // button8
            // 
            this.button8.BackgroundImage = global::Pk3DSRNGTool.Properties.Resources.Clock_08;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button8.Location = new System.Drawing.Point(381, 31);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(40, 40);
            this.button8.TabIndex = 7;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.Get_Clock_Number);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(254, 96);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(72, 27);
            this.Clear.TabIndex = 17;
            this.Clear.Text = "清空";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // StartClockInput
            // 
            this.StartClockInput.AutoSize = true;
            this.StartClockInput.Location = new System.Drawing.Point(18, 86);
            this.StartClockInput.Name = "StartClockInput";
            this.StartClockInput.Size = new System.Drawing.Size(73, 17);
            this.StartClockInput.TabIndex = 7;
            this.StartClockInput.Text = "开始位置";
            this.StartClockInput.UseVisualStyleBackColor = true;
            // 
            // Clock_List
            // 
            this.Clock_List.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clock_List.Location = new System.Drawing.Point(453, 96);
            this.Clock_List.Name = "Clock_List";
            this.Clock_List.Size = new System.Drawing.Size(244, 22);
            this.Clock_List.TabIndex = 19;
            // 
            // button10
            // 
            this.button10.BackgroundImage = global::Pk3DSRNGTool.Properties.Resources.Clock_10;
            this.button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button10.Location = new System.Drawing.Point(473, 31);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(40, 40);
            this.button10.TabIndex = 9;
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.Get_Clock_Number);
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(144, 96);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(72, 27);
            this.Back.TabIndex = 7;
            this.Back.Text = "后退";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // button7
            // 
            this.button7.BackgroundImage = global::Pk3DSRNGTool.Properties.Resources.Clock_07;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button7.Location = new System.Drawing.Point(335, 31);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(40, 40);
            this.button7.TabIndex = 6;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Get_Clock_Number);
            // 
            // button11
            // 
            this.button11.BackgroundImage = global::Pk3DSRNGTool.Properties.Resources.Clock_11;
            this.button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button11.Location = new System.Drawing.Point(519, 31);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(40, 40);
            this.button11.TabIndex = 10;
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.Get_Clock_Number);
            // 
            // button6
            // 
            this.button6.BackgroundImage = global::Pk3DSRNGTool.Properties.Resources.Clock_06;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button6.Location = new System.Drawing.Point(289, 31);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(40, 40);
            this.button6.TabIndex = 5;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Get_Clock_Number);
            // 
            // button12
            // 
            this.button12.BackgroundImage = global::Pk3DSRNGTool.Properties.Resources.Clock_12;
            this.button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button12.Location = new System.Drawing.Point(565, 31);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(40, 40);
            this.button12.TabIndex = 11;
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.Get_Clock_Number);
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::Pk3DSRNGTool.Properties.Resources.Clock_05;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button5.Location = new System.Drawing.Point(243, 31);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(40, 40);
            this.button5.TabIndex = 4;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Get_Clock_Number);
            // 
            // button0
            // 
            this.button0.BackgroundImage = global::Pk3DSRNGTool.Properties.Resources.Clock_00;
            this.button0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button0.Location = new System.Drawing.Point(13, 31);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(40, 40);
            this.button0.TabIndex = 16;
            this.button0.UseVisualStyleBackColor = true;
            this.button0.Click += new System.EventHandler(this.Get_Clock_Number);
            // 
            // button13
            // 
            this.button13.BackgroundImage = global::Pk3DSRNGTool.Properties.Resources.Clock_13;
            this.button13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button13.Location = new System.Drawing.Point(611, 31);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(40, 40);
            this.button13.TabIndex = 12;
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.Get_Clock_Number);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Pk3DSRNGTool.Properties.Resources.Clock_01;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(59, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Get_Clock_Number);
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::Pk3DSRNGTool.Properties.Resources.Clock_04;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.Location = new System.Drawing.Point(197, 31);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(40, 40);
            this.button4.TabIndex = 3;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Get_Clock_Number);
            // 
            // button14
            // 
            this.button14.BackgroundImage = global::Pk3DSRNGTool.Properties.Resources.Clock_14;
            this.button14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button14.Location = new System.Drawing.Point(657, 31);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(40, 40);
            this.button14.TabIndex = 13;
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.Get_Clock_Number);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::Pk3DSRNGTool.Properties.Resources.Clock_02;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Location = new System.Drawing.Point(105, 31);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 40);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Get_Clock_Number);
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::Pk3DSRNGTool.Properties.Resources.Clock_03;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.Location = new System.Drawing.Point(151, 31);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 40);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Get_Clock_Number);
            // 
            // button15
            // 
            this.button15.BackgroundImage = global::Pk3DSRNGTool.Properties.Resources.Clock_15;
            this.button15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button15.Location = new System.Drawing.Point(703, 31);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(40, 40);
            this.button15.TabIndex = 14;
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.Get_Clock_Number);
            // 
            // L_StartingFrame
            // 
            this.L_StartingFrame.AutoSize = true;
            this.L_StartingFrame.Location = new System.Drawing.Point(21, 35);
            this.L_StartingFrame.Name = "L_StartingFrame";
            this.L_StartingFrame.Size = new System.Drawing.Size(43, 13);
            this.L_StartingFrame.TabIndex = 98;
            this.L_StartingFrame.Text = "起点帧";
            // 
            // Time_min
            // 
            this.Time_min.AccessibleName = "";
            this.Time_min.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Time_min.Location = new System.Drawing.Point(113, 33);
            this.Time_min.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.Time_min.Minimum = new decimal(new int[] {
            418,
            0,
            0,
            0});
            this.Time_min.Name = "Time_min";
            this.Time_min.Size = new System.Drawing.Size(73, 22);
            this.Time_min.TabIndex = 99;
            this.Time_min.Value = new decimal(new int[] {
            425,
            0,
            0,
            0});
            // 
            // SearchSeedBox
            // 
            this.SearchSeedBox.Controls.Add(this.RB_QR);
            this.SearchSeedBox.Controls.Add(this.SeedResults);
            this.SearchSeedBox.Controls.Add(this.label7);
            this.SearchSeedBox.Controls.Add(this.ListResults);
            this.SearchSeedBox.Controls.Add(this.RB_SaveScreen);
            this.SearchSeedBox.Controls.Add(this.RB_ID);
            this.SearchSeedBox.Controls.Add(this.Frame_max);
            this.SearchSeedBox.Controls.Add(this.L_SeedResult);
            this.SearchSeedBox.Controls.Add(this.Search);
            this.SearchSeedBox.Controls.Add(this.Frame_min);
            this.SearchSeedBox.Location = new System.Drawing.Point(12, 155);
            this.SearchSeedBox.Name = "SearchSeedBox";
            this.SearchSeedBox.Size = new System.Drawing.Size(535, 165);
            this.SearchSeedBox.TabIndex = 36;
            this.SearchSeedBox.TabStop = false;
            // 
            // RB_QR
            // 
            this.RB_QR.AutoSize = true;
            this.RB_QR.Location = new System.Drawing.Point(11, 58);
            this.RB_QR.Name = "RB_QR";
            this.RB_QR.Size = new System.Drawing.Size(137, 17);
            this.RB_QR.TabIndex = 40;
            this.RB_QR.Text = "QR指针序列检索位置";
            this.RB_QR.UseVisualStyleBackColor = false;
            this.RB_QR.CheckedChanged += new System.EventHandler(this.RB_CheckedChanged);
            // 
            // SeedResults
            // 
            this.SeedResults.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeedResults.Location = new System.Drawing.Point(225, 47);
            this.SeedResults.Name = "SeedResults";
            this.SeedResults.Size = new System.Drawing.Size(297, 22);
            this.SeedResults.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(110, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 103;
            this.label7.Text = "->";
            // 
            // ListResults
            // 
            this.ListResults.FormattingEnabled = true;
            this.ListResults.Location = new System.Drawing.Point(225, 47);
            this.ListResults.Name = "ListResults";
            this.ListResults.Size = new System.Drawing.Size(297, 108);
            this.ListResults.TabIndex = 101;
            this.ListResults.Visible = false;
            // 
            // RB_ID
            // 
            this.RB_ID.AutoSize = true;
            this.RB_ID.Location = new System.Drawing.Point(11, 129);
            this.RB_ID.Name = "RB_ID";
            this.RB_ID.Size = new System.Drawing.Size(60, 17);
            this.RB_ID.TabIndex = 24;
            this.RB_ID.Text = "ID乱数";
            this.RB_ID.UseVisualStyleBackColor = true;
            this.RB_ID.CheckedChanged += new System.EventHandler(this.RB_CheckedChanged);
            // 
            // Frame_max
            // 
            this.Frame_max.AccessibleName = "";
            this.Frame_max.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Frame_max.Increment = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.Frame_max.Location = new System.Drawing.Point(138, 94);
            this.Frame_max.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.Frame_max.Minimum = new decimal(new int[] {
            418,
            0,
            0,
            0});
            this.Frame_max.Name = "Frame_max";
            this.Frame_max.Size = new System.Drawing.Size(75, 22);
            this.Frame_max.TabIndex = 102;
            this.Frame_max.Value = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            // 
            // L_SeedResult
            // 
            this.L_SeedResult.AutoSize = true;
            this.L_SeedResult.Location = new System.Drawing.Point(222, 22);
            this.L_SeedResult.Name = "L_SeedResult";
            this.L_SeedResult.Size = new System.Drawing.Size(55, 13);
            this.L_SeedResult.TabIndex = 6;
            this.L_SeedResult.Text = "检索结果";
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(141, 125);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(72, 27);
            this.Search.TabIndex = 21;
            this.Search.Text = "检索";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // Frame_min
            // 
            this.Frame_min.AccessibleName = "";
            this.Frame_min.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Frame_min.Location = new System.Drawing.Point(22, 94);
            this.Frame_min.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.Frame_min.Minimum = new decimal(new int[] {
            418,
            0,
            0,
            0});
            this.Frame_min.Name = "Frame_min";
            this.Frame_min.Size = new System.Drawing.Size(75, 22);
            this.Frame_min.TabIndex = 101;
            this.Frame_min.Value = new decimal(new int[] {
            418,
            0,
            0,
            0});
            // 
            // TargetFrame
            // 
            this.TargetFrame.AccessibleName = "";
            this.TargetFrame.Enabled = false;
            this.TargetFrame.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TargetFrame.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.TargetFrame.Location = new System.Drawing.Point(113, 76);
            this.TargetFrame.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.TargetFrame.Name = "TargetFrame";
            this.TargetFrame.Size = new System.Drawing.Size(73, 22);
            this.TargetFrame.TabIndex = 100;
            // 
            // TimeCalculator
            // 
            this.TimeCalculator.Controls.Add(this.L_TargetFrame);
            this.TimeCalculator.Controls.Add(this.B_Calc);
            this.TimeCalculator.Controls.Add(this.NPC);
            this.TimeCalculator.Controls.Add(this.L_NPC);
            this.TimeCalculator.Controls.Add(this.L_StartingFrame);
            this.TimeCalculator.Controls.Add(this.TargetFrame);
            this.TimeCalculator.Controls.Add(this.Time_min);
            this.TimeCalculator.Location = new System.Drawing.Point(565, 155);
            this.TimeCalculator.Name = "TimeCalculator";
            this.TimeCalculator.Size = new System.Drawing.Size(250, 165);
            this.TimeCalculator.TabIndex = 104;
            this.TimeCalculator.TabStop = false;
            this.TimeCalculator.Text = "Time Calculator";
            // 
            // L_TargetFrame
            // 
            this.L_TargetFrame.AutoSize = true;
            this.L_TargetFrame.Location = new System.Drawing.Point(21, 80);
            this.L_TargetFrame.Name = "L_TargetFrame";
            this.L_TargetFrame.Size = new System.Drawing.Size(43, 13);
            this.L_TargetFrame.TabIndex = 106;
            this.L_TargetFrame.Text = "目标帧";
            // 
            // B_Calc
            // 
            this.B_Calc.Location = new System.Drawing.Point(164, 118);
            this.B_Calc.Name = "B_Calc";
            this.B_Calc.Size = new System.Drawing.Size(72, 27);
            this.B_Calc.TabIndex = 104;
            this.B_Calc.Text = "计算";
            this.B_Calc.UseVisualStyleBackColor = true;
            this.B_Calc.Click += new System.EventHandler(this.CalcTime);
            // 
            // NPC
            // 
            this.NPC.AccessibleName = "";
            this.NPC.Enabled = false;
            this.NPC.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NPC.Location = new System.Drawing.Point(81, 119);
            this.NPC.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.NPC.Name = "NPC";
            this.NPC.Size = new System.Drawing.Size(52, 22);
            this.NPC.TabIndex = 105;
            this.NPC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // L_NPC
            // 
            this.L_NPC.AutoSize = true;
            this.L_NPC.Location = new System.Drawing.Point(21, 125);
            this.L_NPC.Name = "L_NPC";
            this.L_NPC.Size = new System.Drawing.Size(29, 13);
            this.L_NPC.TabIndex = 105;
            this.L_NPC.Text = "NPC";
            // 
            // Gen7MainRNGTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(824, 327);
            this.Controls.Add(this.TimeCalculator);
            this.Controls.Add(this.InputBox);
            this.Controls.Add(this.SearchSeedBox);
            this.MaximumSize = new System.Drawing.Size(840, 365);
            this.MinimumSize = new System.Drawing.Size(840, 365);
            this.Name = "Gen7MainRNGTool";
            this.Text = "Gen7MainRNGTool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Gen7MainRNGTool_FormClosing);
            this.InputBox.ResumeLayout(false);
            this.InputBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Time_min)).EndInit();
            this.SearchSeedBox.ResumeLayout(false);
            this.SearchSeedBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Frame_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Frame_min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetFrame)).EndInit();
            this.TimeCalculator.ResumeLayout(false);
            this.TimeCalculator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NPC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton RB_SaveScreen;
        private System.Windows.Forms.GroupBox InputBox;
        private System.Windows.Forms.Label L_StartingFrame;
        private System.Windows.Forms.NumericUpDown Time_min;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.RadioButton EndClockInput;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.RadioButton StartClockInput;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button0;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.GroupBox SearchSeedBox;
        private System.Windows.Forms.RadioButton RB_ID;
        private System.Windows.Forms.Label L_clocklist;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Label L_SeedResult;
        private System.Windows.Forms.TextBox Clock_List;
        private System.Windows.Forms.RadioButton RB_QR;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown Frame_max;
        private System.Windows.Forms.NumericUpDown Frame_min;
        private System.Windows.Forms.NumericUpDown TargetFrame;
        private System.Windows.Forms.TextBox SeedResults;
        private System.Windows.Forms.ListBox ListResults;
        private System.Windows.Forms.GroupBox TimeCalculator;
        private System.Windows.Forms.Label L_NPC;
        private System.Windows.Forms.NumericUpDown NPC;
        private System.Windows.Forms.Button B_Calc;
        private System.Windows.Forms.Label L_TargetFrame;
    }
}