using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using UtangQAppBO;
using UtangQAppDAL.Interfaces;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using static Dapper.SqlMapper;

namespace UtangQAppDAL
{
    public class BillDAL : IBill
    {
        private string GetConnectionString()
        {
            return Helper.GetConnectionString();
            //return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }

        public void Create(Bill entity)
        {
           using(SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Users.CreateBill";
                var param = new
                {
                    UserID = entity.UserID,
                    BillAmount = entity.BillAmount,
                    BillDate = entity.BillDate,
                    BillDescription = entity.BillDescription,
                    OwnerContribution = entity.OwnerContribution
                };

                try
                {
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 1)
                    {
                        throw new ArgumentException("Insert data failed..");
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
                var strSql = "Users.DeleteBill";
                var param = new
                {
                    BillID = id
                };

                try
                {
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 1)
                    {
                        throw new ArgumentException("Delete data failed..");
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

        public Bill Get(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Users.ReadBillbyID";
                var param = new { BillID = id };
                var result = conn.QuerySingleOrDefault<Bill>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public IEnumerable<Bill> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Users.ReadAllBills";
                var result = conn.Query<Bill>(strSql, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public void Update(Bill entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Users.UpdateBill";
                var param = new
                {
                    BillID = entity.BillID,
                    UserID = entity.UserID,
                    BillAmount = entity.BillAmount,
                    BillDate = entity.BillDate,
                    BillDescription = entity.BillDescription,
                    OwnerContribution = entity.OwnerContribution
                };

                try
                {
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 1)
                    {
                        throw new ArgumentException("Update data failed..");
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

        public IEnumerable<Bill> ReadUserBills(int UserId)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Users.ReadUserBills";
                var param = new { UserID = UserId };
                var result = conn.Query<Bill>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public decimal GetTotalBillAmountCreatedProcedure(int UserId)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Transactions.GetTotalBillAmountCreatedProcedure";
                var param = new { UserID = UserId };
                var result = conn.ExecuteScalar<decimal>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public decimal GetTotalBillAmountCreatedPendingProcedure(int UserId)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Transactions.GetTotalBillAmountCreatedPendingProcedure";
                var param = new { UserID = UserId };
                var result = conn.ExecuteScalar<decimal>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public decimal GetTotalBillAmountCreatedPaidProcedure(int UserId)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Transactions.GetTotalBillAmountCreatedPaidProcedure";
                var param = new { UserID = UserId };
                var result = conn.ExecuteScalar<decimal>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public decimal CalculateTotalUnassignedBillAmount(int UserId)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Transactions.CalculateTotalUnassignedBillAmount";
                var param = new { UserID = UserId };
                var result = conn.ExecuteScalar<decimal>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public decimal GetTotalPendingAmountOwedProcedure(int RecipientUserID)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Transactions.GetTotalPendingAmountOwedProcedure";
                var param = new { RecipientUserID = RecipientUserID };
                var result = conn.ExecuteScalar<decimal>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public decimal GetTotalBillAmountPaidProcedure(int RecipientUserID)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Transactions.GetTotalBillAmountPaidProcedure";
                var param = new { RecipientUserID = RecipientUserID };
                var result = conn.ExecuteScalar<decimal>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

		public decimal GetTotalBillAmountCreatedAcceptedProcedure(int UserId)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "Transactions.GetTotalBillAmountCreatedAcceptedProcedure";
				var param = new { UserID = UserId };
				var result = conn.ExecuteScalar<decimal>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
				return result;
			}
		}

		public decimal GetTotalBillAmountCreatedRejectedProcedure(int UserId)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "Transactions.GetTotalBillAmountCreatedRejectedProcedure";
				var param = new { UserID = UserId };
				var result = conn.ExecuteScalar<decimal>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
				return result;
			}
		}

		public decimal GetTotalBillAmountCreatedAwaitingProcedure(int UserId)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "Transactions.GetTotalBillAmountCreatedAwaitingProcedure";
				var param = new { UserID = UserId };
				var result = conn.ExecuteScalar<decimal>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
				return result;
			}
		}

		public decimal GetTotalBillAmountAcceptedProcedure(int RecipientUserID)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "Transactions.GetTotalBillAmountAcceptedProcedure";
				var param = new { RecipientUserID = RecipientUserID };
				var result = conn.ExecuteScalar<decimal>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
				return result;
			}
		}

		public decimal GetTotalBillAmountAwaitingProcedure(int RecipientUserID)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "Transactions.GetTotalBillAmountAwaitingProcedure";
				var param = new { RecipientUserID = RecipientUserID };
				var result = conn.ExecuteScalar<decimal>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
				return result;
			}
		}
	}
}
