using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerConsoleApplication.Helper
{
    internal static class SearchForTable
    {
        public static bool DoesTableExist(string connectionString, string database, string tableName)
        {
            var builder = new SqlConnectionStringBuilder(connectionString);
            builder.InitialCatalog = database;

            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                var query = @"SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @TableName";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TableName", tableName);

                    var result = command.ExecuteScalar();
                    return result != null;
                }
            }
        }
    }
}
