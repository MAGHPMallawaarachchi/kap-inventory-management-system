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
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_management_system_kap.Views
{
    public partial class NewCustomerModalView : Form
    {
        private CustomersView customersView;
        private CustomerController customerController;
        private readonly string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;

        public NewCustomerModalView(CustomersView customersView)
        {
            InitializeComponent();
            customerController = new CustomerController(new CustomerRepository(sqlConnectionString));
            this.customersView = customersView;
        }

        private void imgBtnClose_Click(object sender, EventArgs e)
        {
            ClearForm();
            this.Close();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
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
                    ClearForm();
                    customersView.RefreshDataGrid();
                    MessageBox.Show("A new Customer added successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error has occurred: " + ex.Message);
                }
            }
        }

        private void ClearForm()
        {
            txtCustomerId.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtContactNumber.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private bool ValidateForm()
        {
            bool isValid = true;

            lblCustomerIdError.Visible = false;
            lblNameError.Visible = false;
            lblAddressError.Visible = false;
            lblCityError.Visible = false;
            lblContactNoError.Visible = false;

            if (string.IsNullOrWhiteSpace(txtCustomerId.Text))
            {
                lblCustomerIdError.Text = "Customer ID is required";
                lblCustomerIdError.Visible = true;
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                lblNameError.Text = "Name is required";
                lblNameError.Visible = true;
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                lblAddressError.Text = "Address is required.";
                lblAddressError.Visible = true;
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtCity.Text))
            {
                lblCityError.Text = "City is required.";
                lblCityError.Visible = true;
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtContactNumber.Text))
            {
                lblContactNoError.Text = "Contact Number is required.";
                lblContactNoError.Visible = true;
                isValid = false;
            }

            return isValid;
        }
    }
}
