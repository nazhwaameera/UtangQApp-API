using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBLL.DTOs.User;

namespace UtangQAppBLL.Interfaces.User
{
    public interface IBillBLL : ICrudBLL<BillDTO>
    {
        void Create(BillCreateDTO entity);
        IEnumerable<BillDTO> ReadUserBills(int UserId);
        decimal GetTotalBillAmountCreatedProcedure(int UserId);
        decimal GetTotalBillAmountCreatedPendingProcedure(int UserId);
        decimal GetTotalBillAmountCreatedPaidProcedure(int UserId);
    }
}
