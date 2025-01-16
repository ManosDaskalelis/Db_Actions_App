using Microsoft.Data.SqlClient;
using System.Configuration;

namespace ServerConsoleApplication.Helper
{
    internal static class Printer
    {
        public static void ResultPrinter(SqlCommand? command, StreamWriter? writer)
        {

            var saveDirectory = ConfigurationManager.AppSettings["SaveDirectory"];
            var saveFileName = ConfigurationManager.AppSettings["SaveFileName"];
            var saveFilePath = Path.Combine(saveDirectory, saveFileName);

            if (!Directory.Exists(saveDirectory))
            {
                Directory.CreateDirectory(saveDirectory);
            }

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        writer.Write($"{reader.GetName(i)} -- {reader[i].ToString()}\n");
                        Console.WriteLine($"{reader.GetName(i)} -- {reader[i].ToString()}\n");
                    }
                    writer.WriteLine();
                }
            }

        }
    }
}
