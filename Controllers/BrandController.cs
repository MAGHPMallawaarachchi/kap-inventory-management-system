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
    public class BrandController
    {
        private readonly BrandRepository _brandRepository;

        public BrandController(BrandRepository repository)
        {
            this._brandRepository = repository;
        }

        public IEnumerable<string> GetAllBrands()
        {
            try
            {
                return _brandRepository.GetAllBrands();
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred while getting Brand Ids\n" + ex);
                return new List<string>();
            }
        }
    }
}
