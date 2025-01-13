using DVLD_Bussiness;
using DVLD.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Controls;
using DVLD.People;
using ProjectDVLD;


namespace DVLD.Controls
{
    public partial class ucPersonCard : UserControl
    {
        private int _PersonID=-1;
        public int PersonID
        {
            get
            {
                return _PersonID;
            }
        }
        private clsPerson _Person;
        public clsPerson SelectedPeronInfo
        {
            get { return _Person; }
        }
        public ucPersonCard()
        {
            InitializeComponent();           
        }      

       

        public void ResetPersonInfo()
        {
            string str = "[????]";
            lblPersonID.Text = str;
            lblName.Text = str;
            lblName.ForeColor = Color.Red;
            lblNationalNo.Text = str;
            lblEmail.Text = str;
            lblGendor.Text = str;
            pBImageOfperson.Image = DVLD.Properties.Resources.Male_512;
            lblAddress.Text = str;
            lblCountry.Text = str;
            lblPhone.Text = str;
            lblDateOfBirth.Text = str;
            lklEditPerson.Enabled = false;
        }        

        public void LoadPersonInfo(int PersonID)
        {
           _PersonID=PersonID;
           _Person = clsPerson.Find(_PersonID); 
            if(_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No person exists with personID "+_PersonID,"Information",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }

        public void LoadPersonInfo(string NationalNo)
        {            
            _Person = clsPerson.Find(NationalNo);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No person exists with NationalNo " + NationalNo, "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }

        private void _FillPersonInfo()
        {
            lblPersonID.Text = _Person.PersonID.ToString();
            lblName.Text = _Person.FullName;
            lblName.ForeColor = Color.Red;
            lblNationalNo.Text = _Person.NationalNo;
            lblEmail.Text = _Person.Email;
            lblGendor.Text = (_Person.Gender == 0 ? "Male" : "Female");            
            lblAddress.Text = _Person.Address;
            lblCountry.Text = _Person.CountryInfo.CountryName;
            lblPhone.Text = _Person.Phone;
            lblDateOfBirth.Text = clsFormat.DateToShort(_Person.DateOfBirth);
            lklEditPerson.Enabled = true;
            _LoadPersonImage();
        }

        private void _LoadPersonImage()
        {
            if (_Person.ImagePath != "")
            {
                pBImageOfperson.ImageLocation = _Person.ImagePath;
            }
            else
            {
                if (lblGendor.Text == "Male")
                {
                    pBImageOfperson.Image = DVLD.Properties.Resources.Male_512;
                    pboxGendor.Image = DVLD.Properties.Resources.Man_32;
                }
                else
                {
                    pBImageOfperson.Image = DVLD.Properties.Resources.Female_512;
                    pboxGendor.Image = DVLD.Properties.Resources.Woman_32; ;
                }
            }

        }
        private void lklEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddOrUpdate frm = new frmAddOrUpdate(_PersonID);
            frm.ShowDialog();
            // refresh data
            LoadPersonInfo(_PersonID);
        }
        private void ucPersonCard_Load(object sender, EventArgs e)
        {
           //ResetPersonInfo();
        }
    }
}
