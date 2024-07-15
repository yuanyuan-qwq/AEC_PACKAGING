using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using System;
using System.Windows.Forms;
using AEC_PACKAGING.src.presenter;
using AEC_PACKAGING.src.view.Forms;

namespace AEC_PACKAGING
{
    public partial class Login : Form
    {
        private StaffPresenter staffPresenter;

        public Login()
        {
            InitializeComponent();
            staffPresenter = new StaffPresenter();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserID.Text;
            string password = txtPwd.Text;

            // Authenticate user
            int? userRole = staffPresenter.AuthenticateUser(username, password);

            if (userRole.HasValue)
            {
                // Authentication successful
                MessageBox.Show($"Login successful! User role: {userRole}");

                // Depending on the user's role, navigate to the appropriate form
                switch (userRole)
                {
                    case 1:
                        new Menu().Show();
                        this.Hide();
                        break;
                    case 2:
                        new Menu().Show();
                        this.Hide();
                        break;
                    default:
                        MessageBox.Show($"Wait a minute WHO ARE U! User role: {userRole}");
                        break;
                }
            }
            else
            {
                // Authentication failed
                MessageBox.Show("Invalid username or password. Please try again.");
                txtUserID.Clear();
                txtPwd.Clear();
                txtUserID.Focus();
            }
        }
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if the form is closing due to user action
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Close the entire application
                Application.Exit();
            }
        }

    }
}
