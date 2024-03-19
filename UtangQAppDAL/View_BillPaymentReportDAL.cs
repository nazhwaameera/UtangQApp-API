using System;
using System.Collections.Generic;
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
    public class View_BillPaymentReportDAL : IBillPaymentReport
    {
        private string GetConnectionString()
        {
            return Helper.GetConnectionString();
            //return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }
        public IEnumerable<View_BillPaymentReport> CreateView(int UserId)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "CreateBillPaymentReport";
                var param = new { UserID = UserId };
                var result = conn.Query<View_BillPaymentReport>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
