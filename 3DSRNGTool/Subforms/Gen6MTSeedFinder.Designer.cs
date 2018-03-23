namespace Pk3DSRNGTool
{
    partial class Gen6MTSeedFinder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.RB_1Wild = new System.Windows.Forms.RadioButton();
            this.RB_2Wild = new System.Windows.Forms.RadioButton();
            this.label35 = new System.Windows.Forms.Label();
            this.Seed_max = new Pk3DSRNGTool.Controls.HexMaskedTextBox();
            this.Seed_min = new Pk3DSRNGTool.Controls.HexMaskedTextBox();
            this.L_SeedRange = new System.Windows.Forms.Label();
            this.L_Progress6 = new System.Windows.Forms.Label();
            this.DGV_Seed = new System.Windows.Forms.DataGridView();
            this.dgv_Seed_seed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Seed_frame1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Seed_Nature1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Seed_frame2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Seed_nature2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.B_Search = new System.Windows.Forms.Button();
            this.Gen6PBar = new System.Windows.Forms.ProgressBar();
            this.B_Abort = new System.Windows.Forms.Button();
            this.WildPanel2 = new System.Windows.Forms.Panel();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.L_WildFrameRange = new System.Windows.Forms.Label();
            this.L_IV = new System.Windows.Forms.Label();
            this.Wild1_Fmax = new System.Windows.Forms.NumericUpDown();
            this.L_Wild1 = new System.Windows.Forms.Label();
            this.WildIV1 = new System.Windows.Forms.TextBox();
            this.L_Wild2 = new System.Windows.Forms.Label();
            this.WildIV2 = new System.Windows.Forms.TextBox();
            this.Wild1_Fmin = new System.Windows.Forms.NumericUpDown();
            this.Wild2_Fmin = new System.Windows.Forms.NumericUpDown();
            this.Wild2_Fmax = new System.Windows.Forms.NumericUpDown();
            this.WildPanel1 = new System.Windows.Forms.Panel();
            this.L_Nature = new System.Windows.Forms.Label();
            this.Wild_Nature = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.L_WildFrameRange2 = new System.Windows.Forms.Label();
            this.L_WildLower = new System.Windows.Forms.Label();
            this.Wild_max = new System.Windows.Forms.NumericUpDown();
            this.L_WildUpper = new System.Windows.Forms.Label();
            this.Wild_min = new System.Windows.Forms.NumericUpDown();
            this.L_WildIVRange = new System.Windows.Forms.Label();
            this.Wild_upper = new System.Windows.Forms.TextBox();
            this.Wild_lower = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Seed)).BeginInit();
            this.WildPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Wild1_Fmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wild1_Fmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wild2_Fmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wild2_Fmax)).BeginInit();
            this.WildPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Wild_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wild_min)).BeginInit();
            this.SuspendLayout();
            // 
            // RB_1Wild
            // 
            this.RB_1Wild.AutoSize = true;
            this.RB_1Wild.Location = new System.Drawing.Point(190, 27);
            this.RB_1Wild.Name = "RB_1Wild";
            this.RB_1Wild.Size = new System.Drawing.Size(132, 17);
            this.RB_1Wild.TabIndex = 143;
            this.RB_1Wild.Text = "By IVs Range of a wild";
            this.RB_1Wild.UseVisualStyleBackColor = true;
            this.RB_1Wild.CheckedChanged += new System.EventHandler(this.RB_CheckedChanged);
            // 
            // RB_2Wild
            // 
            this.RB_2Wild.AutoSize = true;
            this.RB_2Wild.Checked = true;
            this.RB_2Wild.Location = new System.Drawing.Point(23, 27);
            this.RB_2Wild.Name = "RB_2Wild";
            this.RB_2Wild.Size = new System.Drawing.Size(105, 17);
            this.RB_2Wild.TabIndex = 142;
            this.RB_2Wild.TabStop = true;
            this.RB_2Wild.Text = "By IVs of 2 wilds ";
            this.RB_2Wild.UseVisualStyleBackColor = true;
            this.RB_2Wild.CheckedChanged += new System.EventHandler(this.RB_CheckedChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(216, 196);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(14, 13);
            this.label35.TabIndex = 138;
            this.label35.Text = "~";
            // 
            // Seed_max
            // 
            this.Seed_max.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Seed_max.Location = new System.Drawing.Point(256, 190);
            this.Seed_max.Mask = "AAAAAAAA";
            this.Seed_max.Name = "Seed_max";
            this.Seed_max.Size = new System.Drawing.Size(64, 22);
            this.Seed_max.TabIndex = 141;
            this.Seed_max.Text = "FFFFFFFF";
            this.Seed_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Seed_max.Value = ((uint)(4294967295u));
            // 
            // Seed_min
            // 
            this.Seed_min.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Seed_min.Location = new System.Drawing.Point(133, 190);
            this.Seed_min.Mask = "AAAAAAAA";
            this.Seed_min.Name = "Seed_min";
            this.Seed_min.Size = new System.Drawing.Size(64, 22);
            this.Seed_min.TabIndex = 140;
            this.Seed_min.Text = "00000000";
            this.Seed_min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Seed_min.Value = ((uint)(0u));
            // 
            // L_SeedRange
            // 
            this.L_SeedRange.AutoSize = true;
            this.L_SeedRange.Location = new System.Drawing.Point(29, 195);
            this.L_SeedRange.Name = "L_SeedRange";
            this.L_SeedRange.Size = new System.Drawing.Size(67, 13);
            this.L_SeedRange.TabIndex = 139;
            this.L_SeedRange.Text = "Seed Range";
            // 
            // L_Progress6
            // 
            this.L_Progress6.AutoSize = true;
            this.L_Progress6.Location = new System.Drawing.Point(29, 260);
            this.L_Progress6.Name = "L_Progress6";
            this.L_Progress6.Size = new System.Drawing.Size(36, 13);
            this.L_Progress6.TabIndex = 135;
            this.L_Progress6.Text = "0.00%";
            // 
            // DGV_Seed
            // 
            this.DGV_Seed.AllowUserToAddRows = false;
            this.DGV_Seed.AllowUserToDeleteRows = false;
            this.DGV_Seed.AllowUserToResizeColumns = false;
            this.DGV_Seed.AllowUserToResizeRows = false;
            this.DGV_Seed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_Seed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_Seed_seed,
            this.dgv_Seed_frame1,
            this.dgv_Seed_Nature1,
            this.dgv_Seed_frame2,
            this.dgv_Seed_nature2,
            this.dgv_gender});
            this.DGV_Seed.Location = new System.Drawing.Point(384, 22);
            this.DGV_Seed.Name = "DGV_Seed";
            this.DGV_Seed.RowHeadersWidth = 18;
            this.DGV_Seed.Size = new System.Drawing.Size(318, 287);
            this.DGV_Seed.TabIndex = 133;
            // 
            // dgv_Seed_seed
            // 
            this.dgv_Seed_seed.DataPropertyName = "Seed";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.Format = "X8";
            this.dgv_Seed_seed.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Seed_seed.HeaderText = "Seed";
            this.dgv_Seed_seed.Name = "dgv_Seed_seed";
            this.dgv_Seed_seed.Width = 65;
            // 
            // dgv_Seed_frame1
            // 
            this.dgv_Seed_frame1.DataPropertyName = "Frame1";
            this.dgv_Seed_frame1.HeaderText = "Frame1";
            this.dgv_Seed_frame1.Name = "dgv_Seed_frame1";
            this.dgv_Seed_frame1.Width = 60;
            // 
            // dgv_Seed_Nature1
            // 
            this.dgv_Seed_Nature1.DataPropertyName = "Nature1";
            this.dgv_Seed_Nature1.HeaderText = "Nature1";
            this.dgv_Seed_Nature1.Name = "dgv_Seed_Nature1";
            this.dgv_Seed_Nature1.Width = 55;
            // 
            // dgv_Seed_frame2
            // 
            this.dgv_Seed_frame2.DataPropertyName = "Frame2";
            this.dgv_Seed_frame2.HeaderText = "Frame2";
            this.dgv_Seed_frame2.Name = "dgv_Seed_frame2";
            this.dgv_Seed_frame2.Width = 60;
            // 
            // dgv_Seed_nature2
            // 
            this.dgv_Seed_nature2.DataPropertyName = "Nature2";
            this.dgv_Seed_nature2.HeaderText = "Nature2";
            this.dgv_Seed_nature2.Name = "dgv_Seed_nature2";
            this.dgv_Seed_nature2.Width = 55;
            // 
            // dgv_gender
            // 
            this.dgv_gender.DataPropertyName = "Gender";
            this.dgv_gender.HeaderText = "Gender";
            this.dgv_gender.Name = "dgv_gender";
            this.dgv_gender.Visible = false;
            this.dgv_gender.Width = 45;
            // 
            // B_Search
            // 
            this.B_Search.Location = new System.Drawing.Point(278, 228);
            this.B_Search.Name = "B_Search";
            this.B_Search.Size = new System.Drawing.Size(90, 25);
            this.B_Search.TabIndex = 132;
            this.B_Search.Text = "Search";
            this.B_Search.UseVisualStyleBackColor = true;
            this.B_Search.Click += new System.EventHandler(this.B_MTSearch_Click);
            // 
            // Gen6PBar
            // 
            this.Gen6PBar.Location = new System.Drawing.Point(28, 286);
            this.Gen6PBar.Name = "Gen6PBar";
            this.Gen6PBar.Size = new System.Drawing.Size(328, 23);
            this.Gen6PBar.TabIndex = 131;
            // 
            // B_Abort
            // 
            this.B_Abort.Location = new System.Drawing.Point(278, 228);
            this.B_Abort.Name = "B_Abort";
            this.B_Abort.Size = new System.Drawing.Size(90, 25);
            this.B_Abort.TabIndex = 134;
            this.B_Abort.Text = "Abort";
            this.B_Abort.UseVisualStyleBackColor = true;
            this.B_Abort.Click += new System.EventHandler(this.B_Abort6_Click);
            // 
            // WildPanel2
            // 
            this.WildPanel2.Controls.Add(this.label30);
            this.WildPanel2.Controls.Add(this.label29);
            this.WildPanel2.Controls.Add(this.L_WildFrameRange);
            this.WildPanel2.Controls.Add(this.L_IV);
            this.WildPanel2.Controls.Add(this.Wild1_Fmax);
            this.WildPanel2.Controls.Add(this.L_Wild1);
            this.WildPanel2.Controls.Add(this.WildIV1);
            this.WildPanel2.Controls.Add(this.L_Wild2);
            this.WildPanel2.Controls.Add(this.WildIV2);
            this.WildPanel2.Controls.Add(this.Wild1_Fmin);
            this.WildPanel2.Controls.Add(this.Wild2_Fmin);
            this.WildPanel2.Controls.Add(this.Wild2_Fmax);
            this.WildPanel2.Location = new System.Drawing.Point(11, 50);
            this.WildPanel2.Name = "WildPanel2";
            this.WildPanel2.Size = new System.Drawing.Size(353, 128);
            this.WildPanel2.TabIndex = 136;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(264, 92);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(14, 13);
            this.label30.TabIndex = 121;
            this.label30.Text = "~";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(264, 44);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(14, 13);
            this.label29.TabIndex = 120;
            this.label29.Text = "~";
            // 
            // L_WildFrameRange
            // 
            this.L_WildFrameRange.AutoSize = true;
            this.L_WildFrameRange.Location = new System.Drawing.Point(202, 14);
            this.L_WildFrameRange.Name = "L_WildFrameRange";
            this.L_WildFrameRange.Size = new System.Drawing.Size(123, 13);
            this.L_WildFrameRange.TabIndex = 119;
            this.L_WildFrameRange.Text = "Encounter Frame Range";
            // 
            // L_IV
            // 
            this.L_IV.AutoSize = true;
            this.L_IV.Location = new System.Drawing.Point(63, 14);
            this.L_IV.Name = "L_IV";
            this.L_IV.Size = new System.Drawing.Size(22, 13);
            this.L_IV.TabIndex = 118;
            this.L_IV.Text = "IVs";
            // 
            // Wild1_Fmax
            // 
            this.Wild1_Fmax.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Wild1_Fmax.Location = new System.Drawing.Point(284, 39);
            this.Wild1_Fmax.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.Wild1_Fmax.Name = "Wild1_Fmax";
            this.Wild1_Fmax.Size = new System.Drawing.Size(54, 22);
            this.Wild1_Fmax.TabIndex = 94;
            this.Wild1_Fmax.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // L_Wild1
            // 
            this.L_Wild1.AutoSize = true;
            this.L_Wild1.Location = new System.Drawing.Point(10, 44);
            this.L_Wild1.Name = "L_Wild1";
            this.L_Wild1.Size = new System.Drawing.Size(34, 13);
            this.L_Wild1.TabIndex = 117;
            this.L_Wild1.Text = "Wild1";
            // 
            // WildIV1
            // 
            this.WildIV1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WildIV1.Location = new System.Drawing.Point(61, 40);
            this.WildIV1.Name = "WildIV1";
            this.WildIV1.Size = new System.Drawing.Size(122, 20);
            this.WildIV1.TabIndex = 0;
            this.WildIV1.Text = "29 14 5 24 8 13";
            // 
            // L_Wild2
            // 
            this.L_Wild2.AutoSize = true;
            this.L_Wild2.Location = new System.Drawing.Point(10, 92);
            this.L_Wild2.Name = "L_Wild2";
            this.L_Wild2.Size = new System.Drawing.Size(34, 13);
            this.L_Wild2.TabIndex = 116;
            this.L_Wild2.Text = "Wild2";
            // 
            // WildIV2
            // 
            this.WildIV2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WildIV2.Location = new System.Drawing.Point(61, 88);
            this.WildIV2.Name = "WildIV2";
            this.WildIV2.Size = new System.Drawing.Size(122, 20);
            this.WildIV2.TabIndex = 1;
            this.WildIV2.Text = "0 14 26 17 3 26";
            // 
            // Wild1_Fmin
            // 
            this.Wild1_Fmin.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Wild1_Fmin.Location = new System.Drawing.Point(202, 39);
            this.Wild1_Fmin.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.Wild1_Fmin.Name = "Wild1_Fmin";
            this.Wild1_Fmin.Size = new System.Drawing.Size(54, 22);
            this.Wild1_Fmin.TabIndex = 93;
            this.Wild1_Fmin.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // Wild2_Fmin
            // 
            this.Wild2_Fmin.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Wild2_Fmin.Location = new System.Drawing.Point(202, 87);
            this.Wild2_Fmin.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Wild2_Fmin.Name = "Wild2_Fmin";
            this.Wild2_Fmin.Size = new System.Drawing.Size(54, 22);
            this.Wild2_Fmin.TabIndex = 95;
            this.Wild2_Fmin.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // Wild2_Fmax
            // 
            this.Wild2_Fmax.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Wild2_Fmax.Location = new System.Drawing.Point(284, 87);
            this.Wild2_Fmax.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Wild2_Fmax.Name = "Wild2_Fmax";
            this.Wild2_Fmax.Size = new System.Drawing.Size(54, 22);
            this.Wild2_Fmax.TabIndex = 96;
            this.Wild2_Fmax.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // WildPanel1
            // 
            this.WildPanel1.Controls.Add(this.L_Nature);
            this.WildPanel1.Controls.Add(this.Wild_Nature);
            this.WildPanel1.Controls.Add(this.label34);
            this.WildPanel1.Controls.Add(this.L_WildFrameRange2);
            this.WildPanel1.Controls.Add(this.L_WildLower);
            this.WildPanel1.Controls.Add(this.Wild_max);
            this.WildPanel1.Controls.Add(this.L_WildUpper);
            this.WildPanel1.Controls.Add(this.Wild_min);
            this.WildPanel1.Controls.Add(this.L_WildIVRange);
            this.WildPanel1.Controls.Add(this.Wild_upper);
            this.WildPanel1.Controls.Add(this.Wild_lower);
            this.WildPanel1.Location = new System.Drawing.Point(11, 50);
            this.WildPanel1.Name = "WildPanel1";
            this.WildPanel1.Size = new System.Drawing.Size(353, 128);
            this.WildPanel1.TabIndex = 137;
            // 
            // L_Nature
            // 
            this.L_Nature.AutoSize = true;
            this.L_Nature.Location = new System.Drawing.Point(202, 91);
            this.L_Nature.Name = "L_Nature";
            this.L_Nature.Size = new System.Drawing.Size(39, 13);
            this.L_Nature.TabIndex = 127;
            this.L_Nature.Text = "Nature";
            // 
            // Wild_Nature
            // 
            this.Wild_Nature.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Wild_Nature.Location = new System.Drawing.Point(254, 86);
            this.Wild_Nature.Name = "Wild_Nature";
            this.Wild_Nature.Size = new System.Drawing.Size(62, 21);
            this.Wild_Nature.TabIndex = 126;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(264, 44);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(14, 13);
            this.label34.TabIndex = 123;
            this.label34.Text = "~";
            // 
            // L_WildFrameRange2
            // 
            this.L_WildFrameRange2.AutoSize = true;
            this.L_WildFrameRange2.Location = new System.Drawing.Point(199, 14);
            this.L_WildFrameRange2.Name = "L_WildFrameRange2";
            this.L_WildFrameRange2.Size = new System.Drawing.Size(123, 13);
            this.L_WildFrameRange2.TabIndex = 125;
            this.L_WildFrameRange2.Text = "Encounter Frame Range";
            // 
            // L_WildLower
            // 
            this.L_WildLower.AutoSize = true;
            this.L_WildLower.Location = new System.Drawing.Point(13, 92);
            this.L_WildLower.Name = "L_WildLower";
            this.L_WildLower.Size = new System.Drawing.Size(36, 13);
            this.L_WildLower.TabIndex = 124;
            this.L_WildLower.Text = "Lower";
            // 
            // Wild_max
            // 
            this.Wild_max.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Wild_max.Location = new System.Drawing.Point(284, 39);
            this.Wild_max.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.Wild_max.Name = "Wild_max";
            this.Wild_max.Size = new System.Drawing.Size(54, 22);
            this.Wild_max.TabIndex = 122;
            this.Wild_max.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // L_WildUpper
            // 
            this.L_WildUpper.AutoSize = true;
            this.L_WildUpper.Location = new System.Drawing.Point(12, 44);
            this.L_WildUpper.Name = "L_WildUpper";
            this.L_WildUpper.Size = new System.Drawing.Size(36, 13);
            this.L_WildUpper.TabIndex = 122;
            this.L_WildUpper.Text = "Upper";
            // 
            // Wild_min
            // 
            this.Wild_min.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Wild_min.Location = new System.Drawing.Point(202, 39);
            this.Wild_min.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.Wild_min.Name = "Wild_min";
            this.Wild_min.Size = new System.Drawing.Size(54, 22);
            this.Wild_min.TabIndex = 121;
            this.Wild_min.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // L_WildIVRange
            // 
            this.L_WildIVRange.AutoSize = true;
            this.L_WildIVRange.Location = new System.Drawing.Point(61, 14);
            this.L_WildIVRange.Name = "L_WildIVRange";
            this.L_WildIVRange.Size = new System.Drawing.Size(57, 13);
            this.L_WildIVRange.TabIndex = 122;
            this.L_WildIVRange.Text = "IVs Range";
            // 
            // Wild_upper
            // 
            this.Wild_upper.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Wild_upper.Location = new System.Drawing.Point(61, 40);
            this.Wild_upper.Name = "Wild_upper";
            this.Wild_upper.Size = new System.Drawing.Size(122, 20);
            this.Wild_upper.TabIndex = 122;
            this.Wild_upper.Text = "29 14 5 24 8 13";
            // 
            // Wild_lower
            // 
            this.Wild_lower.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Wild_lower.Location = new System.Drawing.Point(61, 88);
            this.Wild_lower.Name = "Wild_lower";
            this.Wild_lower.Size = new System.Drawing.Size(122, 20);
            this.Wild_lower.TabIndex = 123;
            this.Wild_lower.Text = "29 14 4 24 7 13";
            // 
            // Gen6MTSeedFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 322);
            this.Controls.Add(this.RB_1Wild);
            this.Controls.Add(this.RB_2Wild);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.Seed_max);
            this.Controls.Add(this.Seed_min);
            this.Controls.Add(this.L_SeedRange);
            this.Controls.Add(this.L_Progress6);
            this.Controls.Add(this.DGV_Seed);
            this.Controls.Add(this.Gen6PBar);
            this.Controls.Add(this.WildPanel2);
            this.Controls.Add(this.WildPanel1);
            this.Controls.Add(this.B_Search);
            this.Controls.Add(this.B_Abort);
            this.Name = "Gen6MTSeedFinder";
            this.Text = "Gen6MTSeedFinder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Gen6MTSeedFinder_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Seed)).EndInit();
            this.WildPanel2.ResumeLayout(false);
            this.WildPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Wild1_Fmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wild1_Fmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wild2_Fmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wild2_Fmax)).EndInit();
            this.WildPanel1.ResumeLayout(false);
            this.WildPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Wild_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wild_min)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton RB_1Wild;
        private System.Windows.Forms.RadioButton RB_2Wild;
        private System.Windows.Forms.Label label35;
        private Controls.HexMaskedTextBox Seed_max;
        private Controls.HexMaskedTextBox Seed_min;
        private System.Windows.Forms.Label L_SeedRange;
        private System.Windows.Forms.Label L_Progress6;
        private System.Windows.Forms.DataGridView DGV_Seed;
        private System.Windows.Forms.ProgressBar Gen6PBar;
        private System.Windows.Forms.Button B_Abort;
        private System.Windows.Forms.Panel WildPanel2;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label L_WildFrameRange;
        private System.Windows.Forms.Label L_IV;
        private System.Windows.Forms.NumericUpDown Wild1_Fmax;
        private System.Windows.Forms.Label L_Wild1;
        private System.Windows.Forms.TextBox WildIV1;
        private System.Windows.Forms.Label L_Wild2;
        private System.Windows.Forms.TextBox WildIV2;
        private System.Windows.Forms.NumericUpDown Wild1_Fmin;
        private System.Windows.Forms.NumericUpDown Wild2_Fmin;
        private System.Windows.Forms.NumericUpDown Wild2_Fmax;
        private System.Windows.Forms.Panel WildPanel1;
        private System.Windows.Forms.Label L_Nature;
        private System.Windows.Forms.ComboBox Wild_Nature;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label L_WildFrameRange2;
        private System.Windows.Forms.Label L_WildLower;
        private System.Windows.Forms.NumericUpDown Wild_max;
        private System.Windows.Forms.Label L_WildUpper;
        private System.Windows.Forms.NumericUpDown Wild_min;
        private System.Windows.Forms.Label L_WildIVRange;
        private System.Windows.Forms.TextBox Wild_upper;
        private System.Windows.Forms.TextBox Wild_lower;
        private System.Windows.Forms.Button B_Search;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_Seed_seed;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_Seed_frame1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_Seed_Nature1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_Seed_frame2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_Seed_nature2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_gender;
    }
}