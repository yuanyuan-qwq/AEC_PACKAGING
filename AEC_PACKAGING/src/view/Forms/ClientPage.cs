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
    public partial class ClientPage : Form
    {
        private ClientPresenter clientPresenter = new ClientPresenter();
        private Client client = null;
        private List<Client> clientList = null;
        string PKeyword = null;
        string PSelectedColumn = null;

        public ClientPage()
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
                using (Brush brush = new SolidBrush(Color.LightBlue)) // Change the color as needed
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }
                e.PaintContent(e.CellBounds);
                e.Handled = true;
            }
        }
        private void LoadData()
        {
            List<model.Client> allClient = clientPresenter.GetAllClients();
            dataGridView1.DataSource = allClient;

            if (tabControl1.SelectedTab == tabSearchResult)
                search(PKeyword, PSelectedColumn);

        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (client != null)
            {
                ClientEdit clientEditForm = new ClientEdit(client);
                clientEditForm.ShowDialog();
                client = null;
                LoadData();
            }
            else
            {
                MessageBox.Show("Please select a client to edit.");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClientAdd clientAddForm = new ClientAdd();
            clientAddForm.ShowDialog();

            client = null;
            LoadData();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && tabControl1.SelectedTab == tabDisplay)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                client = new Client();
                client.ClientID = Convert.ToInt32(selectedRow.Cells["ClientID"].Value);
                client.Company_name = Convert.ToString(selectedRow.Cells["Company_name"].Value);
                client.Company_address = Convert.ToString(selectedRow.Cells["Company_address"].Value);
                client.Company_num = Convert.ToString(selectedRow.Cells["Company_num"].Value);
                client.Fax_num = Convert.ToString(selectedRow.Cells["Fax_num"].Value);
                client.PIC_name = Convert.ToString(selectedRow.Cells["PIC_name"].Value);
                client.PIC_num = Convert.ToString(selectedRow.Cells["PIC_num"].Value);
                client.PIC_email = Convert.ToString(selectedRow.Cells["PIC_email"].Value);
                client.StaffID = selectedRow.Cells["StaffID"].Value == DBNull.Value ? (int?)null : Convert.ToInt32(selectedRow.Cells["StaffID"].Value);
            }
            else if (dataGridView2.SelectedRows.Count > 0 && tabControl1.SelectedTab == tabSearchResult)
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];

                client = new Client();
                client.ClientID = Convert.ToInt32(selectedRow.Cells["ClientID"].Value);
                client.Company_name = Convert.ToString(selectedRow.Cells["Company_name"].Value);
                client.Company_address = Convert.ToString(selectedRow.Cells["Company_address"].Value);
                client.Company_num = Convert.ToString(selectedRow.Cells["Company_num"].Value);
                client.Fax_num = Convert.ToString(selectedRow.Cells["Fax_num"].Value);
                client.PIC_name = Convert.ToString(selectedRow.Cells["PIC_name"].Value);
                client.PIC_num = Convert.ToString(selectedRow.Cells["PIC_num"].Value);
                client.PIC_email = Convert.ToString(selectedRow.Cells["PIC_email"].Value);
                client.StaffID = selectedRow.Cells["StaffID"].Value == DBNull.Value ? (int?)null : Convert.ToInt32(selectedRow.Cells["StaffID"].Value);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (client != null)
            {
                if (clientPresenter.DeleteClient(client.ClientID))
                {
                    MessageBox.Show("Client information Delete successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData();

                }
                else
                {
                    MessageBox.Show("Failed to Delete client information. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                client = null;
            }
            else
            {
                MessageBox.Show("Please select a client to Delete.");
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
            clientList = new List<Client>();

            switch (selectedColumn)
            {
                case "Client ID":
                    int clientID;
                    if (int.TryParse(keyword, out clientID))
                    {
                        Client client = clientPresenter.GetClientByID(clientID);
                        if (client != null)
                        {
                            clientList.Add(client);
                        }
                    }
                    break;
                case "Company Name":
                    clientList = clientPresenter.GetClientsByName(keyword);
                    break;
                case "PIC Name":
                    clientList = clientPresenter.GetClientsByPICName(keyword);
                    break;
            }

            dataGridView2.DataSource = clientList;
            PKeyword = keyword;
            PSelectedColumn = selectedColumn;
        }


    }
}
