using DVLD.Classes;
using DVLD.Tests;
using DVLD_Bussiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Tests.Controls
{
    public partial class ucScheduleTests : UserControl
    {
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode = enMode.AddNew;

        public enum enCreationMode { FirstTimeSchedule = 0, RetakeTestSchedule = 1 }
        private enCreationMode _CreationMode = enCreationMode.FirstTimeSchedule;

        private clsTestAppointments _TestAppointment;
        private int _TestAppointmentID = -1;

        private clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplication;
        private int _LocalDrivingLicenseApplicationID = -1;

        private clsTestTypes.enTestType _TestTypeID = clsTestTypes.enTestType.VisionTest; 
        public clsTestTypes.enTestType TestTypeID
        {
            get
            {
                return _TestTypeID;
            }
            set
            {
                _TestTypeID = value;
                switch (_TestTypeID)
                {
                    case clsTestTypes.enTestType.VisionTest:
                        gBScheduleTest.Text = "Vision Test Appointment";
                        pboxTypeOfTest.Image = DVLD.Properties.Resources.Vision_512;
                        break;
                    case clsTestTypes.enTestType.WrittenTest:
                        gBScheduleTest.Text = "Writen Test Appointment";
                        pboxTypeOfTest.Image = DVLD.Properties.Resources.Written_Test_512;
                        break;
                    case clsTestTypes.enTestType.StreetTest:
                        gBScheduleTest.Text = "Practical Test Appointment";
                        pboxTypeOfTest.Image = DVLD.Properties.Resources.driving_test_512;
                        break;
                }
            }
        }
        public void LoadInfo(int LocalDrivingLicenseApplicationID, int TestAppointmentID = -1)
        {
            if (TestAppointmentID == -1)
            {
                _Mode = enMode.AddNew;
            }
            else
            {
                _Mode = enMode.Update;
            }

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = TestAppointmentID;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
            // code just extra as we read from dgv which is already full with data
            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application exists for id " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            if (_LocalDrivingLicenseApplication.DoesAttendTestType(_TestTypeID))
            {
                _CreationMode = enCreationMode.RetakeTestSchedule;
            }
            else
            {
                _CreationMode = enCreationMode.FirstTimeSchedule;
            }

            if (_CreationMode == enCreationMode.RetakeTestSchedule)
            {
                lblRAppFees.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.RetakeTest).ApplicationFees.ToString();
                gbRetakeTestInfo.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
                lblRTestAppID.Text = "0";

            }
            else
            {
                gbRetakeTestInfo.Enabled = false;
                lblRAppFees.Text = "0";
                lblTitle.Text = "Schedule Test";
                lblRTestAppID.Text = "N/A";
            }

            lblDLApplicantID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblFullName.Text = _LocalDrivingLicenseApplication.PersonFullName;


            if (_Mode == enMode.AddNew)
            {
                lblTestFees.Text = clsTestTypes.Find(_TestTypeID).TestTypeFees.ToString();
                dtpDateTest.MinDate = DateTime.Now;
                lblRTestAppID.Text = "N/A";
                _TestAppointment = new clsTestAppointments();
            }
            else
            {
                if (!_LoadTestAppointmentData())
                    return;
            }
            lblTotalTestFees.Text = (Convert.ToSingle(lblRAppFees.Text) + Convert.ToSingle(lblTestFees.Text)).ToString();

            if (!_HandleActiveTestAppointmentConstraint())
                return;

            if (!_HandleAppointmentLockedConstraint())
                return;
            if (!_HandlePreviousTestContraint())
                return;
        }

        private bool _LoadTestAppointmentData()
        {
            _TestAppointment = clsTestAppointments.Find(_TestAppointmentID);

            if (_TestAppointment == null)
            {
                MessageBox.Show("Error: No Appointment with ID =" + _TestAppointmentID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }

            lblTestFees.Text = _TestAppointment.PaidFees.ToString();
            // to check its utility
            if (DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) < 0)
                dtpDateTest.MinDate = DateTime.Now;
            else
                dtpDateTest.MinDate = _TestAppointment.AppointmentDate;

            dtpDateTest.Value = _TestAppointment.AppointmentDate;

            //to check its utility, we have already checked in creationmode above
            // why we dont check only this line of code 
            // if(__TestAppointment.RetakeTestAppID != -1)
            //     lblRTestAppID.Text = _TestAppointment.RetakeTestAppID.ToString();
            if (_TestAppointment.RetakeTestAppID == -1)
            {

                lblRAppFees.Text = "0";
                lblTitle.Text = "Schedule Test";
                lblRTestAppID.Text = "N/A";

            }
            else
            {
                lblRAppFees.Text = _TestAppointment.RetakeTestapplication.PaidFees.ToString();
                gbRetakeTestInfo.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
                lblRTestAppID.Text = _TestAppointment.RetakeTestAppID.ToString();
            }

            return true;

        }

        private bool _HandleActiveTestAppointmentConstraint()
        {
            if (_Mode == enMode.AddNew && clsLocalDrivingLicenseApplications.IsThereAnActiveScheduleTest(_LocalDrivingLicenseApplicationID, _TestTypeID))
            {
                // I think here we have to displaya messagebox to the user
                lblUserMessage.Text = "Person has already an active appointment";
                btnSave.Enabled = false;
                dtpDateTest.Enabled = false;
                return false;
            }
            return true;
        }

        private bool _HandleAppointmentLockedConstraint()
        {
            if (_TestAppointment.IsLocked)
            {
                lblUserMessage.Visible = true;
                lblUserMessage.Text = "Person is already sat in this test, test is locked";
                btnSave.Enabled = false;
                dtpDateTest.Enabled = false;
                return false;
            }
            else
            {
                lblUserMessage.Visible = false;
            }

            return true;
        }

        private bool _HandlePreviousTestContraint()
        {
            switch (_TestTypeID)
            {
                case clsTestTypes.enTestType.VisionTest:
                    lblUserMessage.Visible = false;
                    return true;
                case clsTestTypes.enTestType.WrittenTest:
                    if (!_LocalDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.VisionTest))
                    {
                        lblUserMessage.Visible = true;
                        lblUserMessage.Text = "You can't add appointment till you pass previous test";
                        btnSave.Enabled = false;
                        dtpDateTest.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblUserMessage.Visible = false;
                    }
                    return true;
                case clsTestTypes.enTestType.StreetTest:
                    if (!_LocalDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.WrittenTest))
                    {
                        lblUserMessage.Visible = true;
                        lblUserMessage.Text = "You can't add appointment till you pass previous test";
                        btnSave.Enabled = false;
                        dtpDateTest.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblUserMessage.Visible = false;
                    }
                    return true;
            }
            return true;
        }

        private bool _HandleRetakeTestApplication()
        {
            if (_Mode == enMode.AddNew && _CreationMode == enCreationMode.RetakeTestSchedule)
            {
                clsApplications application = new clsApplications();
                application.ApplicantPersonID = _LocalDrivingLicenseApplication.ApplicantPersonID;
                application.ApplicationDate = DateTime.Now;
                application.LastStatusDate = DateTime.Now;
                application.ApplicationTypeID = (int)clsApplications.enApplicationType.RetakeTest;
                application.ApplicationStatus = clsApplications.enApplicationStatus.New;
                application.PaidFees = clsApplicationTypes.Find((int)clsApplications.enApplicationType.RetakeTest).ApplicationFees;
                application.CreatedByUserID = clsGlobal.CurrentUser.UserID;

                if (!application.Save())
                {
                    _TestAppointment.RetakeTestAppID = -1;
                    MessageBox.Show("failed to create application for retake test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _TestAppointment.RetakeTestAppID = application.ApplicationID;
            }
            return true;
        }
        
        public ucScheduleTests()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleRetakeTestApplication())
                return;

            _TestAppointment.TestTypeID = _TestTypeID;
            _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
            _TestAppointment.AppointmentDate = dtpDateTest.Value;
            _TestAppointment.PaidFees = Convert.ToSingle(lblTestFees.Text);
            _TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_TestAppointment.Save())
            {
                MessageBox.Show("TestAppointment added successfully!!", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("TestAppointment failed to add!!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
    }
}


//    public partial class frmScheduleTest : Form
//{
    
//    private float _RetakeTestFees;

    
//    stTestAppointment _TestAppointment2;
//    public frmScheduleTest(stTestAppointment MyStruct, clsTestTypes.enTestType TestTypeID)
//    {
//        InitializeComponent();
//        _TestAppointment2 = MyStruct;
//        _TestTypeID = TestTypeID;
//        //Par default TestTypeID is 1 till passed we move to the second test 2
//    }

    
//    public int TestAppointmentID
//    {
//        set
//        {
//            _TestAppointmentID = value;
//        }
//    }

    

//    public void TakeNewAppointement()
//    {
        
//        if (_TestAppointmentID != -1)
//        {
//            gbRetakeTestInfo.Enabled = true;
//            if (_TestAppointment2.Trial == 0)
//                lblRAppFees.Text = "0";
//            else
//            {
//                _RetakeTestFees = clsApplicationTypes.FindByDriverID(7).ApplicationFees;
//                lblRAppFees.Text = ((int)_RetakeTestFees).ToString();
//                dtpDateTest.MinDate = _TestAppointment2._AppointmentDate.AddDays(10);
//                label1.Text = "Schedule Retake Test";
//            }
//        }
//        else
//        {
//            gbRetakeTestInfo.Enabled = false;
//            lblRAppFees.Text = "0";
//        }
//        dtpDateTest.Enabled = true;
//        btnSave.Enabled = true;
//        lblRTestAppID.Text = "N/A";
//        lblTotalTestFees.Text = (int.Parse(lblRAppFees.Text) * int.Parse(lblTrial.Text) + int.Parse(lblTestFees.Text)).ToString();
//        _TestAppointment2._TestAppointmentID = -1;

//    }

//    public void ShowTestInformation()
//    {
//        lblDLApplicantID.Text = _TestAppointment2._LocalDrivingLicenseApplicationID.ToString();
//        lblDClass.Text = _TestAppointment2._ClassName;
//        lblFullName.Text = _TestAppointment2._FullName;
//        lblTrial.Text = _TestAppointment2.Trial.ToString();
//        lblTestFees.Text = ((int)clsTestTypes.FindByDriverID(_TestTypeID).TestTypeFees).ToString();
//        if (_TestAppointment2._Islocked)
//        {
//            gbRetakeTestInfo.Enabled = false;
//            //lblFaidMessage.Visible = true;
//            if (_TestAppointment2.Trial == 0)
//                lblRAppFees.Text = "0";
//            else
//            {
//                _RetakeTestFees = clsApplicationTypes.FindByDriverID(7).ApplicationFees;
//                lblRAppFees.Text = ((int)_RetakeTestFees).ToString();
//                label1.Text = "Schedule Retake Test";
//            }
//            dtpDateTest.Enabled = false;
//            btnSave.Enabled = false;
//            lblRTestAppID.Text = "N/A";
//            lblTotalTestFees.Text = ((int.Parse(lblRAppFees.Text)) * (int.Parse(lblTrial.Text)) + (int.Parse(lblTestFees.Text))).ToString();
//        }
//        else
//        {
//            gbRetakeTestInfo.Enabled = true;
//            if (_TestAppointment2.Trial == 0)
//                lblRAppFees.Text = "0";
//            else
//            {
//                _RetakeTestFees = clsApplicationTypes.FindByDriverID(7).ApplicationFees;
//                lblRAppFees.Text = ((int)_RetakeTestFees).ToString();
//                dtpDateTest.MinDate = _TestAppointment2._AppointmentDate.AddDays(10);
//                label1.Text = "Schedule Retake Test";
//            }
//            lblRTestAppID.Text = "N/A";
//            lblTotalTestFees.Text = ((int.Parse(lblRAppFees.Text)) * (int.Parse(lblTrial.Text)) + (int.Parse(lblTestFees.Text))).ToString();
//        }

//    }
//    private void btnSave_Click(object sender, EventArgs e)
//    {
//        if (_TestAppointment2._TestAppointmentID == -1)
//        {
//            _TestAppointment = new clsTestAppointments();
//            _TestAppointment.TestTypeID = _TestTypeID;
//            _TestAppointment.LocalDrivingLicenseApplicationID = int.Parse(lblDLApplicantID.Text);
//            _TestAppointment.AppointmentDate = dtpDateTest.Value;
//            _TestAppointment.PaidFees = int.Parse(lblTestFees.Text); // this one have to be updated
//            _TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;
//            _TestAppointment.IsLocked = false;
//            if (_TestAppointment.Save())
//            {
//                MessageBox.Show("TestAppointment added successfully!!", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
//                _TestAppointmentID = _TestAppointment.TestAppointmentID;
//                lblRTestAppID.Text = _TestAppointmentID.ToString();
//                btnSave.Enabled = false;
//            }
//            else
//            {
//                MessageBox.Show("TestAppointment failed to add!!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
//            }
//        }
//        else
//        {
//            _TestAppointment = clsTestAppointments.FindByDriverID(_TestAppointmentID);
//            _TestAppointment.PaidFees = int.Parse(lblTestFees.Text);// this one have to be updated
//            _TestAppointment.AppointmentDate = dtpDateTest.Value;
//            if (_TestAppointment.Save())
//            {
//                MessageBox.Show("TestAppointment updated successfully!!", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
//                btnSave.Enabled = false;
//            }
//            else
//            {
//                MessageBox.Show("TestAppointment failed to update!!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
//            }
//        }

//    }

//    private void frmScheduleTest_Load(object sender, EventArgs e)
//    {
       
//        if (lblRAppFees.Text == "5")
//        {
//            if (!_TestAppointment2._Islocked)
//            {
//                dtpDateTest.MinDate = _TestAppointment2._AppointmentDate.AddDays(10);
//            }
//            else
//            {
//                dtpDateTest.MinDate = _TestAppointment2._AppointmentDate;
//            }
//            label1.Text = "Schedule Retake Test";
//        }
//        else
//        {
//            dtpDateTest.MinDate = DateTime.Today;
//        }

//    }
//}