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
	public class IndexImgDAL
	{	
		/// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxID()
        {
            string sql = "select max(ID)+1 from IndexImg";
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
            string sql = "select count(ID) from IndexImg";
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
			string sql = "SELECT ID FROM [IndexImg] WHERE ID = @ID";
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
		public IndexImg FetchEntityByKey (int iD)
		{
			string sql = "SELECT * FROM [IndexImg] WHERE ID = @ID";
			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", iD)
			};
			Database db = new Database(sql,para);
			return db.ExecuteScalar<IndexImg>();
		}
		
		/// <summary>
		/// 根据非ID键值查询该实体
		/// <param name="strWhere">条件语句</param>
		/// <returns>返回该键值实体</returns>
		/// </summary>		
		public IndexImg FetchEntityByNoKey(string strWhere)
		{
			string sql = "SELECT * FROM [IndexImg]";
            if (strWhere.Trim() != "")
            {
                sql += " where " + strWhere;
            }
            Database db = new Database(sql,null);
            return db.ExecuteScalar<IndexImg>();			
		}	
		
		/// <summary>
		/// 查询所有实体        
		/// <returns>返回结果列表</returns>
		/// </summary>
        public IList<IndexImg> GetAllEntities()
        {
			string sql = "SELECT * FROM [IndexImg] Order by ID Desc";
			Database db = new Database(sql,null);
			return db.ExecuteQuery<IndexImg>();			
        }
		
        /// <summary>
		/// 查询所有实体
        /// <param name="strWhere">条件语句</param>
		/// <returns>返回结果列表</returns>
		/// </summary>
        public IList<IndexImg> GetAllEntities(string strWhere)
        {
			string sql = "SELECT * FROM [IndexImg]";
			if (strWhere.Trim() != "")
            {
                sql += " where " + strWhere;                
            }
			sql += " Order by ID Desc";
			Database db = new Database(sql,null);
			return db.ExecuteQuery<IndexImg>();			
        }

		/// <summary>
		/// 查询所有实体返回DataTable
		/// <returns>返回DataTable</returns>
		/// </summary>
		public DataTable GetAllEntitiesToDataTable()
		{
			string sql = "SELECT * FROM [IndexImg] Order by ID Desc";
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
			string sql = "SELECT * FROM [IndexImg]";
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
        public IList<IndexImg> SearchBySql(string sql)
        {              
			Database db = new Database(sql,null);
			return db.ExecuteQuery<IndexImg>();
        }
		
		/// 执行SQL语句 
		/// <param name="sql">SQL语句</param>
		/// <param name="sql">参数数组</param>
		/// <returns>返回查询结果实体列表</returns>
		/// </summary>  
		public IList<IndexImg> SearchBySql( string sql, params SqlParameter[] values )
		{
			Database db = new Database(sql,values);
			return db.ExecuteQuery<IndexImg>();
		}
		
		/// <summary>
		/// 新增实体并返回自动增长id
		/// <param name="indexImg">实体</param>
		/// <returns>返回自动增长id</returns>
		/// </summary>
		public int InsertEntity(IndexImg indexImg)
		{
            string sql ="INSERT [IndexImg] (Img, Link, IsDel, IsSort)" +
			"VALUES (@Img, @Link, @IsDel, @IsSort);select @@IDENTITY";
			SqlParameter[] para = new SqlParameter[]
			{
         		new SqlParameter("@Img", indexImg.Img),
         		new SqlParameter("@Link", indexImg.Link),
         		new SqlParameter("@IsDel", indexImg.IsDel),
				new SqlParameter("@IsSort", indexImg.IsSort)
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
			string sql = "DELETE [IndexImg] WHERE ID = @ID";
			SqlParameter[] para = new SqlParameter[]
			{
			new SqlParameter("@ID", iD)
			};
			Database db = new Database(sql,para);
			return db.ExecuteNoQuery();			
		}
			
        /// <summary>
		/// 更新实体
		/// <param name="indexImg">键值</param>
		/// <returns>返回该键值实体</returns>
		/// </summary>
		public int UpdateEntity(IndexImg indexImg)
		{
			string sql ="UPDATE [IndexImg] " + "SET " +
				"Img = @Img, " +
				"Link = @Link, " +
				"IsDel = @IsDel, " +
				"IsSort = @IsSort "  +
			"WHERE ID = @ID";
			
			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", indexImg.ID),
				new SqlParameter("@Img", indexImg.Img),
				new SqlParameter("@Link", indexImg.Link),
				new SqlParameter("@IsDel", indexImg.IsDel),
				new SqlParameter("@IsSort", indexImg.IsSort)
			};					
			Database db = new Database(sql,para);
			return db.ExecuteNoQuery();
		}
	}
}
