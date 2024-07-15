using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AEC_PACKAGING.src.model;
using AEC_PACKAGING.src.presenter;

namespace AEC_PACKAGING.src.view.Forms
{
    public partial class ProductEdit : Form
    {
        private ProductPresenter productPresenter = new ProductPresenter();
        private Product product = new Product();

        public ProductEdit(Product productInfo)
        {
            InitializeComponent();
            tbProductID.Text = productInfo.ProductID.ToString();
            tbStaffID.Text = productInfo.StaffID.ToString();
            tbProductName.Text = productInfo.Name;
            tbMaterial.Text = productInfo.Material;
            tbPrinting.Text = productInfo.Printing;
            tbPrintingBlock.Text = productInfo.Printing_block;
            tbCategory.Text = productInfo.Category;
            tbUnitPrice.Text = productInfo.Unit_price.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string errorMessage;

            // Validate product data
            if (!productPresenter.ValidateProductData(tbProductName.Text, tbMaterial.Text, tbPrinting.Text, tbPrintingBlock.Text, tbCategory.Text, tbUnitPrice.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Update product object with new information
            product.ProductID = Convert.ToInt32(tbProductID.Text);
            product.StaffID = Convert.ToInt32( tbStaffID.Text);
            product.Name = tbProductName.Text;
            product.Material = tbMaterial.Text;
            product.Printing = tbPrinting.Text;
            product.Printing_block = tbPrintingBlock.Text;
            product.Category = tbCategory.Text;
            product.Unit_price = Convert.ToDouble(tbUnitPrice.Text);

            // Call the presenter to update product information
            if (productPresenter.UpdateProduct(product))
            {
                // If update is successful, display a success message
                MessageBox.Show("Product information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Close the form
                this.Close();
            }
            else
            {
                // If update fails, display an error message
                MessageBox.Show("Failed to update product information. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Set product ID from textbox
            product.ProductID = Convert.ToInt32(tbProductID.Text);

            // Call the presenter to delete product information
            if (productPresenter.DeleteProduct(product.ProductID))
            {
                // If deletion is successful, display a success message
                MessageBox.Show("Product information deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Close the form
                this.Close();
            }
            else
            {
                // If deletion fails, display an error message
                MessageBox.Show("Failed to delete product information. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
