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
    internal class ProductPresenter
    {
        private MySQLDatabase db;
        public ProductPresenter()
        {
            db = new MySQLDatabase();
        }

        public bool ValidateProductData(string productName, string material, string printing, string printingBlock, string category, string unitPrice, out string errorMessage)
        {
            errorMessage = "";

            // Check for empty fields
            if (string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(material) || string.IsNullOrEmpty(printing) ||
                string.IsNullOrEmpty(printingBlock) || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(unitPrice))
            {
                errorMessage = "Please fill in all required fields.";
                return false;
            }

            // Validate unit price
            if (!double.TryParse(unitPrice, out _))
            {
                errorMessage = "Unit price must be a valid number.";
                return false;
            }

            return true; // Validation passed
        }


        public bool AddProduct(Product product)
        {
            try
            {
                string query = $"INSERT INTO Product (StaffID, Name, Material, Printing, Printing_block, Category, Unit_price) VALUES " +
                               $"({product.StaffID}, '{product.Name}', '{product.Material}', '{product.Printing}', '{product.Printing_block}', " +
                               $"'{product.Category}', {product.Unit_price})";

                // Execute INSERT query
                db.ExecuteNonQuery(query);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding Product: {ex.Message}");
                return false;
            }
        }

        public bool UpdateProduct(Product product)
        {
            try
            {
                string query = $"UPDATE Product SET StaffID = {product.StaffID}, Name = '{product.Name}', Material = '{product.Material}', " +
                               $"Printing = '{product.Printing}', Printing_block = '{product.Printing_block}', Category = '{product.Category}', " +
                               $"Unit_price = {product.Unit_price} WHERE ProductID = {product.ProductID}";


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
            catch(Exception ex)
            {
                MessageBox.Show($"Error Update Product: {ex.Message}");
                return false;
            }
        }

        public bool DeleteProduct(int productID)
        {
            try
            {
                // Construct DELETE query
                string query = $"DELETE FROM Product WHERE ProductID = {productID}";

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
            catch ( Exception ex )
            {
                MessageBox.Show($"Error Delete Product: {ex.Message}");
                return false;
            }
        }

        public List<Product> GetAllProducts()
        {
            List<Product> productList = new List<Product>();

            // Construct SELECT query
            string query = "SELECT * FROM Product";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                while (reader.Read())
                {
                    // Create a new Product object and populate it with data from the database
                    Product product = new Product
                    {
                        ProductID = reader.GetInt32("ProductID"),
                        StaffID = reader.GetInt32("StaffID"),
                        Name = reader.GetString("Name"),
                        Material = reader.GetString("Material"),
                        Printing = reader.GetString("Printing"),
                        Printing_block = reader.GetString("Printing_block"),
                        Category = reader.GetString("Category"),
                        Unit_price = reader.GetDouble("Unit_price")
                    };

                    // Add the product object to the list
                    productList.Add(product);

                }
            }

            return productList;
        }



        public Product GetProductfByID(int productID)
        {

            Product product = null;

            // Construct the SQL query to select product by ProductID
            string query = $"SELECT * FROM Product WHERE ProductID = {productID}";

            // Execute the query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if there are rows returned
                if (reader.Read())
                {
                    // Create a new Product object and populate it with data from the database
                    product = new Product
                    {
                        ProductID = reader.GetInt32("ProductID"),
                        StaffID = reader.GetInt32("StaffID"),
                        Name = reader.GetString("Name"),
                        Material = reader.GetString("Material"),
                        Printing = reader.GetString("Printing"),
                        Printing_block = reader.GetString("Printing_block"),
                        Category = reader.GetString("Category"),
                        Unit_price = reader.GetDouble("Unit_price")
                    };
                }
            }

            // Return the product object (might be null if no staff found with the given ProductID)
            return product;
        }
        public List<Product> GetProductsByName(string productName)
        {
            List<Product> productList = new List<Product>();

            // Construct SELECT query
            string query = $"SELECT * FROM Product WHERE Name LIKE '%{productName}%'";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                while (reader.Read())
                {
                    // Create a new Product object and populate it with data from the database
                    Product product = new Product
                    {
                        ProductID = reader.GetInt32("ProductID"),
                        StaffID = reader.GetInt32("StaffID"),
                        Name = reader.GetString("Name"),
                        Material = reader.GetString("Material"),
                        Printing = reader.GetString("Printing"),
                        Printing_block = reader.GetString("Printing_block"),
                        Category = reader.GetString("Category"),
                        Unit_price = reader.GetDouble("Unit_price")
                    };

                    // Add the product object to the list
                    productList.Add(product);
                }
            }

            return productList;
        }

        public List<Product> GetProductsByCategory(string category)
        {
            List<Product> productList = new List<Product>();

            // Construct SELECT query
            string query = $"SELECT * FROM Product WHERE Category = '{category}'";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                while (reader.Read())
                {
                    // Create a new Product object and populate it with data from the database
                    Product product = new Product
                    {
                        ProductID = reader.GetInt32("ProductID"),
                        StaffID = reader.GetInt32("StaffID"),
                        Name = reader.GetString("Name"),
                        Material = reader.GetString("Material"),
                        Printing = reader.GetString("Printing"),
                        Printing_block = reader.GetString("Printing_block"),
                        Category = reader.GetString("Category"),
                        Unit_price = reader.GetDouble("Unit_price")
                    };

                    // Add the product object to the list
                    productList.Add(product);
                }
            }

            return productList;
        }

        public List<Product> GetAllProductsOrderByUnitPriceAscending()
        {
            List<Product> productList = new List<Product>();

            // Construct SELECT query with ORDER BY clause
            string query = "SELECT * FROM Product ORDER BY Unit_price ASC";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                while (reader.Read())
                {
                    // Create a new Product object and populate it with data from the database
                    Product product = new Product
                    {
                        ProductID = reader.GetInt32("ProductID"),
                        StaffID = reader.GetInt32("StaffID"),
                        Name = reader.GetString("Name"),
                        Material = reader.GetString("Material"),
                        Printing = reader.GetString("Printing"),
                        Printing_block = reader.GetString("Printing_block"),
                        Category = reader.GetString("Category"),
                        Unit_price = reader.GetDouble("Unit_price")
                    };

                    // Add the product object to the list
                    productList.Add(product);
                }
            }

            return productList;
        }

        public List<Product> GetAllProductsOrderByUnitPriceDescending()
        {
            List<Product> productList = new List<Product>();

            // Construct SELECT query with ORDER BY clause
            string query = "SELECT * FROM Product ORDER BY Unit_price DESC";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                while (reader.Read())
                {
                    // Create a new Product object and populate it with data from the database
                    Product product = new Product
                    {
                        ProductID = reader.GetInt32("ProductID"),
                        StaffID = reader.GetInt32("StaffID"),
                        Name = reader.GetString("Name"),
                        Material = reader.GetString("Material"),
                        Printing = reader.GetString("Printing"),
                        Printing_block = reader.GetString("Printing_block"),
                        Category = reader.GetString("Category"),
                        Unit_price = reader.GetDouble("Unit_price")
                    };

                    // Add the product object to the list
                    productList.Add(product);
                }
            }

            return productList;
        }
    }
}
