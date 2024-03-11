using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBLL.DTOs.Transaction;
using UtangQAppBO;

namespace UtangQAppBLL.Interfaces.Transaction
{
    public interface IBillRecipientBLL : ICrudBLL<BillRecipientDTO>
    {
        void Create(BillRecipientCreateDTO entity);
        IEnumerable<BillRecipientDTO> GetBillRecipientsByBillID(int BillID);
        void UpdateBillRecipientPaymentStatus(int BillRecipientID, int NewStatusID);
        IEnumerable<BillRecipientDTO> ReadBillRecipientByRecipientUserID(int RecipientUserID);
    }
}
