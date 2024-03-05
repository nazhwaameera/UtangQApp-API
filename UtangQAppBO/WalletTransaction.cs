using System;
using System.Collections.Generic;
using System.Text;

namespace UtangQAppBO
{
    public class WalletTransaction
    {
        public int WalletTransactionID { get; set; }
        public int WalletID { get; set; }
        public decimal WalletTransactionAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionDescription { get; set; }

        public Wallet Wallet { get; set; }
    }
}
