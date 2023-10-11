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


        public InvoicesView()
        {
            InitializeComponent();
            invoiceController = new InvoiceController(new InvoiceRepository(sqlConnectionString));
        }

        private void InvoicesView_Load(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlInvoices);
            dgvInvoices.ClearSelection();
            GetAllInvoices();
        }

        private void pnlInvoices_SizeChanged(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlInvoices);
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

        private void GetAllInvoices()
        {
            IEnumerable<InvoiceModel> invoices = invoiceController.GetAllInvoices();
            dgvInvoices.DataSource = invoices.ToList();
            dgvInvoices.Columns["InvoiceNo"].HeaderText = "Invoice No";
            dgvInvoices.Columns["CustomerId"].HeaderText = "Customer ID";
            dgvInvoices.Columns["DueDate"].HeaderText = "Due Date";
            dgvInvoices.Columns["PaymentType"].HeaderText = "Payment Type";
            dgvInvoices.Columns["TotalAmount"].HeaderText = "Total Amount";
            dgvInvoices.Columns["PaymentStatus"].HeaderText = "Payment Satus";

            
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

            if (e.ColumnIndex == dgvInvoices.Columns["number"].Index && e.RowIndex >= 0)
            {
                e.Value = (e.RowIndex + 1).ToString();
                e.FormattingApplied = true;
            }
        }
    }
}
