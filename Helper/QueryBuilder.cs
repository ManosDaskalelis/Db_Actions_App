using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerConsoleApplication.Helper
{
    internal static class QueryBuilder
    {
        public static void ExecuteQuery(string connectionString, string database, string query, StreamWriter writer)
        {
            var builder = new SqlConnectionStringBuilder(connectionString);
            builder.InitialCatalog = database;

            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand(query, connection))
                    {
                        Printer.ResultPrinter(command, writer);
                    }

                }
                catch (Exception ex)
                {
                    writer.WriteLine($"Failed to execute query on {database}: {ex.Message}");
                    Console.WriteLine($"Failed to execute query on {database}: {ex.Message}");
                }
            }
        }
    }
}
