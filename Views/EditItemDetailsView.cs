using Guna.UI2.AnimatorNS;
using Guna.UI2.WinForms;
using inventory_management_system_kap.Controllers;
using inventory_management_system_kap.Models;
using inventory_management_system_kap.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_management_system_kap.Views
{
    public partial class EditItemDetailsView : Form
    {
        private readonly string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        private ItemDetailsController controller;

        public EditItemDetailsView(string partNo, string brandId)
        {
            InitializeComponent();
            controller = new ItemDetailsController(new ItemDetailsRepository(sqlConnectionString));
            LoadItemDetails(partNo, brandId);
        }

        private void LoadItemDetails(string partNo, string brandId) {

            ItemDetailsModel itemDetails = controller.GetItemDetailsByPartNo(partNo);
            if (itemDetails != null)
            {
                txtPartNumber.Text = itemDetails.PartNo;
                txtOemNumber.Text = itemDetails.OEMNo;
                txtDescription.Text = itemDetails.Description;
                txtBuyingPrice.Text = "Rs. " + itemDetails.BuyingPrice.ToString("N2");
                txtUnitPrice.Text = "Rs. " + itemDetails.UnitPrice.ToString("N2");
                cmbBrand.SelectedItem = itemDetails.BrandId;
                cmbCategory.SelectedItem = itemDetails.Category;
                nudQuantity.Value = itemDetails.TotalQty;

                if (itemDetails.ItemImage != null)
                {
                    using (MemoryStream ms = new MemoryStream(itemDetails.ItemImage))
                    {
                        Image itemImage = Image.FromStream(ms);
                        picAddImage.Image = itemImage;
                    }
                }
                else
                {
                    picAddImage.Image = null;
                }
            }

            ItemDetailsModel supplierDetails = controller.GetItemDetailsbyBrandId(brandId);
            if (supplierDetails != null)
            {
                txtSupplier.Text = supplierDetails.Name;
                txtSupplierEmail.Text = supplierDetails.Email;
                txtSupplierCountry.Text = supplierDetails.Country;
            }

        }

        private void imgBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPartNumber.Clear();
            txtOemNumber.Clear();
            txtDescription.Clear();
            txtBuyingPrice.Clear();
            txtUnitPrice.Clear();
            txtSupplier.Clear();
            txtSupplierEmail.Clear();
            txtSupplierCountry.Clear();
            cmbCategory.SelectedIndex = -1;
            cmbBrand.SelectedIndex = -1;
            nudQuantity.Value = 0;
        }
    }
}
