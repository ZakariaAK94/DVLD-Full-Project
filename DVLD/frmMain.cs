using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DVLD_Bussiness;
using DVLD.Login;
using DVLD.Applications;
using DVLD.Licenses;
using DVLD.People;
using DVLD.Drivers;
using DVLD.User;
using DVLD.Tests;
using DVLD.Classes;

namespace ProjectDVLD
{
    public partial class frmMain : Form
    {
        
        private frmLogin _frmLogin1;       
        

        public frmMain(frmLogin frmLogin1)
        {
            InitializeComponent();            
            _frmLogin1 = frmLogin1;
        }     
        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageListPeople frm1 = new frmManageListPeople();   
            frm1.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        } 
        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLogin1.Show(); // Show PreviousForm
           // _frmLogin1.refreshUserInfo();
            this.Close(); // Close CurrentForm          
        }

        private void UsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers frm = new frmManageUsers();
            frm.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
                       
            frmUserInfo frm = new frmUserInfo(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangeUserPassword frm = new frmChangeUserPassword(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        
        private void tsmManageApplicationTypes_Click(object sender, EventArgs e)
        {
            frmListApplicationTypes frm = new frmListApplicationTypes();    
            frm.ShowDialog();
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTestTypes frm = new frmListTestTypes();
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddOrUpdateNewLocalDrivingLicenseApplication frm = new frmAddOrUpdateNewLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }        

        private void tsmLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicenseApplications frm  = new frmListLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDrivers frm = new frmListDrivers();
            frm.ShowDialog();
        }

        private void tsmInternationalLicense_Click(object sender, EventArgs e)
        {
            frmInternationalDrivingLicenseApplications frm = new frmInternationalDrivingLicenseApplications();
            frm.ShowDialog();
        }

        private void renewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLicenseApplication frm = new frmRenewLicenseApplication();
            frm.ShowDialog();
        }

        private void replacementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmReplacementForLostOrDamagedLicense frm = new frmReplacementForLostOrDamagedLicense();
            //frm.Show();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDetainedLicenses frm =new frmListDetainedLicenses();
            frm.Show();
        }

        private void detainLicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApplication frm = new frmDetainLicenseApplication();
            frm.Show();
        }

        private void releaseDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();
            frm.Show();
        }

        private void internatialLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication frm = new frmNewInternationalLicenseApplication();
            frm.Show();

        }

        private void releaseDetainedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();
            frm.Show();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicenseApplications frm = new frmListLocalDrivingLicenseApplications();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
