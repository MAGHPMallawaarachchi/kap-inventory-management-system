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

        public InventoryView()
        {
            InitializeComponent();
            inventoryController = new InventoryController(new InventoryRepository(sqlConnectionString));
        }

        private void InventoryView_Load(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlInventorySummary);
            UIHelper.UpdatePanelRegion(pnlItems);
            dgvItems.ClearSelection();
            GetAllInventory();
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

        private void GetAllInventory()
        {
            IEnumerable<InventoryModel> inventory = inventoryController.GetAllInventory();
            dgvItems.DataSource = inventory.ToList();
            dgvItems.Columns["PartNo"].HeaderText = "Part No";
            dgvItems.Columns["BrandId"].HeaderText = "Brand";
            dgvItems.Columns["QtyInHand"].HeaderText = "Quantity In Hand";
            dgvItems.Columns["QtySold"].HeaderText = "Quantity Sold";
            dgvItems.Columns["UnitPrice"].HeaderText = "Unit Price";
            dgvItems.Columns["Availability"].HeaderText = "Availability";
        }

        private void dgvItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }
    }
}
