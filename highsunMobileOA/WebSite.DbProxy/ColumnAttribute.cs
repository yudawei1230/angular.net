using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.DbProxy
{
   
    /// <summary>
    /// 自定义特性，用于映射SQL列于实体列的映射
    /// </summary>
	public class ColumnAttribute : Attribute{
		
        /// <summary>
        /// 列的GET/SET访问
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
		public ColumnAttribute(){
		}
	}
}
