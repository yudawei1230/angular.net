using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace WebSite.WebPage
{

    public class Table
    {
        private int colnum = 0;
        private StringBuilder table = new StringBuilder();
        private StringBuilder temp = new StringBuilder();

        /// <summary>
        /// 预加载一个默认样式的Table
        /// </summary>
        public Table()
        {
            this.table.AppendLine("<table cellpadding=\"0\" cellspacing=\"0\" class=\"admin_list_bg\">");
        }
        /// <summary>
        /// 预加载一个加载样式类Class的Table
        /// </summary>
        /// <param name="cssClass">样式名称</param>
        public Table(string cssClass)
        {
            this.table.AppendLine("<table cellpadding=\"0\" cellspacing=\"0\" class=\"" + cssClass + "\">");
        }
        /// <summary>
        /// 增加一个td单元格
        /// </summary>
        /// <param name="value">td的值，可为空</param>
        public void AddCol(string value)
        {
            this.temp.AppendFormat("     <td>{0}</td>\n", value.Trim().Equals("") ? "&nbsp;" : value);
        }        
        /// <summary>
        /// 增加一个td单元格，单元格中的值可追加字符串集合
        /// </summary>
        /// <param name="format">默认一个值</param>
        /// <param name="value">字符串集合</param>
        public void AddCol(string format, string[] value)
        {
            StringBuilder tmp = new StringBuilder();
            tmp.AppendFormat(format, (object[])value);
            this.AddCol(tmp.ToString());
            tmp = null;
        }
        /// <summary>
        /// 增加一个td单元格，可动态添加style和宽度
        /// </summary>
        /// <param name="style">外观样式</param>
        /// <param name="width">单元格宽度</param>
        /// <param name="value">单元格的值</param>
        public void AddCol(string style, string width, string value)
        {
            this.temp.AppendFormat("    <td style=\"{0}\" width=\"{1}\">{2}</td>\n", style, width, value.Trim().Equals("") ? "&nbsp;" : value);
        }
        /// <summary>
        /// 增加横合并一个td单元格
        /// </summary>
        /// <param name="colspan">几个单元格合并</param>
        /// <param name="value">单元格的值</param>
        public void AddColSpan(string colspan, string value)
        {
            this.temp.AppendFormat("     <td {1}>{0}</td>\n", value.Trim().Equals("") ? "&nbsp;" : value, "colspan=" + colspan);
        }
        /// <summary>
        /// 增加竖合并一个td单元格
        /// </summary>
        /// <param name="colspan">几个单元格合并</param>
        /// <param name="value">单元格的值</param>
        public void AddRowSpan(string rowspan, string value)
        {
            this.temp.AppendFormat("     <td {1}>{0}</td>\n", value.Trim().Equals("") ? "&nbsp;" : value, "rowspan=" + rowspan);
        }
        /// <summary>
        /// 增加头部多个td单元格
        /// </summary>
        /// <param name="headrow">格式如下：值/宽度,val01/10,val02/10,val03/10</param>
        public void AddHead(string headrow)
        {
            string[] head = headrow.Split(new char[] { ',' });
            for (int i = 0; i < head.Length; i++)
            {
                string[] headsplite = head[i].Split(new char[] { '/' });
                this.AddHeadCol(headsplite[1], headsplite[0]);
            }
            this.AddRow();
        }
        /// <summary>
        /// 增加头部一个td单元格
        /// </summary>
        /// <param name="width"></param>
        /// <param name="value"></param>
        public void AddHeadCol(string width, string value)
        {
            this.temp.AppendFormat("     <td width=\"{0}\">{1}</td>\n", width, value);
            this.colnum++;
        }
        /// <summary>
        /// 增加第二行合并多个td单元格
        /// </summary>
        /// <param name="toolBar"></param>
        public void AddToolBar(string toolBar)
        {
            this.temp.AppendFormat("     <td class=\"toolbar\" colspan=\"{0}\">{1}</td>\n", this.colnum, toolBar);
            this.AddRow();
        }

        /// <summary>
        /// 增加一行tr
        /// </summary>
        public void AddRow()
        {
            this.table.AppendLine("  <tr>");
            this.table.AppendLine(this.temp.ToString());
            this.table.AppendLine("  </tr>");
            this.temp.Remove(0, this.temp.Length);
        }
        /// <summary>
        /// 字符串尾部增加一个标签
        /// </summary>
        /// <param name="tag"></param>
        public void AddTag(string tag)
        {
            this.table.AppendLine(tag);
        }
        /// <summary>
        /// 增加一行标题tbody-tr
        /// </summary>
        public void AddTbody()
        {
            this.table.AppendLine("<tbody>");
            this.table.AppendLine("  <tr>");
            this.table.AppendLine(this.temp.ToString());
            this.table.AppendLine("  </tr>");
            this.table.AppendLine("</tbody>");
            this.temp.Remove(0, this.temp.Length);
        }        
        /// <summary>
        /// 封闭table
        /// </summary>
        /// <returns></returns>
        public string GetTable()
        {
            this.table.AppendLine("</table>");
            string tmp = this.table.ToString();
            this.temp = null;
            this.table = null;
            return tmp;
        }

        /// <summary>
        /// 定义多条件搜索方式
        /// </summary>
        public enum Where
        {
            /// <summary>
            /// 大于
            /// </summary>
            GreaterThan,
            /// <summary>
            /// 小于
            /// </summary>
            LessThan,
            /// <summary>
            /// 等于
            /// </summary>
            Equal,
            /// <summary>
            /// 大于并等于
            /// </summary>
            GreaterThanEqual,
            /// <summary>
            /// 小于并等于
            /// </summary>
            LessThanEqual,
            /// <summary>
            /// 模糊查询
            /// </summary>
            Contains,
            /// <summary>
            /// 开始等于
            /// </summary>
            StartWidth,
            /// <summary>
            /// 结束等于
            /// </summary>
            EndWidth,
            /// <summary>
            /// 不等于
            /// </summary>
            NotContains,
            /// <summary>
            /// 不筛选
            /// </summary>
            NoSerch
        }

        /// <summary>
        /// 生成前缀
        /// </summary>
        /// <param name="where">条件方式:GreaterThan 大于,LessThan小于,
        /// Equal等于,GreaterThanEqual大于等于,LessThanEqual小于等于
        /// Contains like模糊查询,StartWidth开始等于,EndWidth结束等于,NotContains不等于
        /// </param>
        /// <returns>对应前缀</returns>
        public string ct(Where where)
        {
            switch (where)
            {
                case Where.GreaterThan: return "w_q_";
                case Where.LessThan: return "w_a_";
                case Where.Equal: return "w_d_";
                case Where.GreaterThanEqual: return "w_g_";
                case Where.LessThanEqual: return "w_e_";
                case Where.Contains: return "w_l_";
                case Where.StartWidth: return "w_r_";
                case Where.EndWidth: return "w_z_";
                case Where.NotContains: return "w_n_";
                case Where.NoSerch: return "_[null]";
            }
            return "";
        }

        /// <summary>
        /// 生成下拉框，用于数字类型。包括：大于、小于、等于、小于等于、大于等于
        /// </summary>
        /// <param name="name">select的name属性</param>
        /// <returns>下拉框</returns>
        public string GenByNum(string name)
        {
            StringBuilder select = new StringBuilder();
            select.AppendFormat("<select name={0}_Serch>", name);
            select.AppendFormat("<option value={0}>不筛选</option>", ct(Where.NoSerch));
            select.AppendFormat("<option value={0}>大于</option>", ct(Where.GreaterThan));
            select.AppendFormat("<option value={0}>小于</option>", ct(Where.LessThan));
            select.AppendFormat("<option value={0}>等于</option>", ct(Where.Equal));
            select.AppendFormat("<option value={0}>小于等于</option>", ct(Where.LessThanEqual));
            select.AppendFormat("<option value={0}>大于等于</option>", ct(Where.GreaterThanEqual));
            select.Append("</select>");
            return select.ToString();
        }

        /// <summary>
        /// 生成下拉框，用于文本类型。包括：包含、等于、开头等于、结尾等于、不包含
        /// </summary>
        /// <param name="name">select的name属性</param>
        /// <returns>下拉框</returns>
        public string GenByTxt(string name)
        {
            StringBuilder select = new StringBuilder();
            select.AppendFormat("<select name=\"{0}_Serch\" >", name);
            select.AppendFormat("<option value={0}>不筛选</option>", ct(Where.NoSerch));
            select.AppendFormat("<option value=\"{0}\" >包含</option>", ct(Where.Contains));
            select.AppendFormat("<option value=\"{0}\" >等于</option>", ct(Where.Equal));
            select.AppendFormat("<option value=\"{0}\" >开头等于</option>", ct(Where.GreaterThanEqual));
            select.AppendFormat("<option value=\"{0}\" >结尾等于</option>", ct(Where.EndWidth));
            select.AppendFormat("<option value=\"{0}\" >不包含</option>", ct(Where.NotContains));
            select.Append("</select>");
            return select.ToString();
        }

        /// 生成单选框
        /// </summary>
        /// <param name="name">input的name属性</param>
        /// <returns>单选框</returns>
        public string GenByBool(string name)
        {
            StringBuilder radio = new StringBuilder();
            string value = ct(Where.Equal) + name;
            radio.AppendFormat("<input type=\"radio\" value=\"_[null]\" checked=\"checked\" name=\"{0}\" id=\"{1}_n\" /><lable for=\"{2}_n\">不筛选</lable>&nbsp;", value, value, value);
            radio.AppendFormat("<input type=\"radio\" value=\"1\" name=\"{0}\" id=\"{1}_t\" /><lable for=\"{2}_t\">是</lable>&nbsp;", value, value, value);
            radio.AppendFormat("<input type=\"radio\" value=\"0\" name=\"{0}\" id=\"{1}_f\" /><lable for=\"{2}_f\">否</lable>&nbsp;", value, value, value);
            return radio.ToString();
        }

        /// 生成反转单选框
        /// </summary>
        /// <param name="name">input的name属性</param>
        /// <returns>单选框</returns>
        public string GenBool(string name)
        {
            StringBuilder radio = new StringBuilder();
            string value = ct(Where.Equal) + name;
            radio.AppendFormat("<input type=\"radio\" value=\"_[null]\" checked=\"checked\" name=\"{0}\" id=\"{1}_n\" /><lable for=\"{2}_n\">不筛选</lable>&nbsp;", value, value, value);
            radio.AppendFormat("<input type=\"radio\" value=\"0\" name=\"{0}\" id=\"{1}_t\" /><lable for=\"{2}_t\">是</lable>&nbsp;", value, value, value);
            radio.AppendFormat("<input type=\"radio\" value=\"1\" name=\"{0}\" id=\"{1}_f\" /><lable for=\"{2}_f\">否</lable>&nbsp;", value, value, value);
            return radio.ToString();
        }


        private IList<SerchItem> qSerch = new List<SerchItem>();

        public void AddSerch(string key, string name, Where where)
        {
            qSerch.Add(new SerchItem(key, name, where));
        }

        /// <summary>
        /// 快速搜索框
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string GenQSerch(out string item)
        {
            item = "";
            if (qSerch.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                string serchBar = string.Empty;
                serchBar += "                <form action=\"" + System.Web.HttpContext.Current.Request.Url.AbsolutePath + "\" method=\"get\">\n";
                serchBar += "                <p class=\"admin_search\">\n";
                serchBar += "                    <font class=\"admin_search_a\">\n";
                serchBar += "                        <label>" + qSerch[0].Name + "</label>\n";
                serchBar += "                        <img src=\"/images/admin/admin_arrow.gif\" />\n";
                serchBar += "                     </font>\n";
                serchBar += "                     <font class=\"admin_input\">\n";
                serchBar += "                            <input name=\"" + qSerch[0].Key + "_Serch\" type=\"hidden\" id=\"s_order\" value=\"" + ct(qSerch[0].Where) + "\" />\n";
                serchBar += "                            <input style=\"width: 75px; height: 16px; border: 0;\" name=\"for_" + qSerch[0].Key + "\" type=\"text\" id=\"q_serch\"  />\n";
                serchBar += "                        </font>\n";
                serchBar += "                    <input type=\"submit\" class=\"admin_btn\" value=\"\" />\n";
                serchBar += "                </p>";
                serchBar += "                </form>";
                if (qSerch.Count > 1)
                {
                    sb.Append("                <div id=\"q_Item\" class=\"admin_list_div\">\n");
                    sb.Append("                    <ul>\n");
                    foreach (SerchItem si in qSerch)
                    {
                        sb.Append("                          <li s=\"" + si.Key + "\" w=\"" + ct(si.Where) + "\">" + si.Name + "</li>\n");
                    }
                    sb.Append("                    </ul>\n");
                    sb.Append("                </div>\n");
                }
                item = sb.ToString();
                return serchBar;
            }
            return "";
        }

        internal class SerchItem
        {
            private string key = string.Empty;

            internal string Key
            {
                get { return key; }
                set { key = value; }
            }
            internal string name = string.Empty;

            internal string Name
            {
                get { return name; }
                set { name = value; }
            }
            private Where where;

            internal Where Where
            {
                get { return where; }
                set { where = value; }
            }

            internal SerchItem(string key, string name, Where where)
            {
                this.Key = key;
                this.Name = name;
                this.Where = where;
            }
        }

    }
}

