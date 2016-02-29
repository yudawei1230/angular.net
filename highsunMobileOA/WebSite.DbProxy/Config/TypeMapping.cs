using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace WebSite.DbProxy.Config
{
    /// <summary>
    /// C#类型与SQL数据库类型的匹配
    /// </summary>
	public static class TypeMapping {
        /// <summary>
        /// 根据C#类型返回数据库类型
        /// </summary>
        /// <param name="typeName">C#类型</param>
        /// <returns>数据库类型</returns>
		public static SqlDbType GetType(string typeName) {
			switch (typeName.ToLower()){
				case "int": return SqlDbType.Int;
				case "varchar": return SqlDbType.VarChar;
				case "bit": return SqlDbType.Bit;
				case "datetime": return SqlDbType.DateTime;
				case "float": return SqlDbType.Float;
				case "uniqueidentifier": return SqlDbType.UniqueIdentifier;
				case "text": return SqlDbType.Text;
				case "image": return SqlDbType.Image;
				case "timestamp": return SqlDbType.Timestamp;
				case "char": return SqlDbType.Char;
				case "nvarchar": return SqlDbType.NVarChar;
				case "bigint": return SqlDbType.BigInt;
				case "varbinary": return SqlDbType.VarBinary;
				case "binary": return SqlDbType.Binary;
				case "real": return SqlDbType.Real;
				case "tinyint": return SqlDbType.TinyInt;
				case "smallint": return SqlDbType.SmallInt;
				case "smalldatetime": return SqlDbType.SmallDateTime;
				case "money": return SqlDbType.Money;
				case "sql_variant": return SqlDbType.Variant;
				case "ntext": return SqlDbType.NText;
				case "decimal": return SqlDbType.Decimal;
				case "numeric": return SqlDbType.Decimal;
				case "smallmoney": return SqlDbType.SmallMoney;
				case "nchar": return SqlDbType.NChar;
				case "xml": return SqlDbType.Xml;
			}

			return SqlDbType.Int;
		}
	}
}
