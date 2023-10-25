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
    public class CustomerController
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerController(CustomerRepository repository)
        {
            this._customerRepository = repository;
        }

        public IEnumerable<CustomerModel> GetAllCustomers(int page, int itemsPerPage)
        {
            try
            {
                return _customerRepository.GetAll(page, itemsPerPage);
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred while getting all customers\n" +ex);
                return null;
            }
        }


        public IEnumerable<CustomerModel> GetCustomerByValue(string value, int page, int itemsPerPage)
        {
            try
            {
                return _customerRepository.GetByValue(value, page, itemsPerPage);
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred while searching customers\n" + ex);
                return null;
            }
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
            try
            {
                return _customerRepository.GetUniqueCities();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while getting cities\n" + ex);
                return null;
            }
        }

        public IEnumerable<CustomerModel> FilterCustomers(string city, int page, int itemsPerPage)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while filtering customers\n" + ex);
                return null;
            }
        }

        public IEnumerable<string> GettAllCustomerId()
        {
            try
            {
                return _customerRepository.GetAllCustomerIds();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while getting customers IDs\n" + ex);
                return null;
            }
        }

        public CustomerModel GetCustomerByCustomerId(string customerId)
        {
            try
            {
                return _customerRepository.GetCustomerByCustomerId(customerId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while getting customers\n" + ex);
                return null;
            }
        }

        public void AddCustomers(CustomerModel customer)
        {
            try
            {
                _customerRepository.AddCustomer(customer);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding new customer\n" + ex);
            }
        }
    }
}
