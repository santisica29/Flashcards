using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections;

namespace Flashcards.Data;
internal class DatabaseManager
{
    private readonly IConfiguration _config;
    private readonly string? _connectionString;
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

    internal List<Stack> ViewAllStacks()
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        var selectQuery = "SELECT * FROM Stacks";
        var list = connection.Query<Stack>(selectQuery).ToList();

        return list;
    }
}
