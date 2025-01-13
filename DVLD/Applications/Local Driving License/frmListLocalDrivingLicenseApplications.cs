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
using DVLD.People;
using DVLD.Applications;
using DVLD.Drivers;
using DVLD.Licenses;
using DVLD.Tests;
using DVLD.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.Tests
{
    public partial class frmListLocalDrivingLicenseApplications : Form
    {
        private DataTable _dtAllLocalDrivingLicenseApp = clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplications();
        //private clsApplications _Application;
        //private clsApplicationTypes _ApplicationType;
        //private clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplication;
        //stDLApplication _CurrentDLApplicationStruct3;
        public frmListLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }
        private void frmListLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            dgvLocalDrivingLicenseApplications.DataSource = _dtAllLocalDrivingLicenseApp;
            if (dgvLocalDrivingLicenseApplications.Rows.Count > 0)
            {
                dgvLocalDrivingLicenseApplications.Columns["LocalDrivingLicenseApplicationID"].HeaderText = "L.D.L.AppID";
                dgvLocalDrivingLicenseApplications.Columns["ClassName"].HeaderText = "Driving Class";
                dgvLocalDrivingLicenseApplications.Columns["NationalNo"].HeaderText = "National No";
                dgvLocalDrivingLicenseApplications.Columns["FullName"].HeaderText = "Full Name";
                dgvLocalDrivingLicenseApplications.Columns["ApplicationDate"].HeaderText = "Application Date";
                dgvLocalDrivingLicenseApplications.Columns["PassedTestCount"].HeaderText = "Passed Tests";
            }
            cmbBoxFilterBy.SelectedIndex = 0;
            lblNbrOfLocalDrivingLicesneApplications.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
        }
       

        private void tsmShowApplicationDetails_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplicationInfo frm = new frmLocalDrivingLicenseApplicationInfo((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            frm.Show();
            frmListLocalDrivingLicenseApplications_Load(null, null);
        }     

        //private void _FillInfoData()
        //{
            
        //    /* I read from dgvLocalDrivingLicense to stDLApplication
        //    MyStructInfo._LocalDrivingLicenseApplicationID = ;
        //    MyStructInfo._ClassName = (string)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[1].Value;
        //    MyStructInfo._NationalNo = (string)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[2].Value;
        //    MyStructInfo._FullName = (string)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[3].Value;
        //    MyStructInfo._ApplicationDate = (DateTime)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[4].Value;            
        //    MyStructInfo._PassedTestsCount = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[5].Value;
        //    switch((string)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[6].Value)
        //    {
        //        case "New":
        //            MyStructInfo._ApplicationStatus = 1; break;
        //        case "Cancelled":
        //            MyStructInfo._ApplicationStatus = 2; break;
        //        case "Completed":
        //            MyStructInfo._ApplicationStatus = 3; break;
        //    }*/
        //    // I fill _OldApplication with Data
        //    //_LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.FindByDriverID(_CurrentDLApplicationStruct3._ApplicationID);
        //    /*MyStructInfo._ApplicationID = _LocalDrivingLicenseApplication.ApplicationID;
        //    MyStructInfo._ClassFees = clsLicenseClasses.FindByDriverID(_LocalDrivingLicenseApplication.LicenseClassID).ClassFees;
        //    _Application = clsApplications.FindBaseApplication(MyStructInfo._ApplicationID);
        //    MyStructInfo._ApplicantPersonID = _Application.ApplicantPersonID;
        //    _ApplicationType = clsApplicationTypes.FindByDriverID(_Application.ApplicationTypeID);           
        //    MyStructInfo._LastStatusDate = _Application.LastStatusDate;
        //    //I fill _ApplicationType with Data
        //    MyStructInfo._ApplicationTypeID = _ApplicationType.ApplicationTypeID;
        //    MyStructInfo._ApplicationTypeTitle = _ApplicationType.ApplicationTypeTitle;
        //    MyStructInfo._ApplicationFees = _ApplicationType.ApplicationFees;
        //    // UserName came from Login form
        //    MyStructInfo._CurrentUserName = clsGlobal.CurrentUser.UserName;*/
        //}
        
        private void cmbBoxFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBoxFilterBy.Visible = (cmbBoxFilterBy.Text != "None");

            if(txtBoxFilterBy.Visible)
            {
                txtBoxFilterBy.Text = "";
                txtBoxFilterBy.Focus();
            }

            _dtAllLocalDrivingLicenseApp.DefaultView.RowFilter = "";
            lblNbrOfLocalDrivingLicesneApplications.Text= _dtAllLocalDrivingLicenseApp.Rows.Count.ToString();
           // _FilterColumnName();
        }

        private void txtBoxFilterBy_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cmbBoxFilterBy.Text)
            {
                case "Local Driving License ApplicationID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;
                case "National No":
                    FilterColumn = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Status":
                    FilterColumn = "Status";
                    break;
                default:
                    FilterColumn = "";
                    break;
            }
            //reset the filters in case nothing selected or filter value contains nothing
            txtBoxFilterBy.Visible = (cmbBoxFilterBy.Text != "None");
            if (cmbBoxFilterBy.Text.Trim() == "None" || txtBoxFilterBy.Text.Trim() == "")
            {
                _dtAllLocalDrivingLicenseApp.DefaultView.RowFilter = "";
                lblNbrOfLocalDrivingLicesneApplications.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "LocalDrivingLicenseApplicationID")
            {
                // here we deal with integer and not string
                _dtAllLocalDrivingLicenseApp.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtBoxFilterBy.Text);
            }
            else
            {
                _dtAllLocalDrivingLicenseApp.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", FilterColumn, txtBoxFilterBy.Text.Trim());
            }
            lblNbrOfLocalDrivingLicesneApplications.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
        }

        private void tsmEditApplication_Click(object sender, EventArgs e)
        {
            frmAddOrUpdateNewLocalDrivingLicenseApplication frm = new frmAddOrUpdateNewLocalDrivingLicenseApplication((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListLocalDrivingLicenseApplications_Load(null, null);
        }

        private void txtBoxFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbBoxFilterBy.Text == "Local Driving License ApplicationID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
     

        private void btnAddNewLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            frmAddOrUpdateNewLocalDrivingLicenseApplication frm = new frmAddOrUpdateNewLocalDrivingLicenseApplication();
            frm.ShowDialog();
            frmListLocalDrivingLicenseApplications_Load(null,null);
            
        }
        private void tsmcancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {                 
            if (MessageBox.Show("Are you sure you want to cancel this Application", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                clsLocalDrivingLicenseApplications LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.FindByLocalDrivingAppLicenseID((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
                if(LocalDrivingLicenseApplication != null)
                {
                    if (LocalDrivingLicenseApplication.Cancel())
                    {
                        MessageBox.Show("Application cancelled successfully ", "Cancellation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        frmListLocalDrivingLicenseApplications_Load(null,null);
                    }
                    else
                    {
                        MessageBox.Show("Application failed to cancel ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    }
                }               
            }
            else
                return;

            
        }

        private void tsmDeleteApplication_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel this Application", "Confirmation",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                clsLocalDrivingLicenseApplications LocalDrivingLicenseApplication = 
                    clsLocalDrivingLicenseApplications.FindByLocalDrivingAppLicenseID((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
                if (LocalDrivingLicenseApplication != null)
                {
                    if (LocalDrivingLicenseApplication.Delete())
                    {
                        MessageBox.Show("Application deleted successfully ", "Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        frmListLocalDrivingLicenseApplications_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Application failed to delete ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }
                }
                else
                    return;
            }
        }
        
        private void _ReturntsmScheduleTestToTheInitialForm()
        {
            tsmIssueDrivingLicense.Enabled = false;
            tsmScheduleTests.Enabled = true;
            tsmVisionTest.Enabled = true;
            tsmWrittenTest.Enabled = false;
            tsmPracticalTest.Enabled = false;          
            tsmShowLicense.Enabled = false;          

        }
        private void _CheckDLApplicationStatus()
        {
            _ReturntsmScheduleTestToTheInitialForm();
            byte AplicationStatus=0;
            
            switch ((string)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[6].Value)
            {
                case "New":
                    AplicationStatus = 1; break;
                case "Cancelled":
                    AplicationStatus = 2; break;
                case "Completed":
                    AplicationStatus = 3; break;
            }
            int PassedTestsCount = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[5].Value;
            if (AplicationStatus == 2)
            {
                         
                tsmShowLicense.Enabled = true;
                tsmEditApplication.Enabled = false;
                tsmDeleteApplication.Enabled = true;
                tsmCancelApplication.Enabled=false;
                tsmScheduleTests.Enabled = false;
                tsmIssueDrivingLicense.Enabled = false;
                tsmShowLicense.Enabled = false;
                return;
            }
            else if(AplicationStatus == 1)
            {
                tsmScheduleTests.Enabled = true;
                tsmCancelApplication.Enabled = true;
                tsmEditApplication.Enabled = true;
                tsmDeleteApplication.Enabled = true;
                if (PassedTestsCount == 0)
                {
                    tsmVisionTest.Enabled = true;
                    return;
                }
                else if (PassedTestsCount == 1)
                {
                    tsmVisionTest.Enabled = false;
                    tsmWrittenTest.Enabled = true;
                    return;
                }
                else if (PassedTestsCount == 2)
                {
                    tsmVisionTest.Enabled = false;
                    tsmWrittenTest.Enabled = false;
                    tsmPracticalTest.Enabled = true;
                    return;
                }
                else
                {
                    tsmScheduleTests.Enabled = false;
                    tsmIssueDrivingLicense.Enabled = true;
                    return;
                }
            }
            else
            {
                tsmScheduleTests.Enabled = false;
                tsmCancelApplication.Enabled = true;
                tsmEditApplication.Enabled = true;
                tsmEditApplication.Enabled = false;
                tsmIssueDrivingLicense.Enabled = false;
                tsmCancelApplication.Enabled = false;
                tsmEditApplication.Enabled = false;
                tsmShowLicense.Enabled = true;
                tsmDeleteApplication.Enabled = false;
                return;
            }

        }        
       
       
       
        private void _ShowTest(clsTestTypes.enTestType TestTypeID)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
           //_FillMyStruct(ref _CurrentDLApplicationStruct3);
          // frmTestAppointment Test = new frmTestAppointment(LocalDrivingLicenseApplicationID, TestTypeID);            
          // Test.Show();
            frmListLocalDrivingLicenseApplications_Load(null, null);
        }
        private void tsmVisionTest_Click(object sender, EventArgs e)
        {
            /*int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            clsTestAppointments Appointment = clsTestAppointments.GetLastTestAppointment(LocalDrivingLicenseApplicationID, 
                clsTestTypes.enTestType.VisionTest);

            if(Appointment == null)
            {
                MessageBox.Show("No vision test appointment found!!","Set a vision test",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);

                return;
            }

            frmTakeTest TakeTest = new frmTakeTest(Appointment.TestAppointmentID, clsTestTypes.enTestType.VisionTest);
            TakeTest.Show(); */

            _ShowTest(clsTestTypes.enTestType.VisionTest);
        }
        private void tsmWrittenTest_Click(object sender, EventArgs e)
        {
            /*int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            if (!clsLocalDrivingLicenseApplications.DoesPassTestType(LocalDrivingLicenseApplicationID, clsTestTypes.enTestType.VisionTest))
            {
                MessageBox.Show("Person should pass the first test 'Vision Test' first!!", "Not Allowed",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            clsTestAppointments Appointment = clsTestAppointments.GetLastTestAppointment(LocalDrivingLicenseApplicationID,
                clsTestTypes.enTestType.WrittenTest);

            if (Appointment == null)
            {
                MessageBox.Show("No writen test appointment found!!", "Set a written test",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            frmTakeTest TakeTest = new frmTakeTest(Appointment.TestAppointmentID, clsTestTypes.enTestType.WrittenTest);
            TakeTest.Show();*/

            _ShowTest(clsTestTypes.enTestType.WrittenTest);
        }        
        private void tsmPracticalTest_Click(object sender, EventArgs e)
        {
            /*int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            if (!clsLocalDrivingLicenseApplications.DoesPassTestType(LocalDrivingLicenseApplicationID, clsTestTypes.enTestType.WrittenTest))
            {
                MessageBox.Show("Person should pass the second test 'Written Test' first!!", "Not Allowed",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsTestAppointments Appointment = clsTestAppointments.GetLastTestAppointment(LocalDrivingLicenseApplicationID,
                clsTestTypes.enTestType.StreetTest);

            if (Appointment == null)
            {
                MessageBox.Show("No street test appointment found!!", "Set a street test",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            frmTakeTest TakeTest = new frmTakeTest(Appointment.TestAppointmentID, clsTestTypes.enTestType.StreetTest);
            TakeTest.Show();*/

            _ShowTest(clsTestTypes.enTestType.StreetTest);
        }
        private void dgvLocalDrivingLicenseApplications_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            _CheckDLApplicationStatus();
        }

        private void tsmIssueDrivingLicense_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseAppliID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
           // _FillMyStruct(ref _CurrentDLApplicationStruct3);
          // frmIssueDriverLicense frm = new frmIssueDriverLicense(LocalDrivingLicenseAppliID);           
          // frm.Show();
            frmListLocalDrivingLicenseApplications_Load(null, null);
        }

        private void tsmShowLicense_Click(object sender, EventArgs e)
        {
            //_FillMyStruct(ref _CurrentDLApplicationStruct3);
            frmShowLicenseInfo frm = new frmShowLicenseInfo((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            frm.Show();
        }

        private void tsmShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            //int LocalDrivingLicenseAppliID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            //// _FillMyStruct(ref _CurrentDLApplicationStruct3);
            //clsLocalDrivingLicenseApplications localDrivingLicenseApplication = clsLocalDrivingLicenseApplications.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseAppliID);  
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            frm.Show();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmsApplications_Opening(object sender, CancelEventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplications localDrivingLicenseApplication =
                clsLocalDrivingLicenseApplications.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);
            int TotalPassedTests = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[5].Value;

            bool LicenseExist = localDrivingLicenseApplication.IsLicenseIssued();

            tsmIssueDrivingLicense.Enabled = !LicenseExist && TotalPassedTests == 3;

            tsmShowLicense.Enabled = !LicenseExist;
            tsmEditApplication.Enabled =
                !LicenseExist && localDrivingLicenseApplication.ApplicationStatus == clsApplications.enApplicationStatus.New;
            tsmCancelApplication.Enabled = localDrivingLicenseApplication.ApplicationStatus == clsApplications.enApplicationStatus.New;
            tsmScheduleTests.Enabled = !LicenseExist;
            //We only allow delete incase the application status is new not complete or Cancelled.
            tsmDeleteApplication.Enabled= localDrivingLicenseApplication.ApplicationStatus == clsApplications.enApplicationStatus.New;

            // enable and disable sub menu for schedule tests

            bool PassedVisionTest = localDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.VisionTest);
            bool PassedWrittenTest = localDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.WrittenTest);
            bool PassedStreetTest = localDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.StreetTest);

            tsmScheduleTests.Enabled = (!PassedVisionTest || !PassedWrittenTest || !PassedStreetTest) &&
                (localDrivingLicenseApplication.ApplicationStatus == clsApplications.enApplicationStatus.New);
            if(tsmScheduleTests.Enabled)
            {
                tsmVisionTest.Enabled = !PassedVisionTest;
                tsmWrittenTest.Enabled = PassedVisionTest && !PassedWrittenTest;
                tsmVisionTest.Enabled = PassedWrittenTest && !PassedStreetTest;
            }

        }

        /* private void txtBoxFilterBy_TextChanged_1(object sender, EventArgs e)
         {
             //dgvLocalDrivingLicenseApplications.DataSource = //clsLocalDrivingLicenseApplicationsView.FilterData(cmbBoxFilterBy.SelectedItem.ToString(), txtBoxFilterBy.Text);
             lblNbrOfLocalDrivingLicesneApplications.Text = dgvLocalDrivingLicenseApplications.RowCount.ToString();
         }*/

    }
}




