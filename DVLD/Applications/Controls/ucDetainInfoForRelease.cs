using DVLD_Bussiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DVLD.Login;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Classes;

namespace DVLD
{
    public partial class ucDetainInfoForRelease : UserControl
    {
        private clsDetainLicenses _DetainLicense;
        public ucDetainInfoForRelease()
        {
            InitializeComponent();

        }
        
        private clsLicenses _License;
        public clsLicenses License
        {
            get
            {
                return _License;
            }
            set
            {
                _License = value;
            }
        }

        private void ucDetainInfo_Load(object sender, EventArgs e)
        {       

        }
        
        public void FillucApplicationNewLicenseInfo()
        {
            _DetainLicense = clsDetainLicenses.FindDetainedLicenseInfoByLicenseID(_License.LicenseID);
            if (_DetainLicense.IsReleased)
            {
                lblDetainID.Text        = "[????]";
                lblDetainDate.Text      = "[????]";
                lblApplicationFees.Text = "[????]";
                lblFineFees.Text        = "[????]";
                lblApplicationFees.Text = "[????]";
                lblTotalFees.Text       = "[????]";
                lblLicenseID.Text       = "[????]";
                lblCreatedBy.Text       = "[????]";
                return;
            }                
            int ApplicationFees = (int)clsApplicationTypes.Find(5).ApplicationFees;
            lblDetainID.Text = _DetainLicense.DetainID.ToString();
            lblDetainDate.Text = _DetainLicense.DetainDate.ToString("dd/MMM/yyyy");
            lblApplicationFees.Text = "";
            lblFineFees.Text = ((int)_DetainLicense.FineFees).ToString();
            lblApplicationFees.Text = ApplicationFees.ToString();
            lblTotalFees.Text = ((int)_DetainLicense.FineFees + ApplicationFees).ToString();
            lblLicenseID.Text = _License.LicenseID.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName.ToString();
        }

        public void RefreshRLAppID(int RLAppID)
        {
            lblReleaseAppID.Text = RLAppID.ToString();

        }
                
    }
}
