namespace DVLD.Applications
{
    partial class frmInternationalDrivingLicenseApplications
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
            this.dgvInterDrivingLicenseApplications = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmShowPersonDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmShowLicenseDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.txtBoxFilterBy = new System.Windows.Forms.TextBox();
            this.cmbBoxFilterBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNbrOfInternationalDrivingLicesneApplications = new System.Windows.Forms.Label();
            this.lbl1frmManagePeople = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddNewInternationalDrivingLicenseApplication = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cmbBoxIsActive = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInterDrivingLicenseApplications)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(420, 149);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "International Driving License Applications";
            // 
            // dgvInterDrivingLicenseApplications
            // 
            this.dgvInterDrivingLicenseApplications.AllowUserToAddRows = false;
            this.dgvInterDrivingLicenseApplications.AllowUserToDeleteRows = false;
            this.dgvInterDrivingLicenseApplications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInterDrivingLicenseApplications.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvInterDrivingLicenseApplications.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvInterDrivingLicenseApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInterDrivingLicenseApplications.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvInterDrivingLicenseApplications.Location = new System.Drawing.Point(10, 236);
            this.dgvInterDrivingLicenseApplications.Name = "dgvInterDrivingLicenseApplications";
            this.dgvInterDrivingLicenseApplications.ReadOnly = true;
            this.dgvInterDrivingLicenseApplications.Size = new System.Drawing.Size(1050, 250);
            this.dgvInterDrivingLicenseApplications.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShowPersonDetails,
            this.tsmShowLicenseDetails,
            this.tsmShowPersonLicenseHistory});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(226, 70);
            // 
            // tsmShowPersonDetails
            // 
            this.tsmShowPersonDetails.Name = "tsmShowPersonDetails";
            this.tsmShowPersonDetails.Size = new System.Drawing.Size(225, 22);
            this.tsmShowPersonDetails.Text = "Show Person Details";
            this.tsmShowPersonDetails.Click += new System.EventHandler(this.tsmShowPersonDetails_Click);
            // 
            // tsmShowLicenseDetails
            // 
            this.tsmShowLicenseDetails.Name = "tsmShowLicenseDetails";
            this.tsmShowLicenseDetails.Size = new System.Drawing.Size(225, 22);
            this.tsmShowLicenseDetails.Text = "Show License Details";
            this.tsmShowLicenseDetails.Click += new System.EventHandler(this.tsmShowLicenseDetails_Click);
            // 
            // tsmShowPersonLicenseHistory
            // 
            this.tsmShowPersonLicenseHistory.Name = "tsmShowPersonLicenseHistory";
            this.tsmShowPersonLicenseHistory.Size = new System.Drawing.Size(225, 22);
            this.tsmShowPersonLicenseHistory.Text = "Show Person License History";
            this.tsmShowPersonLicenseHistory.Click += new System.EventHandler(this.tsmShowPersonLicenseHistory_Click);
            // 
            // txtBoxFilterBy
            // 
            this.txtBoxFilterBy.Location = new System.Drawing.Point(247, 200);
            this.txtBoxFilterBy.Name = "txtBoxFilterBy";
            this.txtBoxFilterBy.Size = new System.Drawing.Size(149, 20);
            this.txtBoxFilterBy.TabIndex = 12;
            this.txtBoxFilterBy.Visible = false;
            this.txtBoxFilterBy.TextChanged += new System.EventHandler(this.txtBoxFilterBy_TextChanged);
            this.txtBoxFilterBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxFilterBy_KeyPress);
            // 
            // cmbBoxFilterBy
            // 
            this.cmbBoxFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxFilterBy.FormattingEnabled = true;
            this.cmbBoxFilterBy.Items.AddRange(new object[] {
            "None",
            "International License ID",
            "Application ID",
            "Driver ID",
            "Local License ID",
            "Is Active"});
            this.cmbBoxFilterBy.Location = new System.Drawing.Point(104, 199);
            this.cmbBoxFilterBy.Name = "cmbBoxFilterBy";
            this.cmbBoxFilterBy.Size = new System.Drawing.Size(121, 21);
            this.cmbBoxFilterBy.TabIndex = 11;
            this.cmbBoxFilterBy.SelectedIndexChanged += new System.EventHandler(this.cmbBoxFilterBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Filter By:";
            // 
            // lblNbrOfInternationalDrivingLicesneApplications
            // 
            this.lblNbrOfInternationalDrivingLicesneApplications.AutoSize = true;
            this.lblNbrOfInternationalDrivingLicesneApplications.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNbrOfInternationalDrivingLicesneApplications.Location = new System.Drawing.Point(104, 502);
            this.lblNbrOfInternationalDrivingLicesneApplications.Name = "lblNbrOfInternationalDrivingLicesneApplications";
            this.lblNbrOfInternationalDrivingLicesneApplications.Size = new System.Drawing.Size(45, 20);
            this.lblNbrOfInternationalDrivingLicesneApplications.TabIndex = 15;
            this.lblNbrOfInternationalDrivingLicesneApplications.Text = "????";
            // 
            // lbl1frmManagePeople
            // 
            this.lbl1frmManagePeople.AutoSize = true;
            this.lbl1frmManagePeople.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1frmManagePeople.Location = new System.Drawing.Point(22, 502);
            this.lbl1frmManagePeople.Name = "lbl1frmManagePeople";
            this.lbl1frmManagePeople.Size = new System.Drawing.Size(78, 20);
            this.lbl1frmManagePeople.TabIndex = 14;
            this.lbl1frmManagePeople.Text = "# Record:";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(897, 496);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 46);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // btnAddNewInternationalDrivingLicenseApplication
            // 
            this.btnAddNewInternationalDrivingLicenseApplication.Image = global::DVLD.Properties.Resources.New_Application_64;
            this.btnAddNewInternationalDrivingLicenseApplication.Location = new System.Drawing.Point(980, 165);
            this.btnAddNewInternationalDrivingLicenseApplication.Name = "btnAddNewInternationalDrivingLicenseApplication";
            this.btnAddNewInternationalDrivingLicenseApplication.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAddNewInternationalDrivingLicenseApplication.Size = new System.Drawing.Size(65, 65);
            this.btnAddNewInternationalDrivingLicenseApplication.TabIndex = 13;
            this.btnAddNewInternationalDrivingLicenseApplication.UseVisualStyleBackColor = true;
            this.btnAddNewInternationalDrivingLicenseApplication.Click += new System.EventHandler(this.btnAddNewInternationalDrivingLicenseApplication_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Applications;
            this.pictureBox1.Location = new System.Drawing.Point(434, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(236, 134);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD.Properties.Resources.International_32;
            this.pictureBox2.Location = new System.Drawing.Point(642, 51);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(39, 36);
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // cmbBoxIsActive
            // 
            this.cmbBoxIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxIsActive.FormattingEnabled = true;
            this.cmbBoxIsActive.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cmbBoxIsActive.Location = new System.Drawing.Point(247, 199);
            this.cmbBoxIsActive.Name = "cmbBoxIsActive";
            this.cmbBoxIsActive.Size = new System.Drawing.Size(121, 21);
            this.cmbBoxIsActive.TabIndex = 18;
            this.cmbBoxIsActive.SelectedIndexChanged += new System.EventHandler(this.cmbBoxIsActive_SelectedIndexChanged);
            // 
            // frmInternationalDrivingLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.cmbBoxIsActive);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblNbrOfInternationalDrivingLicesneApplications);
            this.Controls.Add(this.lbl1frmManagePeople);
            this.Controls.Add(this.btnAddNewInternationalDrivingLicenseApplication);
            this.Controls.Add(this.txtBoxFilterBy);
            this.Controls.Add(this.cmbBoxFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvInterDrivingLicenseApplications);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmInternationalDrivingLicenseApplications";
            this.Text = "Internaional Driving License Application";
            this.Load += new System.EventHandler(this.frmInternationalDrivingLicenseApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInterDrivingLicenseApplications)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvInterDrivingLicenseApplications;
        private System.Windows.Forms.TextBox txtBoxFilterBy;
        private System.Windows.Forms.ComboBox cmbBoxFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddNewInternationalDrivingLicenseApplication;
        private System.Windows.Forms.Label lblNbrOfInternationalDrivingLicesneApplications;
        private System.Windows.Forms.Label lbl1frmManagePeople;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmShowPersonDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmShowLicenseDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmShowPersonLicenseHistory;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox cmbBoxIsActive;
    }
}