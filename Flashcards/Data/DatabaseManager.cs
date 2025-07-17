using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections;
using Flashcards.Models;

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

    internal List<CardStack> GetAllStacks()
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        var selectQuery = "SELECT * FROM Stacks";
        var list = connection.Query<CardStack>(selectQuery).ToList();

        return list;
    }

    internal int CreateStack(CardStack newStack)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        var createQuery = $"INSERT INTO Stacks (Name) VALUES (@Name)";

        var affectedRows = connection.Execute(createQuery, newStack);
        return affectedRows;
    }

    internal int DeleteStack(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        var deleteQuery = "DELETE FROM Stacks WHERE Id = @Id";
        
        return connection.Execute(deleteQuery, new {Id = id});
    }
}
