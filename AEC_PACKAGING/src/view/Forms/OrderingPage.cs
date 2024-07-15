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
    public partial class OrderingPage : Form
    {
        private OrderingPresenter orderingPresenter = new OrderingPresenter();
        private Ordering ordering = null;
        private List<Ordering> orderingList = null;
        string PKeyword = null;
        string PSelectedColumn = null;
        

        public OrderingPage()
        {
            InitializeComponent();
            LoadData();
            EventHandler dataGridView1_SelectionChanged = null;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            dataGridView1.CellPainting += dataGridView1_CellPainting;
            dataGridView2.CellPainting += dataGridView1_CellPainting;
        }
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);
                using (Brush brush = new SolidBrush(Color.Yellow)) // Change the color as needed
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }
                e.PaintContent(e.CellBounds);
                e.Handled = true;
            }
        }
        private void LoadData()
        {
            List<Ordering> allOrders = orderingPresenter.GetAllOrders();
            dataGridView1.DataSource = allOrders;



            if (tabControl1.SelectedTab == tabSearchResult)
                search(PKeyword, PSelectedColumn);

        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (ordering != null)
            {
                OrderEdit OrderEditForm = new OrderEdit(ordering);
                OrderEditForm.ShowDialog();
                ordering = null;
                LoadData();
            }
            else
            {
                MessageBox.Show("Please select an order to edit.");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OrderingAdd orderingAddForm = new OrderingAdd();
            orderingAddForm.ShowDialog();

            ordering = null;
            LoadData();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0 && tabControl1.SelectedTab == tabDisplay)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int rowIndex = selectedRow.Index;

                ordering = new Ordering();
                ordering.OrderID = Convert.ToInt32(selectedRow.Cells["OrderID"].Value);
                ordering.StaffID = Convert.ToInt32(selectedRow.Cells["StaffID"].Value);
                ordering.ClientID = Convert.ToInt32(selectedRow.Cells["ClientID"].Value);
                ordering.Order_date = Convert.ToDateTime(selectedRow.Cells["Order_date"].Value);
                ordering.Transportation_cost = Convert.ToDouble(selectedRow.Cells["Transportation_cost"].Value);
                ordering.Status = Convert.ToString(selectedRow.Cells["Status"].Value);
            }
            else if (dataGridView2.SelectedRows.Count > 0 && tabControl1.SelectedTab == tabSearchResult)
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                int rowIndex = selectedRow.Index;

                ordering = new Ordering();
                ordering.OrderID = Convert.ToInt32(selectedRow.Cells["OrderID"].Value);
                ordering.StaffID = Convert.ToInt32(selectedRow.Cells["StaffID"].Value);
                ordering.ClientID = Convert.ToInt32(selectedRow.Cells["ClientID"].Value);
                ordering.Order_date = Convert.ToDateTime(selectedRow.Cells["Order_date"].Value);
                ordering.Transportation_cost = Convert.ToDouble(selectedRow.Cells["Transportation_cost"].Value);
                ordering.Status = Convert.ToString(selectedRow.Cells["Status"].Value);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ordering != null)
            {
                if (orderingPresenter.DeleteOrdering(ordering.OrderID))
                {
                    // If deletion is successful, display a success message
                    MessageBox.Show("Order information deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    // If deletion fails, display an error message
                    MessageBox.Show("Failed to delete order information. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ordering = null;
            }
            else
            {
                MessageBox.Show("Please select an order to delete.");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
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
            orderingList = new List<Ordering>();

            switch (selectedColumn)
            {
                case "Order ID":
                    int orderID;
                    if (int.TryParse(keyword, out orderID))
                    {
                        Ordering order = orderingPresenter.GetOrderByID(orderID);
                        if (order != null)
                        {
                            orderingList.Add(order);
                        }
                    }
                    break;
                case "Date":
                    DateTime orderDate;
                    if (DateTime.TryParse(keyword, out orderDate))
                    {
                        List<Ordering> ordersByDate = orderingPresenter.GetOrdersByDate(orderDate);
                        orderingList.AddRange(ordersByDate);
                    }
                    break;
                case "Status":
                    string status = keyword; 
                    List<Ordering> ordersByStatus = orderingPresenter.GetOrdersByStatus(status);
                    orderingList.AddRange(ordersByStatus);
                    break;
            }


            dataGridView2.DataSource = orderingList;
            //to keep last search for refreshing the search result page
            PKeyword = keyword;
            PSelectedColumn = selectedColumn;
        }
    }
}
