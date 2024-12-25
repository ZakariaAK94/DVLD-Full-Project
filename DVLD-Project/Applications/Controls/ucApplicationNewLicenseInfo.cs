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
    public partial class ucApplicationNewLicenseInfo : UserControl
    {
        private clsLicenses _License;

       
        private string _Notes;        
        public string Notes
        {
            get { return _Notes; }
        }
        public ucApplicationNewLicenseInfo()
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

        private void ucApplicationNewLicenseInfo_Load(object sender, EventArgs e)
        {
           
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblIssueDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName.ToString();
            lblApplicationFees.Text = ((int)clsApplicationTypes.Find(2).ApplicationFees).ToString();          
                        
        }

        public void FillucApplicationNewLicenseInfo()
        {
            //_License = clsLicenses.FindLicenseInfoByLicenseID(_ILLicenseID);
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblIssueDate.Text = _License.IssueDate.ToString("dd/MMM/yyyy");
            lblDateOfExpiration.Text = _License.ExpirationDate.ToString("dd/MMM/yyyy");
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName.ToString();
            int ApplicationFees = (int)clsApplicationTypes.Find(2).ApplicationFees;
            lblApplicationFees.Text = (ApplicationFees).ToString();
            lblLicenseFees.Text = ((int)_License.PaidFees).ToString();
            lblTotalFees.Text = ((int)_License.PaidFees + ApplicationFees).ToString();
            lblOldLicenseID.Text = _License.LicenseID.ToString();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _Notes = txtBoxNotes.Text;
        }
    }
}
