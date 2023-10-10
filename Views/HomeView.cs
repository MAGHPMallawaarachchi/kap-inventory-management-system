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
    public partial class HomeView : Form
    {
        UIHelper UIHelper = new UIHelper();
        public HomeView()
        {
            InitializeComponent();
        }

        private void HomeView_Load(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlQuickActions);
            UIHelper.UpdatePanelRegion(pnlSalesOverview);
            UIHelper.UpdatePanelRegion(pnlTopSellingItems);
            UIHelper.UpdatePanelRegion(panel3);
            UIHelper.UpdatePanelRegion(panel5);
        }

        private void pnlQuickActions_SizeChanged(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlQuickActions);
        }

        private void pnlSalesOverview_SizeChanged(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlSalesOverview);
        }

        private void pnlTopSellingItems_SizeChanged(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlTopSellingItems);
        }

        private void panel3_SizeChanged(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(panel3);
        }

        private void panel5_SizeChanged(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(panel5);
        }
    }
}
