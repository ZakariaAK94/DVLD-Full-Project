using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Bussiness
{
    public class clsTestAppointments
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;
        public int TestAppointmentID { set; get; }
        public clsTestTypes.enTestType TestTypeID { set; get; }
        public int LocalDrivingLicenseApplicationID { set; get; }
        public int CreatedByUserID { set; get; }
        public bool IsLocked { set; get; }
        public DateTime AppointmentDate { set; get; }
        public float PaidFees { set; get; }

        public int TestID
        {
            get
            {
                return _GetTestID();
            }
        }

        public int RetakeTestAppID { set; get; }

        public clsApplications RetakeTestapplication { set; get; }

        private clsTestAppointments(int TestAppointmentID, clsTestTypes.enTestType TestTypeID, int LocalDrivingLicenseApplicationID, int CreatedByUserID,
            bool IsLocked, DateTime AppointmentDate, float PaidFees, int RetakeTestApplID)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.RetakeTestAppID = RetakeTestApplID;
            this.RetakeTestapplication = clsApplications.FindBaseApplication(this.RetakeTestAppID);
            Mode = enMode.Update;
        }

        public clsTestAppointments()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = clsTestTypes.enTestType.VisionTest;
            this.LocalDrivingLicenseApplicationID = -1;
            this.CreatedByUserID = -1;
            this.IsLocked = false;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;

            Mode = enMode.AddNew;

        }

        public static clsTestAppointments Find(int TestAppointmentID)
        {

          int  TestTypeID = -1;
          int  RetakeTestApplID = -1;
          int  LocalDrivingLicenseApplicationID = -1;
          int  CreatedByUserID = -1;
          bool  IsLocked = false;
          DateTime AppointmentDate = DateTime.Now ;
          float  PaidFees = 0;


            if (clsTestAppointmentsData.GetTestAppointementsInfoByID(TestAppointmentID, ref TestTypeID, 
              ref LocalDrivingLicenseApplicationID, ref CreatedByUserID, ref IsLocked, ref AppointmentDate,ref PaidFees,ref RetakeTestApplID))

                return new clsTestAppointments(TestAppointmentID, (clsTestTypes.enTestType)TestTypeID, 
               LocalDrivingLicenseApplicationID, CreatedByUserID, IsLocked, AppointmentDate,PaidFees, RetakeTestApplID);
            else
                return null;

        }

        private bool _AddNewTestAppointment()
        {
            //call DataAccess Layer 
            
            this.TestAppointmentID = clsTestAppointmentsData.AddNewtestAppointment((int)this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.CreatedByUserID, 
                this.IsLocked, this.AppointmentDate, this.PaidFees,this.RetakeTestAppID);
             
            return (this.TestAppointmentID != -1);
        }
        private bool _UpdateTestAppointement()
        {
            //call DataAccess Layer 

            return clsTestAppointmentsData.UpdateTestAppointement(this.TestAppointmentID, (int)this.TestTypeID, 
          this.LocalDrivingLicenseApplicationID, this.CreatedByUserID, this.IsLocked, this.AppointmentDate, this.PaidFees,this.RetakeTestAppID);

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestAppointment())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateTestAppointement();

            }

            return false;

        }

        public static DataTable GetAllTestAppointements()
        {
            return clsTestAppointmentsData.GetAllTestAppointements();

        }


        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID,
            clsTestTypes.enTestType TestTypeID)
        {
            return clsTestAppointmentsData.GetApplicationTestAppointmentsPerTestType(LocalDrivingLicenseApplicationID,(int)TestTypeID);
        }

        public DataTable GetApplicationTestAppointmentsPerTestType(clsTestTypes.enTestType TestTypeID)
        {
            return clsTestAppointmentsData.GetApplicationTestAppointmentsPerTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static clsTestAppointments GetLastTestAppointment(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)
        {
            int TestAppointmentID = -1;
            DateTime AppointmentDate = DateTime.Now;
            float PaidFees = 0;
            int CreatedByUserID = -1;
            bool IsLocked = false;
            int RetakeTestApplicationID = -1;

            if (clsTestAppointmentsData.GetLastTestAppointment(LocalDrivingLicenseApplicationID,(int)TestTypeID, ref TestAppointmentID,
                      ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))
                return new clsTestAppointments(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID,
                         CreatedByUserID, IsLocked, AppointmentDate, PaidFees,RetakeTestApplicationID);
            else
                return null;
        }

        private int _GetTestID()
        {
            return clsTestAppointmentsData.GetTestID(TestAppointmentID);
        }
    }
}

