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
    public class View_TransactionHistoryReportDAL : ITransactionHistoryReport
    {
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }
        public IEnumerable<View_TransactionHistoryReport> CreateView(int UserId)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "CreateTransactionHistoryReport";
                var param = new { UserID = UserId };
                var result = conn.Query<View_TransactionHistoryReport>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
