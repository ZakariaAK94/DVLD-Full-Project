using DVLD_Bussiness;
using static DVLD_Bussiness.clsLicenses;
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

namespace DVLD.Applications.ReplaceLostOrDamagedLicense
{
    public partial class frmReplacementForLostOrDamagedLicense : Form
    {
        private int _NewLicenseID = -1;    
        public frmReplacementForLostOrDamagedLicense()
        {
            InitializeComponent();
            //if (rbDamagedLicense.Checked)
            //    _IssueReason = 4;
            //else
            //    _IssueReason = 3;
            //ucLocalLicenseInfo4.IssueReason = _IssueReason;
            //ucLocalLicenseInfo4.BtnShowed += ShowButton;
            //ucLocalLicenseInfo4.BtnHided += HideButton;            
            //ucLocalLicenseInfo4.lklShowLicensesHistoryEnabled += lklShowLicensesHistoryEnabled;
            //ucLocalLicenseInfo4.DataSent += GetDataSent;
            //ucLocalLicenseInfo4.DataSentForStruct += FillDataStructInfo;
            
           //ucApplicationInfoForLicenseReplacement1.IssueReason = _IssueReason;
        }

        private int _GetApplicationTypeID()
        {
            // this will decide with applicationtype will be considered.
            if (rbDamagedLicense.Checked)
                return (int)clsApplications.enApplicationType.ReplaceDamagedDrivingLicense;
            else
               return (int)clsApplications.enApplicationType.ReplaceLostDrivingLicense;
        }

        private enIssueReason _GetIssueReason()
        {
            if (rbDamagedLicense.Checked)
                return enIssueReason.DamagedReplacement;
            else
                return enIssueReason.LostReplacement;
        }

        private void frmReplacementForLostOrDamagedLicense_Load(object sender, EventArgs e)
        {

            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;

            rbDamagedLicense.Checked = true;
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            //_IssueReason = 4;
            this.Text = lblTitleForThisForm.Text;
            lblTitleForThisForm.Text = "Replacement for Damaged License";
            lblApplicationFees.Text = clsApplicationTypes.Find(_GetApplicationTypeID()).ApplicationFees.ToString();
            //ucApplicationInfoForLicenseReplacement1.IssueReason = _IssueReason;
            //ucApplicationInfoForLicenseReplacement1.ChangeApplicationFees();
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            //_IssueReason = 3;
            this.Text = lblTitleForThisForm.Text;
            lblTitleForThisForm.Text = "Replacement for Lost License";
            lblApplicationFees.Text = clsApplicationTypes.Find(_GetApplicationTypeID()).ApplicationFees.ToString();
            //ucApplicationInfoForLicenseReplacement1.IssueReason = _IssueReason;
            //ucApplicationInfoForLicenseReplacement1.ChangeApplicationFees();
        }

        private void frmReplacementForLostOrDamagedLicense_Activated(object sender, EventArgs e)
        {
            ucDrivingLicenseInfoWithFilter1.txtLicenseIDFocus();
        }

        private void ucDrivingLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;
            lblOldLicenseID.Text = SelectedLicenseID.ToString();
            lklShowLicensesHistory1.Enabled = (SelectedLicenseID!=-1);
            if(SelectedLicenseID != -1)
            {
                return;
            }
            //check if license is Active
            if(!ucDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Error: License is inactive,please check and try again.","Not Allowed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                btnIssueReplacement.Enabled = false;
                return;

            }

            btnIssueReplacement.Enabled = true;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lklShowNewLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
           // _stDLApplication = ucLocalLicenseInfo4.stDLApplication;
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_NewLicenseID);
            frm.Show();
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you wanna replace this license","Confirmation",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                clsLicenses NewLicense = ucDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.ReplaceLicense(_GetIssueReason(),clsGlobal.CurrentUser.UserID);

                if(NewLicense == null)
                {
                    MessageBox.Show("Replace license was failed!!!","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnIssueReplacement.Enabled = false;
                    return;
                }
                _NewLicenseID = NewLicense.LicenseID;
                lblRenewLLicenseID.Text = _NewLicenseID.ToString();
                lblRLApplicationID.Text = NewLicense.ApplicationID.ToString();
                MessageBox.Show("Replace license was successfulll, the id is " + _NewLicenseID.ToString(), "License Issued",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnIssueReplacement.Enabled=false;
                lklShowNewLicensesInfo.Enabled =true;
                lklShowLicensesHistory1.Enabled =true;
                gBReplacementFor.Enabled =false;
                ucDrivingLicenseInfoWithFilter1.FilterEnabled =false;

            }
        }

        private void lklShowLicensesHistory1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            //frm.show();
        }

        //public delegate void EventHandlerRefreshedData();
        //public event EventHandlerRefreshedData DataRefreshed;
        //private clsApplications _OldApplication;
        //private clsApplications _RenewApplication;
        //private clsLicenses _OldLicense;
        //private clsLicenses _NewLicense;
        //private byte _IssueReason;
        //private stDLApplication _stDLApplication;

        //private void HideButton()
        //{
        //    btnIssueReplacement.Enabled = false;
        //}

        //private void GetDataSent(clsLicenses License)
        //{
        //    _OldLicense = License;
        //    //ucApplicationInfoForLicenseReplacement1.License = License;
        //    //ucApplicationInfoForLicenseReplacement1.FillucApplicationNewLicenseInfo();
        //}

        //private void lklShowLicensesHistoryEnabled()
        //{
        //    lklShowLicensesHistory1.Enabled = true;
        //}

        //public bool CheckLicenseExpirationDate()
        //{
        //    return false;
        //    //ucLocalLicenseInfo4.DataSent += SetLicenseIDData;
        //    //return ucLocalLicenseInfo4.CheckLicenseDateExpiration();
        //}

        //public void SetLicenseIDData(clsLicenses  license)
        //{
        //    _OldLicense = license;
        //    //ucApplicationInfoForLicenseReplacement1.License = _OldLicense;
        //}

        //private void btnRenewLicense_Click(object sender, EventArgs e)
        //{            
        //    _RenewApplication = new clsApplications();
        //    _OldApplication = clsApplications.FindBaseApplication(_OldLicense.ApplicationID);
        //    _RenewApplication.ApplicantPersonID = _OldApplication.ApplicantPersonID;
        //    _RenewApplication.ApplicationDate = DateTime.Now;
        //    _RenewApplication.ApplicationTypeID = _IssueReason;            
        //    _RenewApplication.ApplicationStatus = _OldApplication.ApplicationStatus;
        //    _RenewApplication.LastStatusDate = _RenewApplication.ApplicationDate;
        //    _RenewApplication.PaidFees = clsApplicationTypes.Find(_IssueReason).ApplicationFees;
        //    _RenewApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
        //    if (_RenewApplication.Save())
        //    {
        //        MessageBox.Show("information saved successufully!!", "information", MessageBoxButtons.OKCancel);
        //    }
        //    else
        //    {
        //        MessageBox.Show("save information failed!!!", "information", MessageBoxButtons.OKCancel);
        //        return;
        //    }          
        //    _NewLicense = new clsLicenses();
        //    _NewLicense.ApplicationID = _RenewApplication.ApplicationID;
        //    _NewLicense.DriverID = _OldLicense.DriverID;
        //    _NewLicense.LicenseClassID = _OldLicense.LicenseClassID;
        //    _NewLicense.IssueDate = DateTime.Now; 
        //    _NewLicense.ExpirationDate = _NewLicense.IssueDate + (_OldLicense.ExpirationDate - _OldLicense.IssueDate);
        //    _NewLicense.Notes = _OldLicense.Notes;
        //    _NewLicense.PaidFees = _OldLicense.PaidFees;
        //    _NewLicense.IsActive = true;
        //    //_NewLicense.IssueReason = _IssueReason;
        //    _NewLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;
        //    _OldLicense.IsActive = false;
        //    if (_OldLicense.Save())
        //    {
        //        MessageBox.Show("Old License updated successufully!!", "information", MessageBoxButtons.OKCancel);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Old License updated failed!!!", "information", MessageBoxButtons.OKCancel);
        //        return;
        //    }

        //    if (_NewLicense.Save())
        //    {
        //        MessageBox.Show("License added Successfully with License ID = " + _NewLicense.LicenseID, "Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    else
        //    {
        //        MessageBox.Show("save information failed!!!", "information", MessageBoxButtons.OKCancel);
        //        return;
        //    }
        //    btnIssueReplacement.Enabled = false;
        //    //ucLocalLicenseInfo4.btnSearchHided();
        //    lklShowNewLicensesHistory.Enabled = true;
        //    //ucApplicationInfoForLicenseReplacement1.RefreshRLApplicationIDAndRenewLLicenseID(_RenewApplication.ApplicationID, _NewLicense.LicenseID);
        //   // ucLocalLicenseInfo4.RefreshLicenseValidity();
        //    btnIssueReplacement.Enabled = false;


        //}

        //private void lklShowLicensesHistory1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    if (_OldLicense.LicenseID == 0)
        //    {
        //        MessageBox.Show("Please enter a licenseID to open this windows", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        //        return;
        //    }
        //    //_stDLApplication = ucLocalLicenseInfo4.stDLApplication;
        //    frmLicenseHistory frm = new frmLicenseHistory(_stDLApplication,2);
        //    frm.Show();
        //}

        //private void FillDataStructInfo(stDLApplication stDLApplication)
        //{
        //    _stDLApplication = stDLApplication;
        //}

        //private void ShowButton()
        //{
        //    btnIssueReplacement.Enabled = true;
        //}
    }
}
