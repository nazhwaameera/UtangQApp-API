using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using UtangQAppBO;
using UtangQAppDAL.Interfaces;

namespace UtangQAppDAL
{
    public class WalletDAL : IWallet
    {
        private string GetConnectionString()
        {
            return Helper.GetConnectionString();
            //return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }

        public void Create(Wallet entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Users.CreateWallet";
                var param = new
                {
                    UserID = entity.UserID,
                    WalletBalance = entity.WalletBalance
                };

                try
                {
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 1)
                    {
                        throw new ArgumentException("Create wallet data failed..");
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
                var strSql = "Users.DeleteWallet";
                var param = new
                {
                    WalletID = id
                };

                try
                {
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 1)
                    {
                        throw new ArgumentException("Delete wallet data failed..");
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

        public Wallet Get(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Users.ReadWalletbyID";
                var param = new { WalletID = id };
                var result = conn.QuerySingleOrDefault<Wallet>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public IEnumerable<Wallet> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Users.ReadAllWallets";
                var result = conn.Query<Wallet>(strSql, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public Wallet ReadWalletbyUserID(int UserID)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Users.ReadWalletbyUserID";
                var param = new { UserID = UserID };
                var result = conn.QuerySingleOrDefault<Wallet>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);

                // Check if the result is null
                if (result == null)
                {
                    return null; // Return null if wallet does not exist
                }

                return result; // Return the wallet if it exists
            }
        }


        public void Update(Wallet entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Users.UpdateWallet";
                var param = new
                {
                    WalletID = entity.WalletID,
                    UserID = entity.UserID,
                    WalletBalance = entity.WalletBalance
                };

                try
                {
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 1)
                    {
                        throw new ArgumentException("Update wallet data failed..");
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

        public void UpdateWalletBalance(int UserID, decimal Amount, char OperationFlag)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    var strSql = "Transactions.UpdateWalletBalance";
                    var param = new
                    {
                        UserID = UserID,
                        Amount = Amount,
                        OperationFlag = OperationFlag
                    };

                    conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
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
