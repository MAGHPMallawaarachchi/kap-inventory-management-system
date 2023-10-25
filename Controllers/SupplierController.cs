using inventory_management_system_kap.Models;
using inventory_management_system_kap.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            try
            {
                return _supplierRepository.GetSupplierByBrand(brandId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while getting the supplier\n"+ex);
                return null; 
            }
        }
    }
}
