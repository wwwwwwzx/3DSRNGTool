namespace Pk3DSRNGTool.Subforms
{
    partial class ProfileView
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
            this.B_Save = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Gameversion = new System.Windows.Forms.ComboBox();
            this.ShinyCharm = new System.Windows.Forms.CheckBox();
            this.TSV = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Key3 = new Pk3DSRNGTool.Controls.HexMaskedTextBox();
            this.Key0 = new Pk3DSRNGTool.Controls.HexMaskedTextBox();
            this.Key2 = new Pk3DSRNGTool.Controls.HexMaskedTextBox();
            this.Key1 = new Pk3DSRNGTool.Controls.HexMaskedTextBox();
            this.L_GameVersion = new System.Windows.Forms.Label();
            this.L_TSV = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TSV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // B_Save
            // 
            this.B_Save.Location = new System.Drawing.Point(39, 248);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(75, 23);
            this.B_Save.TabIndex = 0;
            this.B_Save.Text = "Save";
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(120, 248);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.B_Close_Click);
            // 
            // Gameversion
            // 
            this.Gameversion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Gameversion.FormattingEnabled = true;
            this.Gameversion.Items.AddRange(new object[] {
            "X",
            "Y",
            "OR",
            "AS",
            "Transporter",
            "Sun",
            "Moon",
            "Ultra Sun",
            "Ultra Moon"});
            this.Gameversion.Location = new System.Drawing.Point(91, 36);
            this.Gameversion.Name = "Gameversion";
            this.Gameversion.Size = new System.Drawing.Size(121, 21);
            this.Gameversion.TabIndex = 2;
            this.Gameversion.SelectedIndexChanged += new System.EventHandler(this.Gameversion_SelectedIndexChanged);
            // 
            // ShinyCharm
            // 
            this.ShinyCharm.AutoSize = true;
            this.ShinyCharm.Location = new System.Drawing.Point(91, 89);
            this.ShinyCharm.Name = "ShinyCharm";
            this.ShinyCharm.Size = new System.Drawing.Size(82, 17);
            this.ShinyCharm.TabIndex = 4;
            this.ShinyCharm.Text = "ShinyCharm";
            this.ShinyCharm.UseVisualStyleBackColor = true;
            // 
            // TSV
            // 
            this.TSV.Location = new System.Drawing.Point(91, 63);
            this.TSV.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.TSV.Name = "TSV";
            this.TSV.Size = new System.Drawing.Size(54, 20);
            this.TSV.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Key3);
            this.groupBox1.Controls.Add(this.Key0);
            this.groupBox1.Controls.Add(this.Key2);
            this.groupBox1.Controls.Add(this.Key1);
            this.groupBox1.Location = new System.Drawing.Point(62, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(110, 130);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Egg Seeds";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "[0]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "[1]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "[2]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "[3]";
            // 
            // Key3
            // 
            this.Key3.Location = new System.Drawing.Point(36, 16);
            this.Key3.Mask = "AAAAAAAA";
            this.Key3.Name = "Key3";
            this.Key3.Size = new System.Drawing.Size(63, 20);
            this.Key3.TabIndex = 5;
            this.Key3.Text = "00000000";
            this.Key3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Key3.Value = ((uint)(0u));
            // 
            // Key0
            // 
            this.Key0.Location = new System.Drawing.Point(36, 94);
            this.Key0.Mask = "AAAAAAAA";
            this.Key0.Name = "Key0";
            this.Key0.Size = new System.Drawing.Size(63, 20);
            this.Key0.TabIndex = 6;
            this.Key0.Text = "00000000";
            this.Key0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Key0.Value = ((uint)(0u));
            // 
            // Key2
            // 
            this.Key2.Location = new System.Drawing.Point(36, 42);
            this.Key2.Mask = "AAAAAAAA";
            this.Key2.Name = "Key2";
            this.Key2.Size = new System.Drawing.Size(63, 20);
            this.Key2.TabIndex = 8;
            this.Key2.Text = "00000000";
            this.Key2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Key2.Value = ((uint)(0u));
            // 
            // Key1
            // 
            this.Key1.Location = new System.Drawing.Point(36, 68);
            this.Key1.Mask = "AAAAAAAA";
            this.Key1.Name = "Key1";
            this.Key1.Size = new System.Drawing.Size(63, 20);
            this.Key1.TabIndex = 7;
            this.Key1.Text = "00000000";
            this.Key1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Key1.Value = ((uint)(0u));
            // 
            // L_GameVersion
            // 
            this.L_GameVersion.AutoSize = true;
            this.L_GameVersion.Location = new System.Drawing.Point(47, 39);
            this.L_GameVersion.Name = "L_GameVersion";
            this.L_GameVersion.Size = new System.Drawing.Size(38, 13);
            this.L_GameVersion.TabIndex = 11;
            this.L_GameVersion.Text = "Game:";
            // 
            // L_TSV
            // 
            this.L_TSV.AutoSize = true;
            this.L_TSV.Location = new System.Drawing.Point(54, 65);
            this.L_TSV.Name = "L_TSV";
            this.L_TSV.Size = new System.Drawing.Size(31, 13);
            this.L_TSV.TabIndex = 12;
            this.L_TSV.Text = "TSV:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Description:";
            // 
            // Description
            // 
            this.Description.Location = new System.Drawing.Point(91, 10);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(121, 20);
            this.Description.TabIndex = 14;
            // 
            // ProfileView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 281);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.L_TSV);
            this.Controls.Add(this.L_GameVersion);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TSV);
            this.Controls.Add(this.ShinyCharm);
            this.Controls.Add(this.Gameversion);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.B_Save);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ProfileView";
            this.Text = "Profile view";
            ((System.ComponentModel.ISupportInitialize)(this.TSV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox Gameversion;
        private System.Windows.Forms.CheckBox ShinyCharm;
        private Controls.HexMaskedTextBox Key3;
        private Controls.HexMaskedTextBox Key0;
        private Controls.HexMaskedTextBox Key1;
        private Controls.HexMaskedTextBox Key2;
        private System.Windows.Forms.NumericUpDown TSV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label L_GameVersion;
        private System.Windows.Forms.Label L_TSV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Description;
    }
}