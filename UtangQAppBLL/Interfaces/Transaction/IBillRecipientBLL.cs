using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBLL.DTOs.Transaction;

namespace UtangQAppBLL.Interfaces.Transaction
{
    public interface IBillRecipientBLL : ICrudBLL<BillRecipientDTO>
    {
        void Create(BillRecipientCreateDTO entity);
        IEnumerable<BillRecipientDTO> GetBillRecipientsByBillID(int BillID);
    }
}
