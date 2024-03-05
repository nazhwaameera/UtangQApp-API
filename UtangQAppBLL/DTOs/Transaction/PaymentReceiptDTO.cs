using System;
using System.Collections.Generic;
using System.Text;

namespace UtangQAppBLL.DTOs.Transaction
{
    public class PaymentReceiptDTO
    {
        public int PaymentReceiptID { get; set; }
        public int BillRecipientID { get; set; }
        public DateTime SentDate { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public string PaymentReceiptURL { get; set; }
    }
}
