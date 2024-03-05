using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBO;

namespace UtangQAppDAL.Interfaces
{
    public interface IBillRecipient : ICrud<BillRecipient>
    {
        IEnumerable<BillRecipient> GetBillRecipientsByBillID(int BillID);
    }
}
