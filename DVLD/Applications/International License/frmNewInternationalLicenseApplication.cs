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
using static DVLD.ucDrivingLicenseInfoWithFilter;
using DVLD.Classes;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.Applications
{
    public partial class frmNewInternationalLicenseApplication : Form
    {
        private int _InternationalLicenseID = -1;
        public frmNewInternationalLicenseApplication()
        {
            InitializeComponent();
            //ucLocalLicenseInfo2.DataSent += ucNewInternatialLicense2_DataSent;
            //ucLocalLicenseInfo2.DataSent += SetLicenseIDData;           
            //ucLocalLicenseInfo2.BtnShowed += ShowButton;
            //ucLocalLicenseInfo2.BtnHided += HideButton;
        }        
                
        private void lklShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int PersonID = ucDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.Show();
        }

        private void btnClose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssue2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to add a new international license for the license selected ?","Confirmation",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question)== DialogResult.OK)
            {
                clsInternationalLicenses InternationalLicense = new clsInternationalLicenses();
               InternationalLicense.ApplicantPersonID = ucDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
                InternationalLicense.ApplicationDate = DateTime.Now;
                InternationalLicense.ApplicationTypeID = (int)clsApplications.enApplicationType.NewInternationalLicense;
                InternationalLicense.LastStatusDate = DateTime.Now;               
               InternationalLicense.PaidFees = clsApplicationTypes.Find((int)clsApplications.enApplicationType.NewInternationalLicense).ApplicationFees;
               InternationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                InternationalLicense.ApplicationStatus = clsApplications.enApplicationStatus.Completed;

               
               InternationalLicense.DriverID = ucDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID;
               InternationalLicense.IssuedUsingLocalLicenseID = ucDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID;
               InternationalLicense.IssueDate = DateTime.Now; ;
               InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
               InternationalLicense.IsActive = true;

               if (!InternationalLicense.Save())
               {
                   MessageBox.Show("International License Issued Successfully with ID = "+ InternationalLicense.InternationalLicenseID,
                       "International License Issued", MessageBoxButtons.OKCancel);
                   lblILApplicationID.Text = InternationalLicense.ApplicationID.ToString();
                   lblILLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
                    btnIssue2.Enabled = false;


               }
               else
               {
                   MessageBox.Show("save information failed!!!", "information", MessageBoxButtons.OKCancel);
                   return;
               }
            }
            else
            {
                return;
            }
            //_Licenses = clsLicenses.FindLicenseInfoByLicenseID(_LicenseID);

            //if (!_Licenses.IsActive)
            //{
            //    MessageBox.Show("local license is inactive, please chekc and retry!!! ", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            //}
            //else if (_Licenses.ExpirationDate < DateTime.Now)
            //{
            //    MessageBox.Show("your local license has an expiry date, please chekc and retry!!! ", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            //}
            //else
            //{
            //    if (MessageBox.Show("Are you sure you wanna issue the license?", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
            //    {
            //        _AddeNewInternationalLicense();
            //        lklShowLicensesInfo1.Enabled = true;
            //        btnIssue2.Enabled = false;
            //        DataRefreshed?.Invoke();
            //    }
            //    else
            //        return;

        }     
        private void ucDrivingLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;
            lblLocalLicenseID.Text = SelectedLicenseID.ToString();
            lklShowLicensesInfo1.Enabled = true;

            if (SelectedLicenseID == -1)
            {
                return;
            }

            // we check if licenseclass is "Class 3 - Ordinary driving license

            if(ucDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassID !=3)
            {
                MessageBox.Show("The license class for this license is not 3, please check and retry","Not Allowed",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if (ucDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("The license selected is not active", "Not Active", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            //Check if person already has an active International License

            int ActiveInternationalLicenseId = clsInternationalLicenses.GetActiveInternationalLicenseIDByDriverID(ucDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID);

            if (ActiveInternationalLicenseId != -1)
            {
                MessageBox.Show("this person already has an active international license with ID "+ ActiveInternationalLicenseId.ToString()
                    , "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lklShowLicensesInfo1.Enabled= true;
                _InternationalLicenseID = ActiveInternationalLicenseId;
                btnIssue2.Enabled=false;

                return;
            }

            btnIssue2.Enabled = true;



        }

        private void lklShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicesInfo frm = new frmShowInternationalLicesInfo(_InternationalLicenseID);
            frm.ShowDialog();

        }

        private void frmNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = lblApplicationDate.Text;
            lblDateOfExpiration.Text = clsFormat.DateToShort(DateTime.Now.AddYears(1));
            lblFees.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.NewInternationalLicense).ApplicationFees.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        
        
        }

    //public delegate void EventHandlerRefreshedData();
    //public event EventHandlerRefreshedData DataRefreshed;

    //private clsApplications _Application;

    //private clsLicenses _Licenses;
    //private int _LicenseID;
    //private clsInternationalLicenses _InternationalLicenses;

    //private stDLApplication _stDLApplication;

    //private void HideButton()
    //{
    //    btnIssue2.Enabled = false;
    //}
    //private void ShowButton()
    //{
    //    btnIssue2.Enabled = true;
    //}
    //private void SetLicenseIDData(clsLicenses  license)
    //{
    //    _LicenseID = license.LicenseID;
    //}
    //private void ucNewInternatialLicense2_DataSent(clsLicenses License)
    //{
    //    ucNewInternatialLicense2.ReceiveData(License.LicenseID);
    //   // _stDLApplication = ucLocalLicenseInfo2.stDLApplication;
    //}

    //private void _AddNewApplication()
    //{
    //    _Application = new clsApplications();
    //    _Application.ApplicantPersonID = _stDLApplication._ApplicantPersonID;
    //    _Application.ApplicationDate = DateTime.Now;
    //    _Application.LastStatusDate = DateTime.Now;
    //    _Application.ApplicationTypeID = 6;
    //    _Application.PaidFees = clsApplicationTypes.Find(6).ApplicationFees;
    //    _Application.CreatedByUserID = clsGlobal.CurrentUser.UserID;
    //    _Application.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
    //    if (_Application.Save())
    //    {
    //        MessageBox.Show("information saved successufully!!", "information", MessageBoxButtons.OKCancel);
    //        ucNewInternatialLicense2.ILApplicationID = _Application.ApplicationID;
    //    }
    //    else
    //    {
    //        MessageBox.Show("save information failed!!!", "information", MessageBoxButtons.OKCancel);
    //        return;
    //    }

    //}
    //private void _AddeNewInternationalLicense()
    //{
    //    _AddNewApplication();
    //    _InternationalLicenses = new clsInternationalLicenses();
    //    _InternationalLicenses.ApplicationID = _Application.ApplicationID;            
    //    _InternationalLicenses.DriverID = _Licenses.DriverID;
    //    _InternationalLicenses.IssuedUsingLocalLicenseID = _Licenses.LicenseID;
    //    _InternationalLicenses.IssueDate = _Application.ApplicationDate;
    //    _InternationalLicenses.ExpirationDate = _Application.ApplicationDate.AddDays(365);
    //    _InternationalLicenses.IsActive = true;
    //    _InternationalLicenses.CreatedByUserID = _Application.CreatedByUserID;
    //    if (_InternationalLicenses.Save())
    //    {
    //        MessageBox.Show("International License Issued Successfully with ID = "+ _InternationalLicenses.InternationalLicenseID,"License Issued", MessageBoxButtons.OKCancel);
    //        ucNewInternatialLicense2.ILLicenseID = _InternationalLicenses.InternationalLicenseID;
    //        ucNewInternatialLicense2.RefreshILApplicationIDAndILLicenseID();

    //    }
    //    else
    //    {
    //        MessageBox.Show("save information failed!!!", "information", MessageBoxButtons.OKCancel);
    //        return;
    //    }
    //}
    }
}
