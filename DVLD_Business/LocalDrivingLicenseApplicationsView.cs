using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;
using DVLD_Bussiness;

namespace DVLD_Bussiness
{
    public class clsLocalDrivingLicenseApplicationsView
    {
       

        public static DataTable GetViewOfAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationsViewData.GetViewOfAllLocalDrivingLicenseApplications();

        }

        public static DataTable FilterData(string ColumnName, string SearchQuery)
        {
            return clsLocalDrivingLicenseApplicationsViewData.FilterData(ColumnName, SearchQuery);
        }


    }
}




