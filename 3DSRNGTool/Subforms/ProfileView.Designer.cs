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
            this.hexMaskedTextBox1 = new Pk3DSRNGTool.Controls.HexMaskedTextBox();
            this.hexMaskedTextBox2 = new Pk3DSRNGTool.Controls.HexMaskedTextBox();
            this.hexMaskedTextBox3 = new Pk3DSRNGTool.Controls.HexMaskedTextBox();
            this.hexMaskedTextBox4 = new Pk3DSRNGTool.Controls.HexMaskedTextBox();
            this.TSV = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.L_GameVersion = new System.Windows.Forms.Label();
            this.L_TSV = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TSV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // B_Save
            // 
            this.B_Save.Location = new System.Drawing.Point(39, 223);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(75, 23);
            this.B_Save.TabIndex = 0;
            this.B_Save.Text = "Save";
            this.B_Save.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(120, 223);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
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
            this.Gameversion.Location = new System.Drawing.Point(79, 11);
            this.Gameversion.Name = "Gameversion";
            this.Gameversion.Size = new System.Drawing.Size(121, 21);
            this.Gameversion.TabIndex = 2;
            // 
            // ShinyCharm
            // 
            this.ShinyCharm.AutoSize = true;
            this.ShinyCharm.Location = new System.Drawing.Point(79, 64);
            this.ShinyCharm.Name = "ShinyCharm";
            this.ShinyCharm.Size = new System.Drawing.Size(82, 17);
            this.ShinyCharm.TabIndex = 4;
            this.ShinyCharm.Text = "ShinyCharm";
            this.ShinyCharm.UseVisualStyleBackColor = true;
            // 
            // hexMaskedTextBox1
            // 
            this.hexMaskedTextBox1.Location = new System.Drawing.Point(36, 16);
            this.hexMaskedTextBox1.Mask = "AAAAAAAA";
            this.hexMaskedTextBox1.Name = "hexMaskedTextBox1";
            this.hexMaskedTextBox1.Size = new System.Drawing.Size(63, 20);
            this.hexMaskedTextBox1.TabIndex = 5;
            this.hexMaskedTextBox1.Text = "00000000";
            this.hexMaskedTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.hexMaskedTextBox1.Value = ((uint)(0u));
            // 
            // hexMaskedTextBox2
            // 
            this.hexMaskedTextBox2.Location = new System.Drawing.Point(36, 94);
            this.hexMaskedTextBox2.Mask = "AAAAAAAA";
            this.hexMaskedTextBox2.Name = "hexMaskedTextBox2";
            this.hexMaskedTextBox2.Size = new System.Drawing.Size(63, 20);
            this.hexMaskedTextBox2.TabIndex = 6;
            this.hexMaskedTextBox2.Text = "00000000";
            this.hexMaskedTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.hexMaskedTextBox2.Value = ((uint)(0u));
            // 
            // hexMaskedTextBox3
            // 
            this.hexMaskedTextBox3.Location = new System.Drawing.Point(36, 68);
            this.hexMaskedTextBox3.Mask = "AAAAAAAA";
            this.hexMaskedTextBox3.Name = "hexMaskedTextBox3";
            this.hexMaskedTextBox3.Size = new System.Drawing.Size(63, 20);
            this.hexMaskedTextBox3.TabIndex = 7;
            this.hexMaskedTextBox3.Text = "00000000";
            this.hexMaskedTextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.hexMaskedTextBox3.Value = ((uint)(0u));
            // 
            // hexMaskedTextBox4
            // 
            this.hexMaskedTextBox4.Location = new System.Drawing.Point(36, 42);
            this.hexMaskedTextBox4.Mask = "AAAAAAAA";
            this.hexMaskedTextBox4.Name = "hexMaskedTextBox4";
            this.hexMaskedTextBox4.Size = new System.Drawing.Size(63, 20);
            this.hexMaskedTextBox4.TabIndex = 8;
            this.hexMaskedTextBox4.Text = "00000000";
            this.hexMaskedTextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.hexMaskedTextBox4.Value = ((uint)(0u));
            // 
            // TSV
            // 
            this.TSV.Location = new System.Drawing.Point(79, 38);
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
            this.groupBox1.Controls.Add(this.hexMaskedTextBox1);
            this.groupBox1.Controls.Add(this.hexMaskedTextBox2);
            this.groupBox1.Controls.Add(this.hexMaskedTextBox4);
            this.groupBox1.Controls.Add(this.hexMaskedTextBox3);
            this.groupBox1.Location = new System.Drawing.Point(62, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(110, 130);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Egg Seeds";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "[2]";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "[0]";
            // 
            // L_GameVersion
            // 
            this.L_GameVersion.AutoSize = true;
            this.L_GameVersion.Location = new System.Drawing.Point(35, 14);
            this.L_GameVersion.Name = "L_GameVersion";
            this.L_GameVersion.Size = new System.Drawing.Size(38, 13);
            this.L_GameVersion.TabIndex = 11;
            this.L_GameVersion.Text = "Game:";
            // 
            // L_TSV
            // 
            this.L_TSV.AutoSize = true;
            this.L_TSV.Location = new System.Drawing.Point(42, 40);
            this.L_TSV.Name = "L_TSV";
            this.L_TSV.Size = new System.Drawing.Size(31, 13);
            this.L_TSV.TabIndex = 12;
            this.L_TSV.Text = "TSV:";
            // 
            // ProfileView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 261);
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
        private Controls.HexMaskedTextBox hexMaskedTextBox1;
        private Controls.HexMaskedTextBox hexMaskedTextBox2;
        private Controls.HexMaskedTextBox hexMaskedTextBox3;
        private Controls.HexMaskedTextBox hexMaskedTextBox4;
        private System.Windows.Forms.NumericUpDown TSV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label L_GameVersion;
        private System.Windows.Forms.Label L_TSV;
    }
}