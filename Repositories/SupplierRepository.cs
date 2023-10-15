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

        public IEnumerable<string> GetAllSupplierIds()
        {
            string query = "SELECT SupplierId FROM Supplier";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    var suppliers = new List<string>();
                    while (reader.Read())
                    {
                        suppliers.Add(reader["SupplierId"].ToString());
                    }
                    return suppliers;
                }
            }
        }
    }
}
