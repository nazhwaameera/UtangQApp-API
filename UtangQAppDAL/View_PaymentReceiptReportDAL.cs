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
    public class View_PaymentReceiptReportDAL : IPaymentReceiptReport
    {
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }
        public IEnumerable<View_PaymentReceiptReport> CreateView(int UserId)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "CreatePaymentReceiptReport";
                var param = new { UserID = UserId };
                var result = conn.Query<View_PaymentReceiptReport>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
