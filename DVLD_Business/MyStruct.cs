using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Bussiness
{
    public struct stDLApplication
    {
        //this is for LDLicenseApplicationView
        public int _LocalDrivingLicenseApplicationID;
        public string _ClassName;
        public string _FullName;
        public string _NationalNo;
        public DateTime _ApplicationDate;
        public int _PassedTestsCount;
        public byte _ApplicationStatus;
        public decimal _ClassFees;
        //this is for Applications
        public int _ApplicationID;
        public int _ApplicantPersonID;        
        public int _ApplicationTypeID;
        public DateTime _LastStatusDate;
        public string _CurrentUserName;
        //this is for ApplicationType
        public float _ApplicationFees;
        public string _ApplicationTypeTitle;
        // this is for DetainLicense
        public bool IsDetain;
        
    }

    public struct stTestAppointment
    {
        public int _TestAppointmentID;
        public int _LocalDrivingLicenseApplicationID;
        public int _ApplicationID;
        public string _TestTypeTitle;
        public string _FullName;
        public DateTime _AppointmentDate;   
        public string _ClassName;     
        public float _PaidFees;
        public bool _Islocked;
        public int _PassTestCount;
        public string _CurrentUserName;
        public int Trial;
    }






}
