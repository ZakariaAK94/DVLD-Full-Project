namespace DVLD.Controls
{
    partial class ucPersonCardWithFilter
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBoxFindBy = new System.Windows.Forms.ComboBox();
            this.txtBoxFindByValue = new System.Windows.Forms.TextBox();
            this.gBFilter = new System.Windows.Forms.GroupBox();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ucPersonCard1 = new DVLD.Controls.ucPersonCard();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gBFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "FindBy";
            // 
            // cmbBoxFindBy
            // 
            this.cmbBoxFindBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxFindBy.FormattingEnabled = true;
            this.cmbBoxFindBy.Items.AddRange(new object[] {
            "National No",
            "Person ID"});
            this.cmbBoxFindBy.Location = new System.Drawing.Point(104, 25);
            this.cmbBoxFindBy.Name = "cmbBoxFindBy";
            this.cmbBoxFindBy.Size = new System.Drawing.Size(121, 28);
            this.cmbBoxFindBy.TabIndex = 3;
            this.cmbBoxFindBy.SelectedIndexChanged += new System.EventHandler(this.cmbBoxFindBy_SelectedIndexChanged);
            // 
            // txtBoxFindByValue
            // 
            this.txtBoxFindByValue.Location = new System.Drawing.Point(252, 26);
            this.txtBoxFindByValue.Name = "txtBoxFindByValue";
            this.txtBoxFindByValue.Size = new System.Drawing.Size(155, 26);
            this.txtBoxFindByValue.TabIndex = 4;
            this.txtBoxFindByValue.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxFindBy_Validating);
            // 
            // gBFilter
            // 
            this.gBFilter.Controls.Add(this.btnAddNewPerson);
            this.gBFilter.Controls.Add(this.btnSearch);
            this.gBFilter.Controls.Add(this.txtBoxFindByValue);
            this.gBFilter.Controls.Add(this.cmbBoxFindBy);
            this.gBFilter.Controls.Add(this.label1);
            this.gBFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBFilter.Location = new System.Drawing.Point(9, 6);
            this.gBFilter.Name = "gBFilter";
            this.gBFilter.Size = new System.Drawing.Size(725, 62);
            this.gBFilter.TabIndex = 7;
            this.gBFilter.TabStop = false;
            this.gBFilter.Text = "Filter";
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.Image = global::DVLD.Properties.Resources.AddPerson_32;
            this.btnAddNewPerson.Location = new System.Drawing.Point(488, 19);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(49, 36);
            this.btnAddNewPerson.TabIndex = 6;
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::DVLD.Properties.Resources.SearchPerson;
            this.btnSearch.Location = new System.Drawing.Point(431, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(49, 36);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ucPersonCard1
            // 
            this.ucPersonCard1.Location = new System.Drawing.Point(9, 74);
            this.ucPersonCard1.Name = "ucPersonCard1";
            this.ucPersonCard1.Size = new System.Drawing.Size(803, 254);
            this.ucPersonCard1.TabIndex = 8;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucPersonCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucPersonCard1);
            this.Controls.Add(this.gBFilter);
            this.Name = "ucPersonCardWithFilter";
            this.Size = new System.Drawing.Size(810, 340);
            this.Load += new System.EventHandler(this.ucPersonCardWithFilter1_Load);
            this.gBFilter.ResumeLayout(false);
            this.gBFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBoxFindBy;
        private System.Windows.Forms.TextBox txtBoxFindByValue;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.GroupBox gBFilter;
        private ucPersonCard ucPersonCard1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
