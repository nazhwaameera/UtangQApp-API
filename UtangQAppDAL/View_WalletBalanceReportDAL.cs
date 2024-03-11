using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppDAL.Interfaces;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using static Dapper.SqlMapper;
using System.Configuration;
using UtangQAppBO;

namespace UtangQAppDAL
{
    public class View_WalletBalanceReportDAL : IWalletBalanceReport
    {
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }
        public IEnumerable<View_WalletBalanceReport> CreateView(int UserId)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "CreateWalletBalanceReport";
                var param = new { UserID = UserId };
                var result = conn.Query<View_WalletBalanceReport>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
