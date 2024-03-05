using System;
using System.Collections.Generic;
using System.Text;

namespace UtangQAppBO
{
    public class PaymentReceipt
    {
        public int PaymentReceiptID { get; set; }
        public int BillRecipientID { get; set; }
        public DateTime SentDate { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public string PaymentReceiptURL { get; set; }

        public BillRecipient BillRecipient { get; set; }
    }
}
