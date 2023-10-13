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
    public partial class CustomersView : Form
    {
        UIHelper UIHelper = new UIHelper();
        private CustomerController controller;
        private readonly string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        private int currentPage = 1;
        private int itemsPerPage = 10;
        private int initialRowNumber = 1;
        public CustomersView()
        {
            InitializeComponent();
            controller = new CustomerController(new CustomerRepository(sqlConnectionString));
        }

        private void RefreshDataGrid()
        {
            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.ColumnCount = 9;

            int currentRowNumber = (currentPage - 1) * itemsPerPage + 1;

            IEnumerable<CustomerModel> customers = controller.GetAllCustomers(currentPage, itemsPerPage);
            var displayedCustomers = customers.ToList();
            dgvCustomers.DataSource = displayedCustomers;
            lblPageNumber.Text = "Page " + currentPage;

            initialRowNumber = currentRowNumber;

            foreach (DataGridViewRow row in dgvCustomers.Rows)
            {
                row.Cells["number"].Value = currentRowNumber;
                currentRowNumber++;
            }

        }
        private void CustomersView_Load(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlCustomers);
            dgvCustomers.ClearSelection();

            RefreshDataGrid();
            dgvCustomers.DataBindingComplete += dgvCustomers_DataBindingComplete;
        }

        private void pnlCustomers_SizeChanged(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlCustomers);
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            NewCustomerModalView newCustomerModalView = new NewCustomerModalView();
            newCustomerModalView.ShowDialog();
        }

        private void dgvCustomers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int currentRowNumber = initialRowNumber;
            foreach (DataGridViewRow row in dgvCustomers.Rows)
            {
                row.Cells["number"].Value = currentRowNumber;
                currentRowNumber++;
            }
        }

        private void dgvCustomers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearchBar.Text.Trim();
            IEnumerable<CustomerModel> filteredCustomers = controller.SearchCustomer(searchValue, currentPage, itemsPerPage);
            dgvCustomers.DataSource = filteredCustomers.ToList();
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

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex == dgvCustomers.Columns["edit"].Index)
            {

            }

            if(e.RowIndex >= 0 && e.ColumnIndex == dgvCustomers.Columns["delete"].Index)
            {

            }
        }

        private void dgvCustomers_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvCustomers.Columns["edit"].Index ||
                    e.ColumnIndex == dgvCustomers.Columns["delete"].Index)
                {
                    dgvCustomers.Cursor = Cursors.Hand;
                }
                else
                {
                    dgvCustomers.Cursor = Cursors.Default;
                }
            }
        }

        private void dgvCustomers_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        { 
            dgvCustomers.Cursor = Cursors.Default;
        }
    }
}
