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
    public partial class InventoryView : Form
    {
        UIHelper UIHelper = new UIHelper();
        private InventoryController inventoryController;
        private readonly string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        private ItemDetailsView itemDetailsView;

        public InventoryView()
        {
            InitializeComponent();
            inventoryController = new InventoryController(new InventoryRepository(sqlConnectionString));
            dgvItems.RowPostPaint += dgvItems_RowPostPaint;
            dgvItems.CellClick += dgvItems_CellClick;

        }

        private void InventoryView_Load(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlInventorySummary);
            UIHelper.UpdatePanelRegion(pnlItems);
            dgvItems.ClearSelection();
            GetItemGrid();
        }

        private void pnlInventorySummary_SizeChanged(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlInventorySummary);
        }

        private void pnlItems_SizeChanged(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlItems);
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            NewItemModalView newItemModalView = new NewItemModalView();
            newItemModalView.ShowDialog();
        }

        private void GetItemGrid()
        {
            IEnumerable<InventoryModel> inventory = inventoryController.GetItemGrid();
            dgvItems.DataSource = inventory.ToList();
            dgvItems.Columns["number"].HeaderText = "No";
            dgvItems.Columns["PartNo"].HeaderText = "Part No";
            dgvItems.Columns["BrandId"].HeaderText = "Brand";
            dgvItems.Columns["QtyInHand"].HeaderText = "Quantity In Hand";
            dgvItems.Columns["QtySold"].HeaderText = "Quantity Sold";
            dgvItems.Columns["UnitPrice"].HeaderText = "Unit Price";
            dgvItems.Columns["Availability"].HeaderText = "Availability";
            dgvItems.Columns["OEMNo"].Visible = false;
            dgvItems.Columns["TotalQty"].Visible = false;
            dgvItems.Columns["Category"].Visible = false;
            dgvItems.Columns["Description"].Visible = false;
            dgvItems.Columns["BuyingPrice"].Visible = false;
            dgvItems.Columns["ItemImage"].Visible = false;
        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearchBar.Text.Trim();
            IEnumerable<InventoryModel> filteredItem = inventoryController.SearchItem(searchValue);
            dgvItems.DataSource = filteredItem.ToList();
        }

        private void dgvItems_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            int rowNumber = (e.RowIndex + 1);
            dgvItems.Rows[e.RowIndex].Cells["number"].Value = rowNumber.ToString();
        }

        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (itemDetailsView == null)
                {
                    itemDetailsView = new ItemDetailsView();
                    itemDetailsView.FormClosed += (s, ev) => { itemDetailsView = null; };
                    itemDetailsView.Show();
                }
            }

        }
    }
}
