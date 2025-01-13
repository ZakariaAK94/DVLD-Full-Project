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

namespace DVLD.Tests
{
    public partial class frmListTestAppointment : Form
    {
        //stDLApplication _DLApplicationStruct1;
        //stTestAppointment _TestAppointmentStruct1;
        //private int _TestAppointmentID = -1;
        //private clsTestAppointments _TestAppointment;
        //private clsTests _Test;
        private DataTable _dtLicenseTestAppointments;       
        private clsTestTypes.enTestType _TestTypeID;
        private int _LocalDrivingLicenseApplicationID = -1;
        public frmListTestAppointment(int LocalDrivingLicenseApplicationID,clsTestTypes.enTestType TestTypeID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            //_DLApplicationStruct1 = _MyStruct;
            // //ucScheduleTests2.SetValueToStruct(_DLApplicationStruct1);
            //_TestAppointmentStruct1._LocalDrivingLicenseApplicationID = _DLApplicationStruct1._LocalDrivingLicenseApplicationID;
            //_TestAppointmentStruct1._ClassName = _DLApplicationStruct1._ClassName;
            //_TestAppointmentStruct1._FullName = _DLApplicationStruct1._FullName;
            //_TestAppointmentStruct1._PaidFees = _DLApplicationStruct1._ApplicationFees;
            //_TestAppointmentStruct1._PassTestCount = _DLApplicationStruct1._PassedTestsCount;
            //_TestAppointmentStruct1._ApplicationID = _DLApplicationStruct1._ApplicationID;
            _TestTypeID = TestTypeID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // RefreshedDataAfterVisionTest?.Invoke(); // I already used NotifyDatachanged method
            this.Close();
        }

        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestTypeID)
            {
                case clsTestTypes.enTestType.VisionTest:
                    {
                        pBTypeOFTest.Image = DVLD.Properties.Resources.Vision_512;
                        lblTitleOfTheTest.Text = "Vision Test Appointments";
                        this.Text = lblTitleOfTheTest.Text;
                        break;
                    }
                case clsTestTypes.enTestType.WrittenTest:
                    {
                        pBTypeOFTest.Image = DVLD.Properties.Resources.Written_Test_512;
                        lblTitleOfTheTest.Text = "Written Test Appointments";
                        this.Text = lblTitleOfTheTest.Text;
                        break;
                    }
                case clsTestTypes.enTestType.StreetTest:
                    {
                        pBTypeOFTest.Image = DVLD.Properties.Resources.driving_test_512;
                        lblTitleOfTheTest.Text = "Street Test Appointments";
                        this.Text = lblTitleOfTheTest.Text;
                        break;
                    }
            }
        }

        private void frmListTestAppointment_Load(object sender, EventArgs e)
        {
            _LoadTestTypeImageAndTitle();
            ucDrivingLicenseApplication1.LoadApplicationInfoByLocalDrivingLicenseID(_LocalDrivingLicenseApplicationID);
            _dtLicenseTestAppointments = clsTestAppointments.GetApplicationTestAppointmentsPerTestType(_LocalDrivingLicenseApplicationID, _TestTypeID);
            dgvCurrentAppoint.DataSource = _dtLicenseTestAppointments;

            lblNbrOfRecords.Text = dgvCurrentAppoint.Rows.Count.ToString();

            if(dgvCurrentAppoint.Rows.Count >0)
            {
                dgvCurrentAppoint.Columns[0].HeaderText = "Appointment ID";
                dgvCurrentAppoint.Columns[1].HeaderText = "Appointment Date";
                dgvCurrentAppoint.Columns[2].HeaderText = "Paid Fees";
                dgvCurrentAppoint.Columns[3].HeaderText = "Is Locked";
            }
             
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplications localDrivingLicenseApplication = 
                clsLocalDrivingLicenseApplications.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
            // 1- we check if the peron had an active appointment
            if (localDrivingLicenseApplication.IsThereAnActiveScheduleTest(_TestTypeID))
            {
                MessageBox.Show("Person Already has an active appointment for this test,you can add an appointment for this test","Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // 2- we check if there isno't any test appointment means new
            clsTests LastTest = clsTests.FindlastTestByPersonIDAndTestTypeIDAndClassLicenseID(localDrivingLicenseApplication.ApplicantPersonID,
                _TestTypeID, localDrivingLicenseApplication.LicenseClassID);
            if(LastTest == null)
            {
                frmScheduleTest frm1 = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestTypeID);
                frm1.ShowDialog();
                frmListTestAppointment_Load(null, null);
                return;
            }
            // 3- we check two points if the person has passed the test or failed

            if(LastTest.TestResult)
            {
                MessageBox.Show("Person Already has passed the test, you can't retake it", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            frmScheduleTest frm2 = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestTypeID);
            frm2.ShowDialog();
            frmListTestAppointment_Load(null, null);


            //_GetLastRowInDataGridViewD();
            //if (_TestAppointmentID != -1)
            //{
            //    _TestAppointment = clsTestAppointments.FindByDriverID(_TestAppointmentID);
            //    _Test = clsTests.FindByTestID(_TestAppointmentID);
            //}
            //else
            //{
            //    _TestAppointment = new clsTestAppointments();
            //    _Test = new clsTests();
            //}
            //if (_Test != null && _TestAppointment.IsLocked == true)
            //{
            //    if (_Test.TestResult == false)
            //    {
            //        // create new 
            //        //_TestAppointmentStruct1.Trial++;
            //        //frmScheduleTest frm = new frmScheduleTest(_TestAppointmentStruct1,_TestTypeID);
            //        //frm.TestAppointmentID = _TestAppointmentID;
            //        //frm.TakeNewAppointement();
            //        //frm.DataAppointmentRefreshed += _UpdateDataGridAfterChanging;
            //        //frm.ShowDialog();
            //        //return;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Person has already passed the test", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //        return;
            //    }
            //}
            //else if (_TestAppointmentID != -1 && _TestAppointment.IsLocked == false)
            //{
            //    MessageBox.Show("Person has already an active appointment for this test,You can't add new appointment", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            //    return;
            //}
            //else
            //{
            //    //frmScheduleTest frm = new frmScheduleTest(_TestAppointmentStruct1,_TestTypeID);
            //    //frm.TestAppointmentID = _TestAppointmentID;
            //    ////frm.TakeNewAppointement();
            //    //frm.DataAppointmentRefreshed += _UpdateDataGridAfterChanging;
            //    //frm.ShowDialog();
            //    return;
            //}


        }



        //public void UpdateDataGridAfterChanging()
        //{
        //    _UpdateDataGridAfterChanging();
        //}        
        
        //public void _GetListDataAppointmentByDLApplicationID()
        //{
        //    if (dgvCurrentAppoint.RowCount != 0)
        //    {
        //        _TestAppointmentStruct1._TestAppointmentID = (int)dgvCurrentAppoint.CurrentRow.Cells[0].Value;
        //        _TestAppointmentID = (int)dgvCurrentAppoint.CurrentRow.Cells[0].Value;
        //        _TestAppointmentStruct1._AppointmentDate = (DateTime)dgvCurrentAppoint.CurrentRow.Cells[1].Value;
        //        _TestAppointmentStruct1._PaidFees = (float)dgvCurrentAppoint.CurrentRow.Cells[2].Value;
        //        _TestAppointmentStruct1._Islocked = (bool)dgvCurrentAppoint.CurrentRow.Cells[3].Value;
        //        lblNbrOfRecords.Text = dgvCurrentAppoint.RowCount.ToString();
        //        _TestAppointmentStruct1.Trial = dgvCurrentAppoint.RowCount - 1;                
        //        return;
        //    }
        //    _TestAppointmentStruct1._TestAppointmentID = _TestAppointmentID;
         
        //}
        //public void _GetLastRowInDataGridViewD()
        //{
        //    if (dgvCurrentAppoint.RowCount != 0)
        //    {
        //        _TestAppointmentStruct1._TestAppointmentID = (int)dgvCurrentAppoint.Rows[0].Cells[0].Value;                
        //        _TestAppointmentID = (int)dgvCurrentAppoint.Rows[0].Cells[0].Value;
        //        _TestAppointmentStruct1._AppointmentDate = (DateTime)dgvCurrentAppoint.Rows[0].Cells[1].Value;
        //        _TestAppointmentStruct1._PaidFees = (float)dgvCurrentAppoint.Rows[0].Cells[2].Value;
        //        _TestAppointmentStruct1._Islocked = (bool)dgvCurrentAppoint.Rows[0].Cells[3].Value;
        //        lblNbrOfRecords.Text = dgvCurrentAppoint.RowCount.ToString();
        //        _TestAppointmentStruct1.Trial = dgvCurrentAppoint.RowCount - 1;
        //        return;
        //    }
        //    _TestAppointmentStruct1._TestAppointmentID = _TestAppointmentID;            
        //}
       
        private void tsmEdit_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvCurrentAppoint.CurrentRow.Cells[0].Value;
            frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID,_TestTypeID,TestAppointmentID);
            frm.Show();
            frmListTestAppointment_Load(null, null);
           // _GetListDataAppointmentByDLApplicationID();
          //  _TestAppointmentStruct1.Trial -= dgvCurrentAppoint.CurrentRow.Index;
          //  frmScheduleTest frm = new frmScheduleTest(_TestAppointmentStruct1,_TestTypeID); 
          //  frm.TestAppointmentID = _TestAppointmentID;
          ////  frm.ShowTestInformation();
          //  frm.DataAppointmentRefreshed += _UpdateDataGridAfterChanging;            
          //  frm.ShowDialog();
        }
        private void tsmTakeTest_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvCurrentAppoint.CurrentRow.Cells[0].Value;

            frmTakeTest frm = new frmTakeTest(TestAppointmentID,_TestTypeID);
            frm.Show(); 
            frmListTestAppointment_Load(null,null);
            //_GetListDataAppointmentByDLApplicationID();
            //frmTakeTest frm = new frmTakeTest(_TestAppointmentStruct1,_TestTypeID);
            //frm.DataSent += Frm_DataSent;
            //frm.Show();

        }
        //private void Frm_DataSent(stTestAppointment TestAppointmentStruct)
        //{
        //    _TestAppointment = clsTestAppointments.FindByDriverID(TestAppointmentStruct._TestAppointmentID);
        //    _TestAppointment.IsLocked = TestAppointmentStruct._Islocked;
        //    if (_TestAppointment.Save())
        //    {
        //        MessageBox.Show("TestAppointment updated successfully!!", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);               
        //    }
        //    else
        //    {
        //        MessageBox.Show("TestAppointment failed to add!!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        //    }
        //    _UpdateDataGridAfterChanging();
        //    _DLApplicationStruct1._PassedTestsCount = TestAppointmentStruct._PassTestCount;
        //    //ucScheduleTests2.SetValueToStruct(_DLApplicationStruct1);
        //    //ucScheduleTests2.FillApplicationInfo();
        //}
        //private void frmVisionTestAppointment_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    NotifyDataChanged();
        //}
        //private void NotifyDataChanged()
        //{
        //    // If other forms are open, you can call a method on them to refresh data
        //    // Example: if you have MainForm and it has a method called RefreshData()
        //    if (Application.OpenForms["frmLocalDrivingLicenseApplications"] != null)
        //    {
        //      //  ((frmLocalDrivingLicenseApplications)Application.OpenForms["frmLocalDrivingLicenseApplications"]).RefreshList();
        //    }
        //}     
        //private void dgvCurrentAppoint_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if ((bool)dgvCurrentAppoint.CurrentRow.Cells[3].Value)
        //    {
        //        tsmTakeTest.Enabled = false;
        //    }
        //    else
        //        tsmTakeTest.Enabled = true;

        //}
    }
    
}
