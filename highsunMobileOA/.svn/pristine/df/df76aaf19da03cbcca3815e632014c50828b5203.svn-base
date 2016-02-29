using System;
namespace WebSite.WebPage
{
    public class DataView
    {
        private string rowHeah = "";
        private string rowText = "";
        private string sql = "";

        public string GetView()
        {
            DataByPage datapage = new DataByPage();
            datapage.Sql = this.sql;
            datapage.GetRecordSetByPage();
            DataTable table = new DataTable();
            table.RowHead = this.rowHeah;
            table.RowText = this.rowText;
            table.DataReader = datapage.DataReader;
            string view = table.GetDataTable() + datapage.PageToolBar;
            datapage.Dispose();
            datapage = null;
            table = null;
            return view;
        }

        public string GetView(DataByPage datapage)
        {
            DataTable table = new DataTable();
            table.RowHead = this.rowHeah;
            table.RowText = this.rowText;
            table.DataReader = datapage.DataReader;
            string view = table.GetDataTable() + datapage.PageToolBar;
            datapage.Dispose();
            datapage = null;
            table = null;
            return view;
        }

        public string RowHead
        {
            get
            {
                return this.rowHeah;
            }
            set
            {
                this.rowHeah = value;
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

