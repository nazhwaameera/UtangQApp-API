using UtangQApp_Domain.Transactions;

namespace UtangQApp_Data.Interfaces.Transactions
{
    public interface IBillRecipient
    {
        Task<IEnumerable<BillRecipient>> GetAll();
        Task<BillRecipient> Get(int id);
        Task<bool> Create(BillRecipientCreate entity);
        Task<bool> Update(BillRecipient entity);
        Task<bool> Delete(int id);
        Task<bool> UpdateBillRecipientPaymentStatus(int BillRecipientID, int NewStatusID);
        Task<IEnumerable<BillRecipient>> ReadBillRecipientByRecipientUserID(int RecipientUserID);
        Task<IEnumerable<BillRecipientWithDesc>> ReadBillRecipientByRecipientUserIDWithDescription(int RecipientUserID);
        Task<IEnumerable<BillRecipient>> GetBillRecipientsByBillID(int BillID);
        Task<bool> HandleIncomingBillRecipient(int BillRecipientID, int NewStatusID);
        Task<decimal> TotalBillRecipientAmountByBillID(int BillID);


    }
}
