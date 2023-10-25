using inventory_management_system_kap.Models;
using inventory_management_system_kap.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_management_system_kap.Controllers
{
    public class InvoiceController
    {
        private readonly InvoiceRepository _invoiceRepository;

        public InvoiceController(InvoiceRepository repository)
        {
            this._invoiceRepository = repository;
        }

        public IEnumerable<InvoiceModel> GetAllInvoices(int page, int itemsPerPage)
        {
            try
            {
                return _invoiceRepository.GetAll(page, itemsPerPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while getting all invoices\n" + ex);
                return null;
            }
        }

        public IEnumerable<InvoiceModel> FilterInvoices(DateTime fromDate, DateTime toDate, string customer, int page, int itemsPerPage)
        {
            try
            {
                if (fromDate == null || toDate == null || customer == null)
                {
                    return _invoiceRepository.GetAll(page, itemsPerPage);
                }
                else
                {
                    return _invoiceRepository.FilterInvoices(fromDate, toDate, customer, page, itemsPerPage);
                }             
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while filtering invoices\n" + ex);
                return null;
            }
        }


        public IEnumerable<InvoiceModel> GetInvoiceByValue(string value, int page, int itemsPerPage)
        {
            try
            {
                return _invoiceRepository.GetByValue(value, page, itemsPerPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while searching invoices\n" + ex);
                return null;
            }
        }

        public IEnumerable<InvoiceModel> SearchInvoice(string value, int page, int itemsPerPage)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return GetAllInvoices(page, itemsPerPage);
            }
            else
            {
                return GetInvoiceByValue(value, page, itemsPerPage);
            }
        }

        public bool HasMoreItemsOnPage(int page, int itemsPerPage)
        {
            IEnumerable<InvoiceModel> items = GetAllInvoices(page, itemsPerPage);
            return items.Any();
        }

        public int GetInvoiceNumber()
        {
            try
            {
                return _invoiceRepository.GetInvoiceNumber();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("An error occurred while fetching the invoice number\n" + ex);
                return 1;
            }
        }

        public decimal GetAmountPerItem(int discount, decimal unitPrice, int qty)
        {
            try
            {
                decimal amount = (decimal)(unitPrice * qty * (100 - discount) / 100);
                return amount;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while calculating the amount\n"+ex);
                return 0;
            }
        }

        public void AddInvoice(InvoiceModel invoice, List<InvoiceItemModel> invoiceItems)
        {
            try
            {
                _invoiceRepository.AddInvoice(invoice, invoiceItems);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the invoice\n" + ex);
            }
        }

        public DateTime GetDueDate(string paymentType)
        {
            try
            {
                if (paymentType == "cash")
                {
                    return DateTime.Now.AddMonths(1);
                }
                else if (paymentType == "credit")
                {
                    return DateTime.Now.AddMonths(3);
                }
                else
                {
                    return DateTime.Now.AddMonths(1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while calculating the due date\n" + ex);
                return DateTime.Now;
            }
        }

        public IEnumerable<InvoiceModel> GetInvoicesForCurrentMonth()
        {
            try
            {
                DateTime currentDate = DateTime.Now;
                DateTime firstDayOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
                DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                return _invoiceRepository.GetInvoicesForDateRange(firstDayOfMonth, lastDayOfMonth);
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred while getting the invoices\n"+ex);
                return Enumerable.Empty<InvoiceModel>();
            }
        }

        public IEnumerable<InvoiceModel> GetInvoicesForPreviousMonth()
        {
            try
            {
                DateTime currentDate = DateTime.Now;
                DateTime firstDayOfCurrentMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
                DateTime firstDayOfPreviousMonth = firstDayOfCurrentMonth.AddMonths(-1);
                DateTime lastDayOfPreviousMonth = firstDayOfCurrentMonth.AddDays(-1);

                return _invoiceRepository.GetInvoicesForDateRange(firstDayOfPreviousMonth, lastDayOfPreviousMonth);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while getting the invoices\n" + ex);
                return Enumerable.Empty<InvoiceModel>();
            }
        }

        public int GetTotalSales()
        {
            try
            {
                return _invoiceRepository.CalculateTotalSales();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while calculating the total number of sales\n" + ex);
                return 0;
            }
        }

        public decimal GetTotalRevenue(DateTime startDate, DateTime endDate)
        {
            try
            {
                return _invoiceRepository.CalculateTotalRevenue(startDate, endDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while calculating the total revenue\n" + ex);
                return 0;
            }
        }

        public decimal GetTotalCost(DateTime startDate, DateTime endDate)
        {
            try
            {
                return _invoiceRepository.CalculateTotalCost(startDate, endDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while calculating the total cost\n" + ex);
                return 0;
            }
        }
    }
}
