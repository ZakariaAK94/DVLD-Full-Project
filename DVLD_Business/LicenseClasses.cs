using DVLD_DataAccess;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Threading.Tasks;

namespace DVLD_Bussiness
{
    public class clsLicenseClasses
    {
        private enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;
        public int LicenseClassID { set; get; }      
        public string ClassName { set; get; }
        public byte MinimumAllowedAge { set; get; }
        public byte DefaultValidityLength { set; get; }

        public string ClassDescription { set; get; }
        public float ClassFees { set; get; }

        private clsLicenseClasses()
        {
            this.LicenseClassID = -1;
            this.ClassName = "";
            this.MinimumAllowedAge = 18;
            this.DefaultValidityLength = 5;
            this.ClassDescription = "";
            this.ClassFees = 0;

            this._Mode = enMode.AddNew;

        }
        private clsLicenseClasses(int LicenseClassID, string ClassName,byte MinimumAllowedAge, byte DefaultValidityLength, string ClassDescription  , float ClassFees)
        {
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassDescription = ClassDescription;
            this.ClassFees = ClassFees;

            this._Mode = enMode.Update;
        }

        public static clsLicenseClasses FindByLicenseClassID(int LicenseClassID)
        {

            string ClassName = "";
            byte MinimumAllowedAge = 18;
            byte DefaultValidityLength = 5;
            string ClassDescription = "";
            float ClassFees = 0;
            if (clsLicenseClassesData.GetLicenseClassInfoByID(LicenseClassID, ref ClassName,ref MinimumAllowedAge,ref DefaultValidityLength, ref ClassDescription, ref ClassFees))
            {
                return new clsLicenseClasses(LicenseClassID, ClassName, MinimumAllowedAge, DefaultValidityLength, ClassDescription, ClassFees);
            
            }else
            {
                return null;
            }              
                

        }

        public static clsLicenseClasses FindByClassName(string ClassName )
        {

            int LicenseClassID = -1;
            byte MinimumAllowedAge = 18;
            byte DefaultValidityLength = 5;
            string ClassDescription = "";
            float ClassFees = 0;
            if (clsLicenseClassesData.GetLicenseClassInfoByClassName(ClassName,ref LicenseClassID, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassDescription, ref ClassFees))

                return new clsLicenseClasses(LicenseClassID, ClassName, MinimumAllowedAge, DefaultValidityLength, ClassDescription, ClassFees);
            else
                return null;

        }

        private bool _AddNewLicenseClass()
        {
            //call DataAccess Layer 
            this.LicenseClassID = clsLicenseClassesData.AddNewLicenseClasses(this.ClassName, this.MinimumAllowedAge, this.DefaultValidityLength,
                this.ClassDescription, this.ClassFees);
            return (this.LicenseClassID != -1);

        }
        private bool _UpdateLicenseClass()
        {
            //call DataAccess Layer 

            return clsLicenseClassesData.UpdateLicenseClasses(this.LicenseClassID, this.ClassName,this.MinimumAllowedAge, this.DefaultValidityLength,
                this.ClassDescription, this.ClassFees);

        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                {
                    if (_AddNewLicenseClass())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }else
                        return false;
                }
                case enMode.Update:
                {
                    return _UpdateLicenseClass();                
                }
            }        
            return false;

        }

        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassesData.GetAllLicenseClasses();
        }




    }
}









