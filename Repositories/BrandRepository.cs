using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management_system_kap.Repositories
{
    public class BrandRepository
    {
        private readonly string connectionString;

        public BrandRepository(string connectionString) 
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<string> GetAllBrands()
        {
            string query = "SELECT * FROM GetAllBrandIds()";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    var brands = new List<string>();
                    while (reader.Read())
                    {
                        brands.Add(reader["BrandId"].ToString());
                    }
                    return brands;
                }
            }
        }
    }
}
