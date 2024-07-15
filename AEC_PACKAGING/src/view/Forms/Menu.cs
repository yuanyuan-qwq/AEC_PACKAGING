using AEC_PACKAGING.src.view.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AEC_PACKAGING
{
    public partial class Menu : Form
    {
        private Button currentButton;
        private Color defaultButtonColor = Color.White;
        private Color btnClientColor = Color.SkyBlue;
        private Color btnOrderColor = Color.Yellow;
        private Color btnReportColor = Color.LightSalmon;
        private Color btnProductColor = Color.GreenYellow;
        private Color btnDashboardColor = Color.Plum;
        private Color btnStaffColor = Color.LightPink;

        private Form activeForm;

        public Menu()
        {
            InitializeComponent();
            OpenChildForm(new Dashboard(), btnDashboard);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                Button clickedButton = (Button)btnSender;

                if (currentButton != clickedButton)
                {
                    // Reset the color of the previously clicked button
                    ResetButtonColor();

                    // Set the color of the new button
                    Color color = GetButtonColor(clickedButton);
                    clickedButton.BackColor = color;
                    clickedButton.ForeColor = Color.Black;
                    clickedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    // Store the current button
                    currentButton = clickedButton;

                }
            }
        }

        private void ResetButtonColor()
        {
            if (currentButton != null)
            {
                currentButton.BackColor = defaultButtonColor;
                currentButton.ForeColor = Color.Black; // Set to the default text color
                currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
        }

        private Color GetButtonColor(Button button)
        {
            switch (button.Name)
            {
                case "btnClient":
                    return btnClientColor;
                case "btnOrder":
                    return btnOrderColor;
                case "btnReport":
                    return btnReportColor;
                case "btnProduct":
                    return btnProductColor;
                case "btnDashboard":
                    return btnDashboardColor;
                case "btnStaff":
                    return btnStaffColor;
                default:
                    return defaultButtonColor;
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            // Close the currently active form if it exists
            if (activeForm != null)
                activeForm.Close();

            // Activate the button associated with the child form
            ActivateButton(btnSender);

            // Set the child form as the active form
            activeForm = childForm;

            // Configure the child form properties for embedding in the panel
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Add the child form to the panel for display
            this.panelDisplay.Controls.Add(childForm);

            // Set the tag of the panel to reference the child form
            this.panelDisplay.Tag = childForm;

            // Bring the child form to the front for display
            childForm.BringToFront();

            // Show the child form
            childForm.Show();

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Dashboard(), sender);
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            OpenChildForm(new StaffPage(), sender);
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ClientPage(), sender);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            OpenChildForm(new OrderingPage(), sender);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ProductPage(), sender);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Report(), sender);
        }



        private void btnLogout_Click(object sender, EventArgs e)
        {

            Login loginForm = new Login();
            loginForm.Show();

            // Close the current form (Menu)
            this.Close();
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
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
