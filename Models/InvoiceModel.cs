using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management_system_kap.Models
{
    public class InvoiceModel
    {
        private int invoiceNo;
        private string customerId;
        private DateTime date;
        private DateTime dueDate;
        private string paymentType;
        private int discount;
        private decimal totalAmount;
        private string paymentStatus;


        public int InvoiceNo { get => invoiceNo; set => invoiceNo = value; }
        public string CustomerId { get => customerId; set => customerId = value; }
        public DateTime Date { get => date; set => date = value; }
        public DateTime DueDate { get => dueDate; set => dueDate = value; }
        public string PaymentType { get => paymentType; set => paymentType = value; }
        public int Discount { get => discount; set => discount = value; }
        public decimal TotalAmount { get => totalAmount; set => totalAmount = value; }
        public string PaymentStatus { get => paymentStatus; set => paymentStatus = value; }

    }
}