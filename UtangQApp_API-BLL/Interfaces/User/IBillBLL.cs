using UtangQApp_API_BLL.DTOs.Users;


namespace UtangQApp_API_BLL.Interfaces.User
{
    public interface IBillBLL : ICrudBLL<BillDTO>
    {
        Task<bool> Create(BillCreateDTO entity);
        Task<IEnumerable<BillDTO>> ReadUserBills(int UserId);
        Task<decimal> GetTotalBillAmountCreatedProcedure(int UserId);
        Task<decimal> CalculateTotalUnassignedBillAmount(int UserId);
        Task<decimal> GetTotalBillAmountCreatedPendingProcedure(int UserId);
        Task<decimal> GetTotalBillAmountCreatedPaidProcedure(int UserId);
        Task<decimal> GetTotalBillAmountCreatedAcceptedProcedure(int UserId);
        Task<decimal> GetTotalBillAmountCreatedRejectedProcedure(int UserId);
        Task<decimal> GetTotalBillAmountCreatedAwaitingProcedure(int UserId);
        Task<decimal> GetTotalPendingAmountOwedProcedure(int RecipientUserID);
        Task<decimal> GetTotalBillAmountPaidProcedure(int RecipientUserID);
        Task<decimal> GetTotalBillAmountAcceptedProcedure(int RecipientUserID);
        Task<decimal> GetTotalBillAmountAwaitingProcedure(int RecipientUserID);
	}
}
