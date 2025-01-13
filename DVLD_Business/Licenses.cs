using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Bussiness
{
    public class clsLicenses
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public enum enIssueReason { FirsTime = 1, Renew = 2, DamagedReplacement =3, LostReplacement};
        
        public int LicenseID { set; get; }
        public int ApplicationID { set; get; }
        public int DriverID { set; get; }
        public clsDrivers DriverInfo;
        public int LicenseClassID { set; get; }
        public clsLicenseClasses LicenseClassInfo;
        public DateTime IssueDate { set; get; }
        public DateTime ExpirationDate { set; get; }
        public string Notes { set; get; }
        public float PaidFees { set; get; }
        public bool IsActive { set; get; }
        public enIssueReason IssueReason { set; get; }

        public string IssueReasonText
        {
            get
            {
                return GetIssueReasonText(this.IssueReason);    
            }
        }
        public int CreatedByUserID { set; get; }

        public clsDetainLicenses DetainedInfo { get; set; }

        public bool IsDetained
        {
            get
            {
              return false ; //clsDetainLicenses.IsLicenseDetain();
            }
        }



        private clsLicenses(int LicenseID, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate,
            DateTime ExpirationDate, string Notes, float PaidFees, bool IsActive, enIssueReason IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;            
            this.LicenseClassID = LicenseClass;            
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.IssueReason = IssueReason;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsActive = IsActive;

            this.DriverInfo = clsDrivers.FindByDriverID(DriverID);
            this.LicenseClassInfo = clsLicenseClasses.FindByLicenseClassID(LicenseClass);
            this.DetainedInfo = clsDetainLicenses.FindDetainedLicenseInfoByLicenseID(LicenseID);

            Mode = enMode.Update;

        }

        public clsLicenses()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClassID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.IssueReason = enIssueReason.FirsTime;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.IsActive = true;

            Mode = enMode.AddNew;
        }

        private string GetIssueReasonText(enIssueReason IsueReason)
        {
            switch(IsueReason)
            {
                case enIssueReason.FirsTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.DamagedReplacement:
                    return "Replacement fro Damaged";
                case enIssueReason.LostReplacement:
                    return "Replacement for Lost";
                default:
                    return "First Time";
            }
        }
        /*public static clsLicenses FindLicenseInfoByApplicationID(int ApplicationID)
        {

            int LicenseID = -1, DriverID = -1, LicenseClass = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            decimal PaidFees = 0;
            bool IsActive = false;
            string Notes = "";
            byte IssueReason = 0;


            if (clsLicensesDataAccess.GetLicenseInfoByApplicationID(ApplicationID, ref LicenseID, ref DriverID, ref LicenseClass, ref IssueDate,
            ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))

                return new clsLicenses(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees,
                    IsActive, IssueReason, CreatedByUserID);
            else
                return null;

        } */

        public static clsLicenses FindLicenseInfoByLicenseID(int LicenseID)
        {

            int ApplicationID = -1, DriverID = -1, LicenseClass = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            float PaidFees = 0;
            bool IsActive = true;
            string Notes = "";
            byte IssueReason = 1;


            if (clsLicensesDataAccess.GetLicenseInfoByLicenseID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass, ref IssueDate,
            ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))

                return new clsLicenses(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees,
                    IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            else
                return null;

        }

        private bool _AddNewLicense()
        {
            //call DataAccess Layer 

            this.LicenseID = clsLicensesDataAccess.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClassID, this.IssueDate,
            this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);

            return (this.LicenseID != -1);
        }
        private bool _UpdateLicense()
        {
            //call DataAccess Layer 

            return clsLicensesDataAccess.UpdateLicense(this.LicenseID, this.ApplicationID, this.DriverID, this.LicenseClassID, this.IssueDate,
            this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);

        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLicense();

            }
            return false;

        }

        //public static DataTable GetAllLicensesOfAnApplicant(int PersonID)
        //{
        //    return clsLicensesDataAccess.GetAllLicensesOfAnApplicant(PersonID);

        //}

        //public static DataTable GetlLicensesOfAnApplicantForTheSameLicenseClass(int PersonID, string ClassName)
        //{
        //    return clsLicensesDataAccess.GetLicensesOfAnApplicantWithTheSameClassName(PersonID, ClassName);

        //}

        //public static bool CheckIfLicenseIDExist(int LicenseID)
        //{
        //    return clsLicensesDataAccess.CheckIfLicenseIDExist(LicenseID);
        //}

        public DataTable GetAllLicenses()
        {
            return clsLicensesDataAccess.GetAllLicenses();
        }

        public static bool IsLicenseExistByPersonIDAndLicenseClassID(int PersonID, int LicenseClassID)
        {
            return GetActiveLicenseIDByPersonID(PersonID, LicenseClassID) != -1;   
        }

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            return clsLicensesDataAccess.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);
        }

        public static DataTable GetDriverLicenses(int DriverID)
        {
            return clsLicensesDataAccess.GetDriverLicenses(DriverID);
        }

        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            return clsLicensesDataAccess.GetDriverInternationalLicenses(DriverID);
        }

        public Boolean IsLicenseExpired()
        {
            return this.ExpirationDate < DateTime.Now;
        }

        public bool DesactiveCurrentLicense()
        {
            return clsLicensesDataAccess.DesactiveLicense(this.LicenseID);
        }

        public int Detain(float FineFees, int CreatedByUserID)
        {
            clsDetainLicenses detainLicense = new clsDetainLicenses();
            detainLicense.LicenseID = this.LicenseID;
            detainLicense.DetainDate = DateTime.Now;
            detainLicense.FineFees = FineFees;
            detainLicense.CreatedByUserID = this.CreatedByUserID;

            if (detainLicense.Save())
            {
                return detainLicense.DetainID;
            }
            else
                return -1;

        }

        public bool ReleaseDetainedLicense(int ReleaseByUserID, ref int ApplicationID)
        {
            // create a new application type ReleaseDetainedLicense
            clsApplications ReleaseApplication = new clsApplications();

            ReleaseApplication.ApplicantPersonID = this.DriverInfo.PersonID;
            ReleaseApplication.ApplicationDate = DateTime.Now;
            ReleaseApplication.LastStatusDate = DateTime.Now;
            ReleaseApplication.ApplicationTypeID = (int)clsApplications.enApplicationType.ReleaseDetainedDrivingLicsense;
            ReleaseApplication.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
            ReleaseApplication.PaidFees = clsApplicationTypes.Find((int)clsApplications.enApplicationType.ReleaseDetainedDrivingLicsense).ApplicationFees;
            ReleaseApplication.CreatedByUserID = ReleaseByUserID;

            if (!ReleaseApplication.Save())
            {
                ApplicationID = -1;
                return false;
            }
            ApplicationID = ReleaseApplication.ApplicationID;

            return false; // this.DetainedInfo.ReleaseDetainedLicense(ReleaseByUserID, ReleaseApplication.ApplicationID);

        }

        public clsLicenses RenewLicense(string Notes, int CreatedByUserID)
        {
            // create a new application type renew

            clsApplications RenewApplication = new clsApplications();
            RenewApplication.ApplicantPersonID=this.DriverInfo.PersonID;
            RenewApplication.ApplicationDate = DateTime.Now;
            RenewApplication.LastStatusDate = DateTime.Now;
            RenewApplication.ApplicationTypeID = (int) clsApplications.enApplicationType.RenewDrivingLicense;
            RenewApplication.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
            RenewApplication.PaidFees = clsApplicationTypes.Find((int)clsApplications.enApplicationType.RenewDrivingLicense).ApplicationFees;
            RenewApplication.CreatedByUserID = CreatedByUserID;

            if(!RenewApplication.Save())
            {
                return null;
            }

            clsLicenses NewLicense = new clsLicenses();
            NewLicense.ApplicationID = RenewApplication.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = this.PaidFees;
            NewLicense.IsActive = this.IsActive;
            NewLicense.IssueReason = enIssueReason.Renew;
            NewLicense.CreatedByUserID = CreatedByUserID;

            if(!NewLicense.Save()) 
            { 
                return null;
            }

            DesactiveCurrentLicense();

            return NewLicense;

        }


        public clsLicenses ReplaceLicense(enIssueReason IssueReason, int CreatedByUserID)
        {
            // create a new application type for Damage or replacement

            clsApplications ApplicationForDamagedOrLost = new clsApplications();
            ApplicationForDamagedOrLost.ApplicantPersonID = this.DriverInfo.PersonID;
            ApplicationForDamagedOrLost.ApplicationDate = DateTime.Now;
            ApplicationForDamagedOrLost.LastStatusDate = DateTime.Now;
            ApplicationForDamagedOrLost.ApplicationTypeID = (IssueReason == enIssueReason.DamagedReplacement) ?
                (int)clsApplications.enApplicationType.ReplaceDamagedDrivingLicense : (int)clsApplications.enApplicationType.ReplaceLostDrivingLicense;          
            ApplicationForDamagedOrLost.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
            ApplicationForDamagedOrLost.PaidFees = clsApplicationTypes.Find((int)IssueReason).ApplicationFees;
            ApplicationForDamagedOrLost.CreatedByUserID = CreatedByUserID;

            if (!ApplicationForDamagedOrLost.Save())
            {
                return null;
            }

            clsLicenses NewLicense = new clsLicenses();
            NewLicense.ApplicationID = ApplicationForDamagedOrLost.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddDays(this.LicenseClassInfo.DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = 0;
            NewLicense.IsActive = this.IsActive;
            NewLicense.IssueReason = IssueReason;
           
            NewLicense.CreatedByUserID = CreatedByUserID;

            if (!NewLicense.Save())
            {
                return null;
            }
            // desactivate old license
            DesactiveCurrentLicense();

            return NewLicense;

        }







    }
}

