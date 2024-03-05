using System;
using System.Collections.Generic;
using System.Text;

namespace UtangQAppBO
{
    public class View_WalletBalanceReport
    {
        public int UserID { get; set; }
        public decimal WalletBalance { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal WalletTransactionAmount { get; set; }
        public string TransactionDescription { get; set; }
    }
}
