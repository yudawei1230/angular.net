﻿using System;
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
	public class ComplaintDAL
	{	
		/// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxID()
        {
            string sql = "select max(ID)+1 from Complaint";
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
            string sql = "select count(ID) from Complaint";
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
			string sql = "SELECT ID FROM [Complaint] WHERE ID = @ID";
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
		public Complaint FetchEntityByKey (int iD)
		{
			string sql = "SELECT * FROM [Complaint] WHERE ID = @ID";
			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", iD)
			};
			Database db = new Database(sql,para);
			return db.ExecuteScalar<Complaint>();
		}
		
		/// <summary>
		/// 根据非ID键值查询该实体
		/// <param name="strWhere">条件语句</param>
		/// <returns>返回该键值实体</returns>
		/// </summary>		
		public Complaint FetchEntityByNoKey(string strWhere)
		{
			string sql = "SELECT * FROM [Complaint]";
            if (strWhere.Trim() != "")
            {
                sql += " where " + strWhere;
            }
            Database db = new Database(sql,null);
            return db.ExecuteScalar<Complaint>();			
		}	
		
		/// <summary>
		/// 查询所有实体        
		/// <returns>返回结果列表</returns>
		/// </summary>
        public IList<Complaint> GetAllEntities()
        {
			string sql = "SELECT * FROM [Complaint] Order by ID Desc";
			Database db = new Database(sql,null);
			return db.ExecuteQuery<Complaint>();			
        }
		
        /// <summary>
		/// 查询所有实体
        /// <param name="strWhere">条件语句</param>
		/// <returns>返回结果列表</returns>
		/// </summary>
        public IList<Complaint> GetAllEntities(string strWhere)
        {
			string sql = "SELECT * FROM [Complaint]";
			if (strWhere.Trim() != "")
            {
                sql += " where " + strWhere;                
            }
			sql += " Order by ID Desc";
			Database db = new Database(sql,null);
			return db.ExecuteQuery<Complaint>();			
        }

		/// <summary>
		/// 查询所有实体返回DataTable
		/// <returns>返回DataTable</returns>
		/// </summary>
		public DataTable GetAllEntitiesToDataTable()
		{
			string sql = "SELECT * FROM [Complaint] Order by ID Desc";
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
			string sql = "SELECT * FROM [Complaint]";
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
        public IList<Complaint> SearchBySql(string sql)
        {              
			Database db = new Database(sql,null);
			return db.ExecuteQuery<Complaint>();
        }
		
		/// 执行SQL语句 
		/// <param name="sql">SQL语句</param>
		/// <param name="sql">参数数组</param>
		/// <returns>返回查询结果实体列表</returns>
		/// </summary>  
		public IList<Complaint> SearchBySql( string sql, params SqlParameter[] values )
		{
			Database db = new Database(sql,values);
			return db.ExecuteQuery<Complaint>();
		}
		
		/// <summary>
		/// 新增实体并返回自动增长id
		/// <param name="complaint">实体</param>
		/// <returns>返回自动增长id</returns>
		/// </summary>
		public int InsertEntity(Complaint complaint)
		{
            string sql ="INSERT [Complaint] (Category, Ask, AskTime, RealName, Phone, Img0, Img1, Img2, AskDetail, AnswerTime, AnswerDetail, IsExamine, IsDel)" +
			"VALUES (@Category, @Ask, @AskTime, @RealName, @Phone, @Img0, @Img1, @Img2, @AskDetail, @AnswerTime, @AnswerDetail, @IsExamine, @IsDel);select @@IDENTITY";
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
         		new SqlParameter("@AnswerTime", complaint.AnswerTime),
         		new SqlParameter("@AnswerDetail", complaint.AnswerDetail),
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

		/// <summary>
		/// 删除实体
		/// <param name="iD">实体</param>
		/// <returns>返回受影响行数</returns>
		/// </summary>
		public int DeleteEntityByKey(int iD)
		{    
			string sql = "DELETE [Complaint] WHERE ID = @ID";
			SqlParameter[] para = new SqlParameter[]
			{
			new SqlParameter("@ID", iD)
			};
			Database db = new Database(sql,para);
			return db.ExecuteNoQuery();			
		}
			
        /// <summary>
		/// 更新实体
		/// <param name="complaint">键值</param>
		/// <returns>返回该键值实体</returns>
		/// </summary>
		public int UpdateEntity(Complaint complaint)
		{
			string sql ="UPDATE [Complaint] " + "SET " +
				"Category = @Category, " +
				"Ask = @Ask, " +
				"AskTime = @AskTime, " +
				"RealName = @RealName, " +
				"Phone = @Phone, " +
				"Img0 = @Img0, " +
				"Img1 = @Img1, " +
				"Img2 = @Img2, " +
				"AskDetail = @AskDetail, " +
				"AnswerTime = @AnswerTime, " +
				"AnswerDetail = @AnswerDetail, " +
				"IsExamine = @IsExamine, " +
				"IsDel = @IsDel "  +
			"WHERE ID = @ID";
			
			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", complaint.ID),
				new SqlParameter("@Category", complaint.Category),
				new SqlParameter("@Ask", complaint.Ask),
				new SqlParameter("@AskTime", complaint.AskTime),
				new SqlParameter("@RealName", complaint.RealName),
				new SqlParameter("@Phone", complaint.Phone),
				new SqlParameter("@Img0", complaint.Img0),
				new SqlParameter("@Img1", complaint.Img1),
				new SqlParameter("@Img2", complaint.Img2),
				new SqlParameter("@AskDetail", complaint.AskDetail),
				new SqlParameter("@AnswerTime", complaint.AnswerTime),
				new SqlParameter("@AnswerDetail", complaint.AnswerDetail),
				new SqlParameter("@IsExamine", complaint.IsExamine),
				new SqlParameter("@IsDel", complaint.IsDel)
			};					
			Database db = new Database(sql,para);
			return db.ExecuteNoQuery();
		}
	}
}