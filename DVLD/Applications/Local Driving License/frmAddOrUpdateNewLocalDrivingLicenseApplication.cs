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

namespace DVLD.Applications
{
    public partial class frmAddOrUpdateNewLocalDrivingLicenseApplication : Form
    {
        // public delegate void RefreshDataOfPreviousForm();
       // public event RefreshDataOfPreviousForm DataRefreshed;
       // clsApplications _Application;
        // clsApplicationTypes _ApplicationType = clsApplicationTypes.FindByDriverID(1); // because it is concerned new local driving license ID is 1

        public enum enMode { AddNew = 0, Update =1 };
        private enMode _Mode;
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _SelectedPersonID = -1;
        clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplication; 
        public frmAddOrUpdateNewLocalDrivingLicenseApplication()
        {
            InitializeComponent();
           // ucUserDetails11.btnshowed += UcUserDetails11_btnshowed;
            // ucUserDetails11.btnhided += UcUserDetails11_btnhided;
            _Mode = enMode.AddNew;
        }

        public frmAddOrUpdateNewLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _Mode = enMode.Update;
            // ucUserDetails11.btnshowed += UcUserDetails11_btnshowed;
            // ucUserDetails11.btnhided += UcUserDetails11_btnhided;
        }      

        private void _FillLicenseClassesInCombobox()
        {
            DataTable dt = clsLicenseClasses.GetAllLicenseClasses();
            foreach(DataRow row in dt.Rows)
            {
                cmbBoxLicenseClass.Items.Add(row["ClassName"]);   
            }

        }
        private void _ResetDefaultValues()
        {
            //this will fill the combobox with Licenses classes
            _FillLicenseClassesInCombobox();

            if(_Mode == enMode.AddNew)
            {
                lblTitle.Text = "New Local Driving License Application";
                this.Text = lblTitle.Text;
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplications();
                ucPersonCardWithFilter1.FilterFocus();
                tpApplicationInfo.Enabled = false;

                cmbBoxLicenseClass.SelectedIndex = 2;
                lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.NewDrivingLicense).ApplicationFees.ToString();
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblUserCreateedBy.Text = clsGlobal.CurrentUser.UserName;

            }
            else
            {
                lblTitle.Text = "Update Local Driving License Application";
                this.Text = lblTitle.Text;
                tpApplicationInfo.Enabled = true;
                btnSave.Enabled = true;
                btnNext.Enabled = true;
            }
        }
        private void _LoadData()
        {
            ucPersonCardWithFilter1.FilterEnabled = false;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID); 
            if(_LocalDrivingLicenseApplication == null )
            {
                MessageBox.Show("No person with ID = " + _LocalDrivingLicenseApplication.ApplicantPersonID + " exists!!",
                    "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ucPersonCardWithFilter1.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicantPersonID);
            cmbBoxLicenseClass.SelectedIndex = cmbBoxLicenseClass.FindString(_LocalDrivingLicenseApplication.LicenseClassInfo.ClassName);
            lblApplicationFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lblApplicationDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToShortDateString();
            lblUserCreateedBy.Text = _LocalDrivingLicenseApplication.CreatedByUserID.ToString();  
            lblID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
       
        }
        private void frmNewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if(_Mode == enMode.Update)
            {
                _LoadData();
            }
                        
        }

        /*
        private void _AddNewApplication()
        {
            _Application = new clsApplications();
            _Application.ApplicantPersonID = ucPersonCardWithFilter1.PersonID;
            _Application.ApplicationDate = DateTime.Now;
            _Application.LastStatusDate = DateTime.Now;
            _Application.ApplicationTypeID = _ApplicationType.ApplicationTypeID;
            _Application.PaidFees = _ApplicationType.ApplicationFees;
            _Application.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _Application.ApplicationStatus = clsApplications.enApplicationStatus.New;
            if (_Application.Save())
            {
                MessageBox.Show("information saved successufully!!", "information", MessageBoxButtons.OKCancel);
            }
            else
            {
                MessageBox.Show("save information failed!!!", "information", MessageBoxButtons.OKCancel);
                return;
            }
            lblID.Text = _Application.ApplicationID.ToString();
        }

        private void _AddeNewLocalLicenseDriving()
        {
            _AddNewApplication();
            _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplications();
            _LocalDrivingLicenseApplication.ApplicationID = _Application.ApplicationID;
            _LocalDrivingLicenseApplication.LicenseClassID = clsLicenseClasses.FindByDriverID(cmbBoxLicenseClass.SelectedItem.ToString()).LicenseClassID;
            if (_LocalDrivingLicenseApplication.Save())
            {
                MessageBox.Show("information saved successufully!!", "information", MessageBoxButtons.OKCancel);
                lblTitle.Text = "Update local license driving";
            }
            else
            {
                MessageBox.Show("save information failed!!!", "information", MessageBoxButtons.OKCancel);
                return;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnNext.Enabled == false)
            {
                MessageBox.Show("Please select a person to add!!!", "Warning", MessageBoxButtons.OKCancel);
                return;
            }
            DataTable dt = clsApplications.CheckIfPersonHasAlreadySignUp(ucPersonCardWithFilter1.PersonID);           
            foreach (DataRow row in dt.Rows )
            {
                if ((int)row["LicenseClassID"] == clsLicenseClasses.FindByDriverID(cmbBoxLicenseClass.SelectedItem.ToString()).LicenseClassID)
                {
                    if ((byte)row["ApplicationStatus"] ==1)
                    {
                        MessageBox.Show("Choose another license class, the selected person has already an active application" +
                            " for the selected class with id="+ (int)row["LicenseID"],"Warning",MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        return;
                    }
                    else if ((byte)row["ApplicationStatus"] ==3)
                    {
                        MessageBox.Show("this Person has already a license driving in this class, you can choose another license class", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        return ;
                    }
                    
                }
            }
            _AddeNewLocalLicenseDriving();         

        }
        */
        

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tbCntrNewLocalDriving.SelectedTab = tbCntrNewLocalDriving.TabPages["tpApplicationInfo"];
                return;
            }
            // incase of add new mode
            if(ucPersonCardWithFilter1.PersonID!=-1)
            {
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tbCntrNewLocalDriving.SelectedTab = tbCntrNewLocalDriving.TabPages["tpApplicationInfo"];
            }else
            {
                MessageBox.Show("Please Select a Person","Select a Person",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        /*
        private void UcUserDetails11_btnshowed()
        {
            btnNext.Enabled = true;
        }

        private void UcUserDetails11_btnhided()
        {
            btnNext.Enabled = false;
        }
        */

        private void btnSave_Click(object sender, EventArgs e)
        {
            int LicenseClassId = clsLicenseClasses.FindByClassName(cmbBoxLicenseClass.Text).LicenseClassID;
            int ActiveApplicationID = clsApplications.GetActiveApplicationIDForLicenseClass(_LocalDrivingLicenseApplication.ApplicantPersonID,
                clsApplications.enApplicationType.NewDrivingLicense, LicenseClassId);
            if(ActiveApplicationID != -1)
            {
                MessageBox.Show("the selected Person already has an active application for the selected class, please choose another license class",
                "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbBoxLicenseClass.Focus();
                return;
            }
            // check if the person has already issued license class
            /*  if(clsLicenses.IsLicenseExistForPersonID(ucPersonCardWithFilter1.PersonID, LicenseClassID))
              {
                  MessageBox.Show("the selected Person already has an license for the selected class, please choose another license class",
                  "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  cmbBoxLicenseClass.Focus();
                  return;
              }*/

            _LocalDrivingLicenseApplication.ApplicantPersonID = ucPersonCardWithFilter1.PersonID;
            _LocalDrivingLicenseApplication.ApplicationTypeID = 1;
            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplications.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassId;
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(lblApplicationFees.Text);
            _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            if(_LocalDrivingLicenseApplication.Save())
            {
                MessageBox.Show("Information added successfully to data","Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblID.Text=_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                _Mode = enMode.Update;
                lblTitle.Text = " Update Local Driving License Application";
                this.Text = lblTitle.Text;
                btnSave.Enabled = false;
                
            }
            else
            {
                MessageBox.Show("Information failed to add to data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);               
                return;
            }

        }

        private void ucPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;
        }

        private void frmAddOrUpdateNewLocalDrivingLicenseApplication_Activated(object sender, EventArgs e)
        {
            ucPersonCardWithFilter1.FilterFocus();
        }
    }
}
