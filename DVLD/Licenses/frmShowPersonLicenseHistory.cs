using DVLD_Bussiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Drivers;
using DVLD.Controls;

namespace DVLD.Licenses
{
    public partial class frmShowPersonLicenseHistory : Form
    {
        //private enum enForOneLicenseOrAll { All = 1, OneLicense = 2 };
        //private enForOneLicenseOrAll _enForOneLicenseOrAll;
        //private stDLApplication _stDLApplication5;
        //private clsLicenses _License;

        private int _PersonID = -1;
        public frmShowPersonLicenseHistory(int PersonID) //(stDLApplication Mystruct, int AllOrOne)
        {
            InitializeComponent();
            _PersonID = PersonID;
            //_stDLApplication5 = Mystruct;
            //_enForOneLicenseOrAll = (enForOneLicenseOrAll)AllOrOne;
        }

        public frmShowPersonLicenseHistory() 
        {
            InitializeComponent();
           
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucUserDetails11_OnPersonSelected(int obj)
        {
            _PersonID = obj;
            if(_PersonID == -1)
            {
                ucDriverLicenses1.Clear();
            }else
            {
                ucDriverLicenses1.LoadInfoBypersonID(_PersonID);
            }
        }

        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {
            if(_PersonID != -1)
            {
                ucPersonCardWithFilter1.LoadPersonInfo(_PersonID);
                ucPersonCardWithFilter1.FilterEnabled = false;
                ucDriverLicenses1.LoadInfoBypersonID(_PersonID) ;
            }else
            {
                ucPersonCardWithFilter1.FilterFocus();
                ucPersonCardWithFilter1.FilterEnabled = true;
            }
        }



        // fct to check ho< to change value in datagridview but should the same type of data
        //    private void ModifyCellContentInDataGridView(int rowIndex, int columnIndex, object newValue)
        //    {
        //        if (dgvLocalLicensesHistory != null && rowIndex >= 0 && rowIndex < dgvLocalLicensesHistory.Rows.Count)
        //        {
        //            dgvLocalLicensesHistory.Rows[rowIndex].Cells[columnIndex].Value = newValue;
        //        }
        //    }
        //    private void frmLicenseHistory_Load(object sender, EventArgs e)
        //    {
        //        //ucUserDetails11.SearchByPersonID(_stDLApplication5._ApplicantPersonID);
        //        //ucUserDetails11.HideOption(false, _stDLApplication5._ApplicantPersonID);
        //        if(_enForOneLicenseOrAll == enForOneLicenseOrAll.All)
        //        {
        //            //dgvLocalLicensesHistory.DataSource = clsLicenses.GetAllLicensesOfAnApplicant(_stDLApplication5._ApplicantPersonID);
        //            dgvInternationalLicenseHistory.DataSource = clsInternationalLicenses.GetAllInternationalLicensesOfAnApplicant(_stDLApplication5._ApplicantPersonID);

        //            dgvLocalLicensesHistory.Columns["LicenseID"].HeaderText = "Lic ID";
        //            dgvLocalLicensesHistory.Columns["ApplicationID"].HeaderText = "App ID";
        //            dgvLocalLicensesHistory.Columns["ClassName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        //            dgvLocalLicensesHistory.Columns["DriverID"].Visible = false;

        //            dgvInternationalLicenseHistory.Columns["InternationalLicenseID"].HeaderText = "Int.License ID";
        //            dgvInternationalLicenseHistory.Columns["IssuedUsingLocalLicenseID"].HeaderText = "L.LicenseID";

        //        }
        //        else
        //        {
        //           // dgvLocalLicensesHistory.DataSource = clsLicenses.GetlLicensesOfAnApplicantForTheSameLicenseClass(_stDLApplication5._ApplicantPersonID, _stDLApplication5._ClassName);
        //            dgvLocalLicensesHistory.Columns["LicenseID"].HeaderText = "Lic ID";
        //            dgvLocalLicensesHistory.Columns["ApplicationID"].HeaderText = "App ID";
        //            dgvLocalLicensesHistory.Columns["ClassName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        //        }

        //        lblNbrOfRecords.Text = dgvLocalLicensesHistory.RowCount.ToString();

        //    }

        //    private void tbControlLocal_SelectedIndexChanged(object sender, EventArgs e)
        //    {
        //        if(tbControlLocal.SelectedIndex == 0) 
        //        {
        //            lblNbrOfRecords.Text = dgvLocalLicensesHistory.RowCount.ToString();
        //        }
        //        else
        //        {
        //            lblNbrOfRecords.Text = dgvInternationalLicenseHistory.RowCount.ToString();
        //        }

        //    }

        //    private void tsmShowLicenseInfo_Click(object sender, EventArgs e)
        //    {
        //        _License = clsLicenses.FindLicenseInfoByLicenseID((int)dgvLocalLicensesHistory.CurrentRow.Cells[0].Value);
        //        frmDriverLicenseInfo frm = new frmDriverLicenseInfo(_stDLApplication5, _License);
        //        frm.Show();
        //    }
        //}
    }
}
