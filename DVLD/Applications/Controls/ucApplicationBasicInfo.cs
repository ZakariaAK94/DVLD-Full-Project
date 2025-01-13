using DVLD.Classes;
using DVLD.People;
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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.Applications.Controls
{
    public partial class ucApplicationBasicInfo : UserControl
    {
        clsApplications _Application;
        private int _ApplicationID;

        public int ApplicationID
        {
            get
            {
                return _ApplicationID;
            }
        }
        public ucApplicationBasicInfo()
        {
            InitializeComponent();
        }

        private void _FillApplicationInfo()
        {
            lblApplicantID.Text = _Application.ApplicationID.ToString();
            lblStatus.Text = _Application.StatusText;
            lblType.Text = _Application.ApplicationTypeInfo.ApplicationTypeTitle;
            lblFees.Text = _Application.PaidFees.ToString();
            lblApplicant.Text = _Application.ApplicantFullName;
            lblDate.Text = _Application.ApplicationDate.ToShortDateString();
            lblStatusDate.Text = _Application.LastStatusDate.ToShortDateString();
            lblUserCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }

        public void ResetDefaultValues()
        {
            _ApplicationID = -1;
            string str = "[???]";
            lblApplicantID.Text = str;
            lblStatus.Text = str;
            lblType.Text = str;
            lblFees.Text = str;
            lblApplicant.Text = str;
            lblDate.Text = str;
            lblStatusDate.Text = str;
            lblUserCreatedBy.Text = str;
        }
        public void LoadApplicationInfo(int applicationID)
        {
           
        _ApplicationID = applicationID;
        _Application = clsApplications.FindBaseApplication(applicationID);
            if (_Application != null)
            {
                _FillApplicationInfo();
            }
            else
            {
                ResetDefaultValues();
                MessageBox.Show("No Application exist with ApplicationID " + _ApplicationID, "Application not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void lklViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo personDetails = new frmShowPersonInfo(_Application.ApplicantPersonID);
            personDetails.ShowDialog();
            //Refresh
            LoadApplicationInfo(_ApplicationID);
        }
    }
}
