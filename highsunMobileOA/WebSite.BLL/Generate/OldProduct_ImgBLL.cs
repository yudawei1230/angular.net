using System;
using System.Collections.Generic;
using System.Text;
using WebSite.DAL;
using WebSite.Models;
using System.Data;

namespace WebSite.BLL
{
    public class OldProduct_ImgBLL
    {
		/// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxID()
        {
            return new OldProduct_ImgDAL().GetMaxID();
        }
		
		/// <summary>
        /// 得到记录总和
        /// </summary>
        public int GetCount(string strWhere)
        {
            return new OldProduct_ImgDAL().GetCount(strWhere);
        }
		
		/// <summary>
		/// 查询实体是否存在
		/// <param name="iD">键值</param>
		/// <returns>返回该键值实体</returns>
		/// </summary>
        public bool IsHaveEntityByKey(int iD)
        {
            return new OldProduct_ImgDAL().IsHaveEntityByKey(iD);
        }
		
		/// <summary>
		/// 根据键值查询该实体
		/// <param name="iD">键值</param>
		/// <returns>返回该键值实体</returns>
		/// </summary>
		public OldProduct_Img FetchEntityByKey (int iD)
		{
			return new OldProduct_ImgDAL().FetchEntityByKey(iD);	
		}
		
		/// <summary>
		/// 根据非ID键值查询该实体
		/// <param name="strWhere">条件语句</param>
		/// <returns>返回该键值实体</returns>
		/// </summary>		
		public OldProduct_Img FetchEntityByNoKey(string strWhere)
		{
			return new OldProduct_ImgDAL().FetchEntityByNoKey(strWhere);	
		}
		
		/// <summary>
		/// 查询所有实体        
		/// <returns>返回结果列表</returns>
		/// </summary>
        public IList<OldProduct_Img> GetAllEntities()
        {
           return new OldProduct_ImgDAL().GetAllEntities();	
        }
		
		/// <summary>
		/// 查询所有实体
        /// <param name="strWhere">条件语句</param>
		/// <returns>返回结果列表</returns>
		/// </summary>
        public IList<OldProduct_Img> GetAllEntities(string strWhere)
        {
            return new OldProduct_ImgDAL().GetAllEntities(strWhere);	
        }

		/// <summary>
		/// 查询所有实体返回DataTable
		/// <returns>返回DataTable</returns>
		/// </summary>
		public DataTable GetAllEntitiesToDataTable()
		{
			return new OldProduct_ImgDAL().GetAllEntitiesToDataTable();	
		}
		
		/// <summary>
		/// 查询所有实体返回DataTable
		/// <returns>返回DataTable</returns>
        /// <param name="strWhere">条件语句</param>
		/// </summary>
		public DataTable GetAllEntitiesToDataTable(string strWhere)
		{
			return new OldProduct_ImgDAL().GetAllEntitiesToDataTable(strWhere);	
		}
		
		/// 执行SQL语句 
		/// <param name="sql">SQL语句</param>
		/// <returns>返回查询结果实体列表</returns>
		/// </summary>        
        public IList<OldProduct_Img> SearchBySql(string sql)
        {                     
           return new OldProduct_ImgDAL().SearchBySql(sql);	
        }
		
		/// <summary>
		/// 新增实体并返回自动增长id
		/// <param name="oldProduct_Img">实体</param>
		/// <returns>返回自动增长id</returns>
		/// </summary>
		public int InsertEntity(OldProduct_Img oldProduct_Img)
		{
           return new OldProduct_ImgDAL().InsertEntity(oldProduct_Img);		
		}

		/// <summary>
		/// 删除实体
		/// <param name="iD">实体</param>
		/// <returns>返回受影响行数</returns>
		/// </summary>
		public int DeleteEntityByKey(int iD)
		{          
			return new OldProduct_ImgDAL().DeleteEntityByKey(iD);
		}		
		
		/// <summary>
		/// 更新实体
		/// <param name="oldProduct_Img">键值</param>
		/// <returns>返回该键值实体</returns>
		/// </summary>
        public int UpdateEntity(OldProduct_Img oldProduct_Img)
        {
            return new OldProduct_ImgDAL().UpdateEntity(oldProduct_Img);
        }
    }
}
