using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AEC_PACKAGING
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text == "yuan" && txtPwd.Text == "yuan")
            {
                new Form2().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("incorrect User name and Password");
                txtUserID.Clear();
                txtPwd.Clear();
                txtUserID.Focus();
            }
        }
    }
}
