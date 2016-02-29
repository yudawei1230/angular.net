using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace WebSite.DbProxy.Config
{
    
    /// <summary>
    /// 配置类
    /// </summary>
	public static class Configuration {
        
        /// <summary>
        /// 当前连接字符串（首次加载对字符串进行解密）
        /// </summary>
        private static string connString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString; 
 
        /// <summary>
        /// 获取当前连接字符串（已解密）
        /// </summary>
    	public static string ConnectionString {
			get {
                return connString;
			}

        }

        /// <summary>
        /// 获取Connection连接
        /// </summary>
		public static SqlConnection Connection {
			get {
                return new SqlConnection(ConnectionString);
			}
		}
        private static string quantitylv = ConfigurationManager.AppSettings["AQuantitylv"];
        public static string Quantitylv
        {
            get
            {
                return quantitylv;
            }
        }
	}
}
