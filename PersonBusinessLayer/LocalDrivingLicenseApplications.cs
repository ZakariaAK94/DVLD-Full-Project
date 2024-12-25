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
    public class clsLocalDrivingLicenseApplications : clsApplications
    {
        public enum enMode{ AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;

        public int LocalDrivingLicenseApplicationID { set; get; }        
        public int LicenseClassID { set; get; }
        public clsLicenseClasses LicenseClassInfo;

        public string PersonFullName
        {
            get
            {
                return base.ApplicantPersonInfo.FullName;
            }
        }
        public clsLocalDrivingLicenseApplications()
        {
            this.LocalDrivingLicenseApplicationID = -1;            
            this.LicenseClassID = -1;
            Mode = enMode.AddNew;

        }
        private clsLocalDrivingLicenseApplications(int LocalDrivingLicenseApplicationID,int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
            enApplicationStatus ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID, int LicenseClassID)
        {
            // initialize properties of the subClass
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.LicenseClassID = LicenseClassID;
            this.LicenseClassInfo = clsLicenseClasses.FindByLicenseClassID(LicenseClassID);
            Mode = enMode.Update; // hides the mode of the superclass.
            // initialize proporties of the superClass
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;        
        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            //call DataAccess Layer 

            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationsData.AddNewLocalDrivingLicenseApplication
                (this.ApplicationID, this.LicenseClassID);

            return (this.LocalDrivingLicenseApplicationID != -1);
        }
        private bool _UpdateLocalDrivingLicenseApplication()
        {
            //call DataAccess Layer 

            bool Result = clsLocalDrivingLicenseApplicationsData.UpdateLocalDrivingLicenseApplication
                (this.LocalDrivingLicenseApplicationID,this.ApplicationID,this.LicenseClassID);

            return (Result);
        }
        public static clsLocalDrivingLicenseApplications FindByLocalDrivingAppLicenseID(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = -1, LicenseClassID = -1;
            bool IsFound = clsLocalDrivingLicenseApplicationsData.GetLocalDrivingLicenseApplicationByID(LocalDrivingLicenseApplicationID, 
                ref ApplicationID, ref LicenseClassID);            
            
          if (IsFound)
          {
                clsApplications Application = clsApplications.FindBaseApplication(ApplicationID);
                return new clsLocalDrivingLicenseApplications(LocalDrivingLicenseApplicationID,ApplicationID, 
                 Application.ApplicantPersonID, Application.ApplicationDate, Application.ApplicationTypeID,
                 (enApplicationStatus)Application.ApplicationStatus, Application.LastStatusDate,
                Application.PaidFees, Application.CreatedByUserID, LicenseClassID);
           }
            else
            {
                return null;
            }
                
        }

        public static clsLocalDrivingLicenseApplications FindByApplicationID(int ApplicationID)
        {
            int LocalDrivingLicenseApplicationID = -1, LicenseClassID = -1;
            bool IsFound = clsLocalDrivingLicenseApplicationsData.GetLocalDrivingLicenseApplicationByApplicationID(ApplicationID,
                ref LocalDrivingLicenseApplicationID, ref LicenseClassID);

            if (IsFound)
            {
                clsApplications Application = clsApplications.FindBaseApplication(ApplicationID);
                return new clsLocalDrivingLicenseApplications(LocalDrivingLicenseApplicationID, ApplicationID, Application.ApplicantPersonID,
                Application.ApplicationDate, Application.ApplicationTypeID, (enApplicationStatus)Application.ApplicationStatus, Application.LastStatusDate,
                Application.PaidFees, Application.CreatedByUserID, LicenseClassID);
            }
            else
                return null;
        }




        public bool Save()
        {
            //because of inheriance we have to start with save() in the base classe and ensure that all data implement into the application table
            base.Mode = (clsApplications.enMode)Mode;
            if(!base.Save())
            {
                return false;
            }
            // then we save the information for the subclass
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLocalDrivingLicenseApplication())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                 return _UpdateLocalDrivingLicenseApplication();

            }

            return false;
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationsData.GetAllLocalDrivingLicenseApplications();
        }

        public bool Delete()
        {
            // because of inheritance we have to handle to points, delete current data 'Subclass' then delete data from baseclass
            bool IsLocalDrivingLicenseDeleted = false;
            bool IsBaseClassDataDeleted = false;
            IsLocalDrivingLicenseDeleted = clsLocalDrivingLicenseApplicationsData.DeleteLocalDrivingLicenseApplications(this.LocalDrivingLicenseApplicationID);
            if (!IsLocalDrivingLicenseDeleted)
                return false;
            IsBaseClassDataDeleted = base.Delete();
            return IsBaseClassDataDeleted;                
        }

        public bool DoesPassTestType(clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationsData.DoesPassTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool DoesPassPreviousTest(clsTestTypes.enTestType CurrentTestType)
        {
            switch(CurrentTestType)
            {
                case clsTestTypes.enTestType.VisionTest:
                    // in this case no required previous test to pass
                    return true;
                case clsTestTypes.enTestType.WrittenTest:
                    // we have to check if the vision test is passed
                    return this.DoesPassTestType(clsTestTypes.enTestType.VisionTest);
                case clsTestTypes.enTestType.StreetTest:
                    // we have to check if the written test is passed
                    return this.DoesPassTestType(clsTestTypes.enTestType.WrittenTest);
                default:
                    return false;

            }
        }

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationsData.DoesPassTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public bool DoesAttendTestType(clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationsData.DoesAttendTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool AttendedTest(clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationsData.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID,(int)TestTypeID) > 0;
        }

        public static bool AttendedTest(int LocalDrivingLicenseApplicationID,clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationsData.TotalTrialsPerTest(LocalDrivingLicenseApplicationID, (int)TestTypeID) > 0;
        }

        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationsData.TotalTrialsPerTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public byte TotalTrialsPerTest(clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationsData.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }



        public bool IsThereAnActiveScheduleTest(clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationsData.IsThereAnActiveScheduleTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static bool IsThereAnActiveScheduleTest(int LocalDrivingLicenseApplicationID,clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationsData.IsThereAnActiveScheduleTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool PassedAllTests()
        {
            return clsTests.PassedAllTests(this.LocalDrivingLicenseApplicationID);
        }
        public int GetActiveLicenseID()
        {
            return clsLicenses.GetActiveLicenseIDByPersonID(this.ApplicantPersonID,this.LicenseClassID);
        }

        public int IssueLicenseForFirstTime(string Notes, int CreatedByUserID)
        {
            int DriverID = -1;
            // we check if the driver already exist for this person
            clsDrivers Driver = clsDrivers.FindByPersonID(this.ApplicantPersonID);
            if(Driver == null)
            {
                Driver = new clsDrivers();
                Driver.PersonID = this.ApplicantPersonID;
                Driver.CreatedByUserID = CreatedByUserID;
                Driver.CreatedDate = DateTime.Now;
                if(!Driver.Save())
                {
                    DriverID = -1;
                    return DriverID;
                }
                else
                    DriverID = Driver.DriverID;
            }else
                DriverID = Driver.DriverID;
            // we create a new license
            clsLicenses NewLicense = new clsLicenses();

            NewLicense.ApplicationID = this.ApplicationID;
            NewLicense.DriverID = DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = this.LicenseClassInfo.ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = clsLicenses.enIssueReason.FirsTime;
            NewLicense.CreatedByUserID =CreatedByUserID;
            if (!NewLicense.Save())
            {
                return -1;
            }
            else
            {
                this.SetComplete();
                return NewLicense.LicenseID;
            }                       

        } 

        public bool IsLicenseIssued()
        {
            return GetActiveLicenseID() != -1;
        }
    }
}




