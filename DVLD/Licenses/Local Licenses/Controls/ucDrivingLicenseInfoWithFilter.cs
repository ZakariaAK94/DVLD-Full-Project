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
using System.Xml.Linq;
using DVLD.Login;
using static System.Net.Mime.MediaTypeNames;
using DVLD.Classes;
using static DVLD_Bussiness.clsApplications;
using static DVLD_Bussiness.clsLicenses;

namespace DVLD
{
    public partial class ucDrivingLicenseInfoWithFilter : UserControl
    {
        //Define a custom event handler delegate with parameters
        public event Action<int> OnLicenseSelected;
        // create a protocted method to raise the event with parameter
        protected virtual void PersonSelected(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;

            if(handler != null && _FilterEnabled)
            {
                handler(LicenseID);
            }
        }

        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            { 
                _FilterEnabled = value;
                gBFilter.Enabled = _FilterEnabled;
            }
        }

        private int _LicenseID=-1;

        public int LicenseID
        {
            get
            {
                return ucDriverLicenseInfo2.LicenseID;
            }
        }

        public clsLicenses SelectedLicenseInfo
        {
            get
            {
                return ucDriverLicenseInfo2.SelectedLicense;
            }
        }
        

        public void LoadLicenseInfo(int LicenseID)
        {
            txtBoxLicenseID.Text = LicenseID.ToString();
            ucDriverLicenseInfo2.LoadInfo(LicenseID);
            _LicenseID = ucDriverLicenseInfo2.LicenseID;
            if(OnLicenseSelected != null && _FilterEnabled)
            {
                OnLicenseSelected(LicenseID);
            }
        }
        public ucDrivingLicenseInfoWithFilter()
        {
            InitializeComponent();
        }
              
       
        private void btnSearchLicenseInfo_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valid, please check and retry!!", "Not Valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _LicenseID = int.Parse(txtBoxLicenseID.Text);
            LoadLicenseInfo(_LicenseID);
        }

        private void txtBoxLicenseID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxLicenseID.Text))
            {
                e.Cancel = true; // Prevents focus from leaving the control
                errorProvider1.SetError(txtBoxLicenseID, "txtBox is Empty!!!!.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtBoxLicenseID, "");
            }
            //else
            //{
            //    if (/*!clsLicenses.CheckIfLicenseIDExist(int.Parse(txtBoxLicenseID.Text)))*/ true)
            //    {
            //        e.Cancel = true; // Prevents focus from leaving the control
            //        errorProvider1.SetError(txtBoxLicenseID, "LicenseID doesn't exist in the database!!!");
            //    }
            //    else
            //    {
            //        e.Cancel = false;
            //        errorProvider1.SetError(txtBoxLicenseID, "");
            //    }
                
            //}
        }

        

        private void txtBoxLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);

            if (e.KeyChar == (char)13)
                btnSearchLicenseInfo.PerformClick();
        }

        public void txtLicenseIDFocus()
        {
            txtBoxLicenseID.Focus();    
        }




        //public stDLApplication stDLApplication
        //{
        //    get { return _stDLApplication; }
        //}
        //private int _LicenseID = 0;
        //public int LicenseID
        //{
        //    get
        //    {
        //        return _LicenseID;
        //    }
        //    set
        //    {
        //        _LicenseID = value;
        //    }
        //}
        //private void _FillMyStruct(clsLicenses License)
        //{
        //    _Application = clsApplications.FindBaseApplication(License.ApplicationID);
        //    _Person = clsPerson.Find(_Application.ApplicantPersonID);
        //    _ApplicationType = clsApplicationTypes.Find(_Application.ApplicationTypeID);
        //    _LicenseClass = clsLicenseClasses.FindByLicenseClassID(License.LicenseClassID);
        //    _stDLApplication._ApplicantPersonID = _Application.ApplicantPersonID;
        //    _stDLApplication._LastStatusDate = _Application.LastStatusDate;
        //    _stDLApplication._ClassName = _LicenseClass.ClassName;
        //    _stDLApplication._NationalNo = _Person.NationalNo;
        //    _stDLApplication._FullName = _Person.FirstName + " " + _Person.SecondName + " " + _Person.ThirdName + " " + _Person.LastName;
        //    _stDLApplication._ApplicationID = License.ApplicationID;
        //    // _stDLApplication._ClassFees = _LicenseClass.ClassFees;            
        //    _stDLApplication._ApplicationTypeID = _ApplicationType.ApplicationTypeID;
        //    _stDLApplication._ApplicationTypeTitle = _ApplicationType.ApplicationTypeTitle;
        //    _stDLApplication._ApplicationFees = _ApplicationType.ApplicationFees;
        //    _stDLApplication._CurrentUserName = clsGlobal.CurrentUser.UserName;
        //}

        //private void btnSearchLicenseInfo_Click(object sender, EventArgs e)
        //{
        //    BtnHided?.Invoke();

        //    if (!CheckLicenseDateExpiration())
        //    {
        //        lklShowLicensesHistoryEnabled?.Invoke();
        //        DataSentForStruct?.Invoke(stDLApplication);
        //        return;
        //    }
        //    BtnShowed?.Invoke();
        //    lklShowLicensesHistoryEnabled?.Invoke();
        //    if (string.IsNullOrEmpty(txtBoxLicenseID.Text))
        //    {
        //        MessageBox.Show("Please enter LicenseID !!!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        //        return;
        //    }
        //    //else if(!clsLicenses.FindLicenseInfoByLicenseID(_LicenseID).IsActive) to be checked the same btn worked for != fcts
        //    else if (!_License.IsActive)
        //    {
        //        _FillMyStruct(_License);
        //        OnDataSent();
        //        //ucDriverLicenseControl2.SetValueToStruct(_stDLApplication);
        //        //ucDriverLicenseControl2.License = _License;
        //        //ucDriverLicenseControl2.Person = _Person;
        //        //ucDriverLicenseControl2.ucDriverLicenseControlLoad();
        //        BtnHided?.Invoke();
        //        MessageBox.Show("local license is inactive, please chekc and retry!!! ", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        //        return;
        //    }
        //    else
        //    {

        //        _FillMyStruct(_License);
        //        OnDataSent();
        //        //ucDriverLicenseControl2.SetValueToStruct(_stDLApplication);
        //        //ucDriverLicenseControl2.License = _License;
        //        //ucDriverLicenseControl2.Person = _Person;
        //        //ucDriverLicenseControl2.ucDriverLicenseControlLoad();

        //        return;
        //    }

        //}
        //public void OnDataSent()
        //{
        //    DataSent?.Invoke(_License);
        //}
        //public void RefreshLicenseValidity()
        //{
        //    ucDriverLicenseControl2.ucDriverLicenseControlUpdateActivityOfLicense();
        //}

        //public void RefreshLicenseDetain()
        //{
        //    ucDriverLicenseControl2.ucDriverLicenseControlUpdateDetainLicense();
        //}

        //public bool CheckLicenseDateExpiration()
        //{
        //    _LicenseID = int.Parse(txtBoxLicenseID.Text);
        //    _License = clsLicenses.FindLicenseInfoByLicenseID(_LicenseID);
        //    if (_License.ExpirationDate > DateTime.Now)
        //    {
        //        if (_IssueReason == 3 || _IssueReason == 4)
        //        {
        //            return true;
        //        }
        //        else if (_DetainLicense)
        //        {
        //            int DetainID = clsDetainLicenses.CheckIfLicenseIsDetain(_LicenseID);
        //            if (DetainID != -1)
        //            {
        //                DataSent?.Invoke(_License);
        //                _FillMyStruct(_License);
        //                //ucDriverLicenseControl2.SetValueToStruct(_stDLApplication);
        //                //ucDriverLicenseControl2.ucDriverLicenseControlLoad();
        //                _DetainedLicense = clsDetainLicenses.FindDetainedLicenseInfoByLicenseID(_License.LicenseID);
        //                if (_DetainedLicense.IsReleased)
        //                    return true;
        //                else
        //                {
        //                    MessageBox.Show("Selected License is already detained, the DetainID is: " + DetainID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    return false;
        //                }
        //            }
        //            return true;
        //        }
        //        else if (_ReleaseDetainedLicense)
        //        {
        //            int DetainID = clsDetainLicenses.CheckIfLicenseIsDetain(_LicenseID);
        //            if (DetainID != -1)
        //            {
        //                DataSent?.Invoke(_License);
        //                _FillMyStruct(_License);
        //                //ucDriverLicenseControl2.SetValueToStruct(_stDLApplication);
        //                //ucDriverLicenseControl2.ucDriverLicenseControlLoad();
        //                _DetainedLicense = clsDetainLicenses.FindDetainedLicenseInfoByLicenseID(_License.LicenseID);
        //                if (!_DetainedLicense.IsReleased)
        //                {
        //                    _stDLApplication.IsDetain = true;
        //                    return true;
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Selected License is not detained, please choose another one", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    _stDLApplication.IsDetain = false;
        //                    return false;
        //                }

        //            }
        //            return true;

        //        }

        //        DataSent?.Invoke(_License);
        //        _FillMyStruct(_License);
        //        //ucDriverLicenseControl2.SetValueToStruct(_stDLApplication);
        //        //ucDriverLicenseControl2.ucDriverLicenseControlLoad();
        //        MessageBox.Show("Selected License is not yet expaired, it will expire on:" + _License.ExpirationDate.ToShortDateString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //    return true;
        //}

        //public void TriggerButtonClick()
        //{
        //    // Simulate button click
        //    txtBoxLicenseID.Text = _LicenseID.ToString();
        //    btnSearchLicenseInfo.PerformClick();
        //}

        //public void btnSearchHided()
        //{
        //    gBFilter.Enabled = false;
        //}

        //private clsLicenses _License;
        //private clsLicenseClasses _LicenseClass;
        //private clsApplications _Application;
        //private clsApplicationTypes _ApplicationType;
        //private clsPerson _Person;
        //private clsDetainLicenses _DetainedLicense;
        //public delegate void EventHandlerSendStruct(stDLApplication stDLApplication);
        //public event EventHandlerSendStruct DataSentForStruct;
        //public delegate void EventHandlerHideOrShowButton();
        //public event EventHandlerHideOrShowButton BtnHided;
        //public event EventHandlerHideOrShowButton BtnShowed;
        //public event EventHandlerHideOrShowButton lklShowLicensesHistoryEnabled;
        //private byte _IssueReason;
        //public byte IssueReason
        //{
        //    set
        //    {
        //        _IssueReason = value;
        //    }
        //}

        //private bool _DetainLicense;
        //public bool DetainLicense
        //{
        //    set
        //    {
        //        _DetainLicense = value;
        //    }
        //}

        //private bool _ReleaseDetainedLicense;
        //public bool ReleaseDetainedLicense
        //{
        //    set
        //    {
        //        _ReleaseDetainedLicense = value;
        //    }
        //}

        //private stDLApplication _stDLApplication;
        //public delegate void EventHandler(int LicenseID);
        //public event EventHandler DataSent;

    }
}
