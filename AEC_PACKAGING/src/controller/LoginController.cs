using MySql.Data.MySqlClient;
using System;

public class LoginController
{
    private UserModel userModel;
    private DatabaseConnection databaseConnection; 

    public LoginController(UserModel userModel, DatabaseConnection databaseConnection)
    {
        this.userModel = userModel;
        this.databaseConnection = databaseConnection;
    }
    public void SetCredentials(string userID, string password)
    {
        userModel.UserID = userID;
        userModel.Password = password;
    }
    public bool AttemptLogin()
    {
        MySqlConnection connection = DatabaseConnection.GetConnection(); 

        try
        {
            connection.Open();
            string selectQuery = "SELECT * FROM user WHERE UserID = @UserID AND Password = @Password";
            using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
            {
                command.Parameters.AddWithValue("@UserID", userModel.UserID);
                command.Parameters.AddWithValue("@Password", userModel.Password);

                using (MySqlDataReader mdr = command.ExecuteReader())
                {
                    return mdr.Read(); // If is found, login 
                }
            }
        }
        catch (Exception)
        {
            return false; // Handle exceptions
        }
        finally
        {
            connection.Close();
        }
    }

}
