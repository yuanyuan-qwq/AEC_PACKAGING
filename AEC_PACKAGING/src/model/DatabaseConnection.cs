using MySql.Data.MySqlClient;

public class DatabaseConnection
{
    private static MySqlConnection connection = null;
    private static readonly object lockObject = new object();
    private static string connectionString = "Server=localhost;Database=AEC;User ID=root;Password=;";

    public static MySqlConnection GetConnection()
    {
        lock (lockObject)
        {
            if (connection == null)
            {
                connection = new MySqlConnection(connectionString);
            }

            return connection;
        }
    }
}
