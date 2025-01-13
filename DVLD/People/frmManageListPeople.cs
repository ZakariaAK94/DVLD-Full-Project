using DVLD_Bussiness;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Configuration;

namespace DVLD.People
{
    public partial class frmManageListPeople : Form
    {
        private DataTable _dtAllPeople ;
        public frmManageListPeople()
        {
            InitializeComponent();            
        }
        
        private void _RefreshPeopleList()
        {
            _dtAllPeople = clsPerson.GetAllPeople();
            dgvGetAllPeople.DataSource = _dtAllPeople;
            lblNbrOfRecords.Text = dgvGetAllPeople.Rows.Count.ToString();            
        }

        private void frmManageListPeople_Load(object sender, EventArgs e)
        {
            _dtAllPeople = clsPerson.GetAllPeople();
            dgvGetAllPeople.DataSource = _dtAllPeople;
            cmbBox1.SelectedIndex = 0;
            if(dgvGetAllPeople.Rows.Count > 0)
            {
                dgvGetAllPeople.Columns[0].HeaderText = "Person ID";
                dgvGetAllPeople.Columns[1].HeaderText = "National No";
                dgvGetAllPeople.Columns[2].HeaderText = "First Name";
                dgvGetAllPeople.Columns[3].HeaderText = "Second Name";
                dgvGetAllPeople.Columns[4].HeaderText = "Third Name";
                dgvGetAllPeople.Columns[5].HeaderText = "Last Name";
                dgvGetAllPeople.Columns[6].HeaderText = "Date Of Birth";
                dgvGetAllPeople.Columns[7].HeaderText = "Gendor";
                dgvGetAllPeople.Columns[8].HeaderText = "Address";
                dgvGetAllPeople.Columns[9].HeaderText = "Phone";
                dgvGetAllPeople.Columns[10].HeaderText = "Email";
            }
                        
        }

        private void txtBoxFilterBy_TextChanged(object sender, EventArgs e)
        {
            _FilterBy();
            if (string.IsNullOrEmpty(txtBoxFilterBy.Text))
            {
                _RefreshPeopleList();
                return;
            }
        }

        public void RefreshPeopleList()
        {
            _RefreshPeopleList();
        }

        private string _ColumnName = "";
        
        private void _FilterBy()
        {
            switch(cmbBox1.Text)
            {
                case "Person ID":
                    _ColumnName = "PersonID";                    
                    break;
                case "National No":
                    _ColumnName = "NationalNo";
                    break;
                case "First Name":
                    _ColumnName = "FirstName";
                    break;
                case "Second Name":
                    _ColumnName = "Second Name";
                    break;
                case "Third Name":
                    _ColumnName = "ThirdName";
                    break;
                case "Last Name":
                    _ColumnName = "LastName";
                    break;                
                default:
                    _ColumnName = cmbBox1.Text;
                    
                    break;
            }
            txtBoxFilterBy.Visible = (cmbBox1.Text != "None");
            //Reset the filters in case nothing selected or filter value contains nothing.
            if (txtBoxFilterBy.Text.Trim() == "" || _ColumnName == "None")
            {
                _dtAllPeople.DefaultView.RowFilter = "";
                lblNbrOfRecords.Text = dgvGetAllPeople.Rows.Count.ToString();                
                return;
            }

            if (_ColumnName == "PersonID")
                //in this case we deal with integer not string. filerColumn is the column name               
                _dtAllPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", _ColumnName, txtBoxFilterBy.Text.Trim());
            else
                _dtAllPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", _ColumnName, txtBoxFilterBy.Text.Trim());
            // {0} is a placeholder for the column name, in this case will be FilterColumn.
            // [ ] brackets are used to denote the column name in the filter expression, necessary when the column name contains spaces or special characters.
            // {1} is a placeholder for the filter value in this case it will be txtFilterValue.
            // txtFilterValue.Text.Trim() provides the value to filter by, with Trim() removing any leading or trailing whitespace.

            lblNbrOfRecords.Text = dgvGetAllPeople.Rows.Count.ToString();
            
        }

        /* My solution 
        private void _FilterDataGridView(string columnName, string filterValue)
        {
            string filterExpression = "";
            // Check the data type of the column
            if (_dtAllPeople.Columns[columnName].DataType == typeof(string))
            {
                filterExpression = $"{columnName} LIKE '%{filterValue}%'";
            }
            else
            {
                filterExpression = $"{columnName} = {filterValue}";
            }
            DataRow[] filteredRows = _dtAllPeople.Select(filterExpression);

            DataTable filteredTable = _dtAllPeople.Clone();
            foreach (DataRow row in filteredRows)
            {
                filteredTable.ImportRow(row);
            }

            dgvGetAllPeople.DataSource = filteredTable;
        }
        */

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddOrUpdate frm = new frmAddOrUpdate();
            frm.ShowDialog();
            frmManageListPeople_Load(null,null);
        }

        private void tsmDeletePerson_Click(object sender, EventArgs e)
        {
           
            if (MessageBox.Show("Are you sure you want to delete Person [" + dgvGetAllPeople.CurrentRow.Cells[0].Value + "]",
                "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //Perform Delele and refresh
                if (clsPerson.DeletePerson((int)dgvGetAllPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.");
                    frmManageListPeople_Load(null, null);
                }

                else
                    MessageBox.Show("Person is not deleted.");

            }
        }

        private void tsmEditPerson_Click(object sender, EventArgs e)
        {
            frmAddOrUpdate frm = new frmAddOrUpdate((int)dgvGetAllPeople.CurrentRow.Cells[0].Value);            
            frm.ShowDialog();
            frmManageListPeople_Load(null, null);
        }

        private void tsmAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddOrUpdate frm = new frmAddOrUpdate();
            frm.ShowDialog();
            frmManageListPeople_Load(null, null);
        }

        private void tsmShowDetails_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo((int)dgvGetAllPeople.CurrentRow.Cells[0].Value);  
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBoxFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the entered character is not a digit and not a control character (like Backspace)
            if (cmbBox1.Text == "Person ID" || cmbBox1.Text == "Phone")
            {
                // Cancel the keypress event
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void cmbBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterBy();
        }

    }
}
