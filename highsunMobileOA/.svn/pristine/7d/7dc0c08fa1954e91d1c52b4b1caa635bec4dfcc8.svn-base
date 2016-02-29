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
	public class OldProduct_ImgDAL
	{	
		/// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxID()
        {
            string sql = "select max(ID)+1 from OldProduct_Img";
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
            string sql = "select count(ID) from OldProduct_Img";
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
			string sql = "SELECT ID FROM [OldProduct_Img] WHERE ID = @ID";
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
		public OldProduct_Img FetchEntityByKey (int iD)
		{
			string sql = "SELECT * FROM [OldProduct_Img] WHERE ID = @ID";
			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", iD)
			};
			Database db = new Database(sql,para);
			return db.ExecuteScalar<OldProduct_Img>();
		}
		
		/// <summary>
		/// 根据非ID键值查询该实体
		/// <param name="strWhere">条件语句</param>
		/// <returns>返回该键值实体</returns>
		/// </summary>		
		public OldProduct_Img FetchEntityByNoKey(string strWhere)
		{
			string sql = "SELECT * FROM [OldProduct_Img]";
            if (strWhere.Trim() != "")
            {
                sql += " where " + strWhere;
            }
            Database db = new Database(sql,null);
            return db.ExecuteScalar<OldProduct_Img>();			
		}	
		
		/// <summary>
		/// 查询所有实体        
		/// <returns>返回结果列表</returns>
		/// </summary>
        public IList<OldProduct_Img> GetAllEntities()
        {
			string sql = "SELECT * FROM [OldProduct_Img] Order by ID Desc";
			Database db = new Database(sql,null);
			return db.ExecuteQuery<OldProduct_Img>();			
        }
		
        /// <summary>
		/// 查询所有实体
        /// <param name="strWhere">条件语句</param>
		/// <returns>返回结果列表</returns>
		/// </summary>
        public IList<OldProduct_Img> GetAllEntities(string strWhere)
        {
			string sql = "SELECT * FROM [OldProduct_Img]";
			if (strWhere.Trim() != "")
            {
                sql += " where " + strWhere;                
            }
			sql += " Order by ID Desc";
			Database db = new Database(sql,null);
			return db.ExecuteQuery<OldProduct_Img>();			
        }

		/// <summary>
		/// 查询所有实体返回DataTable
		/// <returns>返回DataTable</returns>
		/// </summary>
		public DataTable GetAllEntitiesToDataTable()
		{
			string sql = "SELECT * FROM [OldProduct_Img] Order by ID Desc";
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
			string sql = "SELECT * FROM [OldProduct_Img]";
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
        public IList<OldProduct_Img> SearchBySql(string sql)
        {              
			Database db = new Database(sql,null);
			return db.ExecuteQuery<OldProduct_Img>();
        }
		
		/// 执行SQL语句 
		/// <param name="sql">SQL语句</param>
		/// <param name="sql">参数数组</param>
		/// <returns>返回查询结果实体列表</returns>
		/// </summary>  
		public IList<OldProduct_Img> SearchBySql( string sql, params SqlParameter[] values )
		{
			Database db = new Database(sql,values);
			return db.ExecuteQuery<OldProduct_Img>();
		}
		
		/// <summary>
		/// 新增实体并返回自动增长id
		/// <param name="oldProduct_Img">实体</param>
		/// <returns>返回自动增长id</returns>
		/// </summary>
		public int InsertEntity(OldProduct_Img oldProduct_Img)
		{
            string sql ="INSERT [OldProduct_Img] (ProductID, Number, Url)" +
			"VALUES (@ProductID, @Number, @Url);select @@IDENTITY";
			SqlParameter[] para = new SqlParameter[]
			{
         		new SqlParameter("@ProductID", oldProduct_Img.ProductID),
         		new SqlParameter("@Number", oldProduct_Img.Number),
				new SqlParameter("@Url", oldProduct_Img.Url)
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
			string sql = "DELETE [OldProduct_Img] WHERE ID = @ID";
			SqlParameter[] para = new SqlParameter[]
			{
			new SqlParameter("@ID", iD)
			};
			Database db = new Database(sql,para);
			return db.ExecuteNoQuery();			
		}
			
        /// <summary>
		/// 更新实体
		/// <param name="oldProduct_Img">键值</param>
		/// <returns>返回该键值实体</returns>
		/// </summary>
		public int UpdateEntity(OldProduct_Img oldProduct_Img)
		{
			string sql ="UPDATE [OldProduct_Img] " + "SET " +
				"ProductID = @ProductID, " +
				"Number = @Number, " +
				"Url = @Url "  +
			"WHERE ID = @ID";
			
			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", oldProduct_Img.ID),
				new SqlParameter("@ProductID", oldProduct_Img.ProductID),
				new SqlParameter("@Number", oldProduct_Img.Number),
				new SqlParameter("@Url", oldProduct_Img.Url)
			};					
			Database db = new Database(sql,para);
			return db.ExecuteNoQuery();
		}
	}
}
