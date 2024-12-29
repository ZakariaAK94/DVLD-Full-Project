namespace DVLD.Licenses
{
    partial class frmListDetainedLicenses
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvListDetainedLicenses = new System.Windows.Forms.DataGridView();
            this.cmsApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmShowPersonDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmShowLicenseDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmReleaseDetainedLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.txtBoxFilterBy = new System.Windows.Forms.TextBox();
            this.cmbBoxFilterBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNbrOfDetainedLicesnes = new System.Windows.Forms.Label();
            this.lbl1frmManagePeople = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReleaseDetainedLicense = new System.Windows.Forms.Button();
            this.btnAddNewDetainLicense = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbIsRelease = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListDetainedLicenses)).BeginInit();
            this.cmsApplications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(405, 121);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "List Detained Licenses";
            // 
            // dgvListDetainedLicenses
            // 
            this.dgvListDetainedLicenses.AllowUserToAddRows = false;
            this.dgvListDetainedLicenses.AllowUserToDeleteRows = false;
            this.dgvListDetainedLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListDetainedLicenses.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvListDetainedLicenses.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvListDetainedLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListDetainedLicenses.ContextMenuStrip = this.cmsApplications;
            this.dgvListDetainedLicenses.Location = new System.Drawing.Point(10, 208);
            this.dgvListDetainedLicenses.Name = "dgvListDetainedLicenses";
            this.dgvListDetainedLicenses.ReadOnly = true;
            this.dgvListDetainedLicenses.Size = new System.Drawing.Size(1200, 255);
            this.dgvListDetainedLicenses.TabIndex = 4;
            // 
            // cmsApplications
            // 
            this.cmsApplications.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.cmsApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShowPersonDetails,
            this.tsmShowLicenseDetails,
            this.tsmShowPersonLicenseHistory,
            this.toolStripMenuItem5,
            this.tsmReleaseDetainedLicense});
            this.cmsApplications.Name = "contextMenuStrip1";
            this.cmsApplications.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsApplications.Size = new System.Drawing.Size(242, 150);
            this.cmsApplications.Opening += new System.ComponentModel.CancelEventHandler(this.cmsApplications_Opening);
            // 
            // tsmShowPersonDetails
            // 
            this.tsmShowPersonDetails.AutoSize = false;
            this.tsmShowPersonDetails.Image = global::DVLD.Properties.Resources.PersonDetails_32;
            this.tsmShowPersonDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmShowPersonDetails.Name = "tsmShowPersonDetails";
            this.tsmShowPersonDetails.Size = new System.Drawing.Size(230, 35);
            this.tsmShowPersonDetails.Text = "Show Person Details";
            this.tsmShowPersonDetails.Click += new System.EventHandler(this.tsmShowPersonDetails_Click);
            // 
            // tsmShowLicenseDetails
            // 
            this.tsmShowLicenseDetails.AutoSize = false;
            this.tsmShowLicenseDetails.Image = global::DVLD.Properties.Resources.License_View_32;
            this.tsmShowLicenseDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmShowLicenseDetails.Name = "tsmShowLicenseDetails";
            this.tsmShowLicenseDetails.Size = new System.Drawing.Size(230, 35);
            this.tsmShowLicenseDetails.Text = "Show License Details";
            this.tsmShowLicenseDetails.Click += new System.EventHandler(this.tsmShowLicenseDetails_Click);
            // 
            // tsmShowPersonLicenseHistory
            // 
            this.tsmShowPersonLicenseHistory.AutoSize = false;
            this.tsmShowPersonLicenseHistory.Image = global::DVLD.Properties.Resources.PersonLicenseHistory_32;
            this.tsmShowPersonLicenseHistory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmShowPersonLicenseHistory.Name = "tsmShowPersonLicenseHistory";
            this.tsmShowPersonLicenseHistory.Size = new System.Drawing.Size(230, 35);
            this.tsmShowPersonLicenseHistory.Text = "Show Person License History";
            this.tsmShowPersonLicenseHistory.Click += new System.EventHandler(this.tsmShowPersonLicenseHistory_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(238, 6);
            // 
            // tsmReleaseDetainedLicense
            // 
            this.tsmReleaseDetainedLicense.AutoSize = false;
            this.tsmReleaseDetainedLicense.Enabled = false;
            this.tsmReleaseDetainedLicense.Image = global::DVLD.Properties.Resources.Release_Detained_License_32;
            this.tsmReleaseDetainedLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmReleaseDetainedLicense.Name = "tsmReleaseDetainedLicense";
            this.tsmReleaseDetainedLicense.Size = new System.Drawing.Size(230, 35);
            this.tsmReleaseDetainedLicense.Text = "Release Detained License";
            this.tsmReleaseDetainedLicense.Click += new System.EventHandler(this.tsmReleaseDetainedLicense_Click);
            // 
            // txtBoxFilterBy
            // 
            this.txtBoxFilterBy.Location = new System.Drawing.Point(248, 176);
            this.txtBoxFilterBy.Name = "txtBoxFilterBy";
            this.txtBoxFilterBy.Size = new System.Drawing.Size(149, 20);
            this.txtBoxFilterBy.TabIndex = 12;
            this.txtBoxFilterBy.Visible = false;
            this.txtBoxFilterBy.TextChanged += new System.EventHandler(this.txtBoxFilterBy_TextChanged_1);
            this.txtBoxFilterBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxFilterBy_KeyPress);
            // 
            // cmbBoxFilterBy
            // 
            this.cmbBoxFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxFilterBy.FormattingEnabled = true;
            this.cmbBoxFilterBy.Items.AddRange(new object[] {
            "None",
            "Detain ID",
            "Is Released",
            "National No",
            "Full Name",
            "Release Application ID"});
            this.cmbBoxFilterBy.Location = new System.Drawing.Point(105, 175);
            this.cmbBoxFilterBy.Name = "cmbBoxFilterBy";
            this.cmbBoxFilterBy.Size = new System.Drawing.Size(121, 21);
            this.cmbBoxFilterBy.TabIndex = 11;
            this.cmbBoxFilterBy.SelectedIndexChanged += new System.EventHandler(this.cmbBoxFilterBy_SelectedIndexChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Filter By:";
            // 
            // lblNbrOfDetainedLicesnes
            // 
            this.lblNbrOfDetainedLicesnes.AutoSize = true;
            this.lblNbrOfDetainedLicesnes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNbrOfDetainedLicesnes.Location = new System.Drawing.Point(102, 479);
            this.lblNbrOfDetainedLicesnes.Name = "lblNbrOfDetainedLicesnes";
            this.lblNbrOfDetainedLicesnes.Size = new System.Drawing.Size(45, 20);
            this.lblNbrOfDetainedLicesnes.TabIndex = 15;
            this.lblNbrOfDetainedLicesnes.Text = "????";
            // 
            // lbl1frmManagePeople
            // 
            this.lbl1frmManagePeople.AutoSize = true;
            this.lbl1frmManagePeople.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1frmManagePeople.Location = new System.Drawing.Point(20, 479);
            this.lbl1frmManagePeople.Name = "lbl1frmManagePeople";
            this.lbl1frmManagePeople.Size = new System.Drawing.Size(78, 20);
            this.lbl1frmManagePeople.TabIndex = 14;
            this.lbl1frmManagePeople.Text = "# Record:";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(1035, 469);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(111, 46);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReleaseDetainedLicense
            // 
            this.btnReleaseDetainedLicense.Image = global::DVLD.Properties.Resources.Release_Detained_License_32;
            this.btnReleaseDetainedLicense.Location = new System.Drawing.Point(1035, 128);
            this.btnReleaseDetainedLicense.Name = "btnReleaseDetainedLicense";
            this.btnReleaseDetainedLicense.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnReleaseDetainedLicense.Size = new System.Drawing.Size(65, 65);
            this.btnReleaseDetainedLicense.TabIndex = 17;
            this.btnReleaseDetainedLicense.UseVisualStyleBackColor = true;
            this.btnReleaseDetainedLicense.Click += new System.EventHandler(this.btnReleaseDetainedLicense_Click);
            // 
            // btnAddNewDetainLicense
            // 
            this.btnAddNewDetainLicense.Image = global::DVLD.Properties.Resources.Detain_48;
            this.btnAddNewDetainLicense.Location = new System.Drawing.Point(1115, 128);
            this.btnAddNewDetainLicense.Name = "btnAddNewDetainLicense";
            this.btnAddNewDetainLicense.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAddNewDetainLicense.Size = new System.Drawing.Size(65, 65);
            this.btnAddNewDetainLicense.TabIndex = 13;
            this.btnAddNewDetainLicense.UseVisualStyleBackColor = true;
            this.btnAddNewDetainLicense.Click += new System.EventHandler(this.btnAddNewDetainLicense_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Detain_64;
            this.pictureBox1.Location = new System.Drawing.Point(441, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // cmbIsRelease
            // 
            this.cmbIsRelease.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsRelease.FormattingEnabled = true;
            this.cmbIsRelease.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cmbIsRelease.Location = new System.Drawing.Point(248, 175);
            this.cmbIsRelease.Name = "cmbIsRelease";
            this.cmbIsRelease.Size = new System.Drawing.Size(121, 21);
            this.cmbIsRelease.TabIndex = 18;
            this.cmbIsRelease.Visible = false;
            this.cmbIsRelease.SelectedIndexChanged += new System.EventHandler(this.cmbIsRelease_SelectedIndexChanged);
            // 
            // frmListDetainedLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 526);
            this.Controls.Add(this.cmbIsRelease);
            this.Controls.Add(this.btnReleaseDetainedLicense);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblNbrOfDetainedLicesnes);
            this.Controls.Add(this.lbl1frmManagePeople);
            this.Controls.Add(this.btnAddNewDetainLicense);
            this.Controls.Add(this.txtBoxFilterBy);
            this.Controls.Add(this.cmbBoxFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvListDetainedLicenses);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmListDetainedLicenses";
            this.Text = "List Detained Licenses";
            this.Load += new System.EventHandler(this.frmListDetainedLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListDetainedLicenses)).EndInit();
            this.cmsApplications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvListDetainedLicenses;
        private System.Windows.Forms.TextBox txtBoxFilterBy;
        private System.Windows.Forms.ComboBox cmbBoxFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddNewDetainLicense;
        private System.Windows.Forms.Label lblNbrOfDetainedLicesnes;
        private System.Windows.Forms.Label lbl1frmManagePeople;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip cmsApplications;
        private System.Windows.Forms.ToolStripMenuItem tsmShowPersonDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmShowLicenseDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem tsmReleaseDetainedLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmShowPersonLicenseHistory;
        private System.Windows.Forms.Button btnReleaseDetainedLicense;
        private System.Windows.Forms.ComboBox cmbIsRelease;
    }
}