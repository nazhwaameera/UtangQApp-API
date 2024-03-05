using System;
using System.Collections.Generic;
using System.Text;

namespace UtangQAppBLL.DTOs.Report
{
    public class TransactionHistoryReportDTO
    {
        public DateTime TransactionDate { get; set; }
        public decimal TransactionAmount { get; set; }
        public string TransactionDescription { get; set; }
    }
}
