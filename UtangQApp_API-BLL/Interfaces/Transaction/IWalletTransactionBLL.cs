using UtangQApp_API_BLL.DTOs.Transactions;

namespace UtangQApp_API_BLL.Interfaces.Transaction
{
    public interface IWalletTransactionBLL : ICrudBLL<WalletTransactionDTO>
    {
        Task<bool> Create(WalletTransactionCreateDTO entity);
        Task<IEnumerable<WalletTransactionDTO>> ReadWalletTransactionbyUserID(int UserID);
    }
}
