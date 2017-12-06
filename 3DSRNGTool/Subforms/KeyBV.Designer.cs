namespace Pk3DSRNGTool
{
    partial class KeyBV
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
            this.Video1 = new System.Windows.Forms.TextBox();
            this.B_Dump = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.B_V1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.B_V2 = new System.Windows.Forms.Button();
            this.Video2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Video1
            // 
            this.Video1.Location = new System.Drawing.Point(56, 22);
            this.Video1.Name = "Video1";
            this.Video1.Size = new System.Drawing.Size(222, 20);
            this.Video1.TabIndex = 0;
            this.Video1.TextChanged += new System.EventHandler(this.CheckFile);
            // 
            // B_Dump
            // 
            this.B_Dump.Enabled = false;
            this.B_Dump.Location = new System.Drawing.Point(201, 146);
            this.B_Dump.Name = "B_Dump";
            this.B_Dump.Size = new System.Drawing.Size(75, 23);
            this.B_Dump.TabIndex = 2;
            this.B_Dump.Text = "Dump";
            this.B_Dump.UseVisualStyleBackColor = true;
            this.B_Dump.Click += new System.EventHandler(this.B_Dump_Click);
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.B_V1);
            this.panel1.Controls.Add(this.Video1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 70);
            this.panel1.TabIndex = 3;
            this.panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileDrop);
            this.panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.DropEnter);
            // 
            // B_V1
            // 
            this.B_V1.Location = new System.Drawing.Point(12, 22);
            this.B_V1.Name = "B_V1";
            this.B_V1.Size = new System.Drawing.Size(38, 23);
            this.B_V1.TabIndex = 6;
            this.B_V1.Text = "V1";
            this.B_V1.UseVisualStyleBackColor = true;
            this.B_V1.Click += new System.EventHandler(this.B_Open_Click);
            // 
            // panel2
            // 
            this.panel2.AllowDrop = true;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.B_V2);
            this.panel2.Controls.Add(this.Video2);
            this.panel2.Location = new System.Drawing.Point(0, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(285, 70);
            this.panel2.TabIndex = 4;
            this.panel2.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileDrop);
            this.panel2.DragEnter += new System.Windows.Forms.DragEventHandler(this.DropEnter);
            // 
            // B_V2
            // 
            this.B_V2.Location = new System.Drawing.Point(12, 22);
            this.B_V2.Name = "B_V2";
            this.B_V2.Size = new System.Drawing.Size(38, 23);
            this.B_V2.TabIndex = 5;
            this.B_V2.Text = "V2";
            this.B_V2.UseVisualStyleBackColor = true;
            this.B_V2.Click += new System.EventHandler(this.B_Open_Click);
            // 
            // Video2
            // 
            this.Video2.Location = new System.Drawing.Point(56, 24);
            this.Video2.Name = "Video2";
            this.Video2.Size = new System.Drawing.Size(222, 20);
            this.Video2.TabIndex = 0;
            this.Video2.TextChanged += new System.EventHandler(this.CheckFile);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Only 1 Pokemon";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "2 Pokemon: 2nd PKM from Video 1";
            // 
            // KeyBV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 182);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.B_Dump);
            this.MaximumSize = new System.Drawing.Size(300, 220);
            this.MinimumSize = new System.Drawing.Size(300, 220);
            this.Name = "KeyBV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "KeyBV";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TextBox Video1;
        private System.Windows.Forms.Button B_Dump;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox Video2;
        private System.Windows.Forms.Button B_V1;
        private System.Windows.Forms.Button B_V2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}