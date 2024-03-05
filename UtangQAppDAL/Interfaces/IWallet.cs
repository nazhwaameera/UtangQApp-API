using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBO;

namespace UtangQAppDAL.Interfaces
{
    public interface IWallet : ICrud<Wallet>
    {
        Wallet ReadWalletbyUserID (int UserID); 
        void UpdateWalletBalance(int UserID, decimal Amount, char OperationFlag);
    }
}
