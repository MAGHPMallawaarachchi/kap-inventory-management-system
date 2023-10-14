using inventory_management_system_kap.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management_system_kap.Repositories
{
    internal class InventoryRepository
    {
        private readonly string connectionString;

        public InventoryRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<InventoryModel> GetAll()
        {
            var inventoryList = new List<InventoryModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Item ORDER BY PartNo DESC";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var inventoryModel = new InventoryModel
                        {
                            PartNo = (int)reader["PartNo"],
                            OEMNo = (int)reader["OEMNo"],
                            BrandId = (string)reader["BrandId"],
                            QtySold = (int)reader["QtySold"], 
                            QtyInHand = (int)reader["QtyInHand"], 
                            TotalQty = (int)reader["TotalQty"], 
                            Category = (string)reader["Category"],
                            Description = (string)reader["Description"],
                            BuyingPrice = (decimal)reader["BuyingPrice"],
                            UnitPrice = (decimal)reader["UnitPrice"],
                            ItemImage = (long)reader["ItemImage"]
                        };
                        inventoryList.Add(inventoryModel);
                    }
                }
            }
            return inventoryList;
        }
    }
}
