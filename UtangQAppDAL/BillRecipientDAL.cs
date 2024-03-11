using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using UtangQAppBO;
using UtangQAppDAL.Interfaces;
using Dapper;
using static Dapper.SqlMapper;

namespace UtangQAppDAL
{
    public class BillRecipientDAL : IBillRecipient
    {
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }

        public void Create(BillRecipientCreate entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Transactions.CreateBillRecipient";
                var param = new
                {
                    BillID = entity.BillID,
                    RecipientUserID = entity.RecipientUserID,
                    TotalUsers = entity.TotalUsers,
                    IsSplitEvenly = entity.IsSplitEvenly,
                    TaxStatusDescription = entity.TaxStatusDescription,
                    TaxCharged = entity.TaxCharged
                };

                try
                {
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 1)
                    {
                        throw new ArgumentException("Insert bill recipient data failed..");
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
                var strSql = "Transactions.DeleteBillRecipient";
                var param = new
                {
                    BillRecipientID = id
                };

                try
                {
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 1)
                    {
                        throw new ArgumentException("Delete  bill recipient data failed..");
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

        public BillRecipient Get(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Transactions.ReadBillRecipientbyID";
                var param = new { BillID = id };
                var result = conn.QuerySingleOrDefault<BillRecipient>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public IEnumerable<BillRecipient> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Transactions.ReadAllBillRecipients";
                var result = conn.Query<BillRecipient>(strSql, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public IEnumerable<BillRecipient> GetBillRecipientsByBillID(int BillID)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    var strSql = "Transactions.GetBillRecipientsByBillID";
                    var param = new { BillID = BillID };
                    var results = conn.Query<BillRecipient>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    return results;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Update(BillRecipient entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Transactions.UpdateBillRecipient";
                var param = new
                {
                    BillRecipientID = entity.BillRecipientID,
                    BillID = entity.BillID,
                    RecipientUserID = entity.RecipientUserID,
                    SentDate = entity.SentDate,
                    BillRecipientStatusID = entity.BillRecipientStatusID,
                    BillRecipientTaxStatusID = entity.BillRecipientTaxStatusID
                };

                try
                {
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 1)
                    {
                        throw new ArgumentException("Update bill recipient data failed..");
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
                    NewStatusID = NewStatusID,
                };

                try
                {
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 2)
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

        public IEnumerable<BillRecipient> ReadBillRecipientByRecipientUserID(int RecipientUserID)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    var strSql = "Transactions.ReadBillRecipientByRecipientUserID";
                    var param = new { RecipientUserID = RecipientUserID };
                    var results = conn.Query<BillRecipient>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    return results;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
