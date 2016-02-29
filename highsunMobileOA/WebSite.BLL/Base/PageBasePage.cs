using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace WebSite.BLL
{
    public class PageBasePage : System.Web.UI.Page
    {
        public void BasePage_Init(string _title, string _keywords, string _description)
        {
            Page.Title = _title;
            for (int i = 0; i < Header.Controls.Count; i++)
            {
                ControlCollection ct = Header.Controls;
                if (ct[i].GetType().Name == "HtmlMeta")
                {
                    HtmlMeta tag = (HtmlMeta)ct[i];

                    switch (tag.Name.ToLower())
                    {
                        case "keywords":
                            Header.Controls.Remove(tag);
                            tag.Name = "Keywords";
                            tag.Content = _keywords;
                            Header.Controls.Add(tag);
                            break;
                        case "description":
                            Header.Controls.Remove(tag);
                            tag.Name = "Description";
                            tag.Content = _description;
                            Header.Controls.Add(tag);
                            break;
                    }
                }
            }
        }
    }
}
