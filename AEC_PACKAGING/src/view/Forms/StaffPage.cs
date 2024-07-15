using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AEC_PACKAGING.src.presenter;
using AEC_PACKAGING.src.model;
using Microsoft.Office.Interop.Word;

namespace AEC_PACKAGING.src.view.Forms
{
    public partial class StaffPage : Form
    {
        private StaffPresenter staffPresenter = new StaffPresenter();
        private Staff staff = null;
        private List<Staff> staffList = null; //for tab2(result tab)
        string PKeyword = null;
        string PSelectedColumn = null;

        public StaffPage()
        {
            InitializeComponent();
            LoadData();
            dataGridView1.CellPainting += dataGridView1_CellPainting;
            dataGridView2.CellPainting += dataGridView1_CellPainting;

        }
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);
                using (Brush brush = new SolidBrush(Color.Pink)) // Change the color as needed
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }
                e.PaintContent(e.CellBounds);
                e.Handled = true;
            }
        }


        public void LoadData()
        {
            List<model.Staff> allStaff = staffPresenter.GetAllStaff();
            dataGridView1.DataSource = allStaff;

            if (tabControl1.SelectedTab == tabSearchResult)
                search(PKeyword,PSelectedColumn);
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (staff != null)
            {
                StaffEdit staffEditForm = new StaffEdit(staff);
                staffEditForm.ShowDialog(); 
                staff = null;
                LoadData();
            }
            else
            {
                MessageBox.Show("Please select a staff member to edit.");
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && tabControl1.SelectedTab == tabDisplay)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                staff = new Staff();
                staff.StaffID = Convert.ToInt32(selectedRow.Cells["StaffID"].Value);
                staff.Name = Convert.ToString(selectedRow.Cells["Name"].Value);
                staff.IC = Convert.ToString(selectedRow.Cells["IC"].Value);
                staff.Phone_num = Convert.ToString(selectedRow.Cells["Phone_num"].Value);
                staff.Email = Convert.ToString(selectedRow.Cells["Email"].Value);
                staff.Username = Convert.ToString(selectedRow.Cells["Username"].Value);
                staff.Password = Convert.ToString(selectedRow.Cells["Password"].Value);
                staff.Role = Convert.ToInt32(selectedRow.Cells["Role"].Value);
                staff.Salary = Convert.ToInt32(selectedRow.Cells["Salary"].Value);
                staff.Referral_StaffID = selectedRow.Cells["Referral_StaffID"].Value == DBNull.Value ? (int?)null : Convert.ToInt32(selectedRow.Cells["Referral_StaffID"].Value);
            }
            // Check if tab2 is selected
            else if (dataGridView2.SelectedRows.Count > 0 && tabControl1.SelectedTab == tabSearchResult)
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                staff = new Staff();
                staff.StaffID = Convert.ToInt32(selectedRow.Cells["StaffID"].Value);
                staff.Name = Convert.ToString(selectedRow.Cells["Name"].Value);
                staff.IC = Convert.ToString(selectedRow.Cells["IC"].Value);
                staff.Phone_num = Convert.ToString(selectedRow.Cells["Phone_num"].Value);
                staff.Email = Convert.ToString(selectedRow.Cells["Email"].Value);
                staff.Username = Convert.ToString(selectedRow.Cells["Username"].Value);
                staff.Password = Convert.ToString(selectedRow.Cells["Password"].Value);
                staff.Role = Convert.ToInt32(selectedRow.Cells["Role"].Value);
                staff.Salary = Convert.ToInt32(selectedRow.Cells["Salary"].Value);
                staff.Referral_StaffID = selectedRow.Cells["Referral_StaffID"].Value == DBNull.Value ? (int?)null : Convert.ToInt32(selectedRow.Cells["Referral_StaffID"].Value);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            StaffAdd staffAddForm = new StaffAdd();
            staffAddForm.ShowDialog(); 

            staff = null;
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (staff != null)
            {
                if (staffPresenter.DeleteStaff(staff.StaffID))
                {
                    // If update is successful, display a success message
                    MessageBox.Show("Staff information Delete successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData();

                }
                else
                {
                    // If update fails, display an error message
                    MessageBox.Show("Failed to Delete staff information. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                staff = null;
            }
            else
            {
                MessageBox.Show("Please select a staff member to Delete.");
            }

            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            // Check if a search column is selected
            if (cboSearch.SelectedItem == null)
            {
                MessageBox.Show("Please select a search column.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string currentKeyword = tbSearch.Text;
            string currentSelectedColumn = cboSearch.SelectedItem.ToString();

            search(currentKeyword, currentSelectedColumn);

            // Optionally, you can switch to the tab containing the search result
            tabControl1.SelectedTab = tabSearchResult;
        }

        private void search(string keyword, string selectedColumn)
        {
            staffList = new List<Staff>();

            switch (selectedColumn)
            {
                case "Staff ID":
                    int staffID;
                    if (int.TryParse(keyword, out staffID))
                    {
                        Staff staff = staffPresenter.GetStaffByID(staffID);
                        if (staff != null)
                        {
                            staffList.Add(staff);
                        }
                    }
                    break;
                case "Name":
                    staffList = staffPresenter.GetStaffByName(keyword);
                    break;
                case "IC":
                    staffList = staffPresenter.GetStaffByIC(keyword);
                    break;
            }

            dataGridView2.DataSource = staffList;
            //to keep last search for refresh the search result page
            PKeyword = keyword;
            PSelectedColumn = selectedColumn;
        }


    }

    
}
