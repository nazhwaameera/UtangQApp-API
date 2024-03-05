using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using UtangQAppBO;
using UtangQAppDAL.Interfaces;
using Dapper;

namespace UtangQAppDAL
{
    public class BillRecipientDAL : IBillRecipient
    {
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }

        public void Create(BillRecipient entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public BillRecipient Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BillRecipient> GetAll()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
