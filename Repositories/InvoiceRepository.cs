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
    public class InvoiceRepository
    {
        private readonly string connectionString;

        public InvoiceRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<InvoiceModel> GetAll()
        {
            var invoiceList = new List<InvoiceModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Invoice ORDER BY InvoiceNo DESC";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var invoiceModel = new InvoiceModel
                        {
                            InvoiceNo = (int)reader["InvoiceNo"],
                            CustomerId = (string)reader["CustomerId"],
                            Date = (DateTime)reader["Date"],
                            DueDate = (DateTime)reader["DueDate"],
                            PaymentType = (string)reader["PaymentType"],
                            Discount = (int)reader["Discount"],
                            TotalAmount = (decimal)reader["TotalAmount"],
                            PaymentStatus = (string)reader["PaymentStatus"]
                        };
                        invoiceList.Add(invoiceModel);
                    }
                }
            }
            return invoiceList;
        }

        public IEnumerable<InvoiceModel> GetByValue(string value)
        {
            var invoiceList = new List<InvoiceModel>();
            int InvoiceNo = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string CustomerId = value;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Invoice " +
                                        "WHERE InvoiceNo = @InvoiceNo OR CustomerId LIKE @CustomerId+'%' " +
                                        "ORDER BY InvoiceNo DESC";

                command.Parameters.Add("@InvoiceNo", SqlDbType.Int).Value = InvoiceNo;
                command.Parameters.Add("@CustomerId", SqlDbType.VarChar).Value = CustomerId;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var invoiceModel = new InvoiceModel
                        {
                            InvoiceNo = (int)reader["InvoiceNo"],
                            CustomerId = (string)reader["CustomerId"],
                            Date = (DateTime)reader["Date"],
                            DueDate = (DateTime)reader["DueDate"],
                            PaymentType = (string)reader["PaymentType"],
                            Discount = (int)reader["Discount"],
                            TotalAmount = (decimal)reader["TotalAmount"],
                            PaymentStatus = (string)reader["PaymentStatus"]
                        };
                        invoiceList.Add(invoiceModel);
                    }
                }
            }
            return invoiceList;
        }
    }
}
