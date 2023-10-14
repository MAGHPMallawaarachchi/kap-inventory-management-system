using inventory_management_system_kap.Controllers;
using inventory_management_system_kap.Repositories;
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

namespace inventory_management_system_kap.Views.FilterViews
{
    public partial class ItemsFilterView : Form
    {
        public string Brand {  get; set; }

        private ItemController itemController;
        private BrandController brandController;
        private readonly string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;

        public ItemsFilterView(string brand)
        {
            InitializeComponent();
            itemController = new ItemController(new ItemRepository(sqlConnectionString));
            brandController = new BrandController(new BrandRepository(sqlConnectionString));

            cmbBrand.Text = Brand = brand;
        }

        private void ItemsFilterView_Load(object sender, EventArgs e)
        {
            SetBrandsInComboBox();
        }

        private void imgBtnClose_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnAddFilter_Click(object sender, EventArgs e)
        {
            Brand = cmbBrand.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            Brand = string.Empty;

            cmbBrand.Text = string.Empty;

            Close();
        }

        private void SetBrandsInComboBox()
        {
            var brands = brandController.GetAllBrands();

            cmbBrand.Items.Clear();
            cmbBrand.Items.AddRange(brands.ToArray());
        }
    }
}
