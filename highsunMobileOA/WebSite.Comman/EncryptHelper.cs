using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Web.Security;

namespace WebSite.Comman
{
    public class EncryptHelper
    {
        /// <summary>
        /// SHA1加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string SHA1Password(string password)
        {
            string strSHA1 = string.Empty;
            strSHA1 = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
            return strSHA1;
        }
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string MD5Password(string password)
        {
            string strMD5 = string.Empty;
            strMD5 = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");
            return strMD5;
        }
        readonly static string key = "DA39A3EE5E6B4B0D3255BFEF95601890AFD80709";
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Encode(string data)
        {
            byte[] byKey = System.Text.Encoding.Default.GetBytes(key.Substring(5, 8));
            byte[] byIV = System.Text.Encoding.Default.GetBytes(key.Substring(5, 8));

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(cst);
            cst.Write(System.Text.Encoding.Default.GetBytes(data), 0, System.Text.Encoding.Default.GetByteCount(data));
            //sw.Write(data);   
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Decode(string data)
        {
            //把密钥转成二进制数组
            byte[] byKey = System.Text.Encoding.Default.GetBytes(key.Substring(5, 8));
            byte[] byIV = System.Text.Encoding.Default.GetBytes(key.Substring(5, 8));

            byte[] byEnc;
            try
            {
                //base64解码
                byEnc = Convert.FromBase64String(data);
            }
            catch
            {
                return null;
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            byte[] tmp = new byte[ms.Length];
            cst.Read(tmp, 0, tmp.Length);
            string result = System.Text.Encoding.Default.GetString(tmp);

            return result.Replace("\0", "");
        }
    }
}
