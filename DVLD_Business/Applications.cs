using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Bussiness
{
    public class clsApplications
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public enum enApplicationType {NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7};
        public enum enApplicationStatus { New=1,Cancelled=2,Completed =3};

        
        public int ApplicationID { set; get; }
        public int ApplicantPersonID { set; get; }
        public clsPerson ApplicantPersonInfo;
        public string ApplicantFullName
        {
            get
            {
                return clsPerson.Find(ApplicantPersonID).FullName;
            }
        }
        public DateTime ApplicationDate { set; get; }
        public int ApplicationTypeID { set; get; }
        public clsApplicationTypes ApplicationTypeInfo;

        public string StatusText
        {
            get
            {
                switch(ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "unknow";
                }
            }
        }
        public enApplicationStatus ApplicationStatus { set; get; }
        public DateTime LastStatusDate { set; get; }
        public float PaidFees { set; get; }
        public int CreatedByUserID { set; get; }
        public clsUser CreatedByUserInfo;
        

        private clsApplications(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
            enApplicationStatus ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicantPersonInfo = clsPerson.Find(this.ApplicantPersonID);           
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeInfo = clsApplicationTypes.Find(ApplicationTypeID);
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUserInfo = clsUser.FindByUserID(CreatedByUserID);
            Mode = enMode.Update;

        }

        public clsApplications()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now ;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            Mode = enMode.AddNew;
        }

        private bool _AddNewApplication()
        {
            //call DataAccess Layer 

            this.ApplicationID = clsApplicationsData.AddNewApplication(this.ApplicantPersonID, this.ApplicationDate, 
                this.ApplicationTypeID,(byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

            return (this.ApplicationID != -1);
        }

        private bool _UpdateApplication()
        {
            //call DataAccess Layer 

            return clsApplicationsData.UpdateApplication(this.ApplicationID, this.ApplicantPersonID, this.ApplicationDate, 
                this.ApplicationTypeID, (byte)this.ApplicationStatus,this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

        }

        public static clsApplications FindBaseApplication(int ApplicationID)
        {

            int ApplicantPersonID = -1, ApplicationTypeID = -1, CreatedByUserID = -1;
            DateTime ApplicationDate = DateTime.Now, LastStatusDate = DateTime.Now;
            float PaidFees = 0;
            byte ApplicationStatus = (byte)enApplicationStatus.New; 

            if (clsApplicationsData.GetApplicationInfoByID(ApplicationID, ref ApplicantPersonID, ref ApplicationDate, ref ApplicationTypeID,
                ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))

                return new clsApplications(ApplicationID, ApplicantPersonID,  ApplicationDate,  ApplicationTypeID, (enApplicationStatus)ApplicationStatus,
             LastStatusDate,PaidFees,CreatedByUserID);
            else
                return null;
        }        
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateApplication();

            }
            return false;

        }

       
        public bool Delete()
        {
            return clsApplicationsData.DeleteApplication(this.ApplicationID);
        }
        public bool Cancel()
        {
            return clsApplicationsData.UpdateStatus(ApplicationID, (byte)enApplicationStatus.Cancelled);
        }

        public bool SetComplete()
        {
            return clsApplicationsData.UpdateStatus(ApplicationID, (byte)enApplicationStatus.Completed);
        }

        public static bool IsApplicationExist(int ApplicationID)
        {
            return clsApplicationsData.IsApplicationExists(ApplicationID);
        }

        public static bool DoesPersonHaveActiveApplication(int PersonID,int ApplicationTypeID)
        {
            return clsApplicationsData.DoesPersonHaveAnActiveApplication(PersonID, ApplicationTypeID);
        }
        public bool DoesPersonHaveActiveApplication(int ApplicationTypeID)
        {
            return clsApplicationsData.DoesPersonHaveAnActiveApplication(this.ApplicantPersonID, ApplicationTypeID);
        }

        public static int GetActiveApplicationID(int PersonID,clsApplications.enApplicationType ApplicationTypeID)
        {
            return clsApplicationsData.GetActiveApplicationID(PersonID,(int)ApplicationTypeID);
        }

        public int GetActiveApplicationID(clsApplications.enApplicationType ApplicationTypeID)
        {
            return clsApplicationsData.GetActiveApplicationID(this.ApplicantPersonID, (int)ApplicationTypeID);
        }
        public static int GetActiveApplicationIDForLicenseClass(int PersonID, clsApplications.enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return clsApplicationsData.GetActiveApplicationIDForLicenseClass(PersonID,(int)ApplicationTypeID, LicenseClassID);
        }
        public static DataTable GetAllApplications()
        {
            return clsApplicationsData.GetAllApplications();
        }

        public static DataTable CheckIfPersonHasAlreadySignUp(int PersonID)
        {
            return clsApplicationsData.CheckIfPersonHasAlreadySignUp(PersonID);
        }


    }
}

