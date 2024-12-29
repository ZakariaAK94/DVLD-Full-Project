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
using System.IO;

namespace DVLD
{
    public partial class ucDriverLicenseInfo : UserControl
    {
        //private enum _enIssueReason { FirstTime =1, Renew=2, ReplacementforLost = 3, ReplacementforDamaged = 4 };

        //stDLApplication _MyCurrentStruct4;
        //clsPerson _Person;
        //clsLicenses _License;       

        private int _LicenseID;
        private clsLicenses _License;

        public clsLicenses SelectedLicense
        {
            get
            {
                return _License;
            }
        }

        public int LicenseID
        {
            get
            {
                return _LicenseID;
            }
        }


        public ucDriverLicenseInfo()
        {
            InitializeComponent();            
        }

        private void _LoadPersonImage()
        {
            if (_License.DriverInfo.PersonInfo.ImagePath == "")
            {
                if (lblGendor.Text == "Male")
                    pBImageOfperson.Image = Resources.Male_512;
                else
                    pBImageOfperson.Image = Resources.Female_512;
            }

            string ImagePath = _License.DriverInfo.PersonInfo.ImagePath;
            if (ImagePath !="")
            {
                if (File.Exists(ImagePath))
                    pBImageOfperson.Load(ImagePath);
                else
                    MessageBox.Show("Image not found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        public void LoadInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
            _License = clsLicenses.FindLicenseInfoByLicenseID(_LicenseID);
            if( _License == null )
            {
                MessageBox.Show("No license exist with LicenseID = " + _LicenseID.ToString(), "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblLicenseID.Text = _License.LicenseID.ToString();
            lblClass.Text = _License.LicenseClassInfo.ClassName;
            lblName.Text = _License.DriverInfo.PersonInfo.FullName;
            lblNationalNo.Text = _License.DriverInfo.PersonInfo.NationalNo;
            lblGendor.Text = (_License.DriverInfo.PersonInfo.Gender == 0 ? "Male":"Female");            
            lblDateOfBirth.Text = _License.DriverInfo.PersonInfo.DateOfBirth.ToString("dd/MMM/yyyy");
            lblDateOfExpiration.Text = _License.ExpirationDate.ToString("dd/MMMM/yyyy");
            lblIssueDate.Text = _License.IssueDate.ToString("dd/MMM/yyyy");
            lblNote.Text = (_License.Notes == "" ? "No Notes" : _License.Notes);            
            lblIsActive.Text = _License.IsActive ? "Yes" : "No";
            lblDriverID.Text = _License.DriverID.ToString();
            lblIsDetained.Text = (_License.IsDetained == true ? "Yes" : "No");
            lblIssueReason.Text = _License.IssueReasonText;
            
            _LoadPersonImage();

        }

        //public void SetValueToStruct(stDLApplication MyStruct)
        //{
        //    _MyCurrentStruct4 = MyStruct;
        //}

        //public clsLicenses License { get { return _License; } set {  _License = value; } }

        //public clsPerson Person { get { return _Person; } set { _Person = value; } }

        //public void ucDriverLicenseControlLoad()
        //{
        //    if(_Person == null)
        //        _Person = clsPerson.Find(_MyCurrentStruct4._ApplicantPersonID);
        //    lblClass.Text = _MyCurrentStruct4._ClassName;
        //    lblName.Text = _Person.FirstName + " " + _Person.LastName + " "+ _Person.ThirdName + " "+ _Person.LastName;
        //    lblNationalNo.Text= _Person.NationalNo;
        //    if (_Person.Gender == 0)
        //        lblGendor.Text = "Female";
        //    else
        //        lblGendor.Text = "Male";
        //    lblDateOfBirth.Text = _Person.DateOfBirth.ToString("dd/MMM/yyyy");
        //    if(_Person.ImagePath == "")
        //    {
        //        if (lblGendor.Text == "Male")
        //            pBImageOfperson.Image = Image.FromFile("C:\\Users\\AKILZA\\Desktop\\projet DVLC pictures\\man1.png");
        //        else
        //            pBImageOfperson.Image = Image.FromFile("C:\\Users\\AKILZA\\Desktop\\projet DVLC pictures\\woman1.png");
        //    }
        //    else
        //        pBImageOfperson.Load(_Person.ImagePath);

        //    if (_License == null)
        //        _License = clsLicenses.FindLicenseInfoByApplicationID(_MyCurrentStruct4._ApplicationID);
        //    lblDateOfExpiration.Text = _License.ExpirationDate.ToString("dd/MMMM/yyyy");
        //    lblIssueDate.Text = _License.IssueDate.ToString("dd/MMM/yyyy");
        //    if (_License.Notes == "")
        //        lblNote.Text = "No Notes";
        //    else
        //        lblNote.Text = _License.Notes;
        //    switch(_License.IssueReason)
        //    {
        //        case (byte)_enIssueReason.FirstTime:
        //            lblIssueReason.Text = "First Time";
        //            break;
        //        case (byte)_enIssueReason.Renew:
        //            lblIssueReason.Text = "Renew";
        //            break;
        //        case (byte)_enIssueReason.ReplacementforLost:
        //            lblIssueReason.Text = "Replacement for Lost";
        //            break;
        //        case (byte)_enIssueReason.ReplacementforDamaged:
        //            lblIssueReason.Text = "Replacement for Damaged";

        //            break;

        //    }
        //    lblIsActive.Text = _License.IsActive ? "Yes" : "No";
        //    lblDriverID.Text = _License.DriverID.ToString();
        //    if (_MyCurrentStruct4.IsDetain)
        //    {
        //        lblIsDetained.Text = "Yes";
        //    } 
        //    else
        //    {
        //        lblIsDetained.Text = "No";
        //    }                     
        //    lblLicenseID.Text = _License.LicenseID.ToString();


        //}

        //public void ucDriverLicenseControlUpdateActivityOfLicense()
        //{          
        //    lblIsActive.Text = _License.IsActive ? "Yes" : "No";          
        //}

        //public void ucDriverLicenseControlUpdateDetainLicense()
        //{
        //    lblIsDetained.Text = "Yes";

        //}


    }
    
    
}

