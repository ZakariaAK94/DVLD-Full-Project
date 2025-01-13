using DVLD_Bussiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Remoting.Messaging;
using DVLD.Properties;
using System.Runtime.InteropServices;
using DVLD.Global_Classes;
using DVLD.Classes;
using DVLD.Controls;


namespace DVLD.People
{
    public partial class frmAddOrUpdate : Form
    {
        // Declare a delegate to be checked its utility
         public delegate void DataBackEventHandler(object sender, int PersonID);
        // Declare an event using the delegate
         public event DataBackEventHandler DataBack;

        public delegate void SendBackPersonIDtofrmAddNewUser(int PersonID);
        public event SendBackPersonIDtofrmAddNewUser DataBackSent;
        public enum enMode { AddNew = 0, Update = 1 };
        public enum enGender { Male = 0, Female = 1 };

        private enMode _Mode;
        private int _PersonID = -1;
        clsPerson _Person;
        
        private string _OrignalNationalNo;

        //private bool _IsValide; there is a fucntion called ValidateChildren

        public frmAddOrUpdate()
        {
            InitializeComponent();

            // have to be done in load function not here in constructor
            /*_Person = new clsPerson();*/
            _Mode = enMode.AddNew;

        }
        public frmAddOrUpdate(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            _Mode = enMode.Update;
            // have to be done in load function not here in constructor
            /*_Person = clsPerson.FindByUserID(PersonID);*/
           
        }

        private void _ResetDefaultValues()
        {
            _FillcmbBoxCountries();

            if (_Mode == enMode.AddNew)
            {
                lblAddOrUpdate.Text = "Add New Person";
                _Person = new clsPerson();
            }
            else
            {
                lblAddOrUpdate.Text = "Update Person";
                
            }
            // set default image for the person
            if (rbMale.Checked)
            {
                pBImageOfperson.Image = DVLD.Properties.Resources.Male_512;
            }
            else
                pBImageOfperson.Image = DVLD.Properties.Resources.Female_512;
            // hide or show labellink depending of the image
            lklblRemoveImage.Visible = (pBImageOfperson.ImageLocation != null);

            // initialize the value with the country where i live "Morocco"
            cmbBoxCountries.SelectedIndex = 118;
            // Set the maximum date allowed in the DateTimePicker
            dtPDateOfBirth.MaxDate = DateTime.Today.AddYears(-18);
            // limiting age to 100y
            dtPDateOfBirth.MinDate = DateTime.Today.AddYears(-100);

            txtBoxFirstName.Text = "";
            txtBoxSecondName.Text = "";
            txtBoxThirdName.Text = "";
            txtBoxLastName.Text = "";
            txtBoxNationalNo.Text = "";
            rbMale.Checked = true;
            txtBoxPhone.Text = "";
            txtBoxEmail.Text = "";
            txtBoxAddress.Text = "";
        }

        private void _FillcmbBoxCountries()
        {
            DataTable dt = clsCountry.GetAllCountries();
            foreach (DataRow row in dt.Rows)
            {
                cmbBoxCountries.Items.Add(row["CountryName"]);
            }
                    
        }

        private void _FillFormWithData(clsPerson Person)
        {
            lblPersonID.Text = _PersonID.ToString();
            txtBoxNationalNo.Text = Person.NationalNo;
            txtBoxFirstName.Text = Person.FirstName;
            txtBoxSecondName.Text = Person.SecondName;
            txtBoxThirdName.Text = Person.ThirdName;
            txtBoxLastName.Text = Person.LastName;
            if (Person.Gender == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;
            txtBoxEmail.Text = Person.Email;
            txtBoxPhone.Text = Person.Phone;
            txtBoxAddress.Text = Person.Address;
            dtPDateOfBirth.Value = Person.DateOfBirth;
            cmbBoxCountries.SelectedIndex = Person.NationalityCountryID - 1;
            if (Person.ImagePath != "")
            {
                pBImageOfperson.ImageLocation = Person.ImagePath;

            }
            lklblRemoveImage.Visible = (Person.ImagePath != "");
        }
        private void _LoadData()
        {
            _Person = clsPerson.Find(_PersonID);
            // I have to check if the PersonID is already exist or not
            if (_Person == null)
            {
                MessageBox.Show("No person exists with ID =" + _PersonID + ", Please check and retry.", "PersonID Not Found", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                this.Close();
                return;
            }
            _FillFormWithData(_Person);


        }
        private void frmAddOrUpdate_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if(_Mode == enMode.Update)     //if(_PersonID!=-1)
            {
                _LoadData();
            }              
            
        }

        

        private void rdbtnMale_CheckedChanged(object sender, EventArgs e)
        {
            // pBImageOfperson.Image = Image.FromFile("C:\\Users\\AKILZA\\Desktop\\DVLD ICONS TEACHER\\Male 512.png");
            pBImageOfperson.Image = DVLD.Properties.Resources.Male_512;
        }
        private void rdbtnFemale_CheckedChanged(object sender, EventArgs e)
        {
            // pBImageOfperson.Image = Image.FromFile("C:\\Users\\AKILZA\\Desktop\\DVLD ICONS TEACHER\\Female 512.png");
            pBImageOfperson.Image = DVLD.Properties.Resources.Female_512;
        }

        private void ValidateEmptyTxtBox(object sender, CancelEventArgs e)
        {
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text))
            {
                e.Cancel = true;
                Temp.Focus();
                errorProvider1.SetError(Temp, (Temp.Text + " is mondatory, please enter this field."));
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(Temp, "");               
                return;
            }
        }

        private void txtBoxEmail_Validating(object sender, CancelEventArgs e)
        {
            // email allow null so to need to check it if it is empty
            if (txtBoxEmail.Text.Trim() == "")
                return;
            // validate email format
            if(!clsValidation.ValidateEmail(txtBoxEmail.Text.Trim()))
            {
                e.Cancel = true;
                txtBoxEmail.Focus();
                errorProvider1.SetError(txtBoxEmail,"this format is invalid, please check and retry");                
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtBoxEmail, "");               
            }
        }

        private void txtBoxPhone_Validating(object sender, CancelEventArgs e)
        {
            ValidateEmptyTxtBox(sender, e);
            // validate phone format
            if (!clsValidation.ValidateInteger(txtBoxPhone.Text.Trim()))
            {
                e.Cancel = true;
                txtBoxPhone.Focus();
                errorProvider1.SetError(txtBoxPhone, "please enter number in this field!!!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtBoxPhone, "");
            }
        }


        private void txtBoxNationalNo_Validating(object sender, CancelEventArgs e)
        {
            ValidateEmptyTxtBox(sender, e);

            if (clsPerson.IsPersonExist(txtBoxNationalNo.Text.Trim()) && (txtBoxNationalNo).Text.Trim() != _OrignalNationalNo)
            {
                e.Cancel = true;
                txtBoxNationalNo.Focus();
                errorProvider1.SetError(txtBoxNationalNo, "National Number is already exist with other person");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtBoxNationalNo, "");
            }
        }
        
        private void txtBoxNationalNo_TextChanged(object sender, EventArgs e)
        {
                  _OrignalNationalNo = txtBoxNationalNo.Text.Trim();
        }  
        
        private void txtBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the entered character is not a digit and not a control character (like Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancel the keypress event
                e.Handled = true;
            }
        }     

        private bool _HandlePersonImage()
        {
            if (pBImageOfperson.ImageLocation != _Person.ImagePath)
            {
                if (_Person.ImagePath != "")
                {
                    // first we delete the old image from the folder in case there is any

                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {
                        // we could not delete this file
                        // log it later
                    }

                }
                if (pBImageOfperson.ImageLocation != null)
                {
                    string sourceFile = pBImageOfperson.ImageLocation;
                    if (clsUtil.DeplaceImageToPersonImageFolder(ref sourceFile))
                    {
                        pBImageOfperson.ImageLocation = sourceFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error copying Image file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }


                }
            }
                return true;
                /*_Person.ImagePath = pBImageOfperson.ImageLocation;
                Guid guidoforPicName = Guid.NewGuid();
                string sourceFolderPath = openFileDialog1.FileName;
                string destinationFolderPath = @"C:\Users\AKILZA\Desktop\DVLD image Person"; // Path to the destination folder             

                try
                {


                    // Get the file name from the full path
                    string imageName = Path.GetFileName(sourceFolderPath);

                    // Combine the source image path with the destination folder path to get the destination image path
                    string destinationImagePath = Path.Combine(destinationFolderPath, guidoforPicName.ToString() + ".png");

                    // Copy the image file from the source folder to the destination folder
                    File.Copy(sourceFolderPath, destinationImagePath);

                    MessageBox.Show("Image copied successfully.");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
                _Person.ImagePath = "";*/
        }
       
        private void _FillDataFromForm()
        {
            _Person.NationalNo = txtBoxNationalNo.Text;
            _Person.FirstName = txtBoxFirstName.Text;
            _Person.SecondName = txtBoxSecondName.Text;
            _Person.LastName = txtBoxLastName.Text;
            if (rbFemale.Checked)
                _Person.Gender = 1;
            else
                _Person.Gender = 0;
            _Person.Phone = txtBoxPhone.Text;
            _Person.Address = txtBoxAddress.Text;
            _Person.DateOfBirth = dtPDateOfBirth.Value;
            _Person.NationalityCountryID = clsCountry.Find(cmbBoxCountries.Text).ID;
            if (txtBoxThirdName.Text != "")
            {
                _Person.ThirdName = txtBoxThirdName.Text;
            }
            else
                _Person.ThirdName = "";
            if (txtBoxEmail.Text != "")
            {
                _Person.Email = txtBoxEmail.Text;
            }
            else
                _Person.Email = "";
            if (pBImageOfperson.ImageLocation != null)
            {
                _Person.ImagePath = pBImageOfperson.ImageLocation;
            }
            else
                _Person.ImagePath = "";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!ValidateChildren())
            { 
                MessageBox.Show("Please enter all required fields with(*).","Missing Information",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!_HandlePersonImage())
                return;         
            
            if (MessageBox.Show("Are you sure you want to save Data ",
                "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                _FillDataFromForm(); // to fill _Person with Data
                if (_Person.Save())
                {
                    MessageBox.Show("Data Saved Successfully.");
                    DataBack ?.Invoke (this,_Person.PersonID);
                    lblPersonID.Text = _Person.PersonID.ToString();
                    lblAddOrUpdate.Text = "Update Person ";
                    _Mode = enMode.Update;

                }
                else
                    MessageBox.Show("Error: Data Is not Saved Successfully.");
                
            }
            else
                return;
           
            
        }
        private void NotifyDataChanged()
        {
            // If other forms are open, you can call a method on them to refresh data
            // Example: if you have MainForm and it has a method called RefreshData()
            if (Application.OpenForms["frmManagePeople"] != null)
            {
                ((frmManageListPeople)Application.OpenForms["frmManagePeople"]).RefreshPeopleList();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddOrUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            NotifyDataChanged();
        }

        private void lklblSetImage_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string sourceFolderPath = openFileDialog1.FileName;

                MessageBox.Show("Selected Image is:" + sourceFolderPath);

                pBImageOfperson.ImageLocation =sourceFolderPath;
                // ...

                lklblRemoveImage.Visible = true;

            }
        }

        private void lklblRemoveImage_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pBImageOfperson.Image = null;
            lklblRemoveImage.Visible = false;
            if (rbMale.Checked)
            {
                pBImageOfperson.Image = DVLD.Properties.Resources.Male_512;
            }
            else
                pBImageOfperson.Image = DVLD.Properties.Resources.Female_512;
        }
    }
}


