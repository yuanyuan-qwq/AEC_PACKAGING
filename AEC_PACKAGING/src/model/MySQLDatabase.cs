using System;
using MySql.Data.MySqlClient;

namespace AEC_PACKAGING.src.model
{
    public class MySQLDatabase
    {
        private string connectionString;

        public MySQLDatabase()
        {
            // Create connection string
            connectionString = "Server=127.0.0.1;Database=aec;user=root;password=;";
            //connectionString = $"Server= 192.168.1.107; Database=aec;Uid=aec8888;Pwd=123456;Convert Zero Datetime=True;Allow Zero Datetime=True";
        }

        public MySqlConnection GetConnection()
        {
            // Create and return a new MySqlConnection object using the connection string
            return new MySqlConnection(connectionString);
        }

        public int ExecuteNonQuery(string query)
        {
            int rowsAffected = 0;
            // Create a MySqlConnection object
            using (var connection = GetConnection())
            {
                // Open the connection
                connection.Open();

                // Create a MySqlCommand object
                using (var command = new MySqlCommand(query, connection))
                {
                    // Execute the query and get the number of affected rows
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

        public object ExecuteScalar(string query)
        {
            // Create a MySqlConnection object
            using (var connection = GetConnection())
            {
                // Open the connection
                connection.Open();

                // Create a MySqlCommand object
                using (var command = new MySqlCommand(query, connection))
                {
                    // Execute the query and return the result
                    return command.ExecuteScalar();
                }
            }
        }

        public MySqlDataReader ExecuteQuery(string query)
        {
            // Create a MySqlConnection object
            var connection = GetConnection();

            // Open the connection
            connection.Open();

            // Create a MySqlCommand object
            var command = new MySqlCommand(query, connection);

            // Execute the query and return the MySqlDataReader
            return command.ExecuteReader();
        }
    }
}
