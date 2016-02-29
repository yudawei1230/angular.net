using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI;

namespace WebApplication.Ajax
{
    public partial class ValidCode : System.Web.UI.Page
    {
        //private string ValiDate;
        private void CreateImage(string randomcode)
        {
            int maxValue = 0x2d;
            int width = randomcode.Length * 20;
            Bitmap image = new Bitmap(width, 30);
            Graphics graphics = Graphics.FromImage(image);
            graphics.Clear(Color.AliceBlue);
            graphics.DrawRectangle(new Pen(Color.Black, 0f), 0, 0, image.Width - 1, image.Height - 1);
            Random random = new Random();
            Pen pen = new Pen(Color.LightGray, 0f);
            for (int i = 0; i < 50; i++)
            {
                int x = random.Next(0, image.Width);
                int y = random.Next(0, image.Height);
                graphics.DrawRectangle(pen, x, y, 1, 1);
            }
            char[] chArray = randomcode.ToCharArray();
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            Color[] colorArray = new Color[] { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };
            string[] strArray = new string[] { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial" };
            for (int j = 0; j < chArray.Length; j++)
            {
                int index = random.Next(7);
                int num8 = random.Next(4);
                Font font = new Font(strArray[num8], 14f, FontStyle.Bold);
                Brush brush = new SolidBrush(colorArray[index]);
                Point point = new Point(14, 15);
                float angle = random.Next(-maxValue, maxValue);
                graphics.TranslateTransform((float)point.X, (float)point.Y);
                graphics.RotateTransform(angle);
                graphics.DrawString(chArray[j].ToString(), font, brush, 1f, 1f, format);
                graphics.RotateTransform(-angle);
                graphics.TranslateTransform(2f, (float)-point.Y);
            }
            MemoryStream stream = new MemoryStream();
            image.Save(stream, ImageFormat.Gif);
            base.Response.ClearContent();
            base.Response.ContentType = "image/gif";
            base.Response.Expires = 0;
            base.Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1.0);
            base.Response.CacheControl = "no-cache";
            base.Response.BinaryWrite(stream.ToArray());
            graphics.Dispose();
            image.Dispose();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CreateImage(CreateVerifyCode(4));
        }

        public string CreateVerifyCode(int length)
        {
            string str = string.Empty;
            Random random = new Random();
            while (str.Length < length)
            {
                char ch;
                int num = random.Next();
                if ((num % 3) == 0)
                {
                    ch = (char)(0x61 + ((ushort)(num % 0x1a)));
                }
                else
                {
                    ch = (char)(0x30 + ((ushort)(num % 10)));
                }
                if ((((ch != '0') && (ch != 'o')) && (ch != 'i') && ((ch != '1') && (ch != '7'))) && (ch != 'l'))
                {
                    str = str + ch.ToString();
                }
            }
            string version = WebSite.Comman.SRequest.GetQueryString("v");
            if (version != "")
            {
                this.Context.Session["ValiDate" + version] = str;
                return (string)this.Context.Session["ValiDate" + version];
            }
            else
            {
                this.Context.Session["ValiDate"] = str;
                return (string)this.Context.Session["ValiDate"];
            }
        }
    }

}