using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;


namespace WebSite.Comman
{
    public class FileHelper
    {
        /// <summary>
        /// ɾ���ļ�
        /// </summary>
        /// <param name="fileName"></param>
        public static bool DeleteFile(string fileFullPath)
        {
            if (File.Exists(fileFullPath))
            {
                try
                {
                    File.Delete(fileFullPath);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        /// <summary>
        /// ��ȡ�ļ���
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string ReadFile(string fileName)
        {
            string str = string.Empty;
            if (!File.Exists(fileName))
            {
                throw new FieldAccessException("�ļ�������!");
            }
            using (StreamReader reader = new StreamReader(fileName, Encoding.Default))
            {
                str = reader.ReadToEnd();
                reader.Close();
            }
            return str;
        }

        /// <summary>
        /// ����ļ��Ƿ����
        /// </summary>
        /// <param name="filename">�ļ�����</param>
        /// <returns></returns>
        public static bool FileExists(string filename)
        {
            return File.Exists(filename);
        }

        /// <summary>
        /// �����ļ�
        /// </summary>
        /// <param name="content"></param>
        /// <param name="fileName"></param>
        /// <param name="append"></param>
        public static void WriteFile(string content, string fileName, bool append)
        {
            using (StreamWriter writer = new StreamWriter(fileName, append, Encoding.Default))
            {
                writer.Write(content);
            }
        }

        /// <summary>
        /// �ж��ļ��Ƿ��ļ�����
        /// </summary>
        /// <param name="filename">�ļ�����</param>
        /// <returns>�Ƿ�ͼƬ</returns>
        public static bool IsImgFilename(string filename)
        {
            if (filename.EndsWith(".") || (filename.IndexOf(".") == -1))
            {
                return false;
            }
            string str = filename.Substring(filename.LastIndexOf(".") + 1).ToLower();
            if ((!(str == "jpg") && !(str == "jpeg")) && (!(str == "png") && !(str == "bmp")))
            {
                return (str == "gif");
            }
            return true;
        }

        /// <summary>
        /// ��ȡ�ļ�����չ��
        /// </summary>
        /// <param name="filename">�ļ�����</param>
        /// <returns>��չ��</returns>
        public static string GetFileExtension(string filename)
        {
            if (filename.EndsWith(".") || (filename.IndexOf(".") == -1))
            {
                return "";
            }
            return filename.Substring(filename.LastIndexOf(".") + 1).ToLower();
        }
        
        /// <summary>
        /// ��ȡ�ļ�����
        /// </summary>
        /// <param name="url">url��ַ</param>
        /// <returns>�ļ�����</returns>
        public static string GetFilename(string url)
        {
            if (url == null)
            {
                return "";
            }
            string[] strArray = url.Split(new char[] { '/' });
            return strArray[strArray.Length - 1].Split(new char[] { '?' })[0];
        }

        /// <summary>
        /// �õ���ǰ�������ľ���·��
        /// </summary>
        /// <param name="strPath">����·����·��</param>
        /// <returns>����·��</returns>
        public static string GetMapPath(string strPath)
        {
            return HttpContext.Current.Server.MapPath(strPath);
        }

    }
}
