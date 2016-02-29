using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web.Security;

namespace WebSite.Comman
{
    public class DEncryptHelper
    {
        public static string Decrypt(string encrypted, string key)
        {
            return Decrypt(encrypted, key, Encoding.Default);
        }

        public static byte[] Decrypt(byte[] encrypted, byte[] key)
        {
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = MakeMD5(key);
            des.Mode = CipherMode.ECB;
            return des.CreateDecryptor().TransformFinalBlock(encrypted, 0, encrypted.Length);
        }

        public static string Decrypt(string encrypted, string key, Encoding encoding)
        {
            byte[] buff = Convert.FromBase64String(encrypted);
            byte[] kb = Encoding.Default.GetBytes(key);
            return encoding.GetString(Decrypt(buff, kb));
        }

        public static byte[] Encrypt(byte[] original, byte[] key)
        {
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = MakeMD5(key);
            des.Mode = CipherMode.ECB;
            return des.CreateEncryptor().TransformFinalBlock(original, 0, original.Length);
        }

        public static string Encrypt(string original, int encryptFormat)
        {
            switch (encryptFormat)
            {
                case 0:
                    return FormsAuthentication.HashPasswordForStoringInConfigFile(original, "SHA1");

                case 1:
                    return FormsAuthentication.HashPasswordForStoringInConfigFile(original, "MD5");
            }
            return "";
        }

        public static string Encrypt(string original, string key)
        {
            byte[] buff = Encoding.Default.GetBytes(original);
            byte[] kb = Encoding.Default.GetBytes(key);
            return Convert.ToBase64String(Encrypt(buff, kb));
        }

        public static string GetRandomNumber()
        {
            string randomNumber = "";
            randomNumber = DateTime.Now.ToString("yyyyMMddHHmmss");
            Random rdm = new Random();
            randomNumber = randomNumber + rdm.Next(0x989680, 0x5f5e0ff).ToString();
            rdm = null;
            return randomNumber;
        }

        public static string GetRandomNumber(int length, bool isSleep)
        {
            if (isSleep)
            {
                Thread.Sleep(3);
            }
            string result = "";
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                result = result + random.Next(10).ToString();
            }
            return result;
        }

        public static string GetRandWord(int length)
        {
            string checkCode = string.Empty;
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                char code;
                int number = random.Next();
                if ((number % 2) == 0)
                {
                    code = (char) (0x30 + ((ushort) (number % 10)));
                }
                else
                {
                    code = (char) (0x41 + ((ushort) (number % 0x1a)));
                }
                checkCode = checkCode + code.ToString();
            }
            return checkCode;
        }

        public static byte[] MakeMD5(byte[] original)
        {
            byte[] keyhash = new MD5CryptoServiceProvider().ComputeHash(original);
            return keyhash;
        }

        public static string MakeMD5(string original, string encoding)
        {
            byte[] byteOriginal = new MD5CryptoServiceProvider().ComputeHash(Encoding.GetEncoding(encoding).GetBytes(original));
            StringBuilder ciphertext = new StringBuilder(0x20);
            for (int i = 0; i < byteOriginal.Length; i++)
            {
                ciphertext.Append(byteOriginal[i].ToString("x").PadLeft(2, '0'));
            }
            return ciphertext.ToString();
        }
    }
}

