using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using DVLD_Bussiness;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Licenses
{
    public partial class frmShowInternationalLicesInfo : Form
    {
        private int _InternationalLicenseID;
        public frmShowInternationalLicesInfo(int InternationalLicenseID)
        {
            InitializeComponent();
            _InternationalLicenseID = InternationalLicenseID;
         
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowInternationalLicesInfo_Load(object sender, EventArgs e)
        {
            ucDriverInternationalLicenseInfo1.LoadInfo(_InternationalLicenseID);
        }
    }
}
