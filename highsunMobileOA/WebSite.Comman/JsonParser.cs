using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data;


namespace WebSite.Comman
{
    /// <summary>
    /// JSON序列化类
    /// </summary>
    public class JsonParser
    {
        object _obj;
        private ArrayList Parsed = new ArrayList();//记录已经序列化的属性， 否则如果类内部的属性有递归关系， 会死循环
        List<string> excludePropertys = new List<string>(); //排除掉的属性

        StringBuilder builder = new StringBuilder("");
        /// <summary>
        /// 序列化一个对象
        /// </summary>
        /// <param name="obj"></param>
        public JsonParser(object obj)
        {
            _obj = obj;
        }
        /// <summary>
        /// 序列化一个对象
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="excludePropertys">排除的某些属性名 ， 如果类里面的属性有递归关系的话若没有排除父对象会不正常。</param>
        public JsonParser(object obj, params string[] excludePropertys)
        {
            _obj = obj;
            foreach (string s in excludePropertys)
            {
                this.excludePropertys.Add(s);
            }
        }
        private void BuildJsonObject(object obj)
        {
            if (Parsed.Contains(obj)) { builder.Append("{}"); return; }
            Parsed.Add(obj);

            if (obj != null)
            {
                if (obj is IEnumerable)
                {
                    BuildJsonArray(obj as IEnumerable);
                    return;
                }
                builder.Append("{");
                PropertyInfo[] propertyInfos;
                Type t = obj.GetType();
                object value;
                propertyInfos = t.GetProperties();
                foreach (PropertyInfo pi in propertyInfos)
                {
                    //是否排除
                    if (this.excludePropertys.Contains(pi.Name))
                    {
                        continue;
                        // builder.Append("_exclude:\"" + pi.Name + "\",");
                    }
                    else
                    {
                        if (pi.CanRead)
                        {
                            builder.Append(pi.Name);
                            builder.Append(":");
                            value = pi.GetValue(obj, null);
                            if (IsNumber(value))
                            {
                                builder.Append(value.ToString().ToLower());
                            }
                            // else if (IsDateTime(value))
                            //{
                            //   builder.Append("\""+DateTimeUtil.FormatDate((DateTime)value)+"\"");//------------
                            //}
                            else if (IsString(value))
                            {
                                builder.Append("\"" + ToJavaScriptString(value.ToString()) + "\"");
                            }
                            else if (value is IEnumerable)
                            {
                                BuildJsonArray(value as IEnumerable);
                            }
                            else
                            {
                                BuildJsonObject(value);
                            }
                            builder.Append(",");
                        }
                    }
                }

                if (builder[builder.Length - 1] == ',')
                    builder.Remove(builder.Length - 1, 1);
                builder.Append("}");
            }
            else
            {
                builder.Append("null");
            }
        }
        private void BuildJsonArray(IEnumerable ie)
        {
            IEnumerator ito = ie.GetEnumerator();
            builder.Append("[");
            bool hasItem = false;
            while (ito.MoveNext())
            {
                hasItem = true;
                if (IsNumber(ito.Current))
                {
                    builder.Append(ito.Current.ToString().ToLower() + ",");
                }
                else if (IsString(ito.Current))
                {
                    builder.Append("\"" + ToJavaScriptString(ito.Current.ToString()) + "\",");
                }
                else
                {
                    BuildJsonObject(ito.Current);
                    builder.Append(",");
                }
            }

            if (hasItem) builder.Remove(builder.Length - 1, 1);

            builder.Append("]");
        }


        /// <summary>
        /// 直接输出的属性（这里面包括 bool值）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool IsNumber(object obj)
        {
            if (obj is int
                || obj is long
                || obj is float
                || obj is double
                || obj is byte
                || obj is short
                || obj is decimal
                || obj is uint
                || obj is ulong
                || obj is ushort
                || obj is sbyte
                || obj is bool
                )
                return true;
            return false;
        }
        private static bool IsDateTime(object obj)
        {
            return obj is DateTime;
        }
        private static bool IsString(object obj)
        {
            return (obj is string
                || obj is char
                || obj is Guid
                || obj is DateTime
                || obj is Enum
                || obj is StringBuilder
                || obj is Uri
                );
        }

        /// <summary>
        /// 转到JS用的string ,(特殊字符串的转义)
        /// </summary>
        /// <param name="text">文本</param>
        /// <returns></returns>
        private string ToJavaScriptString(string text)
        {
            StringBuilder buffer = new StringBuilder(text);
            buffer.Replace("\\", @"\\");
            buffer.Replace("\n", @"\n");
            buffer.Replace("\r", @"\r");
            buffer.Replace("\"", @"\""");
            buffer.Replace("\f", @"\f");
            buffer.Replace("\t", @"\t");
            return buffer.ToString();
        }

        public override string ToString()
        {
            if (IsNumber(_obj))
            {
                return _obj.ToString();
            }
            if (IsString(_obj))
            {
                return "\"" + ToJavaScriptString(_obj.ToString()) + "\"";
            }
            BuildJsonObject(_obj);
            return builder.ToString();
        }


        /// <summary>
        /// 只生成一行，用于多表关联
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DtToJsonOther(DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j > 0)
                        jsonBuilder.Append(",");
                    jsonBuilder.Append(""+dt.Columns[j].ColumnName.ToLower() + ":\"" + dt.Rows[i][j].ToString().Replace("\t", " ").Replace("\r", " ").Replace("\n", " ").Replace("\"", "\\\'") + "\"");
                }
            }
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }

        /// <summary>
        /// Json特符字符过滤，参见http://www.json.org/
        /// </summary>
        /// <param name="sourceStr">要过滤的源字符串</param>
        /// <returns>返回过滤的字符串</returns>
        public static string JsonCharFilter(string sourceStr)
        {
            sourceStr = sourceStr.Replace("\\", "\\\\");
            sourceStr = sourceStr.Replace("\b", "\\\b");
            sourceStr = sourceStr.Replace("\t", "\\\t");
            sourceStr = sourceStr.Replace("\n", "\\\n");
            sourceStr = sourceStr.Replace("\n", "\\\n");
            sourceStr = sourceStr.Replace("\f", "\\\f");
            sourceStr = sourceStr.Replace("\r", "\\\r");
            return sourceStr.Replace("\"", "\\\"");
        }

        /// <summary>
        /// DataTable 转换成 JSON
        /// </summary>
        /// <param name="dt">需要转换的DataTable</param>
        /// <returns>JSON结构字符串</returns>
        public static string DtToJSON(DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{\"");
            jsonBuilder.Append(dt.TableName.ToString());
            jsonBuilder.Append("\":[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString());
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }

        //List转成json
        public static string ObjectToJson<T>(string jsonName, IList<T> IL)
        {
            StringBuilder Json = new StringBuilder();
            Json.Append("{\"" + jsonName + "\":[");
            if (IL.Count > 0)
            {
                for (int i = 0; i < IL.Count; i++)
                {
                    T obj = Activator.CreateInstance<T>();
                    Type type = obj.GetType();
                    PropertyInfo[] pis = type.GetProperties();
                    Json.Append("{");
                    for (int j = 0; j < pis.Length; j++)
                    {
                        Json.Append("\"" + pis[j].Name.ToString() + "\":\"" + pis[j].GetValue(IL[i], null) + "\"");
                        if (j < pis.Length - 1)
                        {
                            Json.Append(",");
                        }
                    }
                    Json.Append("}");
                    if (i < IL.Count - 1)
                    {
                        Json.Append(",");
                    }
                }
            }
            Json.Append("]}");
            return Json.ToString();
        }

    }
}
