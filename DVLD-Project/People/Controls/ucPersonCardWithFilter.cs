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
using DVLD.People;

namespace DVLD.Controls
{
    public partial class ucPersonCardWithFilter : UserControl
    {
        //Define a custom event handler delegate with parameters
        public event Action<int> OnPersonSelected;
        // Define a function type protected to raise the event with a parameter 

        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> Handler = OnPersonSelected;
            if (Handler != null)
            {
                Handler(PersonID); // raise the event with parameter
            }
        }

        private int _PersonID = -1;
        public int PersonID
        {
            get
            {
                return ucPersonCard1.PersonID;
            }
        }

        private bool _ShowAddPerson = true;

        public bool ShowAddPerson
        {
            get
            { return _ShowAddPerson; }
            set
            {
                _ShowAddPerson = value;
                btnAddNewPerson.Enabled = _ShowAddPerson;
            }
        }

        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set
            {
                _FilterEnabled = value;
                gBFilter.Enabled = _FilterEnabled;
            }
        }

        public clsPerson SelectedPersonInfo
        {
            get
            {
                return ucPersonCard1.SelectedPeronInfo;
            }
        }

        public ucPersonCardWithFilter()
        {
            InitializeComponent();
        }


        public void LoadPersonInfo(int PersonID)
        {
            cmbBoxFindBy.SelectedIndex = 1;
            txtBoxFindByValue.Text = PersonID.ToString();
            FindNow();
        }

        public void FilterFocus()
        {
            txtBoxFindByValue.Focus();
        }

        private void FindNow()
        {
            switch (cmbBoxFindBy.Text)
            {
                case "Person ID":
                    ucPersonCard1.LoadPersonInfo(int.Parse(txtBoxFindByValue.Text));
                    break;
                case "National No":
                    ucPersonCard1.LoadPersonInfo(txtBoxFindByValue.Text);
                    break;
                default:
                    break;
            }

            if (OnPersonSelected != null && FilterEnabled)
            {
                // Raise the event with a parameter
                OnPersonSelected(ucPersonCard1.PersonID);
            }
        }

        private void cmbBoxFindBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtBoxFindBy.Visible = true; why?
            txtBoxFindByValue.Text = "";
            txtBoxFindByValue.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fields are required!!,put the mouse on the red icon(s) to find out the error", "Validation Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FindNow();
        }

        private void ucPersonCardWithFilter1_Load(object sender, EventArgs e)
        {
            cmbBoxFindBy.SelectedIndex = 0;
            txtBoxFindByValue.Focus();
        }
        private void txtBoxFindBy_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxFindByValue.Text))
            {
                e.Cancel = true;
                txtBoxFindByValue.Focus();
                errorProvider1.SetError(txtBoxFindByValue, " This is mondatory, please enter this field.");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtBoxFindByValue, "");
                return;
            }
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddOrUpdate frm = new frmAddOrUpdate(int.Parse(txtBoxFindByValue.Text));
            //frm.DataBack += DataBackEvent;
            frm.ShowDialog();
        }

        private void DataBackEvent(object sender, int PersonID)
        {
            // Handle the data recieved
            cmbBoxFindBy.SelectedIndex = 1;
            txtBoxFindByValue.Text = PersonID.ToString();
            ucPersonCard1.LoadPersonInfo(PersonID);
        }
        private void TxtBoxFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSearch.PerformClick();
            }

            if (txtBoxFindByValue.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        //public delegate void EventHandlerShowBtn();
        //public event EventHandlerShowBtn btnshowed;
        //public event EventHandlerShowBtn btnhided;

        //public void SearchByPersonID(int PersonID)
        // {
        //      if (clsPerson.isPersonExist(PersonID))
        //      {
        //          ucPersonCard1.LoadPersonInfo(PersonID);
        //          //btnshowed?.Invoke();
        //          return;
        //      }
        //      else
        //          MessageBox.Show("No Person exist with PersonID = " + PersonID.ToString(), "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
        // }

        //public void HideOption(bool IsEnable, int PersonID)
        //{
        //       cmbBoxFindBy.SelectedIndex = 1;
        //       txtBoxFindBy.Text = PersonID.ToString();
        //       gBFilter.Enabled = IsEnable;

        //}
        //private void SearchByNationalNo(string NationalNo)
        //{
        //     if (clsPerson.IsPersonExist(NationalNo))
        //     {
        //         ucPersonCard1.LoadPersonInfo(clsPerson.FindByUserID(NationalNo));
        //         btnshowed ?.Invoke();
        //         return;
        //     }
        //     else
        //         MessageBox.Show("No Person exist with NationalNo = " + NationalNo, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}


        //public void DisableSearchForOtherPerson()
        //{
        //     cmbBoxFindBy.SelectedIndex = 1;
        //     int PersonID = clsUser.FindByUserID(_UserID).PersonID;
        //     txtBoxFindBy.Text = PersonID.ToString();
        //     ucPersonCard1.LoadPersonInfo(PersonID);
        //     gBFilter.Enabled = false;
        //}     

        //private void txtBoxFindBy_MouseLeave(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(txtBoxFindBy.Text))
        //    {
        //        ucPersonCard1.ResetPersonInfo();
        //    }
        //}    

        //private void Frm_DataBack(int PersonID)
        //{
        //    ucPersonCard1.LoadPersonInfo(PersonID);
        //}





        //private void txtBoxFindBy_TextChanged(object sender, EventArgs e)
        //{
        //   // if (string.IsNullOrEmpty(txtBoxFindBy.Text))
        //        //btnhided?.Invoke();
        //}


    }
}


