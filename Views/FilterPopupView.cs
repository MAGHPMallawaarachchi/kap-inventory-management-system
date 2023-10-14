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
    public partial class FilterPopupView : Form
    {
        public DateTime FromDate { get;  set; }
        public DateTime ToDate { get;  set; }
        public string Customer {  get;  set; }

        private CustomerController controller;
        private readonly string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;

        public FilterPopupView(DateTime fromDate, DateTime toDate, string customer)
        {
            InitializeComponent();

            controller = new CustomerController(new CustomerRepository(sqlConnectionString));

            dtpFromDate.Value = FromDate = fromDate;
            dtpToDate.Value = ToDate = toDate;
            cmbCustomer.Text = Customer = customer;
        }

        private void FilterPopupView_Load(object sender, EventArgs e)
        {
            SetCustomerIdsInComboBox();
        }

        private void imgBtnClose_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnAddFilter_Click(object sender, EventArgs e)
        {
            FromDate = dtpFromDate.Value;
            ToDate = dtpToDate.Value;
            Customer = cmbCustomer.SelectedText;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            FromDate = DateTime.MinValue;
            ToDate = DateTime.MaxValue;
            Customer = string.Empty;

            dtpFromDate.Value = dtpFromDate.MinDate;
            dtpToDate.Value = DateTime.Today;
            cmbCustomer.Text = string.Empty;

            Close();
        }

        private void SetCustomerIdsInComboBox()
        {
            var customerIds = controller.GettAllCustomerId();

            cmbCustomer.Items.Clear();
            cmbCustomer.Items.AddRange(customerIds.ToArray());
        }
    }
}
