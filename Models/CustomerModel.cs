using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management_system_kap.Models
{
    public class CustomerModel
    {
        private string customerId;
        private string name;
        private string address;
        private string city;
        private int contactNo;

        public string CustomerId { get => customerId; set => customerId = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public int ContactNo { get => contactNo; set => contactNo = value; }
    }
}
