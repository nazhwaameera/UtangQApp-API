using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBO;
using UtangQAppDAL.Interfaces;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using static Dapper.SqlMapper;
using System.Configuration;

namespace UtangQAppDAL
{
    public class PaymentReceiptDAL : IPaymentReceipt
    {
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }

        public void Create(PaymentReceipt entity)
        {
            throw new NotImplementedException();
        }

        public void CreatePaymentReceiptAndUpdateStatus(int BillRecipientID, string PaymentReceiptURL)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Transactions.CreatePaymentReceiptAndUpdateStatus";
                var param = new
                {
                    BillRecipientID = BillRecipientID,
                    PaymentReceiptURL = PaymentReceiptURL
                };

                try
                {
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 5)
                    {
                        throw new ArgumentException("Create payment receipt data failed..");
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException($"{sqlEx.InnerException.Message} - {sqlEx.Number}");
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Transactions.DeletePaymentReceipt";
                var param = new
                {
                    PaymentReceiptID = id
                };

                try
                {
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 1)
                    {
                        throw new ArgumentException("Delete payment receipt data failed..");
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException($"{sqlEx.InnerException.Message} - {sqlEx.Number}");
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
        }

        public PaymentReceipt Get(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Transactions.ReadPaymentReceiptbyID";
                var param = new { PaymentReceiptID = id };
                var result = conn.QuerySingleOrDefault<PaymentReceipt>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public IEnumerable<PaymentReceipt> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Transactions.ReadAllPaymentReceipts";
                var result = conn.Query<PaymentReceipt>(strSql, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public IEnumerable<PaymentReceipt> ReadPaymentReceiptsByBillCreator(int CreatorUserID)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Transactions.ReadPaymentReceiptsByBillCreator";
                var param = new { CreatorUserID = CreatorUserID };
                var result = conn.Query<PaymentReceipt>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public void Update(PaymentReceipt entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Transactions.UpdatePaymentReceipt";
                var param = new
                {
                    PaymentReceiptID = entity.PaymentReceiptID,
                    BillRecipientID = entity.BillRecipientID,
                    SentDate = entity.SentDate,
                    ConfirmationDate = entity.ConfirmationDate,
                    PaymentReceiptURL = entity.PaymentReceiptURL,
                };

                try
                {
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 1)
                    {
                        throw new ArgumentException("Update payment receipt data failed..");
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException($"{sqlEx.InnerException.Message} - {sqlEx.Number}");
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
        }

        public void UpdateBillRecipientPaymentStatus(int BillRecipientID, int NewStatusID)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Transactions.UpdateBillRecipientPaymentStatus";
                var param = new
                {
                    BillRecipientID = BillRecipientID,
                    NewStatusID = NewStatusID
                };

                try
                {
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 1)
                    {
                        throw new ArgumentException("Update bill recipient payment status data failed..");
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException($"{sqlEx.InnerException.Message} - {sqlEx.Number}");
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
        }

        public PaymentReceipt ReadPaymentReceiptbyBillRecipientID(int BillRecipientID)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Transactions.ReadPaymentReceiptbyBillRecipientID";
                var param = new { BillRecipientID = BillRecipientID };
                var result = conn.QuerySingleOrDefault<PaymentReceipt>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
