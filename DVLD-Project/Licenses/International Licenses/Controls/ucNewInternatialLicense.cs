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
    public partial class ucNewInternatialLicense : UserControl
    {
        public ucNewInternatialLicense()
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
        private int _ILLicenseID;
        public int ILLicenseID
        {
            get
            {
                return _ILLicenseID;
            }
            set
            {
                _ILLicenseID = value;
            }
        }

        private void ucNewInternatialLicense_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblIssueDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblDateOfExpiration.Text = DateTime.Now.AddDays(365).ToString("dd/MMM/yyyy");
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName.ToString();
            lblFees.Text = clsApplicationTypes.Find(6).ApplicationFees.ToString();
            lblILApplicationID.Text = _ILApplicationID.ToString();
            lblILLicenseID.Text = _ILLicenseID.ToString();  
        }

        public void RefreshILApplicationIDAndILLicenseID()
        {         
            lblILApplicationID.Text = _ILApplicationID.ToString();
            lblILLicenseID.Text = _ILLicenseID.ToString();
        }

        public void ReceiveData(int data)
        {
            lblLocalLicenseID.Text = data.ToString(); // Assuming lblDataReceived is a Label in the target control
        }

        private void gBDriverLicenseInfo_Enter(object sender, EventArgs e)
        {

        }
    }
}
