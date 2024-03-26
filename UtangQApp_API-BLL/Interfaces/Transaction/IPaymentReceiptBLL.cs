using UtangQApp_API_BLL.DTOs.Transactions;

namespace UtangQApp_API_BLL.Interfaces.Transaction
{
    public interface IPaymentReceiptBLL : ICrudBLL<PaymentReceiptDTO>
    {
        Task<bool> Create(PaymentReceiptCreateDTO entity);
        Task<bool> CreatePaymentReceiptAndUpdateStatus(int BillRecipientID, string PaymentReceiptURL);
        Task<IEnumerable<PaymentReceiptDTO>> ReadPaymentReceiptsByBillCreator(int CreatorUserID);
        Task<bool> UpdateBillRecipientPaymentStatus(int BillRecipientID, int NewStatusID);
        Task<PaymentReceiptDTO> ReadPaymentReceiptbyBillRecipientID(int BillRecipientID);
    }
}
