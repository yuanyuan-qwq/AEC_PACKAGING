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
    public partial class ClientAdd : Form
    {
        private Client client = new Client();
        private ClientPresenter clientPresenter = new ClientPresenter();

        public ClientAdd()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string errorMessage;
            if (!clientPresenter.ValidateClientData(tbCompanyName.Text, tbCompanyAddress.Text, tbCompanyTEL.Text, tbFax.Text, tbPICName.Text, tbPICTEL.Text, tbPICEmail.Text, tbStaffID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            client.Company_name = tbCompanyName.Text;
            client.Company_address = tbCompanyAddress.Text;
            client.Company_num = tbCompanyTEL.Text;
            client.Fax_num = tbFax.Text;
            client.PIC_name = tbPICName.Text;
            client.PIC_num = tbPICTEL.Text;
            client.PIC_email = tbPICEmail.Text;
            client.StaffID = string.IsNullOrEmpty(tbStaffID.Text) ? null : (int?)Convert.ToInt32(tbStaffID.Text);

            if (clientPresenter.AddClient(client))
            {
                // If addition is successful, display a success message
                MessageBox.Show("Client information added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Close the form
                this.Close();
            }
            else
            {
                // If addition fails, display an error message
                MessageBox.Show("Failed to add client information. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

