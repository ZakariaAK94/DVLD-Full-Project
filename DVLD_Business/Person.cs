using System;
using System.Collections.Generic;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Bussiness
{
    public class clsPerson       
    {
        public enum enMode { AddNew = 0, Update = 1 };
        
        public enMode Mode = enMode.AddNew;

        public int PersonID { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }
        public string LastName { set; get; }

        public string FullName { get {  return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; } }
        public string NationalNo { set; get; }
       
        public DateTime DateOfBirth { set; get; }       
        public byte Gender { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        private string _ImagePath { set; get; }
        public int NationalityCountryID { set; get;}

        public string ImagePath
        {
            get
            { return _ImagePath; }
            set { _ImagePath = value; }
        }

        public clsCountry CountryInfo;

        public clsPerson()
        {
            this.PersonID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.DateOfBirth = DateTime.Now;
            this.NationalityCountryID = -1;
            this.ImagePath = "";
            this.Gender = 0;

            Mode = enMode.AddNew;

        }

        private clsPerson(int ID,string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName,
            byte Gender, string Email, string Phone, string Address, DateTime DateOfBirth,
            int NationalityCountryID, string ImagePath)

        {
            this.PersonID = ID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.Gender = Gender;   
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
            this.CountryInfo = clsCountry.Find(NationalityCountryID);

            Mode = enMode.Update;

        }

        private bool _AddNewPerson()
        {
            //call DataAccess Layer 

            this.PersonID = clsPersonData.AddNewPerson(this.NationalNo,this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                this.Gender,this.Email, this.Phone, this.Address, this.DateOfBirth, this.NationalityCountryID, this.ImagePath) ;

            return (this.PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            //call DataAccess Layer 

            return clsPersonData.UpdatePerson(this.PersonID,this.NationalNo,this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                this.Gender, this.Email, this.Phone, this.Address, this.DateOfBirth, this.NationalityCountryID, this.ImagePath);

        }

        public static clsPerson Find(int ID)
        {

            string NationalNo="",FirstName = "", SecondName = "", ThirdName = "", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            byte Gender = 0;
            int NationalityCountryID = -1;

            if (clsPersonData.GetPersonInfoByID(ID,ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                          ref Gender,ref Email, ref Phone, ref Address, ref DateOfBirth, ref NationalityCountryID, ref ImagePath))

                return new clsPerson(ID, NationalNo,FirstName,SecondName,ThirdName, LastName,Gender,
                           Email, Phone, Address, DateOfBirth, NationalityCountryID, ImagePath);
            else
                return null;
        }

        public static clsPerson Find(string NationalNo)
        {

            int PersonID = -1;
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            byte Gender = 0;
            int NationalityCountryID = -1;

            if (clsPersonData.GetPersonInfoByNationalNo(NationalNo,ref PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                          ref Gender, ref Email, ref Phone, ref Address, ref DateOfBirth, ref NationalityCountryID, ref ImagePath))

                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, Gender,
                           Email, Phone, Address, DateOfBirth, NationalityCountryID, ImagePath);
            else
                return null;
        }
        public static int FindByNationalNo(string NationalNo)
        {
            return (clsPersonData.FindPersonID(NationalNo));       
        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePerson();

            }

            return false;
        }

        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();

        }

      

        public static bool DeletePerson(int ID)
        {
            return clsPersonData.DeletePerson(ID);
        }

        public static bool isPersonExist(int ID)
        {
            return clsPersonData.IsPersonExist(ID);
        }
        // no need for this function, it is only slow down my project
        //public static DataTable FilterData(string ColumnName, string SearchQuery)
        //{
        //  //  return clsPersonData.FilterData(ColumnName,SearchQuery);
        //}

        public static bool IsPersonExist(string NationalNo)
        {
            return clsPersonData.IsPersonExist(NationalNo);
        }


    }
}