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
	public class ShopImgDAL
	{	
		/// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxID()
        {
            string sql = "select max(ID)+1 from ShopImg";
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
            string sql = "select count(ID) from ShopImg";
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
			string sql = "SELECT ID FROM [ShopImg] WHERE ID = @ID";
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
		public ShopImg FetchEntityByKey (int iD)
		{
			string sql = "SELECT * FROM [ShopImg] WHERE ID = @ID";
			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", iD)
			};
			Database db = new Database(sql,para);
			return db.ExecuteScalar<ShopImg>();
		}
		
		/// <summary>
		/// 根据非ID键值查询该实体
		/// <param name="strWhere">条件语句</param>
		/// <returns>返回该键值实体</returns>
		/// </summary>		
		public ShopImg FetchEntityByNoKey(string strWhere)
		{
			string sql = "SELECT * FROM [ShopImg]";
            if (strWhere.Trim() != "")
            {
                sql += " where " + strWhere;
            }
            Database db = new Database(sql,null);
            return db.ExecuteScalar<ShopImg>();			
		}	
		
		/// <summary>
		/// 查询所有实体        
		/// <returns>返回结果列表</returns>
		/// </summary>
        public IList<ShopImg> GetAllEntities()
        {
			string sql = "SELECT * FROM [ShopImg] Order by ID Desc";
			Database db = new Database(sql,null);
			return db.ExecuteQuery<ShopImg>();			
        }
		
        /// <summary>
		/// 查询所有实体
        /// <param name="strWhere">条件语句</param>
		/// <returns>返回结果列表</returns>
		/// </summary>
        public IList<ShopImg> GetAllEntities(string strWhere)
        {
			string sql = "SELECT * FROM [ShopImg]";
			if (strWhere.Trim() != "")
            {
                sql += " where " + strWhere;                
            }
			sql += " Order by ID Desc";
			Database db = new Database(sql,null);
			return db.ExecuteQuery<ShopImg>();			
        }

		/// <summary>
		/// 查询所有实体返回DataTable
		/// <returns>返回DataTable</returns>
		/// </summary>
		public DataTable GetAllEntitiesToDataTable()
		{
			string sql = "SELECT * FROM [ShopImg] Order by ID Desc";
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
			string sql = "SELECT * FROM [ShopImg]";
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
        public IList<ShopImg> SearchBySql(string sql)
        {              
			Database db = new Database(sql,null);
			return db.ExecuteQuery<ShopImg>();
        }
		
		/// 执行SQL语句 
		/// <param name="sql">SQL语句</param>
		/// <param name="sql">参数数组</param>
		/// <returns>返回查询结果实体列表</returns>
		/// </summary>  
		public IList<ShopImg> SearchBySql( string sql, params SqlParameter[] values )
		{
			Database db = new Database(sql,values);
			return db.ExecuteQuery<ShopImg>();
		}
		
		/// <summary>
		/// 新增实体并返回自动增长id
		/// <param name="shopImg">实体</param>
		/// <returns>返回自动增长id</returns>
		/// </summary>
		public int InsertEntity(ShopImg shopImg)
		{
            string sql ="INSERT [ShopImg] (ShopID, Number, Url)" +
			"VALUES (@ShopID, @Number, @Url);select @@IDENTITY";
			SqlParameter[] para = new SqlParameter[]
			{
         		new SqlParameter("@ShopID", shopImg.ShopID),
         		new SqlParameter("@Number", shopImg.Number),
				new SqlParameter("@Url", shopImg.Url)
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
			string sql = "DELETE [ShopImg] WHERE ID = @ID";
			SqlParameter[] para = new SqlParameter[]
			{
			new SqlParameter("@ID", iD)
			};
			Database db = new Database(sql,para);
			return db.ExecuteNoQuery();			
		}
			
        /// <summary>
		/// 更新实体
		/// <param name="shopImg">键值</param>
		/// <returns>返回该键值实体</returns>
		/// </summary>
		public int UpdateEntity(ShopImg shopImg)
		{
			string sql ="UPDATE [ShopImg] " + "SET " +
				"ShopID = @ShopID, " +
				"Number = @Number, " +
				"Url = @Url "  +
			"WHERE ID = @ID";
			
			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", shopImg.ID),
				new SqlParameter("@ShopID", shopImg.ShopID),
				new SqlParameter("@Number", shopImg.Number),
				new SqlParameter("@Url", shopImg.Url)
			};					
			Database db = new Database(sql,para);
			return db.ExecuteNoQuery();
		}
	}
}
