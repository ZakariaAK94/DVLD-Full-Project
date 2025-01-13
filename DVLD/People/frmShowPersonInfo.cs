﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmShowPersonInfo : Form
    {
        private int _PersonID;
        
        public frmShowPersonInfo(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            

        }

        public frmShowPersonInfo(string NationaNo)
        {
            InitializeComponent();
            ucPersonCard1.LoadPersonInfo(NationaNo);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowPersonInfo_Load(object sender, EventArgs e)
        {
            ucPersonCard1.LoadPersonInfo(_PersonID);
        }
    }
}
