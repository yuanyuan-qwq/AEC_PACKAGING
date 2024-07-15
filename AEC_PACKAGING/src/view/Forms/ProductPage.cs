using AEC_PACKAGING.src.model;
using AEC_PACKAGING.src.presenter;
using Microsoft.Office.Interop.Word;
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
    public partial class ProductPage : Form
    {
        private ProductPresenter productPresenter = new ProductPresenter();
        public Product product = null;
        private List<Product> productList = null;
        string PKeyword = null;
        string PSelectedColumn = null;

        public ProductPage()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            // Get all products from the presenter
            List<Product> allProducts = productPresenter.GetAllProducts();

            // Clear the existing controls from the flowLayoutPanel
            flowLayoutPanel1.Controls.Clear();

            // Iterate over each product
            foreach (Product product in allProducts)
            {
                // Create a new ProductItem control and set its properties
                ProductItem productItem = new ProductItem(this);
                productItem.SelectedProduct = product;
                productItem.ProductName = product.Name;
 
                // Add the ProductItem control to the flowLayoutPanel
                flowLayoutPanel1.Controls.Add(productItem);
            }

            if (tabControl1.SelectedTab == tabSearchResult && PKeyword != null)
            {
                search(PKeyword, PSelectedColumn);
            }
            else
            {
                productItem2.Visible = false;
            }

        }




        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (product != null)
            {
                ProductEdit productEditForm = new ProductEdit(product);
                productEditForm.ShowDialog();
                product = null;
                LoadData();
            }
            else
            {
                MessageBox.Show("Please select an order to edit.");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductAdd productAddForm = new ProductAdd();
            productAddForm.ShowDialog();
            product = null;
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (product != null)
            {
                if (productPresenter.DeleteProduct(product.ProductID))
                {
                    MessageBox.Show("Product information deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData();
                }
                else
                {
                    MessageBox.Show("Failed to delete product information. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                product = null;
            }
            else
            {
                MessageBox.Show("Please select a product to delete.");
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

            tabControl1.SelectedTab = tabSearchResult;
        }

        private void search(string keyword, string selectedColumn)
        {
            productList = new List<Product>();

            switch (selectedColumn)
            {
                case "Product ID":
                    int productID;
                    if (int.TryParse(keyword, out productID))
                    {
                        Product product = productPresenter.GetProductfByID(productID);
                        if (product != null)
                        {
                            productList.Add(product);
                        }
                    }
                    break;
                case "Product Name":
                    productList = productPresenter.GetProductsByName(keyword);
                    break;
                case "Category":
                    productList = productPresenter.GetProductsByCategory(keyword);
                    break;
                    // Add more cases as needed for other search columns
            }

            // Clear the existing controls from flowLayoutPanel2
            flowLayoutPanel2.Controls.Clear();

            // Iterate over each product in the search result
            foreach (Product product in productList)
            {
                // Create a new ProductItem control and set its properties
                ProductItem productItem = new ProductItem(this);
                productItem.SelectedProduct = product;
                productItem.ProductName = product.Name;

                // Add the ProductItem control to flowLayoutPanel2
                flowLayoutPanel2.Controls.Add(productItem);
            }
            PKeyword = keyword;
            PSelectedColumn = selectedColumn;
        }

    }
}
