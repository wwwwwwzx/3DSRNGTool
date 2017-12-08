namespace Pk3DSRNGTool
{
    partial class IVTemplate
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
            this.InputBox = new System.Windows.Forms.TextBox();
            this.IVSpread = new System.Windows.Forms.ListBox();
            this.B_Add = new System.Windows.Forms.Button();
            this.B_Remove = new System.Windows.Forms.Button();
            this.B_Male = new System.Windows.Forms.Button();
            this.B_Female = new System.Windows.Forms.Button();
            this.B_Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InputBox
            // 
            this.InputBox.Location = new System.Drawing.Point(35, 26);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(199, 20);
            this.InputBox.TabIndex = 0;
            this.InputBox.Text = "SpreadName = 1,2,3,4,5,6";
            // 
            // IVSpread
            // 
            this.IVSpread.FormattingEnabled = true;
            this.IVSpread.Location = new System.Drawing.Point(35, 94);
            this.IVSpread.Name = "IVSpread";
            this.IVSpread.Size = new System.Drawing.Size(199, 212);
            this.IVSpread.TabIndex = 1;
            // 
            // B_Add
            // 
            this.B_Add.Image = global::Pk3DSRNGTool.Properties.Resources.Add;
            this.B_Add.Location = new System.Drawing.Point(138, 59);
            this.B_Add.Name = "B_Add";
            this.B_Add.Size = new System.Drawing.Size(26, 26);
            this.B_Add.TabIndex = 2;
            this.B_Add.UseVisualStyleBackColor = true;
            this.B_Add.Click += new System.EventHandler(this.B_Add_Click);
            // 
            // B_Remove
            // 
            this.B_Remove.Image = global::Pk3DSRNGTool.Properties.Resources.Delete;
            this.B_Remove.Location = new System.Drawing.Point(170, 59);
            this.B_Remove.Name = "B_Remove";
            this.B_Remove.Size = new System.Drawing.Size(26, 26);
            this.B_Remove.TabIndex = 3;
            this.B_Remove.UseVisualStyleBackColor = true;
            this.B_Remove.Click += new System.EventHandler(this.B_Remove_Click);
            // 
            // B_Male
            // 
            this.B_Male.Location = new System.Drawing.Point(35, 320);
            this.B_Male.Name = "B_Male";
            this.B_Male.Size = new System.Drawing.Size(88, 23);
            this.B_Male.TabIndex = 4;
            this.B_Male.Text = "Set as Male";
            this.B_Male.UseVisualStyleBackColor = true;
            this.B_Male.Click += new System.EventHandler(this.B_Male_Click);
            // 
            // B_Female
            // 
            this.B_Female.Location = new System.Drawing.Point(146, 320);
            this.B_Female.Name = "B_Female";
            this.B_Female.Size = new System.Drawing.Size(88, 23);
            this.B_Female.TabIndex = 5;
            this.B_Female.Text = "Set as Female";
            this.B_Female.UseVisualStyleBackColor = true;
            this.B_Female.Click += new System.EventHandler(this.B_Female_Click);
            // 
            // B_Save
            // 
            this.B_Save.Image = global::Pk3DSRNGTool.Properties.Resources.Save;
            this.B_Save.Location = new System.Drawing.Point(202, 59);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(26, 26);
            this.B_Save.TabIndex = 6;
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click);
            // 
            // IVTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 362);
            this.Controls.Add(this.B_Save);
            this.Controls.Add(this.B_Female);
            this.Controls.Add(this.B_Male);
            this.Controls.Add(this.B_Remove);
            this.Controls.Add(this.B_Add);
            this.Controls.Add(this.IVSpread);
            this.Controls.Add(this.InputBox);
            this.MaximumSize = new System.Drawing.Size(285, 400);
            this.MinimumSize = new System.Drawing.Size(285, 400);
            this.Name = "IVTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "IV Spread Template";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InputBox;
        private System.Windows.Forms.ListBox IVSpread;
        private System.Windows.Forms.Button B_Add;
        private System.Windows.Forms.Button B_Remove;
        private System.Windows.Forms.Button B_Male;
        private System.Windows.Forms.Button B_Female;
        private System.Windows.Forms.Button B_Save;
    }
}