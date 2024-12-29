using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Bussiness
{
    public class clsInternationalLicenses:clsApplications
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;
        public int InternationalLicenseID { set; get; }
        public int DriverID { set; get; }
        public clsDrivers DriverInfo;
        public int IssuedUsingLocalLicenseID { set; get; }
        public DateTime IssueDate { set; get; }
        public DateTime ExpirationDate { set; get; }      
        public bool IsActive { set; get; }


        public clsInternationalLicenses()
        {
            this.InternationalLicenseID = -1;
            this.ApplicationTypeID = (int)clsApplications.enApplicationType.NewInternationalLicense;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            
            this.IsActive = true;

            Mode = enMode.AddNew;
        }

        private clsInternationalLicenses(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, enApplicationStatus ApplicationStatus, 
            DateTime LastStatusDate, float PaidFees, int CreatedByUserID,

            int InternationalLicenseID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate,
            DateTime ExpirationDate, bool IsActive)                   
        {
            // this is for the base class
            base.ApplicationID = ApplicationID;
            base.ApplicantPersonID = ApplicantPersonID;
            base.ApplicantPersonInfo = clsPerson.Find(this.ApplicantPersonID);
            base.ApplicationDate = ApplicationDate;
            base.ApplicationTypeID = (int)clsApplications.enApplicationType.NewInternationalLicense;
            base.ApplicationStatus = ApplicationStatus;
            base.LastStatusDate = LastStatusDate;
            base.PaidFees = PaidFees;
            base.CreatedByUserID = CreatedByUserID;

            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.CreatedByUserID = CreatedByUserID;
            this.IsActive = IsActive;

            this.DriverInfo = clsDrivers.FindByDriverID(this.DriverID);

            Mode = enMode.Update;

        }        

        public static clsInternationalLicenses FindInternationalLicenseInfoByInterLicenseID(int InternationalLicenseID)
        {

            int IssuedUsingLocalLicenseID = -1, DriverID = -1, ApplicationID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            bool IsActive = true;



            if (clsInternationalLicensesDataAccess.GetInternationalLicenseInfoByInterLicenseID(InternationalLicenseID, ref IssuedUsingLocalLicenseID,
                ref ApplicationID, ref DriverID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {
                clsApplications Application = clsApplications.FindBaseApplication(ApplicationID);
                return new clsInternationalLicenses(Application.ApplicationID, Application.ApplicantPersonID, Application.ApplicationDate, Application.ApplicationStatus,
                    Application.LastStatusDate, Application.PaidFees,Application.CreatedByUserID,

                    InternationalLicenseID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate,IsActive);
            }
                
            else
                return null;

        }

        private bool _AddNewInternationalLicense()
        {
            //call DataAccess Layer 

            this.InternationalLicenseID = clsInternationalLicensesDataAccess.AddNewInternationalLicense(this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID, this.IssueDate,
            this.ExpirationDate, this.IsActive, this.CreatedByUserID);

            return (this.InternationalLicenseID != -1);
        }
        private bool _UpdateInternationalLicense()
        {
            //call DataAccess Layer 

            return clsInternationalLicensesDataAccess.UpdateInternationalLicense(this.InternationalLicenseID, this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID, this.IssueDate,
            this.ExpirationDate,this.IsActive, this.CreatedByUserID);

        }


        public bool Save()
        {
            // because of inheritance we have to check that base class save successfully so we handled the base application
            base.Mode = (clsApplications.enMode)Mode;
            if(!base.Save()) 
                return false; 
            
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewInternationalLicense())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateInternationalLicense();

            }
            return false;

        }

        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            return clsInternationalLicensesDataAccess.GetDriverInternationalLicenses(DriverID);

        }

        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {
            return clsInternationalLicensesDataAccess.GetActiveInternationalLicenseIDByDriverID(DriverID);

        }

        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicensesDataAccess.GetAllInternationalLicenses();

        }

        //public static bool CheckIfLocalLicenseAlreadyAttributeToInternationLicense(int LicenseID)
        //{
        //    return clsInternationalLicensesDataAccess.CheckIfLocalLicenseAlreadyAttributeToInternationLicense(LicenseID);
        //}

        //public static DataTable FilterData(string ColumnName, string SearchQuery)
        //{
        //    return clsInternationalLicensesDataAccess.FilterData(ColumnName, SearchQuery);
        //}

        //public static clsInternationalLicenses FindLicenseInfoByApplicatinID(int ApplicationID)
        //{

        //    int InternationalLicenseID = -1, DriverID = -1, LicenseClassID = -1, CreatedByUserID = -1;
        //    DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
        //    decimal PaidFees = 0;
        //    bool IsActive = false;
        //    string Notes = "";
        //    byte IssueReason = 0;


        //    if (clsInternationalLicensesDataAccess.GetLicenseInfoByApplicationID(ApplicationID, ref InternationalLicenseID, ref DriverID, ref LicenseClassID, ref IssueDate,
        //    ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))

        //        return new clsInternationalLicenses(InternationalLicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees,
        //            IsActive, IssueReason, CreatedByUserID);
        //    else
        //        return null;

        //}

        //public static clsInternationalLicenses FindInternationalLicenseInfoByLicenseID(int IssuedUsingLocalLicenseID)
        //{

        //    int InternationalLicenseID = -1, DriverID = -1, ApplicationID = -1, CreatedByUserID = -1;
        //    DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
        //    bool IsActive = false;



        //    if (clsInternationalLicensesDataAccess.GetInternationalLicenseInfoByLicenseID(IssuedUsingLocalLicenseID, ref InternationalLicenseID,
        //        ref ApplicationID, ref DriverID, ref IssueDate,ref ExpirationDate, ref IsActive,ref CreatedByUserID))

        //        return new clsInternationalLicenses(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, 
        //            IsActive, CreatedByUserID);
        //    else
        //        return null;

        //}

    }
}

