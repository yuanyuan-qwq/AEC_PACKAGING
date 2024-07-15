using AEC_PACKAGING.src.model;
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
    public partial class ProductItem : UserControl
    {
        internal Product SelectedProduct;
        ProductPage productPage;
        private ProductItem lastClickedItem = null;

        public ProductItem()
        {
            InitializeComponent();
        }

        public ProductItem(ProductPage page)
        {
            InitializeComponent();
            productPage = page;
        }

        public Image ProductImage
        {
            get
            {
                return pictureBox1.Image;
            }

            set
            {
                pictureBox1.Image = value;
            }
        }

        public String ProductName
        {
            get
            {
                return lbProductName.Text; 
            }

            set
            {
                lbProductName.Text = value;
            }
        }

        private void ListItem_MouseEnter(object sender, EventArgs e)
        {
            if (lastClickedItem != this)
            {
                this.BackColor = Color.AliceBlue;
            }
        }

        private void ListItem_MouseLeave(object sender, EventArgs e)
        {
            if (lastClickedItem != this)
            {
                this.BackColor = Color.White;
            }
        }

        private void ListItem_MouseClick(object sender, MouseEventArgs e)
        {
            if (lastClickedItem != null)
            {
                lastClickedItem.BackColor = Color.White;
            }

            // Update the last clicked item reference
            lastClickedItem = this;

            // Change the color of the current clicked item to silver
            this.BackColor = Color.Silver;
        }


        private void ProductItem_Click(object sender, EventArgs e)
        {
            productPage.product = SelectedProduct;
        }

        private void ProductItem_DoubleClick(object sender, EventArgs e)
        {
            // Check if the Product object is not null
            if (SelectedProduct != null)
            {
                // Open the ProductEdit form and pass the Product object
                ProductEdit productEditForm = new ProductEdit(SelectedProduct);
                productEditForm.ShowDialog();
                productPage.LoadData();
            }

        }


    }
}
