using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management_system_kap.Models
{
    public class ItemDetailsModel {

            private string partNo;
            private string oemNo;
            private string brandId;
            private int qtySold;
            private int qtyInHand;
            private int totalQty;
            private string category;
            private string description;
            private decimal buyingPrice;
            private decimal unitPrice;
            private string country;
            private string name;
            private string email;
            private byte[] itemImage;

            public string PartNo { get => partNo; set => partNo = value; }
            public string OEMNo { get => oemNo; set => oemNo = value; }
            public string BrandId { get => brandId; set => brandId = value; }
            public int QtySold { get => qtySold; set => qtySold = value; }
            public int QtyInHand { get => qtyInHand; set => qtyInHand = value; }
            public int TotalQty { get => totalQty; set => totalQty = value; }
            public string Category { get => category; set => category = value; }
            public string Description { get => description; set => description = value; }
            public decimal BuyingPrice { get => buyingPrice; set => buyingPrice = value; }
            public decimal UnitPrice { get => unitPrice; set => unitPrice = value; }
            public string Country { get => country; set => country = value; }
            public string Name { get => name; set => name = value; }
            public string Email { get => email; set => email = value; }
            public byte[] ItemImage { get => itemImage; set => itemImage = value; }

    }
}
