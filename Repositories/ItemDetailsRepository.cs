using inventory_management_system_kap.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static inventory_management_system_kap.Models.ItemDetailsModel;

namespace inventory_management_system_kap.Repositories
{
    public class ItemDetailsRepository
    {
        private readonly string connectionString;

        public ItemDetailsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        //Get itemDetails by partNo
        public IEnumerable<ItemDetailsModel> GetItemDetailsByPartNo(string partNo)
        {
            string query = "SELECT * FROM Item WHERE PartNo = @PartNo";
            var itemDetailsList = new List<ItemDetailsModel>();
            var parameters = new Dictionary<string, object>
            {
                { "@PartNo", partNo }
            };

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
                    if (reader.Read())
                    {
                        var itemDetailsModel = new ItemDetailsModel
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
                        itemDetailsList.Add(itemDetailsModel);
                    }
                }
                connection.Close();
            }
            return itemDetailsList;
        }

        //Get itemdetails by brandId
        public IEnumerable<ItemDetailsModel> GetItemDetailsbyBrandId(string brandId) {

            string query = "SELECT country,name,email FROM supplier WHERE supplierId = (SELECT supplierId FROM brand WHERE brandId = @BrandId)";
            var itemDetailList = new List<ItemDetailsModel>();
            var parameters =new Dictionary<string, object> {
                {"@BrandId",brandId }
            };

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection)) {

                foreach (var param in parameters) {
                    command.Parameters.Add(new SqlParameter(param.Key, param.Value));
                }

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read()) {
                        var itemDetailsModel = new ItemDetailsModel {
                            Country = (string)reader["Country"],
                            Name = (string)reader["Name"],
                            Email = (string)reader["Email"],
                        };
                        itemDetailList.Add(itemDetailsModel);
                    }
                }
                connection.Close();
            }
            return itemDetailList;

        }
    }
}
