using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Flashcards.Data;
internal class DatabaseManager
{
    private readonly IConfiguration _config;
    private readonly string _connectionString;
    public DatabaseManager()
    {
        _config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

        _connectionString = _config.GetConnectionString("AppDatabase");
    }

    internal void ConnectToDatabase()
    {

        try
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            Console.WriteLine("success");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        

    }
}
