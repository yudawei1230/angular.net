using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace WebSite.DALFactory
{
    public sealed class DataAccess
    {
        private static readonly string path = "WebSite.DAL";

        public static Object CreateInstance(string className)
        {
            string classname = path + "." + className;
            return Assembly.Load(path).CreateInstance(classname);
        }
    }
}
