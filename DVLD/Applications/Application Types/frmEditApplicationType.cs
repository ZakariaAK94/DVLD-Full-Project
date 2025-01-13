using DVLD.Global_Classes;
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

namespace DVLD.Applications
{
    public partial class frmEditApplicationTypes : Form
    {
        private int _ApplicationTypeID = -1;
        private clsApplicationTypes _ApplicationType;
        //public delegate void RefreshDataPreviousForm();
        //public event RefreshDataPreviousForm DataRefreshed;        

        private DataTable _dtAllApplicationTypes;


        public frmEditApplicationTypes(int ID)
        {
            InitializeComponent();
            _ApplicationTypeID = ID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
          //  DataRefreshed?.Invoke();
            this.Close();
        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            _ApplicationType = clsApplicationTypes.Find(_ApplicationTypeID);
            lblID.Text = _ApplicationType.ApplicationTypeID.ToString();
            if(_ApplicationType != null)
            {
                txtBoxTitle.Text = _ApplicationType.ApplicationTypeTitle;
                txtBoxFees.Text = _ApplicationType.ApplicationFees.ToString();
            }            
        }    

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("some fields are not valid, please move the mousse over the red icon(s) to see the error",
                    "Missed Information",MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            _ApplicationType.ApplicationFees = float.Parse(txtBoxFees.Text);// we can use Convert.Tosingle()
            _ApplicationType.ApplicationTypeTitle = txtBoxTitle.Text.Trim();   
            if(MessageBox.Show("Are you sure you wanna update this information?","Confirmation",MessageBoxButtons.OK,MessageBoxIcon.Information)==DialogResult.OK)
            {
                if (_ApplicationType.Save())
                    MessageBox.Show("information Update successsfully");
                else
                    MessageBox.Show("Failed to update information");
            }
        }

        private void txtBoxTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtBoxTitle, "Title cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtBoxTitle, null);
            };

        }

        private void txtBoxFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtBoxFees, "Fees cannot be empty!");
            }else if(clsValidation.IsNumber(txtBoxFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtBoxFees, "Fees must be a number!");
            }
            else
            {
                errorProvider1.SetError(txtBoxFees, null);
            }
        }
    }
}
