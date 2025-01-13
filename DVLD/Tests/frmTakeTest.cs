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
    public partial class frmTakeTest : Form
    {
        //public delegate void SendBackData(stTestAppointment TestAppointmentStruct);
        //public event SendBackData DataSent;
        //private stTestAppointment _TestAppointmentStruct1;

        private clsTests _Test;    
        private int _TestID;     
        
        private clsTestTypes.enTestType _TestTypeID;

        private int _TestAppointmentID;
        private clsTestAppointments _TestAppointment;


        public frmTakeTest(int TestAppointmentID, clsTestTypes.enTestType TestTypeID)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;
            _TestTypeID = TestTypeID;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            ucScheduledTests1.TestTypeID = _TestTypeID;
            ucScheduledTests1.LoadInfo(_TestAppointmentID);

            if(_TestAppointmentID == -1)
            {
                btnSave.Enabled = false;
            }
            else
            {
                btnSave.Enabled=true;
            }

            _TestID = ucScheduledTests1.TestID;
            if(_TestID !=-1)
            {
                _Test = clsTests.FindByTestID(_TestID);
                if (_Test != null)
                {
                    txtBoxNotes.Text = _Test.Notes;
                    if (_Test.TestResult)
                    {
                        rbPassed.Checked = true;
                    }
                    else
                    {
                        rbFailed.Checked = true;
                    }
                    lblUserMessage.Visible = true;
                    rbFailed.Enabled = false;
                    rbPassed.Enabled = false;
                }            
            }
            
            _Test = new clsTests();


            //lblTrial.Text = _TestAppointmentStruct1.Trial.ToString();
            //lblFees.Text = ((int)_TestAppointmentStruct1._PaidFees).ToString();            
            //lblFullName.Text = _TestAppointmentStruct1._FullName;
            //lblApplicationDate.Text = _TestAppointmentStruct1._AppointmentDate.ToShortDateString();           
            //lblDLApplicantID.Text = _TestAppointmentStruct1._LocalDrivingLicenseApplicationID.ToString();
            //lblDClass.Text = _TestAppointmentStruct1._ClassName;
            //if (_TestTypeID == clsTestTypes.enTestType.VisionTest)
            //{
            //    gBoxTakeTest.Text = "Vision Test Appointment";
            //    pBoxTakeTest.Image = Image.FromFile("C:\\Users\\AKILZA\\Desktop\\projet DVLC pictures\\vision test.png");
            //}
            //else if (_TestTypeID == clsTestTypes.enTestType.WrittenTest)
            //{
            //    gBoxTakeTest.Text = "Writen Test Appointment";
            //    pBoxTakeTest.Image = Image.FromFile("C:\\Users\\AKILZA\\Desktop\\projet DVLC pictures\\written test.jpg");
            //}
            //else if (_TestTypeID == clsTestTypes.enTestType.StreetTest)
            //{
            //    gBoxTakeTest.Text = "Practical Test Appointment";
            //    pBoxTakeTest.Image = Image.FromFile("C:\\Users\\AKILZA\\Desktop\\projet DVLC pictures\\driving street test.jpg");
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if(MessageBox.Show("Are you sure you want to save data? After that you cannot change the Pass/Fail results after you save?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                if (_TestID != -1)
                {
                    _Test.Notes = txtBoxNotes.Text;
                    if (_Test.Save())
                    {
                        MessageBox.Show("Test updated successfully!!", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Test failed to update!!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }

                _Test.TestAppointmentID = _TestAppointment.TestAppointmentID;
                _Test.TestResult = rbPassed.Checked;               
                _Test.Notes = txtBoxNotes.Text;
                _Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                if (_Test.Save())
                {
                    MessageBox.Show("Data added successfully!!", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    btnSave.Enabled = false;
                    return;
                }
                else
                {
                    MessageBox.Show("Error: Data failed to add!!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                
            }
           

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
                 this.Close();
        }

        //private void frmTakeTest_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    NotifyDataChanged();
        //}

        //private void NotifyDataChanged()
        //{
        //    // If other forms are open, you can call a method on them to refresh data
        //    // Example: if you have MainForm and it has a method called RefreshData()
        //    if (Application.OpenForms["frmTestAppointment"] != null)
        //    {
        //        ((frmListTestAppointment)Application.OpenForms["frmTestAppointment"]).UpdateDataGridAfterChanging();
        //    }
        //}
    }
}
