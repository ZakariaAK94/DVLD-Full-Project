using System;
using System.Collections.Generic;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Bussiness
{
    public class clsDrivers
    {

        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;

        public int DriverID { set; get; }
        public int PersonID { set; get; }

        public clsPerson PersonInfo;
        public int CreatedByUserID { set; get; }
        public DateTime CreatedDate { set; get; }

        public clsDrivers()
        {
            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;            
            this.CreatedDate = DateTime.Now;          
            Mode = enMode.AddNew;

        }

        private clsDrivers(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.Find(this.PersonID);
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
            Mode = enMode.Update;
        }

        private bool _AddNewDriver()
        {
            //call DataAccess Layer 

            this.DriverID = clsDriverDataAccess.AddNewDriver(this.PersonID, this.CreatedByUserID, this.CreatedDate);

            return (this.DriverID != -1);
        }

        private bool _UpdatePerson()
        {
            //call DataAccess Layer             

            return (clsDriverDataAccess.UpdateDriver(this.DriverID,this.PersonID, this.CreatedByUserID, this.CreatedDate)); 
        }

        public static clsDrivers FindByDriverID(int DriverID)
        {
            DateTime CreatedDate = DateTime.Now;
            int PersonID = -1;
            int CreatedByUserID = -1;

            if (clsDriverDataAccess.GetDriverInfoByDriverID(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))

                return new clsDrivers(DriverID, PersonID, CreatedByUserID,CreatedDate);
            else
                return null;
        }

        public static clsDrivers FindByPersonID(int PersonID)
        {
            DateTime CreatedDate = DateTime.Now;
            int DriverID = -1;
            int CreatedByUserID = -1;

            if (clsDriverDataAccess.GetDriverInfoByDriverID(PersonID, ref DriverID, ref CreatedByUserID, ref CreatedDate))

                return new clsDrivers(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;
        }
        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDriver())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePerson();

            }

            return false;
        }

        public static DataTable GetAllDrivers()
        {
            return clsDriverDataAccess.GetAllDrivers();

        }

        /*
        public static DataTable GetLicenses(int DriverID)
        {
            return clsLicenses.GetDriverLicenses(DriverID); 
        }

        public static DataTable GetInternationalLicenses(int DriverID)
        {
            return clsLicenses.GetDriverInternationalLicenses(DriverID);
        }*/

        //public static bool isDriverExist(int ID)
        //{
        //    return clsDriverDataAccess.IsDriverExist(ID);
        //}

    }
}