using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management_system_kap.Models
{
    public class InvoiceItemModel
    {
        private int invoiceNo;
        private string partNo;
        private int qty;
        private decimal buyingPrice;
        private decimal unitPrice;
        private decimal amount;

        public int InvoiceNo { get => invoiceNo; set => invoiceNo = value; }
        public string PartNo { get => partNo; set => partNo = value; }
        public int Qty { get => qty; set => qty = value; }
        public decimal BuyingPrice { get => buyingPrice; set => buyingPrice = value; }
        public decimal UnitPrice { get => unitPrice; set => unitPrice = value; }
        public decimal Amount { get => amount; set => amount = value; }
    }
}
