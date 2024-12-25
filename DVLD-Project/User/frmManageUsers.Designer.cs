namespace DVLD.User
{
    partial class frmManageUsers
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
            this.label2 = new System.Windows.Forms.Label();
            this.lblNmbrOfUsers = new System.Windows.Forms.Label();
            this.lbl1frmManagePeople = new System.Windows.Forms.Label();
            this.cmbBoxFilterUsers = new System.Windows.Forms.ComboBox();
            this.txtBoxFilteruser = new System.Windows.Forms.TextBox();
            this.dgvGetAllUsers = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMshowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMaddNewUser = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbBoxIsActive = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGetAllUsers)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(324, 229);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage Users";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Filter By:";
            // 
            // lblNmbrOfUsers
            // 
            this.lblNmbrOfUsers.AutoSize = true;
            this.lblNmbrOfUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNmbrOfUsers.Location = new System.Drawing.Point(143, 532);
            this.lblNmbrOfUsers.Name = "lblNmbrOfUsers";
            this.lblNmbrOfUsers.Size = new System.Drawing.Size(45, 20);
            this.lblNmbrOfUsers.TabIndex = 14;
            this.lblNmbrOfUsers.Text = "????";
            // 
            // lbl1frmManagePeople
            // 
            this.lbl1frmManagePeople.AutoSize = true;
            this.lbl1frmManagePeople.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1frmManagePeople.Location = new System.Drawing.Point(61, 532);
            this.lbl1frmManagePeople.Name = "lbl1frmManagePeople";
            this.lbl1frmManagePeople.Size = new System.Drawing.Size(78, 20);
            this.lbl1frmManagePeople.TabIndex = 13;
            this.lbl1frmManagePeople.Text = "# Record:";
            // 
            // cmbBoxFilterUsers
            // 
            this.cmbBoxFilterUsers.BackColor = System.Drawing.SystemColors.Control;
            this.cmbBoxFilterUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxFilterUsers.FormattingEnabled = true;
            this.cmbBoxFilterUsers.Items.AddRange(new object[] {
            "None",
            "User ID",
            "Person ID",
            "Full Name",
            "UserName",
            "Is Active"});
            this.cmbBoxFilterUsers.Location = new System.Drawing.Point(146, 302);
            this.cmbBoxFilterUsers.Name = "cmbBoxFilterUsers";
            this.cmbBoxFilterUsers.Size = new System.Drawing.Size(121, 21);
            this.cmbBoxFilterUsers.TabIndex = 15;
            this.cmbBoxFilterUsers.SelectedIndexChanged += new System.EventHandler(this.cmbBoxFilterUsers_SelectedIndexChanged);
            // 
            // txtBoxFilteruser
            // 
            this.txtBoxFilteruser.Location = new System.Drawing.Point(280, 303);
            this.txtBoxFilteruser.Name = "txtBoxFilteruser";
            this.txtBoxFilteruser.Size = new System.Drawing.Size(119, 20);
            this.txtBoxFilteruser.TabIndex = 16;
            this.txtBoxFilteruser.Visible = false;
            this.txtBoxFilteruser.TextChanged += new System.EventHandler(this.txtBoxFilteruser_TextChanged);
            // 
            // dgvGetAllUsers
            // 
            this.dgvGetAllUsers.AllowUserToAddRows = false;
            this.dgvGetAllUsers.AllowUserToDeleteRows = false;
            this.dgvGetAllUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvGetAllUsers.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvGetAllUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGetAllUsers.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvGetAllUsers.Location = new System.Drawing.Point(46, 340);
            this.dgvGetAllUsers.Name = "dgvGetAllUsers";
            this.dgvGetAllUsers.ReadOnly = true;
            this.dgvGetAllUsers.Size = new System.Drawing.Size(824, 180);
            this.dgvGetAllUsers.TabIndex = 19;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMshowDetails,
            this.toolStripSeparator1,
            this.TSMaddNewUser,
            this.TSMEdit,
            this.TSMDelete,
            this.TSMChangePassword});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(185, 214);
            // 
            // TSMshowDetails
            // 
            this.TSMshowDetails.AutoSize = false;
            this.TSMshowDetails.Image = global::DVLD.Properties.Resources.PersonDetails_32;
            this.TSMshowDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TSMshowDetails.Name = "TSMshowDetails";
            this.TSMshowDetails.Size = new System.Drawing.Size(150, 40);
            this.TSMshowDetails.Text = "Show Details";
            this.TSMshowDetails.Click += new System.EventHandler(this.TSMshowDetails_Click);
            // 
            // TSMaddNewUser
            // 
            this.TSMaddNewUser.AutoSize = false;
            this.TSMaddNewUser.Image = global::DVLD.Properties.Resources.Add_New_User_32;
            this.TSMaddNewUser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TSMaddNewUser.Name = "TSMaddNewUser";
            this.TSMaddNewUser.Size = new System.Drawing.Size(150, 40);
            this.TSMaddNewUser.Text = "Add New User";
            this.TSMaddNewUser.Click += new System.EventHandler(this.TSMaddNewUser_Click);
            // 
            // TSMEdit
            // 
            this.TSMEdit.AutoSize = false;
            this.TSMEdit.Image = global::DVLD.Properties.Resources.edit_32;
            this.TSMEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TSMEdit.Name = "TSMEdit";
            this.TSMEdit.Size = new System.Drawing.Size(150, 40);
            this.TSMEdit.Text = "Edit";
            this.TSMEdit.Click += new System.EventHandler(this.TSMEdit_Click);
            // 
            // TSMDelete
            // 
            this.TSMDelete.AutoSize = false;
            this.TSMDelete.Image = global::DVLD.Properties.Resources.Delete_32;
            this.TSMDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TSMDelete.Name = "TSMDelete";
            this.TSMDelete.Size = new System.Drawing.Size(150, 40);
            this.TSMDelete.Text = "Delete";
            this.TSMDelete.Click += new System.EventHandler(this.TSMDelete_Click);
            // 
            // TSMChangePassword
            // 
            this.TSMChangePassword.AutoSize = false;
            this.TSMChangePassword.Image = global::DVLD.Properties.Resources.Password_32;
            this.TSMChangePassword.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TSMChangePassword.Name = "TSMChangePassword";
            this.TSMChangePassword.Size = new System.Drawing.Size(150, 40);
            this.TSMChangePassword.Text = "Change Password";
            this.TSMChangePassword.Click += new System.EventHandler(this.TSMChangePassword_Click);
            // 
            // cmbBoxIsActive
            // 
            this.cmbBoxIsActive.BackColor = System.Drawing.SystemColors.Control;
            this.cmbBoxIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxIsActive.FormattingEnabled = true;
            this.cmbBoxIsActive.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cmbBoxIsActive.Location = new System.Drawing.Point(290, 302);
            this.cmbBoxIsActive.Name = "cmbBoxIsActive";
            this.cmbBoxIsActive.Size = new System.Drawing.Size(121, 21);
            this.cmbBoxIsActive.TabIndex = 20;
            this.cmbBoxIsActive.Visible = false;
            this.cmbBoxIsActive.SelectedIndexChanged += new System.EventHandler(this.cmbBoxIsActive_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(706, 526);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(130, 43);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Image = global::DVLD.Properties.Resources.Add_New_User_32;
            this.btnAddUser.Location = new System.Drawing.Point(798, 261);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(72, 62);
            this.btnAddUser.TabIndex = 17;
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Users_2_400;
            this.pictureBox1.Location = new System.Drawing.Point(224, 22);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(304, 204);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 10);
            // 
            // frmManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 578);
            this.Controls.Add(this.cmbBoxIsActive);
            this.Controls.Add(this.dgvGetAllUsers);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.txtBoxFilteruser);
            this.Controls.Add(this.cmbBoxFilterUsers);
            this.Controls.Add(this.lblNmbrOfUsers);
            this.Controls.Add(this.lbl1frmManagePeople);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmManageUsers";
            this.Text = "Manage Users";
            this.Load += new System.EventHandler(this.frmManageUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGetAllUsers)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNmbrOfUsers;
        private System.Windows.Forms.Label lbl1frmManagePeople;
        private System.Windows.Forms.ComboBox cmbBoxFilterUsers;
        private System.Windows.Forms.TextBox txtBoxFilteruser;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvGetAllUsers;
        private System.Windows.Forms.ComboBox cmbBoxIsActive;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TSMshowDetails;
        private System.Windows.Forms.ToolStripMenuItem TSMaddNewUser;
        private System.Windows.Forms.ToolStripMenuItem TSMEdit;
        private System.Windows.Forms.ToolStripMenuItem TSMDelete;
        private System.Windows.Forms.ToolStripMenuItem TSMChangePassword;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}