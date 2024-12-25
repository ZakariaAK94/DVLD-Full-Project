using DVLD_DataAccess;
using DVLD_Bussiness;
using System.Data;
using System.Collections.Generic;
using System;

namespace DVLD_Bussiness
{
    public class clsUser
    {

        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;

        public int UserID { set; get; }
        public int PersonID { set; get; }

        public clsPerson PersonInfo;
        public string UserName { set; get; }
        public string Password { set; get; } 
        public bool isActive { set; get; } 

        public clsUser()
        {
            this.UserID = -1;
            //this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            this.isActive = true;

            Mode = enMode.AddNew;

        }

        
        private clsUser(int UserID, int PersonID, string UserName, string Password,bool isActive)

        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName= UserName;
            this.Password = Password;
            this.isActive = isActive;
            
            Mode = enMode.Update;

        }

        private bool _AddNewUser()
        {
            //call DataAccess Layer 

            this.UserID = clsUserData.AddNewUser(this.PersonID, this.UserName, this.Password, this.isActive);

            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            //call DataAccess Layer 

            return clsUserData.UpdateUser(this.UserID, this.PersonID, this.UserName, this.Password, this.isActive);                

        }

        public static clsUser FindByUserID(int UserID)
        {
            int PersonID = -1;
            string UserName = "", Password = "";            
            bool isActive = false;           
            if (clsUserData.GetUserInfoByUserID(UserID, ref PersonID, ref UserName, ref Password, ref isActive))              
                return new clsUser(UserID, PersonID,UserName, Password, isActive);
            else
                return null;
        }

        public static clsUser FindByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = "", Password = "";
            bool isActive = false;
            if (clsUserData.GetUserInfoByPersonID(PersonID, ref UserID, ref UserName, ref Password, ref isActive))
                return new clsUser(UserID, PersonID, UserName, Password, isActive);
            else
                return null;
        }

        public static clsUser FindByUserNameAndPassword(string UserName, string Password)
        {
            int UserID = -1;
            int PersonID = -1;
           // string Password = "";
            bool isActive = false;
            if (clsUserData.GetUserInfoByUserNameAndPassword(ref UserID,ref PersonID, UserName, Password, ref isActive))
                return new clsUser(UserID, PersonID, UserName, Password, isActive);
            else
                return null;
        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateUser();

            }

            return false;
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();

        }

        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }

        

        

        public static bool isUserExistForPersonID(int PersonID)
        {
            return clsUserData.IsUserExistForPersonID(PersonID);
        }

        public static bool isUserExist(string UserName)
        {
            return clsUserData.IsUserExist(UserName);
        }

        //public static bool isUserExist(int UserID)
        //{
        //    return clsUserData.IsUserExistForPersonID(UserID);
        //}

        //public static bool isNationalNoAffectedToAnUser(string NationalNo)
        //{
        //    return clsUserData.isNationalNoAffectedToAnUser(NationalNo);
        //}

        //public static DataTable FilterData(string ColumnName, string SearchQuery)
        //{
        //    return clsUserData.FilterData(ColumnName, SearchQuery);
        //}

        //public static DataTable FilterDataByIsActive(string ColumnName, int Index)
        //{
        //    return clsUserData.FilterDataByIsActive(ColumnName, Index);
        //}

        //public static List<string> GetAllUserName()
        //{
        //    return clsUserData.GetAllUserName();
        //}


    }
}