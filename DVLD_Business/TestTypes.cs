using DVLD_DataAccess;
using System.Data;
using System.Threading.Tasks;

namespace DVLD_Bussiness
{
    public class clsTestTypes
    {
        public enum enMode { AddNew =0, Update = 1 };
        private enMode _Mode =enMode.AddNew;
        public enum enTestType { VisionTest =1, WrittenTest = 2,StreetTest=3};
        public clsTestTypes.enTestType TestTypeID { set; get; }

        public string TestTypeTitle { set; get; }
        public string TestTypeDescription { set; get; }
        public float TestTypeFees { set; get; }

        private clsTestTypes()
        {
            this.TestTypeID = enTestType.VisionTest;
            this.TestTypeTitle = "";
            this.TestTypeDescription = "";
            this.TestTypeFees = 0;
            this._Mode = enMode.AddNew;
        }
        private clsTestTypes(clsTestTypes.enTestType TestTypeID, string TestTypeTitle, string TestTypeDescription, float TestTypeFees)
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;
            this._Mode= enMode.Update;
        }

        public static clsTestTypes Find(clsTestTypes.enTestType TestTypeID)
        {

            string TestTypeTitle = "";
            string TestTypeDescription = "";
            float TestTypeFees = 0;

            if (clsTestTypesData.GetTestTypesInfoByID((int)TestTypeID, ref TestTypeTitle, ref TestTypeDescription,ref TestTypeFees))

                return new clsTestTypes(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);
            else
                return null;

        }

        private bool _AddNewTestTypes()
        {
            //call DataAccess Layer 
            this.TestTypeID = (clsTestTypes.enTestType)clsTestTypesData.AddNewTestType(this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);

            return ((int)this.TestTypeID != 0);
        }
        private bool _UpdateTestTypes()
        {
            //call DataAccess Layer 

            return clsTestTypesData.UpdateTestTypes((int)this.TestTypeID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);

        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestTypes())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateTestTypes();

            }
            return false;

        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypesData.GetAllTestTypes();

        }




    }
}








