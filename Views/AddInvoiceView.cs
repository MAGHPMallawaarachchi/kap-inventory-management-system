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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_management_system_kap.Views
{
    public partial class AddInvoiceView : Form
    {
        UIHelper UIHelper = new UIHelper();
        private InvoiceController invoiceController;
        private CustomerController customerController;
        private ItemController itemController;
        private readonly string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;

        public AddInvoiceView()
        {
            InitializeComponent();
            invoiceController = new InvoiceController(new InvoiceRepository(sqlConnectionString));
            customerController = new CustomerController(new CustomerRepository(sqlConnectionString));
            itemController = new ItemController(new ItemRepository(sqlConnectionString));
            setLabels();
            InitializeDataGridView();
        }

        private void AddInvoiceView_Load(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlCustomerDetails);
            UIHelper.UpdatePanelRegion(pnlInvoiceDetails);
            UIHelper.UpdatePanelRegion(pnlItems);

            setLabels();
        }

        private void cmbCustomer_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cmbCustomer.Text != "-- customer id --")
            {
                CustomerModel customer = customerController.GetCustomerByCustomerId(cmbCustomer.Text);
                if (customer != null)
                {
                    lblName.Text = customer.Name;
                    lblAddress.Text = customer.Address;
                    lblPhoneNo.Text = customer.ContactNo;
                }
                else
                {
                    setCustomerDetails();
                }
            }
            else
            {
                setCustomerDetails() ;
            }
        }

        private void InitializeDataGridView()
        {
            dgvInvoice.AutoGenerateColumns = false;

            List<string> partNos = itemController.GetAllPartNos().ToList();
            partNos.Insert(0, "-- part number --");
            partNo.DataSource = partNos;

            AddRow();
        }

        private void dgvInvoice_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex == dgvInvoice.Columns["partNo"].Index)
            {
                var selectedPartNo = dgvInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                if(selectedPartNo != null || selectedPartNo != "-- part number --")
                {
                    var item = itemController.GetItemByPartNo(selectedPartNo);
                    if (item != null)
                    {
                        dgvInvoice.Rows[e.RowIndex].Cells["brand"].Value = item.BrandId;
                        dgvInvoice.Rows[e.RowIndex].Cells["description"].Value = item.Description;
                        dgvInvoice.Rows[e.RowIndex].Cells["unitPrice"].Value = item.UnitPrice;
                    }
                }
            }

            if (e.RowIndex >= 0 && e.ColumnIndex == dgvInvoice.Columns["qty"].Index)
            {
                int discount = (int)nudDiscount.Value;
                int qty;

                if (dgvInvoice.Rows[e.RowIndex].Cells["qty"].Value != null &&
                    int.TryParse(dgvInvoice.Rows[e.RowIndex].Cells["qty"].Value.ToString(), out qty) &&
                    qty != 0)
                {
                    decimal unitPrice = (decimal)dgvInvoice.Rows[e.RowIndex].Cells["unitPrice"].Value;
                    decimal amountPerItem = invoiceController.GetAmountPerItem(discount, unitPrice, qty);
                    dgvInvoice.Rows[e.RowIndex].Cells["amount"].Value = amountPerItem;

                    UpdateTotalAmount();
                }
            }

        }

        private void setLabels()
        {
            lblInvoiceNo.Text = "KAP-" + invoiceController.GetLastInvoiceNumber().ToString("D6");
            lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt");
            setCustomerDetails();
            nudDiscount.Value = 0;
            cmbPaymentType.SelectedIndex = 0;
            SetCustomerIdsInComboBox();
        }

        private void setCustomerDetails()
        {
            lblName.Text = "-- name --";
            lblAddress.Text = "-- address --";
            lblPhoneNo.Text = "-- phone number --";
        }

        private void SetCustomerIdsInComboBox()
        {
            var customerIds = customerController.GettAllCustomerId().ToList();
            customerIds.Insert(0, "-- customer id --");

            cmbCustomer.Items.Clear();
            cmbCustomer.Items.AddRange(customerIds.ToArray());

            cmbCustomer.SelectedIndex = 0;
        }

        private void AddRow()
        {
            dgvInvoice.Rows.Add();

            int rowIndex = dgvInvoice.Rows.Count - 1;

            DataGridViewRow templateRow = dgvInvoice.Rows[rowIndex];
            templateRow.Cells[0].Value = rowIndex + 1;
            templateRow.Cells[2].Value = "-- Brand --";
            templateRow.Cells[3].Value = "-- Description --";
            templateRow.Cells[4].Value = 0;
            templateRow.Cells[5].Value = 0.00;
            templateRow.Cells[6].Value = 0.00;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddRow();
        }

        private void pnlInvoiceDetails_SizeChanged(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlInvoiceDetails);
        }

        private void pnlCustomerDetails_SizeChanged(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlCustomerDetails);
        }

        private void pnlItems_SizeChanged(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlItems);
        }

        private void dgvInvoice_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                if(e.ColumnIndex == dgvInvoice.Columns["qty"].Index)
                {
                    dgvInvoice.Cursor = Cursors.IBeam;
                }
                else if (e.ColumnIndex == dgvInvoice.Columns["partNo"].Index)
                {
                    dgvInvoice.Cursor = Cursors.Hand;
                }
                else
                {
                    dgvInvoice.Cursor = Cursors.Default;
                }
            }
        }

        private void dgvInvoice_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            dgvInvoice.Cursor = Cursors.Default;
        }

        private void nudDiscount_ValueChanged(object sender, EventArgs e)
        {
            RecalculateAmounts();
        }

        private void RecalculateAmounts()
        {
            foreach (DataGridViewRow row in dgvInvoice.Rows)
            {
                if (row.Cells["qty"].Value != null && row.Cells["unitPrice"].Value != null)
                {
                    int qty;
                    decimal unitPrice;

                    if (int.TryParse(row.Cells["qty"].Value.ToString(), out qty) &&
                        decimal.TryParse(row.Cells["unitPrice"].Value.ToString(), out unitPrice))
                    {
                        int discount = (int)nudDiscount.Value;
                        decimal amountPerItem = invoiceController.GetAmountPerItem(discount, unitPrice, qty);
                        row.Cells["amount"].Value = amountPerItem;
                    }
                }
            }

            UpdateTotalAmount();
        }

        private decimal CalculateTotalAmount()
        {
            decimal totalAmount = 0;

            foreach (DataGridViewRow row in dgvInvoice.Rows)
            {
                if (row.Cells["amount"].Value != null)
                {
                    decimal amount;

                    if (decimal.TryParse(row.Cells["amount"].Value.ToString(), out amount))
                    {
                        totalAmount += amount;
                    }
                }
            }

            return totalAmount;
        }

        private void UpdateTotalAmount()
        {
            decimal totalAmount = CalculateTotalAmount();
            lblTotalAmount.Text = "Rs." +totalAmount.ToString("N2");
        }

        private bool ValidateInvoice()
        {
            if (cmbCustomer.Text == "-- customer id --")
            {
                MessageBox.Show("Please select a customer.");
                return false;
            }

            bool anyItemsAdded = false;
            List<string> addedPartNos = new List<string>();
            bool hasZeroQty = false;

            foreach (DataGridViewRow row in dgvInvoice.Rows)
            {
                if (row.Cells["partNo"].Value != null)
                {
                    anyItemsAdded = true;
                    string partNo = row.Cells["partNo"].Value.ToString();

                    if (addedPartNos.Contains(partNo))
                    {
                        MessageBox.Show("Duplicate item detected: " + partNo);
                        return false;
                    }

                    addedPartNos.Add(partNo);
                }

                if (row.Cells["qty"].Value != null)
                {
                    int qty;
                    if (int.TryParse(row.Cells["qty"].Value.ToString(), out qty) && qty == 0)
                    {
                        hasZeroQty = true;
                    }
                }
            }

            if (!anyItemsAdded)
            {
                MessageBox.Show("Please add at least one item to the invoice.");
                return false;
            }

            if (hasZeroQty)
            {
                MessageBox.Show("The invoice contains an item with no quantity.");
                return false;
            }

            return true;
        }


        private void btnAddInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if(ValidateInvoice())
                {
                    InvoiceModel invoice = new InvoiceModel
                    {
                        CustomerId = cmbCustomer.Text.ToString(),
                        Date = DateTime.Now,
                        DueDate = invoiceController.GetDueDate(cmbPaymentType.Text.ToLower()),
                        PaymentType = cmbPaymentType.Text.ToLower(),
                        Discount = (int)nudDiscount.Value,
                        TotalAmount = CalculateTotalAmount(),
                        PaymentStatus = "pending"
                    };

                    List<InvoiceItemModel> invoiceItems = new List<InvoiceItemModel>();
                    foreach (DataGridViewRow row in dgvInvoice.Rows)
                    {
                        int qty;

                        if (row.Cells["partNo"].Value != null && row.Cells["qty"].Value != null && row.Cells["unitPrice"].Value != null && row.Cells["amount"].Value != null && int.TryParse(row.Cells["qty"].Value.ToString(), out qty))
                        {
                            string partNo = row.Cells["partNo"].Value.ToString();
                            decimal buyingPrice = itemController.GetItemByPartNo(partNo).BuyingPrice;
                            decimal unitPrice = itemController.GetItemByPartNo(partNo).UnitPrice;

                            var item = new InvoiceItemModel
                            {
                                InvoiceNo = invoiceController.GetLastInvoiceNumber(),
                                PartNo = partNo,
                                Qty = qty,
                                BuyingPrice = buyingPrice,
                                UnitPrice = unitPrice,
                                Amount = invoiceController.GetAmountPerItem((int)nudDiscount.Value, unitPrice, qty)
                            };

                            invoiceItems.Add(item);
                            itemController.UpdateQtySold(item.PartNo, item.Qty);
                        }
                    }
                    invoiceController.AddInvoice(invoice, invoiceItems);
                    MessageBox.Show("Invoice saved successfully");
                    ClearPage();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            ClearPage();
        }

        private void ClearPage()
        {
            dgvInvoice.Rows.Clear();
            AddRow();
            SetCustomerIdsInComboBox();
            setLabels();
        }
    }
}
