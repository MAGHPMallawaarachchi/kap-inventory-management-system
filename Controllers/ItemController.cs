using inventory_management_system_kap.Models;
using inventory_management_system_kap.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management_system_kap.Controllers
{
    public class ItemController
    {
        private readonly ItemRepository _itemRepository;

        public ItemController(ItemRepository repository) 
        {
            this._itemRepository = repository;
        }

        public IEnumerable<ItemModel> GetAllItems(int page, int itemsPerPage) 
        {
            return _itemRepository.GetAll(page, itemsPerPage);
        }

        public IEnumerable<ItemModel> GetItemByValue(string value, int page, int itemsPerPage)
        {
            return _itemRepository.GetByValue(value, page, itemsPerPage);
        }

        public IEnumerable<ItemModel> SearchItem(string value, int page, int itemsPerPage)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return GetAllItems(page, itemsPerPage);
            }
            else
            {
                return GetItemByValue(value, page, itemsPerPage);
            }
        }

        public IEnumerable<ItemModel> FilterItems(string brandId, int page, int itemsPerPage)
        {
            if (brandId == null)
            {
                return _itemRepository.GetAll(page, itemsPerPage);
            }
            else
            {
                return _itemRepository.FilterItems(brandId, page, itemsPerPage);
            }
        }

        public bool HasMoreItemsOnPage(int page, int itemsPerPage)
        {
            IEnumerable<ItemModel> items = GetAllItems(page, itemsPerPage);
            return items.Any();
        }
    }
}
