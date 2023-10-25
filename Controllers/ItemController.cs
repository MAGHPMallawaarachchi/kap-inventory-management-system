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
    public class ItemController
    {
        private readonly ItemRepository _itemRepository;

        public ItemController(ItemRepository repository) 
        {
            this._itemRepository = repository;
        }

        public IEnumerable<ItemModel> GetAllItems(int page, int itemsPerPage) 
        {
            try
            {
                return _itemRepository.GetAll(page, itemsPerPage);
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred while getting all customers\n" + ex);
                return null;
            }
        }

        public IEnumerable<ItemModel> GetItemByValue(string value, int page, int itemsPerPage)
        {
            try
            {
                return _itemRepository.GetByValue(value, page, itemsPerPage);
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred while searching items\n" + ex);
                return null;
            }
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while filtering items\n" + ex);
                return null;
            }
        }

        public bool HasMoreItemsOnPage(int page, int itemsPerPage)
        {
            IEnumerable<ItemModel> items = GetAllItems(page, itemsPerPage);
            return items.Any();
        }

        public IEnumerable<string> GetAllPartNos()
        {
            try
            {
                return _itemRepository.GetAllPartNos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while getting part numbers\n" + ex);
                return null;
            }
        }

        public ItemModel GetItemByPartNo(string partNo)
        {
            try
            {
                return _itemRepository.GetItemByPartNo(partNo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while getting item\n" + ex);
                return null;
            }
        }

        public string DeleteItem(string partNo)
        {
            try
            {
                return _itemRepository.DeleteItem(partNo);
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
      
        public void AddItem(ItemModel item)
        {
            try 
            { 
                _itemRepository.AddItem(item); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding new item\n" + ex);
            }
        }

        public int GetTotalAvailableItems()
        {
            try
            {
                return _itemRepository.CalculateTotalAvailableItems();
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred while calculating the total number of available items\n" + ex);
                return 0;
            }
        }

        public int GetTotalCategories()
        {
            try
            {
                return _itemRepository.CalculateTotalCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while calculating the total number of categories\n" + ex);
                return 0;
            }
        }

        public int GetLowInStockItems()
        {
            try
            {
                return _itemRepository.CalculateLowInStockItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while calculating the total number of low-in-stock items\n" + ex);
                return 0;
            }
        }

        public int GetOutOfStockItems()
        {
            try
            {
                return _itemRepository.CalculateOutOfStockItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while calculating the total number of out-of-stock items\n" + ex);
                return 0;
            }
        }
    }
}
