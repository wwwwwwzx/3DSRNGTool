namespace Pk3DSRNGTool
{
    partial class TinyTimelineTool
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label0 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Frame1 = new System.Windows.Forms.NumericUpDown();
            this.B_Create = new System.Windows.Forms.Button();
            this.L_Mainframe = new System.Windows.Forms.Label();
            this.Frame_max = new System.Windows.Forms.NumericUpDown();
            this.L_TargetFrame = new System.Windows.Forms.Label();
            this.GB_Cali = new System.Windows.Forms.GroupBox();
            this.L_TypeNum = new System.Windows.Forms.Label();
            this.TypeNum = new System.Windows.Forms.NumericUpDown();
            this.L_Type = new System.Windows.Forms.Label();
            this.Type3 = new System.Windows.Forms.ComboBox();
            this.Frame3 = new System.Windows.Forms.NumericUpDown();
            this.Type2 = new System.Windows.Forms.ComboBox();
            this.Frame2 = new System.Windows.Forms.NumericUpDown();
            this.Type1 = new System.Windows.Forms.ComboBox();
            this.tiny3 = new Pk3DSRNGTool.Controls.HexMaskedTextBox();
            this.tiny2 = new Pk3DSRNGTool.Controls.HexMaskedTextBox();
            this.tiny0 = new Pk3DSRNGTool.Controls.HexMaskedTextBox();
            this.tiny1 = new Pk3DSRNGTool.Controls.HexMaskedTextBox();
            this.B_Stop = new System.Windows.Forms.Button();
            this.B_Cali = new System.Windows.Forms.Button();
            this.GB_Adj = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Delay = new System.Windows.Forms.NumericUpDown();
            this.ConsiderDelay = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Parameters = new System.Windows.Forms.NumericUpDown();
            this.Cry = new System.Windows.Forms.CheckBox();
            this.CryFrame = new System.Windows.Forms.NumericUpDown();
            this.L_Method = new System.Windows.Forms.Label();
            this.Method = new System.Windows.Forms.ComboBox();
            this.TTTToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.MainDGV = new System.Windows.Forms.DataGridView();
            this.tiny_MTFRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiny_index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiny_hitidx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiny_enctr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiny_sync = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiny_slot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiny_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiny_ha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiny_high16bit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiny_rand100 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiny_state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RealTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Frame1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Frame_max)).BeginInit();
            this.GB_Cali.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TypeNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Frame3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Frame2)).BeginInit();
            this.GB_Adj.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Delay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parameters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CryFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label0
            // 
            this.label0.AutoSize = true;
            this.label0.Font = new System.Drawing.Font("Consolas", 9F);
            this.label0.Location = new System.Drawing.Point(12, 114);
            this.label0.Name = "label0";
            this.label0.Size = new System.Drawing.Size(28, 14);
            this.label0.TabIndex = 107;
            this.label0.Text = "[0]";
            this.label0.DoubleClick += new System.EventHandler(this.Update_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9F);
            this.label1.Location = new System.Drawing.Point(12, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 14);
            this.label1.TabIndex = 106;
            this.label1.Text = "[1]";
            this.label1.DoubleClick += new System.EventHandler(this.Update_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9F);
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 14);
            this.label2.TabIndex = 105;
            this.label2.Text = "[2]";
            this.label2.DoubleClick += new System.EventHandler(this.Update_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 9F);
            this.label3.Location = new System.Drawing.Point(12, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 14);
            this.label3.TabIndex = 104;
            this.label3.Text = "[3]";
            this.label3.DoubleClick += new System.EventHandler(this.Update_Click);
            // 
            // CMS
            // 
            this.CMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyStatusToolStripMenuItem});
            this.CMS.Name = "CMS";
            this.CMS.Size = new System.Drawing.Size(138, 26);
            // 
            // copyStatusToolStripMenuItem
            // 
            this.copyStatusToolStripMenuItem.Name = "copyStatusToolStripMenuItem";
            this.copyStatusToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.copyStatusToolStripMenuItem.Text = "Copy Status";
            this.copyStatusToolStripMenuItem.Click += new System.EventHandler(this.copyStatusToolStripMenuItem_Click);
            // 
            // Frame1
            // 
            this.Frame1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Frame1.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.Frame1.Location = new System.Drawing.Point(15, 210);
            this.Frame1.Name = "Frame1";
            this.Frame1.Size = new System.Drawing.Size(73, 22);
            this.Frame1.TabIndex = 109;
            // 
            // B_Create
            // 
            this.B_Create.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.B_Create.Location = new System.Drawing.Point(99, 498);
            this.B_Create.Name = "B_Create";
            this.B_Create.Size = new System.Drawing.Size(76, 29);
            this.B_Create.TabIndex = 110;
            this.B_Create.Text = "Create";
            this.B_Create.UseVisualStyleBackColor = true;
            this.B_Create.Click += new System.EventHandler(this.B_Create_Click);
            // 
            // L_Mainframe
            // 
            this.L_Mainframe.AutoSize = true;
            this.L_Mainframe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Mainframe.Location = new System.Drawing.Point(12, 184);
            this.L_Mainframe.Name = "L_Mainframe";
            this.L_Mainframe.Size = new System.Drawing.Size(89, 13);
            this.L_Mainframe.TabIndex = 111;
            this.L_Mainframe.Text = "Main RNG Frame";
            // 
            // Frame_max
            // 
            this.Frame_max.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Frame_max.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.Frame_max.Location = new System.Drawing.Point(95, 62);
            this.Frame_max.Name = "Frame_max";
            this.Frame_max.Size = new System.Drawing.Size(88, 22);
            this.Frame_max.TabIndex = 112;
            // 
            // L_TargetFrame
            // 
            this.L_TargetFrame.AutoSize = true;
            this.L_TargetFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TargetFrame.Location = new System.Drawing.Point(10, 66);
            this.L_TargetFrame.Name = "L_TargetFrame";
            this.L_TargetFrame.Size = new System.Drawing.Size(70, 13);
            this.L_TargetFrame.TabIndex = 114;
            this.L_TargetFrame.Text = "Target Frame";
            // 
            // GB_Cali
            // 
            this.GB_Cali.Controls.Add(this.L_TypeNum);
            this.GB_Cali.Controls.Add(this.TypeNum);
            this.GB_Cali.Controls.Add(this.L_Type);
            this.GB_Cali.Controls.Add(this.Type3);
            this.GB_Cali.Controls.Add(this.Frame3);
            this.GB_Cali.Controls.Add(this.Type2);
            this.GB_Cali.Controls.Add(this.Frame2);
            this.GB_Cali.Controls.Add(this.Type1);
            this.GB_Cali.Controls.Add(this.L_Mainframe);
            this.GB_Cali.Controls.Add(this.Frame1);
            this.GB_Cali.Controls.Add(this.tiny3);
            this.GB_Cali.Controls.Add(this.label0);
            this.GB_Cali.Controls.Add(this.label3);
            this.GB_Cali.Controls.Add(this.tiny2);
            this.GB_Cali.Controls.Add(this.label2);
            this.GB_Cali.Controls.Add(this.label1);
            this.GB_Cali.Controls.Add(this.tiny0);
            this.GB_Cali.Controls.Add(this.tiny1);
            this.GB_Cali.Controls.Add(this.B_Stop);
            this.GB_Cali.Controls.Add(this.B_Cali);
            this.GB_Cali.Location = new System.Drawing.Point(5, 12);
            this.GB_Cali.Name = "GB_Cali";
            this.GB_Cali.Size = new System.Drawing.Size(189, 300);
            this.GB_Cali.TabIndex = 115;
            this.GB_Cali.TabStop = false;
            this.GB_Cali.Text = "Calibration";
            // 
            // L_TypeNum
            // 
            this.L_TypeNum.AutoSize = true;
            this.L_TypeNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TypeNum.Location = new System.Drawing.Point(14, 153);
            this.L_TypeNum.Name = "L_TypeNum";
            this.L_TypeNum.Size = new System.Drawing.Size(99, 13);
            this.L_TypeNum.TabIndex = 122;
            this.L_TypeNum.Text = "# of Advance Type";
            // 
            // TypeNum
            // 
            this.TypeNum.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TypeNum.Location = new System.Drawing.Point(127, 149);
            this.TypeNum.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.TypeNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TypeNum.Name = "TypeNum";
            this.TypeNum.Size = new System.Drawing.Size(43, 22);
            this.TypeNum.TabIndex = 118;
            this.TypeNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TypeNum.ValueChanged += new System.EventHandler(this.TypeNum_ValueChanged);
            // 
            // L_Type
            // 
            this.L_Type.AutoSize = true;
            this.L_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Type.Location = new System.Drawing.Point(101, 184);
            this.L_Type.Name = "L_Type";
            this.L_Type.Size = new System.Drawing.Size(77, 13);
            this.L_Type.TabIndex = 119;
            this.L_Type.Text = "Advance Type";
            // 
            // Type3
            // 
            this.Type3.Enabled = false;
            this.Type3.FormattingEnabled = true;
            this.Type3.Location = new System.Drawing.Point(101, 264);
            this.Type3.Name = "Type3";
            this.Type3.Size = new System.Drawing.Size(76, 21);
            this.Type3.TabIndex = 118;
            this.Type3.EnabledChanged += new System.EventHandler(this.Type_EnabledChanged);
            // 
            // Frame3
            // 
            this.Frame3.Enabled = false;
            this.Frame3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Frame3.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.Frame3.Location = new System.Drawing.Point(15, 265);
            this.Frame3.Name = "Frame3";
            this.Frame3.Size = new System.Drawing.Size(73, 22);
            this.Frame3.TabIndex = 117;
            // 
            // Type2
            // 
            this.Type2.Enabled = false;
            this.Type2.FormattingEnabled = true;
            this.Type2.Location = new System.Drawing.Point(101, 237);
            this.Type2.Name = "Type2";
            this.Type2.Size = new System.Drawing.Size(76, 21);
            this.Type2.TabIndex = 116;
            this.Type2.EnabledChanged += new System.EventHandler(this.Type_EnabledChanged);
            // 
            // Frame2
            // 
            this.Frame2.Enabled = false;
            this.Frame2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Frame2.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.Frame2.Location = new System.Drawing.Point(15, 238);
            this.Frame2.Name = "Frame2";
            this.Frame2.Size = new System.Drawing.Size(73, 22);
            this.Frame2.TabIndex = 112;
            // 
            // Type1
            // 
            this.Type1.FormattingEnabled = true;
            this.Type1.Location = new System.Drawing.Point(101, 211);
            this.Type1.Name = "Type1";
            this.Type1.Size = new System.Drawing.Size(76, 21);
            this.Type1.TabIndex = 112;
            // 
            // tiny3
            // 
            this.tiny3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiny3.Location = new System.Drawing.Point(40, 26);
            this.tiny3.Mask = "AAAAAAAA";
            this.tiny3.Name = "tiny3";
            this.tiny3.Size = new System.Drawing.Size(63, 22);
            this.tiny3.TabIndex = 100;
            this.tiny3.Text = "00000000";
            this.tiny3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tiny3.Value = ((uint)(0u));
            // 
            // tiny2
            // 
            this.tiny2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiny2.Location = new System.Drawing.Point(40, 54);
            this.tiny2.Mask = "AAAAAAAA";
            this.tiny2.Name = "tiny2";
            this.tiny2.Size = new System.Drawing.Size(63, 22);
            this.tiny2.TabIndex = 101;
            this.tiny2.Text = "00000000";
            this.tiny2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tiny2.Value = ((uint)(0u));
            // 
            // tiny0
            // 
            this.tiny0.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiny0.Location = new System.Drawing.Point(40, 111);
            this.tiny0.Mask = "AAAAAAAA";
            this.tiny0.Name = "tiny0";
            this.tiny0.Size = new System.Drawing.Size(63, 22);
            this.tiny0.TabIndex = 103;
            this.tiny0.Text = "00000000";
            this.tiny0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tiny0.Value = ((uint)(0u));
            // 
            // tiny1
            // 
            this.tiny1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiny1.Location = new System.Drawing.Point(40, 82);
            this.tiny1.Mask = "AAAAAAAA";
            this.tiny1.Name = "tiny1";
            this.tiny1.Size = new System.Drawing.Size(63, 22);
            this.tiny1.TabIndex = 102;
            this.tiny1.Text = "00000000";
            this.tiny1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tiny1.Value = ((uint)(0u));
            // 
            // B_Stop
            // 
            this.B_Stop.Location = new System.Drawing.Point(120, 110);
            this.B_Stop.Name = "B_Stop";
            this.B_Stop.Size = new System.Drawing.Size(58, 23);
            this.B_Stop.TabIndex = 121;
            this.B_Stop.Text = "Stop";
            this.B_Stop.UseVisualStyleBackColor = true;
            this.B_Stop.Visible = false;
            this.B_Stop.Click += new System.EventHandler(this.B_Stop_Click);
            // 
            // B_Cali
            // 
            this.B_Cali.Location = new System.Drawing.Point(120, 110);
            this.B_Cali.Name = "B_Cali";
            this.B_Cali.Size = new System.Drawing.Size(58, 23);
            this.B_Cali.TabIndex = 120;
            this.B_Cali.Text = "Calibrate";
            this.B_Cali.UseVisualStyleBackColor = true;
            this.B_Cali.Click += new System.EventHandler(this.B_Cali_Click);
            // 
            // GB_Adj
            // 
            this.GB_Adj.Controls.Add(this.label5);
            this.GB_Adj.Controls.Add(this.Delay);
            this.GB_Adj.Controls.Add(this.ConsiderDelay);
            this.GB_Adj.Controls.Add(this.label4);
            this.GB_Adj.Controls.Add(this.Parameters);
            this.GB_Adj.Controls.Add(this.Cry);
            this.GB_Adj.Controls.Add(this.CryFrame);
            this.GB_Adj.Controls.Add(this.L_Method);
            this.GB_Adj.Controls.Add(this.Method);
            this.GB_Adj.Controls.Add(this.Frame_max);
            this.GB_Adj.Controls.Add(this.L_TargetFrame);
            this.GB_Adj.Location = new System.Drawing.Point(5, 318);
            this.GB_Adj.Name = "GB_Adj";
            this.GB_Adj.Size = new System.Drawing.Size(189, 164);
            this.GB_Adj.TabIndex = 117;
            this.GB_Adj.TabStop = false;
            this.GB_Adj.Text = "Adjustment";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(162, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 127;
            this.label5.Text = "F";
            // 
            // Delay
            // 
            this.Delay.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delay.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.Delay.Location = new System.Drawing.Point(113, 94);
            this.Delay.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.Delay.Name = "Delay";
            this.Delay.Size = new System.Drawing.Size(43, 22);
            this.Delay.TabIndex = 126;
            // 
            // ConsiderDelay
            // 
            this.ConsiderDelay.AutoSize = true;
            this.ConsiderDelay.Location = new System.Drawing.Point(15, 97);
            this.ConsiderDelay.Name = "ConsiderDelay";
            this.ConsiderDelay.Size = new System.Drawing.Size(95, 17);
            this.ConsiderDelay.TabIndex = 125;
            this.ConsiderDelay.Text = "Consider delay";
            this.ConsiderDelay.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(162, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 124;
            this.label4.Text = "F";
            // 
            // Parameters
            // 
            this.Parameters.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Parameters.Location = new System.Drawing.Point(142, 26);
            this.Parameters.Name = "Parameters";
            this.Parameters.Size = new System.Drawing.Size(43, 22);
            this.Parameters.TabIndex = 117;
            // 
            // Cry
            // 
            this.Cry.AutoSize = true;
            this.Cry.Location = new System.Drawing.Point(15, 130);
            this.Cry.Name = "Cry";
            this.Cry.Size = new System.Drawing.Size(96, 17);
            this.Cry.TabIndex = 118;
            this.Cry.Text = "Cry at Target +";
            this.Cry.UseVisualStyleBackColor = true;
            this.Cry.EnabledChanged += new System.EventHandler(this.Cry_EnabledChanged);
            // 
            // CryFrame
            // 
            this.CryFrame.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CryFrame.Location = new System.Drawing.Point(113, 127);
            this.CryFrame.Name = "CryFrame";
            this.CryFrame.Size = new System.Drawing.Size(43, 22);
            this.CryFrame.TabIndex = 123;
            // 
            // L_Method
            // 
            this.L_Method.AutoSize = true;
            this.L_Method.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Method.Location = new System.Drawing.Point(7, 30);
            this.L_Method.Name = "L_Method";
            this.L_Method.Size = new System.Drawing.Size(43, 13);
            this.L_Method.TabIndex = 116;
            this.L_Method.Text = "Method";
            // 
            // Method
            // 
            this.Method.FormattingEnabled = true;
            this.Method.Items.AddRange(new object[] {
            "Instant Sync",
            "Cutscenes Sync",
            "Horde",
            "Friend Safari",
            "PokeRadar",
            "Fishing",
            "Rock Smash",
            "Cave Shadow"});
            this.Method.Location = new System.Drawing.Point(51, 26);
            this.Method.Name = "Method";
            this.Method.Size = new System.Drawing.Size(88, 21);
            this.Method.TabIndex = 115;
            this.Method.SelectedIndexChanged += new System.EventHandler(this.Method_SelectedIndexChanged);
            // 
            // MainDGV
            // 
            this.MainDGV.AllowUserToAddRows = false;
            this.MainDGV.AllowUserToDeleteRows = false;
            this.MainDGV.AllowUserToResizeRows = false;
            this.MainDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MainDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.MainDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.MainDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tiny_MTFRange,
            this.tiny_index,
            this.tiny_hitidx,
            this.tiny_enctr,
            this.tiny_sync,
            this.tiny_slot,
            this.tiny_item,
            this.tiny_ha,
            this.tiny_high16bit,
            this.tiny_rand100,
            this.tiny_state,
            this.RealTime});
            this.MainDGV.ContextMenuStrip = this.CMS;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MainDGV.DefaultCellStyle = dataGridViewCellStyle5;
            this.MainDGV.Location = new System.Drawing.Point(200, 12);
            this.MainDGV.Name = "MainDGV";
            this.MainDGV.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MainDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.MainDGV.RowHeadersWidth = 18;
            this.MainDGV.Size = new System.Drawing.Size(574, 515);
            this.MainDGV.TabIndex = 108;
            this.MainDGV.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.MainDGV_CellFormatting);
            this.MainDGV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainDGV_MouseDown);
            // 
            // tiny_MTFRange
            // 
            this.tiny_MTFRange.DataPropertyName = "FrameRange";
            this.tiny_MTFRange.HeaderText = "Main RNG Frame";
            this.tiny_MTFRange.Name = "tiny_MTFRange";
            this.tiny_MTFRange.ReadOnly = true;
            this.tiny_MTFRange.Width = 112;
            // 
            // tiny_index
            // 
            this.tiny_index.DataPropertyName = "Index";
            this.tiny_index.HeaderText = "Index";
            this.tiny_index.Name = "tiny_index";
            this.tiny_index.ReadOnly = true;
            this.tiny_index.Width = 35;
            // 
            // tiny_hitidx
            // 
            this.tiny_hitidx.DataPropertyName = "HitIndex";
            this.tiny_hitidx.HeaderText = "Hit";
            this.tiny_hitidx.Name = "tiny_hitidx";
            this.tiny_hitidx.ReadOnly = true;
            this.tiny_hitidx.Visible = false;
            this.tiny_hitidx.Width = 35;
            // 
            // tiny_enctr
            // 
            this.tiny_enctr.DataPropertyName = "Encounter";
            this.tiny_enctr.HeaderText = "Enctr?";
            this.tiny_enctr.Name = "tiny_enctr";
            this.tiny_enctr.ReadOnly = true;
            this.tiny_enctr.Width = 45;
            // 
            // tiny_sync
            // 
            this.tiny_sync.DataPropertyName = "Sync";
            this.tiny_sync.HeaderText = "Sync";
            this.tiny_sync.Name = "tiny_sync";
            this.tiny_sync.ReadOnly = true;
            this.tiny_sync.Width = 40;
            // 
            // tiny_slot
            // 
            this.tiny_slot.DataPropertyName = "Slot";
            this.tiny_slot.HeaderText = "Slot";
            this.tiny_slot.Name = "tiny_slot";
            this.tiny_slot.ReadOnly = true;
            this.tiny_slot.Width = 40;
            // 
            // tiny_item
            // 
            this.tiny_item.DataPropertyName = "Item";
            this.tiny_item.HeaderText = "Item";
            this.tiny_item.Name = "tiny_item";
            this.tiny_item.ReadOnly = true;
            this.tiny_item.Width = 40;
            // 
            // tiny_ha
            // 
            this.tiny_ha.DataPropertyName = "HA";
            this.tiny_ha.HeaderText = "HA";
            this.tiny_ha.Name = "tiny_ha";
            this.tiny_ha.ReadOnly = true;
            this.tiny_ha.Width = 35;
            // 
            // tiny_high16bit
            // 
            this.tiny_high16bit.DataPropertyName = "High16bit";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.Format = "X4";
            this.tiny_high16bit.DefaultCellStyle = dataGridViewCellStyle2;
            this.tiny_high16bit.HeaderText = "High16";
            this.tiny_high16bit.Name = "tiny_high16bit";
            this.tiny_high16bit.ReadOnly = true;
            this.tiny_high16bit.Width = 45;
            // 
            // tiny_rand100
            // 
            this.tiny_rand100.DataPropertyName = "Rand100";
            this.tiny_rand100.HeaderText = "M100";
            this.tiny_rand100.Name = "tiny_rand100";
            this.tiny_rand100.ReadOnly = true;
            this.tiny_rand100.Width = 40;
            // 
            // tiny_state
            // 
            this.tiny_state.DataPropertyName = "Status";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiny_state.DefaultCellStyle = dataGridViewCellStyle3;
            this.tiny_state.HeaderText = "Tiny Status";
            this.tiny_state.Name = "tiny_state";
            this.tiny_state.ReadOnly = true;
            this.tiny_state.Width = 255;
            // 
            // RealTime
            // 
            this.RealTime.DataPropertyName = "RealTime";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.RealTime.DefaultCellStyle = dataGridViewCellStyle4;
            this.RealTime.HeaderText = "Real Time";
            this.RealTime.Name = "RealTime";
            this.RealTime.ReadOnly = true;
            this.RealTime.Width = 160;
            // 
            // TinyTimelineTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 539);
            this.Controls.Add(this.GB_Adj);
            this.Controls.Add(this.GB_Cali);
            this.Controls.Add(this.B_Create);
            this.Controls.Add(this.MainDGV);
            this.MinimumSize = new System.Drawing.Size(800, 545);
            this.Name = "TinyTimelineTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tiny Timeline Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TinyTimelineTool_FormClosing);
            this.CMS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Frame1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Frame_max)).EndInit();
            this.GB_Cali.ResumeLayout(false);
            this.GB_Cali.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TypeNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Frame3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Frame2)).EndInit();
            this.GB_Adj.ResumeLayout(false);
            this.GB_Adj.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Delay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parameters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CryFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label0;
        private Controls.HexMaskedTextBox tiny2;
        private System.Windows.Forms.Label label1;
        private Controls.HexMaskedTextBox tiny1;
        private Controls.HexMaskedTextBox tiny0;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown Frame1;
        private System.Windows.Forms.Button B_Create;
        private System.Windows.Forms.Label L_Mainframe;
        private System.Windows.Forms.NumericUpDown Frame_max;
        private System.Windows.Forms.Label L_TargetFrame;
        private System.Windows.Forms.GroupBox GB_Cali;
        private System.Windows.Forms.ComboBox Type2;
        private System.Windows.Forms.NumericUpDown Frame2;
        private System.Windows.Forms.ComboBox Type1;
        private System.Windows.Forms.GroupBox GB_Adj;
        private System.Windows.Forms.ContextMenuStrip CMS;
        private System.Windows.Forms.ToolStripMenuItem copyStatusToolStripMenuItem;
        private System.Windows.Forms.ComboBox Type3;
        private System.Windows.Forms.NumericUpDown Frame3;
        public System.Windows.Forms.ComboBox Method;
        private System.Windows.Forms.Label L_Method;
        private System.Windows.Forms.Label L_Type;
        public System.Windows.Forms.NumericUpDown Parameters;
        private System.Windows.Forms.ToolTip TTTToolTip;
        private System.Windows.Forms.DataGridView MainDGV;
        public System.Windows.Forms.Button B_Cali;
        public System.Windows.Forms.Button B_Stop;
        private System.Windows.Forms.Label L_TypeNum;
        public System.Windows.Forms.NumericUpDown TypeNum;
        public System.Windows.Forms.CheckBox Cry;
        public System.Windows.Forms.NumericUpDown CryFrame;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.NumericUpDown Delay;
        public System.Windows.Forms.CheckBox ConsiderDelay;
        private Controls.HexMaskedTextBox tiny3;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiny_MTFRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiny_index;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiny_hitidx;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiny_enctr;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiny_sync;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiny_slot;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiny_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiny_ha;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiny_high16bit;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiny_rand100;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiny_state;
        private System.Windows.Forms.DataGridViewTextBoxColumn RealTime;
    }
}