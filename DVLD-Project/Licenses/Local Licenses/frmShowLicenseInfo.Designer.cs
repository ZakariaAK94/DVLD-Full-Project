namespace DVLD.Licenses
{
    partial class frmShowLicenseInfo
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
            this.ucDriverLicenseInfo1 = new DVLD.ucDriverLicenseInfo();
            this.lblTitleOfTheTest = new System.Windows.Forms.Label();
            this.pBTypeOFTest = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pBTypeOFTest)).BeginInit();
            this.SuspendLayout();
            // 
            // ucDriverLicenseInfo1
            // 
            this.ucDriverLicenseInfo1.Location = new System.Drawing.Point(7, 154);
            this.ucDriverLicenseInfo1.Name = "ucDriverLicenseInfo1";
            this.ucDriverLicenseInfo1.Size = new System.Drawing.Size(859, 327);
            this.ucDriverLicenseInfo1.TabIndex = 0;
            // 
            // lblTitleOfTheTest
            // 
            this.lblTitleOfTheTest.AutoSize = true;
            this.lblTitleOfTheTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleOfTheTest.ForeColor = System.Drawing.Color.Red;
            this.lblTitleOfTheTest.Location = new System.Drawing.Point(315, 130);
            this.lblTitleOfTheTest.Name = "lblTitleOfTheTest";
            this.lblTitleOfTheTest.Size = new System.Drawing.Size(212, 29);
            this.lblTitleOfTheTest.TabIndex = 3;
            this.lblTitleOfTheTest.Text = "Driver License Info";
            // 
            // pBTypeOFTest
            // 
            this.pBTypeOFTest.Image = global::DVLD.Properties.Resources.LicenseView_400;
            this.pBTypeOFTest.Location = new System.Drawing.Point(319, 5);
            this.pBTypeOFTest.Name = "pBTypeOFTest";
            this.pBTypeOFTest.Size = new System.Drawing.Size(195, 120);
            this.pBTypeOFTest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBTypeOFTest.TabIndex = 4;
            this.pBTypeOFTest.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(726, 479);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 47);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 534);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pBTypeOFTest);
            this.Controls.Add(this.lblTitleOfTheTest);
            this.Controls.Add(this.ucDriverLicenseInfo1);
            this.Name = "frmShowLicenseInfo";
            this.Text = "License Info";
            this.Load += new System.EventHandler(this.frmShowLicenseInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBTypeOFTest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucDriverLicenseInfo ucDriverLicenseInfo1;
        private System.Windows.Forms.PictureBox pBTypeOFTest;
        private System.Windows.Forms.Label lblTitleOfTheTest;
        private System.Windows.Forms.Button btnClose;
    }
}