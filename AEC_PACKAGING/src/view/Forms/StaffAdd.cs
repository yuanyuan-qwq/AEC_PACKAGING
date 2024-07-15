using AEC_PACKAGING.src.model;
using AEC_PACKAGING.src.presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AEC_PACKAGING.src.view.Forms
{
    public partial class StaffAdd : Form
    {
        private Staff staff = new Staff();
        private StaffPresenter staffPresenter = new StaffPresenter();

        public StaffAdd()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string errorMessage;
            if (!staffPresenter.ValidateStaffData(tbIC.Text, tbName.Text, tbTEL.Text, tbEmail.Text, tbUsername.Text, tbPassword.Text, tbRole.Text, tbSalary.Text, tbRStaffID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            staff.IC = tbIC.Text;
            staff.Name = tbName.Text;
            staff.Phone_num = tbTEL.Text;
            staff.Email = tbEmail.Text;
            staff.Username = tbUsername.Text;
            staff.Password = tbPassword.Text;
            staff.Role = Convert.ToInt32(tbRole.Text);
            staff.Salary = Convert.ToInt32(tbSalary.Text);
            staff.Referral_StaffID = string.IsNullOrEmpty(tbRStaffID.Text) ? null : (int?)Convert.ToInt32(tbRStaffID.Text);

            if (staffPresenter.AddStaff(staff))
            {
                // If update is successful, display a success message
                MessageBox.Show("Staff information Add successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Close the form
                this.Close();
            }
            else
            {
                // If update fails, display an error message
                MessageBox.Show("Failed to Add staff information. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
