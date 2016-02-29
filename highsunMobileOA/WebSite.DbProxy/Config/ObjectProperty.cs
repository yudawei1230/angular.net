using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace WebSite.DbProxy.Config
{
    
    /// <summary>
    /// 配置类
    /// </summary>
	internal class ObjectProperty {

        /// <summary>
        /// 发现属性 (Property) 的属性 (Attribute) 并提供对属性 (Property) 元数据的访问。
        /// </summary>
		public PropertyInfo Property { get; set; }
        /// <summary>
        /// 列名
        /// </summary>
		public string ColumnName { get; set; }
	}
}
