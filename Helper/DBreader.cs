using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerConsoleApplication.Helper
{
    internal static class DBreader
    {
        public static List<string> GetDatabases(string connectionString)
        {

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                Console.WriteLine("Connection string cannot be empty.");
                Environment.Exit(0);
            }

            var databases = new List<string>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT name FROM sys.databases WHERE state = 0", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!(reader.GetString(0).Contains("master") || reader.GetString(0).Contains("tempdb") || reader.GetString(0).Contains("model") || reader.GetString(0).Contains("msdb")))
                        {

                            databases.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return databases;
        }
    }
}
