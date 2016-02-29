using System;
using System.Collections.Generic;
using System.Text;
using WebSite.DAL;
using WebSite.Models;
using System.Data;

namespace WebSite.BLL
{
    public class IndustryBLL
    {
		/// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxID()
        {
            return new IndustryDAL().GetMaxID();
        }
		
		/// <summary>
        /// 得到记录总和
        /// </summary>
        public int GetCount(string strWhere)
        {
            return new IndustryDAL().GetCount(strWhere);
        }
		
		/// <summary>
		/// 查询实体是否存在
		/// <param name="iD">键值</param>
		/// <returns>返回该键值实体</returns>
		/// </summary>
        public bool IsHaveEntityByKey(int iD)
        {
            return new IndustryDAL().IsHaveEntityByKey(iD);
        }
		
		/// <summary>
		/// 根据键值查询该实体
		/// <param name="iD">键值</param>
		/// <returns>返回该键值实体</returns>
		/// </summary>
		public Industry FetchEntityByKey (int iD)
		{
			return new IndustryDAL().FetchEntityByKey(iD);	
		}
		
		/// <summary>
		/// 根据非ID键值查询该实体
		/// <param name="strWhere">条件语句</param>
		/// <returns>返回该键值实体</returns>
		/// </summary>		
		public Industry FetchEntityByNoKey(string strWhere)
		{
			return new IndustryDAL().FetchEntityByNoKey(strWhere);	
		}
		
		/// <summary>
		/// 查询所有实体        
		/// <returns>返回结果列表</returns>
		/// </summary>
        public IList<Industry> GetAllEntities()
        {
           return new IndustryDAL().GetAllEntities();	
        }
		
		/// <summary>
		/// 查询所有实体
        /// <param name="strWhere">条件语句</param>
		/// <returns>返回结果列表</returns>
		/// </summary>
        public IList<Industry> GetAllEntities(string strWhere)
        {
            return new IndustryDAL().GetAllEntities(strWhere);	
        }

		/// <summary>
		/// 查询所有实体返回DataTable
		/// <returns>返回DataTable</returns>
		/// </summary>
		public DataTable GetAllEntitiesToDataTable()
		{
			return new IndustryDAL().GetAllEntitiesToDataTable();	
		}
		
		/// <summary>
		/// 查询所有实体返回DataTable
		/// <returns>返回DataTable</returns>
        /// <param name="strWhere">条件语句</param>
		/// </summary>
		public DataTable GetAllEntitiesToDataTable(string strWhere)
		{
			return new IndustryDAL().GetAllEntitiesToDataTable(strWhere);	
		}
		
		/// 执行SQL语句 
		/// <param name="sql">SQL语句</param>
		/// <returns>返回查询结果实体列表</returns>
		/// </summary>        
        public IList<Industry> SearchBySql(string sql)
        {                     
           return new IndustryDAL().SearchBySql(sql);	
        }
		
		/// <summary>
		/// 新增实体并返回自动增长id
		/// <param name="industry">实体</param>
		/// <returns>返回自动增长id</returns>
		/// </summary>
		public int InsertEntity(Industry industry)
		{
           return new IndustryDAL().InsertEntity(industry);		
		}

		/// <summary>
		/// 删除实体
		/// <param name="iD">实体</param>
		/// <returns>返回受影响行数</returns>
		/// </summary>
		public int DeleteEntityByKey(int iD)
		{          
			return new IndustryDAL().DeleteEntityByKey(iD);
		}		
		
		/// <summary>
		/// 更新实体
		/// <param name="industry">键值</param>
		/// <returns>返回该键值实体</returns>
		/// </summary>
        public int UpdateEntity(Industry industry)
        {
            return new IndustryDAL().UpdateEntity(industry);
        }
    }
}
