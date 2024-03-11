using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBO;

namespace UtangQAppDAL.Interfaces
{
    public interface IBillRecipient
    {
        IEnumerable<BillRecipient> GetAll();
        BillRecipient Get(int id);
        void Create(BillRecipientCreate entity);
        void Update(BillRecipient entity);
        void Delete(int id);
        void UpdateBillRecipientPaymentStatus(int BillRecipientID, int NewStatusID);
        IEnumerable<BillRecipient> ReadBillRecipientByRecipientUserID(int RecipientUserID);
        IEnumerable<BillRecipient> GetBillRecipientsByBillID(int BillID);
    }
}
