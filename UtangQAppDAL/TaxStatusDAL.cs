using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
    public class TaxStatusDAL : ITaxStatus
    {
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }
        public void Create(TaxStatus entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Transactions.CreateTaxStatus";
                var param = new
                {
                    TaxStatusDescription = entity.TaxStatusDescription,
                };

                try
                {
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 1)
                    {
                        throw new ArgumentException("Insert tax status data failed..");
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
                var strSql = "Transactions.DeleteTaxStatus";
                var param = new
                {
                    TaxStatusID = id
                };

                try
                {
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 1)
                    {
                        throw new ArgumentException("Delete tax status data failed..");
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

        public TaxStatus Get(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Transactions.ReadTaxStatusbyID";
                var param = new { TaxStatusID = id };
                var result = conn.QuerySingleOrDefault<TaxStatus>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public IEnumerable<TaxStatus> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Transactions.ReadAllTaxStatus";
                var result = conn.Query<TaxStatus>(strSql, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public void Update(TaxStatus entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "Transactions.UpdateTaxStatus";
                var param = new
                {
                    TaxStatusID = entity.TaxStatusID,
                    TaxStatusDescription = entity.TaxStatusDescription
                };

                try
                {
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 1)
                    {
                        throw new ArgumentException("Update tax status data failed..");
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
