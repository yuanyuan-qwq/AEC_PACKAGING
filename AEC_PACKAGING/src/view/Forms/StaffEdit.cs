
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

    public partial class StaffEdit : Form
    {
        private StaffPresenter staffPresenter = new StaffPresenter();
        private Staff staff = new Staff();

        public StaffEdit(Staff staffInfo)
        {
            InitializeComponent();
            tbStaffID.Text = staffInfo.StaffID.ToString();
            tbIC.Text = staffInfo.IC;
            tbName.Text = staffInfo.Name;
            tbTEL.Text = staffInfo.Phone_num;
            tbEmail.Text = staffInfo.Email;
            tbUsername.Text = staffInfo.Username;
            tbPassword.Text = staffInfo.Password;
            tbRole.Text = staffInfo.Role.ToString();
            tbSalary.Text = staffInfo.Salary.ToString();
            tbRStaffID.Text = staffInfo.Referral_StaffID.ToString();

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string errorMessage;
            if (!staffPresenter.ValidateStaffData(tbIC.Text, tbName.Text, tbTEL.Text, tbEmail.Text, tbUsername.Text, tbPassword.Text, tbRole.Text, tbSalary.Text, tbRStaffID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            staff.StaffID = Convert.ToInt32(tbStaffID.Text);
            staff.IC = tbIC.Text;
            staff.Name = tbName.Text;
            staff.Phone_num = tbTEL.Text;
            staff.Email = tbEmail.Text;
            staff.Username = tbUsername.Text;
            staff.Password = tbPassword.Text;
            staff.Role = Convert.ToInt32(tbRole.Text);
            staff.Salary = Convert.ToInt32(tbSalary.Text);
            staff.Referral_StaffID = string.IsNullOrEmpty(tbRStaffID.Text) ? null : (int?)Convert.ToInt32(tbRStaffID.Text);

            if (staffPresenter.UpdateStaff(staff))
            {
                // If update is successful, display a success message
                MessageBox.Show("Staff information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Close the form
                this.Close();
            }
            else
            {
                // If update fails, display an error message
                MessageBox.Show("Failed to update staff information. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            staff.StaffID = Convert.ToInt32(tbStaffID.Text);

            if (staffPresenter.DeleteStaff(staff.StaffID))
            {
                // If update is successful, display a success message
                MessageBox.Show("Staff information Delete successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // Close the form
                this.Close();
            }
            else
            {
                // If update fails, display an error message
                MessageBox.Show("Failed to Delete staff information. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

