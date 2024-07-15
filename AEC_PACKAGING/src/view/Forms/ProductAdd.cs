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
    public partial class ProductAdd : Form
    {
        private Product product = new Product();
        private ProductPresenter productPresenter = new ProductPresenter();

        public ProductAdd()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            string errorMessage;
            if (!productPresenter.ValidateProductData(tbProductName.Text, tbMaterial.Text, tbPrinting.Text, tbPrintingBlock.Text, tbCategory.Text, tbUnitPrice.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            product.StaffID = Convert.ToInt32(tbStaffID.Text);
            product.Name = tbProductName.Text;
            product.Material = tbMaterial.Text;
            product.Printing = tbPrinting.Text;
            product.Printing_block = tbPrintingBlock.Text;
            product.Category = tbCategory.Text;
            product.Unit_price = Convert.ToDouble(tbUnitPrice.Text);


            if (productPresenter.AddProduct(product))
            {
                // If addition is successful, display a success message
                MessageBox.Show("Product information added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Close the form
                this.Close();
            }
            else
            {
                // If addition fails, display an error message
                MessageBox.Show("Failed to add product information. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
