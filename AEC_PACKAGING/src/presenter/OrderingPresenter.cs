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
    internal class OrderingPresenter
    {
        private MySQLDatabase db;
        public OrderingPresenter()
        {
            db = new MySQLDatabase();
        }

        public bool ValidateOrderData(string staffID, string clientID, string orderDate, string transportationCost, string status, out string errorMessage)
        {
            errorMessage = "";

            // Check for required fields
            if (string.IsNullOrEmpty(staffID) || string.IsNullOrEmpty(clientID) || string.IsNullOrEmpty(orderDate) || string.IsNullOrEmpty(transportationCost) || string.IsNullOrEmpty(status))
            {
                errorMessage = "Please fill in all required Order fields.";
                return false;
            }

            // Validate orderID, staffID, and clientID
            if (!int.TryParse(staffID, out _) || !int.TryParse(clientID, out _))
            {
                errorMessage = "staff ID, and client ID must be valid integers.";
                return false;
            }

            // Validate transportation cost and status
            if (!double.TryParse(transportationCost, out _))
            {
                errorMessage = "Transportation cost must be valid numbers.";
                return false;
            }

            // Add more validation as needed...

            return true; // Validation passed
        }


        public bool AddOrdering(Ordering order)
        {
            try
            {
                string formattedOrderDate = order.Order_date.ToString("yyyy-MM-dd");

                string query = $"INSERT INTO Ordering (StaffID, ClientID, Order_date, Transportation_cost, Status) VALUES " +
                               $"({order.StaffID}, {order.ClientID}, '{formattedOrderDate}', {order.Transportation_cost}, '{order.Status}')";

                // Execute INSERT query
                db.ExecuteNonQuery(query);

                // If execution reaches this point, insertion was successful
                return true;
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., display an error message or log the exception)
                MessageBox.Show($"Error adding Ordering: {ex.Message}");

                // Return false to indicate failure
                return false;
            }
        }


        public bool UpdateOrdering(Ordering order)
        {
            try
            {
                string formattedOrderDate = order.Order_date.ToString("yyyy-MM-dd");

                string query = $"UPDATE Ordering SET StaffId = {order.StaffID}, ClientID = {order.ClientID}, Order_date = '{formattedOrderDate}', " +
                    $"Transportation_cost = {order.Transportation_cost}, Status = '{order.Status}' WHERE OrderID = {order.OrderID}";

                // Execute UPDATE query
                int rowsAffected = db.ExecuteNonQuery(query);

                // Check if any rows were affected
                if (rowsAffected > 0)
                {
                    return true; // Update successful
                }
                else
                {
                    return false; // No rows were affected, update failed
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating Ordering: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Update failed due to exception
            }
        }


        public bool DeleteOrdeList(int orderID) //remove ordering child
        {
            try
            {
                // Construct DELETE query
                string query = $"DELETE FROM order_list WHERE OrderID = {orderID}";

                // Execute DELETE query
                int rowsAffected = db.ExecuteNonQuery(query);

                // Check if any rows were affected
                if (rowsAffected > 0)
                {
                    return true; // Deletion successful
                }
                else
                {
                    return true; // order with empty orderlist
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting order list: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Deletion failed due to exception
            }
        }

        public bool DeleteOrdering(int orderID)     //remove ordering
        {
            if (DeleteOrdeList(orderID))
            {
                try
                {
                    // Construct DELETE query
                    string query = $"DELETE FROM Ordering WHERE OrderID = {orderID}";

                    // Execute DELETE query
                    int rowsAffected = db.ExecuteNonQuery(query);

                    // Check if any rows were affected
                    if (rowsAffected > 0)
                    {
                        return true; // Deletion successful
                    }
                    else
                    {
                        MessageBox.Show($"Error deleting ordering: OrderID not found");
                        return false; // No rows were affected, deletion failed 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting ordering: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false; // Deletion failed due to exception
                }
            }
            else
            {
                return false;
            }
        }


        public List<Ordering> GetAllOrders()
        {
            List<Ordering> orderList = new List<Ordering>();

            // Construct SELECT query
            string query = "SELECT * FROM Ordering";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                while (reader.Read())
                {
                    // Create a new Ordering object and populate it with data from the database
                    Ordering order = new Ordering
                    {
                        OrderID = reader.GetInt32("OrderID"),
                        StaffID = reader.GetInt32("StaffID"),
                        ClientID = reader.GetInt32("ClientID"),
                        Order_date = reader.GetDateTime("Order_date"),
                        Transportation_cost = reader.GetDouble("Transportation_cost"),
                        Status = reader.GetString("Status")
                    };

                    // Add the ordering object to the list
                    orderList.Add(order);

                }
            }

            return orderList;


        }

        public int GetHighestOrderID()
        {
            int highestOrderID = -1;

            string query = "SELECT MAX(OrderID) AS HighestOrderID FROM Ordering";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                if (reader.Read())
                {
                    {
                        highestOrderID = reader.GetInt32("HighestOrderID");
                    };
                }
            }

            return highestOrderID;
        }

        public Ordering GetNewOrderID()
        {
            int highestOrderID = GetHighestOrderID();
            // Create a variable to hold the retrieved order
            Ordering order = null;

            // Construct SELECT query
            string query = $"SELECT * FROM Ordering WHERE OrderID = {highestOrderID}";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                if (reader.Read())
                {
                    // Create a new Ordering object and populate it with data from the database
                    order = new Ordering
                    {
                        OrderID = reader.GetInt32("OrderID"),
                        StaffID = reader.GetInt32("StaffID"),
                        ClientID = reader.GetInt32("ClientID"),
                        Order_date = reader.GetDateTime("Order_date"),
                        Transportation_cost = reader.GetDouble("Transportation_cost"),
                        Status = reader.GetString("Status")
                    };
                }
            }

            return order;
        }

        public Ordering GetOrderByID(int orderID)
        {
            // Create a variable to hold the retrieved order
            Ordering order = null;

            // Construct SELECT query
            string query = $"SELECT * FROM Ordering WHERE OrderID = {orderID}";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                if (reader.Read())
                {
                    // Create a new Ordering object and populate it with data from the database
                    order = new Ordering
                    {
                        OrderID = reader.GetInt32("OrderID"),
                        StaffID = reader.GetInt32("StaffID"),
                        ClientID = reader.GetInt32("ClientID"),
                        Order_date = reader.GetDateTime("Order_date"),
                        Transportation_cost = reader.GetDouble("Transportation_cost"),
                        Status = reader.GetString("Status")
                    };
                }
            }

            return order;
        }

        public List<Ordering> GetAllDownLineOrders(List<Staff> staffList)
        {
            List<Ordering> orderList = new List<Ordering>();

            // Construct comma-separated list of StaffIDs from the provided staffList
            string staffIDList = string.Join(",", staffList.Select(s => s.StaffID));

            // Construct SELECT query to retrieve orders associated with staff IDs in the list
            string query = $@"
                                SELECT * 
                                FROM Ordering 
                                WHERE StaffID IN ({staffIDList})
                            ";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                while (reader.Read())
                {
                    // Create a new Ordering object and populate it with data from the database
                    Ordering order = new Ordering
                    {
                        OrderID = reader.GetInt32("OrderID"),
                        StaffID = reader.GetInt32("StaffID"),
                        ClientID = reader.GetInt32("ClientID"),
                        Order_date = reader.GetDateTime("Order_date"),
                        Transportation_cost = reader.GetDouble("Transportation_cost"),
                        Status = reader.GetString("Status")
                    };

                    // Add the ordering object to the list
                    orderList.Add(order);
                }
            }

            return orderList;
        }

        public List<Ordering> GetOrdersByDate(DateTime orderDate)
        {
            List<Ordering> orderList = new List<Ordering>();

            // Construct SELECT query
            string formattedDate = orderDate.ToString("yyyy-MM-dd"); // Format the date to match database format
            string query = $"SELECT * FROM Ordering WHERE Order_date = '{formattedDate}'";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                while (reader.Read())
                {
                    // Create a new Ordering object and populate it with data from the database
                    Ordering order = new Ordering
                    {
                        OrderID = reader.GetInt32("OrderID"),
                        StaffID = reader.GetInt32("StaffID"),
                        ClientID = reader.GetInt32("ClientID"),
                        Order_date = reader.GetDateTime("Order_date"),
                        Transportation_cost = reader.GetDouble("Transportation_cost"),
                        Status = reader.GetString("Status")
                    };

                    // Add the ordering object to the list
                    orderList.Add(order);
                }
            }

            return orderList;

            /*
             OrderingController orderingController = new OrderingController();

            // Example: Get orders placed on a specific date, such as "2024-03-19"
            DateTime specificDate = new DateTime(2024, 03, 19);
            List<Ordering> orderList = orderingController.GetOrdersByDate(specificDate);

            // Use the list of order records as needed
            foreach (var order in orderList)
            {
                MessageBox.Show($"Order ID: {order.OrderID}, Order Date: {order.Order_date}");
            }
             */
        }

        public List<Ordering> GetOrdersByStatus(string status)
        {
            List<Ordering> orderList = new List<Ordering>();

            // Construct SELECT query
            string query = $"SELECT * FROM Ordering WHERE Status LIKE '%{status}%'";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                while (reader.Read())
                {
                    // Create a new Ordering object and populate it with data from the database
                    Ordering order = new Ordering
                    {
                        OrderID = reader.GetInt32("OrderID"),
                        StaffID = reader.GetInt32("StaffID"),
                        ClientID = reader.GetInt32("ClientID"),
                        Order_date = reader.GetDateTime("Order_date"),
                        Transportation_cost = reader.GetDouble("Transportation_cost"),
                        Status = reader.GetString("Status")
                    };

                    // Add the ordering object to the list
                    orderList.Add(order);
                }
            }

            return orderList;
        }
    }
}
