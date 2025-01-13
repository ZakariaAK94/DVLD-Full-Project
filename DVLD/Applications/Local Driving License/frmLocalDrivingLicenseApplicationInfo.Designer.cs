namespace DVLD.Applications
{
    partial class frmLocalDrivingLicenseApplicationInfo
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
            this.ucDrivingLicenseApplication1 = new DVLD.Controls.ApplicationControls.ucDrivingLicenseApplication();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ucDrivingLicenseApplication1
            // 
            this.ucDrivingLicenseApplication1.LocalDrivingLicenseAppID = -1;
            this.ucDrivingLicenseApplication1.Location = new System.Drawing.Point(12, 12);
            this.ucDrivingLicenseApplication1.Name = "ucDrivingLicenseApplication1";
            this.ucDrivingLicenseApplication1.Size = new System.Drawing.Size(791, 289);
            this.ucDrivingLicenseApplication1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(639, 307);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 39);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // frmLocalDrivingLicenseApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 364);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ucDrivingLicenseApplication1);
            this.Name = "frmLocalDrivingLicenseApplicationInfo";
            this.Text = "Show Application Detail";
            this.Load += new System.EventHandler(this.frmShowApplicationDetail_Load);
            this.ResumeLayout(false);

        }

        private DVLD.Controls.ApplicationControls.ucDrivingLicenseApplication ucDrivingLicenseApplication1;
        private System.Windows.Forms.Button btnClose;

        #endregion

    }
}