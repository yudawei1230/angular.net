using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace WebSite.DbProxy.Config
{
    /// <summary>
    /// 存储过程参数信息
    /// </summary>
    internal class ParameterInfo
    {
        /// <summary>
        /// 存储过程名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        public SqlDbType Type { get; set; }
        /// <summary>
        /// 长度
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// 是都有输出参数
        /// </summary>
        public bool IsOutput { get; set; }
    }
}
