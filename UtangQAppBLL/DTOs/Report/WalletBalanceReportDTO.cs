using System;
using System.Collections.Generic;
using System.Text;

namespace UtangQAppBLL.DTOs.Report
{
    public class WalletBalanceReportDTO
    {
        public int UserID { get; set; }
        public decimal WalletBalance { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal WalletTransactionAmount { get; set; }
        public string TransactionDescription { get; set; }
    }
}
