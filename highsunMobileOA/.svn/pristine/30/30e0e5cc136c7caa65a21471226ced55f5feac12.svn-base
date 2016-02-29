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
	public class OldProductDAL
	{	
		/// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxID()
        {
            string sql = "select max(ID)+1 from OldProduct";
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
            string sql = "select count(ID) from OldProduct";
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
			string sql = "SELECT ID FROM [OldProduct] WHERE ID = @ID";
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
		public OldProduct FetchEntityByKey (int iD)
		{
			string sql = "SELECT * FROM [OldProduct] WHERE ID = @ID";
			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", iD)
			};
			Database db = new Database(sql,para);
			return db.ExecuteScalar<OldProduct>();
		}
		
		/// <summary>
		/// 根据非ID键值查询该实体
		/// <param name="strWhere">条件语句</param>
		/// <returns>返回该键值实体</returns>
		/// </summary>		
		public OldProduct FetchEntityByNoKey(string strWhere)
		{
			string sql = "SELECT * FROM [OldProduct]";
            if (strWhere.Trim() != "")
            {
                sql += " where " + strWhere;
            }
            Database db = new Database(sql,null);
            return db.ExecuteScalar<OldProduct>();			
		}	
		
		/// <summary>
		/// 查询所有实体        
		/// <returns>返回结果列表</returns>
		/// </summary>
        public IList<OldProduct> GetAllEntities()
        {
			string sql = "SELECT * FROM [OldProduct] Order by ID Desc";
			Database db = new Database(sql,null);
			return db.ExecuteQuery<OldProduct>();			
        }
		
        /// <summary>
		/// 查询所有实体
        /// <param name="strWhere">条件语句</param>
		/// <returns>返回结果列表</returns>
		/// </summary>
        public IList<OldProduct> GetAllEntities(string strWhere)
        {
			string sql = "SELECT * FROM [OldProduct]";
			if (strWhere.Trim() != "")
            {
                sql += " where " + strWhere;                
            }
			sql += " Order by ID Desc";
			Database db = new Database(sql,null);
			return db.ExecuteQuery<OldProduct>();			
        }

		/// <summary>
		/// 查询所有实体返回DataTable
		/// <returns>返回DataTable</returns>
		/// </summary>
		public DataTable GetAllEntitiesToDataTable()
		{
			string sql = "SELECT * FROM [OldProduct] Order by ID Desc";
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
			string sql = "SELECT * FROM [OldProduct]";
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
        public IList<OldProduct> SearchBySql(string sql)
        {              
			Database db = new Database(sql,null);
			return db.ExecuteQuery<OldProduct>();
        }
		
		/// 执行SQL语句 
		/// <param name="sql">SQL语句</param>
		/// <param name="sql">参数数组</param>
		/// <returns>返回查询结果实体列表</returns>
		/// </summary>  
		public IList<OldProduct> SearchBySql( string sql, params SqlParameter[] values )
		{
			Database db = new Database(sql,values);
			return db.ExecuteQuery<OldProduct>();
		}
		
		/// <summary>
		/// 新增实体并返回自动增长id
		/// <param name="oldProduct">实体</param>
		/// <returns>返回自动增长id</returns>
		/// </summary>
		public int InsertEntity(OldProduct oldProduct)
		{
            string sql ="INSERT [OldProduct] (MarketID, CategoryID, Name, Degree, Price, Detail, Contact, Phone, Address, BrokerID, IsDel, IsSort, AddDate, CTR)" +
			"VALUES (@MarketID, @CategoryID, @Name, @Degree, @Price, @Detail, @Contact, @Phone, @Address, @BrokerID, @IsDel, @IsSort, @AddDate, @CTR);select @@IDENTITY";
			SqlParameter[] para = new SqlParameter[]
			{
         		new SqlParameter("@MarketID", oldProduct.MarketID),
         		new SqlParameter("@CategoryID", oldProduct.CategoryID),
         		new SqlParameter("@Name", oldProduct.Name),
         		new SqlParameter("@Degree", oldProduct.Degree),
         		new SqlParameter("@Price", oldProduct.Price),
         		new SqlParameter("@Detail", oldProduct.Detail),
         		new SqlParameter("@Contact", oldProduct.Contact),
         		new SqlParameter("@Phone", oldProduct.Phone),
         		new SqlParameter("@Address", oldProduct.Address),
         		new SqlParameter("@BrokerID", oldProduct.BrokerID),
         		new SqlParameter("@IsDel", oldProduct.IsDel),
         		new SqlParameter("@IsSort", oldProduct.IsSort),
         		new SqlParameter("@AddDate", oldProduct.AddDate),
				new SqlParameter("@CTR", oldProduct.CTR)
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
			string sql = "DELETE [OldProduct] WHERE ID = @ID";
			SqlParameter[] para = new SqlParameter[]
			{
			new SqlParameter("@ID", iD)
			};
			Database db = new Database(sql,para);
			return db.ExecuteNoQuery();			
		}
			
        /// <summary>
		/// 更新实体
		/// <param name="oldProduct">键值</param>
		/// <returns>返回该键值实体</returns>
		/// </summary>
		public int UpdateEntity(OldProduct oldProduct)
		{
			string sql ="UPDATE [OldProduct] " + "SET " +
				"MarketID = @MarketID, " +
				"CategoryID = @CategoryID, " +
				"Name = @Name, " +
				"Degree = @Degree, " +
				"Price = @Price, " +
				"Detail = @Detail, " +
				"Contact = @Contact, " +
				"Phone = @Phone, " +
				"Address = @Address, " +
				"BrokerID = @BrokerID, " +
				"IsDel = @IsDel, " +
				"IsSort = @IsSort, " +
				"AddDate = @AddDate, " +
				"CTR = @CTR "  +
			"WHERE ID = @ID";
			
			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", oldProduct.ID),
				new SqlParameter("@MarketID", oldProduct.MarketID),
				new SqlParameter("@CategoryID", oldProduct.CategoryID),
				new SqlParameter("@Name", oldProduct.Name),
				new SqlParameter("@Degree", oldProduct.Degree),
				new SqlParameter("@Price", oldProduct.Price),
				new SqlParameter("@Detail", oldProduct.Detail),
				new SqlParameter("@Contact", oldProduct.Contact),
				new SqlParameter("@Phone", oldProduct.Phone),
				new SqlParameter("@Address", oldProduct.Address),
				new SqlParameter("@BrokerID", oldProduct.BrokerID),
				new SqlParameter("@IsDel", oldProduct.IsDel),
				new SqlParameter("@IsSort", oldProduct.IsSort),
				new SqlParameter("@AddDate", oldProduct.AddDate),
				new SqlParameter("@CTR", oldProduct.CTR)
			};					
			Database db = new Database(sql,para);
			return db.ExecuteNoQuery();
		}
	}
}
