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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DVLD.Global_Classes;

namespace DVLD.Applications
{
    public partial class frmDetainLicenseApplication : Form
    {
        //public delegate void EventHandlerRefreshedData();
        //public event EventHandlerRefreshedData DataRefreshed;         

        //private clsLicenses _OldLicense;
        //private clsLicenses _NewLicense;
        //private clsDetainLicenses _DetainLicense;

        //private stDLApplication _stDLApplication;

        //private bool _IsDetain = false;

        private int _DetainID = -1;
        private int _SelectedLicenseID = -1;
        public frmDetainLicenseApplication()
        {
            InitializeComponent();
          
            //ucLocalLicenseInfo4.DetainLicense = true;
            //ucLocalLicenseInfo4.BtnShowed += ShowButton;
            //ucLocalLicenseInfo4.BtnHided += HideButton;            
            //ucLocalLicenseInfo4.lklShowLicensesHistoryEnabled += lklShowLicensesHistoryEnabled;
            //ucLocalLicenseInfo4.DataSent += GetDataSent;
            //ucLocalLicenseInfo4.DataSentForStruct += FillDataStructInfo;            
           //ucDetainInfo1.IssueReason = _IssueReason;

        }

      
        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to detain this license with ID " + ucDrivingLicenseInfoWithFilter1.LicenseID, "Confirmation",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                _DetainID = ucDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.Detain(Convert.ToSingle(txtBoxFineFees.Text.Trim()), clsGlobal.CurrentUser.UserID);

                if (_DetainID == -1)
                {
                    MessageBox.Show("Error: Detain license failed ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("license deainted successfully with ID "+_DetainID, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblDetainID.Text = _DetainID.ToString();
                btnDetain.Enabled = false;
                lklShowLicensesHistory1.Enabled = true;
                txtBoxFineFees.Enabled = false;
            }
            else
                return;

            //_DetainLicense = new clsDetainLicenses();
            //_DetainLicense.LicenseID = _OldLicense.LicenseID;
            //_DetainLicense.DetainDate = DateTime.Now;   
            ////_DetainLicense.FineFees = ucDetainInfo1.FineFees;
            //_DetainLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            //_DetainLicense.IsReleased = false;
            //if (_DetainLicense.Save())
            //{
            //    MessageBox.Show("information saved successufully!!", "information", MessageBoxButtons.OKCancel);
            //}
            //else
            //{
            //    MessageBox.Show("save information failed!!!", "information", MessageBoxButtons.OKCancel);
            //    return;
            //}
            //_stDLApplication.IsDetain = true;
            //btnDetain.Enabled = false;
            ////ucLocalLicenseInfo4.btnSearchHided();
            //lklShowNewLicensesInfo.Enabled = true;
            ////ucDetainInfo1.RefreshDetainID(_DetainLicense.DetainID);
            ////ucLocalLicenseInfo4.RefreshLicenseDetain();
            //btnDetain.Enabled = false;

        }

        private void lklShowLicensesHistory1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(ucDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lklShowNewLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            // _stDLApplication = ucLocalLicenseInfo4.stDLApplication;             
            frmShowLicenseInfo frm = new frmShowLicenseInfo(ucDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID);
            frm.Show();

        }

        private void frmDetainLicenseApplication_Load(object sender, EventArgs e)
        {
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            lblDetainDate.Text = clsFormat.DateToShort(DateTime.Now);
        }

        private void frmDetainLicenseApplication_Activated(object sender, EventArgs e)
        {
            ucDrivingLicenseInfoWithFilter1.txtLicenseIDFocus();
        }

        private void ucDrivingLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;
            lblLicenseID.Text = _SelectedLicenseID.ToString();
            lklShowLicensesHistory1.Enabled = (_SelectedLicenseID != -1);
            if(_SelectedLicenseID == -1)
            {
                return;
            }
            // To check license is not already detained
            if(ucDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected license is already detained, please choose another one","Not Allowed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if (ucDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected license is not Active, please choose another one", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnDetain.Enabled = true;
            ucDrivingLicenseInfoWithFilter1.FilterEnabled = false;
            txtBoxFineFees.Focus();
        }

        private void txtBoxFineFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxFineFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtBoxFineFees, "This field cannot be empty.");
                return;
            }
            else
            {
                e.Cancel = true;
                errorProvider1.SetError(txtBoxFineFees, null);
            }

            if (!clsValidation.IsNumber(txtBoxFineFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtBoxFineFees, "the value is not valid, please enter a number.");
                return;
            }
            else
            {
                e.Cancel = true;
                errorProvider1.SetError(txtBoxFineFees, null);
            }

        }


        //public void SetLicenseIDData(clsLicenses license)
        //{
        //    _OldLicense = license;
        //    // ucDetainInfo1.License = _OldLicense;
        //}

        //private void FillDataStructInfo(stDLApplication stDLApplication)
        //{
        //    _stDLApplication = stDLApplication;
        //}

        //private void ShowButton()
        //{
        //    btnDetain.Enabled = true;
        //}

        //private void HideButton()
        //{
        //    btnDetain.Enabled = false;
        //}

        //private void GetDataSent(clsLicenses License)
        //{
        //    _OldLicense = License;
        //    //ucDetainInfo1.License = License;
        //    //ucDetainInfo1.FillucApplicationNewLicenseInfo();
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


    }
}
