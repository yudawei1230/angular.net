using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web;

namespace WebSite.Comman
{
    [Obsolete]
    public class ValidateCode
    {
        private static void CreateValidateCodeImage(string checkCode)
        {
            if ((checkCode != null) && (checkCode.Trim() != string.Empty))
            {
                Bitmap image = new Bitmap((int) Math.Ceiling((double) (checkCode.Length * 15.0)), 0x1a);
                Graphics graphics = Graphics.FromImage(image);
                Random random = new Random();
                graphics.Clear(Color.WhiteSmoke);
                for (int i = 0; i < 0x2c; i++)
                {
                    int num2 = random.Next(image.Width - i);
                    int num3 = random.Next(image.Width);
                    int num4 = random.Next(image.Height);
                    int num5 = random.Next(image.Height);
                    graphics.DrawLine(new Pen(Color.White), num2, num4, num3, num5);
                }
                Font font = new Font("Arial", 14f, FontStyle.Italic | FontStyle.Bold);
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Coral, Color.Black, 1.2f, true);
                graphics.DrawString(checkCode, font, brush, (float) 2f, (float) 2f);
                for (int j = 0; j < 5; j++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                graphics.DrawRectangle(new Pen(Color.OldLace), 0, 0, image.Width - 1, image.Height - 1);
                MemoryStream stream = new MemoryStream();
                image.Save(stream, ImageFormat.Gif);
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.ContentType = "image/Gif";
                HttpContext.Current.Response.BinaryWrite(stream.ToArray());
            }
        }

        public static string Generate()
        {
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            string checkCode = GenerateCode();
            CreateValidateCodeImage(checkCode);
            return checkCode;
        }

        private static string GenerateCode()
        {
            string str = string.Empty;
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                char ch;
                int num = random.Next();
                if ((num % 2) == 0)
                {
                    ch = (char) (0x30 + ((ushort) (num % 10)));
                }
                else
                {
                    ch = (char) (0x41 + ((ushort) (num % 0x1a)));
                }
                str = str + ch.ToString();
            }
            return str;
        }
    }
}

