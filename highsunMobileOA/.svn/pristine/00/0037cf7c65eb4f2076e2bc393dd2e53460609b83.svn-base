using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;


namespace WebSite.Comman
{
    /// <summary>
    /// 用于绑定列表控件（无限极）
    /// </summary>
    public class HtmlddllBind
    {
        /// <summary>
        /// 父级分栏样式
        /// </summary>
        private string topParentStyle = "　";

        public string TopParentStyle
        {
            get { return topParentStyle; }
            set { topParentStyle = value; }
        }


        /// <summary>
        /// 子项分栏样式
        /// </summary>
        private string subkey = "　　∟";

        public string Subkey
        {
            get { return subkey; }
            set { subkey = value; }
        }

        /// <summary>
        /// 顶级ID
        /// </summary>
        private int topParentID;

        public int TopParentID
        {
            get { return topParentID; }
            set { topParentID = value; }
        }


        /// <summary>
        /// ID列名
        /// </summary>
        private string idColumnsName;

        public string IdColumnsName
        {
            get { return idColumnsName; }
            set { idColumnsName = value; }
        }

        /// <summary>
        /// 类型列名
        /// </summary>
        private string typeColumnsName;

        public string TypeColumnsName
        {
            get { return typeColumnsName; }
            set { typeColumnsName = value; }
        }


        /// <summary>
        /// 父级列名
        /// </summary>
        private string parentIDColumnsName;

        public string ParentIDColumnsName
        {
            get { return parentIDColumnsName; }
            set { parentIDColumnsName = value; }
        }


        /// <summary>
        /// 最顶级标识
        /// </summary>
        private string topTitle;

        public string TopTitle
        {
            get { return topTitle; }
            set { topTitle = value; }
        }

        /// <summary>
        /// 默认选择项目
        /// </summary>
        private string selValue;

        public string SelValue
        {
            get { return selValue; }
            set { selValue = value; }
        }


        /// <summary>
        /// 默认构造函数
        /// </summary>
        public HtmlddllBind()
        {


        }



        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="topParentID">顶级ID</param>
        /// <param name="idColumnsName">ID列名</param>
        /// <param name="typeColumnsName">类型列名</param>
        /// <param name="parentIDColumnsName">父级列名</param>
        /// <param name="topTitle">最顶级标识</param>
        public HtmlddllBind(int topParentID, string idColumnsName, string typeColumnsName, string parentIDColumnsName)
        {
            this.topParentID = topParentID;
            this.idColumnsName = idColumnsName;
            this.typeColumnsName = typeColumnsName;
            this.parentIDColumnsName = parentIDColumnsName;
        }

        /// <summary>
        /// 绑定无限级类别到下拉框
        /// </summary>
        /// <param name="source">DataTable数据源</param>
        /// <param name="topParentID">顶级ID</param>
        /// <param name="idColumnsName">一级类的ID，用于下拉框的值</param>
        /// <param name="typeColumnsName">类型名字，用于下拉框的键</param>
        /// <param name="parentIDColumnsName">与ID关联的类型列名</param>    
        /// <returns>返回option递归项</returns>
        public string OptionCreate(DataTable source, int topParentID, string idColumnsName, string typeColumnsName, string parentIDColumnsName)
        {
            this.topParentID = topParentID;
            this.idColumnsName = idColumnsName;
            this.typeColumnsName = typeColumnsName;
            this.parentIDColumnsName = parentIDColumnsName;
            return BindDrpClass(source);
        }

        /// <summary>
        /// 绑定无限级类别到下拉框
        /// </summary>
        /// <param name="source">DataTable数据源</param>
        /// <param name="topParentID">顶级ID</param>
        /// <param name="idColumnsName">一级类的ID，用于下拉框的值</param>
        /// <param name="typeColumnsName">类型名字，用于下拉框的键</param>
        /// <param name="parentIDColumnsName">与ID关联的类型列名</param>
        /// <param name="selValue">>默认选择的下级ID</param>
        /// <param name="topTitle">最顶级文字描述</param>
        /// <returns>返回option递归项</returns>
        public string OptionCreate(DataTable source, int topParentID, string idColumnsName, string typeColumnsName, string parentIDColumnsName, string selValue, string topTitle)
        {
            this.topParentID = topParentID;
            this.idColumnsName = idColumnsName;
            this.typeColumnsName = typeColumnsName;
            this.parentIDColumnsName = parentIDColumnsName;
            this.selValue = selValue;
            this.topTitle = topTitle;
            return BindDrpClass(source);
        }
        /// <summary>
        /// 绑定无限级类别到下拉框
        /// </summary>
        /// <param name="source">DataTable数据源</param>
        /// <param name="topParentID">顶级ID</param>
        /// <param name="idColumnsName">一级类的ID，用于下拉框的值</param>
        /// <param name="typeColumnsName">类型名字，用于下拉框的键</param>
        /// <param name="parentIDColumnsName">与ID关联的类型列名</param>
        /// <param name="selValue">>默认选择的下级ID</param>
        /// <param name="topTitle">最顶级文字描述</param>
        /// <returns>返回option递归项</returns>
        public string OptionCreate(DataTable source, string idColumnsName, string typeColumnsName, string topTitle)
        {
            StringBuilder options = new StringBuilder();
            if (source != null & source.Rows.Count > 0)
            {
                
                options.Append("<option value=\"_[null]\" >" + topTitle + "</option>");
              
                foreach (DataRow dr in source.Rows)
                {
                    //获取ID
                    string id = dr[idColumnsName].ToString();
                    //获取类型名称
                    string typeName = dr[typeColumnsName].ToString();
                    //顶级分类显示形式
                    //typeName = topParentStyle + typeName;

                    options.Append("<option value=\"" + id + "\">" + typeName + "</option>\r\n");

                   
                }
            }
            return options.ToString();
        }
        /// <summary>
        /// 绑定顶级分栏
        /// </summary>        
        private string BindDrpClass(DataTable source)
        {
            StringBuilder options = new StringBuilder();
            if (source != null & source.Rows.Count > 0)
            {
                DataRow[] drs;

                if (topParentID == 0)
                {
                    drs = source.Select(string.Format("{0} = 0", parentIDColumnsName.Trim(), topParentID));
                }
                else
                {
                    drs = source.Select(string.Format("{0}= {1}", parentIDColumnsName.Trim(), topParentID));
                }

                options.Append("<option value=\"_[null]\" >" + topTitle + "</option>");
                foreach (DataRow dr in drs)
                {
                    //获取ID
                    string id = dr[idColumnsName].ToString();
                    //获取类型名称
                    string typeName = dr[typeColumnsName].ToString();
                    //顶级分类显示形式
                    typeName = topParentStyle + typeName;

                    options.Append("<option value=\"" + id + "\">" + typeName + "</option>\r\n");

                    int nowID = -1;
                    int.TryParse(id, out nowID);
                    if (nowID > 0)
                    {
                        BindNode(options, source, nowID, subkey);
                    }
                }
            }
            return options.ToString();
        }

        /// <summary>
        /// 绑定子分类
        /// </summary>
        private void BindNode(StringBuilder options, DataTable source, int topParentID, string blank)
        {
            DataRow[] drs = source.Select(string.Format("{0}= {1}", parentIDColumnsName.Trim(), topParentID));
            foreach (DataRow dr in drs)
            {
                //获取ID
                string id = dr[idColumnsName].ToString();
                //获取类型名称
                string typeName = dr[typeColumnsName].ToString();
                typeName = blank + typeName;
                //顶级分类显示形式
                if (!string.IsNullOrEmpty(selValue) && selValue == id)
                {
                    options.Append("<option value=\"" + id + "\" selected=\"selected\" >" + typeName + "</option>\r\n");
                }
                else
                {
                    options.Append("<option value=\"" + id + "\">" + typeName + "</option>\r\n");
                }
                int nowID = -1;
                int.TryParse(id, out nowID);

                string nextBlank = "　" + blank;
                if (nowID > 0)
                {
                    BindNode(options, source, nowID, nextBlank);
                }
            }
        }
    }
}
