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
	public class ShopDAL
	{	
		/// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxID()
        {
            string sql = "select max(ID)+1 from Shop";
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
            string sql = "select count(ID) from Shop";
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
			string sql = "SELECT ID FROM [Shop] WHERE ID = @ID";
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
		public Shop FetchEntityByKey (int iD)
		{
			string sql = "SELECT * FROM [Shop] WHERE ID = @ID";
			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", iD)
			};
			Database db = new Database(sql,para);
			return db.ExecuteScalar<Shop>();
		}
		
		/// <summary>
		/// 根据非ID键值查询该实体
		/// <param name="strWhere">条件语句</param>
		/// <returns>返回该键值实体</returns>
		/// </summary>		
		public Shop FetchEntityByNoKey(string strWhere)
		{
			string sql = "SELECT * FROM [Shop]";
            if (strWhere.Trim() != "")
            {
                sql += " where " + strWhere;
            }
            Database db = new Database(sql,null);
            return db.ExecuteScalar<Shop>();			
		}	
		
		/// <summary>
		/// 查询所有实体        
		/// <returns>返回结果列表</returns>
		/// </summary>
        public IList<Shop> GetAllEntities()
        {
			string sql = "SELECT * FROM [Shop] Order by ID Desc";
			Database db = new Database(sql,null);
			return db.ExecuteQuery<Shop>();			
        }
		
        /// <summary>
		/// 查询所有实体
        /// <param name="strWhere">条件语句</param>
		/// <returns>返回结果列表</returns>
		/// </summary>
        public IList<Shop> GetAllEntities(string strWhere)
        {
			string sql = "SELECT * FROM [Shop]";
			if (strWhere.Trim() != "")
            {
                sql += " where " + strWhere;                
            }
			sql += " Order by ID Desc";
			Database db = new Database(sql,null);
			return db.ExecuteQuery<Shop>();			
        }

		/// <summary>
		/// 查询所有实体返回DataTable
		/// <returns>返回DataTable</returns>
		/// </summary>
		public DataTable GetAllEntitiesToDataTable()
		{
			string sql = "SELECT * FROM [Shop] Order by ID Desc";
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
			string sql = "SELECT * FROM [Shop]";
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
        public IList<Shop> SearchBySql(string sql)
        {              
			Database db = new Database(sql,null);
			return db.ExecuteQuery<Shop>();
        }
		
		/// 执行SQL语句 
		/// <param name="sql">SQL语句</param>
		/// <param name="sql">参数数组</param>
		/// <returns>返回查询结果实体列表</returns>
		/// </summary>  
		public IList<Shop> SearchBySql( string sql, params SqlParameter[] values )
		{
			Database db = new Database(sql,values);
			return db.ExecuteQuery<Shop>();
		}
		
		/// <summary>
		/// 新增实体并返回自动增长id
		/// <param name="shop">实体</param>
		/// <returns>返回自动增长id</returns>
		/// </summary>
		public int InsertEntity(Shop shop)
		{
            string sql ="INSERT [Shop] (MarketID, IndustryID, Name, Area, Price, ShowPrice, Rent, ShowRent, ShopNo, Floor, UtilityRate, Peripheral, Plane, Facilitie, BrokerID, IsDel, IsSort, AddDate, CTR)" +
			"VALUES (@MarketID, @IndustryID, @Name, @Area, @Price, @ShowPrice, @Rent, @ShowRent, @ShopNo, @Floor, @UtilityRate, @Peripheral, @Plane, @Facilitie, @BrokerID, @IsDel, @IsSort, @AddDate, @CTR);select @@IDENTITY";
			SqlParameter[] para = new SqlParameter[]
			{
         		new SqlParameter("@MarketID", shop.MarketID),
         		new SqlParameter("@IndustryID", shop.IndustryID),
         		new SqlParameter("@Name", shop.Name),
         		new SqlParameter("@Area", shop.Area),
         		new SqlParameter("@Price", shop.Price),
         		new SqlParameter("@ShowPrice", shop.ShowPrice),
         		new SqlParameter("@Rent", shop.Rent),
         		new SqlParameter("@ShowRent", shop.ShowRent),
         		new SqlParameter("@ShopNo", shop.ShopNo),
         		new SqlParameter("@Floor", shop.Floor),
         		new SqlParameter("@UtilityRate", shop.UtilityRate),
         		new SqlParameter("@Peripheral", shop.Peripheral),
         		new SqlParameter("@Plane", shop.Plane),
         		new SqlParameter("@Facilitie", shop.Facilitie),
         		new SqlParameter("@BrokerID", shop.BrokerID),
         		new SqlParameter("@IsDel", shop.IsDel),
         		new SqlParameter("@IsSort", shop.IsSort),
         		new SqlParameter("@AddDate", shop.AddDate),
				new SqlParameter("@CTR", shop.CTR)
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
			string sql = "DELETE [Shop] WHERE ID = @ID";
			SqlParameter[] para = new SqlParameter[]
			{
			new SqlParameter("@ID", iD)
			};
			Database db = new Database(sql,para);
			return db.ExecuteNoQuery();			
		}
			
        /// <summary>
		/// 更新实体
		/// <param name="shop">键值</param>
		/// <returns>返回该键值实体</returns>
		/// </summary>
		public int UpdateEntity(Shop shop)
		{
			string sql ="UPDATE [Shop] " + "SET " +
				"MarketID = @MarketID, " +
				"IndustryID = @IndustryID, " +
				"Name = @Name, " +
				"Area = @Area, " +
				"Price = @Price, " +
				"ShowPrice = @ShowPrice, " +
				"Rent = @Rent, " +
				"ShowRent = @ShowRent, " +
				"ShopNo = @ShopNo, " +
				"Floor = @Floor, " +
				"UtilityRate = @UtilityRate, " +
				"Peripheral = @Peripheral, " +
				"Plane = @Plane, " +
				"Facilitie = @Facilitie, " +
				"BrokerID = @BrokerID, " +
				"IsDel = @IsDel, " +
				"IsSort = @IsSort, " +
				"AddDate = @AddDate, " +
				"CTR = @CTR "  +
			"WHERE ID = @ID";
			
			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", shop.ID),
				new SqlParameter("@MarketID", shop.MarketID),
				new SqlParameter("@IndustryID", shop.IndustryID),
				new SqlParameter("@Name", shop.Name),
				new SqlParameter("@Area", shop.Area),
				new SqlParameter("@Price", shop.Price),
				new SqlParameter("@ShowPrice", shop.ShowPrice),
				new SqlParameter("@Rent", shop.Rent),
				new SqlParameter("@ShowRent", shop.ShowRent),
				new SqlParameter("@ShopNo", shop.ShopNo),
				new SqlParameter("@Floor", shop.Floor),
				new SqlParameter("@UtilityRate", shop.UtilityRate),
				new SqlParameter("@Peripheral", shop.Peripheral),
				new SqlParameter("@Plane", shop.Plane),
				new SqlParameter("@Facilitie", shop.Facilitie),
				new SqlParameter("@BrokerID", shop.BrokerID),
				new SqlParameter("@IsDel", shop.IsDel),
				new SqlParameter("@IsSort", shop.IsSort),
				new SqlParameter("@AddDate", shop.AddDate),
				new SqlParameter("@CTR", shop.CTR)
			};					
			Database db = new Database(sql,para);
			return db.ExecuteNoQuery();
		}
	}
}
