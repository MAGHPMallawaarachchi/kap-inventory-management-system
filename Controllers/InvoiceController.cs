using inventory_management_system_kap.Models;
using inventory_management_system_kap.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return _invoiceRepository.GetAll(page, itemsPerPage);
        }

        public IEnumerable<InvoiceModel> FilterInvoices(DateTime fromDate, DateTime toDate, string customer, int page, int itemsPerPage)
        {
            if(fromDate == null || toDate == null || customer == null)
            {
                return _invoiceRepository.GetAll(page, itemsPerPage);
            }
            else
            {
                return _invoiceRepository.FilterInvoices(fromDate, toDate, customer, page, itemsPerPage);
            }
        }


        public IEnumerable<InvoiceModel> GetInvoiceByValue(string value, int page, int itemsPerPage)
        {
            return _invoiceRepository.GetByValue(value, page, itemsPerPage);
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

        public int GetLastInvoiceNumber()
        {
            return _invoiceRepository.GetLastInvoiceNumber();
        }

        public decimal GetAmountPerItem(int discount, decimal unitPrice, int qty)
        {
            decimal amount = (decimal)(unitPrice * qty * (100 - discount) / 100);
            return amount;
        }

        public void AddInvoice(InvoiceModel invoice, List<InvoiceItemModel> invoiceItems)
        {
            _invoiceRepository.AddInvoice(invoice, invoiceItems);
        }

        public DateTime GetDueDate(string paymentType)
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
    }
}
