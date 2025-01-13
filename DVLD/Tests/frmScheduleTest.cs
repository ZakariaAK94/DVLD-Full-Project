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
using DVLD.Classes;

namespace DVLD.Tests
{
    public partial class frmScheduleTest : Form
    {
                  
        private int _TestAppointmentID = -1;
        private clsTestTypes.enTestType _TestTypeID = clsTestTypes.enTestType.VisionTest;
        private int _LocalDrivingLicenseApplicationID =-1;
        public frmScheduleTest(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID, int TestAppointmentID =-1)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;
            _TestAppointmentID = TestAppointmentID;
        }

       

        private void frmScheduleTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            ucScheduleTests1.TestTypeID = _TestTypeID;
            ucScheduleTests1.LoadInfo(_LocalDrivingLicenseApplicationID, _TestAppointmentID);          
        }     

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //private void NotifyDataChanged1()
        //{
        //    // If other forms are open, you can call a method on them to refresh data
        //    // Example: if you have MainForm and it has a method called RefreshData()
        //    if (Application.OpenForms["frmTestAppointment"] != null)
        //    {
        //        ((frmTestAppointment)Application.OpenForms["frmTestAppointment"]).UpdateDataGridAfterChanging();
        //    }
        //}
        //private void btnClose_Click(object sender, EventArgs e)
        //{
        //    //if(!_TestAppointment2._Islocked ==true)
        //    //{
        //    //    this.Close();
        //    //    return;
        //    //}
        //    DataAppointmentRefreshed?.Invoke();
        //    this.Close();
        //}
        //public void TakeNewAppointement()
        //{
        //    lblDLApplicantID.Text = _TestAppointment2._LocalDrivingLicenseApplicationID.ToString();
        //    lblDClass.Text = _TestAppointment2._ClassName;
        //    lblFullName.Text = _TestAppointment2._FullName;
        //    lblTrial.Text = _TestAppointment2.Trial.ToString();
        //    lblTestFees.Text = ((int)clsTestTypes.FindByDriverID(_TestTypeID).TestTypeFees).ToString();
        //    if (_TestAppointmentID!=-1)
        //    {
        //        gbRetakeTestInfo.Enabled = true;
        //        if (_TestAppointment2.Trial == 0)
        //            lblRAppFees.Text = "0";
        //        else
        //        {
        //            _RetakeTestFees = clsApplicationTypes.FindByDriverID(7).ApplicationFees;
        //            lblRAppFees.Text = ((int)_RetakeTestFees).ToString();
        //            dtpDateTest.MinDate = _TestAppointment2._AppointmentDate.AddDays(10);
        //            label1.Text = "Schedule Retake Test";
        //        }                
        //    }
        //    else
        //    {
        //        gbRetakeTestInfo.Enabled = false;
        //        lblRAppFees.Text = "0";  
        //    }
        //    dtpDateTest.Enabled = true;
        //    btnSave.Enabled = true;
        //    lblRTestAppID.Text = "N/A";
        //    lblTotalTestFees.Text = (int.Parse(lblRAppFees.Text) * int.Parse(lblTrial.Text) + int.Parse(lblTestFees.Text)).ToString();
        //    _TestAppointment2._TestAppointmentID = -1;

        //}

        //public void ShowTestInformation()
        //{
        //    lblDLApplicantID.Text = _TestAppointment2._LocalDrivingLicenseApplicationID.ToString();
        //    lblDClass.Text = _TestAppointment2._ClassName;
        //    lblFullName.Text = _TestAppointment2._FullName;
        //    lblTrial.Text = _TestAppointment2.Trial.ToString();
        //    lblTestFees.Text =((int)clsTestTypes.FindByDriverID(_TestTypeID).TestTypeFees).ToString(); 
        //    if (_TestAppointment2._Islocked)
        //    {
        //        gbRetakeTestInfo.Enabled = false;
        //        //lblFaidMessage.Visible = true;
        //        if (_TestAppointment2.Trial == 0)
        //            lblRAppFees.Text = "0";
        //        else
        //        {
        //            _RetakeTestFees = clsApplicationTypes.FindByDriverID(7).ApplicationFees;
        //            lblRAppFees.Text = ((int)_RetakeTestFees).ToString();
        //            label1.Text = "Schedule Retake Test";
        //        }
        //        dtpDateTest.Enabled = false;
        //        btnSave.Enabled = false;
        //        lblRTestAppID.Text = "N/A";
        //        lblTotalTestFees.Text = ((int.Parse(lblRAppFees.Text)) * (int.Parse(lblTrial.Text)) + (int.Parse(lblTestFees.Text))).ToString();
        //    }
        //    else
        //    {
        //        gbRetakeTestInfo.Enabled = true;
        //        if (_TestAppointment2.Trial == 0)
        //            lblRAppFees.Text = "0";
        //        else
        //        {
        //            _RetakeTestFees = clsApplicationTypes.FindByDriverID(7).ApplicationFees;
        //            lblRAppFees.Text =((int)_RetakeTestFees).ToString();
        //            dtpDateTest.MinDate = _TestAppointment2._AppointmentDate.AddDays(10);
        //            label1.Text = "Schedule Retake Test";
        //        }
        //        lblRTestAppID.Text = "N/A";
        //        lblTotalTestFees.Text = ((int.Parse(lblRAppFees.Text)) * (int.Parse(lblTrial.Text)) + (int.Parse(lblTestFees.Text))).ToString();
        //    }

        //}
        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    if(_TestAppointment2._TestAppointmentID == -1)
        //    {
        //        _TestAppointment = new clsTestAppointments();
        //        _TestAppointment.TestTypeID = _TestTypeID; 
        //        _TestAppointment.LocalDrivingLicenseApplicationID = int.Parse(lblDLApplicantID.Text);
        //        _TestAppointment.AppointmentDate = dtpDateTest.Value;
        //        _TestAppointment.PaidFees = int.Parse(lblTestFees.Text); // this one have to be updated
        //        _TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;               
        //        _TestAppointment.IsLocked = false;
        //        if (_TestAppointment.Save())
        //        {
        //            MessageBox.Show("TestAppointment added successfully!!", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        //            _TestAppointmentID = _TestAppointment.TestAppointmentID;
        //            lblRTestAppID.Text = _TestAppointmentID.ToString();
        //            btnSave.Enabled = false;
        //        }
        //        else
        //        {
        //            MessageBox.Show("TestAppointment failed to add!!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        //        }
        //    }
        //    else
        //    {
        //        _TestAppointment = clsTestAppointments.FindByDriverID(_TestAppointmentID);
        //        _TestAppointment.PaidFees = int.Parse(lblTestFees.Text);// this one have to be updated
        //        _TestAppointment.AppointmentDate = dtpDateTest.Value;
        //        if (_TestAppointment.Save())
        //        {
        //            MessageBox.Show("TestAppointment updated successfully!!", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        //            btnSave.Enabled = false;
        //        }
        //        else
        //        {
        //            MessageBox.Show("TestAppointment failed to update!!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        //        }
        //    }          

        //}

        //private void frmScheduleTest_Load(object sender, EventArgs e)
        //{
        //    if (_TestTypeID == clsTestTypes.enTestType.VisionTest)
        //    {
        //        gBScheduleTest.Text = "Vision Test Appointment";
        //        pboxTypeOfTest.Image = Image.FromFile("C:\\Users\\AKILZA\\Desktop\\projet DVLC pictures\\vision test.png");
        //    }
        //    else if (_TestTypeID == clsTestTypes.enTestType.WrittenTest)
        //    {
        //        gBScheduleTest.Text = "Writen Test Appointment";
        //        pboxTypeOfTest.Image = Image.FromFile("C:\\Users\\AKILZA\\Desktop\\projet DVLC pictures\\written test.jpg");
        //       // dtpDateTest.MinDate = _TestAppointment2._AppointmentDate.AddDays(10);
        //    }
        //    else if (_TestTypeID == clsTestTypes.enTestType.StreetTest)
        //    {
        //        gBScheduleTest.Text = "Practical Test Appointment";
        //        pboxTypeOfTest.Image = Image.FromFile("C:\\Users\\AKILZA\\Desktop\\projet DVLC pictures\\driving street test.jpg");
        //        //dtpDateTest.MinDate = _TestAppointment2._AppointmentDate.AddDays(10);
        //    }
        //    if (lblRAppFees.Text == "5")
        //    {
        //        if(!_TestAppointment2._Islocked)
        //        {
        //            dtpDateTest.MinDate = _TestAppointment2._AppointmentDate.AddDays(10);
        //        }                
        //        else
        //        {
        //            dtpDateTest.MinDate = _TestAppointment2._AppointmentDate;
        //        }
        //        label1.Text = "Schedule Retake Test";
        //    }      
        //    else
        //    {                
        //            dtpDateTest.MinDate = DateTime.Today;
        //    }               

        //}
    }
}
