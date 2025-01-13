namespace DVLD
{
    partial class ucDrivingLicenseInfoWithFilter
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
            this.gBFilter = new System.Windows.Forms.GroupBox();
            this.btnSearchLicenseInfo = new System.Windows.Forms.Button();
            this.txtBoxLicenseID = new System.Windows.Forms.TextBox();
            this.label01 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ucDriverLicenseInfo2 = new DVLD.ucDriverLicenseInfo();
            this.gBFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gBFilter
            // 
            this.gBFilter.Controls.Add(this.btnSearchLicenseInfo);
            this.gBFilter.Controls.Add(this.txtBoxLicenseID);
            this.gBFilter.Controls.Add(this.label01);
            this.gBFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBFilter.Location = new System.Drawing.Point(9, 10);
            this.gBFilter.Name = "gBFilter";
            this.gBFilter.Size = new System.Drawing.Size(516, 67);
            this.gBFilter.TabIndex = 1;
            this.gBFilter.TabStop = false;
            this.gBFilter.Text = "Filter";
            // 
            // btnSearchLicenseInfo
            // 
            this.btnSearchLicenseInfo.Image = global::DVLD.Properties.Resources.License_View_32;
            this.btnSearchLicenseInfo.Location = new System.Drawing.Point(392, 18);
            this.btnSearchLicenseInfo.Name = "btnSearchLicenseInfo";
            this.btnSearchLicenseInfo.Size = new System.Drawing.Size(65, 40);
            this.btnSearchLicenseInfo.TabIndex = 76;
            this.btnSearchLicenseInfo.UseVisualStyleBackColor = true;
            this.btnSearchLicenseInfo.Click += new System.EventHandler(this.btnSearchLicenseInfo_Click);
            // 
            // txtBoxLicenseID
            // 
            this.txtBoxLicenseID.Location = new System.Drawing.Point(135, 27);
            this.txtBoxLicenseID.Name = "txtBoxLicenseID";
            this.txtBoxLicenseID.Size = new System.Drawing.Size(217, 24);
            this.txtBoxLicenseID.TabIndex = 75;
            this.txtBoxLicenseID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxLicenseID_KeyPress);
            this.txtBoxLicenseID.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxLicenseID_Validating);
            // 
            // label01
            // 
            this.label01.AutoSize = true;
            this.label01.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label01.Location = new System.Drawing.Point(26, 31);
            this.label01.Name = "label01";
            this.label01.Size = new System.Drawing.Size(80, 16);
            this.label01.TabIndex = 74;
            this.label01.Text = "LicenseID:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucDriverLicenseInfo2
            // 
            this.ucDriverLicenseInfo2.Location = new System.Drawing.Point(6, 77);
            this.ucDriverLicenseInfo2.Name = "ucDriverLicenseInfo2";
            this.ucDriverLicenseInfo2.Size = new System.Drawing.Size(882, 320);
            this.ucDriverLicenseInfo2.TabIndex = 2;
            // 
            // ucDrivingLicenseInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gBFilter);
            this.Controls.Add(this.ucDriverLicenseInfo2);
            this.Name = "ucDrivingLicenseInfoWithFilter";
            this.Size = new System.Drawing.Size(893, 396);
            this.gBFilter.ResumeLayout(false);
            this.gBFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        
        private System.Windows.Forms.GroupBox gBFilter;
        private System.Windows.Forms.Button btnSearchLicenseInfo;
        private System.Windows.Forms.TextBox txtBoxLicenseID;
        private System.Windows.Forms.Label label01;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ucDriverLicenseInfo ucDriverLicenseInfo2;
    }
}
