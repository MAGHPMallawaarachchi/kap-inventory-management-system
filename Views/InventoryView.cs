using InventoryManagementSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public InventoryView()
        {
            InitializeComponent();
        }

        private void InventoryView_Load(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlInventorySummary);
            UIHelper.UpdatePanelRegion(pnlItems);
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
    }
}
