using DVLD_Bussiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using DVLD.Login;
using DVLD.Applications;
using DVLD.Licenses;
using DVLD.People;
using DVLD.Drivers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Classes;
using System.Security.Policy;

namespace DVLD.Applications
{
    public partial class frmInternationalDrivingLicenseApplications : Form
    {
        //stDLApplication _CurrentDLApplicationStruct3;
        //private clsPerson _Person;
        //private clsLicenses _License;
        //private clsApplications _Application;
        //private clsApplicationTypes _ApplicationType;
        // private clsInternationalLicenses _InternationalLicense;
        private DataTable _dtInternationalLicenseApplications;    

        public frmInternationalDrivingLicenseApplications()
        {
            InitializeComponent();
        }
        private void frmInternationalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _dtInternationalLicenseApplications = clsInternationalLicenses.GetAllInternationalLicenses();
            dgvInterDrivingLicenseApplications.DataSource = _dtInternationalLicenseApplications;
            lblNbrOfInternationalDrivingLicesneApplications.Text = dgvInterDrivingLicenseApplications.Rows.Count.ToString();
            if (dgvInterDrivingLicenseApplications.Rows.Count > 0)
            {
                dgvInterDrivingLicenseApplications.Columns[0].HeaderText = "Int.License ID";
                dgvInterDrivingLicenseApplications.Columns[0].Width = 160;

                dgvInterDrivingLicenseApplications.Columns[1].HeaderText = "Application ID";
                dgvInterDrivingLicenseApplications.Columns[1].Width = 150;

                dgvInterDrivingLicenseApplications.Columns[2].HeaderText = "Driver ID";
                dgvInterDrivingLicenseApplications.Columns[2].Width = 130;

               dgvInterDrivingLicenseApplications.Columns[3].HeaderText = "L.License ID";
                dgvInterDrivingLicenseApplications.Columns[3].Width = 130;

               dgvInterDrivingLicenseApplications.Columns[4].HeaderText = "Issue Date";
                dgvInterDrivingLicenseApplications.Columns[4].Width = 180;

               dgvInterDrivingLicenseApplications.Columns[5].HeaderText = "Expiration Date";
                dgvInterDrivingLicenseApplications.Columns[5].Width = 180;

               dgvInterDrivingLicenseApplications.Columns[6].HeaderText = "Is Active";
                dgvInterDrivingLicenseApplications.Columns[6].Width = 120;
            }               
            cmbBoxFilterBy.SelectedIndex = 0;
            txtBoxFilterBy.Visible = false;
            cmbBoxIsActive.Visible = false;
        }

        private void _FilterColumns()
        {
            string FilterName = "";
            switch (cmbBoxFilterBy.Text)
            {
                case "International License ID":
                    FilterName = "InternationalLicenseID";
                    break;
                case "Application ID":
                    FilterName = "ApplicationID";
                    break;
                case "Driver ID":
                    FilterName = "DriverID";
                    break;
                case "Local License ID":
                    FilterName = "LocalLicenseID";
                    break;
                case "Is Active":
                    FilterName = "IsActive";
                    break;
                default:
                    FilterName = "None";
                    break;
            }

            if(cmbBoxFilterBy.Text == "None" || txtBoxFilterBy.Text.Trim() =="")
            {
                _dtInternationalLicenseApplications.DefaultView.RowFilter = "";
                lblNbrOfInternationalDrivingLicesneApplications.Text = dgvInterDrivingLicenseApplications.Rows.Count.ToString();
                return;
            }
            
            _dtInternationalLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}",FilterName,txtBoxFilterBy.Text.Trim());
            lblNbrOfInternationalDrivingLicesneApplications.Text = dgvInterDrivingLicenseApplications.Rows.Count.ToString();
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmbBoxFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (cmbBoxFilterBy.Text == "None")
            {
                txtBoxFilterBy.Visible = false;
                cmbBoxIsActive.Visible = false;
            }
            else if(cmbBoxFilterBy.Text == "Is Active")
            {
                txtBoxFilterBy.Visible = false;
                cmbBoxIsActive.Visible = true;
            }else
            {
                txtBoxFilterBy.Visible = true;
                cmbBoxIsActive.Visible = false;
            }
        }
        private void btnAddNewInternationalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication frm = new frmNewInternationalLicenseApplication();            
            frm.ShowDialog();
            frmInternationalDrivingLicenseApplications_Load(null, null);

        }
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


        private void tsmShowPersonDetails_Click(object sender, EventArgs e)
        {
            int PersonID = clsDrivers.FindByDriverID((int)dgvInterDrivingLicenseApplications.CurrentRow.Cells[2].Value).PersonID;
            frmShowPersonInfo frm = new frmShowPersonInfo(PersonID);
            frm.Show();
        }
        private void tsmShowLicenseDetails_Click(object sender, EventArgs e)
        {
            //_FillMyStruct(ref _CurrentDLApplicationStruct3);
            int InterLicenseID = (int)dgvInterDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            frmShowInternationalLicesInfo frm = new frmShowInternationalLicesInfo(InterLicenseID);
            frm.Show();
        }      
   
        private void tsmShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            //_FillMyStruct(ref _CurrentDLApplicationStruct3);
            int PersonID = clsDrivers.FindByDriverID((int)dgvInterDrivingLicenseApplications.CurrentRow.Cells[2].Value).PersonID; ;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);// PersonID
            frm.Show();
        }

        private void txtBoxFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void txtBoxFilterBy_TextChanged(object sender, EventArgs e)
        {
            _FilterColumns();
        }

        private void cmbBoxIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterValue = "";
            switch(cmbBoxIsActive.Text.Trim()) 
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
            if(FilterValue == "")
            {
                _dtInternationalLicenseApplications.DefaultView.RowFilter = "";      
            }else
            {
                _dtInternationalLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}","IsActive", FilterValue);
            }

            lblNbrOfInternationalDrivingLicesneApplications.Text = _dtInternationalLicenseApplications.Rows.Count.ToString();
        }
        //private void _FillMyStruct(ref stDLApplication MyStructInfo)
        //{
        //    I read from dgvLocalDrivingLicense to stDLApplication
        //    _InternationalLicense = new clsInternationalLicenses();
        //    _InternationalLicense.InternationalLicenseID = (int)dgvInterDrivingLicenseApplications.CurrentRow.Cells[0].Value;
        //    _InternationalLicense.ApplicationID = (int)dgvInterDrivingLicenseApplications.CurrentRow.Cells[1].Value;
        //    _InternationalLicense.DriverID = (int)dgvInterDrivingLicenseApplications.CurrentRow.Cells[2].Value;
        //    _InternationalLicense.IssuedUsingLocalLicenseID = (int)dgvInterDrivingLicenseApplications.CurrentRow.Cells[3].Value;
        //    _InternationalLicense.IssueDate = (DateTime)dgvInterDrivingLicenseApplications.CurrentRow.Cells[4].Value;
        //    _InternationalLicense.ExpirationDate = (DateTime)dgvInterDrivingLicenseApplications.CurrentRow.Cells[5].Value;
        //    _InternationalLicense.IsActive = (bool)dgvInterDrivingLicenseApplications.CurrentRow.Cells[6].Value;
        //    I fill _OldApplication with Data
        //   _License = clsLicenses.FindLicenseInfoByLicenseID(_InternationalLicense.IssuedUsingLocalLicenseID);
        //    _Application = clsApplications.FindBaseApplication(_License.ApplicationID);
        //    MyStructInfo._ApplicationID = _Application.ApplicationID;
        //    _Person = clsPerson.Find(_Application.ApplicantPersonID);
        //    MyStructInfo._ApplicantPersonID = _Person.PersonID;
        //    MyStructInfo._ClassName = clsLicenseClasses.FindByLicenseClassID(_License.LicenseClassID).ClassName;
        //    MyStructInfo._FullName = _Person.FirstName + " " + _Person.SecondName + " " + _Person.ThirdName + " " + _Person.LastName;
        //    MyStructInfo._NationalNo = _Person.NationalNo;
        //    _ApplicationType = clsApplicationTypes.Find(_Application.ApplicationTypeID);
        //    MyStructInfo._LastStatusDate = _Application.LastStatusDate;
        //    //I fill _ApplicationType with Data
        //    MyStructInfo._ApplicationTypeID = _ApplicationType.ApplicationTypeID;
        //    MyStructInfo._ApplicationTypeTitle = _ApplicationType.ApplicationTypeTitle;
        //    MyStructInfo._ApplicationFees = _ApplicationType.ApplicationFees;
        //    / UserName came from Login form
        //    MyStructInfo._CurrentUserName = clsGlobal.CurrentUser.UserName;
        //}
    }
}




