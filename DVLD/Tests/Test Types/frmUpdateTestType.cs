using DVLD_Bussiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Tests
{
    public partial class frmUpdateTestType : Form
    {
                     
        private clsTestTypes _TestType;
        private clsTestTypes.enTestType _TestTypeID = clsTestTypes.enTestType.VisionTest;


        public frmUpdateTestType(clsTestTypes.enTestType ID)
        {
            InitializeComponent();
            _TestTypeID = ID;
        }

        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            _TestType = clsTestTypes.Find(_TestTypeID);
            if(_TestType!=null)
            {
                lblID.Text = _TestType.TestTypeID.ToString();
                txtBoxTestTitle.Text = _TestType.TestTypeTitle;
                txtBoxTestTypeDescription.Text = _TestType.TestTypeDescription;
                txtBoxTestFees.Text = _TestType.TestTypeFees.ToString();
            }else
            {
                // we don't need to check if testtype exist or not because we are in the mode of update
                MessageBox.Show("Could not find Test Type with id = " + _TestTypeID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("some fields are not valid, please move the mousse over the red icon(s) to see the error",
                    "Missed Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            _TestType.TestTypeFees = float.Parse(txtBoxTestFees.Text.Trim());
            _TestType.TestTypeTitle = txtBoxTestTitle.Text.Trim();
             _TestType.TestTypeDescription = txtBoxTestTypeDescription.Text.Trim();             

            if (MessageBox.Show("Are you sure you wanna update this information?", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (_TestType.Save())
                    MessageBox.Show("information Update successsfully");
                else
                    MessageBox.Show("Failed to update information");
            }
        }


        private void txtBoxTestTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxTestTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtBoxTestTitle, "Title is a mondatory field");
            }
            else
            {
                errorProvider1.SetError(txtBoxTestTitle, null);
            }
        }

        private void txtBoxTestTypeDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxTestTypeDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtBoxTestTypeDescription, "TitleDescription is a mondatory field!");
            }
            else
            {
                errorProvider1.SetError(txtBoxTestTypeDescription, null);
            }
        }
    }
}
