using UtangQApp_API_BLL.DTOs.Users;

namespace UtangQApp_API_BLL.Interfaces.User
{
    public interface IWalletBLL : ICrudBLL<WalletDTO>
    {
        Task<bool> Create(WalletCreateDTO entity);
        Task<WalletDTO> ReadWalletbyUserID(int UserID);
        Task<bool> UpdateWalletBalance(int UserID, decimal Amount, char OperationFlag);
    }
}
