using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Bussiness;
using DVLD.Properties;

namespace DVLD.Controls
{
    public partial class ucUserCard : UserControl
    {
        private clsUser _User;
        private int _UserId=-1;// we have to initialize this value for all the time
        public int UserID
        {
            get
            {
                return _UserId;
            }
        }

        //public int UserID
        //{
        //    set
        //    {
        //        _UserId=value;
        //    }
        //}


        public ucUserCard()
        {
            InitializeComponent();
        }

        private void _ResetDefaultValues()
        {
            string value = "????";
            lblIsActive.Text = value;
            lblUserID.Text = value;
            lblUserName.Text = value;
        }
        public void LoadUserInfo(int UserID)
        {
            _User = clsUser.FindByUserID(UserID);
            if( _User == null )
            {
                _ResetDefaultValues();
                MessageBox.Show("No user exist with ID = "+_User.UserID,"No User Found",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            // fill user Info 
            // first ucControl PersonInfo
            ucPersonCard3.LoadPersonInfo(_User.PersonID);
            // second ucControl userInfo
            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName.ToString();
            if (_User.isActive)
                lblIsActive.Text = "Yes";
            else
                lblIsActive.Text = "No";
        }


    }
}

