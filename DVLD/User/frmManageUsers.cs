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
using DVLD.User;

namespace DVLD.User
{
    public partial class frmManageUsers : Form
    {
        private static DataTable _dtAllUsers; 
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _RefreshUserList();
        }
        private void _RefreshUserList()
        {
            _dtAllUsers = clsUser.GetAllUsers();            
            dgvGetAllUsers.DataSource = _dtAllUsers;
            lblNmbrOfUsers.Text = dgvGetAllUsers.Rows.Count.ToString();
            dgvGetAllUsers.Columns["UserID"].HeaderText = "User ID";
            dgvGetAllUsers.Columns["PersonID"].HeaderText = "Person ID";
            dgvGetAllUsers.Columns["FullName"].HeaderText = "Full Name";            
            dgvGetAllUsers.Columns["IsActive"].HeaderText = "Is Active";            
            cmbBoxFilterUsers.SelectedIndex = 0;
            dgvGetAllUsers.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvGetAllUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void cmbBoxFilterUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if(cmbBoxFilterUsers.Text=="None")
            {
                cmbBoxIsActive.Visible = false;
                txtBoxFilteruser.Visible = false;
                
            }
            else if(cmbBoxFilterUsers.Text == "Is Active")
            {
                cmbBoxIsActive.Visible = true;
                txtBoxFilteruser.Visible = !cmbBoxIsActive.Visible;
                cmbBoxIsActive.SelectedIndex = 0;
            }
            else
            {
                txtBoxFilteruser.Visible = true;
                cmbBoxIsActive.Visible = !txtBoxFilteruser.Visible;
            }
        }
        private void _FilterData()
        {
            string FilterColumnName = "";
            switch(cmbBoxFilterUsers.Text)
            {
                case "User ID":
                    FilterColumnName = "UserID";
                    break;
                case "Person ID":
                    FilterColumnName = "PersonID";
                    break;
                case "Full Name":
                    FilterColumnName = "FullName";
                    break;
                case "UserName":
                    FilterColumnName = "UserName";            
                    break;
                case "Is Active":
                    FilterColumnName = "IsActive";
                    break;
                default:
                    FilterColumnName = "None";
                    break;
            }
            if (FilterColumnName == "None" || txtBoxFilteruser.Text.Trim() == "")
            {
                _dtAllUsers.DefaultView.RowFilter = "";                
                lblNmbrOfUsers.Text = dgvGetAllUsers.Rows.Count.ToString();
                return;
            }
            else if (FilterColumnName == "UserID" || FilterColumnName == "PersonID" || FilterColumnName == "IsActive")
            {

                txtBoxFilteruser.KeyPress += TxtBoxFilterByKeyPress;
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumnName, txtBoxFilteruser.Text.Trim());
                return;
            }
            else
            {
                txtBoxFilteruser.KeyPress -= TxtBoxFilterByKeyPress;
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumnName, txtBoxFilteruser.Text.Trim());
                return;
            }
        }

        private void TxtBoxFilterByKeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the entered character is not a digit and not a control character (like Backspace)          
            // Cancel the keypress event
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }




        

        private void txtBoxFilteruser_TextChanged(object sender, EventArgs e)
        {
            _FilterData();
          //  dgvGetAllUsers.DataSource = clsUser.FilterData(cmbBoxFilterUsers.SelectedItem.ToString(), txtBoxFilteruser.Text);
        }

        private void cmbBoxIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterValue = "";
            switch(cmbBoxIsActive.Text)
            {
                case "All":
                    FilterValue = "";
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }
            if (cmbBoxIsActive.Text == "All")
                _dtAllUsers.DefaultView.RowFilter = "";
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", "IsActive", FilterValue); 
            
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddNewUser frmAddUser = new frmAddNewUser();            
            frmAddUser.ShowDialog();
        }

        private void TSMEdit_Click(object sender, EventArgs e)
        {
            frmAddNewUser frm = new frmAddNewUser((int)dgvGetAllUsers.CurrentRow.Cells[0].Value);           
            frm.ShowDialog();
            
        }

        private void TSMDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this User?","Confirmation",
                MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                if (clsUser.DeleteUser((int)dgvGetAllUsers.CurrentRow.Cells[0].Value) == true) 
                {
                    MessageBox.Show("User deleted successfully ");
                    _RefreshUserList();
                }
                else
                    MessageBox.Show("User was failed to delete");
            }
        }

        private void TSMChangePassword_Click(object sender, EventArgs e)
        {
            frmChangeUserPassword frm = new frmChangeUserPassword((int)dgvGetAllUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void TSMshowDetails_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo((int)dgvGetAllUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void TSMaddNewUser_Click(object sender, EventArgs e)
        {
            frmAddNewUser frmAddUser = new frmAddNewUser();
            frmAddUser.ShowDialog();
        }
    }
}
