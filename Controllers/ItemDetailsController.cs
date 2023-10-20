using inventory_management_system_kap.Models;
using inventory_management_system_kap.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management_system_kap.Controllers
{
    public class ItemDetailsController { 
        
        private readonly ItemDetailsRepository _itemDetailsRepository;

        public ItemDetailsController(ItemDetailsRepository itemDetailsepository)
        {
            _itemDetailsRepository = itemDetailsepository;
        }

        public ItemDetailsModel GetItemDetailsByPartNo(string partNo)
        {
            IEnumerable<ItemDetailsModel> itemDetailsList = _itemDetailsRepository.GetItemDetailsByPartNo(partNo);

            if (itemDetailsList != null && itemDetailsList.Any())
            {
                return itemDetailsList.First();
            }

            return null;
        }

        public ItemDetailsModel GetItemDetailsbyBrandId(string brandId)
        {
            IEnumerable<ItemDetailsModel> itemDetailsList = _itemDetailsRepository.GetItemDetailsbyBrandId(brandId);

            if (itemDetailsList != null && itemDetailsList.Any())
            {
                return itemDetailsList.First();
            }

            return null;
        }

        public string DeleteItemDetails(string partNo) { 

            return _itemDetailsRepository.DeleteItemDetails(partNo);
        }

    }
}
