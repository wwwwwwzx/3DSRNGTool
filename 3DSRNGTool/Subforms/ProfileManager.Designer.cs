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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.B_Add = new System.Windows.Forms.ToolStripButton();
            this.B_Edit = new System.Windows.Forms.ToolStripButton();
            this.B_Delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.B_up = new System.Windows.Forms.ToolStripButton();
            this.B_Down = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.D_Profiles)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // D_Profiles
            // 
            this.D_Profiles.AllowUserToAddRows = false;
            this.D_Profiles.AllowUserToDeleteRows = false;
            this.D_Profiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.D_Profiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.D_Profiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.D_Profiles.Location = new System.Drawing.Point(0, 25);
            this.D_Profiles.MultiSelect = false;
            this.D_Profiles.Name = "D_Profiles";
            this.D_Profiles.ReadOnly = true;
            this.D_Profiles.RowHeadersWidth = 18;
            this.D_Profiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.D_Profiles.Size = new System.Drawing.Size(560, 236);
            this.D_Profiles.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.B_Add,
            this.B_Edit,
            this.B_Delete,
            this.toolStripSeparator1,
            this.B_up,
            this.B_Down});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.ShowItemToolTips = false;
            this.toolStrip1.Size = new System.Drawing.Size(560, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // B_Add
            // 
            this.B_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.B_Add.Image = global::Pk3DSRNGTool.Properties.Resources.Add;
            this.B_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.B_Add.Name = "B_Add";
            this.B_Add.Size = new System.Drawing.Size(23, 22);
            this.B_Add.Text = "Add";
            this.B_Add.Click += new System.EventHandler(this.B_Add_Click);
            // 
            // B_Edit
            // 
            this.B_Edit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.B_Edit.Image = global::Pk3DSRNGTool.Properties.Resources.Edit;
            this.B_Edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.B_Edit.Name = "B_Edit";
            this.B_Edit.Size = new System.Drawing.Size(23, 22);
            this.B_Edit.Text = "Edit";
            this.B_Edit.Click += new System.EventHandler(this.B_Edit_Click);
            // 
            // B_Delete
            // 
            this.B_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.B_Delete.Image = global::Pk3DSRNGTool.Properties.Resources.Delete;
            this.B_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.B_Delete.Name = "B_Delete";
            this.B_Delete.Size = new System.Drawing.Size(23, 22);
            this.B_Delete.Text = "Remove";
            this.B_Delete.Click += new System.EventHandler(this.B_Remove_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // B_up
            // 
            this.B_up.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.B_up.Image = global::Pk3DSRNGTool.Properties.Resources.Arrow_up;
            this.B_up.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.B_up.Name = "B_up";
            this.B_up.Size = new System.Drawing.Size(23, 22);
            this.B_up.Text = "Move up";
            this.B_up.Click += new System.EventHandler(this.B_up_Click);
            // 
            // B_Down
            // 
            this.B_Down.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.B_Down.Image = global::Pk3DSRNGTool.Properties.Resources.Arrow_down;
            this.B_Down.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.B_Down.Name = "B_Down";
            this.B_Down.Size = new System.Drawing.Size(23, 22);
            this.B_Down.Text = "Move down";
            this.B_Down.Click += new System.EventHandler(this.B_Down_Click);
            // 
            // ProfileManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 261);
            this.Controls.Add(this.D_Profiles);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ProfileManager";
            this.Text = "Profile Manager";
            ((System.ComponentModel.ISupportInitialize)(this.D_Profiles)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView D_Profiles;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton B_Add;
        private System.Windows.Forms.ToolStripButton B_Edit;
        private System.Windows.Forms.ToolStripButton B_Delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton B_up;
        private System.Windows.Forms.ToolStripButton B_Down;
    }
}