using Guna.UI2.WinForms;
using inventory_management_system_kap.Controllers;
using inventory_management_system_kap.Models;
using inventory_management_system_kap.Repositories;
using InventoryManagementSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_management_system_kap.Views
{
    public partial class InvoicesView : Form
    {
        UIHelper UIHelper = new UIHelper();
        private InvoiceController invoiceController;
        private readonly string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        private int currentPage = 1;
        private int itemsPerPage = 2;
        private int initialRowNumber = 1;

        public InvoicesView()
        {
            InitializeComponent();
            invoiceController = new InvoiceController(new InvoiceRepository(sqlConnectionString));
        }

        private void RefreshDataGrid()
        {
            int currentRowNumber = (currentPage - 1) * itemsPerPage + 1;

            IEnumerable<InvoiceModel> invoices = invoiceController.GetAllInvoices(currentPage, itemsPerPage);
            var displayedInvoices = invoices.ToList();

            dgvInvoices.DataSource = displayedInvoices;
            lblPageNumber.Text = "Page " + currentPage;

            dgvInvoices.Columns["InvoiceNo"].HeaderText = "Invoice No";
            dgvInvoices.Columns["CustomerId"].HeaderText = "Customer ID";
            dgvInvoices.Columns["DueDate"].HeaderText = "Due Date";
            dgvInvoices.Columns["PaymentType"].HeaderText = "Payment Type";
            dgvInvoices.Columns["TotalAmount"].HeaderText = "Total Amount";
            dgvInvoices.Columns["PaymentStatus"].HeaderText = "Payment Satus";

            initialRowNumber = currentRowNumber;

            foreach (DataGridViewRow row in dgvInvoices.Rows)
            {
                row.Cells["number"].Value = currentRowNumber;
                currentRowNumber++;
            }
        }

        private bool HasMoreItemsOnPage(int page, int itemsPerPage)
        {
            int offset = (page - 1) * itemsPerPage;
            IEnumerable<InvoiceModel> items = invoiceController.GetAllInvoices(page, itemsPerPage);
            return items.Any();
        }

        private void InvoicesView_Load(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlInvoices);
            dgvInvoices.ClearSelection();
            RefreshDataGrid();

            dgvInvoices.DataBindingComplete += dgvInvoices_DataBindingComplete;
        }

        private void pnlInvoices_SizeChanged(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlInvoices);
        }

        private void dgvInvoices_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvInvoices.Columns["TotalAmount"].Index && e.RowIndex >= 0)
            {
                if (e.Value is decimal totalAmount)
                {
                    e.Value = "Rs." + totalAmount.ToString("N2");
                    e.FormattingApplied = true;
                }
            }

            if (e.ColumnIndex == dgvInvoices.Columns["InvoiceNo"].Index && e.RowIndex >= 0)
            {
                if (e.Value is int InvoiceNo)
                {
                    e.Value = "KAP-" + InvoiceNo.ToString("D6");
                    e.FormattingApplied = true;
                }
            }
        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearchBar.Text.Trim();
            IEnumerable<InvoiceModel> filteredInvoices = invoiceController.SearchInvoice(searchValue,currentPage,itemsPerPage);
            dgvInvoices.DataSource = filteredInvoices.ToList();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                RefreshDataGrid();
                btnNext.Enabled = true;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int nextPage = currentPage + 1;

            if (HasMoreItemsOnPage(nextPage, itemsPerPage))
            {
                currentPage = nextPage;
                RefreshDataGrid();
            }
            else
            {
                btnNext.Enabled = false;
            }
        }

        private void dgvInvoices_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int currentRowNumber = initialRowNumber;
            foreach (DataGridViewRow row in dgvInvoices.Rows)
            {
                row.Cells["number"].Value = currentRowNumber;
                currentRowNumber++;
            }
        }

        private void btnAddInvoice_Click(object sender, EventArgs e)
        {
            AddInvoiceView addInvoiceForm = new AddInvoiceView();
            addInvoiceForm.TopLevel = false;
            addInvoiceForm.FormBorderStyle = FormBorderStyle.None;
            addInvoiceForm.Dock = DockStyle.Fill;
            pnlChildForm.Controls.Add(addInvoiceForm);
            pnlChildForm.Tag = addInvoiceForm;
            addInvoiceForm.BringToFront();
            addInvoiceForm.Show();
        }
    }
}
