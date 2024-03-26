using UtangQApp_Domain.Transactions;

namespace UtangQApp_Data.Interfaces.Transactions
{
    public interface IPaymentReceipt : ICrud<PaymentReceipt>
    {
        Task<bool> CreatePaymentReceiptAndUpdateStatus(int BillRecipientID, string PaymentReceiptURL);
        Task<IEnumerable<PaymentReceipt>> ReadPaymentReceiptsByBillCreator(int CreatorUserID);
        Task<bool> UpdateBillRecipientPaymentStatus(int BillRecipientID, int NewStatusID);
        Task<PaymentReceipt> ReadPaymentReceiptbyBillRecipientID(int BillRecipientID);
    }
}
