using System;
using System.Collections.Generic;
using System.Text;

namespace UtangQAppBO
{
    public class View_TransactionHistoryReport
    {
        public DateTime TransactionDate { get; set; }
        public decimal TransactionAmount { get; set; }
        public string TransactionDescription { get; set; }

    }
}
