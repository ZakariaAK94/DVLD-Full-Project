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
using DVLD.Properties;

namespace DVLD
{
    public partial class ucDriverInternationalLicenseInfo : UserControl
    {
        private int _InternationalLicenseID;
        private clsInternationalLicenses _InternationalLicenses;
        public ucDriverInternationalLicenseInfo()
        {
            InitializeComponent();            
        }

        public int InternationalLicenseID
        {
            get { return _InternationalLicenseID; }
        }
        

        private int _LicenseID;

        public int LicenseID
        {
            set
            {
                _LicenseID = value;
            }
        }

        private void _LoadImage()
        {          
            if (_InternationalLicenses.DriverInfo.PersonInfo.ImagePath == "")
            {
                pBImageOfperson.Image = (lblGendor.Text == "Male" ? Resources.Male_512 : Resources.Female_512);
                
            }
            else
                pBImageOfperson.Load(_InternationalLicenses.DriverInfo.PersonInfo.ImagePath);
        }

        public void LoadInfo(int InternationalLicenseID)
        {
            _InternationalLicenseID = InternationalLicenseID;
            _InternationalLicenses = clsInternationalLicenses.FindInternationalLicenseInfoByInterLicenseID(_InternationalLicenseID);
            if (_InternationalLicenses == null)
            {
                MessageBox.Show("There is no international license for ID " + _InternationalLicenseID.ToString(), "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblDateOfBirth.Text = _InternationalLicenses.DriverInfo.PersonInfo.DateOfBirth.ToString("dd/MMM/yyyy");
            lblGendor.Text = (_InternationalLicenses.DriverInfo.PersonInfo.Gender == 0 ? "Male" : "Female");
            lblName.Text = _InternationalLicenses.DriverInfo.PersonInfo.FullName;
            lblNationalNo.Text = _InternationalLicenses.DriverInfo.PersonInfo.NationalNo;           
            lblDateOfExpiration.Text = _InternationalLicenses.ExpirationDate.ToString("dd/MMMM/yyyy");
            lblIssueDate.Text = _InternationalLicenses.IssueDate.ToString("dd/MMM/yyyy");
            lblIsActive.Text = _InternationalLicenses.IsActive ? "Yes" : "No";
            lblDriverID.Text = _InternationalLicenses.DriverID.ToString();
            lblInterLicenseID.Text = _InternationalLicenses.InternationalLicenseID.ToString();
            lblLicenseID.Text = _InternationalLicenses.IssuedUsingLocalLicenseID.ToString();
            lblApplicationID.Text = _InternationalLicenses.ApplicationID.ToString();
            _LoadImage();
        }
    }
}
