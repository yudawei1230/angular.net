using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace WebSite.DbProxy.Config
{
    
    /// <summary>
    /// 动态创建对象
    /// </summary>
	internal static class ObjectBuilder {

        /// <summary>
        /// 用户缓存实体类型映射
        /// </summary>
		private static Dictionary<Type, ObjectProperty[]> _types = new Dictionary<Type, ObjectProperty[]>();

        /// <summary>
        /// 根据数据动态返回对象
        /// </summary>
        /// <typeparam name="T">T类型</typeparam>
        /// <param name="reader">SqlDataReader对象</param>
        /// <returns>返回T类型</returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
		public static T Build<T>(SqlDataReader reader) where T : new() {
			Type targetType = typeof(T);
			if (!_types.ContainsKey(targetType)) {
				_types.Add(targetType, GetProperties(targetType));
			}

			ObjectProperty[] properties = _types[targetType];
			T obj = (T)Activator.CreateInstance(targetType);
			foreach (ObjectProperty prop in properties) {
				int colIndex = reader.GetOrdinal(prop.ColumnName);
				object val = GetValue(reader, colIndex, prop.Property.PropertyType);

				prop.Property.SetValue(obj, val, null);
			}

			return obj;
		}

        /// <summary>
        /// 根据数据库列获取对象
        /// </summary>
        /// <param name="reader">SqlDataReader对象</param>
        /// <param name="colIndex">列索引</param>
        /// <param name="colType">列类型</param>
        /// <returns>返回object对象</returns>
		private static object GetValue(SqlDataReader reader, int colIndex, Type colType) {
			if (colType == typeof(Int32))
				return reader.IsDBNull(colIndex) ? 0 : reader.GetInt32(colIndex);
			if (colType == typeof(String))
				return reader.IsDBNull(colIndex) ? null : reader.GetString(colIndex);
			if (colType == typeof(DateTime))
				return reader.IsDBNull(colIndex) ? DateTime.MinValue : reader.GetDateTime(colIndex);
			if (colType == typeof(Boolean))
				return reader.IsDBNull(colIndex) ? false : reader.GetBoolean(colIndex);
			if (colType == typeof(Guid))
				return reader.IsDBNull(colIndex) ? Guid.Empty : reader.GetGuid(colIndex);

			if (colType == typeof(float))
				return reader.IsDBNull(colIndex) ? 0 : reader.GetFloat(colIndex);

			return reader.IsDBNull(colIndex) ? null : reader.GetValue(colIndex);
		}

        /// <summary>
        /// 用于匹配实体属性类型
        /// </summary>
        /// <param name="targetType">当前类型</param>
        /// <returns>返回匹配属性信息</returns>
		private static ObjectProperty[] GetProperties(Type targetType) {
			PropertyInfo[] properties = targetType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			if (properties == null || properties.Length < 1)
				throw new ArgumentException("该类型没有合适的属性");

			List<ObjectProperty> result = new List<ObjectProperty>(properties.Length);

			foreach (PropertyInfo item in properties) {
				ColumnAttribute attr = (ColumnAttribute)Attribute.GetCustomAttribute(item, typeof(ColumnAttribute));
				if (attr !=null ){
					ObjectProperty prop = new ObjectProperty();
					prop.Property = item;

					if(String.IsNullOrEmpty(attr.ColumnName)){
						prop.ColumnName = item.Name;
					}else{
						prop.ColumnName = attr.ColumnName;
					}

					result.Add(prop);
				}
			}

			return result.ToArray();
		}
	}
}
