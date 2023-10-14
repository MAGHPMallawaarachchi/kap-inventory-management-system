using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management_system_kap.Models
{
    internal class InventoryModel
    {
        private int partNo;
        private int oemNo;
        private string brandId;
        private int qtySold;
        private int qtyInHand;
        private int totalQty;
        private string category;
        private string description;
        private decimal buyingPrice;
        private decimal unitPrice;
        private long itemImage;


        public int PartNo { get => partNo; set => partNo = value; }
        public int OEMNo { get => oemNo; set => oemNo = value; }
        public string BrandId { get => brandId; set => brandId = value; }
        public int QtySold { get => qtySold; set => qtySold = value; }
        public int QtyInHand { get => qtyInHand; set => qtyInHand = value; }
        public int TotalQty { get => totalQty; set => totalQty = value; }
        public string Category { get => category; set => category = value; }
        public string Description { get => description; set => description = value; }
        public decimal BuyingPrice { get => buyingPrice; set => buyingPrice = value; }
        public decimal UnitPrice { get => unitPrice; set => unitPrice = value; }
        public long ItemImage { get => itemImage; set => itemImage = value; }
    }
}
