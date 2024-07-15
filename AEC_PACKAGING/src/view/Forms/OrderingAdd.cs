using AEC_PACKAGING.src.model;
using AEC_PACKAGING.src.presenter;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AEC_PACKAGING.src.view.Forms
{
    public partial class OrderingAdd : Form
    {
        private OrderingPresenter orderingPresenter = new OrderingPresenter();
        private OrderListPresenter orderListPresenter = new OrderListPresenter();
        private StaffPresenter staffPresenter = new StaffPresenter();
        private ClientPresenter clientPresenter = new ClientPresenter();
        private ProductPresenter productPresenter = new ProductPresenter();
        private OrderList orderList = null;
        private Ordering ordering = null;
        private bool isNewOrder = false;
        private bool NewOrder = false;
        private string message;
        public OrderingAdd()
        {
            InitializeComponent();
            isNewOrder = true;
            NewOrder = true;    

            // Get all staff members from the database
            List<Staff> allStaff = staffPresenter.GetAllStaff();

            // Add each staff member's name to the ComboBox
            foreach (Staff staff in allStaff)
            {
                string item = $"{staff.StaffID} - {staff.Name}";
                cbStaff.Items.Add(item);
            }

            // Get all clients from the database
            List<Client> allClients = clientPresenter.GetAllClients();

            // Add each client's ID and name to the ComboBox
            foreach (Client client in allClients)
            {
                string item = $"{client.ClientID} - {client.Company_name}";
                cbClient.Items.Add(item);
            }

            // Get all products from the database
            List<Product> allProducts = productPresenter.GetAllProducts();

            // Add each product's ID and name to the ComboBox
            foreach (Product product in allProducts)
            {
                string item = $"{product.ProductID} - {product.Name}";
                cbProduct.Items.Add(item);
            }
            LoadData();

        }

        public void LoadData()
        {
            if (!isNewOrder)
            {
                List<OrderList> underOrderID = orderListPresenter.GetAllListsWithOrderID(ordering.OrderID);
                dataGridView1.DataSource = underOrderID;

                if (underOrderID.Count <= 0)
                {
                    isNewOrder = true;
                }
            }
            //order list info
            lbListID.Text = "Auto Generate";
            lbProductID.Text = null;
            lbProductName.Text = null;
            tbQuantity.Text = null;
            tbSize.Text = null;
            tbDesignFee.Text = null;
            tbRemarks.Text = null;
            tbUnitPrice.Text = null;
            cbProduct.Text = null;


            if (ordering != null)
            {
                lbOrderID.Text = ordering.OrderID.ToString();
                lbStaffID.Text = ordering.StaffID.ToString();
                lbClientID.Text = ordering.ClientID.ToString();
                TOrderDate.Text = ordering.Order_date.ToString();
                tbTCost.Text = ordering.Transportation_cost.ToString();

                cbStatus.Text = ordering.Status.ToString();

                foreach (string item in cbStaff.Items)
                {
                    string[] parts = item.Split(new[] { " - " }, StringSplitOptions.None);
                    if (parts.Length == 2 && parts[0] == lbStaffID.Text)
                    {
                        cbStaff.SelectedItem = item;
                        break;
                    }
                }
                foreach (string item in cbClient.Items)
                {
                    string[] parts = item.Split(new[] { " - " }, StringSplitOptions.None);
                    if (parts.Length == 2 && parts[0] == lbClientID.Text)
                    {
                        cbClient.SelectedItem = item;
                        break;
                    }
                }
            }
            else
            {
                //orderind info
                lbOrderID.Text = "Auto Generate";
                lbStaffID.Text = "select";
                lbStaffName.Text = "select";
                lbClientID.Text = "select";
                lbClientName.Text = "select";
                TOrderDate.Text = null;
                tbTCost.Text = null;

                cbStatus.SelectedItem = null;
                cbStaff.SelectedItem = null;
                cbClient.SelectedItem = null;
            }
        }
        private bool comboBoxValidate()
        {

            if (cbStatus.SelectedItem == null)
            {
                MessageBox.Show("Please select a status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (cbStaff.SelectedItem == null)
            {
                MessageBox.Show("Please select a staff.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (cbClient.SelectedItem == null)
            {
                MessageBox.Show("Please select a client.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            


            return true;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string errorMessage;

            //check cobobox
            if (!comboBoxValidate())
            {
                return;
            }

            //new ordering, run one time only
            if (NewOrder)
            {        
                // Validate order data
                if (!orderingPresenter.ValidateOrderData(lbStaffID.Text, lbClientID.Text, TOrderDate.Text, tbTCost.Text, cbStatus.SelectedItem.ToString(), out errorMessage))
                {
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    // Update ordering object with new information
                    ordering = new Ordering();
                    ordering.StaffID = Convert.ToInt32(lbStaffID.Text);
                    ordering.ClientID = Convert.ToInt32(lbClientID.Text);
                    ordering.Order_date = Convert.ToDateTime(TOrderDate.Text);
                    ordering.Transportation_cost = Convert.ToDouble(tbTCost.Text);
                    ordering.Status = cbStatus.SelectedItem.ToString();

                    if (orderingPresenter.AddOrdering(ordering))
                    {
                        ordering = orderingPresenter.GetNewOrderID();
                        isNewOrder = false;
                        NewOrder = false;
                        message = "Success to Add order information.";
                        //MessageBox.Show($"Success to Add order information.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // If update fails, display an error message
                        MessageBox.Show($"Failed to Add order information. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                if (!UpdateOrdering())
                {
                    
                    return;
                }
            }

            if (!AddOrderList())
            {
                return;
            }
            LoadData();
            Message();         
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (orderList != null)
            {
                if (orderListPresenter.DeleteOrderList(orderList.ListID))
                {
                    MessageBox.Show("orderList information Delete successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData();

                }
                else
                {
                    MessageBox.Show("Failed to Delete orderList information. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                orderList = null;
            }
            else
            {
                MessageBox.Show("Please select a orderList to Delete.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!comboBoxValidate())
            {
                return;
            }

            if (!isNewOrder)
            {
                if (!UpdateOrdering())
                {
                    return;
                }
                //validate listID(not null)
                if (int.TryParse(lbListID.Text, out _))
                {
                    if (!UpdateOrderList())
                    {
                        return;
                    }
                }
                LoadData();
                Message();
            }
            else
            {
                MessageBox.Show("Please Add some Product Order", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int rowIndex = selectedRow.Index;

                orderList = new OrderList();
                orderList.ListID = Convert.ToInt32(selectedRow.Cells["ListID"].Value);
                orderList.OrderID = Convert.ToInt32(selectedRow.Cells["OrderID"].Value);
                orderList.ProductID = Convert.ToInt32(selectedRow.Cells["ProductID"].Value);
                orderList.Quantity = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);
                orderList.Size = Convert.ToString(selectedRow.Cells["Size"].Value);
                orderList.Design_fee = Convert.ToDouble(selectedRow.Cells["Design_fee"].Value);
                orderList.Remarks = Convert.ToString(selectedRow.Cells["Remarks"].Value);
                orderList.Unit_price = Convert.ToDouble(selectedRow.Cells["Unit_price"].Value);

                lbListID.Text = orderList.ListID.ToString();
                lbProductID.Text = orderList.ProductID.ToString();
                tbQuantity.Text = orderList.Quantity.ToString();
                tbSize.Text = orderList.Size;
                tbDesignFee.Text = orderList.Design_fee.ToString();
                tbRemarks.Text = orderList.Remarks;
                tbUnitPrice.Text = orderList.Unit_price.ToString();

                foreach (string item in cbProduct.Items)
                {
                    string[] parts = item.Split(new[] { " - " }, StringSplitOptions.None);
                    if (parts.Length == 2 && parts[0] == lbProductID.Text)
                    {
                        cbProduct.SelectedItem = item;
                        break;
                    }
                }

            }
        }

        private void cbStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = cbStaff.SelectedItem?.ToString();

            if (selectedItem != null)
            {
                // Split the selected item to extract the staff ID and name
                string[] parts = selectedItem.Split(new[] { " - " }, StringSplitOptions.None);

                if (parts.Length == 2)
                {
                    // Update the text of lbStaffID with the staff ID
                    lbStaffID.Text = parts[0]; // parts[0] contains the staff ID

                    // Update the text of lbStaffName with the staff name
                    lbStaffName.Text = parts[1]; // parts[1] contains the staff name
                }
            }
        }
        private void cbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = cbClient.SelectedItem?.ToString();

            if (selectedItem != null)
            {
                // Split the selected item to extract the client ID and name
                string[] parts = selectedItem.Split(new[] { " - " }, StringSplitOptions.None);

                if (parts.Length == 2)
                {
                    // Update the text of lbClientID with the client ID
                    lbClientID.Text = parts[0]; // parts[0] contains the client ID

                    // Update the text of lbClientName with the client name
                    lbClientName.Text = parts[1]; // parts[1] contains the client name
                }
            }
        }
        private void cbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = cbProduct.SelectedItem?.ToString();

            if (selectedItem != null)
            {
                // Split the selected item to extract the product ID and name
                string[] parts = selectedItem.Split(new[] { " - " }, StringSplitOptions.None);

                if (parts.Length == 2)
                {
                    // Update the text of lbProductID with the product ID
                    lbProductID.Text = parts[0]; // parts[0] contains the product ID

                    // Update the text of lbProductName with the product name
                    lbProductName.Text = parts[1]; // parts[1] contains the product name
                }
            }
        }

        private bool UpdateOrdering()
        {
            string errorMessage;
            // Validate order data (null,invalid input)
            if (!orderingPresenter.ValidateOrderData(lbStaffID.Text, lbClientID.Text, TOrderDate.Text, tbTCost.Text, cbStatus.SelectedItem.ToString(), out errorMessage))
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {

                // Update ordering object with new information

                ordering.StaffID = Convert.ToInt32(lbStaffID.Text);
                ordering.ClientID = Convert.ToInt32(lbClientID.Text);
                ordering.Order_date = Convert.ToDateTime(TOrderDate.Text);
                ordering.Transportation_cost = Convert.ToDouble(tbTCost.Text);
                ordering.Status = cbStatus.SelectedItem.ToString(); ;

                if (orderingPresenter.UpdateOrdering(ordering))
                {
                    message = "Order information updated successfully!";
                    // If update is successful, display a success message
                    //MessageBox.Show("Order information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    // If update fails, display an error message
                    MessageBox.Show("Failed to update order information. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        private bool AddOrderList()
        {
            string errorMessage;
            // Validate order list data
            if (!orderListPresenter.ValidateOrderListData(lbProductID.Text, tbQuantity.Text, tbSize.Text, tbDesignFee.Text, tbUnitPrice.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                orderList = new OrderList();
                // Set order list properties from textboxes

                orderList.OrderID = ordering.OrderID;
                orderList.ProductID = Convert.ToInt32(lbProductID.Text);
                orderList.Quantity = Convert.ToInt32(tbQuantity.Text);
                orderList.Size = tbSize.Text;
                orderList.Design_fee = Convert.ToDouble(tbDesignFee.Text);
                orderList.Remarks = tbRemarks.Text;
                orderList.Unit_price = Convert.ToDouble(tbUnitPrice.Text);

                // Call the presenter to add the order list
                if (orderListPresenter.AddOrderList(orderList))
                {
                    message = "Order list information added successfully!";
                    //MessageBox.Show($"Order list information added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    // If addition fails, display an error message
                    MessageBox.Show($"Failed to add order list information. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
        }
        private bool UpdateOrderList()
        {
            string errorMessage;
            // Validate order list data(null,invalid)
            if (!orderListPresenter.ValidateOrderListData(lbProductID.Text, tbQuantity.Text, tbSize.Text, tbDesignFee.Text, tbUnitPrice.Text, out errorMessage))
            {
                //validate listID(null)
                if (!int.TryParse(lbListID.Text, out _))
                {
                    return false;
                }
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else //row
            {
                //validate listID
                if (!int.TryParse(lbListID.Text, out _))
                {
                    errorMessage = "please select a row for update order list";
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                // Set order list properties from textboxes
                orderList.ListID = Convert.ToInt32(lbListID.Text);
                orderList.OrderID = ordering.OrderID;
                orderList.ProductID = Convert.ToInt32(lbProductID.Text);
                orderList.Quantity = Convert.ToInt32(tbQuantity.Text);
                orderList.Size = tbSize.Text;
                orderList.Design_fee = Convert.ToDouble(tbDesignFee.Text);
                orderList.Remarks = tbRemarks.Text;
                orderList.Unit_price = Convert.ToDouble(tbUnitPrice.Text);

                // Call the presenter to add the order list
                if (orderListPresenter.UpdateOrderList(orderList))
                {
                    message = "Order list information Update successfully!";
                    //MessageBox.Show("Order list information Update successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    // If addition fails, display an error message
                    MessageBox.Show("Failed to Update order list information. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
        }

        private void Message()
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
