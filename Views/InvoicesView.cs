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
        private InvoiceController controller;
        private readonly string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        private int currentPage = 1;
        private int itemsPerPage = 10;
        private int initialRowNumber = 1;

        public InvoicesView()
        {
            InitializeComponent();
            controller = new InvoiceController(new InvoiceRepository(sqlConnectionString));
        }

        private void RefreshDataGrid()
        {
            dgvInvoices.AutoGenerateColumns = false;
            dgvInvoices.ColumnCount = 9;

            int currentRowNumber = (currentPage - 1) * itemsPerPage + 1;

            IEnumerable<InvoiceModel> invoices = controller.GetAllInvoices(currentPage, itemsPerPage);
            var displayedInvoices = invoices.ToList();
            dgvInvoices.DataSource = displayedInvoices;
            lblPageNumber.Text = "Page " + currentPage;

            initialRowNumber = currentRowNumber;

            foreach (DataGridViewRow row in dgvInvoices.Rows)
            {
                row.Cells["number"].Value = currentRowNumber;
                currentRowNumber++;
            }        

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
            if (e.ColumnIndex == dgvInvoices.Columns[6].Index && e.RowIndex >= 0)
            {
                if (e.Value is decimal totalAmount)
                {
                    e.Value = "Rs." + totalAmount.ToString("N2");
                    e.FormattingApplied = true;
                }
            }

            if (e.ColumnIndex == dgvInvoices.Columns[1].Index && e.RowIndex >= 0)
            {
                if (e.Value is int InvoiceNo)
                {
                    e.Value = "KAP-" + InvoiceNo.ToString("D6");
                    e.FormattingApplied = true;
                }
            }

            if (e.ColumnIndex == dgvInvoices.Columns[8].Index && e.RowIndex >= 0)
            {
                if (dgvInvoices[7, e.RowIndex].Value is string paymentStatus)
                {
                    if (paymentStatus.Equals("pending", StringComparison.OrdinalIgnoreCase))
                    {
                        e.Value = Properties.Resources.orange_icon;
                        e.FormattingApplied = true;
                    }
                    else
                    {
                        e.Value = Properties.Resources.green_icon;
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearchBar.Text.Trim();
            IEnumerable<InvoiceModel> filteredInvoices = controller.SearchInvoice(searchValue,currentPage,itemsPerPage);
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

            if (controller.HasMoreItemsOnPage(nextPage, itemsPerPage))
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
