namespace DVLD.People
{
    partial class frmManageListPeople
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageListPeople));
            this.dgvGetAllPeople = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAddNewPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEditPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDeletePerson = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl1frmManagePeople = new System.Windows.Forms.Label();
            this.lblNbrOfRecords = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBox1 = new System.Windows.Forms.ComboBox();
            this.txtBoxFilterBy = new System.Windows.Forms.TextBox();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGetAllPeople)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGetAllPeople
            // 
            this.dgvGetAllPeople.AllowUserToAddRows = false;
            this.dgvGetAllPeople.AllowUserToDeleteRows = false;
            this.dgvGetAllPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGetAllPeople.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvGetAllPeople.Location = new System.Drawing.Point(10, 249);
            this.dgvGetAllPeople.Name = "dgvGetAllPeople";
            this.dgvGetAllPeople.ReadOnly = true;
            this.dgvGetAllPeople.Size = new System.Drawing.Size(1144, 249);
            this.dgvGetAllPeople.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShowDetails,
            this.tsmAddNewPerson,
            this.tsmEditPerson,
            this.tsmDeletePerson});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(179, 124);
            // 
            // tsmShowDetails
            // 
            this.tsmShowDetails.AutoSize = false;
            this.tsmShowDetails.Image = global::DVLD.Properties.Resources.PersonDetails_32;
            this.tsmShowDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmShowDetails.Name = "tsmShowDetails";
            this.tsmShowDetails.Size = new System.Drawing.Size(180, 30);
            this.tsmShowDetails.Text = "Show Details";
            this.tsmShowDetails.Click += new System.EventHandler(this.tsmShowDetails_Click);
            // 
            // tsmAddNewPerson
            // 
            this.tsmAddNewPerson.AutoSize = false;
            this.tsmAddNewPerson.Image = global::DVLD.Properties.Resources.AddPerson_32;
            this.tsmAddNewPerson.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmAddNewPerson.Name = "tsmAddNewPerson";
            this.tsmAddNewPerson.Size = new System.Drawing.Size(180, 30);
            this.tsmAddNewPerson.Text = "Add New Person";
            this.tsmAddNewPerson.Click += new System.EventHandler(this.tsmAddNewPerson_Click);
            // 
            // tsmEditPerson
            // 
            this.tsmEditPerson.AutoSize = false;
            this.tsmEditPerson.Image = global::DVLD.Properties.Resources.edit_32;
            this.tsmEditPerson.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmEditPerson.Name = "tsmEditPerson";
            this.tsmEditPerson.Size = new System.Drawing.Size(180, 30);
            this.tsmEditPerson.Text = "Edit";
            this.tsmEditPerson.Click += new System.EventHandler(this.tsmEditPerson_Click);
            // 
            // tsmDeletePerson
            // 
            this.tsmDeletePerson.AutoSize = false;
            this.tsmDeletePerson.Image = global::DVLD.Properties.Resources.Delete_32;
            this.tsmDeletePerson.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmDeletePerson.Name = "tsmDeletePerson";
            this.tsmDeletePerson.Size = new System.Drawing.Size(180, 30);
            this.tsmDeletePerson.Text = "Delete ";
            this.tsmDeletePerson.Click += new System.EventHandler(this.tsmDeletePerson_Click);
            // 
            // lbl1frmManagePeople
            // 
            this.lbl1frmManagePeople.AutoSize = true;
            this.lbl1frmManagePeople.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1frmManagePeople.Location = new System.Drawing.Point(15, 509);
            this.lbl1frmManagePeople.Name = "lbl1frmManagePeople";
            this.lbl1frmManagePeople.Size = new System.Drawing.Size(78, 20);
            this.lbl1frmManagePeople.TabIndex = 2;
            this.lbl1frmManagePeople.Text = "# Record:";
            // 
            // lblNbrOfRecords
            // 
            this.lblNbrOfRecords.AutoSize = true;
            this.lblNbrOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNbrOfRecords.Location = new System.Drawing.Point(97, 509);
            this.lblNbrOfRecords.Name = "lblNbrOfRecords";
            this.lblNbrOfRecords.Size = new System.Drawing.Size(45, 20);
            this.lblNbrOfRecords.TabIndex = 3;
            this.lblNbrOfRecords.Text = "????";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Filter By:";
            // 
            // cmbBox1
            // 
            this.cmbBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBox1.FormattingEnabled = true;
            this.cmbBox1.Items.AddRange(new object[] {
            "None",
            "Person ID",
            "National No",
            "First Name",
            "Second Name",
            "Third Name",
            "Last Name",
            "Nationality",
            "Gendor",
            "Phone ",
            "Email"});
            this.cmbBox1.Location = new System.Drawing.Point(86, 206);
            this.cmbBox1.Name = "cmbBox1";
            this.cmbBox1.Size = new System.Drawing.Size(121, 21);
            this.cmbBox1.TabIndex = 6;
            this.cmbBox1.SelectedIndexChanged += new System.EventHandler(this.cmbBox1_SelectedIndexChanged);
            // 
            // txtBoxFilterBy
            // 
            this.txtBoxFilterBy.Location = new System.Drawing.Point(229, 207);
            this.txtBoxFilterBy.Name = "txtBoxFilterBy";
            this.txtBoxFilterBy.Size = new System.Drawing.Size(149, 20);
            this.txtBoxFilterBy.TabIndex = 9;
            this.txtBoxFilterBy.Visible = false;
            this.txtBoxFilterBy.TextChanged += new System.EventHandler(this.txtBoxFilterBy_TextChanged);
            this.txtBoxFilterBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxFilterBy_KeyPress);
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewPerson.Image")));
            this.btnAddNewPerson.Location = new System.Drawing.Point(1068, 170);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAddNewPerson.Size = new System.Drawing.Size(67, 66);
            this.btnAddNewPerson.TabIndex = 7;
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(444, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(270, 147);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(518, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Manage People";
            // 
            // frmManageListPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 542);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxFilterBy);
            this.Controls.Add(this.btnAddNewPerson);
            this.Controls.Add(this.cmbBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblNbrOfRecords);
            this.Controls.Add(this.lbl1frmManagePeople);
            this.Controls.Add(this.dgvGetAllPeople);
            this.Name = "frmManageListPeople";
            this.Text = "Manage People";
            this.Load += new System.EventHandler(this.frmManageListPeople_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGetAllPeople)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGetAllPeople;
        private System.Windows.Forms.Label lbl1frmManagePeople;
        private System.Windows.Forms.Label lblNbrOfRecords;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBox1;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.TextBox txtBoxFilterBy;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmShowDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmAddNewPerson;
        private System.Windows.Forms.ToolStripMenuItem tsmEditPerson;
        private System.Windows.Forms.ToolStripMenuItem tsmDeletePerson;
        private System.Windows.Forms.Label label2;
    }
}