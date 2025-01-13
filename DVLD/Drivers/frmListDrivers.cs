using DVLD.Licenses;
using DVLD.People;
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

namespace DVLD.Drivers
{
    public partial class frmListDrivers : Form
    {
        private DataTable _dtAllDrivers = clsDrivers.GetAllDrivers();
        public frmListDrivers()
        {
            InitializeComponent();
        }     

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _FilterName()
        {
            string FilterColumnName = "";
            switch(cmbBoxFilterDrivers.Text)
            {
                case "Driver ID":
                    FilterColumnName = "DriverID";
                    break;
                case "Person ID":
                    FilterColumnName = "PersonID";
                    break;
                case "National No":
                    FilterColumnName = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumnName = "FullName";
                    break;
                default:
                    FilterColumnName = "";
                    break;
            }
            if(FilterColumnName == "None" || txtBoxFilterDriver.Text.Trim() == "")
            {
                _dtAllDrivers.DefaultView.RowFilter = " ";
            }
            else if(FilterColumnName == "DriverID" || FilterColumnName == "PersonID")                
                _dtAllDrivers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumnName,txtBoxFilterDriver.Text.Trim());
            else
                _dtAllDrivers.DefaultView.RowFilter = string.Format("{0} like '{1}%'", FilterColumnName,txtBoxFilterDriver.Text.Trim());

            lblNmbrOfDrivers.Text = dgvGetAllDrivers.Rows.Count.ToString();
        }
        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            //_RefreshDriversList();
            dgvGetAllDrivers.DataSource = _dtAllDrivers;  
            if (dgvGetAllDrivers.Rows.Count > 0)
            {
                dgvGetAllDrivers.Columns["DriverID"].HeaderText = "Driver ID";
                dgvGetAllDrivers.Columns["PersonID"].HeaderText = "Person ID";
                dgvGetAllDrivers.Columns["NationalNo"].HeaderText = "National No";
                dgvGetAllDrivers.Columns["FullName"].HeaderText = "Full Name";
            }
            lblNmbrOfDrivers.Text = dgvGetAllDrivers.Rows.Count.ToString();
            cmbBoxFilterDrivers.SelectedIndex = 0;
            dgvGetAllDrivers.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvGetAllDrivers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBoxFilterDriver_TextChanged(object sender, EventArgs e)
        {
            // dgvGetAllDrivers.DataSource = clsDriversView.FilterData(cmbBoxFilterDrivers.SelectedItem.ToString(), txtBoxFilterDriver.Text);
            _FilterName();
        }

        private void txtBoxFilterDriver_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cmbBoxFilterDrivers.Text == "Person ID" || cmbBoxFilterDrivers.Text == "Driver ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void cmbBoxFilterDrivers_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBoxFilterDriver.Visible = (cmbBoxFilterDrivers.Text != "None");
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo((int)dgvGetAllDrivers.CurrentRow.Cells[1].Value);
            frm.Show();
        }

        private void showPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory((int)dgvGetAllDrivers.CurrentRow.Cells[1].Value);
            frm.Show();
        }
    }
}
