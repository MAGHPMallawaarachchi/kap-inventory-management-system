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

namespace inventory_management_system_kap.Views
{
    public partial class CustomerFilterView : Form
    {
        public string City { get; set; }

        private CustomerController controller;
        private readonly string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;

        public CustomerFilterView(string city)
        {
            InitializeComponent();

            controller = new CustomerController(new CustomerRepository(sqlConnectionString));
            cmbCity.Text = City = city;

        }

        private void FilterPopupView_Load(object sender, EventArgs e)
        {
            SetCitiesInComboBox();
        }

        private void imgBtnClose_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnAddFilter_Click(object sender, EventArgs e)
        {
            City = cmbCity.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            City = string.Empty;
            cmbCity.Text = string.Empty;

            Close();
        }

        private void SetCitiesInComboBox()
        {
            var cities = controller.GetCities();

            cmbCity.Items.Clear();
            cmbCity.Items.AddRange(cities.ToArray());
        }
    }
}