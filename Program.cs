using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServerConsoleApplication.Helper;
using System.Configuration;


namespace ServerConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            var saveDirectory = ConfigurationManager.AppSettings["SaveDirectory"];
            var saveFileName = ConfigurationManager.AppSettings["SaveFileName"];
            var saveFilePath = Path.Combine(saveDirectory, saveFileName);

            try
            {
                if (!Directory.Exists(saveDirectory))
                {
                    Directory.CreateDirectory(saveDirectory);
                }

                var databases = DBreader.GetDatabases(ConnectionStringGetter.GetConnString());

                Console.WriteLine("Databases found on the server:");
                foreach (var db in databases)
                {
                    Console.WriteLine($"- {db}");
                }
                while (true)
                {
                    Console.WriteLine("\nEnter the name of the Table\n");
                    var tableName = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(tableName))
                    {
                        Console.WriteLine($"{tableName} cannot be empty");
                        return;
                    }

                    Console.WriteLine("\nEnter the query you want to run on all databases:");
                    var query = Console.ReadLine();
                    if (!QueryValidator.QueryChecker(query.ToUpper()))
                    {
                        continue;
                    }


                    using (var writer = new StreamWriter(saveFilePath))
                    {
                        foreach (var database in databases)
                        {

                            if (SearchForTable.DoesTableExist(ConnectionStringGetter.GetConnString(), database, tableName))
                            {
                                Console.WriteLine($"\nExecuting query on db --- {database}\n");
                                writer.WriteLine($"\nExecuting query on db --- {database}\n");
                                QueryBuilder.ExecuteQuery(ConnectionStringGetter.GetConnString(), database, query, writer);
                                writer.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine($"{tableName} does not exist in {database}");
                                writer.WriteLine($"{tableName} does not exist in {database}");
                            }
                        }
                    }

                    Console.WriteLine($"\nResults have been successfully saved to: {saveFilePath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
