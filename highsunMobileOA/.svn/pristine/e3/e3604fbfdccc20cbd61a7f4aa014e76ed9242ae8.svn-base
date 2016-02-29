using System;
using System.Collections.Generic;
using System.Text;
using WebSite.DbProxy.Config;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace WebSite.DbProxy
{

    /// <summary>
    /// 数据访问层（方便对SQL数据库的访问）<br/>
    /// 使用方法事例：<br/>
    /// /* 存储过程方式访问 */<br/>
    /// Database db=new Database(存储过程名称,DatabaseCommandType.StoredProcedure,参数没有可忽略);<br/>
    /// db.ExecuteQuery<返回类型>();用于返回该类型，还提供更多的数据访问方法，详情请查看帮助文档<br/><br/>
    /// /* SQL方式访问 */<br/>
    /// Database db=new Database(SQL语句,DatabaseCommandType.SQLCommand,参数没有可忽略);<br/>
    /// db.ExecuteQuery<返回类型>();用于返回该类型，还提供更多的数据访问方法，详情请查看帮助文档<br/><br/>
    /// 
    /// 注意：使用动态返回实体必须对实体进行映射:<br/>
    /// 映射事例：<br/>
    /// public class Text<br/>
    ///  {<br/>
    ///    [Column(ColumnName="PermissionsID")] //映射对应数据库的列，指定 [Column(ColumnName="PermissionsID")] 默认[Column]<br/>
    ///    public int PermissionsID { get; set; }<br/>
    ///  }<br/>
    /// </summary>
    public class Database
    {

        /// <summary>
        /// 程序命令
        /// </summary>
        private ProcedureCommand cmd = null;


        /// <summary>
        /// 构造函数（存储过程）
        /// </summary>
        /// <param name="procedureName">存储过程名称</param>
        /// <param name="values">参数（没有参数可以忽略）</param>
        public Database(string procedureName, params object[] values)
        {
            /// 存储过程类型
            cmd = CommandFactory.GetCommand(procedureName, values);
        }

        /// <summary>
        /// 构造函数（SQL语句）
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="para">参数（没有参数可以忽略）</param>
        public Database(string sql, SqlParameter[] para)
        {

            /// SQL语句类型
            cmd = CommandFactory.GetGetSQLCommand(sql, para);

        }

        public Database()
        {
        }


        /// <summary>
        /// 输出参数
        /// </summary>
        public object OutputValue
        {
            get
            {
                if (cmd.OutParameter == null)
                    throw new NullReferenceException("没有输出参数");

                return cmd.OutParameter.Value;
            }
        }

        /// <summary>
        /// 返回影响行数
        /// </summary>
        public int ReturnValue
        {
            get
            {
                return (int)cmd.ReturnParameter.Value;
            }
        }

        #region 获取数据流，数据集对象
        /// <summary>
        /// 查询数据库，返回结果集。<br/>
        /// 当结果集使用完后必须关闭，结果集所依赖的连接将自动关闭。
        /// </summary>
        /// <returns>结果集</returns>
        public SqlDataReader ExecuteReader()
        {
            SqlConnection conn = Configuration.Connection;
            SqlCommand sqlCmd = cmd.Command;
            sqlCmd.Connection = conn;

            conn.Open();
            return sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public object GetSingle()
        {
            SqlConnection connection = Configuration.Connection;
            SqlCommand sqlCmd = cmd.Command;
            sqlCmd.Connection = connection;
            try
            {
                connection.Open();
                object obj = sqlCmd.ExecuteScalar();
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    connection.Close();
                    return null;
                }
                else
                {
                    connection.Close();
                    return obj;
                }
               
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                connection.Close();
                throw new Exception(e.Message);
            }

        }

        /// <summary>
        ///  查询数据库，是否存在该记录<br/>
        /// </summary>
        /// <returns>返回true有该记录存在 false没有该记录存在</returns>
        public bool HaveExecuteReader()
        {
            string aa = Configuration.ConnectionString;
            SqlConnection conn = Configuration.Connection;
            SqlCommand sqlCmd = cmd.Command;
            sqlCmd.Connection = conn;
            conn.Open();
            using (SqlDataReader reader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                return reader.Read();
            }

        }
        /// <summary>
        /// 查询数据库,返回DataTable结果集合。<br/>
        ///  当结果集使用完后必须关闭，结果集所依赖的连接将自动关闭。
        /// </summary>
        /// <returns>返回DataTable</returns>
        public DataTable ExecuteDataTable()
        {

            using (SqlConnection conn = Configuration.Connection)
            {
                SqlCommand sqlCmd = cmd.Command;
                sqlCmd.Connection = conn;

                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(ds);
                return ds.Tables[0];
            }
        }


        public DataSet ExecuteDataSet()
        {
            using (SqlConnection conn = Configuration.Connection)
            {
                SqlCommand sqlCmd = cmd.Command;
                sqlCmd.Connection = conn;
                conn.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                return dataSet;
            }
        }
        #endregion

        #region 执行简单的增删改查
        /// <summary>
        /// 执行更新（增、删、改）
        /// </summary>
        /// <returns>影响的行数</returns>
        public int ExecuteNoQuery()
        {
            using (SqlConnection conn = Configuration.Connection)
            {
                SqlCommand sqlCmd = cmd.Command;

                sqlCmd.Connection = conn;

                conn.Open();
                return sqlCmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 执行更新（增、删、改）
        /// </summary>
        /// <returns>是否成功提交</returns>
        public bool ExecuteNoQuery(ArrayList SQLStringList)
        {
            using (SqlConnection conn = Configuration.Connection)
            {
                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Connection = conn;

                conn.Open();

                SqlTransaction tx = conn.BeginTransaction();
                sqlCmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            sqlCmd.CommandText = strsql;
                            sqlCmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                    return true;
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    tx.Rollback();
                    return false;
                }
            }
        }
        #endregion

        #region 强类型的查询
        /// <summary>
        /// 强类型列表查詢(存储过程)
        /// </summary>
        /// <typeparam name="T">T类型</typeparam>
        /// <returns>返回T类型列表</returns>
        public List<T> ExecuteQuery<T>() where T : new()
        {
            using (SqlConnection conn = Configuration.Connection)
            {
                SqlCommand sqlCmd = cmd.Command;

                sqlCmd.Connection = conn;

                List<T> items = new List<T>();
                conn.Open();
                using (SqlDataReader reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        T info = ObjectBuilder.Build<T>(reader);
                        items.Add(info);
                    }
                }
                conn.Close();
                return items;

            }
        }

        /// <summary>
        /// 强类型查询
        /// </summary>
        /// <typeparam name="T">T类型</typeparam>
        /// <returns>返回T类型列表</returns>
        public T ExecuteScalar<T>() where T : new()
        {
            using (SqlConnection conn = Configuration.Connection)
            {

                SqlCommand sqlCmd = cmd.Command;

                sqlCmd.Connection = conn;

                List<T> items = new List<T>();
                conn.Open();
                using (SqlDataReader reader = sqlCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return ObjectBuilder.Build<T>(reader);
                    }

                    return default(T);
                    //  throw new ArgumentException("找不到指定的数据");
                }

            }
        }
        #endregion

        #region 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。
        /// </summary>
        /// <returns>返回影响行数</returns>
        public int ExecuteIntScalar()
        {

            using (SqlConnection conn = Configuration.Connection)
            {
                conn.Open();
                SqlCommand sqlCmd = cmd.Command;

                sqlCmd.Connection = conn;

                return Convert.ToInt32(sqlCmd.ExecuteScalar());
            }

        }
        /// <summary>
        /// 执行参数化存储过程
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <param name="listParam"></param>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        public DataTable ExecuteFill(string sqlStr, List<SqlParameter> listParam, CommandType cmdType)
        {

            //数据集
            DataSet ds = new DataSet();
            SqlConnection conn = Configuration.Connection;
            conn.Open();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conn;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = sqlStr;
            if (listParam != null)
            {
                //清空参数
                sqlCmd.Parameters.Clear();
                //设置命令执行的SQL语句或存储过程
                foreach (SqlParameter sp in listParam)
                {
                    if (sp.Value == null)
                        sp.Value = DBNull.Value;
                    sqlCmd.Parameters.Add(sp);
                }
            }
            SqlDataAdapter _sqlAda = new SqlDataAdapter();
            _sqlAda.SelectCommand = sqlCmd;
            try
            {
                _sqlAda.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return new DataTable();
            }
        }

    }
        #endregion


}






