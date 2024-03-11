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
    public class BillStatusDAL : IBillStatus
    {
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }
        public void Create(BillStatus entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Transactions.CreateBillStatus";
                var param = new
                {
                    BillStatusDescription = entity.BillStatusDescription,
                };

                try
                {
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 1)
                    {
                        throw new ArgumentException("Insert bill status data failed..");
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
                var strSql = "Transactions.DeleteBillStatus";
                var param = new
                {
                    BillStatusID = id
                };

                try
                {
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 1)
                    {
                        throw new ArgumentException("Delete bill status data failed..");
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

        public BillStatus Get(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Transactions.ReadBillStatusbyID";
                var param = new { BillStatusID = id };
                var result = conn.QuerySingleOrDefault<BillStatus>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public IEnumerable<BillStatus> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Transactions.ReadAllBillStatus";
                var result = conn.Query<BillStatus>(strSql, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public void Update(BillStatus entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Transactions.UpdateBillStatus";
                var param = new
                {
                    BillStatusID = entity.BillStatusID,
                    BillStatusDescription = entity.BillStatusDescription
                };

                try
                {
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 1)
                    {
                        throw new ArgumentException("Update bill status data failed..");
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
