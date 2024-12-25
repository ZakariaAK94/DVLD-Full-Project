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

namespace DVLD.Applications
{
    public partial class frmListApplicationTypes : Form
    {
        private DataTable _dtAllApplicationTypes;
        public frmListApplicationTypes()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }          

        private void frmListApplicationTypes_Load(object sender, EventArgs e)
        {
            _dtAllApplicationTypes = clsApplicationTypes.GetAllApplicationTypes();
            dgvGetAllApplicationTypes.DataSource = _dtAllApplicationTypes;
            lblCountApplicationTypes.Text = dgvGetAllApplicationTypes.RowCount.ToString();
            dgvGetAllApplicationTypes.Columns["ApplicationTypeTitle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            frmEditApplicationTypes frm = new frmEditApplicationTypes((int)dgvGetAllApplicationTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListApplicationTypes_Load(null, null);
        }

    }
}
