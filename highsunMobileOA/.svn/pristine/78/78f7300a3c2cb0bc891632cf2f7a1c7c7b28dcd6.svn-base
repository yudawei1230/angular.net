using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using WebSite.DbProxy;
using WebSite.Models;


namespace WebSite.DAL
{
	/// <summary>
	/// 业务逻辑类
	/// </summary>
	public class AdvertDAL
	{	
		/// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxID()
        {
            string sql = "select max(ID)+1 from Advert";
            Database db = new Database(sql, null);
            object obj = db.ExecuteReader();
            if (obj != null && obj != DBNull.Value)
            {
                return int.Parse(obj.ToString());
            }
            return 1;
        }
		
		/// <summary>
        /// 得到记录总和
        /// </summary>
        public int GetCount(string strWhere)
        {
            string sql = "select count(ID) from Advert";
            if (strWhere.Trim() != "")
            {
                sql += " where " + strWhere;
            }
            Database db = new Database(sql, null);
            object obj = db.ExecuteIntScalar();
            if (obj != null && obj != DBNull.Value)
            {
                return int.Parse(obj.ToString());
            }
            return 1;
        }
		
		/// <summary>
		/// 查询实体是否存在
		/// <param name="iD">键值</param>
		/// <returns>返回该键值实体</returns>
		/// </summary>
        public bool IsHaveEntityByKey(int iD)
        {
			string sql = "SELECT ID FROM [Advert] WHERE ID = @ID";
			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", iD)
			};
			Database db = new Database(sql,para);
			return  db.HaveExecuteReader();			
        }
		
		/// <summary>
		/// 根据键值查询该实体
		/// <param name="iD">键值</param>
		/// <returns>返回该键值实体</returns>
		/// </summary>
		public Advert FetchEntityByKey (int iD)
		{
			string sql = "SELECT * FROM [Advert] WHERE ID = @ID";
			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", iD)
			};
			Database db = new Database(sql,para);
			return db.ExecuteScalar<Advert>();
		}
		
		/// <summary>
		/// 根据非ID键值查询该实体
		/// <param name="strWhere">条件语句</param>
		/// <returns>返回该键值实体</returns>
		/// </summary>		
		public Advert FetchEntityByNoKey(string strWhere)
		{
			string sql = "SELECT * FROM [Advert]";
            if (strWhere.Trim() != "")
            {
                sql += " where " + strWhere;
            }
            Database db = new Database(sql,null);
            return db.ExecuteScalar<Advert>();			
		}	
		
		/// <summary>
		/// 查询所有实体        
		/// <returns>返回结果列表</returns>
		/// </summary>
        public IList<Advert> GetAllEntities()
        {
			string sql = "SELECT * FROM [Advert] Order by ID Desc";
			Database db = new Database(sql,null);
			return db.ExecuteQuery<Advert>();			
        }
		
        /// <summary>
		/// 查询所有实体
        /// <param name="strWhere">条件语句</param>
		/// <returns>返回结果列表</returns>
		/// </summary>
        public IList<Advert> GetAllEntities(string strWhere)
        {
			string sql = "SELECT * FROM [Advert]";
			if (strWhere.Trim() != "")
            {
                sql += " where " + strWhere;                
            }
			sql += " Order by ID Desc";
			Database db = new Database(sql,null);
			return db.ExecuteQuery<Advert>();			
        }

		/// <summary>
		/// 查询所有实体返回DataTable
		/// <returns>返回DataTable</returns>
		/// </summary>
		public DataTable GetAllEntitiesToDataTable()
		{
			string sql = "SELECT * FROM [Advert] Order by ID Desc";
			Database db = new Database(sql,null);
			return db.ExecuteDataTable();
		}
		
		/// <summary>
		/// 查询所有实体返回DataTable
		/// <returns>返回DataTable</returns>
        /// <param name="strWhere">条件语句</param>
		/// </summary>
		public DataTable GetAllEntitiesToDataTable(string strWhere)
		{
			string sql = "SELECT * FROM [Advert]";
			if (strWhere.Trim() != "")
            {
                sql += " where " + strWhere;
            }
			sql += " Order by ID Desc";
			Database db = new Database(sql,null);
			return db.ExecuteDataTable();
		}		
		
		/// 执行SQL语句 
		/// <param name="sql">SQL语句</param>
		/// <returns>返回查询结果实体列表</returns>
		/// </summary>        
        public IList<Advert> SearchBySql(string sql)
        {              
			Database db = new Database(sql,null);
			return db.ExecuteQuery<Advert>();
        }
		
		/// 执行SQL语句 
		/// <param name="sql">SQL语句</param>
		/// <param name="sql">参数数组</param>
		/// <returns>返回查询结果实体列表</returns>
		/// </summary>  
		public IList<Advert> SearchBySql( string sql, params SqlParameter[] values )
		{
			Database db = new Database(sql,values);
			return db.ExecuteQuery<Advert>();
		}
		
		/// <summary>
		/// 新增实体并返回自动增长id
		/// <param name="advert">实体</param>
		/// <returns>返回自动增长id</returns>
		/// </summary>
		public int InsertEntity(Advert advert)
		{
            string sql ="INSERT [Advert] (MarketID, MediaSourceID, Name, ReleaseForm, Size, Rent, ShowRent, Position, Advertisers, ShowSer, AdvertNo, Plane, BrokerID, IsDel, IsSort, AddDate, CTR)" +
			"VALUES (@MarketID, @MediaSourceID, @Name, @ReleaseForm, @Size, @Rent, @ShowRent, @Position, @Advertisers, @ShowSer, @AdvertNo, @Plane, @BrokerID, @IsDel, @IsSort, @AddDate, @CTR);select @@IDENTITY";
			SqlParameter[] para = new SqlParameter[]
			{
         		new SqlParameter("@MarketID", advert.MarketID),
         		new SqlParameter("@MediaSourceID", advert.MediaSourceID),
         		new SqlParameter("@Name", advert.Name),
         		new SqlParameter("@ReleaseForm", advert.ReleaseForm),
         		new SqlParameter("@Size", advert.Size),
         		new SqlParameter("@Rent", advert.Rent),
         		new SqlParameter("@ShowRent", advert.ShowRent),
         		new SqlParameter("@Position", advert.Position),
         		new SqlParameter("@Advertisers", advert.Advertisers),
         		new SqlParameter("@ShowSer", advert.ShowSer),
         		new SqlParameter("@AdvertNo", advert.AdvertNo),
         		new SqlParameter("@Plane", advert.Plane),
         		new SqlParameter("@BrokerID", advert.BrokerID),
         		new SqlParameter("@IsDel", advert.IsDel),
         		new SqlParameter("@IsSort", advert.IsSort),
         		new SqlParameter("@AddDate", advert.AddDate),
				new SqlParameter("@CTR", advert.CTR)
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

		/// <summary>
		/// 删除实体
		/// <param name="iD">实体</param>
		/// <returns>返回受影响行数</returns>
		/// </summary>
		public int DeleteEntityByKey(int iD)
		{    
			string sql = "DELETE [Advert] WHERE ID = @ID";
			SqlParameter[] para = new SqlParameter[]
			{
			new SqlParameter("@ID", iD)
			};
			Database db = new Database(sql,para);
			return db.ExecuteNoQuery();			
		}
			
        /// <summary>
		/// 更新实体
		/// <param name="advert">键值</param>
		/// <returns>返回该键值实体</returns>
		/// </summary>
		public int UpdateEntity(Advert advert)
		{
			string sql ="UPDATE [Advert] " + "SET " +
				"MarketID = @MarketID, " +
				"MediaSourceID = @MediaSourceID, " +
				"Name = @Name, " +
				"ReleaseForm = @ReleaseForm, " +
				"Size = @Size, " +
				"Rent = @Rent, " +
				"ShowRent = @ShowRent, " +
				"Position = @Position, " +
				"Advertisers = @Advertisers, " +
				"ShowSer = @ShowSer, " +
				"AdvertNo = @AdvertNo, " +
				"Plane = @Plane, " +
				"BrokerID = @BrokerID, " +
				"IsDel = @IsDel, " +
				"IsSort = @IsSort, " +
				"AddDate = @AddDate, " +
				"CTR = @CTR "  +
			"WHERE ID = @ID";
			
			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", advert.ID),
				new SqlParameter("@MarketID", advert.MarketID),
				new SqlParameter("@MediaSourceID", advert.MediaSourceID),
				new SqlParameter("@Name", advert.Name),
				new SqlParameter("@ReleaseForm", advert.ReleaseForm),
				new SqlParameter("@Size", advert.Size),
				new SqlParameter("@Rent", advert.Rent),
				new SqlParameter("@ShowRent", advert.ShowRent),
				new SqlParameter("@Position", advert.Position),
				new SqlParameter("@Advertisers", advert.Advertisers),
				new SqlParameter("@ShowSer", advert.ShowSer),
				new SqlParameter("@AdvertNo", advert.AdvertNo),
				new SqlParameter("@Plane", advert.Plane),
				new SqlParameter("@BrokerID", advert.BrokerID),
				new SqlParameter("@IsDel", advert.IsDel),
				new SqlParameter("@IsSort", advert.IsSort),
				new SqlParameter("@AddDate", advert.AddDate),
				new SqlParameter("@CTR", advert.CTR)
			};					
			Database db = new Database(sql,para);
			return db.ExecuteNoQuery();
		}
	}
}
