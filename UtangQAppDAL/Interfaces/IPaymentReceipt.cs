using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBO;

namespace UtangQAppDAL.Interfaces
{
    public interface IPaymentReceipt : ICrud<PaymentReceipt>
    {
        void CreatePaymentReceiptAndUpdateStatus(int BillRecipientID, string PaymentReceiptURL);
        IEnumerable<PaymentReceipt> ReadPaymentReceiptsByBillCreator(int CreatorUserID);
        void UpdateBillRecipientPaymentStatus (int BillRecipientID, int NewStatusID);
        PaymentReceipt ReadPaymentReceiptbyBillRecipientID (int BillRecipientID);
    }
}
