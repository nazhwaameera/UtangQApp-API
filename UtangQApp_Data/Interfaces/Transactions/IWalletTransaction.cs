using UtangQApp_Domain.Transactions;

namespace UtangQApp_Data.Interfaces.Transactions
{
    public interface IWalletTransaction : ICrud<WalletTransaction>
    {
        Task<IEnumerable<WalletTransaction>> ReadWalletTransactionbyUserID(int UserID);
    }
}
