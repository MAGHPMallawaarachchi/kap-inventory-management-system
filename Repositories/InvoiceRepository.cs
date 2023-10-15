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

        private IEnumerable<InvoiceModel> GetInvoices(string query, Dictionary<string, object> parameters)
        {
            var invoiceList = new List<InvoiceModel>();

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

        public IEnumerable<InvoiceModel> GetAll(int page, int itemsPerPage)
        {
            int offset = (page - 1) * itemsPerPage;
            string query = "SELECT * FROM Invoice ORDER BY InvoiceNo DESC " +
                           "OFFSET @Offset ROWS FETCH NEXT @ItemsPerPage ROWS ONLY";

            var parameters = new Dictionary<string, object>
            {
                { "@Offset", offset },
                { "@ItemsPerPage", itemsPerPage }
            };

            return GetInvoices(query, parameters);
        }

        public IEnumerable<InvoiceModel> GetByValue(string value, int page, int itemsPerPage)
        {
            int InvoiceNo = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string CustomerId = value;
            int offset = (page - 1) * itemsPerPage;

            string query = "SELECT * FROM Invoice " +
                           "WHERE (InvoiceNo = @InvoiceNo OR CustomerId LIKE @CustomerId+'%') " +
                           "ORDER BY InvoiceNo DESC " +
                           $"OFFSET {offset} ROWS FETCH NEXT {itemsPerPage} ROWS ONLY";

            var parameters = new Dictionary<string, object>
            {
                { "@InvoiceNo", InvoiceNo },
                { "@CustomerId", CustomerId }
            };

            return GetInvoices(query, parameters);
        }

        public IEnumerable<InvoiceModel> FilterInvoices(DateTime fromDate, DateTime toDate, string customer, int page, int itemsPerPage)
        {
            int offset = (page - 1) * itemsPerPage;

            string query = "SELECT * FROM Invoice WHERE 1 = 1";

            var parameters = new Dictionary<string, object>();

            if (fromDate != DateTime.MinValue && toDate != DateTime.MinValue)
            {
                query += " AND Date >= @FromDate AND Date <= @ToDate";
                parameters.Add("@FromDate", fromDate);
                parameters.Add("@ToDate", toDate);
            }

            if (!string.IsNullOrEmpty(customer))
            {
                query += " AND CustomerId LIKE @CustomerId + '%'";
                parameters.Add("@CustomerId", customer);
            }

            query += " ORDER BY InvoiceNo DESC " +
                     $"OFFSET {offset} ROWS FETCH NEXT {itemsPerPage} ROWS ONLY";

            return GetInvoices(query, parameters);
        }

        public void AddInvoice(InvoiceModel invoice, List<InvoiceItemModel> invoiceItems)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var invoiceId = InsertInvoice(invoice, connection, transaction);

                        foreach (var item in invoiceItems)
                        {
                            InsertInvoiceItem(item, invoiceId, connection, transaction);
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private int InsertInvoice(InvoiceModel invoice, SqlConnection connection, SqlTransaction transaction)
        {
            var invoiceQuery = "INSERT INTO Invoice (CustomerId, Date, DueDate, PaymentType, Discount, TotalAmount, PaymentStatus) " +
                              "VALUES (@CustomerId, @Date, @DueDate, @PaymentType, @Discount, @TotalAmount, @PaymentStatus); " +
                              "SELECT SCOPE_IDENTITY()";

            var invoiceParameters = new Dictionary<string, object>
            {
                { "@CustomerId", invoice.CustomerId },
                { "@Date", invoice.Date },
                { "@DueDate", invoice.DueDate },
                { "@PaymentType", invoice.PaymentType },
                { "@Discount", invoice.Discount },
                { "@TotalAmount", invoice.TotalAmount },
                { "@PaymentStatus", invoice.PaymentStatus }
            };

            using (var command = new SqlCommand(invoiceQuery, connection, transaction))
            {
                foreach (var param in invoiceParameters)
                {
                    command.Parameters.Add(new SqlParameter(param.Key, param.Value));
                }

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        private void InsertInvoiceItem(InvoiceItemModel item, int invoiceId, SqlConnection connection, SqlTransaction transaction)
        {
            var invoiceItemQuery = "INSERT INTO InvoiceItem (InvoiceNo, PartNo, Qty, BuyingPrice, UnitPrice, Amount) " +
                                "VALUES (@InvoiceNo, @PartNo, @Qty, @BuyingPrice, @UnitPrice, @Amount)";

            var invoiceItemParameters = new Dictionary<string, object>
            {
                { "@InvoiceNo", invoiceId },
                { "@PartNo", item.PartNo },
                { "@Qty", item.Qty },
                { "@BuyingPrice", item.BuyingPrice },
                { "@UnitPrice", item.UnitPrice },
                { "@Amount", item.Amount }
            };

            using (var command = new SqlCommand(invoiceItemQuery, connection, transaction))
            {
                foreach (var param in invoiceItemParameters)
                {
                    command.Parameters.Add(new SqlParameter(param.Key, param.Value));
                }

                command.ExecuteNonQuery();
            }
        }

        public int GetLastInvoiceNumber()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var query = "SELECT TOP 1 InvoiceNo FROM Invoice ORDER BY InvoiceNo DESC";

                using (var command = new SqlCommand(query, connection))
                {
                    var result = command.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        return (int)result + 1;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
        }

    }
}
