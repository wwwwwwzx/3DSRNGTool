namespace pkm3dsRNG
{
    partial class MainForm
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
            pkm3dsRNG.Controls.CheckBoxProperties checkBoxProperties1 = new pkm3dsRNG.Controls.CheckBoxProperties();
            pkm3dsRNG.Controls.CheckBoxProperties checkBoxProperties2 = new pkm3dsRNG.Controls.CheckBoxProperties();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Filters = new System.Windows.Forms.GroupBox();
            this.HiddenPower = new pkm3dsRNG.Controls.CheckBoxComboBox();
            this.Nature = new pkm3dsRNG.Controls.CheckBoxComboBox();
            this.ShowStats = new System.Windows.Forms.CheckBox();
            this.Reset = new System.Windows.Forms.Button();
            this.ByIVs = new System.Windows.Forms.RadioButton();
            this.ByStats = new System.Windows.Forms.RadioButton();
            this.L_Lv_S = new System.Windows.Forms.Label();
            this.L_Ability = new System.Windows.Forms.Label();
            this.Filter_Lv = new System.Windows.Forms.NumericUpDown();
            this.Ability = new System.Windows.Forms.ComboBox();
            this.DisableFilters = new System.Windows.Forms.CheckBox();
            this.ShinyOnly = new System.Windows.Forms.CheckBox();
            this.L_gender = new System.Windows.Forms.Label();
            this.Gender = new System.Windows.Forms.ComboBox();
            this.L_nature = new System.Windows.Forms.Label();
            this.L_HP = new System.Windows.Forms.Label();
            this.L_S = new System.Windows.Forms.Label();
            this.L_C = new System.Windows.Forms.Label();
            this.L_B = new System.Windows.Forms.Label();
            this.L_H = new System.Windows.Forms.Label();
            this.L_A = new System.Windows.Forms.Label();
            this.L_D = new System.Windows.Forms.Label();
            this.IVPanel = new System.Windows.Forms.Panel();
            this.PerfectIVs = new System.Windows.Forms.NumericUpDown();
            this.L_IVRange = new System.Windows.Forms.Label();
            this.ivmin0 = new System.Windows.Forms.NumericUpDown();
            this.ivmax0 = new System.Windows.Forms.NumericUpDown();
            this.ivmin1 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.ivmin2 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.ivmin3 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.ivmin4 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.ivmin5 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ivmax1 = new System.Windows.Forms.NumericUpDown();
            this.ivmax5 = new System.Windows.Forms.NumericUpDown();
            this.ivmax2 = new System.Windows.Forms.NumericUpDown();
            this.ivmax4 = new System.Windows.Forms.NumericUpDown();
            this.ivmax3 = new System.Windows.Forms.NumericUpDown();
            this.StatPanel = new System.Windows.Forms.Panel();
            this.L_Stats = new System.Windows.Forms.Label();
            this.L_BS = new System.Windows.Forms.Label();
            this.Stat0 = new System.Windows.Forms.NumericUpDown();
            this.Stat1 = new System.Windows.Forms.NumericUpDown();
            this.BS_5 = new System.Windows.Forms.NumericUpDown();
            this.Stat2 = new System.Windows.Forms.NumericUpDown();
            this.BS_4 = new System.Windows.Forms.NumericUpDown();
            this.Stat3 = new System.Windows.Forms.NumericUpDown();
            this.BS_3 = new System.Windows.Forms.NumericUpDown();
            this.Stat4 = new System.Windows.Forms.NumericUpDown();
            this.BS_2 = new System.Windows.Forms.NumericUpDown();
            this.Stat5 = new System.Windows.Forms.NumericUpDown();
            this.BS_1 = new System.Windows.Forms.NumericUpDown();
            this.BS_0 = new System.Windows.Forms.NumericUpDown();
            this.RNGMethod = new System.Windows.Forms.TabControl();
            this.StationaryRNG = new System.Windows.Forms.TabPage();
            this.RNGInfo = new System.Windows.Forms.GroupBox();
            this.CreateTimeline = new System.Windows.Forms.RadioButton();
            this.TimeSpan = new System.Windows.Forms.NumericUpDown();
            this.ConsiderDelay = new System.Windows.Forms.CheckBox();
            this.Timedelay = new System.Windows.Forms.NumericUpDown();
            this.NPC = new System.Windows.Forms.NumericUpDown();
            this.RB_FrameRange = new System.Windows.Forms.RadioButton();
            this.CalcList = new System.Windows.Forms.Button();
            this.L_NPC = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Frame_max = new System.Windows.Forms.NumericUpDown();
            this.Frame_min = new System.Windows.Forms.NumericUpDown();
            this.Condition = new System.Windows.Forms.GroupBox();
            this.L_Category = new System.Windows.Forms.Label();
            this.CB_Category = new System.Windows.Forms.ComboBox();
            this.L_GenderRatio = new System.Windows.Forms.Label();
            this.ShinyLocked = new System.Windows.Forms.CheckBox();
            this.L_SyncNature = new System.Windows.Forms.Label();
            this.GenderRatio = new System.Windows.Forms.ComboBox();
            this.SyncNature = new System.Windows.Forms.ComboBox();
            this.Fix3v = new System.Windows.Forms.CheckBox();
            this.L_Poke = new System.Windows.Forms.Label();
            this.Sta_Poke = new System.Windows.Forms.ComboBox();
            this.AlwaysSynced = new System.Windows.Forms.CheckBox();
            this.EventRNG = new System.Windows.Forms.TabPage();
            this.EventSetting = new System.Windows.Forms.GroupBox();
            this.B_Open = new System.Windows.Forms.Button();
            this.Event_Forme = new System.Windows.Forms.ComboBox();
            this.Event_PID = new pkm3dsRNG.Controls.HexNumericUpdown();
            this.L_Forme = new System.Windows.Forms.Label();
            this.Event_EC = new pkm3dsRNG.Controls.HexNumericUpdown();
            this.Event_Species = new System.Windows.Forms.ComboBox();
            this.Event_SID = new System.Windows.Forms.NumericUpDown();
            this.L_Event_PID = new System.Windows.Forms.Label();
            this.AbilityLocked = new System.Windows.Forms.CheckBox();
            this.EventIV0 = new System.Windows.Forms.NumericUpDown();
            this.L_IVsCount = new System.Windows.Forms.Label();
            this.L_Species = new System.Windows.Forms.Label();
            this.L_EC = new System.Windows.Forms.Label();
            this.EventIV1 = new System.Windows.Forms.NumericUpDown();
            this.IVsCount = new System.Windows.Forms.NumericUpDown();
            this.IsEgg = new System.Windows.Forms.CheckBox();
            this.YourID = new System.Windows.Forms.CheckBox();
            this.EventIV2 = new System.Windows.Forms.NumericUpDown();
            this.GenderLocked = new System.Windows.Forms.CheckBox();
            this.OtherInfo = new System.Windows.Forms.CheckBox();
            this.L_SID = new System.Windows.Forms.Label();
            this.EventIV3 = new System.Windows.Forms.NumericUpDown();
            this.NatureLocked = new System.Windows.Forms.CheckBox();
            this.L_Event_TSV = new System.Windows.Forms.Label();
            this.Event_PIDType = new System.Windows.Forms.ComboBox();
            this.EventIV4 = new System.Windows.Forms.NumericUpDown();
            this.Event_IV_Fix5 = new System.Windows.Forms.CheckBox();
            this.Event_Ability = new System.Windows.Forms.ComboBox();
            this.L_PID = new System.Windows.Forms.Label();
            this.EventIV5 = new System.Windows.Forms.NumericUpDown();
            this.Event_IV_Fix4 = new System.Windows.Forms.CheckBox();
            this.L_TID = new System.Windows.Forms.Label();
            this.Event_IV_Fix3 = new System.Windows.Forms.CheckBox();
            this.Event_IV_Fix0 = new System.Windows.Forms.CheckBox();
            this.Event_TID = new System.Windows.Forms.NumericUpDown();
            this.Event_Gender = new System.Windows.Forms.ComboBox();
            this.Event_IV_Fix2 = new System.Windows.Forms.CheckBox();
            this.Event_IV_Fix1 = new System.Windows.Forms.CheckBox();
            this.Event_Nature = new System.Windows.Forms.ComboBox();
            this.Lang = new System.Windows.Forms.ComboBox();
            this.Advanced = new System.Windows.Forms.CheckBox();
            this.ShinyCharm = new System.Windows.Forms.CheckBox();
            this.L_TSV = new System.Windows.Forms.Label();
            this.L_Seed = new System.Windows.Forms.Label();
            this.TSV = new System.Windows.Forms.NumericUpDown();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.Gameversion = new System.Windows.Forms.ComboBox();
            this.L_GameVersion = new System.Windows.Forms.Label();
            this.Seed = new pkm3dsRNG.Controls.HexNumericUpdown();
            this.dgv_Frame = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_blink = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_delay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_H = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_S = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_nature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_synced = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_hiddenpower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_psv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_ability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_rand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_rand64 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_pid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_EC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Filters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_Lv)).BeginInit();
            this.IVPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PerfectIVs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivmin0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivmax0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivmin1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivmin2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivmin3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivmin4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivmin5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivmax1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivmax5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivmax2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivmax4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivmax3)).BeginInit();
            this.StatPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Stat0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Stat1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Stat2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Stat3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Stat4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Stat5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_0)).BeginInit();
            this.RNGMethod.SuspendLayout();
            this.StationaryRNG.SuspendLayout();
            this.RNGInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeSpan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Timedelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NPC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Frame_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Frame_min)).BeginInit();
            this.Condition.SuspendLayout();
            this.EventRNG.SuspendLayout();
            this.EventSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Event_PID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Event_EC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Event_SID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventIV0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventIV1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IVsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventIV2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventIV3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventIV4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventIV5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Event_TID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TSV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Seed)).BeginInit();
            this.SuspendLayout();
            // 
            // Filters
            // 
            this.Filters.BackColor = System.Drawing.Color.White;
            this.Filters.Controls.Add(this.HiddenPower);
            this.Filters.Controls.Add(this.Nature);
            this.Filters.Controls.Add(this.ShowStats);
            this.Filters.Controls.Add(this.Reset);
            this.Filters.Controls.Add(this.ByIVs);
            this.Filters.Controls.Add(this.ByStats);
            this.Filters.Controls.Add(this.L_Lv_S);
            this.Filters.Controls.Add(this.L_Ability);
            this.Filters.Controls.Add(this.Filter_Lv);
            this.Filters.Controls.Add(this.Ability);
            this.Filters.Controls.Add(this.DisableFilters);
            this.Filters.Controls.Add(this.ShinyOnly);
            this.Filters.Controls.Add(this.L_gender);
            this.Filters.Controls.Add(this.Gender);
            this.Filters.Controls.Add(this.L_nature);
            this.Filters.Controls.Add(this.L_HP);
            this.Filters.Controls.Add(this.L_S);
            this.Filters.Controls.Add(this.L_C);
            this.Filters.Controls.Add(this.L_B);
            this.Filters.Controls.Add(this.L_H);
            this.Filters.Controls.Add(this.L_A);
            this.Filters.Controls.Add(this.L_D);
            this.Filters.Controls.Add(this.IVPanel);
            this.Filters.Controls.Add(this.StatPanel);
            this.Filters.Location = new System.Drawing.Point(424, 13);
            this.Filters.Name = "Filters";
            this.Filters.Size = new System.Drawing.Size(407, 278);
            this.Filters.TabIndex = 4;
            this.Filters.TabStop = false;
            this.Filters.Text = "筛选";
            // 
            // HiddenPower
            // 
            this.HiddenPower.BlankText = null;
            checkBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.HiddenPower.CheckBoxProperties = checkBoxProperties1;
            this.HiddenPower.DisplayMemberSingleItem = "";
            this.HiddenPower.DropDownHeight = 400;
            this.HiddenPower.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HiddenPower.FormattingEnabled = true;
            this.HiddenPower.Location = new System.Drawing.Point(295, 113);
            this.HiddenPower.Name = "HiddenPower";
            this.HiddenPower.Size = new System.Drawing.Size(91, 21);
            this.HiddenPower.TabIndex = 78;
            // 
            // Nature
            // 
            this.Nature.BlankText = "Any";
            checkBoxProperties2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Nature.CheckBoxProperties = checkBoxProperties2;
            this.Nature.DisplayMemberSingleItem = "";
            this.Nature.DropDownHeight = 400;
            this.Nature.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Nature.FormattingEnabled = true;
            this.Nature.Location = new System.Drawing.Point(295, 164);
            this.Nature.Name = "Nature";
            this.Nature.Size = new System.Drawing.Size(91, 21);
            this.Nature.TabIndex = 77;
            // 
            // ShowStats
            // 
            this.ShowStats.AutoSize = true;
            this.ShowStats.Location = new System.Drawing.Point(203, 224);
            this.ShowStats.Name = "ShowStats";
            this.ShowStats.Size = new System.Drawing.Size(86, 17);
            this.ShowStats.TabIndex = 75;
            this.ShowStats.Text = "能力值显示";
            this.ShowStats.UseVisualStyleBackColor = true;
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(302, 21);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(75, 23);
            this.Reset.TabIndex = 73;
            this.Reset.Text = "重置";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // ByIVs
            // 
            this.ByIVs.AutoSize = true;
            this.ByIVs.Location = new System.Drawing.Point(18, 31);
            this.ByIVs.Name = "ByIVs";
            this.ByIVs.Size = new System.Drawing.Size(85, 17);
            this.ByIVs.TabIndex = 72;
            this.ByIVs.TabStop = true;
            this.ByIVs.Text = "通过个体值";
            this.ByIVs.UseVisualStyleBackColor = true;
            this.ByIVs.CheckedChanged += new System.EventHandler(this.SearchMethod_CheckedChanged);
            // 
            // ByStats
            // 
            this.ByStats.AutoSize = true;
            this.ByStats.Location = new System.Drawing.Point(104, 31);
            this.ByStats.Name = "ByStats";
            this.ByStats.Size = new System.Drawing.Size(85, 17);
            this.ByStats.TabIndex = 71;
            this.ByStats.TabStop = true;
            this.ByStats.Text = "通过能力值";
            this.ByStats.UseVisualStyleBackColor = true;
            this.ByStats.CheckedChanged += new System.EventHandler(this.SearchMethod_CheckedChanged);
            // 
            // L_Lv_S
            // 
            this.L_Lv_S.AutoSize = true;
            this.L_Lv_S.Location = new System.Drawing.Point(299, 63);
            this.L_Lv_S.Name = "L_Lv_S";
            this.L_Lv_S.Size = new System.Drawing.Size(19, 13);
            this.L_Lv_S.TabIndex = 66;
            this.L_Lv_S.Text = "Lv";
            // 
            // L_Ability
            // 
            this.L_Ability.AutoSize = true;
            this.L_Ability.Location = new System.Drawing.Point(200, 142);
            this.L_Ability.Name = "L_Ability";
            this.L_Ability.Size = new System.Drawing.Size(31, 13);
            this.L_Ability.TabIndex = 64;
            this.L_Ability.Text = "特性";
            // 
            // Filter_Lv
            // 
            this.Filter_Lv.AccessibleName = "";
            this.Filter_Lv.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter_Lv.Location = new System.Drawing.Point(318, 57);
            this.Filter_Lv.Name = "Filter_Lv";
            this.Filter_Lv.Size = new System.Drawing.Size(44, 22);
            this.Filter_Lv.TabIndex = 67;
            // 
            // Ability
            // 
            this.Ability.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Ability.Items.AddRange(new object[] {
            "-",
            "1",
            "2",
            "H"});
            this.Ability.Location = new System.Drawing.Point(200, 163);
            this.Ability.Name = "Ability";
            this.Ability.Size = new System.Drawing.Size(74, 21);
            this.Ability.TabIndex = 63;
            // 
            // DisableFilters
            // 
            this.DisableFilters.AutoSize = true;
            this.DisableFilters.Location = new System.Drawing.Point(302, 224);
            this.DisableFilters.Name = "DisableFilters";
            this.DisableFilters.Size = new System.Drawing.Size(74, 17);
            this.DisableFilters.TabIndex = 51;
            this.DisableFilters.Text = "取消筛选";
            this.DisableFilters.UseVisualStyleBackColor = true;
            // 
            // ShinyOnly
            // 
            this.ShinyOnly.AutoSize = true;
            this.ShinyOnly.Location = new System.Drawing.Point(302, 197);
            this.ShinyOnly.Name = "ShinyOnly";
            this.ShinyOnly.Size = new System.Drawing.Size(74, 17);
            this.ShinyOnly.TabIndex = 8;
            this.ShinyOnly.Text = "仅异色帧";
            this.ShinyOnly.UseVisualStyleBackColor = true;
            // 
            // L_gender
            // 
            this.L_gender.AutoSize = true;
            this.L_gender.Location = new System.Drawing.Point(200, 92);
            this.L_gender.Name = "L_gender";
            this.L_gender.Size = new System.Drawing.Size(31, 13);
            this.L_gender.TabIndex = 39;
            this.L_gender.Text = "性别";
            // 
            // Gender
            // 
            this.Gender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Gender.Location = new System.Drawing.Point(200, 113);
            this.Gender.Name = "Gender";
            this.Gender.Size = new System.Drawing.Size(74, 21);
            this.Gender.TabIndex = 38;
            // 
            // L_nature
            // 
            this.L_nature.AutoSize = true;
            this.L_nature.Location = new System.Drawing.Point(295, 142);
            this.L_nature.Name = "L_nature";
            this.L_nature.Size = new System.Drawing.Size(31, 13);
            this.L_nature.TabIndex = 35;
            this.L_nature.Text = "性格";
            // 
            // L_HP
            // 
            this.L_HP.AutoSize = true;
            this.L_HP.Location = new System.Drawing.Point(295, 92);
            this.L_HP.Name = "L_HP";
            this.L_HP.Size = new System.Drawing.Size(31, 13);
            this.L_HP.TabIndex = 34;
            this.L_HP.Text = "觉醒";
            // 
            // L_S
            // 
            this.L_S.AutoSize = true;
            this.L_S.Location = new System.Drawing.Point(10, 239);
            this.L_S.Name = "L_S";
            this.L_S.Size = new System.Drawing.Size(31, 13);
            this.L_S.TabIndex = 29;
            this.L_S.Text = "速度";
            // 
            // L_C
            // 
            this.L_C.AutoSize = true;
            this.L_C.Location = new System.Drawing.Point(10, 179);
            this.L_C.Name = "L_C";
            this.L_C.Size = new System.Drawing.Size(31, 13);
            this.L_C.TabIndex = 27;
            this.L_C.Text = "特攻";
            // 
            // L_B
            // 
            this.L_B.AutoSize = true;
            this.L_B.Location = new System.Drawing.Point(10, 149);
            this.L_B.Name = "L_B";
            this.L_B.Size = new System.Drawing.Size(31, 13);
            this.L_B.TabIndex = 26;
            this.L_B.Text = "防御";
            // 
            // L_H
            // 
            this.L_H.AutoSize = true;
            this.L_H.Location = new System.Drawing.Point(10, 89);
            this.L_H.Name = "L_H";
            this.L_H.Size = new System.Drawing.Size(22, 13);
            this.L_H.TabIndex = 24;
            this.L_H.Text = "HP";
            // 
            // L_A
            // 
            this.L_A.AutoSize = true;
            this.L_A.Location = new System.Drawing.Point(10, 119);
            this.L_A.Name = "L_A";
            this.L_A.Size = new System.Drawing.Size(31, 13);
            this.L_A.TabIndex = 25;
            this.L_A.Text = "攻击";
            // 
            // L_D
            // 
            this.L_D.AutoSize = true;
            this.L_D.Location = new System.Drawing.Point(10, 209);
            this.L_D.Name = "L_D";
            this.L_D.Size = new System.Drawing.Size(31, 13);
            this.L_D.TabIndex = 28;
            this.L_D.Text = "特防";
            // 
            // IVPanel
            // 
            this.IVPanel.Controls.Add(this.PerfectIVs);
            this.IVPanel.Controls.Add(this.L_IVRange);
            this.IVPanel.Controls.Add(this.ivmin0);
            this.IVPanel.Controls.Add(this.ivmax0);
            this.IVPanel.Controls.Add(this.ivmin1);
            this.IVPanel.Controls.Add(this.label6);
            this.IVPanel.Controls.Add(this.ivmin2);
            this.IVPanel.Controls.Add(this.label5);
            this.IVPanel.Controls.Add(this.ivmin3);
            this.IVPanel.Controls.Add(this.label4);
            this.IVPanel.Controls.Add(this.ivmin4);
            this.IVPanel.Controls.Add(this.label3);
            this.IVPanel.Controls.Add(this.ivmin5);
            this.IVPanel.Controls.Add(this.label2);
            this.IVPanel.Controls.Add(this.label1);
            this.IVPanel.Controls.Add(this.ivmax1);
            this.IVPanel.Controls.Add(this.ivmax5);
            this.IVPanel.Controls.Add(this.ivmax2);
            this.IVPanel.Controls.Add(this.ivmax4);
            this.IVPanel.Controls.Add(this.ivmax3);
            this.IVPanel.Location = new System.Drawing.Point(40, 54);
            this.IVPanel.Name = "IVPanel";
            this.IVPanel.Size = new System.Drawing.Size(147, 209);
            this.IVPanel.TabIndex = 24;
            // 
            // PerfectIVs
            // 
            this.PerfectIVs.AccessibleName = "";
            this.PerfectIVs.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PerfectIVs.Location = new System.Drawing.Point(86, 3);
            this.PerfectIVs.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.PerfectIVs.Name = "PerfectIVs";
            this.PerfectIVs.Size = new System.Drawing.Size(49, 22);
            this.PerfectIVs.TabIndex = 74;
            // 
            // L_IVRange
            // 
            this.L_IVRange.AutoSize = true;
            this.L_IVRange.Location = new System.Drawing.Point(2, 6);
            this.L_IVRange.Name = "L_IVRange";
            this.L_IVRange.Size = new System.Drawing.Size(67, 13);
            this.L_IVRange.TabIndex = 73;
            this.L_IVRange.Text = "个体值范围";
            // 
            // ivmin0
            // 
            this.ivmin0.AccessibleName = "";
            this.ivmin0.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ivmin0.Location = new System.Drawing.Point(11, 32);
            this.ivmin0.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.ivmin0.Name = "ivmin0";
            this.ivmin0.Size = new System.Drawing.Size(49, 22);
            this.ivmin0.TabIndex = 6;
            // 
            // ivmax0
            // 
            this.ivmax0.AccessibleName = "";
            this.ivmax0.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ivmax0.Location = new System.Drawing.Point(86, 32);
            this.ivmax0.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.ivmax0.Name = "ivmax0";
            this.ivmax0.Size = new System.Drawing.Size(49, 22);
            this.ivmax0.TabIndex = 12;
            this.ivmax0.Value = new decimal(new int[] {
            31,
            0,
            0,
            0});
            // 
            // ivmin1
            // 
            this.ivmin1.AccessibleName = "";
            this.ivmin1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ivmin1.Location = new System.Drawing.Point(11, 62);
            this.ivmin1.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.ivmin1.Name = "ivmin1";
            this.ivmin1.Size = new System.Drawing.Size(49, 22);
            this.ivmin1.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(66, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "~";
            // 
            // ivmin2
            // 
            this.ivmin2.AccessibleName = "";
            this.ivmin2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ivmin2.Location = new System.Drawing.Point(11, 92);
            this.ivmin2.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.ivmin2.Name = "ivmin2";
            this.ivmin2.Size = new System.Drawing.Size(49, 22);
            this.ivmin2.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "~";
            // 
            // ivmin3
            // 
            this.ivmin3.AccessibleName = "";
            this.ivmin3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ivmin3.Location = new System.Drawing.Point(11, 122);
            this.ivmin3.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.ivmin3.Name = "ivmin3";
            this.ivmin3.Size = new System.Drawing.Size(49, 22);
            this.ivmin3.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "~";
            // 
            // ivmin4
            // 
            this.ivmin4.AccessibleName = "";
            this.ivmin4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ivmin4.Location = new System.Drawing.Point(11, 152);
            this.ivmin4.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.ivmin4.Name = "ivmin4";
            this.ivmin4.Size = new System.Drawing.Size(49, 22);
            this.ivmin4.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "~";
            // 
            // ivmin5
            // 
            this.ivmin5.AccessibleName = "";
            this.ivmin5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ivmin5.Location = new System.Drawing.Point(11, 182);
            this.ivmin5.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.ivmin5.Name = "ivmin5";
            this.ivmin5.Size = new System.Drawing.Size(49, 22);
            this.ivmin5.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "~";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "~";
            // 
            // ivmax1
            // 
            this.ivmax1.AccessibleName = "";
            this.ivmax1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ivmax1.Location = new System.Drawing.Point(86, 62);
            this.ivmax1.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.ivmax1.Name = "ivmax1";
            this.ivmax1.Size = new System.Drawing.Size(49, 22);
            this.ivmax1.TabIndex = 13;
            this.ivmax1.Value = new decimal(new int[] {
            31,
            0,
            0,
            0});
            // 
            // ivmax5
            // 
            this.ivmax5.AccessibleName = "";
            this.ivmax5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ivmax5.Location = new System.Drawing.Point(86, 182);
            this.ivmax5.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.ivmax5.Name = "ivmax5";
            this.ivmax5.Size = new System.Drawing.Size(49, 22);
            this.ivmax5.TabIndex = 17;
            this.ivmax5.Value = new decimal(new int[] {
            31,
            0,
            0,
            0});
            // 
            // ivmax2
            // 
            this.ivmax2.AccessibleName = "";
            this.ivmax2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ivmax2.Location = new System.Drawing.Point(86, 92);
            this.ivmax2.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.ivmax2.Name = "ivmax2";
            this.ivmax2.Size = new System.Drawing.Size(49, 22);
            this.ivmax2.TabIndex = 14;
            this.ivmax2.Value = new decimal(new int[] {
            31,
            0,
            0,
            0});
            // 
            // ivmax4
            // 
            this.ivmax4.AccessibleName = "";
            this.ivmax4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ivmax4.Location = new System.Drawing.Point(86, 152);
            this.ivmax4.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.ivmax4.Name = "ivmax4";
            this.ivmax4.Size = new System.Drawing.Size(49, 22);
            this.ivmax4.TabIndex = 16;
            this.ivmax4.Value = new decimal(new int[] {
            31,
            0,
            0,
            0});
            // 
            // ivmax3
            // 
            this.ivmax3.AccessibleName = "";
            this.ivmax3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ivmax3.Location = new System.Drawing.Point(86, 122);
            this.ivmax3.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.ivmax3.Name = "ivmax3";
            this.ivmax3.Size = new System.Drawing.Size(49, 22);
            this.ivmax3.TabIndex = 15;
            this.ivmax3.Value = new decimal(new int[] {
            31,
            0,
            0,
            0});
            // 
            // StatPanel
            // 
            this.StatPanel.Controls.Add(this.L_Stats);
            this.StatPanel.Controls.Add(this.L_BS);
            this.StatPanel.Controls.Add(this.Stat0);
            this.StatPanel.Controls.Add(this.Stat1);
            this.StatPanel.Controls.Add(this.BS_5);
            this.StatPanel.Controls.Add(this.Stat2);
            this.StatPanel.Controls.Add(this.BS_4);
            this.StatPanel.Controls.Add(this.Stat3);
            this.StatPanel.Controls.Add(this.BS_3);
            this.StatPanel.Controls.Add(this.Stat4);
            this.StatPanel.Controls.Add(this.BS_2);
            this.StatPanel.Controls.Add(this.Stat5);
            this.StatPanel.Controls.Add(this.BS_1);
            this.StatPanel.Controls.Add(this.BS_0);
            this.StatPanel.Location = new System.Drawing.Point(40, 54);
            this.StatPanel.Name = "StatPanel";
            this.StatPanel.Size = new System.Drawing.Size(147, 209);
            this.StatPanel.TabIndex = 42;
            // 
            // L_Stats
            // 
            this.L_Stats.AutoSize = true;
            this.L_Stats.Location = new System.Drawing.Point(80, 7);
            this.L_Stats.Name = "L_Stats";
            this.L_Stats.Size = new System.Drawing.Size(43, 13);
            this.L_Stats.TabIndex = 74;
            this.L_Stats.Text = "能力值";
            // 
            // L_BS
            // 
            this.L_BS.AutoSize = true;
            this.L_BS.Location = new System.Drawing.Point(11, 7);
            this.L_BS.Name = "L_BS";
            this.L_BS.Size = new System.Drawing.Size(43, 13);
            this.L_BS.TabIndex = 73;
            this.L_BS.Text = "种族值";
            // 
            // Stat0
            // 
            this.Stat0.AccessibleName = "";
            this.Stat0.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stat0.Location = new System.Drawing.Point(80, 32);
            this.Stat0.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.Stat0.Name = "Stat0";
            this.Stat0.Size = new System.Drawing.Size(55, 22);
            this.Stat0.TabIndex = 31;
            // 
            // Stat1
            // 
            this.Stat1.AccessibleName = "";
            this.Stat1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stat1.Location = new System.Drawing.Point(80, 62);
            this.Stat1.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.Stat1.Name = "Stat1";
            this.Stat1.Size = new System.Drawing.Size(55, 22);
            this.Stat1.TabIndex = 32;
            // 
            // BS_5
            // 
            this.BS_5.AccessibleName = "";
            this.BS_5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BS_5.Location = new System.Drawing.Point(11, 182);
            this.BS_5.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.BS_5.Name = "BS_5";
            this.BS_5.Size = new System.Drawing.Size(55, 22);
            this.BS_5.TabIndex = 5;
            // 
            // Stat2
            // 
            this.Stat2.AccessibleName = "";
            this.Stat2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stat2.Location = new System.Drawing.Point(80, 92);
            this.Stat2.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.Stat2.Name = "Stat2";
            this.Stat2.Size = new System.Drawing.Size(55, 22);
            this.Stat2.TabIndex = 33;
            // 
            // BS_4
            // 
            this.BS_4.AccessibleName = "";
            this.BS_4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BS_4.Location = new System.Drawing.Point(11, 152);
            this.BS_4.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.BS_4.Name = "BS_4";
            this.BS_4.Size = new System.Drawing.Size(55, 22);
            this.BS_4.TabIndex = 4;
            // 
            // Stat3
            // 
            this.Stat3.AccessibleName = "";
            this.Stat3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stat3.Location = new System.Drawing.Point(80, 122);
            this.Stat3.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.Stat3.Name = "Stat3";
            this.Stat3.Size = new System.Drawing.Size(55, 22);
            this.Stat3.TabIndex = 34;
            // 
            // BS_3
            // 
            this.BS_3.AccessibleName = "";
            this.BS_3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BS_3.Location = new System.Drawing.Point(11, 122);
            this.BS_3.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.BS_3.Name = "BS_3";
            this.BS_3.Size = new System.Drawing.Size(55, 22);
            this.BS_3.TabIndex = 3;
            // 
            // Stat4
            // 
            this.Stat4.AccessibleName = "";
            this.Stat4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stat4.Location = new System.Drawing.Point(80, 152);
            this.Stat4.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.Stat4.Name = "Stat4";
            this.Stat4.Size = new System.Drawing.Size(55, 22);
            this.Stat4.TabIndex = 35;
            // 
            // BS_2
            // 
            this.BS_2.AccessibleName = "";
            this.BS_2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BS_2.Location = new System.Drawing.Point(11, 92);
            this.BS_2.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.BS_2.Name = "BS_2";
            this.BS_2.Size = new System.Drawing.Size(55, 22);
            this.BS_2.TabIndex = 2;
            // 
            // Stat5
            // 
            this.Stat5.AccessibleName = "";
            this.Stat5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stat5.Location = new System.Drawing.Point(80, 182);
            this.Stat5.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.Stat5.Name = "Stat5";
            this.Stat5.Size = new System.Drawing.Size(55, 22);
            this.Stat5.TabIndex = 36;
            // 
            // BS_1
            // 
            this.BS_1.AccessibleName = "";
            this.BS_1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BS_1.Location = new System.Drawing.Point(11, 62);
            this.BS_1.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.BS_1.Name = "BS_1";
            this.BS_1.Size = new System.Drawing.Size(55, 22);
            this.BS_1.TabIndex = 1;
            // 
            // BS_0
            // 
            this.BS_0.AccessibleName = "";
            this.BS_0.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BS_0.Location = new System.Drawing.Point(11, 32);
            this.BS_0.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.BS_0.Name = "BS_0";
            this.BS_0.Size = new System.Drawing.Size(55, 22);
            this.BS_0.TabIndex = 0;
            // 
            // RNGMethod
            // 
            this.RNGMethod.AllowDrop = true;
            this.RNGMethod.Controls.Add(this.StationaryRNG);
            this.RNGMethod.Controls.Add(this.EventRNG);
            this.RNGMethod.Location = new System.Drawing.Point(12, 32);
            this.RNGMethod.Name = "RNGMethod";
            this.RNGMethod.SelectedIndex = 0;
            this.RNGMethod.Size = new System.Drawing.Size(1083, 323);
            this.RNGMethod.TabIndex = 5;
            this.RNGMethod.SelectedIndexChanged += new System.EventHandler(this.RNGMethod_SelectedIndexChanged);
            this.RNGMethod.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragDropWC);
            this.RNGMethod.DragEnter += new System.Windows.Forms.DragEventHandler(this.DropEnter);
            // 
            // StationaryRNG
            // 
            this.StationaryRNG.Controls.Add(this.RNGInfo);
            this.StationaryRNG.Controls.Add(this.Condition);
            this.StationaryRNG.Controls.Add(this.Filters);
            this.StationaryRNG.Location = new System.Drawing.Point(4, 22);
            this.StationaryRNG.Name = "StationaryRNG";
            this.StationaryRNG.Padding = new System.Windows.Forms.Padding(3);
            this.StationaryRNG.Size = new System.Drawing.Size(1075, 297);
            this.StationaryRNG.TabIndex = 0;
            this.StationaryRNG.Text = "定点乱数";
            this.StationaryRNG.UseVisualStyleBackColor = true;
            // 
            // RNGInfo
            // 
            this.RNGInfo.Controls.Add(this.CreateTimeline);
            this.RNGInfo.Controls.Add(this.TimeSpan);
            this.RNGInfo.Controls.Add(this.ConsiderDelay);
            this.RNGInfo.Controls.Add(this.Timedelay);
            this.RNGInfo.Controls.Add(this.NPC);
            this.RNGInfo.Controls.Add(this.RB_FrameRange);
            this.RNGInfo.Controls.Add(this.CalcList);
            this.RNGInfo.Controls.Add(this.L_NPC);
            this.RNGInfo.Controls.Add(this.label7);
            this.RNGInfo.Controls.Add(this.label10);
            this.RNGInfo.Controls.Add(this.Frame_max);
            this.RNGInfo.Controls.Add(this.Frame_min);
            this.RNGInfo.Location = new System.Drawing.Point(839, 13);
            this.RNGInfo.Name = "RNGInfo";
            this.RNGInfo.Size = new System.Drawing.Size(227, 278);
            this.RNGInfo.TabIndex = 91;
            this.RNGInfo.TabStop = false;
            this.RNGInfo.Text = "乱数信息";
            // 
            // CreateTimeline
            // 
            this.CreateTimeline.AutoSize = true;
            this.CreateTimeline.Location = new System.Drawing.Point(17, 196);
            this.CreateTimeline.Name = "CreateTimeline";
            this.CreateTimeline.Size = new System.Drawing.Size(85, 17);
            this.CreateTimeline.TabIndex = 95;
            this.CreateTimeline.Text = "生成时间线";
            this.CreateTimeline.UseVisualStyleBackColor = true;
            // 
            // TimeSpan
            // 
            this.TimeSpan.AccessibleName = "";
            this.TimeSpan.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeSpan.Location = new System.Drawing.Point(136, 196);
            this.TimeSpan.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.TimeSpan.Name = "TimeSpan";
            this.TimeSpan.Size = new System.Drawing.Size(72, 22);
            this.TimeSpan.TabIndex = 94;
            this.TimeSpan.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // ConsiderDelay
            // 
            this.ConsiderDelay.AutoSize = true;
            this.ConsiderDelay.Checked = true;
            this.ConsiderDelay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ConsiderDelay.Location = new System.Drawing.Point(14, 28);
            this.ConsiderDelay.Name = "ConsiderDelay";
            this.ConsiderDelay.Size = new System.Drawing.Size(98, 17);
            this.ConsiderDelay.TabIndex = 63;
            this.ConsiderDelay.Text = "考虑时间延迟";
            this.ConsiderDelay.UseVisualStyleBackColor = true;
            // 
            // Timedelay
            // 
            this.Timedelay.AccessibleName = "";
            this.Timedelay.Enabled = false;
            this.Timedelay.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Timedelay.Location = new System.Drawing.Point(136, 25);
            this.Timedelay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Timedelay.Name = "Timedelay";
            this.Timedelay.Size = new System.Drawing.Size(44, 22);
            this.Timedelay.TabIndex = 64;
            // 
            // NPC
            // 
            this.NPC.AccessibleName = "";
            this.NPC.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NPC.Location = new System.Drawing.Point(136, 57);
            this.NPC.Name = "NPC";
            this.NPC.Size = new System.Drawing.Size(38, 22);
            this.NPC.TabIndex = 40;
            // 
            // RB_FrameRange
            // 
            this.RB_FrameRange.AutoSize = true;
            this.RB_FrameRange.Checked = true;
            this.RB_FrameRange.Location = new System.Drawing.Point(15, 125);
            this.RB_FrameRange.Name = "RB_FrameRange";
            this.RB_FrameRange.Size = new System.Drawing.Size(73, 17);
            this.RB_FrameRange.TabIndex = 92;
            this.RB_FrameRange.TabStop = true;
            this.RB_FrameRange.Text = "检索范围";
            this.RB_FrameRange.UseVisualStyleBackColor = true;
            // 
            // CalcList
            // 
            this.CalcList.Location = new System.Drawing.Point(118, 230);
            this.CalcList.Name = "CalcList";
            this.CalcList.Size = new System.Drawing.Size(92, 28);
            this.CalcList.TabIndex = 90;
            this.CalcList.Text = "检索";
            this.CalcList.UseVisualStyleBackColor = true;
            this.CalcList.Click += new System.EventHandler(this.CalcList_Click);
            // 
            // L_NPC
            // 
            this.L_NPC.AutoSize = true;
            this.L_NPC.Location = new System.Drawing.Point(71, 61);
            this.L_NPC.Name = "L_NPC";
            this.L_NPC.Size = new System.Drawing.Size(41, 13);
            this.L_NPC.TabIndex = 47;
            this.L_NPC.Text = "NPC数";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(103, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "->";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(186, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 15);
            this.label10.TabIndex = 65;
            this.label10.Text = "+4F";
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
            this.Frame_max.Location = new System.Drawing.Point(133, 152);
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
            this.Frame_max.TabIndex = 41;
            this.Frame_max.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // Frame_min
            // 
            this.Frame_min.AccessibleName = "";
            this.Frame_min.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Frame_min.Location = new System.Drawing.Point(15, 152);
            this.Frame_min.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.Frame_min.Name = "Frame_min";
            this.Frame_min.Size = new System.Drawing.Size(75, 22);
            this.Frame_min.TabIndex = 40;
            // 
            // Condition
            // 
            this.Condition.Controls.Add(this.L_Category);
            this.Condition.Controls.Add(this.CB_Category);
            this.Condition.Controls.Add(this.L_GenderRatio);
            this.Condition.Controls.Add(this.ShinyLocked);
            this.Condition.Controls.Add(this.L_SyncNature);
            this.Condition.Controls.Add(this.GenderRatio);
            this.Condition.Controls.Add(this.SyncNature);
            this.Condition.Controls.Add(this.Fix3v);
            this.Condition.Controls.Add(this.L_Poke);
            this.Condition.Controls.Add(this.Sta_Poke);
            this.Condition.Controls.Add(this.AlwaysSynced);
            this.Condition.Location = new System.Drawing.Point(11, 13);
            this.Condition.Name = "Condition";
            this.Condition.Size = new System.Drawing.Size(405, 145);
            this.Condition.TabIndex = 89;
            this.Condition.TabStop = false;
            this.Condition.Text = "条件设置";
            // 
            // L_Category
            // 
            this.L_Category.AutoSize = true;
            this.L_Category.Location = new System.Drawing.Point(9, 28);
            this.L_Category.Name = "L_Category";
            this.L_Category.Size = new System.Drawing.Size(31, 13);
            this.L_Category.TabIndex = 74;
            this.L_Category.Text = "分类";
            // 
            // CB_Category
            // 
            this.CB_Category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Category.FormattingEnabled = true;
            this.CB_Category.Location = new System.Drawing.Point(62, 24);
            this.CB_Category.Name = "CB_Category";
            this.CB_Category.Size = new System.Drawing.Size(106, 21);
            this.CB_Category.TabIndex = 73;
            this.CB_Category.SelectedIndexChanged += new System.EventHandler(this.Category_SelectedIndexChanged);
            // 
            // L_GenderRatio
            // 
            this.L_GenderRatio.AutoSize = true;
            this.L_GenderRatio.Location = new System.Drawing.Point(9, 71);
            this.L_GenderRatio.Name = "L_GenderRatio";
            this.L_GenderRatio.Size = new System.Drawing.Size(43, 13);
            this.L_GenderRatio.TabIndex = 72;
            this.L_GenderRatio.Text = "性别比";
            // 
            // ShinyLocked
            // 
            this.ShinyLocked.AutoSize = true;
            this.ShinyLocked.Location = new System.Drawing.Point(262, 69);
            this.ShinyLocked.Name = "ShinyLocked";
            this.ShinyLocked.Size = new System.Drawing.Size(74, 17);
            this.ShinyLocked.TabIndex = 71;
            this.ShinyLocked.Text = "必定不闪";
            this.ShinyLocked.UseVisualStyleBackColor = true;
            // 
            // L_SyncNature
            // 
            this.L_SyncNature.AutoSize = true;
            this.L_SyncNature.Location = new System.Drawing.Point(9, 114);
            this.L_SyncNature.Name = "L_SyncNature";
            this.L_SyncNature.Size = new System.Drawing.Size(55, 13);
            this.L_SyncNature.TabIndex = 70;
            this.L_SyncNature.Text = "同步性格";
            // 
            // GenderRatio
            // 
            this.GenderRatio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GenderRatio.Location = new System.Drawing.Point(81, 67);
            this.GenderRatio.Name = "GenderRatio";
            this.GenderRatio.Size = new System.Drawing.Size(76, 21);
            this.GenderRatio.TabIndex = 8;
            // 
            // SyncNature
            // 
            this.SyncNature.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SyncNature.Location = new System.Drawing.Point(81, 110);
            this.SyncNature.Name = "SyncNature";
            this.SyncNature.Size = new System.Drawing.Size(76, 21);
            this.SyncNature.TabIndex = 3;
            this.SyncNature.SelectedIndexChanged += new System.EventHandler(this.SyncNature_SelectedIndexChanged);
            // 
            // Fix3v
            // 
            this.Fix3v.AutoSize = true;
            this.Fix3v.Location = new System.Drawing.Point(176, 69);
            this.Fix3v.Name = "Fix3v";
            this.Fix3v.Size = new System.Drawing.Size(63, 17);
            this.Fix3v.TabIndex = 1;
            this.Fix3v.Text = "固定3V";
            this.Fix3v.UseVisualStyleBackColor = true;
            // 
            // L_Poke
            // 
            this.L_Poke.AutoSize = true;
            this.L_Poke.Location = new System.Drawing.Point(187, 28);
            this.L_Poke.Name = "L_Poke";
            this.L_Poke.Size = new System.Drawing.Size(43, 13);
            this.L_Poke.TabIndex = 37;
            this.L_Poke.Text = "宝可梦";
            // 
            // Sta_Poke
            // 
            this.Sta_Poke.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Sta_Poke.FormattingEnabled = true;
            this.Sta_Poke.Location = new System.Drawing.Point(244, 24);
            this.Sta_Poke.Name = "Sta_Poke";
            this.Sta_Poke.Size = new System.Drawing.Size(92, 21);
            this.Sta_Poke.TabIndex = 36;
            this.Sta_Poke.SelectedIndexChanged += new System.EventHandler(this.Poke_SelectedIndexChanged);
            // 
            // AlwaysSynced
            // 
            this.AlwaysSynced.AutoSize = true;
            this.AlwaysSynced.Location = new System.Drawing.Point(176, 112);
            this.AlwaysSynced.Name = "AlwaysSynced";
            this.AlwaysSynced.Size = new System.Drawing.Size(74, 17);
            this.AlwaysSynced.TabIndex = 9;
            this.AlwaysSynced.Text = "必定同步";
            this.AlwaysSynced.UseVisualStyleBackColor = true;
            // 
            // EventRNG
            // 
            this.EventRNG.Controls.Add(this.EventSetting);
            this.EventRNG.Location = new System.Drawing.Point(4, 22);
            this.EventRNG.Name = "EventRNG";
            this.EventRNG.Padding = new System.Windows.Forms.Padding(3);
            this.EventRNG.Size = new System.Drawing.Size(1075, 297);
            this.EventRNG.TabIndex = 1;
            this.EventRNG.Text = "配信乱数";
            this.EventRNG.UseVisualStyleBackColor = true;
            // 
            // EventSetting
            // 
            this.EventSetting.Controls.Add(this.B_Open);
            this.EventSetting.Controls.Add(this.Event_Forme);
            this.EventSetting.Controls.Add(this.Event_PID);
            this.EventSetting.Controls.Add(this.L_Forme);
            this.EventSetting.Controls.Add(this.Event_EC);
            this.EventSetting.Controls.Add(this.Event_Species);
            this.EventSetting.Controls.Add(this.Event_SID);
            this.EventSetting.Controls.Add(this.L_Event_PID);
            this.EventSetting.Controls.Add(this.AbilityLocked);
            this.EventSetting.Controls.Add(this.EventIV0);
            this.EventSetting.Controls.Add(this.L_IVsCount);
            this.EventSetting.Controls.Add(this.L_Species);
            this.EventSetting.Controls.Add(this.L_EC);
            this.EventSetting.Controls.Add(this.EventIV1);
            this.EventSetting.Controls.Add(this.IVsCount);
            this.EventSetting.Controls.Add(this.IsEgg);
            this.EventSetting.Controls.Add(this.YourID);
            this.EventSetting.Controls.Add(this.EventIV2);
            this.EventSetting.Controls.Add(this.GenderLocked);
            this.EventSetting.Controls.Add(this.OtherInfo);
            this.EventSetting.Controls.Add(this.L_SID);
            this.EventSetting.Controls.Add(this.EventIV3);
            this.EventSetting.Controls.Add(this.NatureLocked);
            this.EventSetting.Controls.Add(this.L_Event_TSV);
            this.EventSetting.Controls.Add(this.Event_PIDType);
            this.EventSetting.Controls.Add(this.EventIV4);
            this.EventSetting.Controls.Add(this.Event_IV_Fix5);
            this.EventSetting.Controls.Add(this.Event_Ability);
            this.EventSetting.Controls.Add(this.L_PID);
            this.EventSetting.Controls.Add(this.EventIV5);
            this.EventSetting.Controls.Add(this.Event_IV_Fix4);
            this.EventSetting.Controls.Add(this.L_TID);
            this.EventSetting.Controls.Add(this.Event_IV_Fix3);
            this.EventSetting.Controls.Add(this.Event_IV_Fix0);
            this.EventSetting.Controls.Add(this.Event_TID);
            this.EventSetting.Controls.Add(this.Event_Gender);
            this.EventSetting.Controls.Add(this.Event_IV_Fix2);
            this.EventSetting.Controls.Add(this.Event_IV_Fix1);
            this.EventSetting.Controls.Add(this.Event_Nature);
            this.EventSetting.Location = new System.Drawing.Point(6, 13);
            this.EventSetting.Name = "EventSetting";
            this.EventSetting.Size = new System.Drawing.Size(409, 278);
            this.EventSetting.TabIndex = 97;
            this.EventSetting.TabStop = false;
            this.EventSetting.Text = "配信设置";
            // 
            // B_Open
            // 
            this.B_Open.Location = new System.Drawing.Point(310, 24);
            this.B_Open.Name = "B_Open";
            this.B_Open.Size = new System.Drawing.Size(82, 23);
            this.B_Open.TabIndex = 29;
            this.B_Open.Text = "从文件导入";
            this.B_Open.UseVisualStyleBackColor = true;
            this.B_Open.Click += new System.EventHandler(this.B_Open_Click);
            // 
            // Event_Forme
            // 
            this.Event_Forme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Event_Forme.FormattingEnabled = true;
            this.Event_Forme.Location = new System.Drawing.Point(205, 24);
            this.Event_Forme.Name = "Event_Forme";
            this.Event_Forme.Size = new System.Drawing.Size(61, 21);
            this.Event_Forme.TabIndex = 96;
            this.Event_Forme.Visible = false;
            // 
            // Event_PID
            // 
            this.Event_PID.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Event_PID.Hexadecimal = true;
            this.Event_PID.Location = new System.Drawing.Point(327, 203);
            this.Event_PID.Name = "Event_PID";
            this.Event_PID.Size = new System.Drawing.Size(78, 22);
            this.Event_PID.TabIndex = 92;
            this.Event_PID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Event_PID.Visible = false;
            // 
            // L_Forme
            // 
            this.L_Forme.AutoSize = true;
            this.L_Forme.Location = new System.Drawing.Point(168, 27);
            this.L_Forme.Name = "L_Forme";
            this.L_Forme.Size = new System.Drawing.Size(31, 13);
            this.L_Forme.TabIndex = 95;
            this.L_Forme.Text = "形态";
            this.L_Forme.Visible = false;
            // 
            // Event_EC
            // 
            this.Event_EC.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Event_EC.Hexadecimal = true;
            this.Event_EC.Location = new System.Drawing.Point(327, 241);
            this.Event_EC.Name = "Event_EC";
            this.Event_EC.Size = new System.Drawing.Size(78, 22);
            this.Event_EC.TabIndex = 93;
            this.Event_EC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Event_EC.Visible = false;
            // 
            // Event_Species
            // 
            this.Event_Species.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Event_Species.FormattingEnabled = true;
            this.Event_Species.Location = new System.Drawing.Point(79, 24);
            this.Event_Species.Name = "Event_Species";
            this.Event_Species.Size = new System.Drawing.Size(83, 21);
            this.Event_Species.TabIndex = 94;
            this.Event_Species.SelectedIndexChanged += new System.EventHandler(this.Event_Species_SelectedIndexChanged);
            // 
            // Event_SID
            // 
            this.Event_SID.AccessibleName = "";
            this.Event_SID.Enabled = false;
            this.Event_SID.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Event_SID.Location = new System.Drawing.Point(324, 134);
            this.Event_SID.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Event_SID.Name = "Event_SID";
            this.Event_SID.Size = new System.Drawing.Size(63, 22);
            this.Event_SID.TabIndex = 56;
            this.Event_SID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Event_SID.ValueChanged += new System.EventHandler(this.IDChanged);
            // 
            // L_Event_PID
            // 
            this.L_Event_PID.AutoSize = true;
            this.L_Event_PID.Location = new System.Drawing.Point(127, 135);
            this.L_Event_PID.Name = "L_Event_PID";
            this.L_Event_PID.Size = new System.Drawing.Size(52, 13);
            this.L_Event_PID.TabIndex = 71;
            this.L_Event_PID.Text = "PID Type";
            // 
            // AbilityLocked
            // 
            this.AbilityLocked.AutoSize = true;
            this.AbilityLocked.Checked = true;
            this.AbilityLocked.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AbilityLocked.Location = new System.Drawing.Point(127, 169);
            this.AbilityLocked.Name = "AbilityLocked";
            this.AbilityLocked.Size = new System.Drawing.Size(74, 17);
            this.AbilityLocked.TabIndex = 47;
            this.AbilityLocked.Text = "固定特性";
            this.AbilityLocked.UseVisualStyleBackColor = true;
            this.AbilityLocked.CheckedChanged += new System.EventHandler(this.AbilityLocked_CheckedChanged);
            // 
            // EventIV0
            // 
            this.EventIV0.AccessibleName = "";
            this.EventIV0.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventIV0.Location = new System.Drawing.Point(66, 59);
            this.EventIV0.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.EventIV0.Name = "EventIV0";
            this.EventIV0.Size = new System.Drawing.Size(47, 22);
            this.EventIV0.TabIndex = 6;
            this.EventIV0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // L_IVsCount
            // 
            this.L_IVsCount.AutoSize = true;
            this.L_IVsCount.Location = new System.Drawing.Point(124, 66);
            this.L_IVsCount.Name = "L_IVsCount";
            this.L_IVsCount.Size = new System.Drawing.Size(74, 13);
            this.L_IVsCount.TabIndex = 46;
            this.L_IVsCount.Text = "保底随机V数";
            // 
            // L_Species
            // 
            this.L_Species.AutoSize = true;
            this.L_Species.Location = new System.Drawing.Point(12, 27);
            this.L_Species.Name = "L_Species";
            this.L_Species.Size = new System.Drawing.Size(31, 13);
            this.L_Species.TabIndex = 74;
            this.L_Species.Text = "种类";
            // 
            // L_EC
            // 
            this.L_EC.AutoSize = true;
            this.L_EC.Location = new System.Drawing.Point(295, 244);
            this.L_EC.Name = "L_EC";
            this.L_EC.Size = new System.Drawing.Size(21, 13);
            this.L_EC.TabIndex = 57;
            this.L_EC.Text = "EC";
            this.L_EC.Visible = false;
            // 
            // EventIV1
            // 
            this.EventIV1.AccessibleName = "";
            this.EventIV1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventIV1.Location = new System.Drawing.Point(66, 96);
            this.EventIV1.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.EventIV1.Name = "EventIV1";
            this.EventIV1.Size = new System.Drawing.Size(47, 22);
            this.EventIV1.TabIndex = 7;
            this.EventIV1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // IVsCount
            // 
            this.IVsCount.AccessibleName = "";
            this.IVsCount.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IVsCount.Location = new System.Drawing.Point(228, 61);
            this.IVsCount.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.IVsCount.Name = "IVsCount";
            this.IVsCount.Size = new System.Drawing.Size(47, 22);
            this.IVsCount.TabIndex = 45;
            this.IVsCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // IsEgg
            // 
            this.IsEgg.AutoSize = true;
            this.IsEgg.Location = new System.Drawing.Point(216, 99);
            this.IsEgg.Name = "IsEgg";
            this.IsEgg.Size = new System.Drawing.Size(38, 17);
            this.IsEgg.TabIndex = 70;
            this.IsEgg.Text = "蛋";
            this.IsEgg.UseVisualStyleBackColor = true;
            this.IsEgg.CheckedChanged += new System.EventHandler(this.Event_CheckedChanged);
            // 
            // YourID
            // 
            this.YourID.AutoSize = true;
            this.YourID.Location = new System.Drawing.Point(127, 99);
            this.YourID.Name = "YourID";
            this.YourID.Size = new System.Drawing.Size(49, 17);
            this.YourID.TabIndex = 48;
            this.YourID.Text = "自ID";
            this.YourID.UseVisualStyleBackColor = true;
            this.YourID.CheckedChanged += new System.EventHandler(this.Event_CheckedChanged);
            // 
            // EventIV2
            // 
            this.EventIV2.AccessibleName = "";
            this.EventIV2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventIV2.Location = new System.Drawing.Point(66, 133);
            this.EventIV2.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.EventIV2.Name = "EventIV2";
            this.EventIV2.Size = new System.Drawing.Size(47, 22);
            this.EventIV2.TabIndex = 8;
            this.EventIV2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // GenderLocked
            // 
            this.GenderLocked.AutoSize = true;
            this.GenderLocked.Location = new System.Drawing.Point(127, 245);
            this.GenderLocked.Name = "GenderLocked";
            this.GenderLocked.Size = new System.Drawing.Size(74, 17);
            this.GenderLocked.TabIndex = 44;
            this.GenderLocked.Text = "固定性别";
            this.GenderLocked.UseVisualStyleBackColor = true;
            this.GenderLocked.CheckedChanged += new System.EventHandler(this.GenderLocked_CheckedChanged);
            // 
            // OtherInfo
            // 
            this.OtherInfo.AutoSize = true;
            this.OtherInfo.Location = new System.Drawing.Point(298, 64);
            this.OtherInfo.Name = "OtherInfo";
            this.OtherInfo.Size = new System.Drawing.Size(74, 17);
            this.OtherInfo.TabIndex = 54;
            this.OtherInfo.Text = "其他信息";
            this.OtherInfo.UseVisualStyleBackColor = true;
            this.OtherInfo.CheckedChanged += new System.EventHandler(this.OtherInfo_CheckedChanged);
            // 
            // L_SID
            // 
            this.L_SID.AutoSize = true;
            this.L_SID.Location = new System.Drawing.Point(295, 138);
            this.L_SID.Name = "L_SID";
            this.L_SID.Size = new System.Drawing.Size(25, 13);
            this.L_SID.TabIndex = 52;
            this.L_SID.Text = "SID";
            // 
            // EventIV3
            // 
            this.EventIV3.AccessibleName = "";
            this.EventIV3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventIV3.Location = new System.Drawing.Point(66, 170);
            this.EventIV3.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.EventIV3.Name = "EventIV3";
            this.EventIV3.Size = new System.Drawing.Size(47, 22);
            this.EventIV3.TabIndex = 9;
            this.EventIV3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // NatureLocked
            // 
            this.NatureLocked.AutoSize = true;
            this.NatureLocked.Location = new System.Drawing.Point(127, 207);
            this.NatureLocked.Name = "NatureLocked";
            this.NatureLocked.Size = new System.Drawing.Size(74, 17);
            this.NatureLocked.TabIndex = 43;
            this.NatureLocked.Text = "固定性格";
            this.NatureLocked.UseVisualStyleBackColor = true;
            this.NatureLocked.CheckedChanged += new System.EventHandler(this.NatureLocked_CheckedChanged);
            // 
            // L_Event_TSV
            // 
            this.L_Event_TSV.AutoSize = true;
            this.L_Event_TSV.Location = new System.Drawing.Point(295, 172);
            this.L_Event_TSV.Name = "L_Event_TSV";
            this.L_Event_TSV.Size = new System.Drawing.Size(64, 13);
            this.L_Event_TSV.TabIndex = 73;
            this.L_Event_TSV.Text = "TSV:   0000";
            this.L_Event_TSV.Visible = false;
            // 
            // Event_PIDType
            // 
            this.Event_PIDType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Event_PIDType.Items.AddRange(new object[] {
            "",
            "",
            "",
            ""});
            this.Event_PIDType.Location = new System.Drawing.Point(198, 131);
            this.Event_PIDType.Name = "Event_PIDType";
            this.Event_PIDType.Size = new System.Drawing.Size(74, 21);
            this.Event_PIDType.TabIndex = 49;
            this.Event_PIDType.SelectedIndexChanged += new System.EventHandler(this.Event_PIDType_SelectedIndexChanged);
            // 
            // EventIV4
            // 
            this.EventIV4.AccessibleName = "";
            this.EventIV4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventIV4.Location = new System.Drawing.Point(66, 207);
            this.EventIV4.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.EventIV4.Name = "EventIV4";
            this.EventIV4.Size = new System.Drawing.Size(47, 22);
            this.EventIV4.TabIndex = 10;
            this.EventIV4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Event_IV_Fix5
            // 
            this.Event_IV_Fix5.AutoSize = true;
            this.Event_IV_Fix5.Location = new System.Drawing.Point(12, 245);
            this.Event_IV_Fix5.Name = "Event_IV_Fix5";
            this.Event_IV_Fix5.Size = new System.Drawing.Size(50, 17);
            this.Event_IV_Fix5.TabIndex = 41;
            this.Event_IV_Fix5.Text = "速度";
            this.Event_IV_Fix5.UseVisualStyleBackColor = true;
            this.Event_IV_Fix5.CheckedChanged += new System.EventHandler(this.IVLocked_CheckedChanged);
            // 
            // Event_Ability
            // 
            this.Event_Ability.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Event_Ability.Items.AddRange(new object[] {
            "-",
            "1",
            "2",
            "H"});
            this.Event_Ability.Location = new System.Drawing.Point(225, 167);
            this.Event_Ability.Name = "Event_Ability";
            this.Event_Ability.Size = new System.Drawing.Size(62, 21);
            this.Event_Ability.TabIndex = 66;
            // 
            // L_PID
            // 
            this.L_PID.AutoSize = true;
            this.L_PID.Location = new System.Drawing.Point(295, 210);
            this.L_PID.Name = "L_PID";
            this.L_PID.Size = new System.Drawing.Size(25, 13);
            this.L_PID.TabIndex = 58;
            this.L_PID.Text = "PID";
            this.L_PID.Visible = false;
            // 
            // EventIV5
            // 
            this.EventIV5.AccessibleName = "";
            this.EventIV5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventIV5.Location = new System.Drawing.Point(66, 244);
            this.EventIV5.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.EventIV5.Name = "EventIV5";
            this.EventIV5.Size = new System.Drawing.Size(47, 22);
            this.EventIV5.TabIndex = 11;
            this.EventIV5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Event_IV_Fix4
            // 
            this.Event_IV_Fix4.AutoSize = true;
            this.Event_IV_Fix4.Location = new System.Drawing.Point(12, 208);
            this.Event_IV_Fix4.Name = "Event_IV_Fix4";
            this.Event_IV_Fix4.Size = new System.Drawing.Size(50, 17);
            this.Event_IV_Fix4.TabIndex = 40;
            this.Event_IV_Fix4.Text = "特防";
            this.Event_IV_Fix4.UseVisualStyleBackColor = true;
            this.Event_IV_Fix4.CheckedChanged += new System.EventHandler(this.IVLocked_CheckedChanged);
            // 
            // L_TID
            // 
            this.L_TID.AutoSize = true;
            this.L_TID.Location = new System.Drawing.Point(295, 101);
            this.L_TID.Name = "L_TID";
            this.L_TID.Size = new System.Drawing.Size(25, 13);
            this.L_TID.TabIndex = 51;
            this.L_TID.Text = "TID";
            // 
            // Event_IV_Fix3
            // 
            this.Event_IV_Fix3.AutoSize = true;
            this.Event_IV_Fix3.Location = new System.Drawing.Point(12, 171);
            this.Event_IV_Fix3.Name = "Event_IV_Fix3";
            this.Event_IV_Fix3.Size = new System.Drawing.Size(50, 17);
            this.Event_IV_Fix3.TabIndex = 39;
            this.Event_IV_Fix3.Text = "特攻";
            this.Event_IV_Fix3.UseVisualStyleBackColor = true;
            this.Event_IV_Fix3.CheckedChanged += new System.EventHandler(this.IVLocked_CheckedChanged);
            // 
            // Event_IV_Fix0
            // 
            this.Event_IV_Fix0.AutoSize = true;
            this.Event_IV_Fix0.Location = new System.Drawing.Point(12, 60);
            this.Event_IV_Fix0.Name = "Event_IV_Fix0";
            this.Event_IV_Fix0.Size = new System.Drawing.Size(41, 17);
            this.Event_IV_Fix0.TabIndex = 8;
            this.Event_IV_Fix0.Text = "HP";
            this.Event_IV_Fix0.UseVisualStyleBackColor = true;
            this.Event_IV_Fix0.CheckedChanged += new System.EventHandler(this.IVLocked_CheckedChanged);
            // 
            // Event_TID
            // 
            this.Event_TID.AccessibleName = "";
            this.Event_TID.Enabled = false;
            this.Event_TID.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Event_TID.Location = new System.Drawing.Point(324, 95);
            this.Event_TID.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Event_TID.Name = "Event_TID";
            this.Event_TID.Size = new System.Drawing.Size(63, 22);
            this.Event_TID.TabIndex = 55;
            this.Event_TID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Event_TID.ValueChanged += new System.EventHandler(this.IDChanged);
            // 
            // Event_Gender
            // 
            this.Event_Gender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Event_Gender.Enabled = false;
            this.Event_Gender.Location = new System.Drawing.Point(225, 239);
            this.Event_Gender.Name = "Event_Gender";
            this.Event_Gender.Size = new System.Drawing.Size(62, 21);
            this.Event_Gender.TabIndex = 62;
            // 
            // Event_IV_Fix2
            // 
            this.Event_IV_Fix2.AutoSize = true;
            this.Event_IV_Fix2.Location = new System.Drawing.Point(12, 134);
            this.Event_IV_Fix2.Name = "Event_IV_Fix2";
            this.Event_IV_Fix2.Size = new System.Drawing.Size(50, 17);
            this.Event_IV_Fix2.TabIndex = 38;
            this.Event_IV_Fix2.Text = "防御";
            this.Event_IV_Fix2.UseVisualStyleBackColor = true;
            this.Event_IV_Fix2.CheckedChanged += new System.EventHandler(this.IVLocked_CheckedChanged);
            // 
            // Event_IV_Fix1
            // 
            this.Event_IV_Fix1.AutoSize = true;
            this.Event_IV_Fix1.Location = new System.Drawing.Point(12, 97);
            this.Event_IV_Fix1.Name = "Event_IV_Fix1";
            this.Event_IV_Fix1.Size = new System.Drawing.Size(50, 17);
            this.Event_IV_Fix1.TabIndex = 37;
            this.Event_IV_Fix1.Text = "攻击";
            this.Event_IV_Fix1.UseVisualStyleBackColor = true;
            this.Event_IV_Fix1.CheckedChanged += new System.EventHandler(this.IVLocked_CheckedChanged);
            // 
            // Event_Nature
            // 
            this.Event_Nature.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Event_Nature.Enabled = false;
            this.Event_Nature.Location = new System.Drawing.Point(225, 203);
            this.Event_Nature.Name = "Event_Nature";
            this.Event_Nature.Size = new System.Drawing.Size(62, 21);
            this.Event_Nature.TabIndex = 61;
            // 
            // Lang
            // 
            this.Lang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Lang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Lang.FormattingEnabled = true;
            this.Lang.Items.AddRange(new object[] {
            "English",
            "简体中文"});
            this.Lang.Location = new System.Drawing.Point(452, 11);
            this.Lang.Name = "Lang";
            this.Lang.Size = new System.Drawing.Size(76, 21);
            this.Lang.TabIndex = 87;
            this.Lang.SelectedIndexChanged += new System.EventHandler(this.ChangeLanguage);
            // 
            // Advanced
            // 
            this.Advanced.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Advanced.AutoSize = true;
            this.Advanced.Location = new System.Drawing.Point(996, 14);
            this.Advanced.Name = "Advanced";
            this.Advanced.Size = new System.Drawing.Size(74, 17);
            this.Advanced.TabIndex = 86;
            this.Advanced.Text = "高级模式";
            this.Advanced.UseVisualStyleBackColor = true;
            this.Advanced.CheckedChanged += new System.EventHandler(this.Advanced_CheckedChanged);
            // 
            // ShinyCharm
            // 
            this.ShinyCharm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ShinyCharm.AutoSize = true;
            this.ShinyCharm.Location = new System.Drawing.Point(916, 14);
            this.ShinyCharm.Name = "ShinyCharm";
            this.ShinyCharm.Size = new System.Drawing.Size(74, 17);
            this.ShinyCharm.TabIndex = 85;
            this.ShinyCharm.Text = "闪耀护符";
            this.ShinyCharm.UseVisualStyleBackColor = true;
            this.ShinyCharm.CheckedChanged += new System.EventHandler(this.ShinyCharm_CheckedChanged);
            // 
            // L_TSV
            // 
            this.L_TSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.L_TSV.AutoSize = true;
            this.L_TSV.Location = new System.Drawing.Point(790, 16);
            this.L_TSV.Name = "L_TSV";
            this.L_TSV.Size = new System.Drawing.Size(28, 13);
            this.L_TSV.TabIndex = 84;
            this.L_TSV.Text = "TSV";
            // 
            // L_Seed
            // 
            this.L_Seed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.L_Seed.AutoSize = true;
            this.L_Seed.Location = new System.Drawing.Point(663, 16);
            this.L_Seed.Name = "L_Seed";
            this.L_Seed.Size = new System.Drawing.Size(32, 13);
            this.L_Seed.TabIndex = 83;
            this.L_Seed.Text = "Seed";
            // 
            // TSV
            // 
            this.TSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TSV.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSV.Location = new System.Drawing.Point(831, 11);
            this.TSV.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.TSV.Name = "TSV";
            this.TSV.Size = new System.Drawing.Size(54, 22);
            this.TSV.TabIndex = 82;
            this.TSV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TSV.ValueChanged += new System.EventHandler(this.TSV_ValueChanged);
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToResizeColumns = false;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_Frame,
            this.dgv_blink,
            this.dgv_delay,
            this.dgv_H,
            this.dgv_A,
            this.dgv_B,
            this.dgv_C,
            this.dgv_D,
            this.dgv_S,
            this.dgv_nature,
            this.dgv_synced,
            this.dgv_hiddenpower,
            this.dgv_psv,
            this.dgv_gender,
            this.dgv_ability,
            this.dgv_rand,
            this.dgv_rand64,
            this.dgv_pid,
            this.dgv_EC});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGV.Location = new System.Drawing.Point(13, 358);
            this.DGV.Name = "DGV";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV.RowHeadersWidth = 18;
            this.DGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGV.RowTemplate.Height = 21;
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(1069, 288);
            this.DGV.TabIndex = 89;
            // 
            // Gameversion
            // 
            this.Gameversion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Gameversion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Gameversion.Items.AddRange(new object[] {
            "X",
            "Y",
            "OR",
            "AS",
            "Sun",
            "Moon"});
            this.Gameversion.Location = new System.Drawing.Point(603, 11);
            this.Gameversion.Name = "Gameversion";
            this.Gameversion.Size = new System.Drawing.Size(51, 21);
            this.Gameversion.TabIndex = 91;
            this.Gameversion.SelectedIndexChanged += new System.EventHandler(this.GameVersion_SelectedIndexChanged);
            // 
            // L_GameVersion
            // 
            this.L_GameVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.L_GameVersion.AutoSize = true;
            this.L_GameVersion.Location = new System.Drawing.Point(532, 15);
            this.L_GameVersion.Name = "L_GameVersion";
            this.L_GameVersion.Size = new System.Drawing.Size(55, 13);
            this.L_GameVersion.TabIndex = 90;
            this.L_GameVersion.Text = "游戏版本";
            // 
            // Seed
            // 
            this.Seed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Seed.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Seed.Hexadecimal = true;
            this.Seed.Location = new System.Drawing.Point(707, 11);
            this.Seed.Name = "Seed";
            this.Seed.Size = new System.Drawing.Size(78, 22);
            this.Seed.TabIndex = 88;
            this.Seed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Seed.ValueChanged += new System.EventHandler(this.Seed_ValueChanged);
            // 
            // dgv_Frame
            // 
            this.dgv_Frame.HeaderText = "帧数";
            this.dgv_Frame.Name = "dgv_Frame";
            this.dgv_Frame.Width = 60;
            // 
            // dgv_blink
            // 
            this.dgv_blink.HeaderText = "眨眼";
            this.dgv_blink.Name = "dgv_blink";
            this.dgv_blink.Width = 40;
            // 
            // dgv_delay
            // 
            this.dgv_delay.HeaderText = "延时";
            this.dgv_delay.Name = "dgv_delay";
            this.dgv_delay.Width = 40;
            // 
            // dgv_H
            // 
            this.dgv_H.HeaderText = "HP";
            this.dgv_H.Name = "dgv_H";
            this.dgv_H.Width = 30;
            // 
            // dgv_A
            // 
            this.dgv_A.HeaderText = "Atk";
            this.dgv_A.Name = "dgv_A";
            this.dgv_A.Width = 30;
            // 
            // dgv_B
            // 
            this.dgv_B.HeaderText = "Def";
            this.dgv_B.Name = "dgv_B";
            this.dgv_B.Width = 30;
            // 
            // dgv_C
            // 
            this.dgv_C.HeaderText = "SpA";
            this.dgv_C.Name = "dgv_C";
            this.dgv_C.Width = 30;
            // 
            // dgv_D
            // 
            this.dgv_D.HeaderText = "SpD";
            this.dgv_D.Name = "dgv_D";
            this.dgv_D.Width = 30;
            // 
            // dgv_S
            // 
            this.dgv_S.HeaderText = "Spe";
            this.dgv_S.Name = "dgv_S";
            this.dgv_S.Width = 30;
            // 
            // dgv_nature
            // 
            this.dgv_nature.HeaderText = "性格";
            this.dgv_nature.Name = "dgv_nature";
            this.dgv_nature.Width = 55;
            // 
            // dgv_synced
            // 
            this.dgv_synced.HeaderText = "同步";
            this.dgv_synced.Name = "dgv_synced";
            this.dgv_synced.Width = 45;
            // 
            // dgv_hiddenpower
            // 
            this.dgv_hiddenpower.HeaderText = "觉醒";
            this.dgv_hiddenpower.Name = "dgv_hiddenpower";
            this.dgv_hiddenpower.Width = 48;
            // 
            // dgv_psv
            // 
            this.dgv_psv.HeaderText = "PSV";
            this.dgv_psv.Name = "dgv_psv";
            this.dgv_psv.Width = 40;
            // 
            // dgv_gender
            // 
            this.dgv_gender.HeaderText = "性别";
            this.dgv_gender.Name = "dgv_gender";
            this.dgv_gender.Width = 45;
            // 
            // dgv_ability
            // 
            this.dgv_ability.HeaderText = "特性";
            this.dgv_ability.Name = "dgv_ability";
            this.dgv_ability.Width = 45;
            // 
            // dgv_rand
            // 
            this.dgv_rand.HeaderText = "乱数值";
            this.dgv_rand.Name = "dgv_rand";
            this.dgv_rand.Width = 65;
            // 
            // dgv_rand64
            // 
            this.dgv_rand64.HeaderText = "乱数值64";
            this.dgv_rand64.Name = "dgv_rand64";
            this.dgv_rand64.Visible = false;
            this.dgv_rand64.Width = 125;
            // 
            // dgv_pid
            // 
            this.dgv_pid.HeaderText = "PID";
            this.dgv_pid.Name = "dgv_pid";
            this.dgv_pid.Width = 65;
            // 
            // dgv_EC
            // 
            this.dgv_EC.HeaderText = "加密常数";
            this.dgv_EC.Name = "dgv_EC";
            this.dgv_EC.Width = 65;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 652);
            this.Controls.Add(this.Gameversion);
            this.Controls.Add(this.L_GameVersion);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.Seed);
            this.Controls.Add(this.Lang);
            this.Controls.Add(this.Advanced);
            this.Controls.Add(this.ShinyCharm);
            this.Controls.Add(this.L_TSV);
            this.Controls.Add(this.L_Seed);
            this.Controls.Add(this.TSV);
            this.Controls.Add(this.RNGMethod);
            this.Name = "MainForm";
            this.Text = "pkm3dsRNG";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Filters.ResumeLayout(false);
            this.Filters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_Lv)).EndInit();
            this.IVPanel.ResumeLayout(false);
            this.IVPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PerfectIVs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivmin0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivmax0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivmin1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivmin2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivmin3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivmin4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivmin5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivmax1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivmax5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivmax2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivmax4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivmax3)).EndInit();
            this.StatPanel.ResumeLayout(false);
            this.StatPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Stat0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Stat1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Stat2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Stat3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Stat4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Stat5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_0)).EndInit();
            this.RNGMethod.ResumeLayout(false);
            this.StationaryRNG.ResumeLayout(false);
            this.RNGInfo.ResumeLayout(false);
            this.RNGInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeSpan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Timedelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NPC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Frame_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Frame_min)).EndInit();
            this.Condition.ResumeLayout(false);
            this.Condition.PerformLayout();
            this.EventRNG.ResumeLayout(false);
            this.EventSetting.ResumeLayout(false);
            this.EventSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Event_PID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Event_EC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Event_SID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventIV0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventIV1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IVsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventIV2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventIV3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventIV4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventIV5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Event_TID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TSV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Seed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Filters;
        private pkm3dsRNG.Controls.CheckBoxComboBox HiddenPower;
        private pkm3dsRNG.Controls.CheckBoxComboBox Nature;
        private System.Windows.Forms.CheckBox ShowStats;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.RadioButton ByIVs;
        private System.Windows.Forms.RadioButton ByStats;
        private System.Windows.Forms.Label L_Lv_S;
        private System.Windows.Forms.Label L_Ability;
        private System.Windows.Forms.NumericUpDown Filter_Lv;
        private System.Windows.Forms.ComboBox Ability;
        private System.Windows.Forms.CheckBox DisableFilters;
        private System.Windows.Forms.CheckBox ShinyOnly;
        private System.Windows.Forms.Label L_gender;
        private System.Windows.Forms.ComboBox Gender;
        private System.Windows.Forms.Label L_nature;
        private System.Windows.Forms.Label L_HP;
        private System.Windows.Forms.Label L_S;
        private System.Windows.Forms.Label L_C;
        private System.Windows.Forms.Label L_B;
        private System.Windows.Forms.Label L_H;
        private System.Windows.Forms.Label L_A;
        private System.Windows.Forms.Label L_D;
        private System.Windows.Forms.Panel IVPanel;
        private System.Windows.Forms.NumericUpDown PerfectIVs;
        private System.Windows.Forms.Label L_IVRange;
        private System.Windows.Forms.NumericUpDown ivmin0;
        private System.Windows.Forms.NumericUpDown ivmax0;
        private System.Windows.Forms.NumericUpDown ivmin1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown ivmin2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown ivmin3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown ivmin4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown ivmin5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ivmax1;
        private System.Windows.Forms.NumericUpDown ivmax5;
        private System.Windows.Forms.NumericUpDown ivmax2;
        private System.Windows.Forms.NumericUpDown ivmax4;
        private System.Windows.Forms.NumericUpDown ivmax3;
        private System.Windows.Forms.Panel StatPanel;
        private System.Windows.Forms.Label L_Stats;
        private System.Windows.Forms.Label L_BS;
        private System.Windows.Forms.NumericUpDown Stat0;
        private System.Windows.Forms.NumericUpDown Stat1;
        private System.Windows.Forms.NumericUpDown BS_5;
        private System.Windows.Forms.NumericUpDown Stat2;
        private System.Windows.Forms.NumericUpDown BS_4;
        private System.Windows.Forms.NumericUpDown Stat3;
        private System.Windows.Forms.NumericUpDown BS_3;
        private System.Windows.Forms.NumericUpDown Stat4;
        private System.Windows.Forms.NumericUpDown BS_2;
        private System.Windows.Forms.NumericUpDown Stat5;
        private System.Windows.Forms.NumericUpDown BS_1;
        private System.Windows.Forms.NumericUpDown BS_0;
        private System.Windows.Forms.TabControl RNGMethod;
        private System.Windows.Forms.TabPage StationaryRNG;
        private System.Windows.Forms.TabPage EventRNG;
        private System.Windows.Forms.ComboBox Lang;
        private System.Windows.Forms.CheckBox Advanced;
        private System.Windows.Forms.CheckBox ShinyCharm;
        private System.Windows.Forms.Label L_TSV;
        private System.Windows.Forms.Label L_Seed;
        private System.Windows.Forms.NumericUpDown TSV;
        private Controls.HexNumericUpdown Seed;
        private System.Windows.Forms.GroupBox Condition;
        private System.Windows.Forms.Label L_SyncNature;
        private System.Windows.Forms.ComboBox GenderRatio;
        private System.Windows.Forms.ComboBox SyncNature;
        private System.Windows.Forms.CheckBox Fix3v;
        private System.Windows.Forms.Label L_Poke;
        private System.Windows.Forms.ComboBox Sta_Poke;
        private System.Windows.Forms.CheckBox AlwaysSynced;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Button CalcList;
        private System.Windows.Forms.GroupBox RNGInfo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown Frame_max;
        private System.Windows.Forms.NumericUpDown Frame_min;
        private System.Windows.Forms.ComboBox Gameversion;
        private System.Windows.Forms.Label L_GameVersion;
        private System.Windows.Forms.CheckBox ShinyLocked;
        private System.Windows.Forms.ComboBox CB_Category;
        private System.Windows.Forms.Label L_GenderRatio;
        private System.Windows.Forms.Label L_Category;
        private System.Windows.Forms.Label L_Event_PID;
        private System.Windows.Forms.Label L_Species;
        private System.Windows.Forms.CheckBox IsEgg;
        private System.Windows.Forms.CheckBox OtherInfo;
        private System.Windows.Forms.Label L_Event_TSV;
        private System.Windows.Forms.ComboBox Event_Ability;
        private System.Windows.Forms.Label L_TID;
        private System.Windows.Forms.ComboBox Event_Gender;
        private System.Windows.Forms.ComboBox Event_Nature;
        private System.Windows.Forms.NumericUpDown Event_TID;
        private System.Windows.Forms.Button B_Open;
        private System.Windows.Forms.Label L_PID;
        private System.Windows.Forms.ComboBox Event_PIDType;
        private System.Windows.Forms.Label L_SID;
        private System.Windows.Forms.CheckBox YourID;
        private System.Windows.Forms.Label L_EC;
        private System.Windows.Forms.CheckBox AbilityLocked;
        private System.Windows.Forms.NumericUpDown Event_SID;
        private System.Windows.Forms.Label L_IVsCount;
        private System.Windows.Forms.NumericUpDown IVsCount;
        private System.Windows.Forms.CheckBox GenderLocked;
        private System.Windows.Forms.CheckBox NatureLocked;
        private System.Windows.Forms.CheckBox Event_IV_Fix5;
        private System.Windows.Forms.CheckBox Event_IV_Fix4;
        private System.Windows.Forms.CheckBox Event_IV_Fix3;
        private System.Windows.Forms.CheckBox Event_IV_Fix2;
        private System.Windows.Forms.CheckBox Event_IV_Fix1;
        private System.Windows.Forms.CheckBox Event_IV_Fix0;
        private System.Windows.Forms.NumericUpDown EventIV5;
        private System.Windows.Forms.NumericUpDown EventIV4;
        private System.Windows.Forms.NumericUpDown EventIV3;
        private System.Windows.Forms.NumericUpDown EventIV2;
        private System.Windows.Forms.NumericUpDown EventIV1;
        private System.Windows.Forms.NumericUpDown EventIV0;
        private Controls.HexNumericUpdown Event_EC;
        private Controls.HexNumericUpdown Event_PID;
        private System.Windows.Forms.ComboBox Event_Species;
        private System.Windows.Forms.ComboBox Event_Forme;
        private System.Windows.Forms.Label L_Forme;
        private System.Windows.Forms.GroupBox EventSetting;
        private System.Windows.Forms.RadioButton RB_FrameRange;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown Timedelay;
        private System.Windows.Forms.CheckBox ConsiderDelay;
        private System.Windows.Forms.NumericUpDown NPC;
        private System.Windows.Forms.Label L_NPC;
        private System.Windows.Forms.RadioButton CreateTimeline;
        private System.Windows.Forms.NumericUpDown TimeSpan;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_Frame;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_blink;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_delay;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_H;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_A;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_B;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_D;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_S;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_nature;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_synced;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_hiddenpower;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_psv;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_ability;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_rand;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_rand64;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_pid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_EC;
    }
}

