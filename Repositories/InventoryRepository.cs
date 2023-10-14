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
    public class InventoryRepository
    {
        private readonly string connectionString;

        public InventoryRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IEnumerable<InventoryModel> GetItem()
        {
            var inventoryList = new List<InventoryModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT PartNo, BrandID, QtySold, QtyInHand, UnitPrice FROM Item ORDER BY PartNo DESC";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var inventoryModel = new InventoryModel
                        {
                            PartNo = (string)reader["PartNo"],
                            BrandId = (string)reader["BrandId"],
                            QtyInHand = (int)reader["QtyInHand"],
                            QtySold = (int)reader["QtySold"],
                            UnitPrice = (decimal)reader["UnitPrice"],
                        };

                        // Calculate availability
                        inventoryModel.Availability = inventoryModel.QtyInHand > inventoryModel.QtySold ? "Yes" : "No";

                        inventoryList.Add(inventoryModel);
                    }
                }
            }
            return inventoryList;
        }


        public IEnumerable<InventoryModel> GetByValue(string value)
        {
            var inventoryList = new List<InventoryModel>();
            string PartNo = value;
            string BrandId = value;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT PartNo,BrandID, QtySold,QtyInHand,UnitPrice FROM Item " +
                                        "WHERE PartNo = @PartNo OR BrandId LIKE @BrandId+'%' " +
                                        "ORDER BY PartNo DESC";

                command.Parameters.Add("@PartNo", SqlDbType.VarChar).Value = PartNo;
                command.Parameters.Add("@BrandId", SqlDbType.VarChar).Value = BrandId;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var inventoryModel = new InventoryModel
                        {
                            PartNo = (string)reader["PartNo"],
                            BrandId = (string)reader["BrandId"],
                            QtyInHand = (int)reader["QtyInHand"],
                            QtySold = (int)reader["QtySold"],
                            UnitPrice = (decimal)reader["UnitPrice"]
                        };
                        inventoryList.Add(inventoryModel);
                    }
                }
            }
            return inventoryList;
        }
    }
}
