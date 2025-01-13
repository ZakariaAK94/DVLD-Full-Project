using DVLD_Bussiness;
using DVLD.Properties;
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
using DVLD.Licenses;
using DVLD.Drivers;
using static DVLD.ucDrivingLicenseInfoWithFilter;
using DVLD.Classes;

namespace DVLD.Applications
{
    public partial class frmReleaseDetainedLicenseApplication : Form
    {
        //public delegate void EventHandlerRefreshedData();
        //public event EventHandlerRefreshedData DataRefreshed;

        //public delegate int EventHandlerGetLicenseID(int LicenseID);
        //public event EventHandlerGetLicenseID SentLicendeID;
        //private clsLicenses _OldLicense;
        //private clsLicenses _NewLicense;
        //private clsDetainLicenses _DetainLicense;        
        //private clsApplications _NewApplication;
        //private stDLApplication _stDLApplication;

        private int _SelectedLicenseID = -1;

        public frmReleaseDetainedLicenseApplication()
        {
            InitializeComponent();
          
            //ucLocalLicenseInfo6.ReleaseDetainedLicense = true;
            //ucLocalLicenseInfo6.BtnShowed += ShowButton;
            //ucLocalLicenseInfo6.BtnHided += HideButton;            
            //ucLocalLicenseInfo6.lklShowLicensesHistoryEnabled += lklShowLicensesHistoryEnabled;
            //ucLocalLicenseInfo6.DataSent += GetDataSent;
            //ucLocalLicenseInfo6.DataSentForStruct += FillDataStructInfo;            
           
        }

        public frmReleaseDetainedLicenseApplication(int LicenseID)
        {
            InitializeComponent();
            _SelectedLicenseID = LicenseID;
            ucDrivingLicenseInfoWithFilter1.LoadLicenseInfo(_SelectedLicenseID);
            ucDrivingLicenseInfoWithFilter1.FilterEnabled = false;
            //ucLocalLicenseInfo6.ReleaseDetainedLicense = true;
            //ucLocalLicenseInfo6.LicenseID = LicenseID;            
            //ucLocalLicenseInfo6.BtnShowed += ShowButton;
            //ucLocalLicenseInfo6.BtnHided += HideButton;
            //ucLocalLicenseInfo6.lklShowLicensesHistoryEnabled += lklShowLicensesHistoryEnabled;
            //ucLocalLicenseInfo6.DataSent += GetDataSent;          
            //ucLocalLicenseInfo6.DataSentForStruct += FillDataStructInfo;
        }

        
        
        private void lklShowLicensesHistory1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //if (_OldLicense.LicenseID == 0)
            //{
            //    MessageBox.Show("Please enter a licenseID to open this windows", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //    return;
            //}
            //_stDLApplication = ucLocalLicenseInfo4.stDLApplication;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(ucDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lklShowNewLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            // _stDLApplication = ucLocalLicenseInfo6.stDLApplication;             
            frmShowLicenseInfo frm = new frmShowLicenseInfo(ucDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID);
            frm.Show();
        }

        


       

        private void btnRelease_Click(object sender, EventArgs e)
        {
            int DetainLicenseID = ucDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID;
            if (MessageBox.Show("Are you sure you want t release this detain license with ID" + DetainLicenseID, "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                int ReleaseApplicationID = -1;

                bool IsReleased = false;
                IsReleased = ucDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.ReleaseDetainedLicense(clsGlobal.CurrentUser.UserID, ref ReleaseApplicationID);

                if (!IsReleased)
                {
                    MessageBox.Show("Release license was failed", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }
                lblReleaseAppID.Text = ReleaseApplicationID.ToString();
                lklShowLicensesHistory1.Enabled = true;
                btnRelease.Enabled = false;
            }
            else
                return;   

            //_stDLApplication = ucLocalLicenseInfo6.stDLApplication;
           // _NewApplication = new clsApplications();
           // _NewApplication.ApplicantPersonID = _stDLApplication._ApplicantPersonID;
           // _NewApplication.ApplicationDate = DateTime.Now;
           // _NewApplication.ApplicationTypeID = 5;
           // _NewApplication.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
           // _NewApplication.LastStatusDate = DateTime.Now;
           // _NewApplication.PaidFees = clsApplicationTypes.Find(5).ApplicationFees;
           // _NewApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
           // if (_NewApplication.Save())
           // {
           //     MessageBox.Show("information saved successufully!!", "information", MessageBoxButtons.OKCancel);
           // }
           // else
           // {
           //     MessageBox.Show("save information failed!!!", "information", MessageBoxButtons.OKCancel);
           //     return;
           // }
           // _DetainLicense = clsDetainLicenses.FindDetainedLicenseInfoByLicenseID(_OldLicense.LicenseID);            
           // _DetainLicense.IsReleased = true;
           // _DetainLicense.ReleaseApplicationID = _NewApplication.ApplicationID;
           // _DetainLicense.CreatedByUserID = _NewApplication.CreatedByUserID;
           // if (_DetainLicense.Save())
           // {
           //     MessageBox.Show("information saved successufully!!", "information", MessageBoxButtons.OKCancel);
           // }
           // else
           // {
           //     MessageBox.Show("save information failed!!!", "information", MessageBoxButtons.OKCancel);
           //     return;
           // }
           // _stDLApplication.IsDetain = false;
           // btnRelease.Enabled = false;
           //// ucLocalLicenseInfo6.btnSearchHided();
           // lklShowNewLicenseInfo.Enabled = true;
           // ucDetainInfoForRelease1.RefreshRLAppID((int)_DetainLicense.ReleaseApplicationID);
           // //ucLocalLicenseInfo6.RefreshLicenseDetain();
           // btnRelease.Enabled = false;


        }       

        private void frmReleaseDetainedLicenseApplication_Activated(object sender, EventArgs e)
        {
            ucDrivingLicenseInfoWithFilter1.txtLicenseIDFocus();
        }

        private void ucDrivingLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;

            if(_SelectedLicenseID == -1)
            {
                MessageBox.Show("There is no License with ID "+_SelectedLicenseID, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(ucDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License is not detain, please check and retry","Not Allowed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (ucDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Active, please check and retry", "Not Active", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            lblDetainDate.Text = clsFormat.DateToShort(DateTime.Now);// clsFormat.DateToShort(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.DetainDate);
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;// or this one ucDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.CreatedByUserInfo.UserName
            lblDetainID.Text = ucDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.DetainID.ToString();
            lblLicenseID.Text = ucDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID.ToString();
            lblFineFees.Text = ucDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.FineFees.ToString();
            lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.ReleaseDetainedDrivingLicsense).ApplicationFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblFineFees.Text.Trim()) + Convert.ToSingle(lblApplicationFees.Text.Trim())).ToString();

            ucDrivingLicenseInfoWithFilter1.FilterEnabled = false;
            btnRelease.Enabled = true;

        }


        //private void HideButton()
        //{
        //    btnRelease.Enabled = false;
        //}

        //private void GetDataSent(clsLicenses License)
        //{
        //    _OldLicense = License;
        //    ucDetainInfoForRelease1.License = License;
        //    ucDetainInfoForRelease1.FillucApplicationNewLicenseInfo();
        //}

        //private void lklShowLicensesHistoryEnabled()
        //{
        //    lklShowLicensesHistory1.Enabled = true;
        //}

        //public bool CheckLicenseExpirationDate()
        //{
        //    return false;
        //    //ucLocalLicenseInfo6.DataSent += SetLicenseIDData;
        //    //return ucLocalLicenseInfo6.CheckLicenseDateExpiration();
        //}

        //public void SetLicenseIDData(clsLicenses license)
        //{
        //    _OldLicense = license;
        //    ucDetainInfoForRelease1.License = _OldLicense;
        //}

        //private void FillDataStructInfo(stDLApplication stDLApplication)
        //{
        //    _stDLApplication = stDLApplication;
        //}

        //private void ShowButton()
        //{
        //    btnRelease.Enabled = true;
        //}
    }

}
