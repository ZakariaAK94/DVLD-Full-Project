using DVLD_Bussiness;

namespace DVLD.Tests
{
    partial class frmListTestAppointment
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
            this.lblTitleOfTheTest = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNbrOfRecords = new System.Windows.Forms.Label();
            this.dgvCurrentAppoint = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTakeTest = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddAppointment = new System.Windows.Forms.Button();
            this.pBTypeOFTest = new System.Windows.Forms.PictureBox();
            this.ucDrivingLicenseApplication1 = new DVLD.Controls.ApplicationControls.ucDrivingLicenseApplication();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentAppoint)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBTypeOFTest)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitleOfTheTest
            // 
            this.lblTitleOfTheTest.AutoSize = true;
            this.lblTitleOfTheTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleOfTheTest.ForeColor = System.Drawing.Color.Red;
            this.lblTitleOfTheTest.Location = new System.Drawing.Point(259, 145);
            this.lblTitleOfTheTest.Name = "lblTitleOfTheTest";
            this.lblTitleOfTheTest.Size = new System.Drawing.Size(202, 29);
            this.lblTitleOfTheTest.TabIndex = 1;
            this.lblTitleOfTheTest.Text = "Test Appointment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 507);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Appointments:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 709);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "#Records:";
            // 
            // lblNbrOfRecords
            // 
            this.lblNbrOfRecords.AutoSize = true;
            this.lblNbrOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNbrOfRecords.Location = new System.Drawing.Point(123, 710);
            this.lblNbrOfRecords.Name = "lblNbrOfRecords";
            this.lblNbrOfRecords.Size = new System.Drawing.Size(28, 16);
            this.lblNbrOfRecords.TabIndex = 8;
            this.lblNbrOfRecords.Text = "???";
            // 
            // dgvCurrentAppoint
            // 
            this.dgvCurrentAppoint.AllowUserToAddRows = false;
            this.dgvCurrentAppoint.AllowUserToDeleteRows = false;
            this.dgvCurrentAppoint.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCurrentAppoint.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCurrentAppoint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrentAppoint.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvCurrentAppoint.Location = new System.Drawing.Point(15, 548);
            this.dgvCurrentAppoint.MultiSelect = false;
            this.dgvCurrentAppoint.Name = "dgvCurrentAppoint";
            this.dgvCurrentAppoint.ReadOnly = true;
            this.dgvCurrentAppoint.Size = new System.Drawing.Size(781, 132);
            this.dgvCurrentAppoint.TabIndex = 9;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmEdit,
            this.tsmTakeTest});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(121, 48);
            // 
            // tsmEdit
            // 
            this.tsmEdit.Name = "tsmEdit";
            this.tsmEdit.Size = new System.Drawing.Size(120, 22);
            this.tsmEdit.Text = "Edit";
            this.tsmEdit.Click += new System.EventHandler(this.tsmEdit_Click);
            // 
            // tsmTakeTest
            // 
            this.tsmTakeTest.Name = "tsmTakeTest";
            this.tsmTakeTest.Size = new System.Drawing.Size(120, 22);
            this.tsmTakeTest.Text = "Take Test";
            this.tsmTakeTest.Click += new System.EventHandler(this.tsmTakeTest_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(706, 686);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 42);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.Image = global::DVLD.Properties.Resources.AddAppointment_32;
            this.btnAddAppointment.Location = new System.Drawing.Point(725, 488);
            this.btnAddAppointment.Name = "btnAddAppointment";
            this.btnAddAppointment.Size = new System.Drawing.Size(55, 54);
            this.btnAddAppointment.TabIndex = 4;
            this.btnAddAppointment.UseVisualStyleBackColor = true;
            this.btnAddAppointment.Click += new System.EventHandler(this.btnAddAppointment_Click);
            // 
            // pBTypeOFTest
            // 
            this.pBTypeOFTest.Image = global::DVLD.Properties.Resources.Vision_512;
            this.pBTypeOFTest.Location = new System.Drawing.Point(274, 12);
            this.pBTypeOFTest.Name = "pBTypeOFTest";
            this.pBTypeOFTest.Size = new System.Drawing.Size(177, 130);
            this.pBTypeOFTest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBTypeOFTest.TabIndex = 2;
            this.pBTypeOFTest.TabStop = false;
            // 
            // ucDrivingLicenseApplication1
            // 
            this.ucDrivingLicenseApplication1.LocalDrivingLicenseAppID = -1;
            this.ucDrivingLicenseApplication1.Location = new System.Drawing.Point(6, 191);
            this.ucDrivingLicenseApplication1.Name = "ucDrivingLicenseApplication1";
            this.ucDrivingLicenseApplication1.Size = new System.Drawing.Size(791, 289);
            this.ucDrivingLicenseApplication1.TabIndex = 11;
            // 
            // frmTestAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 749);
            this.Controls.Add(this.ucDrivingLicenseApplication1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvCurrentAppoint);
            this.Controls.Add(this.lblNbrOfRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddAppointment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pBTypeOFTest);
            this.Controls.Add(this.lblTitleOfTheTest);
            this.Name = "frmTestAppointment";
            this.Text = "Test Appointment";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentAppoint)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBTypeOFTest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
        private System.Windows.Forms.Label lblTitleOfTheTest;
        private System.Windows.Forms.PictureBox pBTypeOFTest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddAppointment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNbrOfRecords;
        private System.Windows.Forms.DataGridView dgvCurrentAppoint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmTakeTest;
        private DVLD.Controls.ApplicationControls.ucDrivingLicenseApplication ucDrivingLicenseApplication1;
        //private ucDrivingLicenseApplication ucDrivingLicenseApplication;
    }
}