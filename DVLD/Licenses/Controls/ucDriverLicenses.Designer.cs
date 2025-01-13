namespace DVLD.Licenses.Controls
{
    partial class ucDriverLicenses
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gBoxDriverLicenses = new System.Windows.Forms.GroupBox();
            this.lblNbrOfRecords = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbControlLocal = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvLocalLicensesHistory = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvInternationalLicenseHistory = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cmsShowLicenseHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsShowInternationalLicenseHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showInternationalLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gBoxDriverLicenses.SuspendLayout();
            this.tbControlLocal.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicensesHistory)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenseHistory)).BeginInit();
            this.cmsShowLicenseHistory.SuspendLayout();
            this.cmsShowInternationalLicenseHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBoxDriverLicenses
            // 
            this.gBoxDriverLicenses.Controls.Add(this.lblNbrOfRecords);
            this.gBoxDriverLicenses.Controls.Add(this.label3);
            this.gBoxDriverLicenses.Controls.Add(this.tbControlLocal);
            this.gBoxDriverLicenses.Location = new System.Drawing.Point(3, 8);
            this.gBoxDriverLicenses.Name = "gBoxDriverLicenses";
            this.gBoxDriverLicenses.Size = new System.Drawing.Size(1002, 296);
            this.gBoxDriverLicenses.TabIndex = 2;
            this.gBoxDriverLicenses.TabStop = false;
            this.gBoxDriverLicenses.Text = "Driver Licenses";
            // 
            // lblNbrOfRecords
            // 
            this.lblNbrOfRecords.AutoSize = true;
            this.lblNbrOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNbrOfRecords.Location = new System.Drawing.Point(109, 265);
            this.lblNbrOfRecords.Name = "lblNbrOfRecords";
            this.lblNbrOfRecords.Size = new System.Drawing.Size(28, 16);
            this.lblNbrOfRecords.TabIndex = 14;
            this.lblNbrOfRecords.Text = "???";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "#Records:";
            // 
            // tbControlLocal
            // 
            this.tbControlLocal.Controls.Add(this.tabPage1);
            this.tbControlLocal.Controls.Add(this.tabPage2);
            this.tbControlLocal.Location = new System.Drawing.Point(6, 28);
            this.tbControlLocal.Name = "tbControlLocal";
            this.tbControlLocal.SelectedIndex = 0;
            this.tbControlLocal.Size = new System.Drawing.Size(997, 268);
            this.tbControlLocal.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvLocalLicensesHistory);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(989, 242);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Local";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvLocalLicensesHistory
            // 
            this.dgvLocalLicensesHistory.AllowUserToAddRows = false;
            this.dgvLocalLicensesHistory.AllowUserToDeleteRows = false;
            this.dgvLocalLicensesHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocalLicensesHistory.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvLocalLicensesHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocalLicensesHistory.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLocalLicensesHistory.Location = new System.Drawing.Point(0, 35);
            this.dgvLocalLicensesHistory.Name = "dgvLocalLicensesHistory";
            this.dgvLocalLicensesHistory.ReadOnly = true;
            this.dgvLocalLicensesHistory.Size = new System.Drawing.Size(985, 170);
            this.dgvLocalLicensesHistory.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Local Licenses History";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvInternationalLicenseHistory);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(989, 242);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "International";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvInternationalLicenseHistory
            // 
            this.dgvInternationalLicenseHistory.AllowUserToAddRows = false;
            this.dgvInternationalLicenseHistory.AllowUserToDeleteRows = false;
            this.dgvInternationalLicenseHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInternationalLicenseHistory.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvInternationalLicenseHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicenseHistory.Location = new System.Drawing.Point(0, 32);
            this.dgvInternationalLicenseHistory.Name = "dgvInternationalLicenseHistory";
            this.dgvInternationalLicenseHistory.ReadOnly = true;
            this.dgvInternationalLicenseHistory.Size = new System.Drawing.Size(985, 170);
            this.dgvInternationalLicenseHistory.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "International Licenses History";
            // 
            // cmsShowLicenseHistory
            // 
            this.cmsShowLicenseHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseHistoryToolStripMenuItem});
            this.cmsShowLicenseHistory.Name = "cmsShowLicenseHistory";
            this.cmsShowLicenseHistory.Size = new System.Drawing.Size(203, 39);
            // 
            // showLicenseHistoryToolStripMenuItem
            // 
            this.showLicenseHistoryToolStripMenuItem.AutoSize = false;
            this.showLicenseHistoryToolStripMenuItem.Image = global::DVLD.Properties.Resources.License_View_32;
            this.showLicenseHistoryToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLicenseHistoryToolStripMenuItem.Name = "showLicenseHistoryToolStripMenuItem";
            this.showLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(220, 35);
            this.showLicenseHistoryToolStripMenuItem.Text = "Show License History";
            this.showLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showLicenseHistoryToolStripMenuItem_Click);
            // 
            // cmsShowInternationalLicenseHistory
            // 
            this.cmsShowInternationalLicenseHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInternationalLicenseHistoryToolStripMenuItem});
            this.cmsShowInternationalLicenseHistory.Name = "cmsShowInternationalLicenseHistory";
            this.cmsShowInternationalLicenseHistory.Size = new System.Drawing.Size(273, 39);
            // 
            // showInternationalLicenseHistoryToolStripMenuItem
            // 
            this.showInternationalLicenseHistoryToolStripMenuItem.AutoSize = false;
            this.showInternationalLicenseHistoryToolStripMenuItem.Image = global::DVLD.Properties.Resources.License_View_32;
            this.showInternationalLicenseHistoryToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showInternationalLicenseHistoryToolStripMenuItem.Name = "showInternationalLicenseHistoryToolStripMenuItem";
            this.showInternationalLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(220, 35);
            this.showInternationalLicenseHistoryToolStripMenuItem.Text = "Show International License History";
            this.showInternationalLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showInternationalLicenseHistoryToolStripMenuItem_Click);
            // 
            // ucDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gBoxDriverLicenses);
            this.Name = "ucDriverLicenses";
            this.Size = new System.Drawing.Size(1007, 312);
            this.gBoxDriverLicenses.ResumeLayout(false);
            this.gBoxDriverLicenses.PerformLayout();
            this.tbControlLocal.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicensesHistory)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenseHistory)).EndInit();
            this.cmsShowLicenseHistory.ResumeLayout(false);
            this.cmsShowInternationalLicenseHistory.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxDriverLicenses;
        private System.Windows.Forms.TabControl tbControlLocal;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvLocalLicensesHistory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvInternationalLicenseHistory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip cmsShowLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem showLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsShowInternationalLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem showInternationalLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.Label lblNbrOfRecords;
        private System.Windows.Forms.Label label3;
    }
}
