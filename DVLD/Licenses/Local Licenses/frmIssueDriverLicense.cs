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

namespace DVLD.Licenses
{
    public partial class frmIssueDriverLicense : Form
    {
        //public delegate void IssueDriverLicenseEventHandler();
        //public event IssueDriverLicenseEventHandler IssueDriverLicenseCalled;
        //stDLApplication _DLApplicationStruct1;
        //stTestAppointment _TestAppointmentStruct1;
        //private int _TestAppointmentID = -1;
        //private clsTestAppointments _TestAppointment;
        //private clsDrivers _Driver;
        //private clsLicenses _License;
        //private clsLicenseClasses _LicenseClass;

        private int _LocalDrivingLicenseApplicationID = -1;
        private clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplication;
        public frmIssueDriverLicense(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
           // _DLApplicationStruct1 = _MyStruct;
            //ucScheduleTests2.SetValueToStruct(_DLApplicationStruct1);
            //_TestAppointmentStruct1._LocalDrivingLicenseApplicationID = _DLApplicationStruct1._LocalDrivingLicenseApplicationID;
            //_TestAppointmentStruct1._ClassName = _DLApplicationStruct1._ClassName;
            //_TestAppointmentStruct1._FullName = _DLApplicationStruct1._FullName;
            //_TestAppointmentStruct1._PaidFees = _DLApplicationStruct1._ApplicationFees;
            //_TestAppointmentStruct1._PassTestCount = _DLApplicationStruct1._PassedTestsCount;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
           
        }
        
        private void frmIssueDriverLicense_Load(object sender, EventArgs e)
        {
            //ucScheduleTests2.FillApplicationInfo();

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
            if(_LocalDrivingLicenseApplication == null )
            {
                MessageBox.Show("No Application exist for ID " + _LocalDrivingLicenseApplicationID.ToString(), "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if(_LocalDrivingLicenseApplication.PassedAllTests())
            {
                MessageBox.Show("You have to pass all tests first", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            int LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();

            if(LicenseID != -1)
            {
                MessageBox.Show("Person already has a License for this licenseClass with LicenseID =  "+LicenseID.ToString(), "Not Valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return ;
            }

            ucDrivingLicenseApplication1.LoadApplicationInfoByLocalDrivingLicenseID(_LocalDrivingLicenseApplicationID);

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            int LicenseID = _LocalDrivingLicenseApplication.IssueLicenseForFirstTime(txtBoxNotes.Text.Trim(), clsGlobal.CurrentUser.UserID);
            if(LicenseID !=-1)
            {
                MessageBox.Show("License issued successfully with LicenseID "+LicenseID.ToString(),"Information",MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }else
            {
                MessageBox.Show("Error: License was not issued !", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //IssueDriverLicenseCalled?.Invoke();
            this.Close();
        }
        //private void btnIssue_Click(object sender, EventArgs e)
        //{
        //    _Driver = new clsDrivers();
        //    _License = new clsLicenses();
        //    _Driver.PersonID = _DLApplicationStruct1._ApplicantPersonID;
        //    _Driver.CreatedByUserID = clsUser.FindByPersonID(_Driver.PersonID).UserID;
        //    _Driver.CreatedDate = DateTime.Now;
        //    if(_Driver.Save())
        //    {
        //        MessageBox.Show("Driver added Successfully","Confirmation",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
        //        _License.DriverID = _Driver.DriverID;
        //        _LicenseClass = clsLicenseClasses.FindByClassName(_DLApplicationStruct1._ClassName);
        //        _License.ApplicationID = _DLApplicationStruct1._ApplicationID;
        //        _License.LicenseClassID = _LicenseClass.LicenseClassID;
        //        _License.IssueDate = _Driver.CreatedDate;
        //        _License.ExpirationDate = _License.IssueDate.AddDays(_LicenseClass.DefaultValidityLength*365);
        //        _License.Notes = txtBoxNotes.Text;
        //        _License.PaidFees = _LicenseClass.ClassFees;
        //        _License.IsActive = true;
        //        _License.IssueReason =1;
        //        _License.CreatedByUserID = _Driver.CreatedByUserID;
        //        if (_License.Save())
        //        {
        //            MessageBox.Show("License Issued Successfully with License ID = " + _License.LicenseID, "Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        else
        //            return;
        //        clsApplications _Application = clsApplications.FindBaseApplication(_DLApplicationStruct1._ApplicationID);              
        //        _Application.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
        //        if (_Application.Save())
        //        {
        //            MessageBox.Show("Application updated successfully ", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Application failed to update ", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        //            return;
        //        }
        //        btnIssue.Enabled = false;
        //        //ucScheduleTests1.ShowLicenseInfoLkl = true;
        //        //ucScheduleTests1.RefreshlklShowLicenseInfo();

        //    }
        //    else
        //    {
        //        MessageBox.Show("Driver failed to add successfully", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        //    }
            
        //}
        //private void frmIssueDriverLicense_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    NotifyDataChanged1();
        //}        
        //private void NotifyDataChanged1()
        //{
        //    // If other forms are open, you can call a method on them to refresh data
        //    // Example: if you have MainForm and it has a method called RefreshData()
        //    if (Application.OpenForms["frmLocalDrivingLicenseApplications"] != null)
        //    {
        //    // ((frmLocalDrivingLicenseApplications)Application.OpenForms["frmLocalDrivingLicenseApplications"]).RefreshList();;
        //    }
        //}
       
    }
}
