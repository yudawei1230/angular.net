using WebSite.Comman;
using System;
using System.Data.SqlClient;

namespace WebSite.WebPage
{


    public class DataTable
    {
        private SqlDataReader dataReader = null;
        private string rowHead = "";
        private string rowText = "";
        private string toolbar = "";

        public string GetDataTable()
        {
            string pageHtml;
            Table table = new Table();
            try
            {
                int curpage = SRequest.GetInt("pageindex", 0);
                if (curpage < 0)
                {
                    curpage = 1;
                }
                table.AddHead(this.rowHead);
                string[] rowcol = this.rowText.Split(new char[] { ',' });
                int count = 0;
                if (this.DataReader != null)
                {
                    while (this.DataReader.Read())
                    {
                        count++;
                        for (int i = 0; i < rowcol.Length; i++)
                        {
                            if (rowcol[i].IndexOf('$') >= 0)
                            {
                                string format = rowcol[i].Split(new char[] { '$' })[0];
                                string[] key = rowcol[i].Split(new char[] { '$' })[1].Split(new char[] { '|' });
                                string[] value = new string[key.Length];
                                for (int m = 0; m < key.Length; m++)
                                {
                                    if (key[m].Equals("@num"))
                                    {
                                        value[m] = count.ToString();
                                    }
                                    else if (key[m].Equals("@allnum"))
                                    {
                                        value[m] = ((15 * (curpage - 1)) + count).ToString();
                                    }
                                    else if (key[m].IndexOf("@sub") >= 0)
                                    {
                                        string[] sub = key[m].Split(new char[] { '#' });
                                        value[m] = this.dataReader[sub[1]].ToString().Substring(int.Parse(sub[2])) + "";
                                    }
                                    else
                                    {
                                        value[m] = this.dataReader[key[m]].ToString();
                                    }
                                }
                                table.AddCol(format, value);
                            }
                            else
                            {
                                table.AddCol(this.dataReader[rowcol[i]].ToString());
                            }
                        }
                        table.AddRow();
                    }
                }
                pageHtml = table.GetTable();
            }
            catch (Exception ex)
            {
                pageHtml = ex.ToString();
            }
            finally
            {
                table = null;
            }
            return pageHtml;
        }

        public SqlDataReader DataReader
        {
            get
            {
                return this.dataReader;
            }
            set
            {
                this.dataReader = value;
            }
        }

        public string RowHead
        {
            get
            {
                return this.rowHead;
            }
            set
            {
                this.rowHead = value;
            }
        }

        public string RowText
        {
            get
            {
                return this.rowText;
            }
            set
            {
                this.rowText = value;
            }
        }

        public string Toolbar
        {
            get
            {
                return this.toolbar;
            }
            set
            {
                this.toolbar = value;
            }
        }
    }
}

