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
    public partial class CustomersView : Form
    {
        UIHelper UIHelper = new UIHelper();
        public CustomersView()
        {
            InitializeComponent();
        }

        private void CustomersView_Load(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlCustomers);
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
    }
}
