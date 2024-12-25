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
        /* public static bool StoreLoginInfo(string Username, string Password)
         {
             try
             {
                 //this will get the current project directory folder
                 string currentDirectory = System.IO.Directory.GetCurrentDirectory();
                 //Define the path to the text file where  you want to save the data
                 string filePath = currentDirectory + "\\data.txt";
                 // incease the username is empty, delete the file
                 if (Username == "" && File.Exists(filePath))
                 {
                     File.Delete(filePath);
                     return true;
                 }
                 //concatenate username  and password with seperator
                 string DataToSave = Username + "#//#" + Password;
                 // Create Streamwriter to write to the file
                 using (StreamWriter writer = new StreamWriter(filePath))
                 {
                     // write the data to file
                     writer.WriteLine(DataToSave);
                     return true;
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show($"An Error occured: {ex.Message}");
                 return false;
             }

         }

         public static bool GetStoredLoginInfo(ref string UserName, ref string Password)
         {
             try
             {
                 //this will get the current project directory folder
                 string currentDirectory = System.IO.Directory.GetCurrentDirectory();
                 //Define the path to the text file where  you want to save the data
                 string filePath = currentDirectory + "\\data.txt";
                 // Check if the file exists
                 if (File.Exists(filePath))
                 {
                     using (StreamReader reader = new StreamReader(filePath))
                     {
                         //read data line by line until the end of the file
                         string line;
                         while ((line = reader.ReadLine()) != null)
                         {
                             Console.WriteLine(line);
                             string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);
                             UserName = result[0];
                             Password = result[1];
                         }
                         return true;
                     }
                 }
                 else
                 {
                     return false;
                 }

             }
             catch (Exception ex)
             {
                 MessageBox.Show($"Error occured {ex.Message}");
                 return false;
             }            
         }
        */

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

