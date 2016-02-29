using WebSite.Comman;
using WebSite.WebPage;
using System;
using System.Collections;
using System.Data.SqlClient;
using System.Text;
using WebSite.DbProxy;


namespace WebSite.WebPage
{


    public class DataByPage
    {
        private string order;
        private string orderby = "";
        private string orderDesc;
        private int pageCount = 0;
        private int pageIndex = 0;
        
        private string pageToolBar = "";
        private Hashtable para;
        private string query;
        private string receptionToolBar = "";
        private int recordCount = 0;
        private SqlDataReader recordSet;
        private string sql;
        private string table;
        private string where;

        private void DescOrder()
        {
            this.orderDesc = this.order.Replace("desc", "as_1dec");
            this.orderDesc = this.orderDesc.Replace("asc", "desc");
            this.orderDesc = this.orderDesc.Replace("as_1dec", "asc");
        }

        public void Dispose()
        {
            if (this.recordSet != null)
            {
                this.recordSet.Close();
                this.recordSet.Dispose();
                this.recordSet = null;
            }
            this.pageToolBar = null;
            this.sql = null;
            this.query = null;
            this.table = null;
            this.where = null;
            this.order = null;
            this.orderDesc = null;
            GC.Collect();
        }

        private void GetCount()
        {
            try
            {
                Database db = new Database( "select count(*) from " + this.table + " where  " + this.where, null);
                SqlDataReader rd = db.ExecuteReader();
                string strCount = string.Empty;
                if (rd.Read())
                {
                    strCount = rd[0].ToString();
                }

                if (Validator.IsNumber(strCount))
                {
                    this.recordCount = int.Parse(strCount);
                }
                else
                {
                    this.recordCount = 0;
                }
            }
            catch
            {
                this.recordCount = 0;
            }
        }

        private void GetPageCount()
        {
            this.pageCount = ((this.recordCount + this.PageSize) - 1) / this.PageSize;
            if (this.pageIndex < 1)
            {
                this.pageIndex = 1;
            }
            if (this.pageIndex > this.pageCount)
            {
                this.pageIndex = this.pageCount;
            }
        }

        private void GetPara()
        {
            if (this.pageIndex < 1)
            {
                this.pageIndex = SRequest.GetInt("pageindex", 0);
            }
            if (this.pageIndex < 1)
            {
                this.pageIndex = 1;
            }
            this.para = SRequest.GetPara();
        }

        public void GetRecordFreelabelByPage()
        {
            this.GetPara();
            this.SplitSqlFreelabel();
            this.DescOrder();
            this.GetCount();
            this.GetPageCount();
            this.GetToolBar();
            this.ReceptionGetToolBar();
            this.GetRecordSet();
        }

        private void GetRecordSet()
        {
            this.sql = "";
            if (this.recordCount > 0)
            {
                if ((this.pageCount <= 1) || (this.pageIndex <= 1))
                {
                    this.sql = string.Concat(new object[] { "select top ", this.PageSize, " ", this.query, " from ", this.table, " where ", this.where, " order by ", this.order });
                }
                else if (this.pageCount.Equals(this.pageIndex))
                {
                    this.sql = string.Concat(new object[] { "select top ", this.recordCount - (this.PageSize * (this.pageIndex - 1)), " ", this.query, " from ", this.table, " where ", this.where, " order by ", this.orderDesc });
                    this.sql = " select * from (" + this.sql + ")temptable order by " + this.order;
                }
                else
                {
                    this.sql = string.Concat(new object[] { "select top ", this.PageSize * this.pageIndex, " ", this.query, " from ", this.table, " where ", this.where, " order by ", this.order });
                    if (this.pageIndex > 1)
                    {
                        this.sql = string.Concat(new object[] { "select top ", this.PageSize, " * from (", this.sql, ") temptable order by ", this.orderDesc });
                        this.sql = " select * from (" + this.sql + ")temptable order by " + this.order;
                    }
                }
                Database db = new Database(this.sql, null);
                this.recordSet = db.ExecuteReader();
            }
        }

        public void GetRecordSetByPage()
        {
            this.GetPara();
            this.SplitSql();
            this.DescOrder();
            this.GetCount();
            this.GetPageCount();
            this.GetToolBar();
            this.ReceptionGetToolBar();
            this.GetRecordSet();
        }

        /// <summary>
        /// 分页控件
        /// </summary>
        private void GetToolBar()
        {
            if (this.pageCount > 0)
            {
                StringBuilder tool = new StringBuilder();
                string parastring = "";
                if (this.para.Count > 0)
                {
                    foreach (DictionaryEntry de in this.para)
                    {
                        parastring = string.Concat(new object[] { parastring, "&", de.Key, "=", de.Value });
                    }
                }
                tool.AppendLine("   <div class=\"page\"><div>");
                if (this.pageIndex <= 1)
                {
                    //tool.AppendLine("   <span class=\"disabled\"><<</span>");
                    tool.AppendLine("   <span><a href=\"javascript:void(0)\">上一页</a></span>");
                }
                else
                {
                    //tool.AppendLine("   <a href=?pageindex=1" + parastring + "><<</a>");
                    tool.AppendLine(string.Concat(new object[] { "   <span><a href=?pageindex=", this.pageIndex - 1, parastring, ">上一页</a></span>" }));
                }
                for (int i = ((this.pageIndex - 4) > 0) ? (this.pageIndex - 4) : 1; i <= (((this.pageIndex + 4) < this.pageCount) ? (this.pageIndex + 4) : this.pageCount); i++)
                {
                    if (i == this.pageIndex)
                    {
                        tool.AppendLine("<a herf=\"#\" class=\"current\">" + i + "</a>");
                    }
                    else
                    {
                        tool.AppendLine(string.Concat(new object[] { "<a href=\"?pageindex=", i, parastring, "\">", i, "</a>" }));
                    }
                }
                if ((this.pageIndex + 5) < this.pageCount)
                {
                    tool.AppendLine("...");
                    tool.AppendLine(string.Concat(new object[] { "<a href=\"?pageindex=", this.pageCount, parastring, "\">", this.pageCount, "</a>" }));
                }
                if (this.pageIndex >= this.pageCount)
                {
                    tool.AppendLine("   <span><a href=\"javascript:void(0)\">下一页</a></span> ");
                    //tool.AppendLine("   <span class=\"disabled\">>></span>");
                }
                else
                {
                    tool.AppendLine(string.Concat(new object[] { "   <span><a href=?pageindex=", this.pageIndex + 1, parastring, ">下一页</a></span>" }));
                    //tool.AppendLine(string.Concat(new object[] { "   <a href=?pageindex=", this.pageCount, parastring, ">>></a>" }));
                }
                //this.pageToolBar = "\n<div class=\"quotes\">\n" + tool.ToString() + "</div>\n";
                tool.AppendLine(string.Concat(new object[] { "<font>共 ", this.recordCount, " 条</font>" }));
                tool.AppendLine("</div>\n</div>\n");
                this.PageToolBar = tool.ToString();
            }
        }

        private string GetWhere()
        {
            StringBuilder sqlWhere = new StringBuilder();
            int postion = 0;
            string key = "";
            string value = "";

            foreach (DictionaryEntry de in this.para)
            {
                key = de.Key.ToString();
                value = Utils.Filter(de.Value.ToString());
                if (key.Contains("for_"))
                {
                    continue;
                }

                if (key.Contains("_Serch"))
                {
                    string tName = key.Replace("_Serch", "");
                    key = value + tName;
                    value = para["for_" + tName].ToString();
                }

                postion = key.ToString().IndexOf("w_q_");
                if (postion >= 0 && !value.Equals("_[null]") && !value.Equals(""))
                {
                    sqlWhere.Append(" and " + key.Substring(postion + 4) + ">'" + value + "'");
                }

                postion = key.ToString().IndexOf("w_a_");
                if (postion >= 0 && !value.Equals("_[null]") && !value.Equals(""))
                {
                    sqlWhere.Append(" and " + key.Substring(postion + 4) + "<'" + value + "'");
                }

                postion = key.ToString().IndexOf("w_g_");
                if (postion >= 0 && !value.Equals("_[null]") && !value.Equals(""))
                {
                    sqlWhere.Append(" and " + key.Substring(postion + 4) + ">='" + value + "'");
                }

                postion = key.ToString().IndexOf("w_e_");
                if (postion >= 0 && !value.Equals("_[null]") && !value.Equals(""))
                {
                    sqlWhere.Append(" and " + key.Substring(postion + 4) + "<='" + value + "'");
                    continue;
                }
                postion = key.ToString().IndexOf("w_d_");
                if (postion >= 0 && !value.Equals("_[null]") && !value.Equals(""))
                {
                    sqlWhere.Append(" and " + key.Substring(postion + 4) + "='" + value + "'");
                    continue;
                }
                postion = key.ToString().IndexOf("w_n_");
                if (postion >= 0 && !value.Equals("_[null]") && !value.Equals(""))
                {
                    sqlWhere.Append(" and " + key.Substring(postion + 4) + "<>'" + value + "'");
                    continue;
                }
                postion = key.ToString().IndexOf("w_l_");
                if (postion >= 0 && !value.Equals("_[null]") && !value.Equals(""))
                {
                    sqlWhere.Append(" and " + key.Substring(postion + 4) + " like '%" + value + "%'");
                    continue;
                }
                postion = key.ToString().IndexOf("w_z_");
                if (postion >= 0 && !value.Equals("_[null]") && !value.Equals(""))
                {
                    sqlWhere.Append(" and " + key.Substring(postion + 4) + " like '" + value + "%'");
                    continue;
                }
                postion = key.ToString().IndexOf("w_r_");
                if (postion >= 0 && !value.Equals("_[null]") && !value.Equals(""))
                {
                    sqlWhere.Append(" and " + key.Substring(postion + 4) + " like '%" + value + "'");
                    continue;
                }
                postion = key.ToString().IndexOf("w_s_");
                if (postion >= 0 && !value.Equals("_[null]") && !value.Equals(""))
                {
                    sqlWhere.Append(" and Substring(" + key.Substring(postion + 4) + "," + value + ",1)=1");
                    continue;
                }
            }
            return sqlWhere.ToString();
        }

       
        private void ReceptionGetToolBar()
        {
            StringBuilder tool = new StringBuilder();
            string parastring = "";
            if (this.para.Count > 0)
            {
                foreach (DictionaryEntry de in this.para)
                {
                    parastring = string.Concat(new object[] { parastring, "&", de.Key, "=", de.Value });
                }
            }
            tool.AppendLine(string.Concat(new object[] { "共找到 ", this.recordCount, " 条记录    分 ", this.pageCount, " 页显示" }));
            if (this.pageIndex <= 1)
            {
                tool.AppendLine("   <span class=\"disabled\">首页</span>");
                tool.AppendLine("   <span class=\"disabled\">上一页</span>");
            }
            else
            {
                tool.AppendLine("   <a href=?pageindex=1" + parastring + ">首页</a>");
                tool.AppendLine(string.Concat(new object[] { "   <a href=?pageindex=", this.pageIndex - 1, parastring, ">上一页</a>" }));
            }
            for (int i = ((this.pageIndex - 4) > 0) ? (this.pageIndex - 4) : 1; i <= (((this.pageIndex + 4) < this.pageCount) ? (this.pageIndex + 4) : this.pageCount); i++)
            {
                if (i == this.pageIndex)
                {
                    tool.AppendLine("<span class=\"current\">" + i + "</span>");
                }
                else
                {
                    tool.AppendLine(string.Concat(new object[] { "<a href=\"?pageindex=", i, parastring, "\">", i, "</a>" }));
                }
            }
            if ((this.pageIndex + 5) < this.pageCount)
            {
                tool.AppendLine("...");
                tool.AppendLine(string.Concat(new object[] { "<a href=\"?pageindex=", this.pageCount, parastring, "\">", this.pageCount, "</a>" }));
            }
            if (this.pageIndex >= this.pageCount)
            {
                tool.AppendLine("   <span class=\"disabled\">下一页</span>");
                tool.AppendLine("   <span class=\"disabled\">尾页</span>");
            }
            else
            {
                tool.AppendLine(string.Concat(new object[] { "   <a href=?pageindex=", this.pageIndex + 1, parastring, ">下一页</a>" }));
                tool.AppendLine(string.Concat(new object[] { "   <a href=?pageindex=", this.pageCount, parastring, ">尾页</a>" }));
            }
            this.receptionToolBar = "\n<ul class=\"quotes\">\n" + tool.ToString() + "</ul>\n";
        }

        private void SplitSql()
        {
            if (!this.sql.Equals(""))
            {
                this.sql = this.sql.Replace("[select]", "");
                this.sql = this.sql.Replace("[from]", "|");
                this.sql = this.sql.Replace("[where]", "|");
                this.sql = this.sql.Replace("[order by]", "|");
                string[] sqlArr = this.sql.Split(new char[] { '|' });
                this.query = sqlArr[0];
                this.table = sqlArr[1];
                this.where = sqlArr[2];
                this.where = sqlArr[2] + this.GetWhere();
                if (this.orderby.Equals(""))
                {
                    this.order = sqlArr[3];
                }
                else
                {
                    this.order = this.orderby;
                }
            }
        }

        private void SplitSqlFreelabel()
        {
            if (!this.sql.Equals(""))
            {
                this.sql = this.sql.Replace("select", "");
                this.sql = this.sql.Replace("from", "|");
                this.sql = this.sql.Replace("where", "|");
                this.sql = this.sql.Replace("order by", "|");
                string[] sqlArr = this.sql.Split(new char[] { '|' });
                this.query = sqlArr[0];
                this.table = sqlArr[1];
                this.where = sqlArr[2] + this.GetWhere();
                if (this.orderby.Equals(""))
                {
                    this.order = sqlArr[3];
                }
                else
                {
                    this.order = this.orderby;
                }
            }
        }

        public SqlDataReader DataReader
        {
            get
            {
                return this.recordSet;
            }
        }

        public string OrderBy
        {
            get
            {
                return this.orderby;
            }
            set
            {
                this.orderby = value;
            }
        }

        public int PageCount
        {
            get
            {
                return this.pageCount;
            }
            set
            {
                this.pageCount = value;
            }
        }

        public int PageIndex
        {
            get
            {
                return this.pageIndex;
            }
            set
            {
                this.pageIndex = value;
            }
        }

        public int PageSize { get; set; }

        public string PageToolBar
        {
            get
            {
                return this.pageToolBar;
            }
            set
            {
                this.pageToolBar = value;
            }
        }

        public string ReceptionToolBar
        {
            get
            {
                return this.receptionToolBar;
            }
            set
            {
                this.receptionToolBar = value;
            }
        }

        public string Sql
        {
            get
            {
                return this.sql;
            }
            set
            {
                this.sql = value;
            }
        }


    }
}

