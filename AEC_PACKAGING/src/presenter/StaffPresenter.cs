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
    internal class StaffPresenter
    {
        private MySQLDatabase db;

        public StaffPresenter()
        {
            // Create an instance of MySQLDatabase
            db = new MySQLDatabase();
        }

        public bool ValidateStaffData(string IC, string name, string phoneNum, string email, string username, string password, string role, string salary, string referralStaffID, out string errorMessage)
        {
            errorMessage = "";

            // Check for empty fields
            if (string.IsNullOrEmpty(IC) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phoneNum) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(role) || string.IsNullOrEmpty(salary))
            {
                errorMessage = "Please fill in all required fields.";
                return false;
            }

            // Validate Role
            if (!int.TryParse(role, out _))
            {
                errorMessage = "Role must be a valid integer.";
                return false;
            }

            // Validate Salary
            if (!int.TryParse(salary, out _))
            {
                errorMessage = "Salary must be a valid integer.";
                return false;
            }

            // Validate Referral Staff ID
            if (!string.IsNullOrEmpty(referralStaffID) && !int.TryParse(referralStaffID, out _))
            {
                errorMessage = "Referral Staff ID must be a valid integer.";
                return false;
            }

            return true; // Validation passed
        }


        public bool AddStaff(Staff staff)
        {
            try
            {
                // Construct INSERT query
                string query = $"INSERT INTO Staff (IC, Name, Phone_num, Email, Username, Password, Role, Salary, Referral_StaffID) VALUES " +
                               $"('{staff.IC}', '{staff.Name}', '{staff.Phone_num}', '{staff.Email}', '{staff.Username}', '{staff.Password}', " +
                               $"{staff.Role}, {staff.Salary}, {staff.Referral_StaffID})";

                // Execute INSERT query
                db.ExecuteNonQuery(query);

                // If execution reaches this point, insertion was successful
                return true;
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., display an error message or log the exception)
                MessageBox.Show($"Error adding staff: {ex.Message}");

                // Return false to indicate failure
                return false;
            }
        }

        /*
        public void AddStaff(Staff staff)
        {
            // Sample values for Staff object
            staff.IC = "123456789012";
            staff.Name = "John Doe";
            staff.Phone_num = "1234567890";
            staff.Email = "john.doe@example.com";
            staff.Username = "johndoe";
            staff.Password = "password";
            staff.Role = 1; // Sample role ID
            staff.Salary = 5000;
            staff.Referral_StaffID = 1; // Sample referral staff ID, set to null if not applicable

            // Construct INSERT query
            string query = $"INSERT INTO Staff (IC, Name, Phone_num, Email, Username, Password, Role, Salary) VALUES " +
                           $"('{staff.IC}', '{staff.Name}', '{staff.Phone_num}', '{staff.Email}', '{staff.Username}', '{staff.Password}', " +
                           $"{staff.Role}, {staff.Salary})";


            // Execute INSERT query
            db.ExecuteNonQuery(query);
        }
        */


        // To update staff info by staffID
        public bool UpdateStaff(Staff staff)
        {
            try
            {
                // Construct UPDATE query
                string query = $"UPDATE Staff SET IC = '{staff.IC}', Name = '{staff.Name}', Phone_num = '{staff.Phone_num}', " +
                               $"Email = '{staff.Email}', Username = '{staff.Username}', Password = '{staff.Password}', Role = {staff.Role}, " +
                               $"Salary = {staff.Salary}, Referral_StaffID = {staff.Referral_StaffID} WHERE StaffID = {staff.StaffID}";

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
                MessageBox.Show($"Error updating staff: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Update failed due to exception
            }
        }

        // To delete staff by staffID
        public bool DeleteStaff(int staffID)
        {
            try
            {
                // Construct DELETE query
                string query = $"DELETE FROM Staff WHERE StaffID = {staffID}";

                // Execute DELETE query
                int rowsAffected = db.ExecuteNonQuery(query);

                // Check if any rows were affected
                if (rowsAffected > 0)
                {
                    return true; // Deletion successful
                }
                else
                {
                    MessageBox.Show($"Error deleting staff: StaffID not found");
                    return false; // No rows were affected, deletion failed 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting staff: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Deletion failed due to exception
            }
        }


        // To get all the staff
        public List<Staff> GetAllStaff()
        {
            List<Staff> staffList = new List<Staff>();

            // Construct SELECT query
            string query = "SELECT * FROM Staff";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                while (reader.Read())
                {
                    // Create a new Staff object and populate it with data from the database
                    Staff staff = new Staff
                    {
                        StaffID = reader.GetInt32("StaffID"),
                        IC = reader.GetString("IC"),
                        Name = reader.GetString("Name"),
                        Phone_num = reader.GetString("Phone_num"),
                        Email = reader.GetString("Email"),
                        Username = reader.GetString("Username"),
                        Password = reader.GetString("Password"),
                        Role = reader.GetInt32("Role"),
                        Salary = reader.GetInt32("Salary"),
                        Referral_StaffID = reader.GetInt32("Referral_StaffID")
                    };

                    // Add the staff object to the list
                    staffList.Add(staff);
                }
            }

            return staffList;


            /*  How to declare this function
             *  See the codes below
             
       
            StaffController staffController = new StaffController();
           
            List<Staff> allStaff = staffController.GetAllStaff();

            // Use the list of staff records as needed
            foreach (var staff in allStaff)
            {
                MessageBox.Show(staff.Name);
            }

             */
        }


        // To get the staff by staffID
        public Staff GetStaffByID(int staffID)
        {
            // Initialize a Staff object to store the result
            Staff staff = null;

            // Construct the SQL query to select staff by StaffID
            string query = $"SELECT * FROM Staff WHERE StaffID = {staffID}";

            // Execute the query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if there are rows returned
                if (reader.Read())
                {
                    // Create a new Staff object and populate it with data from the database
                    staff = new Staff
                    {
                        StaffID = reader.GetInt32("StaffID"),
                        IC = reader.GetString("IC"),
                        Name = reader.GetString("Name"),
                        Phone_num = reader.GetString("Phone_num"),
                        Email = reader.GetString("Email"),
                        Username = reader.GetString("Username"),
                        Password = reader.GetString("Password"),
                        Role = reader.GetInt32("Role"),
                        Salary = reader.GetInt32("Salary"),
                        // Referral_StaffID might be NULL, so use IsDBNull to handle DBNull.Value
                        Referral_StaffID = reader.GetInt32("Referral_StaffID")
                    };
                }
            }

            // Return the staff object (might be null if no staff found with the given StaffID)
            return staff;
        }

        public List<Staff> GetStaffByName(string name)
        {
            List<Staff> staffList = new List<Staff>();

            // Construct SELECT query
            string query = $"SELECT * FROM Staff WHERE Name LIKE '%{name}%'";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                while (reader.Read())
                {
                    // Create a new Staff object and populate it with data from the database
                    Staff staff = new Staff
                    {
                        StaffID = reader.GetInt32("StaffID"),
                        IC = reader.GetString("IC"),
                        Name = reader.GetString("Name"),
                        Phone_num = reader.GetString("Phone_num"),
                        Email = reader.GetString("Email"),
                        Username = reader.GetString("Username"),
                        Password = reader.GetString("Password"),
                        Role = reader.GetInt32("Role"),
                        Salary = reader.GetInt32("Salary"),
                        Referral_StaffID = reader.GetInt32("Referral_StaffID")
                    };

                    // Add the staff object to the list
                    staffList.Add(staff);
                }
            }

            return staffList;
        }

        public List<Staff> GetStaffByIC(string ic)
        {
            List<Staff> staffList = new List<Staff>();

            // Construct SELECT query
            string query = $"SELECT * FROM Staff WHERE IC LIKE '%{ic}%'";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                while (reader.Read())
                {
                    // Create a new Staff object and populate it with data from the database
                    Staff staff = new Staff
                    {
                        StaffID = reader.GetInt32("StaffID"),
                        IC = reader.GetString("IC"),
                        Name = reader.GetString("Name"),
                        Phone_num = reader.GetString("Phone_num"),
                        Email = reader.GetString("Email"),
                        Username = reader.GetString("Username"),
                        Password = reader.GetString("Password"),
                        Role = reader.GetInt32("Role"),
                        Salary = reader.GetInt32("Salary"),
                        Referral_StaffID = reader.GetInt32("Referral_StaffID")
                    };

                    // Add the staff object to the list
                    staffList.Add(staff);
                }
            }

            return staffList;
        }

        // To authenticate users
        public int? AuthenticateUser(string username, string password)
        {
            int? userRole = null;

            // Construct the SQL query to select user role by username and password
            string query = $"SELECT Role FROM Staff WHERE Username = '{username}' AND Password = '{password}'";

            // Execute the query using ExecuteScalar
            object result = db.ExecuteScalar(query);

            // Check if a role was returned
            if (result != null && result != DBNull.Value)
            {
                userRole = Convert.ToInt32(result);
            }

            // Return the user role (null if authentication failed)
            return userRole;

            /*
             * Way to use this function *
             * 
            int? userRole = staffController.AuthenticateUser("", "");

            if(userRole != null)
            {
                MessageBox.Show(userRole.ToString());
            }

             */
        }


        public List<Staff> GetDownLines(int staffID)
        {
            List<Staff> staffList = new List<Staff>();

            // Construct SELECT query
            string query = $@"
        WITH RECURSIVE DownlineCTE AS (
            SELECT StaffID, IC, Name, Phone_num, Email, Username, Password, Role, Salary, Referral_StaffID
            FROM Staff
            WHERE Referral_StaffID = {staffID}
            UNION ALL
            SELECT s.StaffID, s.IC, s.Name, s.Phone_num, s.Email, s.Username, s.Password, s.Role, s.Salary, s.Referral_StaffID
            FROM Staff s
            JOIN DownlineCTE d ON s.Referral_StaffID = d.StaffID
        )
        SELECT DISTINCT StaffID, IC, Name, Phone_num, Email, Username, Password, Role, Salary, Referral_StaffID
        FROM DownlineCTE;
    ";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                while (reader.Read())
                {
                    // Create a new Staff object and populate it with data from the database
                    Staff staff = new Staff
                    {
                        StaffID = reader.GetInt32("StaffID"),
                        IC = reader.GetString("IC"),
                        Name = reader.GetString("Name"),
                        Phone_num = reader.GetString("Phone_num"),
                        Email = reader.GetString("Email"),
                        Username = reader.GetString("Username"),
                        Password = reader.GetString("Password"),
                        Role = reader.GetInt32("Role"),
                        Salary = reader.GetInt32("Salary"),
                        Referral_StaffID = reader.GetInt32("Referral_StaffID")
                    };

                    // Add the staff object to the list
                    staffList.Add(staff);
                }
            }

            return staffList;
        }

        public List<Staff> GetDownLinesAndSelf(int staffID)
        {
            List<Staff> staffList = new List<Staff>();

            // Construct SELECT query
            string query = $@"
        WITH RECURSIVE DownlineCTE AS (
            SELECT StaffID, IC, Name, Phone_num, Email, Username, Password, Role, Salary, Referral_StaffID
            FROM Staff
            WHERE StaffID = {staffID} -- Include the staff with the specified staffID
            UNION ALL
            SELECT s.StaffID, s.IC, s.Name, s.Phone_num, s.Email, s.Username, s.Password, s.Role, s.Salary, s.Referral_StaffID
            FROM Staff s
            JOIN DownlineCTE d ON s.Referral_StaffID = d.StaffID
        )
        SELECT DISTINCT StaffID, IC, Name, Phone_num, Email, Username, Password, Role, Salary, Referral_StaffID
        FROM DownlineCTE;
    ";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                while (reader.Read())
                {
                    // Create a new Staff object and populate it with data from the database
                    Staff staff = new Staff
                    {
                        StaffID = reader.GetInt32("StaffID"),
                        IC = reader.GetString("IC"),
                        Name = reader.GetString("Name"),
                        Phone_num = reader.GetString("Phone_num"),
                        Email = reader.GetString("Email"),
                        Username = reader.GetString("Username"),
                        Password = reader.GetString("Password"),
                        Role = reader.GetInt32("Role"),
                        Salary = reader.GetInt32("Salary"),
                        Referral_StaffID = reader.GetInt32("Referral_StaffID")
                    };

                    // Add the staff object to the list
                    staffList.Add(staff);
                }
            }

            return staffList;
        }

        
    }
}
