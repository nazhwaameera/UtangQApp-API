using UtangQApp_API_BLL.DTOs.Transactions;


namespace UtangQApp_API_BLL.Interfaces.Transaction
{
    public interface IBillRecipientBLL : ICrudBLL<BillRecipientDTO>
    {
        Task<bool> Create(BillRecipientCreateDTO entity);
        Task<IEnumerable<BillRecipientDTO>> GetBillRecipientsByBillID(int BillID);
        Task<bool> UpdateBillRecipientPaymentStatus(int BillRecipientID, int NewStatusID);
        Task<IEnumerable<BillRecipientDTO>> ReadBillRecipientByRecipientUserID(int RecipientUserID);
        Task<IEnumerable<BillRecipientWithDescDTO>> ReadBillRecipientByRecipientUserIDWithDescription(int RecipientUserID);
        Task<bool> HandleIncomingBillRecipient(int BillRecipientID, int NewStatusID);
        Task<decimal> TotalBillRecipientAmountByBillID(int BillID);
    }
}
