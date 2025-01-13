namespace DVLD.Drivers
{
    partial class frmDriverLicenseInfo
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
            this.ucDriverLicenseControl1 = new DVLD.ucDriverLicenseInfo();
            this.button1 = new System.Windows.Forms.Button();
            this.pboxTypeOfTest = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pboxTypeOfTest)).BeginInit();
            this.SuspendLayout();
            // 
            // ucDriverLicenseControl1
            // 
            //this.ucDriverLicenseControl1.License = null;
            this.ucDriverLicenseControl1.Location = new System.Drawing.Point(4, 154);
            this.ucDriverLicenseControl1.Name = "ucDriverLicenseControl1";
            //this.ucDriverLicenseControl1.Person = null;
            this.ucDriverLicenseControl1.Size = new System.Drawing.Size(872, 327);
            this.ucDriverLicenseControl1.TabIndex = 0;
            // 
            // button1
            // 
            //this.button1.Image = global::DVLD.Properties.Resources.icons8_close_64_2;
            this.button1.Location = new System.Drawing.Point(744, 476);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 41);
            this.button1.TabIndex = 9;
            this.button1.Text = "Close";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pboxTypeOfTest
            // 
            //this.pboxTypeOfTest.Image = global::DVLD.Properties.Resources.issue_driving_license;
            this.pboxTypeOfTest.Location = new System.Drawing.Point(347, 11);
            this.pboxTypeOfTest.Name = "pboxTypeOfTest";
            this.pboxTypeOfTest.Size = new System.Drawing.Size(137, 110);
            this.pboxTypeOfTest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxTypeOfTest.TabIndex = 11;
            this.pboxTypeOfTest.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(333, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "Driver License Info";
            // 
            // frmDriverLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 526);
            this.Controls.Add(this.pboxTypeOfTest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ucDriverLicenseControl1);
            this.Name = "frmDriverLicenseInfo";
            this.Text = "frmDriverLicenseInfo";
            this.Load += new System.EventHandler(this.frmDriverLicenseInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboxTypeOfTest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucDriverLicenseInfo ucDriverLicenseControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pboxTypeOfTest;
        private System.Windows.Forms.Label label1;
    }
}