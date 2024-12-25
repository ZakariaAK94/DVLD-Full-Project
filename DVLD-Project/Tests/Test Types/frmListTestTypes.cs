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

namespace DVLD.Tests
{
    public partial class frmListTestTypes : Form
    {
        private DataTable _dtListTestTypes;
        public frmListTestTypes()
        {
            InitializeComponent();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListTestTypes_Load(object sender, EventArgs e)
        {
            _dtListTestTypes = clsTestTypes.GetAllTestTypes();
            dgvGetAllTestTypes.DataSource = _dtListTestTypes;
            lblCountTestTypes.Text = dgvGetAllTestTypes.Rows.Count.ToString();
            if(dgvGetAllTestTypes.Rows.Count>0)
            {
                dgvGetAllTestTypes.Columns["TestTypeID"].HeaderText = "Test Type ID";
                dgvGetAllTestTypes.Columns["TestTypeID"].Width = 100;
                dgvGetAllTestTypes.Columns["TestTypeTitle"].HeaderText = "Test Type Title";
                dgvGetAllTestTypes.Columns["TestTypeTitle"].Width = 180;
                dgvGetAllTestTypes.Columns["TestTypeDescription"].HeaderText = "Test Type Description";
                dgvGetAllTestTypes.Columns["TestTypeDescription"].Width = 480;
                dgvGetAllTestTypes.Columns["TestTypeFees"].HeaderText = "Test Type Fees";
                dgvGetAllTestTypes.Columns["TestTypeFees"].Width = 100;
            }
            
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            frmUpdateTestType frm = new frmUpdateTestType((clsTestTypes.enTestType)dgvGetAllTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListTestTypes_Load(null, null);
        }
    }
}

