using DVLD_DataAccess;
using System.Data;
using System.Threading.Tasks;

namespace DVLD_Bussiness
{
    public class clsApplicationTypes
    {
        public enum enMode { AddNew=0,Update=1};
        private enMode _Mode = enMode.AddNew;
        public int ApplicationTypeID { set; get; }

        public string ApplicationTypeTitle { set; get; }
        public float ApplicationFees { set; get; }

        private clsApplicationTypes()
        {
            this.ApplicationTypeID = -1;
            this.ApplicationTypeTitle = "";
            this.ApplicationFees = 0;
            this._Mode = enMode.AddNew;
        }
        private clsApplicationTypes(int ApplicationTypeID, string ApplicationTypeTitle, float ApplicationFees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationFees = ApplicationFees;
            this._Mode = enMode.Update;
        }

        private bool _AddNewApplicationType()
        {

            this.ApplicationTypeID = clsApplicationTypesData.AddNewApplicationType(this.ApplicationTypeTitle, this.ApplicationFees);

            return (this.ApplicationTypeID != -1);

        }
        private bool _UpdateApplication()
        {
            //call DataAccess Layer 
            return clsApplicationTypesData.UpdateApplicationFees(this.ApplicationTypeID, this.ApplicationTypeTitle, this.ApplicationFees);
        }
        public static clsApplicationTypes Find(int ApplicationTypeID)
        {

            string ApplicationTypeTitle = "";
            float ApplicationFees = 0;

            if (clsApplicationTypesData.GetApplicationTypeInfoByID(ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationFees))

                return new clsApplicationTypes(ApplicationTypeID, ApplicationTypeTitle, ApplicationFees);
            else
                return null;

        }

        public static clsApplicationTypes Find(string ApplicationTypeTitle)
        {

            int ApplicationTypeID = -1;
            float ApplicationFees = 0;

            if (clsApplicationTypesData.GetApplicationTypeInfoByTitle(ref ApplicationTypeID, ApplicationTypeTitle, ref ApplicationFees))

                return new clsApplicationTypes(ApplicationTypeID, ApplicationTypeTitle, ApplicationFees);
            else
                return null;

        }       
        
        public bool Save()
        {      
            if(_Mode == enMode.AddNew)
            {
                if(_AddNewApplicationType())
                {
                    _Mode = enMode.Update;
                    return true;
                }
                else
                    return false;
            }else if(_Mode==enMode.Update)
            {
                return _UpdateApplication();
            }     
            return false;

        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypesData.GetAllApplicationTypes();

        }

      
      

    }
}



       

     


