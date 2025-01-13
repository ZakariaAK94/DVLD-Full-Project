using DVLD.Classes;
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

namespace DVLD.Tests.Controls
{
    public partial class ucScheduledTests : UserControl
    {
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

        private int _TestAppointmentID = -1;
        private clsTestAppointments _TestAppointment;
        public int TestAppointmentID
        {
            get
            {
                return (_TestAppointmentID);
            }
        }
        private int _TestID = -1;   
        public int TestID
        {
            get
            {
                return (_TestID);
            }
        }

        private int _LocalDrivingLicenseApplicationID = -1;
        private clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplication;
        



        public void LoadInfo(int TestAppointmentID)
        {           
            
            _TestAppointmentID = TestAppointmentID;
            _TestAppointment = clsTestAppointments.Find(TestAppointmentID);
            if( _TestAppointment == null )
            {
                MessageBox.Show("No Appointment exist with ID " + _TestAppointmentID, "Nout Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _TestAppointmentID = -1;
                return;           
            }
            _TestID = _TestAppointment.TestID;
            _LocalDrivingLicenseApplicationID = _TestAppointment.LocalDrivingLicenseApplicationID;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
            // code just extra as we read from dgv which is already full with data
            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application exists for id " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                return;
            }      
            
            lblDLApplicantID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblFullName.Text = _LocalDrivingLicenseApplication.PersonFullName;
            lblTrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestTypeID).ToString();
            lblTestFees.Text = clsTestTypes.Find(_TestTypeID).TestTypeFees.ToString();
            dtpDateTest.MinDate = DateTime.Now;           
            lblTestID.Text = (_TestID == -1 ? "Not Taken Yet":_TestID.ToString());
        }

        public ucScheduledTests()
        {
            InitializeComponent();
        }
    }
    
}
