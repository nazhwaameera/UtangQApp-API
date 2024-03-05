using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBLL.DTOs.User;

namespace UtangQAppBLL.Interfaces.User
{
    internal interface IWalletBLL : ICrudBLL<WalletDTO>
    {
        void Create(WalletCreateDTO entity);
        WalletDTO ReadWalletbyUserID(int UserID);
        void UpdateWalletBalance(int UserID, decimal Amount, char OperationFlag);
    }
}
