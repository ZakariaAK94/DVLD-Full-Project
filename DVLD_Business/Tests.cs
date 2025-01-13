using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Bussiness
{
    public class clsTests
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;
        public int TestID { set; get; }
        public int TestAppointmentID { set; get; }
        public clsTestAppointments TestAppointmentInfo { set; get; }    
        public bool TestResult { set; get; }
        public string Notes { set; get; }
       public int CreatedByUserID { set; get; }     
     

        private clsTests(int TestID, int TestAppointmentID, bool TestResult,string Notes, int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestAppointmentInfo = clsTestAppointments.Find(TestAppointmentID);
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;               
            this.Mode = enMode.Update;  
        }

        public clsTests()
        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = "";
            this.CreatedByUserID = -1;
            this.Mode = enMode.AddNew;
        }

        public static clsTests FindByTestID(int TestID)
        {

            int TestAppointmentID = -1;            
            bool TestResult = false;
            string Notes = "";
            int CreatedByUserID = -1;         


            if (clsTestsData.GetTestByTestID(TestID, ref TestAppointmentID, ref TestResult, ref Notes, 
                ref CreatedByUserID))

                return new clsTests(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            else
                return null;

        }        

        private bool _AddNewTest()
        {
            //call DataAccess Layer 

            this.TestID = clsTestsData.AddNewTest(this.TestAppointmentID, this.TestResult, this.Notes,
                this.CreatedByUserID);

            return (this.TestID != -1);
        }

        private bool _UpdateTest()
        {
            //call DataAccess Layer 

            return clsTestsData.UpdateTest(this.TestID, this.TestAppointmentID, this.TestResult, this.Notes, 
                this.CreatedByUserID);

        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTest())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateTest();

            }

            return false;

        }

        public static DataTable GetAllTests()
        {
            return clsTestsData.GetAllTests();

        }

        public static byte GetPassedtestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTestsData.GetPassedtestCount(LocalDrivingLicenseApplicationID);
        }

        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            return clsTestsData.GetPassedtestCount(LocalDrivingLicenseApplicationID) == 3;
        }

        public static clsTests FindlastTestByPersonIDAndTestTypeIDAndClassLicenseID(int PersonID,
            clsTestTypes.enTestType TestTypeID, int ClassLicenseID)
        {

            int TestID = -1;
            int TestAppointmentID = -1;
            bool TestResult = false;
            string Notes = "";
            int CreatedByUserID = -1;


            if (clsTestsData.GetLastTestByPersonAndTestTypeAndLicenseClass(PersonID,(int)TestTypeID, ClassLicenseID,
                ref TestID,ref TestAppointmentID, ref TestResult, ref Notes,ref CreatedByUserID))

                return new clsTests(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            else
                return null;

        }
    }
}




