using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using DVLD.Classes;
using DVLD_Bussiness;
using ProjectDVLD;

namespace DVLD.Login
{
    public partial class frmLogin : Form
    {
        
        //private clsLoginUserInfo LoginUserInfo = new clsLoginUserInfo();
        public frmLogin()
        {
            InitializeComponent();
            //refreshUserInfo();
        }

        public void refreshUserInfo()
        {
            string UserName = "",Password = "";
            if (rbRememberMe.Checked)
            {                
                clsGlobal.GetStoredLoginInfo(ref UserName, ref Password);
                txtboxUserName.Text = UserName;
                txtboxPassword.Text = Password;
            }
            else
            {
                clsGlobal.StoreLoginInfo("", "");
                txtboxUserName.Text = "";
                txtboxPassword.Text = "";
            }
        }

          
        private void btnLogin_Click(object sender, EventArgs e)
        {
                clsGlobal.CurrentUser = clsUser.FindByUserNameAndPassword(txtboxUserName.Text,txtboxPassword.Text);
                if(clsGlobal.CurrentUser == null)
                {
                    MessageBox.Show("Password/UserName is wrong, pealse enter a correct information", "Error Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }
                else if (clsGlobal.CurrentUser.isActive)
                {
                        if (rbRememberMe.Checked)
                        {
                            clsGlobal.StoreLoginInfo(clsGlobal.CurrentUser.UserName, clsGlobal.CurrentUser.Password);
                        } else
                        {
                             txtboxUserName.Text = "";
                             txtboxPassword.Text = "";
                             clsGlobal.StoreLoginInfo("", "");
                        }
                        frmMain frm1 = new frmMain(this);
                        this.Hide();
                        frm1.ShowDialog();

                }
                else
                {
                    clsGlobal.StoreLoginInfo("", "");
                    MessageBox.Show("Your account is desactivated, please contact your admin", "Error Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                       
        }
        
        private void txtboxUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxUserName.Text))
            {
                e.Cancel = true;
                txtboxUserName.Focus();
                errorProvider1.SetError(txtboxUserName, "UserName is mondatory, please enter your UserName.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtboxUserName, "");
            }
        }

        private void txtboxPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxPassword.Text))
            {
                e.Cancel = true;
                txtboxPassword.Focus();
                errorProvider1.SetError(txtboxPassword, "txtboxPassword is mondatory, please enter your Password.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtboxPassword, "");
            }
        }
      
        private void frmLogin_Load(object sender, EventArgs e)
        {
            refreshUserInfo();
            txtboxUserName.Focus();
            txtboxPassword.Focus();
        }

        private void cbRememberMe_CheckedChanged(object sender, EventArgs e)
        {
            //refreshUserInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
