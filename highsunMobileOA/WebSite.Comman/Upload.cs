using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Drawing;
using System.Drawing.Imaging;
using System.Xml;
namespace WebSite.Comman
{
    /// <summary>
    /// Upload 的摘要说明
    /// </summary>
    public class Upload
    {
        static XmlDocument xmldoc = new XmlDocument();

        private static int _smallwidth;
        private static int _smallheight;
        private static int _middlewidth;
        private static int _middleheight;
        private static int _bigwidth;
        private static int _bigheight;


        /// <summary>
        /// 获取默认图、大图、小图的比例
        /// </summary>
        private static void getXML()
        {
            xmldoc.Load(FileHelper.GetMapPath("/") + "App_Data/img.xml");
            _smallwidth = int.Parse(XMLUtil.GetNodeValue(xmldoc, "smallwidth"));
            _smallheight = int.Parse(XMLUtil.GetNodeValue(xmldoc, "smallheight"));
            _middlewidth = int.Parse(XMLUtil.GetNodeValue(xmldoc, "middlewidth"));
            _middleheight = int.Parse(XMLUtil.GetNodeValue(xmldoc, "middleheight"));
            _bigwidth = int.Parse(XMLUtil.GetNodeValue(xmldoc, "bigwidth"));
            _bigheight = int.Parse(XMLUtil.GetNodeValue(xmldoc, "bigheight"));
        }


        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="imageUrl">要删除的文件名</param>
        public static void DeleteImage(string imageUrl)
        {
            if (!string.IsNullOrEmpty(imageUrl))
            {
                try
                {
                    string path = FileHelper.GetMapPath(imageUrl);
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
                catch
                {
                }
            }
        }
        #region 普通上传方法
        /// <summary>
        /// 取得一个图片的随机名称
        /// </summary>
        /// <returns>以JPG结尾的文件</returns>
        public string Getimgname()
        {
            int ImgName;
            string FileName;
            Random Radnnumer = new Random();
            ImgName = Radnnumer.Next(1, 10000);
            FileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString() + ImgName + ".jpg";
            return FileName;
        }

        /// <summary>
        /// 检测上传图片，判断格式，文件大小
        /// </summary>
        /// <returns>格式和大小无误返回真</returns>
        public static bool CheckUploadFile(FileUpload fl_Name)
        {
            string orgFileName = fl_Name.FileName;

            if (!FileHelper.IsImgFilename(orgFileName))
            {
                return false;
            }
            if (fl_Name.FileContent.Length > 2000000)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 保存原图
        /// </summary>
        /// <param name="fl_Name">Html上传控件的Name</param>
        public static string UploadProductImg(System.Web.HttpPostedFile fl_Name)
        {
            if (fl_Name.FileName == "")
            {
                return "";
            }
            string Path = "/Upload/Original/";
            CreatePath(Path);
            Random Radnnumer = new Random();
            string FileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString() + Radnnumer.Next(1, 100000).ToString();
            string Extension = FileHelper.GetFileExtension(fl_Name.FileName);
            FileName = FileName + "." + Extension;
            fl_Name.SaveAs(System.Web.HttpContext.Current.Server.MapPath(Path + FileName));
            return FileName;
        }
       
        /// <summary>
        /// 保存多个原图
        /// </summary>
        /// <param name="fl_Name">Html上传控件的Name</param>
        /// <param name="i">更改自定文件名</param>
        /// <returns></returns>
        public static string UploadProductImg(System.Web.HttpPostedFile fl_Name, int i)
        {
            if (fl_Name.FileName == "")
            {
                return "";
            }
            string Path = "/Upload/Storage/Original/";
            CreatePath(Path);
            Random Radnnumer = new Random(i);
            string FileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString() + Radnnumer.Next(1, 100000).ToString() + i.ToString() + (i + 1).ToString();
            return SaveFile(fl_Name, Path, FileName);
        }

        /// <summary>
        /// 保存上传的文件
        /// </summary>
        /// <param name="fl_Name">Html上传控件的Name</param>
        /// <param name="Path">保存的路径</param>
        /// <param name="FileName">保存的文件名</param>
        /// <returns></returns>
        private static string SaveFile(System.Web.HttpPostedFile fl_Name, string Path, string FileName)
        {

            string Extension = FileHelper.GetFileExtension(fl_Name.FileName);
            FileName = FileName + "." + Extension;
            fl_Name.SaveAs(System.Web.HttpContext.Current.Server.MapPath(Path + FileName));
            return Path + FileName;
        }

        /// <summary>
        /// 创建一个目录
        /// </summary>
        /// <param name="Path">目录名称</param>
        private static void CreatePath(string Path)
        {
            if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(Path)))
            {
                Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(Path));
            }
        }
      

       /// <summary>
       /// 生成自定义宽高的4张图
       /// </summary>
        /// <param name="fl_Name">Html上传控件的Name</param>
        /// <param name="oriUrl">原始图（原始尺寸不改变）</param>
        /// <param name="bigUrl">大图路径</param>
        /// <param name="bigWidth">大图宽</param>
       /// <param name="bigHeight">大图高</param>
       /// <param name="thuUrl">中图路径</param>
        /// <param name="thuWidth">中图宽</param>
        /// <param name="thuHeight">中图高</param>
       /// <param name="icoUrl">小图路径</param>
        /// <param name="icoWidth">小图宽</param>
        /// <param name="icoHeight">小图高</param>
        /// <param name="mode">生成缩略图的方式</param>
       /// <returns></returns> 
        public static string UploadProductImg(System.Web.HttpPostedFile fl_Name, ref string Url_ori, ref string Url_big)
        {
            string fname = "";
            if (fl_Name.ContentLength > 0)
            {
                string Path_BigPicture = "/Upload/BigPicture/";
                string Path_Original = "/Upload/Original/";
                Random Radnnumer = new Random();
                string FileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString() + Radnnumer.Next(1, 100000).ToString();
                CreatePath(Path_BigPicture);
                CreatePath(Path_Original);
                Url_ori = SaveFile(fl_Name, Path_Original, FileName);
                Url_big = SaveFile(fl_Name, Path_BigPicture, FileName);
                MakeThumbnail(System.Web.HttpContext.Current.Server.MapPath(Url_big), System.Web.HttpContext.Current.Server.MapPath(Url_ori), 480, 210, "w");
                string Extension = FileHelper.GetFileExtension(fl_Name.FileName);
                fname = Path_Original + FileName + "." + Extension;
            }
            else
            {
                fname = "default.gif";
            }
            return fname;
        }
        /// <summary>
        /// 生成自定义宽高的4张图
        /// </summary>
        /// <param name="fl_Name">Html上传控件的Name</param>
        /// <param name="oriUrl">原始图（原始尺寸不改变）</param>
        /// <param name="bigUrl">大图路径</param>
        /// <param name="bigWidth">大图宽</param>
        /// <param name="bigHeight">大图高</param>
        /// <param name="thuUrl">中图路径</param>
        /// <param name="thuWidth">中图宽</param>
        /// <param name="thuHeight">中图高</param>
        /// <param name="icoUrl">小图路径</param>
        /// <param name="icoWidth">小图宽</param>
        /// <param name="icoHeight">小图高</param>
        /// <param name="mode">生成缩略图的方式</param>
        /// <param name="i">生成多张图</param>
        /// <returns></returns> 
        public static string UploadProductImg(System.Web.HttpPostedFile fl_Name, ref string oriUrl, ref string bigUrl, int bigWidth, int bigHeight, ref string thuUrl, int thuWidth, int thuHeight, ref string icoUrl, int icoWidth, int icoHeight, ref string mode, int i)
        {
            string fname = "";
            if (fl_Name.ContentLength > 0)
            {                
                string OriginalPath = "/Upload/Storage/Original/";
                string BigPicturePath = "/Upload/Storage/BigPicture/";
                string ThumbnailsPath = "/Upload/Storage/Thumbnails/";
                string IconPath = "/Upload/Storage/icon/";
                Random Radnnumer = new Random();
                string FileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString() + Radnnumer.Next(1, 100000).ToString() + i.ToString() + (i + 1).ToString(); ;
                CreatePath(OriginalPath);
                CreatePath(BigPicturePath);
                CreatePath(ThumbnailsPath);
                CreatePath(IconPath);
                oriUrl = SaveFile(fl_Name, OriginalPath, FileName);
                bigUrl = SaveFile(fl_Name, BigPicturePath, FileName);
                thuUrl = SaveFile(fl_Name, ThumbnailsPath, FileName);
                icoUrl = SaveFile(fl_Name, IconPath, FileName);
                MakeThumbnail(System.Web.HttpContext.Current.Server.MapPath(oriUrl), System.Web.HttpContext.Current.Server.MapPath(bigUrl), bigWidth, bigHeight, mode);
                MakeThumbnail(System.Web.HttpContext.Current.Server.MapPath(oriUrl), System.Web.HttpContext.Current.Server.MapPath(thuUrl), thuWidth, thuHeight, mode);
                MakeThumbnail(System.Web.HttpContext.Current.Server.MapPath(oriUrl), System.Web.HttpContext.Current.Server.MapPath(icoUrl), icoWidth, icoHeight, mode);                
                string Extension = FileHelper.GetFileExtension(fl_Name.FileName);
                fname = FileName + "." + Extension;
            }
            else
            {

                fname = "default.gif";
            }
            return fname;
        }

        public static string UploadProductImg(System.Web.HttpPostedFile fl_Name, ref string oriUrl, ref string bigUrl, int bigWidth, int bigHeight, ref string tmbUrl, int tmbWidth, int tmbHeight)
        {
            string fname = "";
            if (fl_Name.ContentLength > 0)
            {
                string OriginalPath = "/Upload/Original/";
                string BigPicturePath = "/Upload/BigPicture/";
                string ThumbnailsPath = "/Upload/Thumbnails/";
                Random Radnnumer = new Random();
                string FileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString() + Radnnumer.Next(1, 100000).ToString();
                CreatePath(OriginalPath);
                CreatePath(BigPicturePath);
                CreatePath(ThumbnailsPath);
                oriUrl = SaveFile(fl_Name, OriginalPath, FileName);
                bigUrl = SaveFile(fl_Name, BigPicturePath, FileName);
                tmbUrl = SaveFile(fl_Name, ThumbnailsPath, FileName);
                MakeThumbnail(System.Web.HttpContext.Current.Server.MapPath(oriUrl), System.Web.HttpContext.Current.Server.MapPath(bigUrl), bigWidth, bigHeight, "hw");
                MakeThumbnail(System.Web.HttpContext.Current.Server.MapPath(oriUrl), System.Web.HttpContext.Current.Server.MapPath(tmbUrl), tmbWidth, tmbHeight, "hw");
                string Extension = FileHelper.GetFileExtension(fl_Name.FileName);
                fname = FileName + "." + Extension;
            }
            return fname;
        }
        /// <summary>
        /// 保存原图并生成3张缩略图
        /// </summary>
        /// <param name="fl_Name">Html上传控件的Name</param>
        /// <param name="oriUrl">原始图（原始尺寸不改变）</param>
        /// <param name="bigUrl">大图路径</param>
        /// <param name="thuUrl">缩略图路径</param>
        /// <param name="icoUrl">小图路径</param>
        /// <param name="mode">生成缩略图的方式</param>  
        public static string UploadProductImg(System.Web.HttpPostedFile fl_Name, ref string oriUrl, ref string bigUrl, ref string thuUrl, ref string icoUrl, ref string mode)
        {
            string fname = "";
            if (fl_Name.ContentLength > 0)
            {
                getXML();
                string OriginalPath = "/Upload/Storage/Original/";
                string BigPicturePath = "/Upload/Storage/BigPicture/";
                string ThumbnailsPath = "/Upload/Storage/Thumbnails/";
                string IconPath = "/Upload/Storage/icon/";
                Random Radnnumer = new Random();
                string FileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString() + Radnnumer.Next(1, 100000).ToString();
                CreatePath(OriginalPath);
                CreatePath(BigPicturePath);
                CreatePath(ThumbnailsPath);
                CreatePath(IconPath);
                oriUrl = SaveFile(fl_Name, OriginalPath, FileName);
                bigUrl = SaveFile(fl_Name, BigPicturePath, FileName);
                thuUrl = SaveFile(fl_Name, ThumbnailsPath, FileName);
                icoUrl = SaveFile(fl_Name, IconPath, FileName);
                MakeThumbnail(System.Web.HttpContext.Current.Server.MapPath(oriUrl), System.Web.HttpContext.Current.Server.MapPath(bigUrl), _bigwidth, _bigheight, mode);
                MakeThumbnail(System.Web.HttpContext.Current.Server.MapPath(oriUrl), System.Web.HttpContext.Current.Server.MapPath(thuUrl), _middlewidth, _middleheight, mode);
                MakeThumbnail(System.Web.HttpContext.Current.Server.MapPath(oriUrl), System.Web.HttpContext.Current.Server.MapPath(icoUrl), _smallwidth, _smallheight, mode);
                string Extension = FileHelper.GetFileExtension(fl_Name.FileName);
                fname = FileName + "." + Extension;
            }
            else
            {
                fname = "default.gif";
            }
            return fname;
        }

        /// <summary>
        /// 保存原图并生成3张缩略图
        /// </summary>
        /// <param name="fl_Name">Html上传控件的Name</param>
        /// <param name="oriUrl">原始图（原始尺寸不改变）</param>
        /// <param name="bigUrl">大图路径</param>
        /// <param name="thuUrl">缩略图路径</param>
        /// <param name="icoUrl">小图路径</param>
        /// <param name="mode">生成缩略图的方式</param>  
        /// <param name="i">用于批量生成</param>  
        public static string UploadProductImg(System.Web.HttpPostedFile fl_Name, ref string oriUrl, ref string bigUrl, ref string thuUrl, ref string icoUrl, ref string mode, int i)
        {
            string fname = "";
            if (fl_Name.ContentLength > 0)
            {
                getXML();
                string OriginalPath = "/Upload/Storage/Original/";
                string BigPicturePath = "/Upload/Storage/BigPicture/";
                string ThumbnailsPath = "/Upload/Storage/Thumbnails/";
                string IconPath = "/Upload/Storage/icon/";
                Random Radnnumer = new Random();
                string FileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString() + Radnnumer.Next(1, 100000).ToString() + i.ToString() + (i + 1).ToString(); ;
                CreatePath(OriginalPath);
                CreatePath(BigPicturePath);
                CreatePath(ThumbnailsPath);
                CreatePath(IconPath);
                oriUrl = SaveFile(fl_Name, OriginalPath, FileName);
                bigUrl = SaveFile(fl_Name, BigPicturePath, FileName);
                thuUrl = SaveFile(fl_Name, ThumbnailsPath, FileName);
                icoUrl = SaveFile(fl_Name, IconPath, FileName);
                MakeThumbnail(System.Web.HttpContext.Current.Server.MapPath(oriUrl), System.Web.HttpContext.Current.Server.MapPath(bigUrl), _bigwidth, _bigheight, mode);
                MakeThumbnail(System.Web.HttpContext.Current.Server.MapPath(oriUrl), System.Web.HttpContext.Current.Server.MapPath(thuUrl), _middlewidth, _middleheight, mode);
                MakeThumbnail(System.Web.HttpContext.Current.Server.MapPath(oriUrl), System.Web.HttpContext.Current.Server.MapPath(icoUrl), _smallwidth, _smallheight, mode);
                string Extension = FileHelper.GetFileExtension(fl_Name.FileName);
                fname = FileName + "." + Extension;
            }
            else
            {
                
                fname = "default.gif";
            }
            return fname;
        }



        /// <summary>
        /// 上传产品图片，保存3张图片
        /// </summary>
        /// <param name="oriUrl">图片路径</param>
        /// <param name="newOriUrl">返回默认图路径</param>
        /// <param name="newThuUrl">返回缩略图路径</param>
        /// <param name="icon">返回超小图路径</param>
        /// <returns>保存3张图片</returns>
        public static bool MakeProductDefaultImg(string oriUrl, ref string fileName)
        {
            string mode = "w";
            if (oriUrl == "" ||!File.Exists(FileHelper.GetMapPath(oriUrl)))
                return false;
            try
            {
                string oriFileName = oriUrl.Substring(oriUrl.LastIndexOf("/") + 1).Replace("default", "");
                fileName = oriFileName;
                string newOriUrl = "/Upload/Storage/Original/"; //原图
                string newThuUrl = "/Upload/Storage/Thumbnails/"; //缩略图
                string newIcoUrl = "/Upload/Storage/icon/"; //超小图

                if (Directory.Exists(FileHelper.GetMapPath(newThuUrl)) == false)
                {
                    Directory.CreateDirectory(FileHelper.GetMapPath(newThuUrl));
                }

                if (Directory.Exists(FileHelper.GetMapPath(newOriUrl)) == false)
                {
                    Directory.CreateDirectory(FileHelper.GetMapPath(newOriUrl));
                }
                if (Directory.Exists(FileHelper.GetMapPath(newIcoUrl)) == false)
                {
                    Directory.CreateDirectory(FileHelper.GetMapPath(newIcoUrl));
                }
                getXML();

                newOriUrl += oriFileName;
                newThuUrl += oriFileName;
                newIcoUrl += oriFileName;
                
                MakeThumbnail(FileHelper.GetMapPath(oriUrl), FileHelper.GetMapPath(newOriUrl), _bigwidth, _bigheight, mode);//生成列表页,首页
                MakeThumbnail(FileHelper.GetMapPath(oriUrl), FileHelper.GetMapPath(newThuUrl), _middlewidth, _middleheight, mode);//最终页大图
                MakeThumbnail(FileHelper.GetMapPath(oriUrl), FileHelper.GetMapPath(newIcoUrl), _smallwidth, _smallheight, mode);//最终页ICON
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>    
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

            int towidth = width;
            int toheight = height;
            int bitmapx = 0;
            int bitmapy = 0;
            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;
            switch (mode.ToLower())
            {
                case "hw"://指定高宽缩放（可能变形）                      
                    break;
                case "w"://指定宽，高按比例                    
                    toheight = originalImage.Height * width / originalImage.Width;
                    bitmapy = (height - toheight) / 2;
                    bitmapy = bitmapy < 0 ? 0 : bitmapy;
                    break;
                case "h"://指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "cut"://指定高宽裁减（不变形）                
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片
            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(width, height);
            //新建一个画板
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);
            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //清空画布并以透明背景色填充
            g.Clear(Color.White);
            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new Rectangle(bitmapx, bitmapy, towidth, toheight),
                new Rectangle(x, y, ow, oh),
                GraphicsUnit.Pixel);
            System.Drawing.Imaging.Encoder myEncoder;
            System.Drawing.Imaging.ImageCodecInfo myImageCodecInfo;
            System.Drawing.Imaging.EncoderParameter myEncoderParameter;
            System.Drawing.Imaging.EncoderParameters myEncoderParameters;
            myEncoder = System.Drawing.Imaging.Encoder.Quality;
            myImageCodecInfo = GetEncoderInfo("image/jpeg");                        //设定JPG压缩编码
            myEncoderParameters = new EncoderParameters(1);
            myEncoderParameter = new EncoderParameter(myEncoder, 95L);   //设定JPG质量为100%
            myEncoderParameters.Param[0] = myEncoderParameter;
            try
            {
                //以jpg格式保存缩略图
                bitmap.Save(thumbnailPath, myImageCodecInfo, myEncoderParameters);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                myEncoderParameters.Dispose();
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }


        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
        #endregion

        #region 采用模态框上传
        /// <summary>
        /// 采用模态框上传
        /// </summary>
        /// <param name="myFile"></param>
        /// <returns></returns>
        public static string UpFileForm(System.Web.HttpPostedFile myFile)
        {
            string path = "/Upload/" + DateTime.Now.ToString("yy-MM-dd") + "/"; 
            string OldName = System.IO.Path.GetFileName(myFile.FileName);
            Random Radnnumer = new Random();
            string NewName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString() + Radnnumer.Next(1, 100000).ToString();
            if (!Directory.Exists(FileHelper.GetMapPath(path)))
            {
                Directory.CreateDirectory(FileHelper.GetMapPath(path));
            }
            if (OldName.Length > 0)//有文件才执行上传操作再保存到数据库
            {
                string FileExtention = System.IO.Path.GetExtension(myFile.FileName);
                string ppath = path + @"" + NewName + FileExtention;
                string TrueName = HttpContext.Current.Server.MapPath(ppath);
                myFile.SaveAs(TrueName);
                return ppath;
            }
            else
            {
                return "default.gif";
            }
        }

        public static string UpFileForm(System.Web.HttpPostedFile myFile,int i)
        {
            string path = "/Upload/" + DateTime.Now.ToString("yy-MM-dd") + "/";
            string OldName = System.IO.Path.GetFileName(myFile.FileName);
            Random Radnnumer = new Random();
            string NewName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString() + Radnnumer.Next(1, 100000).ToString() + i.ToString() + (i + 1).ToString(); 
            if (!Directory.Exists(FileHelper.GetMapPath(path)))
            {
                Directory.CreateDirectory(FileHelper.GetMapPath(path));
            }
            if (OldName.Length > 0)//有文件才执行上传操作再保存到数据库
            {
                string FileExtention = System.IO.Path.GetExtension(myFile.FileName);
                string ppath = path + @"" + NewName + FileExtention;
                string TrueName = HttpContext.Current.Server.MapPath(ppath);
                myFile.SaveAs(TrueName);
                return ppath;
            }
            else
            {
                return "default.gif";
            }
        }


        /// <summary>
        /// 上传文件格式检查
        /// </summary>
        /// <param name="fieleType">文件后缀名</param>
        /// <returns></returns>
        private static bool CheckFileTypeByFileType(string fieleType)
        {
            string[] strArray = new string[] { "aspx", "js", "asp", "php", "jsp", "vbs", "html", "htm", "shtml", "shtm", "cgi", "asa", "asax" };
            foreach (string str in strArray)
            {
                if (str == fieleType)
                {
                    return false;
                }
            }
            return false;
        }
        #endregion
    }
}