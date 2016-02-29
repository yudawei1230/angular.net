using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace WebSite.DbProxy.Config
{
   
    /// <summary>
    /// 程序命令
    /// </summary>
	internal class ProcedureCommand {
        /// <summary>
        /// 表示要对 SQL Server 数据库执行的一个 Transact-SQL 语句或存储过程。无法继承此类。
        /// </summary>
		public SqlCommand Command { get; set; }
        /// <summary>
        /// 输出参数
        /// </summary>
		public SqlParameter OutParameter { get; set; }
        /// <summary>
        /// 影响行数
        /// </summary>
		public SqlParameter ReturnParameter { get; set; }
	}
}
