# Db actions app

Db_Actions_App is a C# application that simplifies interacting with databases by enabling users to write connection strings, search for tables, and execute queries across multiple tables. This tool makes it easy to perform actions like querying, searching, and running custom SQL commands on a variety of database systems.
Additionally, the app prints the queries in the console and saves them to a text file for easier reading and reference


## Features 💡

- Connection String Setup: Easily configure your database connection by writing the connection string in the app.config file.
- Table Search: Input the name of a database table, and the app will search for it on the server.
- Multiple Table Query Execution: If the specified table is found in more than one location, the app allows you to run your custom SQL query on all matching tables.
- Flexible SQL Query: Execute any SQL query you provide, targeting multiple tables at once, to perform bulk operations.
- Console Output: The app prints the executed queries directly in the console, so you can see what is being run in real-time.
- Query Logging: All executed queries are saved to a .txt file for easier reading, sharing, and documentation.
- User-Friendly Interface: A clean, responsive, and intuitive interface that makes it simple to interact with your database.


### Getting Started
Prerequisites
- .NET Framework or .NET Core SDK installed on your system. Download the latest version from Microsoft's .NET website.
- A supported database system (e.g., SQL Server, MySQL, PostgreSQL).
### Installation
1. Clone the Repository:
```bash
git clone https://github.com/ManosDaskalelis/Db_Actions_App.git
```
2. Open the Project:
- Use Visual Studio or any other C# IDE.
- Open the .sln file in the repository root.
3. Restore NuGet Packages:
- In Visual Studio, go to Tools > NuGet Package Manager > Manage NuGet Packages for Solution and restore any missing packages.
4. Configure the Database:
- Update the appsettings.json file with your database connection details.
### Running the Application
1. Build the project in your IDE.
2. Run the application.
3. Use the provided interface to perform database operations like querying, inserting, and modifying data.
