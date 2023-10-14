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
    public partial class ItemDetailsView : Form
    {
        UIHelper UIHelper = new UIHelper();
        public string PartNo { get => lblPartNo.Text ; set { lblPartNo.Text = value; } }

        public ItemDetailsView(string partNo)
        {
            InitializeComponent();
            PartNo = partNo;
        }

        private void ItemDetailsView_Load(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlItemDetails);
            lblPartNo2.Text = PartNo;
        }

        private void pnlItemDetails_SizeChanged(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlItemDetails);
        }
    }
}
