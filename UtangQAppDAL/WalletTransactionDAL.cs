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
    public class WalletTransactionDAL : IWalletTransaction
    {
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }
        public void Create(WalletTransaction entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Transactions.CreateWalletTransaction";
                var param = new
                {
                    WalletID = entity.WalletID,
                    WalletTransactionAmount = entity.WalletTransactionAmount,
                    TransactionDescription = entity.TransactionDescription
                };

                try
                {
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 1)
                    {
                        throw new ArgumentException("Insert wallet transaction data failed..");
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
                var strSql = "Transactions.DeleteWalletTransaction";
                var param = new
                {
                    WalletTransactionID = id
                };

                try
                {
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 1)
                    {
                        throw new ArgumentException("Delete wallet transaction data failed..");
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

        public WalletTransaction Get(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Transactions.ReadWalletTransactionbyID";
                var param = new { WalletTransactionID = id };
                var result = conn.QuerySingleOrDefault<WalletTransaction>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public IEnumerable<WalletTransaction> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Transactions.ReadAllWalletTransactions";
                var result = conn.Query<WalletTransaction>(strSql, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public IEnumerable<WalletTransaction> ReadWalletTransactionbyUserID(int UserID)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Transactions.ReadWalletTransactionbyUserID";
                var param = new { UserID = UserID };
                var result = conn.Query<WalletTransaction>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public void Update(WalletTransaction entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Transactions.UpdateWalletTransaction";
                var param = new
                {
                    WalletTransactionID = entity.WalletTransactionID,
                    WalletID = entity.WalletID,
                    WalletTransactionAmount = entity.WalletTransactionAmount,
                    TransactionDate = entity.TransactionDate,
                    TransactionDescription = entity.TransactionDescription
                };

                try
                {
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 1)
                    {
                        throw new ArgumentException("Update wallet transaction data failed..");
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
    }
}
