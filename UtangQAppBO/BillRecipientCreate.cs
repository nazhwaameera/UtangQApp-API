using System;
using System.Collections.Generic;
using System.Text;

namespace UtangQAppBO
{
    public class BillRecipientCreate
    {
        public int BillID { get; set; }
        public int RecipientUserID { get; set; }
        public int TotalUsers { get; set; }
        public bool IsSplitEvenly { get; set; }
        public string TaxStatusDescription { get; set; }
        public decimal TaxCharged { get; set; }
    }
}
