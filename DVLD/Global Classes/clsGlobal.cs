using System;
using DVLD_Bussiness;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;

namespace DVLD.Classes
{
    internal static class clsGlobal
    {
        public static clsUser CurrentUser;
        private static string _KeyPath = @"HKEY_Current_User\SOFTWARE\DVLD";
        
        public static bool WriteToRegistry(string ValueName, string ValueData)
        {
            try
            {
                //write the value to registry
                Registry.SetValue(_KeyPath, ValueName, ValueData, RegistryValueKind.String);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured: " + ex.Message);
                return false;
            }
        }

        public static string ReadFromRegistry(string ValueName)
        {
            string ValueData = null;
            try
            {
                //read the value from registry
                ValueData = Registry.GetValue(_KeyPath, ValueName, null) as string;
                if (ValueData != null)
                {
                    return ValueData;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured: " + ex.Message);
            }

            return ValueData;
        }

        public static bool StoreLoginInfo(string Username, string Password)
        {
            //Encrypt Password data before save it in Registry
            string EncryptPassword = clsUtil.Encrypt(Password);
            bool Result = WriteToRegistry("UserName", Username) && WriteToRegistry("Password", EncryptPassword);
            return Result;
        }
        public static bool GetStoredLoginInfo(ref string UserName, ref string Password)
        {
            UserName = ReadFromRegistry("Username");
            string EncryptPassword = ReadFromRegistry("Password");
            Password = clsUtil.Decrypt(EncryptPassword);           
             

            return (UserName != null && Password != null);

        }

        









    }
}

