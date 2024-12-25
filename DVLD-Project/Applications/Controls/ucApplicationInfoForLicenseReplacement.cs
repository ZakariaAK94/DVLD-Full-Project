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

namespace DVLD
{
    public partial class ucApplicationInfoForLicenseReplacement : UserControl
    {
        private clsLicenses _License;
        private byte _IssueReason;

        public byte IssueReason
        {
            get
            {
                return _IssueReason;
            }
            set
            {
                _IssueReason = value;
            }
        }
        public ucApplicationInfoForLicenseReplacement()
        {
            InitializeComponent();
           
        }

        private int _ILApplicationID;
        public int ILApplicationID
        {
            get
            {
                return _ILApplicationID;
            }
            set
            {
                _ILApplicationID = value;
            }
        }

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

        private void ucApplicationInfoForLicenseReplacement_Load(object sender, EventArgs e)
        {

            lblApplicationDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");           
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName.ToString();
            

        }

        public void FillucApplicationNewLicenseInfo()
        {        
            int ApplicationFees = (byte)clsApplicationTypes.Find(_IssueReason).ApplicationFees;
            lblApplicationFees.Text = (ApplicationFees).ToString();           
            lblOldLicenseID.Text = _License.LicenseID.ToString();
        }

        public void ChangeApplicationFees()
        {
            int ApplicationFees = (int)clsApplicationTypes.Find(_IssueReason).ApplicationFees;
            lblApplicationFees.Text = (ApplicationFees).ToString();            
        }

        public void RefreshRLApplicationIDAndRenewLLicenseID(int RLApplicationID, int RenewLicenseID)
        {
            lblRLApplicationID.Text = RLApplicationID.ToString();
            lblRenewLLicenseID.Text = RenewLicenseID.ToString();
        }

        public void ReceiveData(int data)
        {
            lblOldLicenseID.Text = data.ToString(); // Assuming lblDataReceived is a Label in the target control
        }

       
    }
}
