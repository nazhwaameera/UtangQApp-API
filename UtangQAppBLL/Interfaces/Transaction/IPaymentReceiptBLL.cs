using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBLL.DTOs.Transaction;
using UtangQAppBO;

namespace UtangQAppBLL.Interfaces.Transaction
{
    public interface IPaymentReceiptBLL : ICrudBLL<PaymentReceiptDTO>
    {
        void Create(PaymentReceiptCreateDTO entity);
        void CreatePaymentReceiptAndUpdateStatus(int BillRecipientID, string PaymentReceiptURL);
        IEnumerable<PaymentReceiptDTO> ReadPaymentReceiptsByBillCreator(int CreatorUserID);
        void UpdateBillRecipientPaymentStatus(int BillRecipientID, int NewStatusID);
        PaymentReceiptDTO ReadPaymentReceiptbyBillRecipientID(int BillRecipientID);
    }
}
