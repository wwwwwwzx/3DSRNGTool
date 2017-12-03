namespace Pk3DSRNGTool.Subforms
{
    partial class ProfileManager
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
            this.D_Profiles = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.profilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.M_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.M_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.M_Remove = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.D_Profiles)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // D_Profiles
            // 
            this.D_Profiles.AllowUserToAddRows = false;
            this.D_Profiles.AllowUserToDeleteRows = false;
            this.D_Profiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.D_Profiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.D_Profiles.Location = new System.Drawing.Point(0, 24);
            this.D_Profiles.Name = "D_Profiles";
            this.D_Profiles.ReadOnly = true;
            this.D_Profiles.Size = new System.Drawing.Size(560, 237);
            this.D_Profiles.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profilesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(560, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // profilesToolStripMenuItem
            // 
            this.profilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.M_Add,
            this.M_Edit,
            this.M_Remove});
            this.profilesToolStripMenuItem.Name = "profilesToolStripMenuItem";
            this.profilesToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.profilesToolStripMenuItem.Text = "Profiles";
            // 
            // M_Add
            // 
            this.M_Add.Name = "M_Add";
            this.M_Add.Size = new System.Drawing.Size(152, 22);
            this.M_Add.Text = "Add";
            this.M_Add.Click += new System.EventHandler(this.M_Add_Click);
            // 
            // M_Edit
            // 
            this.M_Edit.Name = "M_Edit";
            this.M_Edit.Size = new System.Drawing.Size(152, 22);
            this.M_Edit.Text = "Edit";
            this.M_Edit.Click += new System.EventHandler(this.M_Edit_Click);
            // 
            // M_Remove
            // 
            this.M_Remove.Name = "M_Remove";
            this.M_Remove.Size = new System.Drawing.Size(152, 22);
            this.M_Remove.Text = "Remove";
            this.M_Remove.Click += new System.EventHandler(this.M_Remove_Click);
            // 
            // ProfileManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 261);
            this.Controls.Add(this.D_Profiles);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ProfileManager";
            this.Text = "Profile Manager";
            ((System.ComponentModel.ISupportInitialize)(this.D_Profiles)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView D_Profiles;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem profilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem M_Add;
        private System.Windows.Forms.ToolStripMenuItem M_Edit;
        private System.Windows.Forms.ToolStripMenuItem M_Remove;
    }
}