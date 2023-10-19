using inventory_management_system_kap.Controllers;
using inventory_management_system_kap.Models;
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
    public partial class NewCustomerModalView : Form
    {
        private CustomerController customerController;
        private readonly string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;

        public NewCustomerModalView()
        {
            InitializeComponent();
            customerController = new CustomerController(new CustomerRepository(sqlConnectionString));
        }

        private void imgBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerModel customer = new CustomerModel
                {
                    CustomerId = txtCustomerId.Text,
                    Name = txtName.Text,
                    Address = txtAddress.Text,
                    City = txtCity.Text,
                    ContactNo = txtContactNumber.Text,
                };

                customerController.AddCustomers(customer);
                MessageBox.Show("A new Customer added successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred: " + ex.Message);
            }
        }
    }
}
