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
    public class ItemRepository
    {
        private readonly string connectionString;

        public ItemRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private IEnumerable<ItemModel> GetItems(string query, Dictionary<string, object> parameters)
        {
            var itemList = new List<ItemModel>();

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
                        var itemModel = new ItemModel
                        {
                            PartNo = (string)reader["PartNo"],
                            OEMNo = (string)reader["OEMNo"],
                            BrandId = (string)reader["BrandId"],
                            QtySold = (int)reader["QtySold"],
                            QtyInHand = (int)reader["QtyInHand"],
                            TotalQty = (int)reader["TotalQty"],
                            Category = (string)reader["category"],
                            Description = (string)reader["description"],
                            BuyingPrice = (decimal)reader["BuyingPrice"],
                            UnitPrice = (decimal)reader["UnitPrice"],
                        };
                        itemList.Add(itemModel);
                    }
                }
            }
            return itemList;
        }

        public IEnumerable<ItemModel> GetAll(int page, int itemsPerPage)
        {
            int offset = (page - 1) * itemsPerPage;
            string query = "SELECT * FROM Item ORDER BY PartNo DESC " +
                           "OFFSET @Offset ROWS FETCH NEXT @ItemsPerPage ROWS ONLY";

            var parameters = new Dictionary<string, object>
            {
                { "@Offset", offset },
                { "@ItemsPerPage", itemsPerPage }
            };

            return GetItems(query, parameters);
        }

        public IEnumerable<ItemModel> GetByValue(string value, int page, int itemsPerPage)
        {
            string PartNo = value;

            int offset = (page - 1) * itemsPerPage;

            string query = "SELECT * FROM Item " +
                           "WHERE (PartNo LIKE @PartNo+'%') " +
                           "ORDER BY PartNo DESC " +
                           $"OFFSET {offset} ROWS FETCH NEXT {itemsPerPage} ROWS ONLY";

            var parameters = new Dictionary<string, object>
            {
                { "@InvoiceNo", PartNo },
            };

            return GetItems(query, parameters);
        }
    }
}
