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
    public partial class ClientEdit : Form
    {
        private ClientPresenter clientPresenter = new ClientPresenter();
        private Client client = new Client();

        public ClientEdit(Client clientInfo)
        {
            InitializeComponent();

            // Populate the textboxes with existing client information
            tbClientID.Text = clientInfo.ClientID.ToString();
            tbCompanyName.Text = clientInfo.Company_name;
            tbCompanyAddress.Text = clientInfo.Company_address;
            tbCompanyTEL.Text = clientInfo.Company_num;
            tbFax.Text = clientInfo.Fax_num;
            tbPICName.Text = clientInfo.PIC_name;
            tbPICTEL.Text = clientInfo.PIC_num;
            tbPICEmail.Text = clientInfo.PIC_email;
            tbStaffID.Text = clientInfo.StaffID.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string errorMessage;

            // Validate client data
            if (!clientPresenter.ValidateClientData(tbCompanyName.Text, tbCompanyAddress.Text, tbCompanyTEL.Text, tbFax.Text, tbPICName.Text, tbPICTEL.Text, tbPICEmail.Text, tbStaffID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Update client object with new information
            client.ClientID = Convert.ToInt32(tbClientID.Text);
            client.Company_name = tbCompanyName.Text;
            client.Company_address = tbCompanyAddress.Text;
            client.Company_num = tbCompanyTEL.Text;
            client.Fax_num = tbFax.Text;
            client.PIC_name = tbPICName.Text;
            client.PIC_num = tbPICTEL.Text;
            client.PIC_email = tbPICEmail.Text;
            client.StaffID = Convert.ToInt32(tbStaffID.Text);

            // Call the presenter to update client information
            if (clientPresenter.UpdateClient(client))
            {
                // If update is successful, display a success message
                MessageBox.Show("Client information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Close the form
                this.Close();
            }
            else
            {
                // If update fails, display an error message
                MessageBox.Show("Failed to update client information. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Set client ID from textbox
            client.ClientID = Convert.ToInt32(tbClientID.Text);

            // Call the presenter to delete client information
            if (clientPresenter.DeleteClient(client.ClientID))
            {
                // If deletion is successful, display a success message
                MessageBox.Show("Client information deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Close the form
                this.Close();
            }
            else
            {
                // If deletion fails, display an error message
                MessageBox.Show("Failed to delete client information. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

