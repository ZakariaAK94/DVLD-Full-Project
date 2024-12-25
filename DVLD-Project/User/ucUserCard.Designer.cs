namespace DVLD.Controls
{
    partial class ucUserCard
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gBLoginInformation = new System.Windows.Forms.GroupBox();
            this.ucPersonCard3 = new DVLD.Controls.ucPersonCard();
            this.gBLoginInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(81, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "User ID:";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(151, 20);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(31, 13);
            this.lblUserID.TabIndex = 2;
            this.lblUserID.Text = "????";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(352, 20);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(31, 13);
            this.lblUserName.TabIndex = 4;
            this.lblUserName.Text = "????";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(267, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "UserName:";
            // 
            // lblIsActive
            // 
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.Location = new System.Drawing.Point(608, 20);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(31, 13);
            this.lblIsActive.TabIndex = 6;
            this.lblIsActive.Text = "????";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(545, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "IsActive:";
            // 
            // gBLoginInformation
            // 
            this.gBLoginInformation.Controls.Add(this.lblIsActive);
            this.gBLoginInformation.Controls.Add(this.label4);
            this.gBLoginInformation.Controls.Add(this.lblUserName);
            this.gBLoginInformation.Controls.Add(this.label3);
            this.gBLoginInformation.Controls.Add(this.lblUserID);
            this.gBLoginInformation.Controls.Add(this.label1);
            this.gBLoginInformation.Location = new System.Drawing.Point(10, 261);
            this.gBLoginInformation.Name = "gBLoginInformation";
            this.gBLoginInformation.Size = new System.Drawing.Size(787, 45);
            this.gBLoginInformation.TabIndex = 7;
            this.gBLoginInformation.TabStop = false;
            this.gBLoginInformation.Text = "Login Information";
            // 
            // ucPersonCard3
            // 
            this.ucPersonCard3.Location = new System.Drawing.Point(6, 0);
            this.ucPersonCard3.Name = "ucPersonCard3";
            this.ucPersonCard3.Size = new System.Drawing.Size(807, 254);
            this.ucPersonCard3.TabIndex = 8;
            // 
            // ucUserCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucPersonCard3);
            this.Controls.Add(this.gBLoginInformation);
            this.Name = "ucUserCard";
            this.Size = new System.Drawing.Size(816, 333);
            this.gBLoginInformation.ResumeLayout(false);
            this.gBLoginInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gBLoginInformation;
        private ucPersonCard ucPersonCard3;
    }
}
