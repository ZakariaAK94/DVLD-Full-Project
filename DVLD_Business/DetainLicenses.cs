using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Bussiness
{
    public class clsDetainLicenses
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;
        public int DetainID { set; get; }
        public int LicenseID { set; get; }
        public DateTime DetainDate { set; get; }
        public float FineFees { set; get; }
        public int CreatedByUserID { set; get; }
        public clsUser CreatedByUserInfo;
        public bool IsReleased { set; get; }
        public DateTime ReleaseDate { set; get; }
        public int ReleasedByUserID { set; get; }
        public clsUser ReleasedByUserInfo;
        public int ReleaseApplicationID { set; get; }  
        
        private clsDetainLicenses(int DetainID, int LicenseID, DateTime DetainDate, float FineFees, int CreatedByUserID, bool IsReleased,
            DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUserInfo = clsUser.FindByUserID(CreatedByUserID);
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleasedByUserInfo = clsUser.FindByUserID(ReleasedByUserID);
            this.ReleaseApplicationID = ReleaseApplicationID;        
            
            Mode = enMode.Update;
        }

        public clsDetainLicenses()
        {
            this.DetainID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.Now;
            this.FineFees = 0;
            this.CreatedByUserID = -1;
            this.IsReleased = false;
            this.ReleaseDate = DateTime.MaxValue;
            this.ReleasedByUserID = -1;
            this.ReleaseApplicationID = -1;

            Mode = enMode.AddNew;   
        }

        public static clsDetainLicenses FindDetainedLicenseInfoByLicenseID(int LicenseID)
        {

            int DetainID = -1, CreatedByUserID = -1;
            int ReleasedByUserID = -1, ReleaseApplicationID = -1;
            DateTime DetainDate = DateTime.Now;
            DateTime ReleaseDate = DateTime.MaxValue;
            float FineFees = 0;
            bool IsReleased = false;

            
            if (clsDetainLicensesDataAccess.GetDetainLicenseInfoByLicenseID(LicenseID, ref DetainID, ref DetainDate, ref FineFees, ref CreatedByUserID, ref IsReleased,
            ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID))

                return new clsDetainLicenses(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased,ReleaseDate,
                    ReleasedByUserID, ReleaseApplicationID);
            else
                return null;

        }

        public static clsDetainLicenses FindDetainedLicenseInfoByID(int DetainID)
        {

            int LicenseID = -1, CreatedByUserID = -1;
            int ReleasedByUserID = -1, ReleaseApplicationID = -1;
            DateTime DetainDate = DateTime.Now;
            DateTime ReleaseDate = DateTime.MaxValue;
            float FineFees = 0;
            bool IsReleased = false;


            if (clsDetainLicensesDataAccess.GetDetainLicenseInfoByID(DetainID, ref LicenseID, ref DetainDate, ref FineFees, ref CreatedByUserID, ref IsReleased,
            ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID))

                return new clsDetainLicenses(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate,
                    ReleasedByUserID, ReleaseApplicationID);
            else
                return null;

        }
        
        private bool _AddNewDetainLicense()
        {
            //call DataAccess Layer 

            this.DetainID = clsDetainLicensesDataAccess.AddNewDetainLicense(this.LicenseID, this.DetainDate, this.FineFees, 
                this.CreatedByUserID, this.IsReleased);

            return (this.DetainID != -1);
        }
        private bool _UpdateDetainLicense()
        {
            //call DataAccess Layer 

            return clsDetainLicensesDataAccess.UpdateDetainLicense(this.DetainID, this.LicenseID, this.DetainDate, this.FineFees,
                this.CreatedByUserID, this.IsReleased);

        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDetainLicense())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateDetainLicense();

            }
            return false;

        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            return clsDetainLicensesDataAccess.IsLicenseDetain(LicenseID);
        }

        public static DataTable GetAllDetainLicenses()
        {
            return clsDetainLicensesDataAccess.GetAllDetainedLicenses();

        }

        public bool ReleaseDetainedLicense(int ReleaseApplicationID, int ReleaseByUserID)
        {
            return clsDetainLicensesDataAccess.ReleaseDetainLicense(this.DetainID, ReleaseApplicationID, ReleaseByUserID);
        }




    }
}

