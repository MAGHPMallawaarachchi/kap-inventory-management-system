using Guna.UI2.AnimatorNS;
using inventory_management_system_kap.Controllers;
using inventory_management_system_kap.Models;
using inventory_management_system_kap.Repositories;
using InventoryManagementSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_management_system_kap.Views
{
    public partial class ItemDetailsView : Form
    {
        UIHelper UIHelper = new UIHelper();
        private readonly string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        private ItemDetailsController controller;
        public string PartNo { get => lblPartNo.Text ; set { lblPartNo.Text = value; } }

        public ItemDetailsView(string partNo)
        {
            InitializeComponent();
            controller = new ItemDetailsController(new ItemDetailsRepository(sqlConnectionString));
            PartNo = partNo;
            LoadItemDetails(partNo);
        }

        private void LoadItemDetails(string partNo)
        {
            ItemDetailsModel itemDetails = controller.GetItemDetailsByPartNo(partNo);
            if (itemDetails != null)
            {
                lblPartNo.Text = itemDetails.PartNo;
                lblPartNo2.Text = itemDetails.PartNo;
                lblOemNo.Text = itemDetails.OEMNo;
                lblDescription.Text = itemDetails.Description;
                lblBuyingPrice.Text = "Rs. " + itemDetails.BuyingPrice.ToString("N2");
                lblUnitPrice.Text = "Rs. " +  itemDetails.UnitPrice.ToString("N2");
                lblBrand.Text = itemDetails.BrandId;
                lblCategory.Text = itemDetails.Category;
                lblTotalQty.Text = itemDetails.TotalQty.ToString();
                lblQtyInHand.Text = itemDetails.QtyInHand.ToString();
                lblQtySold.Text = itemDetails.QtySold.ToString();

                if (itemDetails.ItemImage != null)
                {
                    using (MemoryStream ms = new MemoryStream(itemDetails.ItemImage))
                    {
                        Image itemImage = Image.FromStream(ms);
                        guna2PictureBox1.Image = itemImage;
                    }
                }
                else {
                    guna2PictureBox1.Image = null;
                }
            }

            ItemDetailsModel supplierDetails = controller.GetItemDetailsbyBrandId(itemDetails.BrandId);
            if (supplierDetails != null)
            {
                lblSupplierName.Text = supplierDetails.Name;
                lblSupplierEmail.Text = supplierDetails.Email;
                lblCountryOfOrigin.Text = supplierDetails.Country;
            }
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

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
