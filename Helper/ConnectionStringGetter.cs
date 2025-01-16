using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerConsoleApplication.Helper
{
    internal static class ConnectionStringGetter
    {
        public static string GetConnString()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DataSource"]?.ConnectionString;
            return connectionString;
        }
    }
}
