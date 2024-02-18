using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AEC_PACKAGING
{
    public partial class Login : Form
    {
        private LoginController controller;

        public Login()
        {
            InitializeComponent();
            this.controller = new LoginController(new UserModel(), new DatabaseConnection());
        }
        /*
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        */

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            //temp
            new Menu().Show();
            this.Hide();

            /*
            string userID = txtUserID.Text;
            string password = txtPwd.Text;

            controller.SetCredentials(userID, password);

            if (controller.AttemptLogin())
            {
                MessageBox.Show("Login Successful!");
                new Menu().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect UserID or Password! Try again!");
                txtUserID.Clear();
                txtPwd.Clear();
                txtUserID.Focus();
            }
            */

        }
    }
}
