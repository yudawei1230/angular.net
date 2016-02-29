using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.BLL
{
    public class AdminBase : BasePageLoading
    {
        public string MessageTips = string.Empty;
        public string TipUrl = string.Empty;
        public string serchBar = string.Empty;
        public string serchItem = string.Empty;
        public string lists = string.Empty;
        public string pages = string.Empty;


        public void SetTips(string tips)
        {
            this.MessageTips = tips;
        }

        public void SetTipsReturn(string tips, string url)
        {
            this.MessageTips = tips;
            this.TipUrl = url;
        }
    }
}
