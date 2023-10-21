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
                            ItemImage = (byte[])reader["ItemImage"],
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
                { "@PartNo", PartNo },
            };

            return GetItems(query, parameters);
        }

        public IEnumerable<ItemModel> FilterItems(string brandId, int page, int itemsPerPage)
        {
            int offset = (page - 1) * itemsPerPage;

            string query = "SELECT * FROM Item WHERE 1 = 1 ";

            var parameters = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(brandId))
            {
                query += " AND BrandId LIKE @BrandId + '%' ";
                parameters.Add("@BrandId", brandId);
            }

            query += " ORDER BY PartNo DESC " +
                     $"OFFSET {offset} ROWS FETCH NEXT {itemsPerPage} ROWS ONLY ";

            return GetItems(query, parameters);
        }

        public IEnumerable<string> GetAllPartNos()
        {
            string query = "SELECT PartNo FROM Item";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    var partNos = new List<string>();
                    while (reader.Read())
                    {
                        partNos.Add(reader["PartNo"].ToString());
                    }
                    return partNos;
                }
            }
        }

        public ItemModel GetItemByPartNo(string partNo)
        {
            string query = "SELECT * FROM Item WHERE PartNo = @PartNo";

            var parameters = new Dictionary<string, object>
            {
                { "@PartNo", partNo }
            };

            var items = GetItems(query, parameters);

            return items.FirstOrDefault();
        }

        public void UpdateQtySold(string partNo, int qtySold)
        {
            string query = "UPDATE Item " +
                           "SET QtySold = QtySold + @QtySold " +
                           "WHERE PartNo = @PartNo";

            var parameters = new Dictionary<string, object>
            {
                { "@PartNo", partNo },
                { "@QtySold", qtySold }
            };

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                foreach (var param in parameters)
                {
                    command.Parameters.Add(new SqlParameter(param.Key, param.Value));
                }

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public string DeleteItem(string partNo)
        {
            string query = "DELETE FROM Item WHERE PartNo = @PartNo";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PartNo", partNo);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return "Item deleted successfully.";
                    }
                    else
                    {
                        return "Item not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting item: " + ex.Message);
                return "An error occurred while deleting the item.";
            }
        }
      
        public void AddItem(ItemModel item)
        {
            string query = "INSERT INTO Item (PartNo, OEMNo, BrandId, QtySold, TotalQty, Category, Description, BuyingPrice, UnitPrice, ItemImage) " +
                           "VALUES (@PartNo, @OEMNo, @BrandId, @QtySold, @TotalQty, @Category, @Description, @BuyingPrice, @UnitPrice, @ItemImage)";

            var parameters = new Dictionary<string, object>
            {
                { "@PartNo", item.PartNo },
                { "@OEMNo", item.OEMNo },
                { "@BrandId", item.BrandId },
                { "@QtySold", item.QtySold },
                { "@TotalQty", item.TotalQty },
                { "@Category", item.Category },
                { "@Description", item.Description },
                { "@BuyingPrice", item.BuyingPrice },
                { "@UnitPrice", item.UnitPrice },
                { "@ItemImage", item.ItemImage }
            };

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
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
