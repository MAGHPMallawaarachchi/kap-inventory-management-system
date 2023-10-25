using inventory_management_system_kap.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management_system_kap.Repositories
{
    public class SupplierRepository
    {
        private readonly string connectionString;

        public SupplierRepository(string connectionString) 
        {
            this.connectionString = connectionString;
        }
        private IEnumerable<SupplierModel> GetSuppliers(string query, Dictionary<string, object> parameters)
        {
            var SupplierList = new List<SupplierModel>();

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
                        var supplierModel = new SupplierModel
                        {
                            SupplierId = reader["SupplierId"].ToString(),
                            Name = reader["Name"].ToString(),
                            Address = reader["Address"].ToString(),
                            Email = reader["Email"].ToString(),
                            Country = reader["Country"].ToString(),
                        };
                        SupplierList.Add(supplierModel);
                    }
                }
            }

            return SupplierList;
        }

        public SupplierModel GetSupplierByBrand(string brandId)
        {

            string query = "SELECT * FROM GetSupplierByBrandId(@BrandId)";

            var parameters = new Dictionary<string, object> {
                {"@BrandId",brandId }
            };

            var supplier = GetSuppliers(query, parameters);

            return supplier.FirstOrDefault();
        }
    }
}
