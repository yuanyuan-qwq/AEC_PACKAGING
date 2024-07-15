using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Windows.Forms;

using AEC_PACKAGING.src.model;
using AEC_PACKAGING.src.view;
using AEC_PACKAGING.src.view.Forms;

namespace AEC_PACKAGING.src.presenter
{
    internal class OrderListPresenter
    {
        private MySQLDatabase db;
        public OrderListPresenter()
        {
            db = new MySQLDatabase();
        }

        public bool ValidateOrderListData(string productID, string quantity, string size, string designFee, string unitPrice, out string errorMessage)
        {
            errorMessage = "";

            // Check for required fields
            if (string.IsNullOrEmpty(productID) || string.IsNullOrEmpty(quantity) || string.IsNullOrEmpty(size) || string.IsNullOrEmpty(designFee) || string.IsNullOrEmpty(unitPrice))
            {
                errorMessage = "Please fill in all required Product fields.";
                return false;
            }


            if (!string.IsNullOrEmpty(productID) && !int.TryParse (productID, out _))
            {
                errorMessage = "product ID must be a valid integer.";
                return false;
            }
            else if (!string.IsNullOrEmpty(designFee) && !double.TryParse(designFee, out _))
            {
                errorMessage = "Design Fee must be a valid double.";
                return false;
            }
            else if (!string.IsNullOrEmpty(quantity) && !int.TryParse(quantity, out _))
            {
                errorMessage = "quantity must be a valid integer.";
                return false;
            }
            else if (!string.IsNullOrEmpty(unitPrice) && !double.TryParse(unitPrice, out _))
            {
                errorMessage = "Unit Price must be a valid double.";
                return false;
            }

            return true; // Validation passed
        }


        public bool AddOrderList(OrderList orderList)
        {
            try
            {
                string query = $"INSERT INTO order_list (OrderID, ProductID, Quantity, Size, Design_fee, Remarks, Unit_price) VALUES " +
                               $"({orderList.OrderID}, {orderList.ProductID}, {orderList.Quantity}, '{orderList.Size}', {orderList.Design_fee}, " +
                               $"'{orderList.Remarks}', {orderList.Unit_price})";

                // Execute INSERT query
                db.ExecuteNonQuery(query);

                // If execution reaches this point, insertion was successful
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding OrderList: {ex.Message}");
                return false;
            }
        }

        public bool UpdateOrderList(OrderList orderList)
        {
            try
            {
                string query = $"UPDATE order_list SET OrderID = {orderList.OrderID}, ProductID = {orderList.ProductID}, Quantity = {orderList.Quantity}, " +
                               $"Size = '{orderList.Size}', Design_fee = {orderList.Design_fee}, Remarks = '{orderList.Remarks}', " +
                               $"Unit_price = {orderList.Unit_price} WHERE ListID = {orderList.ListID}";

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
                MessageBox.Show($"Error Update OrderList: {ex.Message}");
                return false;
            }
        }

        public bool DeleteOrderList(int listID)
        {
            try
            {
                // Construct DELETE query
                string query = $"DELETE FROM order_list WHERE ListID = {listID}";

                // Execute DELETE query
                int rowsAffected = db.ExecuteNonQuery(query);

                // Check if any rows were affected
                if (rowsAffected > 0)
                {
                    return true; // Deletion successful
                }
                else
                {
                    MessageBox.Show($"Error deleting order list: List ID not found");
                    return false; // No rows were affected, deletion failed 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Delete OrderList: {ex.Message}");
                return false;
            }
        }


        public List<OrderList> GetAllLists()
        {
            List<OrderList> orderLists = new List<OrderList>();

            // Construct SELECT query
            string query = "SELECT * FROM order_list";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                while (reader.Read())
                {
                    OrderList orderlist = new OrderList
                    {
                        ListID = reader.GetInt32("ListID"),
                        OrderID = reader.GetInt32("OrderID"),
                        ProductID = reader.GetInt32("ProductID"),
                        Quantity = reader.GetInt32("Quantity"),
                        Size = reader.GetString("Size"),
                        Design_fee = reader.GetDouble("Design_fee"),
                        Remarks = reader.GetString("Remarks"),
                        Unit_price = reader.GetDouble("Unit_price")
                    };

                    // Add the order list object to the list
                    orderLists.Add(orderlist);

                }
            }

            return orderLists;

        }

        //get child list based on parent order
        public List<OrderList> GetAllListsByOrderID(int listID)
        {
            List<OrderList> orderLists = new List<OrderList>();

            // Construct SELECT query
            string query = $"SELECT * FROM Order_List WHERE ListID = {listID}";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                while (reader.Read())
                {
                    OrderList orderlist = new OrderList
                    {
                        ListID = reader.GetInt32("ListID"),
                        OrderID = reader.GetInt32("OrderID"),
                        ProductID = reader.GetInt32("ProductID"),
                        Quantity = reader.GetInt32("Quantity"),
                        Size = reader.GetString("Size"),
                        Design_fee = reader.GetDouble("Design_fee"),
                        Remarks = reader.GetString("Remarks"),
                        Unit_price = reader.GetDouble("Unit_price")
                    };

                    // Add the order list object to the list
                    orderLists.Add(orderlist);

                }
            }

            return orderLists;

        }


        //search by listID
        public OrderList GetOrderListByID(int listID)
        {
            // Create a variable to hold the retrieved order list
            OrderList orderList = null;

            // Construct SELECT query
            string query = $"SELECT * FROM Order_List WHERE ListID = {listID}";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                if (reader.Read())
                {
                    // Create a new OrderList object and populate it with data from the database
                    orderList = new OrderList
                    {
                        ListID = reader.GetInt32("ListID"),
                        OrderID = reader.GetInt32("OrderID"),
                        ProductID = reader.GetInt32("ProductID"),
                        Quantity = reader.GetInt32("Quantity"),
                        Size = reader.GetString("Size"),
                        Design_fee = reader.GetDouble("Design_fee"),
                        Remarks = reader.GetString("Remarks"),
                        Unit_price = reader.GetDouble("Unit_price")
                    };
                }
            }

            return orderList;
        }

        public List<OrderList> GetAllListsWithOrderID(int orderID)
        {
            List<OrderList> orderLists = new List<OrderList>();

            // Construct SELECT query
            string query = $"SELECT * FROM order_list WHERE OrderID = {orderID}";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                while (reader.Read())
                {
                    OrderList orderlist = new OrderList
                    {
                        ListID = reader.GetInt32("ListID"),
                        OrderID = reader.GetInt32("OrderID"),
                        ProductID = reader.GetInt32("ProductID"),
                        Quantity = reader.GetInt32("Quantity"),
                        Size = reader.GetString("Size"),
                        Design_fee = reader.GetDouble("Design_fee"),
                        Remarks = reader.GetString("Remarks"),
                        Unit_price = reader.GetDouble("Unit_price")
                    };

                    // Add the order list object to the list
                    orderLists.Add(orderlist);

                }
            }

            return orderLists;

        }
    }
}
