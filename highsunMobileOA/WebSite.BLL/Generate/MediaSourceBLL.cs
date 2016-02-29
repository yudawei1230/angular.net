using System;
using System.Collections.Generic;
using System.Text;
using WebSite.DAL;
using WebSite.Models;
using System.Data;

namespace WebSite.BLL
{
    public class MediaSourceBLL
    {
		/// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxID()
        {
            return new MediaSourceDAL().GetMaxID();
        }
		
		/// <summary>
        /// 得到记录总和
        /// </summary>
        public int GetCount(string strWhere)
        {
            return new MediaSourceDAL().GetCount(strWhere);
        }
		
		/// <summary>
		/// 查询实体是否存在
		/// <param name="iD">键值</param>
		/// <returns>返回该键值实体</returns>
		/// </summary>
        public bool IsHaveEntityByKey(int iD)
        {
            return new MediaSourceDAL().IsHaveEntityByKey(iD);
        }
		
		/// <summary>
		/// 根据键值查询该实体
		/// <param name="iD">键值</param>
		/// <returns>返回该键值实体</returns>
		/// </summary>
		public MediaSource FetchEntityByKey (int iD)
		{
			return new MediaSourceDAL().FetchEntityByKey(iD);	
		}
		
		/// <summary>
		/// 根据非ID键值查询该实体
		/// <param name="strWhere">条件语句</param>
		/// <returns>返回该键值实体</returns>
		/// </summary>		
		public MediaSource FetchEntityByNoKey(string strWhere)
		{
			return new MediaSourceDAL().FetchEntityByNoKey(strWhere);	
		}
		
		/// <summary>
		/// 查询所有实体        
		/// <returns>返回结果列表</returns>
		/// </summary>
        public IList<MediaSource> GetAllEntities()
        {
           return new MediaSourceDAL().GetAllEntities();	
        }
		
		/// <summary>
		/// 查询所有实体
        /// <param name="strWhere">条件语句</param>
		/// <returns>返回结果列表</returns>
		/// </summary>
        public IList<MediaSource> GetAllEntities(string strWhere)
        {
            return new MediaSourceDAL().GetAllEntities(strWhere);	
        }

		/// <summary>
		/// 查询所有实体返回DataTable
		/// <returns>返回DataTable</returns>
		/// </summary>
		public DataTable GetAllEntitiesToDataTable()
		{
			return new MediaSourceDAL().GetAllEntitiesToDataTable();	
		}
		
		/// <summary>
		/// 查询所有实体返回DataTable
		/// <returns>返回DataTable</returns>
        /// <param name="strWhere">条件语句</param>
		/// </summary>
		public DataTable GetAllEntitiesToDataTable(string strWhere)
		{
			return new MediaSourceDAL().GetAllEntitiesToDataTable(strWhere);	
		}
		
		/// 执行SQL语句 
		/// <param name="sql">SQL语句</param>
		/// <returns>返回查询结果实体列表</returns>
		/// </summary>        
        public IList<MediaSource> SearchBySql(string sql)
        {                     
           return new MediaSourceDAL().SearchBySql(sql);	
        }
		
		/// <summary>
		/// 新增实体并返回自动增长id
		/// <param name="mediaSource">实体</param>
		/// <returns>返回自动增长id</returns>
		/// </summary>
		public int InsertEntity(MediaSource mediaSource)
		{
           return new MediaSourceDAL().InsertEntity(mediaSource);		
		}

		/// <summary>
		/// 删除实体
		/// <param name="iD">实体</param>
		/// <returns>返回受影响行数</returns>
		/// </summary>
		public int DeleteEntityByKey(int iD)
		{          
			return new MediaSourceDAL().DeleteEntityByKey(iD);
		}		
		
		/// <summary>
		/// 更新实体
		/// <param name="mediaSource">键值</param>
		/// <returns>返回该键值实体</returns>
		/// </summary>
        public int UpdateEntity(MediaSource mediaSource)
        {
            return new MediaSourceDAL().UpdateEntity(mediaSource);
        }
    }
}
