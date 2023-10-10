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
    public partial class AddInvoiceView : Form
    {
        UIHelper UIHelper = new UIHelper();

        public AddInvoiceView()
        {
            InitializeComponent();
        }

        private void AddInvoiceView_Load(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlCustomerDetails);
            UIHelper.UpdatePanelRegion(pnlInvoiceDetails);
            UIHelper.UpdatePanelRegion(pnlItems);
        }

        private void pnlInvoiceDetails_SizeChanged(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlInvoiceDetails);
        }

        private void pnlCustomerDetails_SizeChanged(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlCustomerDetails);
        }

        private void pnlItems_SizeChanged(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlItems);
        }
    }
}
