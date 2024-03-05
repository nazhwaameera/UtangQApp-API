using System;
using System.Collections.Generic;
using System.Text;

namespace UtangQAppBO
{
    public class View_BillPaymentReport
    {
        public decimal BillAmount { get; set; }
        public DateTime BillDate { get; set; }
        public string BillDescription { get; set; }
        public string PaymentStatus { get; set; }

    }
}
