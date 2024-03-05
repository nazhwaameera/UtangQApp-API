using System;
using System.Collections.Generic;
using System.Text;

namespace UtangQAppBO
{
    public class View_PaymentReceiptReport
    {
        public int PaymentReceiptID { get; set; }
        public int BillRecipientID { get; set; }
        public DateTime ReceiptSentDate { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public string PaymentReceiptURL { get; set; }
    }
}
