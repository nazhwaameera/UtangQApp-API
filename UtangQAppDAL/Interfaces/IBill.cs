using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBO;

namespace UtangQAppDAL.Interfaces
{
    public interface IBill : ICrud<Bill>
    {
        IEnumerable<Bill> ReadUserBills(int UserId);
        decimal GetTotalBillAmountCreatedProcedure(int UserId);
        decimal GetTotalBillAmountCreatedPendingProcedure(int UserId);
        decimal GetTotalBillAmountCreatedPaidProcedure(int UserId);
    }
}
