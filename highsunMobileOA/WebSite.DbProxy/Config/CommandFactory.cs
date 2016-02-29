using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.CompilerServices;

namespace WebSite.DbProxy.Config
{

    /// <summary>
    /// CommandFactory用于初始化构造查询条件
    /// </summary>

    internal static class CommandFactory
    {

        /// <summary>
        /// 用于缓存存储过程信息,如该存储过程的参数个数，类型等
        /// </summary>
        private static Dictionary<string, ParameterInfo[]> parameters = new Dictionary<string, ParameterInfo[]>();

        /// <summary>
        /// 创建用于执行指定存储过程的ProcedureCommand
        /// </summary>
        /// <param name="procedureName">存储过程名</param>
        /// <param name="values">参数的值</param>
        /// <returns>ProcedureCommand</returns>
        /// 
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ProcedureCommand GetCommand(string procedureName, object[] values)
        {


            if (!parameters.ContainsKey(procedureName))
            {
                parameters.Add(procedureName, GetParameters(procedureName));
            }


            ParameterInfo[] pis = parameters[procedureName];
            if (values != null && pis.Length != values.Length)
                throw new ArgumentException(String.Format("与存储过程{0}要求的参数个数{1}不一致", procedureName, pis.Length));

            ProcedureCommand proCmd = new ProcedureCommand();

            SqlCommand sqlCmd = new SqlCommand(procedureName);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            SqlParameterCollection ps = sqlCmd.Parameters;
            // 为当前命令（SqlCommand）添加参数
            for (int i = 0; i < pis.Length; i++)
            {
                ParameterInfo item = pis[i];

                SqlParameter info = ps.Add(item.Name, item.Type, item.Length);

                info.Value = values[i] == null ? DBNull.Value : values[i];

                if (item.IsOutput)
                {
                    info.Direction = ParameterDirection.Output;
                    // 记录输出参数
                    proCmd.OutParameter = info;
                }
            }
            // 为当前命令（SqlCommand）添加返回值
            SqlParameter returnParam = ps.Add("@ReturnValue", SqlDbType.Int);
            returnParam.Direction = ParameterDirection.ReturnValue;
            proCmd.ReturnParameter = returnParam;

            proCmd.Command = sqlCmd;
            return proCmd;
        }




        /// <summary>
        /// 从数据库获取指定存储过程的参数列表。
        /// </summary>
        /// <param name="procedureName">存储过程名</param>
        /// <returns>参数列表</returns>
        private static ParameterInfo[] GetParameters(string procedureName)
        {
            string sql = String.Format(SQLResource.SPParameters, procedureName);
            using (SqlConnection conn = Configuration.Connection)
            {
                SqlCommand cmd = new SqlCommand(sql, conn);

                List<ParameterInfo> pis = new List<ParameterInfo>();

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ParameterInfo info = new ParameterInfo()
                        {
                            Name = reader.GetString(0),
                            Type = TypeMapping.GetType(reader.GetString(1)),
                            Length = reader.GetInt32(2),
                            IsOutput = reader.GetBoolean(3)
                        };

                        pis.Add(info);
                    }
                }

                return pis.ToArray();
            }
        }

        //////////////////////////////////////////////// 2009-10-6 （peak） 扩展 ////////////////////////////////////////////////


        /// <summary>
        /// 分配SqlCommand内容(SQL)
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="values">参数</param>
        /// <returns>返回ProcedureCommand对象</returns>
        public static ProcedureCommand GetGetSQLCommand(string sql, SqlParameter[] para)
        {
            #region///分配SqlCommand内容(SQL)
            ProcedureCommand proComm = new ProcedureCommand();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            if (para != null)
            {
                foreach (SqlParameter parm in para)
                {
                    if (parm.Value == null)
                        parm.Value = DBNull.Value;
                    cmd.Parameters.Add(parm);
                }
            }
            proComm.Command = cmd;
            return proComm;
            #endregion
        }


    }
}
