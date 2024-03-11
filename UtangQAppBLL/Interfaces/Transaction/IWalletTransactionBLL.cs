using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBLL.DTOs.Transaction;
using UtangQAppBO;

namespace UtangQAppBLL.Interfaces.Transaction
{
    public interface IWalletTransactionBLL : ICrudBLL<WalletTransactionDTO>
    {
        void Create(WalletTransactionCreateDTO entity);
        IEnumerable<WalletTransactionDTO> ReadWalletTransactionbyUserID(int UserID);
    }
}
