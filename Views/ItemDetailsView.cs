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
        private InventoryView inventoryView;
        UIHelper UIHelper = new UIHelper();
        private readonly string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        private ItemController itemController;
        private SupplierController supplierController;
        public string PartNo { get => lblPartNo.Text ; set { lblPartNo.Text = value; } }

        public ItemDetailsView(string partNo, InventoryView inventoryView)
        {
            InitializeComponent();
            this.inventoryView = inventoryView;
            itemController = new ItemController(new ItemRepository(sqlConnectionString));
            supplierController = new SupplierController(new SupplierRepository(sqlConnectionString));
            PartNo = partNo;
            LoadItemDetails(partNo);
        }

        //Display item details
        private void LoadItemDetails(string partNo)
        {
            ItemModel item = itemController.GetItemByPartNo(partNo);
            if (item != null)
            {
                lblPartNo.Text = item.PartNo;
                lblPartNo2.Text = item.PartNo;
                lblOemNo.Text = item.OEMNo;
                lblDescription.Text = item.Description;
                lblBuyingPrice.Text = "Rs. " + item.BuyingPrice.ToString("N2");
                lblUnitPrice.Text = "Rs. " + item.UnitPrice.ToString("N2");
                lblBrand.Text = item.BrandId;
                lblCategory.Text = item.Category;
                lblTotalQty.Text = item.TotalQty.ToString();
                lblQtyInHand.Text = item.QtyInHand.ToString();
                lblQtySold.Text = item.QtySold.ToString();

                if (item.ItemImage != null)
                {
                    using (MemoryStream ms = new MemoryStream(item.ItemImage))
                    {
                        Image itemImage = Image.FromStream(ms);
                        puItemImage.Image = itemImage;
                    }
                }
                else {
                    puItemImage.Image = null;
                }
            }

            SupplierModel supplierDetails = supplierController.GetSupplierByBrand(item.BrandId.ToString());
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

        //delete item details
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string partNo = lblPartNo.Text;
                string deletionMessage = itemController.DeleteItem(partNo);

                if (deletionMessage == "Item deleted successfully.")
                {
                    MessageBox.Show("Item deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CloseItemsDetails();
                }
                else if (deletionMessage == "Item not found.")
                {
                    MessageBox.Show("Item not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (deletionMessage == "Item found in Invoices, cannot delete.")
                {
                    MessageBox.Show("Item found in Invoices, cannot delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("An error occurred during the process. Please try again!");
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            CloseItemsDetails();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void CloseItemsDetails()
        {
            this.Close();
            inventoryView.RefreshDataGrid();
        }

    }
}
