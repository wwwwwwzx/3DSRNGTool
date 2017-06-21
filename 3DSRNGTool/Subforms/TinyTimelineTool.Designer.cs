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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tiny3 = new Pk3DSRNGTool.Controls.HexNumericUpdown();
            this.label0 = new System.Windows.Forms.Label();
            this.tiny2 = new Pk3DSRNGTool.Controls.HexNumericUpdown();
            this.label1 = new System.Windows.Forms.Label();
            this.tiny1 = new Pk3DSRNGTool.Controls.HexNumericUpdown();
            this.tiny0 = new Pk3DSRNGTool.Controls.HexNumericUpdown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MainDGV = new System.Windows.Forms.DataGridView();
            this.tiny_MTFRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiny_index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiny_sync = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiny_slot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiny_high16bit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiny_rand100 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiny_state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frame1 = new System.Windows.Forms.NumericUpDown();
            this.B_Create = new System.Windows.Forms.Button();
            this.L_Mainframe = new System.Windows.Forms.Label();
            this.Frame_max = new System.Windows.Forms.NumericUpDown();
            this.B_update = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.GB_Cali = new System.Windows.Forms.GroupBox();
            this.Type2 = new System.Windows.Forms.ComboBox();
            this.Frame2 = new System.Windows.Forms.NumericUpDown();
            this.Type1 = new System.Windows.Forms.ComboBox();
            this.GB_Manu = new System.Windows.Forms.GroupBox();
            this.Shift = new System.Windows.Forms.NumericUpDown();
            this.Frame_J = new System.Windows.Forms.NumericUpDown();
            this.CMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.tiny3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiny2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiny1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiny0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Frame1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Frame_max)).BeginInit();
            this.GB_Cali.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Frame2)).BeginInit();
            this.GB_Manu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Shift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Frame_J)).BeginInit();
            this.CMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // tiny3
            // 
            this.tiny3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiny3.Hexadecimal = true;
            this.tiny3.Location = new System.Drawing.Point(50, 21);
            this.tiny3.Name = "tiny3";
            this.tiny3.Size = new System.Drawing.Size(78, 22);
            this.tiny3.TabIndex = 100;
            this.tiny3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label0
            // 
            this.label0.AutoSize = true;
            this.label0.Font = new System.Drawing.Font("Consolas", 9F);
            this.label0.Location = new System.Drawing.Point(22, 109);
            this.label0.Name = "label0";
            this.label0.Size = new System.Drawing.Size(28, 14);
            this.label0.TabIndex = 107;
            this.label0.Text = "[0]";
            // 
            // tiny2
            // 
            this.tiny2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiny2.Hexadecimal = true;
            this.tiny2.Location = new System.Drawing.Point(50, 49);
            this.tiny2.Name = "tiny2";
            this.tiny2.Size = new System.Drawing.Size(78, 22);
            this.tiny2.TabIndex = 101;
            this.tiny2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9F);
            this.label1.Location = new System.Drawing.Point(22, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 14);
            this.label1.TabIndex = 106;
            this.label1.Text = "[1]";
            // 
            // tiny1
            // 
            this.tiny1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiny1.Hexadecimal = true;
            this.tiny1.Location = new System.Drawing.Point(50, 77);
            this.tiny1.Name = "tiny1";
            this.tiny1.Size = new System.Drawing.Size(78, 22);
            this.tiny1.TabIndex = 102;
            this.tiny1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tiny0
            // 
            this.tiny0.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiny0.Hexadecimal = true;
            this.tiny0.Location = new System.Drawing.Point(50, 106);
            this.tiny0.Name = "tiny0";
            this.tiny0.Size = new System.Drawing.Size(78, 22);
            this.tiny0.TabIndex = 103;
            this.tiny0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9F);
            this.label2.Location = new System.Drawing.Point(22, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 14);
            this.label2.TabIndex = 105;
            this.label2.Text = "[2]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 9F);
            this.label3.Location = new System.Drawing.Point(22, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 14);
            this.label3.TabIndex = 104;
            this.label3.Text = "[3]";
            // 
            // MainDGV
            // 
            this.MainDGV.AllowUserToAddRows = false;
            this.MainDGV.AllowUserToDeleteRows = false;
            this.MainDGV.AllowUserToResizeColumns = false;
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
            this.MainDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tiny_MTFRange,
            this.tiny_index,
            this.tiny_sync,
            this.tiny_slot,
            this.tiny_high16bit,
            this.tiny_rand100,
            this.tiny_state});
            this.MainDGV.ContextMenuStrip = this.CMS;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MainDGV.DefaultCellStyle = dataGridViewCellStyle4;
            this.MainDGV.Location = new System.Drawing.Point(151, 12);
            this.MainDGV.Name = "MainDGV";
            this.MainDGV.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MainDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.MainDGV.RowHeadersWidth = 18;
            this.MainDGV.Size = new System.Drawing.Size(544, 476);
            this.MainDGV.TabIndex = 108;
            this.MainDGV.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.MainDGV_CellFormatting);
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
            this.tiny_index.Width = 50;
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
            // Frame1
            // 
            this.Frame1.AccessibleName = "";
            this.Frame1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Frame1.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.Frame1.Location = new System.Drawing.Point(13, 53);
            this.Frame1.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.Frame1.Name = "Frame1";
            this.Frame1.Size = new System.Drawing.Size(60, 22);
            this.Frame1.TabIndex = 109;
            this.Frame1.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // B_Create
            // 
            this.B_Create.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.B_Create.Location = new System.Drawing.Point(85, 465);
            this.B_Create.Name = "B_Create";
            this.B_Create.Size = new System.Drawing.Size(60, 23);
            this.B_Create.TabIndex = 110;
            this.B_Create.Text = "Create";
            this.B_Create.UseVisualStyleBackColor = true;
            this.B_Create.Click += new System.EventHandler(this.B_Create_Click);
            // 
            // L_Mainframe
            // 
            this.L_Mainframe.AutoSize = true;
            this.L_Mainframe.Font = new System.Drawing.Font("Consolas", 9F);
            this.L_Mainframe.Location = new System.Drawing.Point(12, 27);
            this.L_Mainframe.Name = "L_Mainframe";
            this.L_Mainframe.Size = new System.Drawing.Size(105, 14);
            this.L_Mainframe.TabIndex = 111;
            this.L_Mainframe.Text = "Main RNG Frame";
            // 
            // Frame_max
            // 
            this.Frame_max.AccessibleName = "";
            this.Frame_max.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Frame_max.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.Frame_max.Location = new System.Drawing.Point(15, 418);
            this.Frame_max.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.Frame_max.Name = "Frame_max";
            this.Frame_max.Size = new System.Drawing.Size(88, 22);
            this.Frame_max.TabIndex = 112;
            this.Frame_max.Value = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            // 
            // B_update
            // 
            this.B_update.Location = new System.Drawing.Point(40, 143);
            this.B_update.Name = "B_update";
            this.B_update.Size = new System.Drawing.Size(75, 23);
            this.B_update.TabIndex = 113;
            this.B_update.Text = "Update";
            this.B_update.UseVisualStyleBackColor = true;
            this.B_update.Click += new System.EventHandler(this.B_update_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 9F);
            this.label4.Location = new System.Drawing.Point(12, 392);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 14);
            this.label4.TabIndex = 114;
            this.label4.Text = "Target Frame";
            // 
            // GB_Cali
            // 
            this.GB_Cali.Controls.Add(this.Type2);
            this.GB_Cali.Controls.Add(this.Frame2);
            this.GB_Cali.Controls.Add(this.L_Mainframe);
            this.GB_Cali.Controls.Add(this.Frame1);
            this.GB_Cali.Location = new System.Drawing.Point(5, 172);
            this.GB_Cali.Name = "GB_Cali";
            this.GB_Cali.Size = new System.Drawing.Size(140, 113);
            this.GB_Cali.TabIndex = 115;
            this.GB_Cali.TabStop = false;
            this.GB_Cali.Text = "Calibration";
            // 
            // Type2
            // 
            this.Type2.FormattingEnabled = true;
            this.Type2.Location = new System.Drawing.Point(79, 81);
            this.Type2.Name = "Type2";
            this.Type2.Size = new System.Drawing.Size(44, 21);
            this.Type2.TabIndex = 116;
            // 
            // Frame2
            // 
            this.Frame2.AccessibleName = "";
            this.Frame2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Frame2.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.Frame2.Location = new System.Drawing.Point(13, 81);
            this.Frame2.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.Frame2.Name = "Frame2";
            this.Frame2.Size = new System.Drawing.Size(60, 22);
            this.Frame2.TabIndex = 112;
            this.Frame2.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // Type1
            // 
            this.Type1.FormattingEnabled = true;
            this.Type1.Location = new System.Drawing.Point(84, 226);
            this.Type1.Name = "Type1";
            this.Type1.Size = new System.Drawing.Size(44, 21);
            this.Type1.TabIndex = 112;
            // 
            // GB_Manu
            // 
            this.GB_Manu.Controls.Add(this.Shift);
            this.GB_Manu.Controls.Add(this.Frame_J);
            this.GB_Manu.Location = new System.Drawing.Point(5, 291);
            this.GB_Manu.Name = "GB_Manu";
            this.GB_Manu.Size = new System.Drawing.Size(140, 62);
            this.GB_Manu.TabIndex = 117;
            this.GB_Manu.TabStop = false;
            this.GB_Manu.Text = "Manipulate";
            // 
            // Shift
            // 
            this.Shift.AccessibleName = "";
            this.Shift.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Shift.Location = new System.Drawing.Point(79, 24);
            this.Shift.Name = "Shift";
            this.Shift.Size = new System.Drawing.Size(43, 22);
            this.Shift.TabIndex = 112;
            // 
            // Frame_J
            // 
            this.Frame_J.AccessibleName = "";
            this.Frame_J.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Frame_J.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.Frame_J.Location = new System.Drawing.Point(12, 24);
            this.Frame_J.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.Frame_J.Name = "Frame_J";
            this.Frame_J.Size = new System.Drawing.Size(60, 22);
            this.Frame_J.TabIndex = 109;
            this.Frame_J.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
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
            // TinyTimelineTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 500);
            this.Controls.Add(this.GB_Manu);
            this.Controls.Add(this.Type1);
            this.Controls.Add(this.GB_Cali);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.B_update);
            this.Controls.Add(this.Frame_max);
            this.Controls.Add(this.B_Create);
            this.Controls.Add(this.MainDGV);
            this.Controls.Add(this.tiny3);
            this.Controls.Add(this.label0);
            this.Controls.Add(this.tiny2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tiny1);
            this.Controls.Add(this.tiny0);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.MinimumSize = new System.Drawing.Size(720, 500);
            this.Name = "TinyTimelineTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tiny Timeline Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TinyTimelineTool_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.tiny3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiny2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiny1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiny0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Frame1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Frame_max)).EndInit();
            this.GB_Cali.ResumeLayout(false);
            this.GB_Cali.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Frame2)).EndInit();
            this.GB_Manu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Shift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Frame_J)).EndInit();
            this.CMS.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.HexNumericUpdown tiny3;
        private System.Windows.Forms.Label label0;
        private Controls.HexNumericUpdown tiny2;
        private System.Windows.Forms.Label label1;
        private Controls.HexNumericUpdown tiny1;
        private Controls.HexNumericUpdown tiny0;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView MainDGV;
        private System.Windows.Forms.NumericUpDown Frame1;
        private System.Windows.Forms.Button B_Create;
        private System.Windows.Forms.Label L_Mainframe;
        private System.Windows.Forms.NumericUpDown Frame_max;
        private System.Windows.Forms.Button B_update;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox GB_Cali;
        private System.Windows.Forms.ComboBox Type2;
        private System.Windows.Forms.NumericUpDown Frame2;
        private System.Windows.Forms.ComboBox Type1;
        private System.Windows.Forms.GroupBox GB_Manu;
        private System.Windows.Forms.NumericUpDown Shift;
        private System.Windows.Forms.NumericUpDown Frame_J;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiny_MTFRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiny_index;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiny_sync;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiny_slot;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiny_high16bit;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiny_rand100;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiny_state;
        private System.Windows.Forms.ContextMenuStrip CMS;
        private System.Windows.Forms.ToolStripMenuItem copyStatusToolStripMenuItem;
    }
}