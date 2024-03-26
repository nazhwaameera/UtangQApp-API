using UtangQApp_Domain.Users;


namespace UtangQApp_Data.Interfaces.Users
{
    public interface IWallet : ICrud<Wallet>
    {
        Task<Wallet> ReadWalletbyUserID(int UserID);
        Task<bool> UpdateWalletBalance(int UserID, decimal Amount, char OperationFlag);
    }
}
