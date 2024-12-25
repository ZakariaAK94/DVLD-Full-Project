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
using DVLD.Drivers;
using DVLD.Licenses;
using static DVLD.ucDrivingLicenseInfoWithFilter;
using DVLD.Classes;

namespace DVLD.Applications
{
    public partial class frmRenewLicenseApplication : Form
    {
        //public delegate void EventHandlerRefreshedData();
        //public event EventHandlerRefreshedData DataRefreshed;      
        //private stDLApplication _stDLApplication;
        //private clsApplications _OldApplication;
        //private clsApplications _RenewApplication;
        //private clsLicenses _OldLicense;
        //private clsLicenses _NewLicense;
        private int _NewLicenseID = -1;

       
        public frmRenewLicenseApplication()
        {
            InitializeComponent();      
            //ucLocalLicenseInfo3.BtnShowed += ShowButton;
            //ucLocalLicenseInfo3.BtnHided += HideButton;
            
            //ucLocalLicenseInfo3.lklShowLicensesHistoryEnabled += lklShowLicensesHistoryEnabled;
            //ucLocalLicenseInfo3.DataSent += GetDataSent;
            //ucLocalLicenseInfo3.DataSentForStruct += FillDataStructInfo;
        }
        private void frmRenewLicenseApplication_Load(object sender, EventArgs e)
        {
            ucDrivingLicenseInfoWithFilter1.txtLicenseIDFocus();

            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = lblApplicationDate.Text;
            lblExpirationDate.Text = "????";
            lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.RenewDrivingLicense).ApplicationFees.ToString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName.ToString();
        }

        private void btnRenewLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to renew this license with ID" + ucDrivingLicenseInfoWithFilter1.LicenseID,
                "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                clsLicenses NewLicense = ucDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.RenewLicense(txtNotes.Text.Trim(), clsGlobal.CurrentUser.UserID);
                if (NewLicense == null)
                {
                    MessageBox.Show("Error: Data failed to add", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    btnRenewLicense.Enabled = false;
                    return;
                }
                _NewLicenseID = NewLicense.LicenseID;
                lblRenewedLicenseID.Text = _NewLicenseID.ToString();
                lblApplicationID.Text = NewLicense.ApplicationID.ToString();
                MessageBox.Show("Renew license was successfully add wiTh ID " + _NewLicenseID, "Informatin", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information);
                btnRenewLicense.Enabled = false;
                lklShowNewLicensesHistory.Enabled = false;
                lklShowLicensesHistory.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lklShowNewLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_NewLicenseID);
            frm.Show();
        }

        private void ucDrivingLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            lblOldLicenseID.Text = SelectedLicenseID.ToString();
            lklShowLicensesHistory1.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)
            {
                return;
            }

            int DefaultValidityLenght = ucDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassInfo.DefaultValidityLength;
            lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(DefaultValidityLenght));
            lblLicenseFees.Text = ucDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassInfo.ClassFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblLicenseFees.Text) + Convert.ToSingle(lblApplicationFees.Text)).ToString();
            txtNotes.Text = ucDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.Notes;
            // check if license expired or not
            if (!ucDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Current license is not expired yet", "Not Expired yet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnRenewLicense.Enabled = false;
                return;
            }
            // check if license is Active or not
            if (ucDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Current license is not active", "Not Active", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnRenewLicense.Enabled = false;
                return;
            }

            btnRenewLicense.Enabled = true;



        }

        private void frmRenewLicenseApplication_Activated(object sender, EventArgs e)
        {
            ucDrivingLicenseInfoWithFilter1.txtLicenseIDFocus();
        }

        private void lklShowLicensesHistory1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //if (_OldLicense.LicenseID == 0)
            //{
            //    MessageBox.Show("Please enter a licenseID to open this windows", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //    return;
            //}
            //  _stDLApplication = ucLocalLicenseInfo3.stDLApplication;
            

            //frmDriverLicenseInfo frm = new frmDriverLicenseInfo(_stDLApplication, _NewLicense);
            //frm.Show();
        }












        //private void HideButton()
        //{
        //    btnRenewLicense.Enabled = false;
        //}

        //private void GetDataSent(clsLicenses License)
        //{
        //    _OldLicense = License;
        //    ucApplicationNewLicenseInfo3.License = License;
        //    ucApplicationNewLicenseInfo3.FillucApplicationNewLicenseInfo();
        //}

        //private void lklShowLicensesHistoryEnabled()
        //{
        //    lklShowLicensesHistory1.Enabled = true;
        //}

        //public bool CheckLicenseExpirationDate()
        //{
        //    //ucLocalLicenseInfo3.DataSent += SetLicenseIDData;
        //    //return ucLocalLicenseInfo3.CheckLicenseDateExpiration();
        //    return false;
        //}

        //public void SetLicenseIDData(clsLicenses  license)
        //{
        //    _OldLicense = license;
        //    ucApplicationNewLicenseInfo3.License = _OldLicense;
        //}




        //private void btnRenewLicense_Click(object sender, EventArgs e)
        //{            
        //    _RenewApplication = new clsApplications();
        //    _OldApplication = clsApplications.FindBaseApplication(_OldLicense.ApplicationID);
        //    _RenewApplication.ApplicantPersonID = _OldApplication.ApplicantPersonID;
        //    _RenewApplication.ApplicationDate = DateTime.Now;
        //    _RenewApplication.ApplicationTypeID = 2;
        //    _RenewApplication.ApplicationStatus = _OldApplication.ApplicationStatus;
        //    _RenewApplication.LastStatusDate = _RenewApplication.ApplicationDate;
        //    _RenewApplication.LastStatusDate = _RenewApplication.ApplicationDate;
        //    _RenewApplication.PaidFees = clsApplicationTypes.Find(2).ApplicationFees;
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
        //    _NewLicense.Notes = ucApplicationNewLicenseInfo3.Notes;
        //    _NewLicense.PaidFees = _OldLicense.PaidFees;
        //    _NewLicense.IsActive = true;
        //    //_NewLicense.IssueReason = 2;
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
        //    btnRenewLicense.Enabled = false;
        //    //ucLocalLicenseInfo3.btnSearchHided();
        //    lklShowNewLicensesHistory.Enabled = true;
        //    ucApplicationNewLicenseInfo3.RefreshRLApplicationIDAndRenewLLicenseID(_RenewApplication.ApplicationID, _NewLicense.LicenseID);
        //    //ucLocalLicenseInfo3.RefreshLicenseValidity();
        //    btnRenewLicense.Enabled = false;


        //}



        //private void FillDataStructInfo(stDLApplication stDLApplication)
        //{
        //    _stDLApplication = stDLApplication;
        //}
        //private void ShowButton()
        //{
        //    btnRenewLicense.Enabled = true;
        //}



    }
}   
