using DVLD_Bussiness;
using static DVLD_Bussiness.clsLicenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Licenses.Controls
{
    public partial class ucDriverLicenses : UserControl
    {
        private int _DriverID;
        private clsDrivers _Driver;
        private DataTable _dtDriverLocalLicensesHistory;
        private DataTable _dtDriverInternationalLicensesHistory;
        public ucDriverLicenses()
        {
            InitializeComponent();
        }
        private void _LoadLocalLicenseInfo()
        {
            _dtDriverLocalLicensesHistory = clsLicenses.GetDriverLicenses(_DriverID);
            dgvLocalLicensesHistory.DataSource = _dtDriverLocalLicensesHistory; 
            lblNbrOfRecords.Text = dgvLocalLicensesHistory.Rows.Count.ToString();
            if(dgvLocalLicensesHistory.Rows.Count >0)
            {            
                
                dgvLocalLicensesHistory.Columns[0].HeaderText = "Lic.ID";
                dgvLocalLicensesHistory.Columns[0].Width = 110;

                dgvLocalLicensesHistory.Columns[1].HeaderText = "App.ID";
                dgvLocalLicensesHistory.Columns[1].Width = 110;

                dgvLocalLicensesHistory.Columns[2].HeaderText = "Class Name";
                dgvLocalLicensesHistory.Columns[2].Width = 325;

                dgvLocalLicensesHistory.Columns[3].HeaderText = "Issue Date";
                dgvLocalLicensesHistory.Columns[3].Width = 170;

                dgvLocalLicensesHistory.Columns[4].HeaderText = "Expiration Date";
                dgvLocalLicensesHistory.Columns[4].Width = 170;

                dgvLocalLicensesHistory.Columns[5].HeaderText = "Is Active";
                dgvLocalLicensesHistory.Columns[5].Width = 100;
            }
        }

        private void _LoadInternationalLicenseInfo()
        {
            _dtDriverInternationalLicensesHistory = clsLicenses.GetDriverInternationalLicenses(_DriverID);
            dgvInternationalLicenseHistory.DataSource = _dtDriverLocalLicensesHistory;
            lblNbrOfRecords.Text = dgvInternationalLicenseHistory.Rows.Count.ToString();
            if (dgvInternationalLicenseHistory.Rows.Count > 0)
            {
                dgvInternationalLicenseHistory.Columns[0].HeaderText = "Inter.Lic ID";
                dgvInternationalLicenseHistory.Columns[0].Width = 160;
                
                dgvInternationalLicenseHistory.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicenseHistory.Columns[1].Width = 130;
             
                dgvInternationalLicenseHistory.Columns[2].HeaderText = "L.License ID";
                dgvInternationalLicenseHistory.Columns[2].Width = 130;
              
                dgvInternationalLicenseHistory.Columns[3].HeaderText = "Issue Date";
                dgvInternationalLicenseHistory.Columns[3].Width = 232;
              
                dgvInternationalLicenseHistory.Columns[4].HeaderText = "Expiration Date";
                dgvInternationalLicenseHistory.Columns[4].Width = 232;
         
                dgvInternationalLicenseHistory.Columns[5].HeaderText = "Is Active";
                dgvInternationalLicenseHistory.Columns[5].Width = 100;

            }
        }

        public void LoadInfoByDriverID(int DriverID)
        {            
            _Driver = clsDrivers.FindByDriverID(DriverID);

            if( _Driver == null )
            {
                MessageBox.Show("No driver exist with ID "+DriverID,"Not Found",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            _DriverID = _Driver.DriverID;

            _LoadLocalLicenseInfo();
            _LoadInternationalLicenseInfo();
        }

        public void LoadInfoBypersonID(int PersonID)
        {
            _Driver = clsDrivers.FindByPersonID(PersonID);

            if (_Driver == null)
            {
                MessageBox.Show("No driver linked with person id " + PersonID, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _DriverID = _Driver.DriverID;

            _LoadLocalLicenseInfo();
            _LoadInternationalLicenseInfo();
        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo((int)dgvLocalLicensesHistory.CurrentRow.Cells[0].Value);
            frm.Show();
        }

        private void showInternationalLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowInternationalLicesInfo frm = new frmShowInternationalLicesInfo((int)dgvInternationalLicenseHistory.CurrentRow.Cells[0].Value);
            frm.Show();
        }

        public void Clear()
        {
            _dtDriverInternationalLicensesHistory.Clear();
            _dtDriverLocalLicensesHistory.Clear();
        }
    }
}
