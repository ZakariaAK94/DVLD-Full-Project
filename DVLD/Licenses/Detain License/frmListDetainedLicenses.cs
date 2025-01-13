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
using DVLD.Login;
using DVLD.Applications;
using DVLD.Licenses;
using DVLD.People;
using DVLD.Drivers;
using DVLD.Classes;
using System.Security.Policy;
using System.Xml.Linq;

namespace DVLD.Licenses
{
    public partial class frmListDetainedLicenses : Form
    {
        //private clsLicenses _License;
        //private clsApplications _Application;
        //private clsApplicationTypes _ApplicationType;
        ////private clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplication;
        //stDLApplication _CurrentDLApplicationStruct3;
        //private void _FillMyStruct(ref stDLApplication MyStructInfo)
        //{
        //    // I read from dgvLocalDrivingLicense to stDLApplication
        //    _License = clsLicenses.FindLicenseInfoByLicenseID((int)dgvListDetainedLicenses.CurrentRow.Cells[1].Value);
        //    _Application = clsApplications.FindBaseApplication(_License.ApplicationID);
        //    MyStructInfo._ApplicationID = _Application.ApplicationID;
        //    MyStructInfo._ApplicantPersonID = _Application.ApplicantPersonID;
        //    MyStructInfo._ClassName = clsLicenseClasses.FindByLicenseClassID(_License.LicenseClassID).ClassName;
        //    MyStructInfo._ApplicationDate = _Application.ApplicationDate;
        //    //MyStructInfo._ClassFees = clsLicenseClasses.FindByLicenseClassID(_License.LicenseClassID).ClassFees;
        //    _ApplicationType = clsApplicationTypes.Find(_Application.ApplicationTypeID);
        //    MyStructInfo._LastStatusDate = _Application.LastStatusDate;
        //    MyStructInfo._ApplicantPersonID = _Application.ApplicantPersonID;
        //    MyStructInfo._ApplicationTypeID = _ApplicationType.ApplicationTypeID;
        //    MyStructInfo._ApplicationTypeTitle = _ApplicationType.ApplicationTypeTitle;
        //    MyStructInfo._ApplicationFees = _ApplicationType.ApplicationFees;
        //    MyStructInfo._CurrentUserName = clsGlobal.CurrentUser.UserName;
        //}           

        private DataTable _dtListOfDetainedLicense;

        public frmListDetainedLicenses()
        {
            InitializeComponent();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtBoxFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbBoxFilterBy.Text.Trim() == "Detain ID" || cmbBoxFilterBy.Text.Trim() == "Release Application ID")
            {
                // Cancel the keypress event
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void _FilterColumn()
        {
            string FilterColumn = "";
            switch (cmbBoxFilterBy.Text.Trim())
            {
                case "Detain ID":
                    FilterColumn = "DetainID";
                    break;
                case "Is Released":
                    FilterColumn = "IsReleased";
                    break;
                case "National No":
                    FilterColumn = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Release Application ID":
                    FilterColumn = "ReleaseApplicationID";
                    break;
                default:
                    FilterColumn = "";
                    break;
            }
            if (FilterColumn == "None" || txtBoxFilterBy.Text.Trim() == "")
            {
                _dtListOfDetainedLicense.DefaultView.RowFilter = "";
                lblNbrOfDetainedLicesnes.Text = dgvListDetainedLicenses.RowCount.ToString();
                return;
            }
            else if (FilterColumn == "DetainID" || FilterColumn == "ReleaseApplicationID")
            {
                _dtListOfDetainedLicense.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtBoxFilterBy.Text.Trim());
                 lblNbrOfDetainedLicesnes.Text = dgvListDetainedLicenses.RowCount.ToString();
                return;
            }
            else
            {
                _dtListOfDetainedLicense.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtBoxFilterBy.Text.Trim());
                lblNbrOfDetainedLicesnes.Text = dgvListDetainedLicenses.RowCount.ToString();
                return;
            }

        }
        private void txtBoxFilterBy_TextChanged_1(object sender, EventArgs e)
        {
            _FilterColumn();
        }                            
       
        private void btnReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();            
            frm.Show();
            frmListDetainedLicenses_Load(null, null);
        }

        private void btnAddNewDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApplication frm = new frmDetainLicenseApplication();
            frm.ShowDialog();
            frmListDetainedLicenses_Load(null, null);
        }

        private void tsmShowPersonDetails_Click(object sender, EventArgs e)
        {
            string NationalNo = (string)dgvListDetainedLicenses.CurrentRow.Cells[6].Value;
            frmShowPersonInfo frm = new frmShowPersonInfo(NationalNo);
            frm.Show();
        }

        private void tsmShowLicenseDetails_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvListDetainedLicenses.CurrentRow.Cells[1].Value;
            frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
            frm.Show();
        }

        private void tsmShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            string NationalNo = (string)dgvListDetainedLicenses.CurrentRow.Cells[6].Value;
            //_FillMyStruct(ref _CurrentDLApplicationStruct3);
            frmShowPersonLicenseHistory frm = new 
                frmShowPersonLicenseHistory(clsPerson.Find(NationalNo).PersonID);
            frm.Show();
        }

        private void tsmReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvListDetainedLicenses.CurrentRow.Cells[1].Value;
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication(LicenseID);
            frm.Show();
            frmListDetainedLicenses_Load(null, null);

        }
        private void cmsApplications_Opening(object sender, CancelEventArgs e)
        {
            tsmReleaseDetainedLicense.Enabled = !(bool)dgvListDetainedLicenses.CurrentRow.Cells[3].Value;
        }

        private void frmListDetainedLicenses_Load(object sender, EventArgs e)
        {
            cmbBoxFilterBy.SelectedIndex = 0;
            _dtListOfDetainedLicense = clsDetainLicenses.GetAllDetainLicenses();
            dgvListDetainedLicenses.DataSource = _dtListOfDetainedLicense;
            if (dgvListDetainedLicenses.Rows.Count > 0)
            {
                dgvListDetainedLicenses.Columns[0].HeaderText = "D.ID";
                dgvListDetainedLicenses.Columns[0].Width = 90;

                dgvListDetainedLicenses.Columns[1].HeaderText = "L.ID";
                dgvListDetainedLicenses.Columns[1].Width = 90;

                dgvListDetainedLicenses.Columns[2].HeaderText = "D.Date";
                dgvListDetainedLicenses.Columns[2].Width = 140;

                dgvListDetainedLicenses.Columns[3].HeaderText = "Is Released";
                dgvListDetainedLicenses.Columns[3].Width = 90;

                dgvListDetainedLicenses.Columns[4].HeaderText = "Fine Fees";
                dgvListDetainedLicenses.Columns[4].Width = 90;

                dgvListDetainedLicenses.Columns[5].HeaderText = "Release Date";
                dgvListDetainedLicenses.Columns[5].Width = 140;

                dgvListDetainedLicenses.Columns[6].HeaderText = "N.No.";
                dgvListDetainedLicenses.Columns[6].Width = 90;

                dgvListDetainedLicenses.Columns[7].HeaderText = "Full Name";
                dgvListDetainedLicenses.Columns[7].Width = 320;

                dgvListDetainedLicenses.Columns[8].HeaderText = "Rlease App.ID";
                dgvListDetainedLicenses.Columns[8].Width = 150;


            }
            lblNbrOfDetainedLicesnes.Text = dgvListDetainedLicenses.RowCount.ToString();
            txtBoxFilterBy.Visible = false;
        }

        private void cmbBoxFilterBy_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbBoxFilterBy.Text.Trim() == "None")
            {
                txtBoxFilterBy.Visible = false;
                cmbIsRelease.Visible = false;
            }
            else if (cmbBoxFilterBy.Text.Trim() == "Is Released")
            {
                txtBoxFilterBy.Visible = false;
                cmbIsRelease.Visible = true;
            }
            else
            {
                txtBoxFilterBy.Visible = true;
                cmbIsRelease.Visible = false;
            }
        }

        private void cmbIsRelease_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColunm = "IsReleased";
            string FilterValue = cmbIsRelease.Text.Trim();

            switch(FilterValue)
            {
                case "All":
                    break;
                case "No":
                    FilterValue = "0";
                    break;
                case "Yes":
                    FilterValue = "1";
                    break; 
            }
            if (FilterValue == "All")
            {
                _dtListOfDetainedLicense.DefaultView.RowFilter = "";
                lblNbrOfDetainedLicesnes.Text = dgvListDetainedLicenses.RowCount.ToString();
                return;
            }

            _dtListOfDetainedLicense.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColunm, FilterValue);
            lblNbrOfDetainedLicesnes.Text = dgvListDetainedLicenses.RowCount.ToString();
        }
    }
}




