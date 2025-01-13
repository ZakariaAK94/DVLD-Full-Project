using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Win32;

namespace DVLD.Classes
{
    public  class clsUtil
    {
        private static string _keyForEncrypt;
        public static string GenerateGUID()
        {
            // generate a new GUID
            Guid guid = Guid.NewGuid();

            // convert guid to a string
            return guid.ToString(); 
        }

        private static string ReplaceFileNameWithGUID(string sourcefile)
        {
            string FileName = sourcefile;
            FileInfo fi = new FileInfo(FileName);
            string ext = fi.Extension;
            return GenerateGUID() + ext;

        }
        public static bool CreateFolderIfDoesnotExists(string path)
        {
            if(!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                    return true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error happened during creation of the folder :"+ex.Message);
                    return false;
                }
            }

            return true;
        }

        public static bool DeplaceImageToPersonImageFolder(ref string sourcefile)
        {
            string DestinationFolder = @"C:\Users\AKILZA\Desktop\DVLD PersonImageFolder\";

            if(!CreateFolderIfDoesnotExists(DestinationFolder))
            {
                return false;
            }
            string DestinationFile = DestinationFolder + ReplaceFileNameWithGUID(sourcefile);
            try
            {
                File.Copy(sourcefile, DestinationFile, true);
            }
            catch (IOException iox)
            {
                MessageBox.Show("Error provide :" + iox.Message);
                return false;
            }
                
            sourcefile = DestinationFile;
            return true;
        }

        public static string Encrypt(string plainText)
        {
            _keyForEncrypt = ConfigurationManager.AppSettings["keyForEncrypt"];
            using (Aes aesAlg = Aes.Create())
            {
                // Set the key and IV for AES encryption
                aesAlg.Key = Encoding.UTF8.GetBytes(_keyForEncrypt);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];// IV (Initialization Vector) is set to an array of zeros with a size based on the block size of the AES algorithm.
                                                           //The IV is crucial for ensuring that identical plaintext blocks will encrypt to different ciphertext blocks


                // Create an encryptor
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Encrypt the data
                using (var msEncrypt = new System.IO.MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }

                    // Return the encrypted data as a Base64-encoded string
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }


        public static string Decrypt(string cipherText)
        {
            _keyForEncrypt = ConfigurationManager.AppSettings["keyForEncrypt"];
            using (Aes aesAlg = Aes.Create())
            {
                // Set the key and IV for AES decryption
                aesAlg.Key = Encoding.UTF8.GetBytes(_keyForEncrypt);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];


                // Create a decryptor
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);


                // Decrypt the data
                using (var msDecrypt = new System.IO.MemoryStream(Convert.FromBase64String(cipherText)))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                {
                    // Read the decrypted data from the StreamReader
                    return srDecrypt.ReadToEnd();
                }
            }
        }
    }
}
