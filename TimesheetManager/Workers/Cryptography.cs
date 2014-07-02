using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace TimesheetManager.Workers
{
    public class Cryptography
    {
        public static string Encrypt(string toEncrypt, string key = "O3R")
        {
            TripleDESCryptoServiceProvider desCryptography = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
            byte[] byteHash, byteBuff;

            byteHash = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(key));
            desCryptography.Key = byteHash;
            desCryptography.Mode = CipherMode.ECB;
            byteBuff = ASCIIEncoding.ASCII.GetBytes(toEncrypt);

            return Convert.ToBase64String(desCryptography.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
        }

        public static string Decrypt(string toDecrypt, string key = "O3R")
        {
            TripleDESCryptoServiceProvider desCryptography = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
            byte[] byteHash, byteBuff;

            byteHash = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(key));
            desCryptography.Key = byteHash;
            desCryptography.Mode = CipherMode.ECB;
            byteBuff = Convert.FromBase64String(toDecrypt);

            return ASCIIEncoding.ASCII.GetString(desCryptography.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
        }
    }
}
