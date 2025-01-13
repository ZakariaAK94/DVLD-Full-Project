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
    public partial class ucDetainInfo : UserControl
    {
        
        public ucDetainInfo()
        {
            InitializeComponent();

        }

        private int _FineFees;
        public int FineFees
        {
            get
            {
                return _FineFees;
            }
            //set
            //{
            //    _ILApplicationID = value;
            //}
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

            lblDetainDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName.ToString();


        }

        public void FillucApplicationNewLicenseInfo()
        {                   
            lblLicenseID.Text = _License.LicenseID.ToString();
        }
        
        public void RefreshDetainID(int DetainID)
        {
            lblDetainID.Text = DetainID.ToString();
            
        }

        public void ReceiveData(int data)
        {
            lblLicenseID.Text = data.ToString(); // Assuming lblDataReceived is a Label in the target control
        }

        private void txtBoxFineFees_TextChanged(object sender, EventArgs e)
        {
            _FineFees = int.Parse(txtBoxFineFees.Text);
        }
    }
}
