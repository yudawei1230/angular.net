using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace WebSite.BLL
{
    public interface IRecycle
    {
        string GetTableList(out string pages, out string serchBar, out string serchItem);
        int ClearItems(string items);
        int CancleItems(string items);
    }

    public sealed class DataAccess
    {
        private static readonly string path = "WebSite.BLL";

        /// <summary>
        /// 创建ProductCategory数据层接口
        /// </summary>
        public static IRecycle CreateFactory(string className)
        {
            string typeName = path + "." + className;
            return (IRecycle)Assembly.Load(path).CreateInstance(typeName);
        }
    }
}
