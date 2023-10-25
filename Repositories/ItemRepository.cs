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
            string query = "SELECT * FROM GetAllItems(@Page, @ItemsPerPage)";

            var parameters = new Dictionary<string, object>
            {
                { "@Page", page },
                { "@ItemsPerPage", itemsPerPage }
            };

            return GetItems(query, parameters);
        }

        public IEnumerable<ItemModel> GetByValue(string value, int page, int itemsPerPage)
        {
            string PartNo = value;
            int offset = (page - 1) * itemsPerPage;

            string query = "SELECT * FROM SearchItemsByPartNo(@PartNo, @Offset, @ItemsPerPage)";

            var parameters = new Dictionary<string, object>
            {
                { "@PartNo", PartNo },
                { "@Offset", offset },
                { "@ItemsPerPage", itemsPerPage }
            };

            return GetItems(query, parameters);
        }

        public IEnumerable<ItemModel> FilterItems(string brandId, int page, int itemsPerPage)
        {
            int offset = (page - 1) * itemsPerPage;

            string query = "SELECT * FROM FilterItemsByBrandId(@BrandId, @Offset, @ItemsPerPage)";

            var parameters = new Dictionary<string, object>
            {
                { "@BrandId", brandId },
                { "@Offset", offset },
                { "@ItemsPerPage", itemsPerPage }
            };

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
            string query = "SELECT * FROM GetItemByPartNo(@PartNo)";

            var parameters = new Dictionary<string, object>
            {
                { "@PartNo", partNo }
            };

            var items = GetItems(query, parameters);

            return items.FirstOrDefault();
        }

        public string DeleteItem(string partNo)
        {
            string query = "DeleteItem";
            string message = "";

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PartNo", partNo);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if(rowsAffected == 0)
                    {
                        message = "Item found in Invoices, cannot delete.";
                    }
                    else if(rowsAffected == 1)
                    {
                        message = "Item deleted successfully!";
                    }
                }
            }
            return message;
        }
      
        public void AddItem(ItemModel item)
        {
            string query = "AddItem";

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
                command.CommandType = CommandType.StoredProcedure;

                foreach (var param in parameters)
                {
                    command.Parameters.Add(new SqlParameter(param.Key, param.Value));
                }

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public int CalculateTotalAvailableItems()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var query = "SELECT dbo.CalculateTotalAvailableItems()";

                using (var command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;
                    int result = (int)command.ExecuteScalar();
                    return result;
                }
            }
        }

        public int CalculateTotalCategories()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var query = "SELECT dbo.CalculateTotalCategories()";

                using (var command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;
                    int result = (int)command.ExecuteScalar();
                    return result;
                }
            }
        }

    }
}
