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

        public IEnumerable<InvoiceModel> GetAll(int page, int invoicesPerPage)
        {
            string query = "SELECT * FROM GetAllInvoices(@Page, @InvoicesPerPage)";

            var parameters = new Dictionary<string, object>
            {
                { "@Page", page},
                { "@InvoicesPerPage", invoicesPerPage }
            };

            return GetInvoices(query, parameters);
        }

        public IEnumerable<InvoiceModel> GetByValue(string value, int page, int itemsPerPage)
        {
            int InvoiceNo = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string CustomerId = value;
            int offset = (page - 1) * itemsPerPage;

            string query = "SELECT * FROM SearchInvoices(@InvoiceNo, @CustomerId, @Offset @ItemsPerPage)";

            var parameters = new Dictionary<string, object>
            {
                { "@InvoiceNo", InvoiceNo },
                { "@CustomerId", CustomerId },
                { "@Offset", offset },
                { "@ItemsPerPage", itemsPerPage }
            };

            return GetInvoices(query, parameters);
        }

        public IEnumerable<InvoiceModel> FilterInvoices(DateTime fromDate, DateTime toDate, string customer, int page, int itemsPerPage)
        {
            string query = "SELECT * FROM FilterInvoices(@FromDate, @ToDate, @CustomerId, @Page, @ItemsPerPage)";

            var parameters = new Dictionary<string, object>
            {
                { "@FromDate", fromDate },
                { "@ToDate", toDate },
                { "@CustomerId", customer },
                { "@Page", page },
                { "@ItemsPerPage", itemsPerPage }
            };     

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
            var invoiceQuery = "InsertInvoice";

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
                command.CommandType = CommandType.StoredProcedure;

                foreach (var param in invoiceParameters)
                {
                    command.Parameters.Add(new SqlParameter(param.Key, param.Value));
                }

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        private void InsertInvoiceItem(InvoiceItemModel item, int invoiceNo, SqlConnection connection, SqlTransaction transaction)
        {
            var invoiceItemQuery = "InsertInvoiceItem";

            var invoiceItemParameters = new Dictionary<string, object>
            {
                { "@InvoiceNo", invoiceNo },
                { "@PartNo", item.PartNo },
                { "@Qty", item.Qty },
                { "@BuyingPrice", item.BuyingPrice },
                { "@UnitPrice", item.UnitPrice },
                { "@Amount", item.Amount }
            };

            using (var command = new SqlCommand(invoiceItemQuery, connection, transaction))
            {
                command.CommandType = CommandType.StoredProcedure;

                foreach (var param in invoiceItemParameters)
                {
                    command.Parameters.Add(new SqlParameter(param.Key, param.Value));
                }

                command.ExecuteNonQuery();
            }
        }

        public int GetInvoiceNumber()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var query = "SELECT dbo.GetLastInvoiceNo()";

                using (var command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;
                    int lastInvoiceNo = (int)command.ExecuteScalar();

                    if (lastInvoiceNo > 0)
                    {
                        return (int)lastInvoiceNo + 1;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
        }

        public IEnumerable<InvoiceModel> GetInvoicesForDateRange(DateTime startDate, DateTime endDate)
        {
            string query = "SELECT * FROM GetInvoicesByDateRange(@StartDate, @EndDate)";

            var parameters = new Dictionary<string, object>
            {
                { "@StartDate", startDate },
                { "@EndDate", endDate }
            };

            return GetInvoices(query, parameters);
        }

    }
}
