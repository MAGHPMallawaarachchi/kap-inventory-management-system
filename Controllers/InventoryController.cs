using inventory_management_system_kap.Models;
using inventory_management_system_kap.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management_system_kap.Controllers
{
    public class InventoryController
    {
        private readonly InventoryRepository _inventoryRepository;

        public InventoryController(InventoryRepository inventoryRepository) 
        {
            this._inventoryRepository = inventoryRepository;
        }

        public IEnumerable<InventoryModel> GetItemGrid() 
        {
            return _inventoryRepository.GetItem();
        }

        public IEnumerable<InventoryModel> GetItemByValue(string value)
        {
            return _inventoryRepository.GetByValue(value);
        }

        public IEnumerable<InventoryModel> SearchItem(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return GetItemGrid();
            }
            else
            {
                return GetItemByValue(value);
            }
        }
    }
}
