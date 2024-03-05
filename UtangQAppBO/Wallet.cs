using System;
using System.Collections.Generic;
using System.Text;

namespace UtangQAppBO
{
    public class Wallet
    {
        public Wallet()
        {
            this.WalletTransactions = new List<WalletTransaction>();
        }

        public int WalletID { get; set; }
        public int UserID { get; set; }
        public decimal WalletBalance { get; set; }

        public User User { get; set; }
        public List<WalletTransaction> WalletTransactions { get; set; }
    }
}
