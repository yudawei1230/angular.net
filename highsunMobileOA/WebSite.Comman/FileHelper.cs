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
        /// 删除文件
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
        /// 读取文件夹
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string ReadFile(string fileName)
        {
            string str = string.Empty;
            if (!File.Exists(fileName))
            {
                throw new FieldAccessException("文件不存在!");
            }
            using (StreamReader reader = new StreamReader(fileName, Encoding.Default))
            {
                str = reader.ReadToEnd();
                reader.Close();
            }
            return str;
        }

        /// <summary>
        /// 检查文件是否存在
        /// </summary>
        /// <param name="filename">文件名称</param>
        /// <returns></returns>
        public static bool FileExists(string filename)
        {
            return File.Exists(filename);
        }

        /// <summary>
        /// 创建文件
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
        /// 判断文件是否文件类型
        /// </summary>
        /// <param name="filename">文件名称</param>
        /// <returns>是否图片</returns>
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
        /// 获取文件的扩展名
        /// </summary>
        /// <param name="filename">文件名称</param>
        /// <returns>扩展名</returns>
        public static string GetFileExtension(string filename)
        {
            if (filename.EndsWith(".") || (filename.IndexOf(".") == -1))
            {
                return "";
            }
            return filename.Substring(filename.LastIndexOf(".") + 1).ToLower();
        }
        
        /// <summary>
        /// 获取文件名称
        /// </summary>
        /// <param name="url">url地址</param>
        /// <returns>文件名称</returns>
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
        /// 得到当前服务器的绝对路径
        /// </summary>
        /// <param name="strPath">虚拟路径的路径</param>
        /// <returns>绝对路径</returns>
        public static string GetMapPath(string strPath)
        {
            return HttpContext.Current.Server.MapPath(strPath);
        }

    }
}
