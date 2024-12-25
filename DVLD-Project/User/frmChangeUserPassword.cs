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
using DVLD.Classes;
using DVLD;
using DVLD.Login;

namespace DVLD.User
{
    public partial class frmChangeUserPassword : Form
    {
        
        private int _UserId;
        private clsUser _User;
        public frmChangeUserPassword(int userId)
        {
            
            InitializeComponent();         
            _UserId = userId;
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _ResetDefautValues()
        {
            txtBoxConfirmPassword.Text = "";
           //txtBoxCurrentPassword.Text = "";
            txtBoxNewPassword.Text = "";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                _ResetDefautValues();
                MessageBox.Show("Please fill all required field, put the mouse over the red icon(s) to see the message", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            if(MessageBox.Show("Are you sure you want to update Password?","Confirmation",MessageBoxButtons.OK,MessageBoxIcon.Information)==DialogResult.OK)
            {
                
                _User.Password = txtBoxNewPassword.Text;
                if(_User.Save())
                {
                    MessageBox.Show("the password was updated successfully");
                }
                else
                    MessageBox.Show("the password was failed to update");
            }
        }

        private void txtBoxNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxNewPassword.Text))
            {
                e.Cancel = true;
                txtBoxNewPassword.Focus();
                errorProvider1.SetError(txtBoxNewPassword, "Please confirm password");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtBoxNewPassword, "");
            }

        }
        private void txtBoxCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;
                txtBoxCurrentPassword.Focus();
                errorProvider1.SetError(txtBoxCurrentPassword, "This field is mondatory, please enter current password!!");
                return;
            }else if (_User.Password != txtBoxCurrentPassword.Text.Trim())
            {
                e.Cancel = true;
                txtBoxCurrentPassword.Focus();
                errorProvider1.SetError(txtBoxCurrentPassword, "Current password is incorrecte");
                return;
            }
            else
            {
                e.Cancel= false;
                errorProvider1.SetError(txtBoxCurrentPassword, "");
            }
        }

        private void txtBoxConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtBoxConfirmPassword.Text))
            {
                e.Cancel = true;
                txtBoxConfirmPassword.Focus();
                errorProvider1.SetError(txtBoxConfirmPassword, "Please confirm password");
                return;
            }
            else if (txtBoxConfirmPassword.Text != txtBoxNewPassword.Text) 
            {
                e.Cancel = true;
                txtBoxConfirmPassword.Focus();
                errorProvider1.SetError(txtBoxConfirmPassword, "Incorrect password");
            }
            else
            {
                e.Cancel= false;
                errorProvider1.SetError(txtBoxConfirmPassword, "");
            }
        }       

        private void frmChangeUserPassword_Load(object sender, EventArgs e)
        {
            ucUserInfo1.LoadUserInfo(_UserId);
            _User = clsUser.FindByUserID(_UserId);
        }
    }
}
