using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Windows.Forms;

using AEC_PACKAGING.src.model;
using AEC_PACKAGING.src.view;

namespace AEC_PACKAGING.src.presenter
{
    internal class ClientPresenter
    {
        private MySQLDatabase db;

        public ClientPresenter()
        {
            db = new MySQLDatabase();
        }

        public bool ValidateClientData(string companyName, string companyAddress, string companyNum, string faxNum, string picName, string picNum, string picEmail, string staffID, out string errorMessage)
        {
            errorMessage = "";

            // Check for empty fields
            if (string.IsNullOrEmpty(companyName) || string.IsNullOrEmpty(companyAddress) || string.IsNullOrEmpty(companyNum) ||
                string.IsNullOrEmpty(picName) || string.IsNullOrEmpty(picNum) || string.IsNullOrEmpty(picEmail))
            {
                errorMessage = "Please fill in all required fields.";
                return false;
            }

            // Validate Staff ID
            if (!string.IsNullOrEmpty(staffID) && !int.TryParse(staffID, out _))
            {
                errorMessage = "Staff ID must be a valid integer.";
                return false;
            }

            return true; // Validation passed
        }


        public bool AddClient(Client client)
        {
            try
            {
                string query = $"INSERT INTO Client (Company_name, Company_address, Company_num, Fax_num, PIC_name, PIC_num, PIC_email, StaffID) VALUES " +
                               $"('{client.Company_name}', '{client.Company_address}', '{client.Company_num}', '{client.Fax_num}', '{client.PIC_name}', " +
                               $"'{client.PIC_num}', '{client.PIC_email}', {client.StaffID})";

                // Execute INSERT query
                db.ExecuteNonQuery(query);

                return true; // Operation successful
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding Client: {ex.Message}");
                return false; // Operation failed
            }
        }

        public bool UpdateClient(Client client)
        {

            try
            {
                string query = $"UPDATE Client SET Company_name = '{client.Company_name}', Company_address = '{client.Company_address}', Company_num = '{client.Company_num}', " +
                               $"Fax_num = '{client.Fax_num}', PIC_name = '{client.PIC_name}', PIC_num = '{client.PIC_num}', PIC_email = '{client.PIC_email}', StaffID = {client.StaffID} " +
                               $"WHERE ClientID = {client.ClientID}";

                // Execute UPDATE query
                int rowsAffected = db.ExecuteNonQuery(query);

                // Check if any rows were affected
                if (rowsAffected > 0)
                {
                    return true; // Update successful
                }
                else
                {
                    MessageBox.Show("No rows were affected, update failed");
                    return false; // No rows were affected, update failed
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating client: {ex.Message}");
                return false; // Update failed due to exception
            }
        }


        // To delete client by clientID
        public bool DeleteClient(int clientID)
        {
            try
            {
                // Construct DELETE query
                string query = $"DELETE FROM Client WHERE ClientID = {clientID}";

                // Execute DELETE query
                int rowsAffected = db.ExecuteNonQuery(query);

                // Check if any rows were affected
                if (rowsAffected > 0)
                {
                    return true; // Deletion successful
                }
                else
                {
                    MessageBox.Show($"Error deleting client: ClientID not found");
                    return false; // No rows were affected, deletion failed 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting client: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Deletion failed due to exception
            }
        }


        public List<Client> GetAllClients()
        {
            List<Client> clientList = new List<Client>();

            // Construct SELECT query
            string query = "SELECT * FROM Client";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                while (reader.Read())
                {
                    // Create a new Client object and populate it with data from the database
                    Client client = new Client
                    {
                        ClientID = reader.GetInt32("ClientID"),
                        Company_name = reader.GetString("Company_name"),
                        Company_address = reader.GetString("Company_address"),
                        Company_num = reader.GetString("Company_num"),
                        Fax_num = reader.GetString("Fax_num"),
                        PIC_name = reader.GetString("PIC_name"),
                        PIC_num = reader.GetString("PIC_num"),
                        PIC_email = reader.GetString("PIC_email"),
                        StaffID = reader.GetInt32("StaffID")
                    };

                    // Add the client object to the list
                    clientList.Add(client);
                }
            }

            return clientList;
        }


        public Client GetClientByID(int clientID)
        {
            // Initialize a Client object to store the result
            Client client = null;

            // Construct the SQL query to select client by ClientID
            string query = $"SELECT * FROM Client WHERE ClientID = {clientID}";

            // Execute the query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if there are rows returned
                if (reader.Read())
                {
                    // Create a new Client object and populate it with data from the database
                    client = new Client
                    {
                        ClientID = reader.GetInt32("ClientID"),
                        Company_name = reader.GetString("Company_name"),
                        Company_address = reader.GetString("Company_address"),
                        Company_num = reader.GetString("Company_num"),
                        Fax_num = reader.GetString("Fax_num"),
                        PIC_name = reader.GetString("PIC_name"),
                        PIC_num = reader.GetString("PIC_num"),
                        PIC_email = reader.GetString("PIC_email"),
                        StaffID = reader.GetInt32("StaffID")
                    };
                }
            }

            // Return the client object (might be null if no client found with the given ClientID)
            return client;
        }

        public List<Client> GetClientsByName(string companyName)
        {
            List<Client> clientList = new List<Client>();

            // Construct SELECT query
            string query = $"SELECT * FROM Client WHERE Company_name LIKE '%{companyName}%'";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                while (reader.Read())
                {
                    // Create a new Client object and populate it with data from the database
                    Client client = new Client
                    {
                        ClientID = reader.GetInt32("ClientID"),
                        Company_name = reader.GetString("Company_name"),
                        Company_address = reader.GetString("Company_address"),
                        Company_num = reader.GetString("Company_num"),
                        Fax_num = reader.GetString("Fax_num"),
                        PIC_name = reader.GetString("PIC_name"),
                        PIC_num = reader.GetString("PIC_num"),
                        PIC_email = reader.GetString("PIC_email"),
                        StaffID = reader.GetInt32("StaffID")
                    };

                    // Add the client object to the list
                    clientList.Add(client);
                }
            }

            return clientList;
        }

        public List<Client> GetClientsByPICName(string picName)
        {
            List<Client> clientList = new List<Client>();

            // Construct SELECT query
            string query = $"SELECT * FROM Client WHERE PIC_name LIKE '%{picName}%'";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                while (reader.Read())
                {
                    // Create a new Client object and populate it with data from the database
                    Client client = new Client
                    {
                        ClientID = reader.GetInt32("ClientID"),
                        Company_name = reader.GetString("Company_name"),
                        Company_address = reader.GetString("Company_address"),
                        Company_num = reader.GetString("Company_num"),
                        Fax_num = reader.GetString("Fax_num"),
                        PIC_name = reader.GetString("PIC_name"),
                        PIC_num = reader.GetString("PIC_num"),
                        PIC_email = reader.GetString("PIC_email"),
                        StaffID = reader.GetInt32("StaffID")
                    };

                    // Add the client object to the list
                    clientList.Add(client);
                }
            }

            return clientList;
        }
    }
}
