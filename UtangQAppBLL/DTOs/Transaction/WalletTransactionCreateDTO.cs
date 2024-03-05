using System;
using System.Collections.Generic;
using System.Text;

namespace UtangQAppBLL.DTOs.Transaction
{
    public class WalletTransactionCreateDTO
    {
        public int WalletID { get; set; }
        public decimal WalletTransactionAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionDescription { get; set; }
    }
}
