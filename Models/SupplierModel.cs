using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management_system_kap.Models
{
    public class SupplierModel
    {
        private string supplierId;
        private string name;
        private string email;
        private string country;
        private string address;

        public string SupplierId { get => supplierId; set => supplierId = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Country { get => country; set => country = value; }
        public string Address { get => address; set => address = value; }
    }
}
