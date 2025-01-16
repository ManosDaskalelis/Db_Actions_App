
namespace ServerConsoleApplication.Helper
{
    internal static class QueryValidator
    {
        public static bool QueryChecker(string query)
        {
            var output = query.Split(" ");

            if (output[0].Contains("DROP") || output[0].ToUpper().Contains("TRUNCATE"))
            {
                Console.WriteLine("Cannot perform that action. ");
                Environment.Exit(1);
            }

            if (string.IsNullOrWhiteSpace(query))
            {
                Console.WriteLine("Query cannot be empty.");
                return false;
            }

           if (!(output[0].Contains("SELECT") || output[0].Contains("UPDATE") || output[0].Contains("INSERT") || output[0].Contains("DELETE")))
            {
                Console.WriteLine();
                Console.WriteLine("Invalid query");
                return false;
            }
           return true;
        }
    }
}
