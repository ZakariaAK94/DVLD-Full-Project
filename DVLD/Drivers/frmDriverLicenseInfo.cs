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

namespace DVLD.Drivers
{
    public partial class frmDriverLicenseInfo : Form
    {
       
        public frmDriverLicenseInfo(stDLApplication stDLApplication, clsLicenses License)
        {
            InitializeComponent();
            //ucDriverLicenseControl1.SetValueToStruct(stDLApplication);
            //ucDriverLicenseControl1.License = License;  
            //ucDriverLicenseControl1.Person = clsPerson.Find(stDLApplication._ApplicantPersonID);
            //ucDriverLicenseControl1.ucDriverLicenseControlLoad();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDriverLicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
