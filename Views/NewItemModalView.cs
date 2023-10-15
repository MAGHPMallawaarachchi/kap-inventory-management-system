using Guna.UI2.WinForms.Suite;
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
using static System.Net.Mime.MediaTypeNames;

namespace inventory_management_system_kap.Views
{
    public partial class NewItemModalView : Form
    {
        private ItemController itemController;
        private SupplierController supplierController;
        private BrandController brandController;
        private readonly string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;

        public NewItemModalView()
        {
            InitializeComponent();
            itemController = new ItemController(new ItemRepository(sqlConnectionString));
            supplierController = new SupplierController(new SupplierRepository(sqlConnectionString));
            brandController = new BrandController(new BrandRepository(sqlConnectionString));
            SetBrandIdsInComboBox();
            SetSupplierIdsInComboBox();
        }

        private void imgBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png;";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                picAddImage.Image = System.Drawing.Image.FromFile(imagePath);
            }
        }

        private void SetSupplierIdsInComboBox()
        {
            var supplierIds = supplierController.GetAllSupplierIds().ToList();
            supplierIds.Insert(0, "Select a supplier");

            cmbSupplier.Items.Clear();
            cmbSupplier.Items.AddRange(supplierIds.ToArray());

            cmbSupplier.SelectedIndex = 0;
        }

        private void SetBrandIdsInComboBox()
        {
            var brandIds = brandController.GetAllBrands().ToList();
            brandIds.Insert(0, "Select a brand");

            cmbBrand.Items.Clear();
            cmbBrand.Items.AddRange(brandIds.ToArray());

            cmbBrand.SelectedIndex = 0;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                ItemModel item = new ItemModel
                {
                    PartNo = txtPartNumber.Text,
                    OEMNo = txtOemNumber.Text,
                    BrandId = cmbBrand.Text,
                    QtySold = 0,
                    TotalQty = (int)nudQuantity.Value,
                    Category = txtCategory.Text,
                    Description = txtDescription.Text,
                    BuyingPrice = nudBuyingPrice.Value,
                    UnitPrice = nudUnitPrice.Value,
                };

                using (var stream = new MemoryStream())
                {
                    picAddImage.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    item.ItemImage = stream.ToArray();
                }

                itemController.AddItem(item);
                MessageBox.Show("Item added successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

    }
}
