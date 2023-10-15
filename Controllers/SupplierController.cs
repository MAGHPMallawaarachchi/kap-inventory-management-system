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

        public SupplierController(SupplierRepository repository)
        {
            this._supplierRepository = repository;
        }

        public IEnumerable<string> GetAllSupplierIds()
        {
            return _supplierRepository.GetAllSupplierIds();
        }
    }
}
