using Guna.UI2.AnimatorNS;
using inventory_management_system_kap.Controllers;
using inventory_management_system_kap.Models;
using inventory_management_system_kap.Repositories;
using inventory_management_system_kap.Views.FilterViews;
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
    public partial class InventoryView : Form
    {
        UIHelper UIHelper = new UIHelper();
        private ItemController controller;
        private readonly string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        private int currentPage = 1;
        private int itemsPerPage = 9;
        private int initialRowNumber = 1;

        public InventoryView()
        {
            InitializeComponent();
            controller = new ItemController(new ItemRepository(sqlConnectionString));
        }

        public void RefreshInventoryView()
        {
            LoadInventorySummary();
            RefreshDataGrid();
        }

        private void InventoryView_Load(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlInventorySummary);
            UIHelper.UpdatePanelRegion(pnlItems);

            RefreshInventoryView();
            dgvItems.DataBindingComplete += dgvItems_DataBindingComplete;
        }

        private void RefreshDataGrid()
        {
            dgvItems.AutoGenerateColumns = false;

            int currentRowNumber = (currentPage - 1) * itemsPerPage + 1;

            IEnumerable<ItemModel> items = controller.GetAllItems(currentPage, itemsPerPage);
            var displayedItems = items.ToList();
            dgvItems.DataSource = displayedItems;
            lblPageNumber.Text = "Page " + currentPage;

            initialRowNumber = currentRowNumber;

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                row.Cells["number"].Value = currentRowNumber;
                currentRowNumber++;
            }
        }
        private void LoadInventorySummary()
        {
            lblItems.Text = controller.GetTotalAvailableItems().ToString();
            lblCategories.Text = controller.GetTotalCategories().ToString();
            lblLowInStock.Text = controller.GetLowInStockItems().ToString();
        }

        private void pnlInventorySummary_SizeChanged(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlInventorySummary);
        }

        private void pnlItems_SizeChanged(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlItems);
        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearchBar.Text.Trim();
            IEnumerable<ItemModel> filteredItem = controller.SearchItem(searchValue,currentPage,itemsPerPage);
            dgvItems.DataSource = filteredItem.ToList();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            NewItemModalView newItemModalView = new NewItemModalView(this);
            newItemModalView.ShowDialog();
        }

        private void dgvItems_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int currentRowNumber = initialRowNumber;
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                row.Cells["number"].Value = currentRowNumber;
                currentRowNumber++;
            }
        }

        private void dgvItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvItems.Columns["unitPrice"].Index && e.RowIndex >= 0)
            {
                if (e.Value is decimal unitPrice)
                {
                    e.Value = "Rs." + unitPrice.ToString("N2");
                    e.FormattingApplied = true;
                }
            }

            if (e.ColumnIndex == dgvItems.Columns["availability"].Index && e.RowIndex >= 0)
            {
                if (dgvItems["qtyInHand", e.RowIndex].Value is int qtyInHand)
                {
                    if (qtyInHand < 30)
                    {
                        e.Value = Properties.Resources.red_icon;
                        e.FormattingApplied = true;
                    }
                    else if (qtyInHand < 60)
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

        ItemsFilterView filterPopup = null;

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (filterPopup == null)
            {
                filterPopup = new ItemsFilterView(string.Empty);
            }

            if (filterPopup.ShowDialog() == DialogResult.OK)
            {
                string brand = filterPopup.Brand;

                var filteredItems = controller.FilterItems(brand, currentPage, itemsPerPage);
                dgvItems.DataSource = filteredItems.ToList();
            }
            else
            {
                RefreshDataGrid();
            }
        }

        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string partNo = dgvItems["PartNo", e.RowIndex].Value.ToString();

                ItemDetailsView itemDetailsView = new ItemDetailsView(partNo, this);
                itemDetailsView.PartNo = partNo;

                itemDetailsView.TopLevel = false;
                itemDetailsView.FormBorderStyle = FormBorderStyle.None;
                itemDetailsView.Dock = DockStyle.Fill;
                pnlChildForm.Controls.Add(itemDetailsView);
                pnlChildForm.Tag = itemDetailsView;
                itemDetailsView.BringToFront();
                itemDetailsView.Show();
            }
        }

        private void dgvItems_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvItems.Cursor = Cursors.Hand;
            }
        }

        private void dgvItems_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            dgvItems.Cursor = Cursors.Default;
        }
    }
}
