using System;
using System.Collections.Generic;
using System.IO;
using AEC_PACKAGING.src.model;
using AEC_PACKAGING.src.presenter;
using Microsoft.Office.Interop.Word;

namespace AEC_PACKAGING.src.Quotation
{
    internal class QuotationGeneration
    {
        // Method to copy and edit Word template
        public void CopyAndEditWordTemplate(string savedFilePath, int orderID)
        {
            // Get Order Info
            OrderingPresenter orderPresenter = new OrderingPresenter();
            Ordering order = orderPresenter.GetOrderByID(orderID);

            // Get All Order Lists
            OrderListPresenter orderListPresenter = new OrderListPresenter();
            List<OrderList> orderList = orderListPresenter.GetAllListsWithOrderID(orderID);

            // Get Client Info
            ClientPresenter clientPresenter = new ClientPresenter();
            Client client = clientPresenter.GetClientByID(order.ClientID);

            // Get Staff Info
            StaffPresenter staffPresenter = new StaffPresenter();
            Staff staff = staffPresenter.GetStaffByID(order.StaffID);

            string originalFilePath = "../../Assets/quotation_template.docx";
            // Copy the original Word template file to a new location
            File.Copy(originalFilePath, savedFilePath, true);

            // Create an instance of Microsoft Word
            Application wordApp = new Application();

            try
            {
                // Open the edited document
                Document doc = wordApp.Documents.Open(savedFilePath);

                // Edit the document as needed
                string quotationID = GenerateQuotationID(orderID);
                string formattedOrderDate = order.Order_date.ToString("yyyy-MM-dd");

                FindAndReplaceText(doc, "<Placeholder1>", quotationID);
                FindAndReplaceText(doc, "<Placeholder2>", client.Company_name);
                FindAndReplaceText(doc, "<Placeholder3>", client.PIC_name);
                FindAndReplaceText(doc, "<Placeholder4>", client.PIC_num);
                FindAndReplaceText(doc, "<Placeholder5>", formattedOrderDate);
                FindAndReplaceText(doc, "<Placeholder6>", staff.Name);
                FindAndReplaceText(doc, "<Placeholder7>", staff.Phone_num);

                // Add cells below each column with provided data
                AddCellsBelowColumns(doc, orderList);

                // Save the changes
                doc.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Close and release resources
                wordApp.Quit();
                ReleaseObject(wordApp);
            }
        }

        // Method to release COM objects
        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                GC.Collect();
            }
        }

        public static void AddCellsBelowColumns(Document doc, List<OrderList> list)
        {
            // Assuming the table is at the first index
            Table table = doc.Tables[1]; // Index 1 is the first table

            foreach (var item in list)
            {
                ProductPresenter productPresenter = new ProductPresenter();
                Product product = productPresenter.GetProductfByID(item.ProductID);
                // Create a new row
                Row newRow = table.Rows.Add();

                // Populate cells with data from the item
                newRow.Cells[1].Range.Text = product.Name;
                newRow.Cells[2].Range.Text = product.Material;
                newRow.Cells[3].Range.Text = product.Printing;
                newRow.Cells[4].Range.Text = item.Size;
                newRow.Cells[5].Range.Text = $"RM {item.Unit_price.ToString("0.00")}";
            }
        }


        // Method to find and replace text in the document
        private void FindAndReplaceText(Document doc, string findText, string replaceText)
        {
            foreach (Range range in doc.StoryRanges)
            {
                Find find = range.Find;
                find.Text = findText;
                find.Replacement.Text = replaceText;
                find.Execute(Replace: WdReplace.wdReplaceAll);
            }
        }

        private static string GenerateQuotationID(int num)
        {
            // Ensure that the number is within the range of 0 to 999999
            num = Math.Max(0, Math.Min(999999, num));

            // Format the number with leading zeros and concatenate 'B' in front
            return "B" + num.ToString("D6");
        }
    }
}
