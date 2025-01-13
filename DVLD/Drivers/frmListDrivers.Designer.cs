namespace DVLD.Drivers
{
    partial class frmListDrivers
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
            this.dgvGetAllDrivers = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtBoxFilterDriver = new System.Windows.Forms.TextBox();
            this.cmbBoxFilterDrivers = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNmbrOfDrivers = new System.Windows.Forms.Label();
            this.lbl1frmManagePeople = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pbManageDrivers = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGetAllDrivers)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbManageDrivers)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(360, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Manage Drivers";
            // 
            // dgvGetAllDrivers
            // 
            this.dgvGetAllDrivers.AllowUserToAddRows = false;
            this.dgvGetAllDrivers.AllowUserToDeleteRows = false;
            this.dgvGetAllDrivers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvGetAllDrivers.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvGetAllDrivers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGetAllDrivers.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvGetAllDrivers.Location = new System.Drawing.Point(12, 240);
            this.dgvGetAllDrivers.Name = "dgvGetAllDrivers";
            this.dgvGetAllDrivers.ReadOnly = true;
            this.dgvGetAllDrivers.Size = new System.Drawing.Size(803, 196);
            this.dgvGetAllDrivers.TabIndex = 24;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonInfoToolStripMenuItem,
            this.toolStripSeparator1,
            this.showPersonToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(242, 102);
            // 
            // showPersonInfoToolStripMenuItem
            // 
            this.showPersonInfoToolStripMenuItem.AutoSize = false;
            this.showPersonInfoToolStripMenuItem.Image = global::DVLD.Properties.Resources.PersonDetails_32;
            this.showPersonInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showPersonInfoToolStripMenuItem.Name = "showPersonInfoToolStripMenuItem";
            this.showPersonInfoToolStripMenuItem.Size = new System.Drawing.Size(220, 35);
            this.showPersonInfoToolStripMenuItem.Text = "Show Person Info";
            this.showPersonInfoToolStripMenuItem.Click += new System.EventHandler(this.showPersonInfoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(238, 6);
            // 
            // showPersonToolStripMenuItem
            // 
            this.showPersonToolStripMenuItem.AutoSize = false;
            this.showPersonToolStripMenuItem.Image = global::DVLD.Properties.Resources.PersonLicenseHistory_32;
            this.showPersonToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showPersonToolStripMenuItem.Name = "showPersonToolStripMenuItem";
            this.showPersonToolStripMenuItem.Size = new System.Drawing.Size(220, 35);
            this.showPersonToolStripMenuItem.Text = "Show Person License History";
            this.showPersonToolStripMenuItem.Click += new System.EventHandler(this.showPersonToolStripMenuItem_Click);
            // 
            // txtBoxFilterDriver
            // 
            this.txtBoxFilterDriver.Location = new System.Drawing.Point(238, 205);
            this.txtBoxFilterDriver.Name = "txtBoxFilterDriver";
            this.txtBoxFilterDriver.Size = new System.Drawing.Size(119, 20);
            this.txtBoxFilterDriver.TabIndex = 23;
            this.txtBoxFilterDriver.Visible = false;
            this.txtBoxFilterDriver.TextChanged += new System.EventHandler(this.txtBoxFilterDriver_TextChanged);
            this.txtBoxFilterDriver.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxFilterDriver_KeyPress);
            // 
            // cmbBoxFilterDrivers
            // 
            this.cmbBoxFilterDrivers.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbBoxFilterDrivers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxFilterDrivers.FormattingEnabled = true;
            this.cmbBoxFilterDrivers.Items.AddRange(new object[] {
            "None",
            "Driver ID",
            "Person ID",
            "National No",
            "Full Name"});
            this.cmbBoxFilterDrivers.Location = new System.Drawing.Point(104, 204);
            this.cmbBoxFilterDrivers.Name = "cmbBoxFilterDrivers";
            this.cmbBoxFilterDrivers.Size = new System.Drawing.Size(121, 21);
            this.cmbBoxFilterDrivers.TabIndex = 22;
            this.cmbBoxFilterDrivers.SelectedIndexChanged += new System.EventHandler(this.cmbBoxFilterDrivers_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Filter By:";
            // 
            // lblNmbrOfDrivers
            // 
            this.lblNmbrOfDrivers.AutoSize = true;
            this.lblNmbrOfDrivers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNmbrOfDrivers.Location = new System.Drawing.Point(117, 465);
            this.lblNmbrOfDrivers.Name = "lblNmbrOfDrivers";
            this.lblNmbrOfDrivers.Size = new System.Drawing.Size(45, 20);
            this.lblNmbrOfDrivers.TabIndex = 26;
            this.lblNmbrOfDrivers.Text = "????";
            // 
            // lbl1frmManagePeople
            // 
            this.lbl1frmManagePeople.AutoSize = true;
            this.lbl1frmManagePeople.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1frmManagePeople.Location = new System.Drawing.Point(35, 465);
            this.lbl1frmManagePeople.Name = "lbl1frmManagePeople";
            this.lbl1frmManagePeople.Size = new System.Drawing.Size(78, 20);
            this.lbl1frmManagePeople.TabIndex = 25;
            this.lbl1frmManagePeople.Text = "# Record:";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(605, 457);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(102, 44);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // pbManageDrivers
            // 
            this.pbManageDrivers.Image = global::DVLD.Properties.Resources.Driver_Main;
            this.pbManageDrivers.Location = new System.Drawing.Point(315, 12);
            this.pbManageDrivers.Name = "pbManageDrivers";
            this.pbManageDrivers.Size = new System.Drawing.Size(251, 142);
            this.pbManageDrivers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbManageDrivers.TabIndex = 6;
            this.pbManageDrivers.TabStop = false;
            // 
            // frmListDrivers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 523);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblNmbrOfDrivers);
            this.Controls.Add(this.lbl1frmManagePeople);
            this.Controls.Add(this.dgvGetAllDrivers);
            this.Controls.Add(this.txtBoxFilterDriver);
            this.Controls.Add(this.cmbBoxFilterDrivers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbManageDrivers);
            this.Controls.Add(this.label1);
            this.Name = "frmListDrivers";
            this.Text = "List Drivers";
            this.Load += new System.EventHandler(this.frmListDrivers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGetAllDrivers)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbManageDrivers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbManageDrivers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvGetAllDrivers;
        private System.Windows.Forms.TextBox txtBoxFilterDriver;
        private System.Windows.Forms.ComboBox cmbBoxFilterDrivers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblNmbrOfDrivers;
        private System.Windows.Forms.Label lbl1frmManagePeople;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showPersonInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}