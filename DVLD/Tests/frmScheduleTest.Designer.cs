namespace DVLD.Tests
{
    partial class frmScheduleTest
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
            this.ucScheduleTests1 = new DVLD.Tests.Controls.ucScheduleTests();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ucScheduleTests1
            // 
            this.ucScheduleTests1.Location = new System.Drawing.Point(2, 8);
            this.ucScheduleTests1.Name = "ucScheduleTests1";
            this.ucScheduleTests1.Size = new System.Drawing.Size(474, 592);
            this.ucScheduleTests1.TabIndex = 92;
            this.ucScheduleTests1.TestTypeID = DVLD_Bussiness.clsTestTypes.enTestType.StreetTest;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(185, 617);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 42);
            this.btnClose.TabIndex = 93;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmScheduleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 671);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ucScheduleTests1);
            this.Name = "frmScheduleTest";
            this.Text = "ScheduleTest";
            this.ResumeLayout(false);

        }

        #endregion      
        private Controls.ucScheduleTests ucScheduleTests1;
        private System.Windows.Forms.Button btnClose;
    }
}