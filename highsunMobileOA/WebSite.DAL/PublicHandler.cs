using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using WebSite.DbProxy;
using WebSite.Models;
using WebSite.WebPage;

namespace WebSite.DAL
{
    public class PublicHandler
    {
        public IList<Complaint> GetAllEntities(string AskPerson, int Top, string Range)
        {
            string sql = "SELECT ";
            if (Top != 0)
            {
                sql += " Top " + Top;
            }
            sql += " * FROM [Complaint] where IsDel = 0 ";
            if (Range != "My")
            {
                sql += " and IsExamine =1";
            }
            if (AskPerson.Trim() != "")
            {
                sql += " and Ask ='" + AskPerson + "'";
            }
            sql += " order by ID desc";
            Database db = new Database(sql, null);
            return db.ExecuteQuery<Complaint>();
        }
        public IList<Complaint> GetAllEntitiesByCategory(string Category, int Top)
        {
            string sql = "SELECT ";
            if (Top != 0)
            {
                sql += " Top " + Top;
            }
            sql += " * FROM [Complaint] where IsExamine =1 and IsDel = 0 and Category = @Category order by ID desc";
            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Category", Category)
			};
            Database db = new Database(sql, para);
            return db.ExecuteQuery<Complaint>();
        }

        
        /// <summary>
        /// 更新排序
        /// </summary>
        /// <param name="tab">表名</param>
        /// <param name="id"></param>
        /// <param name="val">IsSort</param>
        /// <returns></returns>
        public int EditSort(string tab, int sort, int val)
        {
            string sql = "update " + tab + " set IsSort = " + val + " where ID =" + sort;
            Database db = new Database(sql, null);
            return db.ExecuteNoQuery();
        }
        /// <summary>
        /// 列表分页显示
        /// </summary>
        /// <returns></returns>
        public DataByPage PageFun(string sqlfield, string sqltab, string sqlwhere, int pageSize)
        {
            DataByPage dataPage = new DataByPage();
            dataPage.Sql = "[select] " + sqlfield + " [from] " + sqltab + " [where] 1=1 " + sqlwhere;
            dataPage.OrderBy = " ID desc";
            dataPage.PageSize = pageSize;
            dataPage.GetRecordSetByPage();
            return dataPage;
        }

        /// <summary>
        /// 放到回收站
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public int DelFun(string tab, string idGroup)
        {
            string sql = "update " + tab + " set IsDel = 1 where ID in (" + idGroup + ")";
            Database db = new Database(sql, null);
            return db.ExecuteNoQuery();
        }

        /// <summary>
        /// 回收站还原
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public int CancleFun(string tab, string idGroup)
        {
            string sql = "update " + tab + " set IsDel = 0 where ID in (" + idGroup + ")";
            Database db = new Database(sql, null);
            return db.ExecuteNoQuery();
        }

        /// <summary>
        /// 不可恢复性删除
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public int ClearFun(string tab, string idGroup)
        {
            Database db = new Database();
            ArrayList sqlArr = new ArrayList();
            sqlArr.Add("delete " + tab + " where ID in(" + idGroup + ")");
            return db.ExecuteNoQuery(sqlArr) ? 1 : 0;
        }
        public System.Data.DataTable IndustryDt()
        {
            string sql = "SELECT * FROM [Industry] where IsDel = 0 Order by ID asc";
            Database db = new Database(sql, null);
            return db.ExecuteDataTable();
        }
        /// <summary>
        /// 删除商品类别和他的子类别
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public bool delIndustry(int Id)
        {
            System.Collections.ArrayList sqlList = new System.Collections.ArrayList();
            string dsql = "DELETE Industry WHERE ID=" + Id + " OR FullID LIKE '%" + Id + ",%'";
            sqlList.Add(dsql);
            Database db = new Database();
            return db.ExecuteNoQuery(sqlList);
        }

        public bool MemberIsHave(string Phone, string Pwd)
        {
            string sql = "SELECT ID FROM [Member] WHERE Phone = @Phone and Pwd = @Pwd and IsDel = 0";
            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Phone", Phone),
                new SqlParameter("@Pwd", Pwd)
			};
            Database db = new Database(sql, para);
            return db.HaveExecuteReader();
        }
        public Member MemberByPhone(string Phone)
        {
            string sql = "SELECT * FROM [Member] WHERE Phone = @Phone and IsDel = 0";
            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Phone", Phone)
			};
            Database db = new Database(sql, para);
            return db.ExecuteScalar<Member>();
        }
        public IList<Shop> ShopByBrokerID(int BrokerID)
        {
            string sql = "SELECT * FROM [Shop] where BrokerID = @BrokerID order by id desc";
            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@BrokerID", BrokerID)
			};
            Database db = new Database(sql, para);
            return db.ExecuteQuery<Shop>();
        }
        public IList<Advert> AdvertByBrokerID(int BrokerID)
        {
            string sql = "SELECT * FROM [Advert] where BrokerID = @BrokerID order by ID desc";
            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@BrokerID", BrokerID)
			};
            Database db = new Database(sql, para);
            return db.ExecuteQuery<Advert>();
        }
        //public int addShopImg(IList<ShopImg> ShopImg)
        //{
        //    StringBuilder sql = new StringBuilder();
        //    sql.Append("insert ShopImg(ShopID,Url,IsDel)");
        //    for (int i = 0; i < ShopImg.Count; i++)
        //    {
        //        sql.Append("select " + ShopImg[i].ShopID + ",'" + ShopImg[i].Url + "','" + Convert.ToBoolean(ShopImg[i].IsDel) + "'");
        //        if (i != ShopImg.Count - 1)
        //        {
        //            sql.Append(" union all ");
        //        }
        //    }
        //    Database db = new Database(sql.ToString(), null);
        //    return db.ExecuteNoQuery();
        //}
        public System.Data.DataSet GetShopImgDs(string ShopID)
        {
            string sql = "SELECT * FROM [ShopImg] where ShopID = @ShopID";
            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ShopID", ShopID)
			};
            Database db = new Database(sql.ToString(), para);
            return db.ExecuteDataSet();
        }
        public System.Data.DataSet GetAdvertImgDs(string AdvertID)
        {
            string sql = "SELECT * FROM [AdvertImg] where AdvertID = @AdvertID";
            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@AdvertID", AdvertID)
			};
            Database db = new Database(sql.ToString(), para);
            return db.ExecuteDataSet();
        }
        //public bool IsHaveShopImg(int ShopID, int Number)
        //{
        //    string sql = "SELECT ID FROM [ShopImg] WHERE ShopID = @ShopID and Number = @Number";
        //    SqlParameter[] para = new SqlParameter[]
        //    {
        //        new SqlParameter("@ShopID", ShopID),
        //        new SqlParameter("@Number", Number)
        //    };
        //    Database db = new Database(sql, para);
        //    return db.HaveExecuteReader();
        //}
        public int ShopImgGetID(int ShopID, int Number)
        {
            string sql = "SELECT ID FROM [ShopImg] WHERE ShopID = @ShopID and Number = @Number";
            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ShopID", ShopID),
                new SqlParameter("@Number", Number)
			};
            Database db = new Database(sql, para);
            object obj = db.GetSingle();
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        public int AdvertImgGetID(int AdvertID, int Number)
        {
            string sql = "SELECT ID FROM [AdvertImg] WHERE AdvertID = @AdvertID and Number = @Number";
            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@AdvertID", AdvertID),
                new SqlParameter("@Number", Number)
			};
            Database db = new Database(sql, para);
            object obj = db.GetSingle();
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        public IList<Market> MarketList()
        {
            string sql = "SELECT * FROM [Market] where IsDel = 0 order by IsSort asc";
            Database db = new Database(sql, null);
            return db.ExecuteQuery<Market>();
        }
        public IList<MediaSource> MediaSourceList()
        {
            string sql = "SELECT * FROM [MediaSource] where IsDel = 0 order by IsSort asc";
            Database db = new Database(sql, null);
            return db.ExecuteQuery<MediaSource>();
        }
        public System.Data.DataTable MarketListByDt()
        {
            string sql = "SELECT * FROM [Market] where IsDel = 0 order by IsSort asc";
            Database db = new Database(sql, null);
            return db.ExecuteDataTable();
        }
        public System.Data.DataTable MediaSourceByDt()
        {
            string sql = "SELECT * FROM [MediaSource] where IsDel = 0 order by IsSort asc";
            Database db = new Database(sql, null);
            return db.ExecuteDataTable();
        }
        public System.Data.DataTable IndustryListByDt()
        {
            string sql = "SELECT * FROM [Industry] where IsDel = 0 order by ID desc";
            Database db = new Database(sql, null);
            return db.ExecuteDataTable();
        }
        public System.Data.DataTable MemberListByDt()
        {
            string sql = "SELECT * FROM [Member] where IsDel = 0 order by ID desc";
            Database db = new Database(sql, null);
            return db.ExecuteDataTable();
        }
        public IList<IndexImg> IndexImgList()
        {
            string sql = "SELECT * FROM [IndexImg] where IsDel = 0 order by IsSort asc";
            Database db = new Database(sql, null);
            return db.ExecuteQuery<IndexImg>();
        }
        public IList<Industry> IndustryList(int ParentID)
        {
            string sql = "SELECT * FROM [Industry] where IsDel = 0 and ParentID = @ParentID";
            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ParentID", ParentID)
			};
            Database db = new Database(sql, para);
            return db.ExecuteQuery<Industry>();
        }
        public IList<Shop> ShopList()
        {
            string sql = "SELECT * FROM [Shop] where IsDel = 0 order by ID desc";
            Database db = new Database(sql, null);
            return db.ExecuteQuery<Shop>();
        }
        public IList<Advert> AdvertList()
        {
            string sql = "SELECT * FROM [Advert] where IsDel = 0 order by ID desc";
            Database db = new Database(sql, null);
            return db.ExecuteQuery<Advert>();
        }
        public IList<Shop> ShopList(string market, string area, string industry, string name)
        {

            string sql = "SELECT * FROM [Shop] where IsDel = 0";
            if (!market.Equals("_null") && !string.IsNullOrEmpty(market))
            {
                sql += " and MarketID = " + market;
            }
            if (!area.Equals("_null") && !string.IsNullOrEmpty(area))
            {
                string[] a = area.Split('|');
                sql += " and Area between " + a[0] + " and  " + a[1] + "";
            }
            if (!industry.Equals("_null") && !string.IsNullOrEmpty(industry))
            {
                sql += " and IndustryID = " + industry;
            }
            if (!string.IsNullOrEmpty(name))
            {
                sql += " and (Name like '%" + name + "%'";
                sql += " or Area like '%" + name + "%'";
                sql += " or Price like '%" + name + "%'";
                sql += " or Rent like '%" + name + "%'";
                sql += " or ShopNo like '%" + name + "%'";
                sql += " or Floor like '%" + name + "%'";
                sql += " or UtilityRate like '%" + name + "%'";
                sql += " or Peripheral like '%" + name + "%'";
                sql += " or Plane like '%" + name + "%'";
                sql += " or Facilitie like '%" + name + "%')";
            }
            sql += " order by ID desc";
            Database db = new Database(sql, null);
            return db.ExecuteQuery<Shop>();
        }

        public IList<Advert> AdvertList(string market, string industry, string name)
        {

            string sql = "SELECT * FROM [Advert] where IsDel = 0";
            if (!market.Equals("_null") && !string.IsNullOrEmpty(market))
            {
                sql += " and MarketID = " + market;
            }
            if (!industry.Equals("_null") && !string.IsNullOrEmpty(industry))
            {
                sql += " and MediaSourceID = " + industry;
            }
            if (!string.IsNullOrEmpty(name))
            {
                sql += " and (Name like '%" + name + "%'";
                sql += " or Size like '%" + name + "%'";
                sql += " or Rent like '%" + name + "%'";
                sql += " or Advertisers like '%" + name + "%')";
            }
            sql += " order by ID desc";
            Database db = new Database(sql, null);
            return db.ExecuteQuery<Advert>();
        }

        public object DefaultShopImg(int ShopID)
        {
            string sql = "SELECT  TOP (1) Url FROM [ShopImg] WHERE ShopID = @ShopID";
            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ShopID", ShopID)
			};
            Database db = new Database(sql, para);
            return db.GetSingle();
        }
        public object DefaultAdvertImg(int AdvertID)
        {
            string sql = "SELECT  TOP (1) Url FROM [AdvertImg] WHERE AdvertID = @AdvertID";
            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@AdvertID", AdvertID)
			};
            Database db = new Database(sql, para);
            return db.GetSingle();
        }
        public IList<ShopImg> GetShopImg(int ShopID)
        {
            string sql = "SELECT * FROM [ShopImg] where ShopID = @ShopID";
            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ShopID", ShopID)
			};
            Database db = new Database(sql, para);
            return db.ExecuteQuery<ShopImg>();
        }
        public IList<AdvertImg> GetAdvertImg(int AdvertID)
        {
            string sql = "SELECT * FROM [AdvertImg] where AdvertID = @AdvertID";
            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@AdvertID", AdvertID)
			};
            Database db = new Database(sql, para);
            return db.ExecuteQuery<AdvertImg>();
        }
        public System.Data.DataSet GetShopDs(string ID)
        {
            string sql = "SELECT * FROM [Shop] where ID = @ID";
            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", ID)
			};
            Database db = new Database(sql.ToString(), para);
            return db.ExecuteDataSet();
        }
        public System.Data.DataSet GetAdvertDs(string ID)
        {
            string sql = "SELECT * FROM [Advert] where ID = @ID";
            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", ID)
			};
            Database db = new Database(sql.ToString(), para);
            return db.ExecuteDataSet();
        }
        public System.Data.DataSet GetMemberDs(int ID)
        {
            string sql = "SELECT * FROM [Member] where ID = @ID";
            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", ID)
			};
            Database db = new Database(sql.ToString(), para);
            return db.ExecuteDataSet();
        }
        public int UpdateShopCTR(Shop shop)
        {
            string sql = "UPDATE [Shop] SET CTR = @CTR WHERE ID = @ID";

            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", shop.ID),				
				new SqlParameter("@CTR", shop.CTR)
			};
            Database db = new Database(sql, para);
            return db.ExecuteNoQuery();
        }

        public int UpdateAdvertCTR(Advert advert)
        {
            string sql = "UPDATE [Advert] SET CTR = @CTR WHERE ID = @ID";
            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", advert.ID),				
				new SqlParameter("@CTR", advert.CTR)
			};
            Database db = new Database(sql, para);
            return db.ExecuteNoQuery();
        }
        public int InsertAsk(Complaint complaint)
        {
            string sql = "INSERT [Complaint] (Category, Ask, AskTime, RealName, Phone, Img0, Img1, Img2, AskDetail, IsExamine, IsDel)" +
            "VALUES (@Category, @Ask, @AskTime, @RealName, @Phone, @Img0, @Img1, @Img2, @AskDetail, @IsExamine, @IsDel);select @@IDENTITY";
            SqlParameter[] para = new SqlParameter[]
			{
         		new SqlParameter("@Category", complaint.Category),
         		new SqlParameter("@Ask", complaint.Ask),
         		new SqlParameter("@AskTime", complaint.AskTime),
                new SqlParameter("@RealName", complaint.RealName),
         		new SqlParameter("@Phone", complaint.Phone),
         		new SqlParameter("@Img0", complaint.Img0),
         		new SqlParameter("@Img1", complaint.Img1),
         		new SqlParameter("@Img2", complaint.Img2),
         		new SqlParameter("@AskDetail", complaint.AskDetail),
         		new SqlParameter("@IsExamine", complaint.IsExamine),
				new SqlParameter("@IsDel", complaint.IsDel)
			};
            Database db = new Database(sql, para);
            object obj = db.GetSingle();
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        public int InsertSLTradingWaterData(SLTradingWaterInfo sltradingwaterInfo)
        {
            string sql = @"INSERT [SLTradingWater] (txn_num,sys_seq_num,txn_date,trans_date_time,pan,amt_trans,retrivl_ref,authr_id_resp,
term_id,mcht_no,mcht_nm,misc_1,misc_2,misc_3,inst_code,agen_no,oper_no,resp_code,offline_flg)" +
@"VALUES (@Txn_num, @Sys_seq_num, @Txn_date, @Trans_date_time, @Pan, @Amt_trans,
@Retrivl_ref, @Authr_id_resp, @Term_id, @Mcht_no, @Mcht_nm, @Misc_1, @Misc_2,
@Misc_3, @Inst_code, @Agen_no, @Oper_no, @Resp_code, @Offline_flg);select @@IDENTITY";
            SqlParameter[] para = new SqlParameter[]
			{
         		new SqlParameter("@Txn_num", sltradingwaterInfo.Txn_num),
         		new SqlParameter("@Sys_seq_num", sltradingwaterInfo.Sys_seq_num),
         		new SqlParameter("@Txn_date", sltradingwaterInfo.Txn_date),
         		new SqlParameter("@Trans_date_time", sltradingwaterInfo.Trans_date_time),
         		new SqlParameter("@Pan", sltradingwaterInfo.Pan),
         		new SqlParameter("@Amt_trans", sltradingwaterInfo.Amt_trans),
         		new SqlParameter("@Retrivl_ref", sltradingwaterInfo.Retrivl_ref),
         		new SqlParameter("@Authr_id_resp", sltradingwaterInfo.Authr_id_resp),
				new SqlParameter("@Term_id", sltradingwaterInfo.Term_id),
                new SqlParameter("@Mcht_no", sltradingwaterInfo.Mcht_no),
                new SqlParameter("@Mcht_nm", sltradingwaterInfo.Mcht_nm),
                new SqlParameter("@Misc_1", sltradingwaterInfo.Misc_1),
                new SqlParameter("@Misc_2", sltradingwaterInfo.Misc_2),
                new SqlParameter("@Misc_3", sltradingwaterInfo.Misc_3),
                new SqlParameter("@Inst_code", sltradingwaterInfo.Inst_code),
                new SqlParameter("@Agen_no", sltradingwaterInfo.Agen_no),
                new SqlParameter("@Oper_no", sltradingwaterInfo.Oper_no),
                new SqlParameter("@Resp_code", sltradingwaterInfo.Resp_code),
                new SqlParameter("@Offline_flg", sltradingwaterInfo.Offline_flg)
			};
            Database db = new Database(sql, para);
            object obj = db.GetSingle();
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
    }
}
