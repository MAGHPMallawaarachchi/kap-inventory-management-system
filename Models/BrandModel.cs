using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management_system_kap.Models
{
    public class BrandModel
    {
        private string brandId;
        private string name;
        private string supplierId;
        private string countryOfOrigin;

        public string BrandId { get => brandId; set => brandId = value; }
        public string Name { get => name; set => name = value; }
        public string SupplierId { get => supplierId; set => supplierId = value; }
        public string CountryOfOrigin { get => countryOfOrigin; set => countryOfOrigin = value; }
    }
}
