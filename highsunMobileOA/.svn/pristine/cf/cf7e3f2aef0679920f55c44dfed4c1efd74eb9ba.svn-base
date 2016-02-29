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
    public class DropDownListBind
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
        /// 默认构造函数
        /// </summary>
        public DropDownListBind()
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
        public DropDownListBind(int topParentID, string idColumnsName, string typeColumnsName, string parentIDColumnsName, string topTitle)
        {
            this.topParentID = topParentID;
            this.idColumnsName = idColumnsName;
            this.typeColumnsName = typeColumnsName;
            this.parentIDColumnsName = parentIDColumnsName;
            this.topTitle = topTitle;
        }

        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="e">列表控件对象</param>
        /// <param name="source">数据源</param>
        /// <param name="topParentID">顶级ID</param>
        /// <param name="idColumnsName">ID列名</param>
        /// <param name="typeColumnsName">类型列名</param>
        /// <param name="parentIDColumnsName">父级列名</param>
        /// <param name="topTitle">最顶级标识</param>
        public DropDownListBind(DropDownList e, DataTable source, int topParentID, string idColumnsName, string typeColumnsName, string parentIDColumnsName, string topTitle)
        {
            this.topParentID = topParentID;
            this.idColumnsName = idColumnsName;
            this.typeColumnsName = typeColumnsName;
            this.parentIDColumnsName = parentIDColumnsName;
            this.topTitle = topTitle;
            BindDrpClass(e, source);
        }
        public DropDownListBind(DropDownList e, DataTable source, string idColumnsName, string typeColumnsName, string topTitle)
        {
            this.idColumnsName = idColumnsName;
            this.typeColumnsName = typeColumnsName;
            this.topTitle = topTitle;
            BindDrpPro(e, source);
        }

        /// <summary>
        /// 绑定顶级分栏
        /// </summary>
        /// <param name="e">列表控件对象</param>
        /// <param name="source">数据源</param>
        public void BindDrpClass(DropDownList e, DataTable source)
        {

            if (source != null & source.Rows.Count > 0)
            {

                //清除所有类型数据
                e.Items.Clear();

                //添加父等级信息
                e.Items.Add(new ListItem(topTitle, "0"));
                //获取父等级数据


                DataRow[] drs;

                if (topParentID == 0)
                {
                    if (source.Columns.Contains("Sort"))
                        drs = source.Select(string.Format("{0} = 0", parentIDColumnsName.Trim(), topParentID), "[Sort]");
                    else
                        drs = source.Select(string.Format("{0} = 0", parentIDColumnsName.Trim(), topParentID));
                }
                else
                {
                    if (source.Columns.Contains("Sort"))
                        drs = source.Select(string.Format("{0}= {1}", parentIDColumnsName.Trim(), topParentID), "[Sort]");
                    else
                        drs = source.Select(string.Format("{0}= {1}", parentIDColumnsName.Trim(), topParentID));
                }

                foreach (DataRow dr in drs)
                {
                    //获取ID
                    string id = dr[idColumnsName].ToString();
                    //获取类型名称
                    string typeName = dr[typeColumnsName].ToString();
                    //顶级分类显示形式
                    typeName = topParentStyle + typeName;
                    e.Items.Add(new ListItem(typeName, id));

                    int nowID = -1;
                    int.TryParse(id, out nowID);
                    if (nowID > 0)
                    {
                        BindNode(e, source, nowID, subkey);
                    }
                }
                e.DataBind();
            }
        }


        /// <summary>
        /// 绑定顶级分栏
        /// </summary>
        /// <param name="e">列表控件对象</param>
        /// <param name="source">数据源</param>
        public void BindDrpPro(DropDownList e, DataTable source)
        {

            if (source != null & source.Rows.Count > 0)
            {

                //清除所有类型数据
                e.Items.Clear();

                //添加父等级信息
                e.Items.Add(new ListItem(topTitle, "0"));
                //获取父等级数据


                DataRow[] drs = source.Select();
                foreach (DataRow dr in drs)
                {
                    //获取ID
                    string id = dr[idColumnsName].ToString();
                    //获取类型名称
                    string typeName = dr[typeColumnsName].ToString();
                    //顶级分类显示形式
                    typeName = topParentStyle + typeName;
                    e.Items.Add(new ListItem(typeName, id));
                    int nowID = -1;
                    int.TryParse(id, out nowID); 
                }
                e.DataBind();
            }
        }


        /// <summary>
        /// 绑定子分类
        /// </summary>
        /// <param name="e">列表控件对象</param>
        /// <param name="source">数据源</param>
        /// <param name="topParentID">父等ID</param>
        /// <param name="idColumnsName">ID列名</param>
        /// <param name="typeColumnsName">类型名称</param>
        /// <param name="parentIDColumnsName">父级名称</param>
        private void BindNode(DropDownList e, DataTable source, int topParentID, string blank)
        {

            DataRow[] drs = null;

            if (source.Columns.Contains("Sort"))
                drs = source.Select(string.Format("{0}= {1}", parentIDColumnsName.Trim(), topParentID), "[Sort]");
            else
                drs = source.Select(string.Format("{0}= {1}", parentIDColumnsName.Trim(), topParentID));
            foreach (DataRow dr in drs)
            {
                //获取ID
                string id = dr[idColumnsName].ToString();
                //获取类型名称
                string typeName = dr[typeColumnsName].ToString();
                //顶级分类显示形式
                typeName = blank + typeName;
                e.Items.Add(new ListItem(typeName, id));

                // 设置下一个样式
                string nextBlank = "　" + blank;

                int nowID = -1;
                int.TryParse(id, out nowID);
                if (nowID > 0)
                {
                    BindNode(e, source, nowID, nextBlank);
                }
            }

        }



    }
}
