using Microsoft.Data.SqlClient;

string connectionString = "Server = (LocalDB)\\FlashcardsLocalDB; Database = master; Trusted_Connection = True";

using var connection = new SqlConnection(connectionString);
try
{
    connection.Open();
    Console.WriteLine($"LocalDB connection successful.");
}
catch (Exception ex)
{
    Console.WriteLine($"Connection failed: {ex.Message}");
}
