using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Bussiness;
using DVLD.Properties;

namespace DVLD.User
{
    public partial class frmAddNewUser : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _UserId=-1;
        clsUser _User;
        public int UserId
        {
            set { _UserId = value; }
        }
        public frmAddNewUser()
        {
            InitializeComponent();            
            _Mode = enMode.AddNew;
        }

        public frmAddNewUser(int UserID)
        {
            InitializeComponent();
            _UserId = UserID;   
            _Mode = enMode.Update;
        }

        private void _ResetDefaultValues()
        {
            if(_Mode == enMode.AddNew)
            {
                _User = new clsUser();
                tpLoginInfo.Enabled = false;
                lblText.Text = "Add New User";
                this.Text = lblText.Text;
                ucPersonCardWithFilter1.FilterFocus();
            }
            else
            {
                tpLoginInfo.Enabled = true;
                lblText.Text = "Update User";
                this.Text = lblText.Text;
                btnSave.Enabled = true;
            }
            txtBoxUserName.Text = "";
            txtBoxPassword.Text = "";
            txtBoxConfirmPassword.Text = "";
            chBoxIsActive.Enabled = true;
        }

        private void _LoadData()
        {
            _User = clsUser.FindByUserID(_UserId);
            ucPersonCardWithFilter1.FilterEnabled = false;
            if(_User == null) 
            {
                MessageBox.Show("No User with ID = "+_User,"User Not Found",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            // the following code won't be executed if the person was not found
            lbluserID.Text = _User.UserID.ToString();
            txtBoxUserName.Text = _User.UserName;
            txtBoxPassword.Text = _User.Password;
            txtBoxConfirmPassword.Text = _User.Password;
            chBoxIsActive.Checked = _User.isActive;
            //btnNext.Enabled = true;
        }

        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if(_Mode == enMode.Update)
            {
                _LoadData();
                ucPersonCardWithFilter1.LoadPersonInfo(clsUser.FindByUserID(_UserId).PersonID);

                btnNext.Enabled = true;
            }
                          
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                // we will exist because the form is not valid
                MessageBox.Show("Some fields are not valid!!,put the mouse over the red icon(s) to see the error", "Not Valid",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you wanna add this user?", "Confirmation", MessageBoxButtons.OK) == DialogResult.OK)
            {
                _User.UserName = txtBoxUserName.Text;
                _User.PersonID = ucPersonCardWithFilter1.PersonID;
                _User.Password = txtBoxPassword.Text;
                _User.isActive = chBoxIsActive.Checked;
                if (_User.Save())
                {
                    lbluserID.Text = _User.UserID.ToString();
                    _Mode = enMode.Update;
                    lblText.Text = "Update User";
                    this.Text = lblText.Text;
                    MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK,MessageBoxIcon.Information);                    
                    btnSave.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Error: Data is not Saved successufully","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }        

        }

        private void txtBoxUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxUserName.Text))
            {
                e.Cancel = true;
                txtBoxUserName.Focus();
                errorProvider1.SetError(txtBoxUserName, "this field is mondatory,please enter the UserName!!!");
            }
            else if(clsUser.isUserExist(txtBoxUserName.Text) && txtBoxUserName.Text.Trim() != _User.UserName)
            {
                e.Cancel = true;
                txtBoxUserName.Focus();
                errorProvider1.SetError(txtBoxUserName, "UserName is leardy used by another person!!!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtBoxUserName, "");
            }            
        }

        private void txtBoxPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxPassword.Text.Trim()))
            {
                e.Cancel = true;
                txtBoxPassword.Focus();
                errorProvider1.SetError(txtBoxPassword, "This field is mondatory, please fill your data!!!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtBoxPassword, "");
            }

        }
        private void txtBoxConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtBoxConfirmPassword.Text.Trim() != txtBoxPassword.Text.Trim())
            {
                e.Cancel = true;
                txtBoxConfirmPassword.Focus();
                errorProvider1.SetError(txtBoxConfirmPassword, "PasswordConfirmation doesn't match Password!!!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtBoxConfirmPassword, "");
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if(_Mode==enMode.Update)
            {
                txtBoxUserName.Focus();
                btnSave.Enabled = true;
                tpLoginInfo.Enabled = true;
                tbCtrlAddNewUser.SelectedIndex = 1;
                return;
            }

            if(ucPersonCardWithFilter1.PersonID!=-1)
            {
                if(clsUser.isUserExistForPersonID(ucPersonCardWithFilter1.PersonID))
                {
                    MessageBox.Show("This person had already a user account, please choose another one", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ucPersonCardWithFilter1.FilterFocus();
                    return;
                }
                else
                {
                    txtBoxUserName.Focus();
                    btnSave.Enabled = true;
                    tpLoginInfo.Enabled = true;
                    tbCtrlAddNewUser.SelectedIndex = 1;
                    return;

                }
            }         
            else
            {
                MessageBox.Show("please select a person to move to the next step!!", "No Person Selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ucPersonCardWithFilter1.FilterFocus();
                return;
            }

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            tbCtrlAddNewUser.SelectedIndex = 0;
            btnSave.Enabled = false;
        }        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}


