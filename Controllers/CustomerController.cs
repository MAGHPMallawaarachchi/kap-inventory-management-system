using inventory_management_system_kap.Models;
using inventory_management_system_kap.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management_system_kap.Controllers
{
    public class CustomerController
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerController(CustomerRepository repository)
        {
            this._customerRepository = repository;
        }

        public IEnumerable<CustomerModel> GetAllCustomers(int page, int itemsPerPage)
        {
            return _customerRepository.GetAll(page, itemsPerPage);
        }


        public IEnumerable<CustomerModel> GetCustomerByValue(string value, int page, int itemsPerPage)
        {
            return _customerRepository.GetByValue(value, page, itemsPerPage);
        }

        public IEnumerable<CustomerModel> SearchCustomer(string value, int page, int itemsPerPage)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return GetAllCustomers(page, itemsPerPage);
            }
            else
            {
                return GetCustomerByValue(value, page, itemsPerPage);
            }
        }

        public bool HasMoreItemsOnPage(int page, int itemsPerPage)
        {
            IEnumerable<CustomerModel> items = GetAllCustomers(page, itemsPerPage);
            return items.Any();
        }

        public IEnumerable<string> GetCities()
        {
            return _customerRepository.GetUniqueCities();
        }

        public IEnumerable<CustomerModel> FilterCustomers(string city, int page, int itemsPerPage)
        {
            if (city == null)
            {
                return _customerRepository.GetAll(page, itemsPerPage);
            }
            else
            {
                return _customerRepository.FilterCustomers(city, page, itemsPerPage);
            }
        }
    }
}
