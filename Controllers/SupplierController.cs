using inventory_management_system_kap.Models;
using inventory_management_system_kap.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management_system_kap.Controllers
{
    public class SupplierController
    {
        private readonly SupplierRepository _supplierRepository;

        public SupplierController(SupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public SupplierModel GetSupplierByBrand(string brandId)
        {
            return _supplierRepository.GetSupplierByBrand(brandId);
        }
    }
}
