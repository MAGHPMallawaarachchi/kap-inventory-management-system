using inventory_management_system_kap.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management_system_kap.Repositories
{
    public class CustomerRepository
    {
        private readonly string connectionString;

        public CustomerRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        private IEnumerable<CustomerModel> GetCustomers(string query, Dictionary<string, object> parameters)
        {
            var customerList = new List<CustomerModel>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                foreach (var param in parameters)
                {
                    command.Parameters.Add(new SqlParameter(param.Key, param.Value));
                }

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var customerModel = new CustomerModel
                        {
                            CustomerId = reader["CustomerId"].ToString(),
                            Name = reader["Name"].ToString(),
                            Address = reader["Address"].ToString(),
                            City = reader["City"].ToString(),
                            ContactNo = reader["ContactNo"].ToString(),
                        };
                        customerList.Add(customerModel);
                    }
                }
            }

            return customerList;
        }

        public IEnumerable<CustomerModel> GetAll(int page, int itemsPerPage)
        {
            string query = "SELECT * FROM GetAllCustomers(@Page, @CustomersPerPage)";

            var parameters = new Dictionary<string, object>
            {
                { "@Page", page },
                { "@CustomersPerPage", itemsPerPage }
            };

            return GetCustomers(query, parameters);
        }


        public IEnumerable<CustomerModel> GetByValue(string value, int page, int itemsPerPage)
        {

            string CustomerId = value;
            int offset = (page - 1) * itemsPerPage;

            string query = "SELECT * FROM SearchCustomersByCustomerId(@CustomerId, @Offset, @ItemsPerPage)";

            var parameters = new Dictionary<string, object>
            {
                { "@CustomerId", CustomerId },
                { "@Offset", offset },
                { "@ItemsPerPage", itemsPerPage }
            };

            return GetCustomers(query, parameters);
        }

        public IEnumerable<string> GetUniqueCities()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT DISTINCT City FROM Customer";

                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    var cities = new List<string>();

                    while (reader.Read())
                    {
                        string city = reader["City"].ToString();
                        cities.Add(city);
                    }

                    return cities;
                }
            }
        }

        public IEnumerable<CustomerModel> FilterCustomers(string city, int page, int itemsPerPage)
        {
            int offset = (page - 1) * itemsPerPage;

            string query = "SELECT * FROM FilterCustomersByCity(@City, @Offset, @ItemsPerPage)";

            var parameters = new Dictionary<string, object>
            {
                { "@City", city },
                { "@Offset", offset },
                { "@ItemsPerPage", itemsPerPage }
            };

            return GetCustomers(query, parameters);
        }

        public IEnumerable<string> GetAllCustomerIds()
        {
            string query = "SELECT CustomerId FROM Customer";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    var customerIds = new List<string>();
                    while (reader.Read())
                    {
                        customerIds.Add(reader["CustomerId"].ToString());
                    }
                    return customerIds;
                }
            }
        }

        public CustomerModel GetCustomerByCustomerId(string customerId)
        {
            string query = "SELECT * FROM GetCustomerByCustomerId(@CustomerId)";

            var parameters = new Dictionary<string, object>
            {
                { "@CustomerId", customerId }
            };

            var customers = GetCustomers(query, parameters);

            return customers.FirstOrDefault();
        }

        public void AddCustomer(CustomerModel customer)
        {
            string query = "AddCustomer";

            var parameters = new Dictionary<string, object>
            {
                { "@CustomerId", customer.CustomerId },
                { "@Name", customer.Name },
                { "@Address", customer.Address },
                { "@City", customer.City },
                { "@ContactNo", customer.ContactNo },               
            };

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                foreach (var param in parameters)
                {
                    command.Parameters.Add(new SqlParameter(param.Key, param.Value));
                }

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}