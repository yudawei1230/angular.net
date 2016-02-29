using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WebSite.Comman;
using WebSite.WebPage;
namespace WebSite.BLL
{
    public class MemberPage : IRecycle
    {
        /// <summary>
        /// 获得表格列表
        /// </summary>
        /// <param name="pages">返回分页</param>
        /// <param name="serchBar">返回快速搜索栏目</param>
        /// <param name="serchItem">返回快速搜索条件</param>
        /// <returns></returns>
        public string GetTableList(out string pages, out string serchBar, out string serchItem)
        {
            WebPage.Table table = new WebPage.Table();
            //判断URL参数w_d_IsDel是否为空，为空取未删除产品，不为空取回收站中产品
            WebPage.DataByPage dataPage = new WebSite.DAL.PublicHandler().PageFun("Member.*,(select Name from Market where ID = Member.MarketID) as MarketName", "Member", SRequest.GetString(table.ct(WebPage.Table.Where.Equal) + "Member.IsDel") != "" ? "" : " and Member.IsDel=0", 15);
            //添加快速搜索

            table.AddSerch("Name", "会员姓名", WebPage.Table.Where.Contains);          
            serchBar = table.GenQSerch(out serchItem);
            //第一步先添加表头
            table.AddHeadCol("20px", "<input type=\"checkbox\" id=\"selItem\" onclick=\"CkbSelectAll('selItem','selItem')\" />");
            table.AddHeadCol("", "所属商场");
            table.AddHeadCol("", "姓名");
            table.AddHeadCol("", "电话");
            table.AddHeadCol("", "操作");
            table.AddRow();
            //添加表的内容            
            int curpage = SRequest.GetInt("pageindex", 1);
            if (curpage < 0)
            {
                curpage = 1;
            }
            int count = 0;
            table.AddTag("<Tbody>");
            if (dataPage.DataReader != null)
            {
                while (dataPage.DataReader.Read())
                {
                    count++;
                    table.AddHeadCol("20px", "<input type=\"checkbox\"  name=\"selItem\" value=\"" + dataPage.DataReader["ID"].ToString() + "\" />");
                    table.AddCol(dataPage.DataReader["MarketName"].ToString());
                    table.AddCol(dataPage.DataReader["Name"].ToString());
                    table.AddCol(dataPage.DataReader["Phone"].ToString());
                    table.AddCol(string.Format("<a target=\"mainFrame\" href='/Admin/MemberManager.aspx?id=" + dataPage.DataReader["ID"].ToString() + "' >编辑</a>"));                
                    table.AddRow();
                }
            }
            table.AddTag("</Tbody>");
            string tlist = table.GetTable();
            pages = dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            return tlist;
        }

        
        /// <summary>
        /// 不可恢复性删除
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public int ClearItems(string idGroup)
        {
            return new DAL.PublicHandler().ClearFun("Member", idGroup);
        }
        /// <summary>
        /// 还原删除项目
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public int CancleItems(string idGroup)
        {
            return new DAL.PublicHandler().CancleFun("Member", idGroup);
        }
    }

    public class MarketPage : IRecycle
    {
        /// <summary>
        /// 获得表格列表
        /// </summary>
        /// <param name="pages">返回分页</param>
        /// <param name="serchBar">返回快速搜索栏目</param>
        /// <param name="serchItem">返回快速搜索条件</param>
        /// <returns></returns>
        public string GetTableList(out string pages, out string serchBar, out string serchItem)
        {
            WebPage.Table table = new WebPage.Table();
            //判断URL参数w_d_IsDel是否为空，为空取未删除产品，不为空取回收站中产品
            WebPage.DataByPage dataPage = new WebSite.DAL.PublicHandler().PageFun("Market.*", "Market", SRequest.GetString(table.ct(WebPage.Table.Where.Equal) + "Market.IsDel") != "" ? "" : " and Market.IsDel=0", 15);
            //添加快速搜索

            table.AddSerch("Name", "会员姓名", WebPage.Table.Where.Contains);
            serchBar = table.GenQSerch(out serchItem);
            //第一步先添加表头
            table.AddHeadCol("20px", "<input type=\"checkbox\" id=\"selItem\" onclick=\"CkbSelectAll('selItem','selItem')\" />");
            table.AddHeadCol("", "商场名称");
            table.AddHeadCol("", "所在地址");
            table.AddHeadCol("", "面积");
            table.AddHeadCol("", "排序");
            table.AddHeadCol("", "操作");
            table.AddRow();
            //添加表的内容            
            int curpage = SRequest.GetInt("pageindex", 1);
            if (curpage < 0)
            {
                curpage = 1;
            }
            int count = 0;
            table.AddTag("<Tbody>");
            if (dataPage.DataReader != null)
            {
                while (dataPage.DataReader.Read())
                {
                    count++;
                    table.AddHeadCol("20px", "<input type=\"checkbox\"  name=\"selItem\" value=\"" + dataPage.DataReader["ID"].ToString() + "\" />");
                    table.AddCol(dataPage.DataReader["Name"].ToString());
                    table.AddCol(dataPage.DataReader["Address"].ToString());
                    table.AddCol(dataPage.DataReader["Area"].ToString());
                    table.AddCol("<input class=\"txtsort\" sort=\"" + dataPage.DataReader["ID"].ToString() + "\" type=\"text\" style=\"width:30px;\" value=\"" + dataPage.DataReader["IsSort"].ToString() + "\" tab=\"Market\" />");
                    table.AddCol(string.Format("<a target=\"mainFrame\" href='/Admin/MarketManager.aspx?id=" + dataPage.DataReader["ID"].ToString() + "' >编辑</a>"));
                    table.AddRow();
                }
            }
            table.AddTag("</Tbody>");
            string tlist = table.GetTable();
            pages = dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            return tlist;
        }


        /// <summary>
        /// 不可恢复性删除
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public int ClearItems(string idGroup)
        {
            return new DAL.PublicHandler().ClearFun("Market", idGroup);
        }
        /// <summary>
        /// 还原删除项目
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public int CancleItems(string idGroup)
        {
            return new DAL.PublicHandler().CancleFun("Market", idGroup);
        }
    }

    public class IndustryPage
    {
        public string GetList(string where)
        {
           System.Data.DataTable source = new PublicHandler().IndustryDt();

            string idColumnsName = "ID";
            string typeColumnsName = "Name";
            string parentIDColumnsName = "ParentID";
            int topParentID = 0;

            Table table = new Table("typeTree");
            //添加表头
            table.AddCol("业态名称");
            table.AddCol("添加子类");
            table.AddCol("编辑");
            table.AddCol("删除");
            table.AddTbody();
            //添加表头结束
            if (source != null & source.Rows.Count > 0)
            {
                DataRow[] drs;

                if (source.Columns.Contains("IsSort"))
                    drs = source.Select(string.Format("{0}= {1}", parentIDColumnsName.Trim(), topParentID), "[IsSort]");
                else
                    drs = source.Select(string.Format("{0}= {1}", parentIDColumnsName.Trim(), topParentID));
                //创建一级类别

                table.AddTag("<Tbody>");
                foreach (DataRow dr in drs)
                {
                    //获取ID
                    string id = dr[idColumnsName].ToString();
                    //获取类型名称
                    string typeName = dr[typeColumnsName].ToString();

                    table.AddCol("text-indent:15px;text-align: left;", "", "<img src=\"../images/icon/ico01.gif\" width=\"14\" height=\"14\" />&nbsp;&nbsp;&nbsp;&nbsp;<b><a href=\"IndustryManager.aspx?EditID=" + id + "\" >" + typeName + "</a></b>");
                    table.AddCol("<a href=\"IndustryManager.aspx?AddId=" + id + "\" ><img src=\"../images/icon/class_add.gif\" width=\"15\" height=\"16\" /></a>");
                    table.AddCol("<a href=\"IndustryManager.aspx?EditID=" + id + "\" ><img src=\"../images/icon/edit.gif\"/></a>");
                    table.AddCol("<a href=\"#\" onclick=\"delCl(" + id + ")\" ><img src=\"../images/icon/del.gif\"/></a>");
                    table.AddRow();

                    int nowID = -1;
                    int.TryParse(id, out nowID);
                    if (nowID > 0)
                    {
                        BindNode(table, source, nowID, idColumnsName, typeColumnsName, parentIDColumnsName, 0);
                    }
                }
            }
            table.AddTag("</Tbody>");

            string view = table.GetTable();

            return view;
        }


        /// <summary>
        /// 绑定子分类
        /// </summary>
        /// <param name="e">列表控件对象</param>
        /// <param name="source">数据源</param>
        /// <param name="topParentID">顶级ID</param>
        /// <param name="idColumnsName">ID列名</param>
        /// <param name="typeColumnsName">类型列名</param>
        /// <param name="parentIDColumnsName">父级列名</param>
        /// <param name="topTitle">最顶级标识</param>
        private Table BindNode(Table e, System.Data.DataTable source, int topParentID, string idColumnsName, string typeColumnsName, string parentIDColumnsName, int padding)
        {
            DataRow[] drs = null;

            if (source.Columns.Contains("IsSort"))
                drs = source.Select(string.Format("{0}= {1}", parentIDColumnsName.Trim(), topParentID), "[IsSort]");
            else
                drs = source.Select(string.Format("{0}= {1}", parentIDColumnsName.Trim(), topParentID));

            padding += 10;
            foreach (DataRow dr in drs)
            {
                //获取ID
                string id = dr[idColumnsName].ToString();
                //获取类型名称
                string typeName = dr[typeColumnsName].ToString();
                //顶级分类显示形式
                e.AddCol("text-indent:30px;text-align: left;padding-left:" + padding + "px", "", "<img src=\"../images/icon/ico02.gif\" width=\"14\" height=\"14\" />&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"IndustryManager.aspx?EditID=" + id + "\" >" + typeName + "</a>");
                e.AddCol("<a href=\"IndustryManager.aspx?AddId=" + id + "\" ><img src=\"../images/icon/class_add.gif\" width=\"15\" height=\"16\" /></a>");
                e.AddCol("<a href=\"IndustryManager.aspx?EditID=" + id + "\" ><img src=\"../images/icon/edit.gif\"/></a>");
                e.AddCol("<a href=\"#\" onclick=\"delCl(" + id + ")\" ><img src=\"../images/icon/del.gif\"/></a>");
                e.AddRow();
                int nowID = -1;
                int.TryParse(id, out nowID);

                if (nowID > 0)
                {
                    BindNode(e, source, nowID, idColumnsName, typeColumnsName, parentIDColumnsName, padding);
                }
            }

            return e;
        }
    }

    public class IndexImgPage : IRecycle
    {
        /// <summary>
        /// 获得表格列表
        /// </summary>
        /// <param name="pages">返回分页</param>
        /// <param name="serchBar">返回快速搜索栏目</param>
        /// <param name="serchItem">返回快速搜索条件</param>
        /// <returns></returns>
        public string GetTableList(out string pages, out string serchBar, out string serchItem)
        {
            WebPage.Table table = new WebPage.Table();
            //判断URL参数w_d_IsDel是否为空，为空取未删除产品，不为空取回收站中产品
            WebPage.DataByPage dataPage = new WebSite.DAL.PublicHandler().PageFun("IndexImg.*", "IndexImg", SRequest.GetString(table.ct(WebPage.Table.Where.Equal) + "IndexImg.IsDel") != "" ? "" : " and IndexImg.IsDel=0",5);
            //添加快速搜索

            table.AddSerch("Link", "链接地址", WebPage.Table.Where.Contains);
            serchBar = table.GenQSerch(out serchItem);
            //第一步先添加表头
            table.AddHeadCol("20px", "<input type=\"checkbox\" id=\"selItem\" onclick=\"CkbSelectAll('selItem','selItem')\" />");
            table.AddHeadCol("", "图片");
            table.AddHeadCol("", "链接地址");
            table.AddHeadCol("", "排序");
            table.AddHeadCol("", "操作");
            table.AddRow();
            //添加表的内容            
            int curpage = SRequest.GetInt("pageindex", 1);
            if (curpage < 0)
            {
                curpage = 1;
            }
            int count = 0;
            table.AddTag("<Tbody>");
            if (dataPage.DataReader != null)
            {
                while (dataPage.DataReader.Read())
                {
                    count++;
                    table.AddHeadCol("20px", "<input type=\"checkbox\"  name=\"selItem\" value=\"" + dataPage.DataReader["ID"].ToString() + "\" />");
                    table.AddCol("<img src=\"/Upload/Thumbnails/" + dataPage.DataReader["Img"].ToString() + "\" height=\"50px\" />");
                    table.AddCol(dataPage.DataReader["Link"].ToString());
                    table.AddCol("<input class=\"txtsort\" sort=\"" + dataPage.DataReader["ID"].ToString() + "\" type=\"text\" style=\"width:30px;\" value=\"" + dataPage.DataReader["IsSort"].ToString() + "\" tab=\"IndexImg\" />");
                    table.AddCol(string.Format("<a target=\"mainFrame\" href='/Admin/IndexImgManager.aspx?id=" + dataPage.DataReader["ID"].ToString() + "' >编辑</a>"));
                    table.AddRow();
                }
            }
            table.AddTag("</Tbody>");
            string tlist = table.GetTable();
            pages = dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            return tlist;
        }


        /// <summary>
        /// 不可恢复性删除
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public int ClearItems(string idGroup)
        {
            return new DAL.PublicHandler().ClearFun("IndexImg", idGroup);
        }
        /// <summary>
        /// 还原删除项目
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public int CancleItems(string idGroup)
        {
            return new DAL.PublicHandler().CancleFun("IndexImg", idGroup);
        }
    }

    public class ShopPage : IRecycle
    {
        /// <summary>
        /// 获得表格列表
        /// </summary>
        /// <param name="pages">返回分页</param>
        /// <param name="serchBar">返回快速搜索栏目</param>
        /// <param name="serchItem">返回快速搜索条件</param>
        /// <returns></returns>
        public string GetTableList(out string pages, out string serchBar, out string serchItem)
        {
            WebPage.Table table = new WebPage.Table();
            //判断URL参数w_d_IsDel是否为空，为空取未删除产品，不为空取回收站中产品
            WebPage.DataByPage dataPage = new WebSite.DAL.PublicHandler().PageFun("Shop.*,(select Name from Market where ID=Shop.MarketID) as MarketName,(select Name from Industry where ID=Shop.IndustryID) as IndustryName", "Shop", SRequest.GetString(table.ct(WebPage.Table.Where.Equal) + "Shop.IsDel") != "" ? "" : " and Shop.IsDel=0", 15);
            //添加快速搜索

            table.AddSerch("Name", "商铺名称", WebPage.Table.Where.Contains);
            serchBar = table.GenQSerch(out serchItem);
            //第一步先添加表头
            table.AddHeadCol("20px", "<input type=\"checkbox\" id=\"selItem\" onclick=\"CkbSelectAll('selItem','selItem')\" />");
            table.AddHeadCol("", "所属商场");
            table.AddHeadCol("", "所属业态");
            table.AddHeadCol("", "商铺名称");
            table.AddHeadCol("", "更新时间");
            table.AddHeadCol("", "面积");
            table.AddHeadCol("", "租金");
            table.AddHeadCol("", "铺号");
            table.AddHeadCol("", "楼层");
            table.AddHeadCol("", "实用率");
            //table.AddHeadCol("", "排序");
            table.AddHeadCol("", "操作");
            table.AddRow();
            //添加表的内容            
            int curpage = SRequest.GetInt("pageindex", 1);
            if (curpage < 0)
            {
                curpage = 1;
            }
            int count = 0;
            table.AddTag("<Tbody>");
            if (dataPage.DataReader != null)
            {
                while (dataPage.DataReader.Read())
                {
                    count++;
                    table.AddHeadCol("20px", "<input type=\"checkbox\"  name=\"selItem\" value=\"" + dataPage.DataReader["ID"].ToString() + "\" />");
                    table.AddCol(dataPage.DataReader["MarketName"].ToString());
                    table.AddCol(dataPage.DataReader["IndustryName"].ToString());
                    table.AddCol(dataPage.DataReader["Name"].ToString());
                    table.AddCol(Convert.ToDateTime(dataPage.DataReader["AddDate"]).ToString("yyyy-MM-dd HH:mm"));
                    table.AddCol(dataPage.DataReader["Area"].ToString());
                    table.AddCol(dataPage.DataReader["Rent"].ToString());
                    table.AddCol(dataPage.DataReader["ShopNo"].ToString());
                    table.AddCol(dataPage.DataReader["Floor"].ToString());
                    table.AddCol(dataPage.DataReader["UtilityRate"].ToString());
                    //table.AddCol("<input class=\"txtsort\" sort=\"" + dataPage.DataReader["ID"].ToString() + "\" type=\"text\" style=\"width:30px;\" value=\"" + dataPage.DataReader["IsSort"].ToString() + "\" tab=\"Shop\" />");
                    table.AddCol(string.Format("<a target=\"mainFrame\" href='/Admin/ShopManager.aspx?id=" + dataPage.DataReader["ID"].ToString() + "' >编辑</a>"));
                    table.AddRow();
                }
            }
            table.AddTag("</Tbody>");
            string tlist = table.GetTable();
            pages = dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            return tlist;
        }


        /// <summary>
        /// 不可恢复性删除
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public int ClearItems(string idGroup)
        {
            return new DAL.PublicHandler().ClearFun("Shop", idGroup);
        }
        /// <summary>
        /// 还原删除项目
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public int CancleItems(string idGroup)
        {
            return new DAL.PublicHandler().CancleFun("Shop", idGroup);
        }
    }

    public class MediaSourcePage : IRecycle
    {
        /// <summary>
        /// 获得表格列表
        /// </summary>
        /// <param name="pages">返回分页</param>
        /// <param name="serchBar">返回快速搜索栏目</param>
        /// <param name="serchItem">返回快速搜索条件</param>
        /// <returns></returns>
        public string GetTableList(out string pages, out string serchBar, out string serchItem)
        {
            WebPage.Table table = new WebPage.Table();
            //判断URL参数w_d_IsDel是否为空，为空取未删除产品，不为空取回收站中产品
            WebPage.DataByPage dataPage = new WebSite.DAL.PublicHandler().PageFun("MediaSource.*", "MediaSource", SRequest.GetString(table.ct(WebPage.Table.Where.Equal) + "MediaSource.IsDel") != "" ? "" : " and MediaSource.IsDel=0", 15);
            //添加快速搜索

            table.AddSerch("Name", "发布形式", WebPage.Table.Where.Contains);
            serchBar = table.GenQSerch(out serchItem);
            //第一步先添加表头
            table.AddHeadCol("20px", "<input type=\"checkbox\" id=\"selItem\" onclick=\"CkbSelectAll('selItem','selItem')\" />");
            table.AddHeadCol("", "名称");
            table.AddHeadCol("", "排序");
            table.AddHeadCol("", "操作");
            table.AddRow();
            //添加表的内容            
            int curpage = SRequest.GetInt("pageindex", 1);
            if (curpage < 0)
            {
                curpage = 1;
            }
            int count = 0;
            table.AddTag("<Tbody>");
            if (dataPage.DataReader != null)
            {
                while (dataPage.DataReader.Read())
                {
                    count++;
                    table.AddHeadCol("20px", "<input type=\"checkbox\"  name=\"selItem\" value=\"" + dataPage.DataReader["ID"].ToString() + "\" />");
                    table.AddCol(dataPage.DataReader["Name"].ToString());
                    table.AddCol("<input class=\"txtsort\" sort=\"" + dataPage.DataReader["ID"].ToString() + "\" type=\"text\" style=\"width:30px;\" value=\"" + dataPage.DataReader["IsSort"].ToString() + "\" tab=\"MediaSource\" />");
                    table.AddCol(string.Format("<a target=\"mainFrame\" href='/Admin/MediaSourceManager.aspx?id=" + dataPage.DataReader["ID"].ToString() + "' >编辑</a>"));
                    table.AddRow();
                }
            }
            table.AddTag("</Tbody>");
            string tlist = table.GetTable();
            pages = dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            return tlist;
        }


        /// <summary>
        /// 不可恢复性删除
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public int ClearItems(string idGroup)
        {
            return new DAL.PublicHandler().ClearFun("MediaSource", idGroup);
        }
        /// <summary>
        /// 还原删除项目
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public int CancleItems(string idGroup)
        {
            return new DAL.PublicHandler().CancleFun("MediaSource", idGroup);
        }
    }

    public class AdvertPage : IRecycle
    {
        /// <summary>
        /// 获得表格列表
        /// </summary>
        /// <param name="pages">返回分页</param>
        /// <param name="serchBar">返回快速搜索栏目</param>
        /// <param name="serchItem">返回快速搜索条件</param>
        /// <returns></returns>
        public string GetTableList(out string pages, out string serchBar, out string serchItem)
        {
            WebPage.Table table = new WebPage.Table();
            //判断URL参数w_d_IsDel是否为空，为空取未删除产品，不为空取回收站中产品
            WebPage.DataByPage dataPage = new WebSite.DAL.PublicHandler().PageFun("Advert.*,(select Name from Market where ID=Advert.MarketID) as MarketName,(select Name from MediaSource where ID=Advert.MediaSourceID) as MediaSourceName", "Advert", SRequest.GetString(table.ct(WebPage.Table.Where.Equal) + "Advert.IsDel") != "" ? "" : " and Advert.IsDel=0", 15);
            //添加快速搜索

            table.AddSerch("Name", "广告名称", WebPage.Table.Where.Contains);
            serchBar = table.GenQSerch(out serchItem);
            //第一步先添加表头
            table.AddHeadCol("20px", "<input type=\"checkbox\" id=\"selItem\" onclick=\"CkbSelectAll('selItem','selItem')\" />");
            table.AddHeadCol("", "所属商场");
            table.AddHeadCol("", "发布形式");
            table.AddHeadCol("", "广告名称");            
            table.AddHeadCol("", "尺寸");
            table.AddHeadCol("", "租金");
            table.AddHeadCol("", "投放广告商");
            table.AddHeadCol("", "广告编号");
            table.AddHeadCol("", "排序");
            table.AddHeadCol("", "操作");
            table.AddRow();
            //添加表的内容            
            int curpage = SRequest.GetInt("pageindex", 1);
            if (curpage < 0)
            {
                curpage = 1;
            }
            int count = 0;
            table.AddTag("<Tbody>");
            if (dataPage.DataReader != null)
            {
                while (dataPage.DataReader.Read())
                {
                    count++;
                    table.AddHeadCol("20px", "<input type=\"checkbox\"  name=\"selItem\" value=\"" + dataPage.DataReader["ID"].ToString() + "\" />");
                    table.AddCol(dataPage.DataReader["MarketName"].ToString());
                    table.AddCol(dataPage.DataReader["MediaSourceName"].ToString());
                    table.AddCol(dataPage.DataReader["Name"].ToString());
                    table.AddCol(dataPage.DataReader["Size"].ToString());
                    table.AddCol(dataPage.DataReader["Rent"].ToString());
                    table.AddCol(dataPage.DataReader["Advertisers"].ToString());
                    table.AddCol(dataPage.DataReader["AdvertNo"].ToString());
                    table.AddCol("<input class=\"txtsort\" sort=\"" + dataPage.DataReader["ID"].ToString() + "\" type=\"text\" style=\"width:30px;\" value=\"" + dataPage.DataReader["IsSort"].ToString() + "\" tab=\"Advert\" />");
                    table.AddCol(string.Format("<a target=\"mainFrame\" href='/Admin/AdvertManager.aspx?id=" + dataPage.DataReader["ID"].ToString() + "' >编辑</a>"));
                    table.AddRow();
                }
            }
            table.AddTag("</Tbody>");
            string tlist = table.GetTable();
            pages = dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            return tlist;
        }


        /// <summary>
        /// 不可恢复性删除
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public int ClearItems(string idGroup)
        {
            return new DAL.PublicHandler().ClearFun("Advert", idGroup);
        }
        /// <summary>
        /// 还原删除项目
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public int CancleItems(string idGroup)
        {
            return new DAL.PublicHandler().CancleFun("Advert", idGroup);
        }
    }

    public class ComplaintPage : IRecycle
    {
        /// <summary>
        /// 获得表格列表
        /// </summary>
        /// <param name="pages">返回分页</param>
        /// <param name="serchBar">返回快速搜索栏目</param>
        /// <param name="serchItem">返回快速搜索条件</param>
        /// <returns></returns>
        public string GetTableList(out string pages, out string serchBar, out string serchItem)
        {
            WebPage.Table table = new WebPage.Table();
            //判断URL参数w_d_IsDel是否为空，为空取未删除产品，不为空取回收站中产品
            WebPage.DataByPage dataPage = new WebSite.DAL.PublicHandler().PageFun("Complaint.*", "Complaint", SRequest.GetString(table.ct(WebPage.Table.Where.Equal) + "Complaint.IsDel") != "" ? "" : " and Complaint.IsDel=0", 15);
            //添加快速搜索

            table.AddSerch("Ask", "投诉人", WebPage.Table.Where.Contains);
            serchBar = table.GenQSerch(out serchItem);
            //第一步先添加表头
            table.AddHeadCol("20px", "<input type=\"checkbox\" id=\"selItem\" onclick=\"CkbSelectAll('selItem','selItem')\" />");
            table.AddHeadCol("", "投诉类别");
            table.AddHeadCol("", "投诉人");
            table.AddHeadCol("", "投诉日期");
            table.AddHeadCol("", "投诉内容");
            table.AddHeadCol("", "是否审核");
            table.AddHeadCol("", "操作");
            table.AddRow();
            //添加表的内容            
            int curpage = SRequest.GetInt("pageindex", 1);
            if (curpage < 0)
            {
                curpage = 1;
            }
            int count = 0;
            table.AddTag("<Tbody>");
            if (dataPage.DataReader != null)
            {
                while (dataPage.DataReader.Read())
                {
                    count++;
                    table.AddHeadCol("20px", "<input type=\"checkbox\"  name=\"selItem\" value=\"" + dataPage.DataReader["ID"].ToString() + "\" />");
                    table.AddCol(dataPage.DataReader["Category"].ToString());
                    table.AddCol(dataPage.DataReader["Ask"].ToString());
                    table.AddCol(Convert.ToDateTime(dataPage.DataReader["AskTime"]).ToString("yyyy-MM-dd HH:mm"));
                    table.AddCol(dataPage.DataReader["AskDetail"].ToString());
                    table.AddCol("<a href=\"javascript:void(0)\" class=\"proIsExamine\" examine=\"" + dataPage.DataReader["ID"].ToString() + "\" >" + (Convert.ToBoolean(dataPage.DataReader["IsExamine"]) == true ? "是" : "否") + "</a>");
                    table.AddCol(string.Format("<a target=\"mainFrame\" href='/Admin/ComplaintManager.aspx?id=" + dataPage.DataReader["ID"].ToString() + "' >编辑</a>"));
                    table.AddRow();
                }
            }
            table.AddTag("</Tbody>");
            string tlist = table.GetTable();
            pages = dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            return tlist;
        }


        /// <summary>
        /// 不可恢复性删除
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public int ClearItems(string idGroup)
        {
            return new DAL.PublicHandler().ClearFun("Complaint", idGroup);
        }
        /// <summary>
        /// 还原删除项目
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public int CancleItems(string idGroup)
        {
            return new DAL.PublicHandler().CancleFun("Complaint", idGroup);
        }
    }

    public class ProCategoryPage : IRecycle
    {
        /// <summary>
        /// 获得表格列表
        /// </summary>
        /// <param name="pages">返回分页</param>
        /// <param name="serchBar">返回快速搜索栏目</param>
        /// <param name="serchItem">返回快速搜索条件</param>
        /// <returns></returns>
        public string GetTableList(out string pages, out string serchBar, out string serchItem)
        {
            WebPage.Table table = new WebPage.Table();
            //判断URL参数w_d_IsDel是否为空，为空取未删除产品，不为空取回收站中产品
            WebPage.DataByPage dataPage = new WebSite.DAL.PublicHandler().PageFun("OldProduct_Category.*", "OldProduct_Category", SRequest.GetString(table.ct(WebPage.Table.Where.Equal) + "OldProduct_Category.IsDel") != "" ? "" : " and OldProduct_Category.IsDel=0", 15);
            //添加快速搜索

            table.AddSerch("Name", "分类名称", WebPage.Table.Where.Contains);
            serchBar = table.GenQSerch(out serchItem);
            //第一步先添加表头
            table.AddHeadCol("20px", "<input type=\"checkbox\" id=\"selItem\" onclick=\"CkbSelectAll('selItem','selItem')\" />");
            table.AddHeadCol("", "名称");
            table.AddHeadCol("", "排序");
            table.AddHeadCol("", "操作");
            table.AddRow();
            //添加表的内容            
            int curpage = SRequest.GetInt("pageindex", 1);
            if (curpage < 0)
            {
                curpage = 1;
            }
            int count = 0;
            table.AddTag("<Tbody>");
            if (dataPage.DataReader != null)
            {
                while (dataPage.DataReader.Read())
                {
                    count++;
                    table.AddHeadCol("20px", "<input type=\"checkbox\"  name=\"selItem\" value=\"" + dataPage.DataReader["ID"].ToString() + "\" />");
                    table.AddCol(dataPage.DataReader["Name"].ToString());
                    table.AddCol("<input class=\"txtsort\" sort=\"" + dataPage.DataReader["ID"].ToString() + "\" type=\"text\" style=\"width:30px;\" value=\"" + dataPage.DataReader["IsSort"].ToString() + "\" tab=\"OldProduct_Category\" />");
                    table.AddCol(string.Format("<a target=\"mainFrame\" href='/Admin/ProCategoryManager.aspx?id=" + dataPage.DataReader["ID"].ToString() + "' >编辑</a>"));
                    table.AddRow();
                }
            }
            table.AddTag("</Tbody>");
            string tlist = table.GetTable();
            pages = dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            return tlist;
        }


        /// <summary>
        /// 不可恢复性删除
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public int ClearItems(string idGroup)
        {
            return new DAL.PublicHandler().ClearFun("OldProduct_Category", idGroup);
        }
        /// <summary>
        /// 还原删除项目
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public int CancleItems(string idGroup)
        {
            return new DAL.PublicHandler().CancleFun("OldProduct_Category", idGroup);
        }
    }

    public class OldProductPage : IRecycle
    {
        /// <summary>
        /// 获得表格列表
        /// </summary>
        /// <param name="pages">返回分页</param>
        /// <param name="serchBar">返回快速搜索栏目</param>
        /// <param name="serchItem">返回快速搜索条件</param>
        /// <returns></returns>
        public string GetTableList(out string pages, out string serchBar, out string serchItem)
        {
            WebPage.Table table = new WebPage.Table();
            //判断URL参数w_d_IsDel是否为空，为空取未删除产品，不为空取回收站中产品
            WebPage.DataByPage dataPage = new WebSite.DAL.PublicHandler().PageFun("OldProduct.*,(select Name from Market where ID=OldProduct.MarketID) as MarketName,(select Name from OldProduct_Category where ID=OldProduct.CategoryID) as MediaSourceName", "OldProduct", SRequest.GetString(table.ct(WebPage.Table.Where.Equal) + "OldProduct.IsDel") != "" ? "" : " and OldProduct.IsDel=0", 15);
            //添加快速搜索

            table.AddSerch("Name", "物品名称", WebPage.Table.Where.Contains);
            serchBar = table.GenQSerch(out serchItem);
            //第一步先添加表头
            table.AddHeadCol("20px", "<input type=\"checkbox\" id=\"selItem\" onclick=\"CkbSelectAll('selItem','selItem')\" />");
            table.AddHeadCol("", "所属商场");
            table.AddHeadCol("", "物品分类");
            table.AddHeadCol("", "物品名称");
            table.AddHeadCol("", "新旧程度");
            table.AddHeadCol("", "价格");
            table.AddHeadCol("", "物品联系人");
            table.AddHeadCol("", "联系人电话");
            table.AddHeadCol("", "可交易地点");
            table.AddHeadCol("", "排序");
            table.AddHeadCol("", "操作");
            table.AddRow();
            //添加表的内容            
            int curpage = SRequest.GetInt("pageindex", 1);
            if (curpage < 0)
            {
                curpage = 1;
            }
            int count = 0;
            table.AddTag("<Tbody>");
            if (dataPage.DataReader != null)
            {
                while (dataPage.DataReader.Read())
                {
                    count++;
                    table.AddHeadCol("20px", "<input type=\"checkbox\"  name=\"selItem\" value=\"" + dataPage.DataReader["ID"].ToString() + "\" />");
                    table.AddCol(dataPage.DataReader["MarketName"].ToString());
                    table.AddCol(dataPage.DataReader["MediaSourceName"].ToString());
                    table.AddCol(dataPage.DataReader["Name"].ToString());
                    table.AddCol(dataPage.DataReader["Degree"].ToString());
                    table.AddCol(dataPage.DataReader["Price"].ToString());
                    table.AddCol(dataPage.DataReader["Contact"].ToString());
                    table.AddCol(dataPage.DataReader["Phone"].ToString());
                    table.AddCol(dataPage.DataReader["Address"].ToString());
                    table.AddCol("<input class=\"txtsort\" sort=\"" + dataPage.DataReader["ID"].ToString() + "\" type=\"text\" style=\"width:30px;\" value=\"" + dataPage.DataReader["IsSort"].ToString() + "\" tab=\"OldProduct\" />");
                    table.AddCol(string.Format("<a target=\"mainFrame\" href='/Admin/OldProductManager.aspx?id=" + dataPage.DataReader["ID"].ToString() + "' >编辑</a>"));
                    table.AddRow();
                }
            }
            table.AddTag("</Tbody>");
            string tlist = table.GetTable();
            pages = dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            return tlist;
        }


        /// <summary>
        /// 不可恢复性删除
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public int ClearItems(string idGroup)
        {
            return new DAL.PublicHandler().ClearFun("OldProduct", idGroup);
        }
        /// <summary>
        /// 还原删除项目
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public int CancleItems(string idGroup)
        {
            return new DAL.PublicHandler().CancleFun("OldProduct", idGroup);
        }
    }

}

