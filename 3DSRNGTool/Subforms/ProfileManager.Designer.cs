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
            ((System.ComponentModel.ISupportInitialize)(this.D_Profiles)).BeginInit();
            this.SuspendLayout();
            // 
            // D_Profiles
            // 
            this.D_Profiles.AllowUserToAddRows = false;
            this.D_Profiles.AllowUserToDeleteRows = false;
            this.D_Profiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.D_Profiles.Location = new System.Drawing.Point(3, 43);
            this.D_Profiles.Name = "D_Profiles";
            this.D_Profiles.ReadOnly = true;
            this.D_Profiles.Size = new System.Drawing.Size(240, 150);
            this.D_Profiles.TabIndex = 0;
            // 
            // ProfileManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.D_Profiles);
            this.Name = "ProfileManager";
            this.Text = "ProfileManager";
            ((System.ComponentModel.ISupportInitialize)(this.D_Profiles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView D_Profiles;
    }
}