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


namespace DVLD.Controls.ApplicationControls
{
    public partial class ucDrivingLicenseApplication : UserControl
    {
        clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplication;
        private int _LocalDrivingLicenseAppID = -1; 
        private int _LicenseID = -1; 

        public int LocalDrivingLicenseAppID
        {
            get
            {
                return _LocalDrivingLicenseAppID;
            }
            set
            {
                _LocalDrivingLicenseAppID = value;
            }
        }
        //stDLApplication _MyCurrentStruct2;     
        public ucDrivingLicenseApplication()
        {
            InitializeComponent();
            
        }

        //private bool _ShowLicenseInfoLkl;

        //public bool ShowLicenseInfoLkl
        //{
        //    get { return _ShowLicenseInfoLkl; }
        //    set { _ShowLicenseInfoLkl = value;}
        //}

        //public void SetValueToStruct(stDLApplication MyStruct)
        //{
        //    _MyCurrentStruct2 = MyStruct;
        //}
        
        //public void RefreshlklShowLicenseInfo()
        //{
        //    if(_ShowLicenseInfoLkl)
        //    {
        //        lklShowLicenseInfo.Enabled = true;
        //    }            
        //}

        public void LoadApplicationInfoByLocalDrivingLicenseID(int localDrivingLicenseAppID)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.FindByLocalDrivingAppLicenseID(localDrivingLicenseAppID);  
            if( _LocalDrivingLicenseApplication != null )
            {
                _FillLocalLicenseApplicationInfo();
            }
            else
            {
                MessageBox.Show("No Application with LocalDrivingLicenseAppID = " + localDrivingLicenseAppID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetDefaultValues();
                return;
            }
        }

        public void LoadApplicationInfoByApplicationID(int ApplicationID)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.FindByApplicationID(ApplicationID);
            if (_LocalDrivingLicenseApplication != null)
            {
                _FillLocalLicenseApplicationInfo();
            }
            else
            {
                MessageBox.Show("No Application with AppID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetDefaultValues();
            }
        }

        public void ResetDefaultValues()
        {
            lblDLAppliID.Text = "[????]";
            lblAppliedForLicense.Text = "[????]";
            ucApplicationBasicInfo1.ResetDefaultValues();
        }

        
        private void _FillLocalLicenseApplicationInfo()
        {
            // _LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();
           // lklShowLicenseInfo.Enabled = (_LicenseID != -1);
            //lblPassedTests.Text = localDrivingLicenseApplications.GetPassedTestCount().ToString() + "/3";            
            lblDLAppliID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblAppliedForLicense.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            ucApplicationBasicInfo1.LoadApplicationInfo(_LocalDrivingLicenseApplication.ApplicationID);
            
        }        

        private void lklShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //frmShowLicenseInfo frm = new frmShowLicenseInfo(_LocalDrivingLicenseApplication.GetActiveLicenseID());
            //frm.Show();
        }
    }
}
