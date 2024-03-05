using System;
using System.Collections.Generic;
using System.Text;

namespace UtangQAppBLL.DTOs.Report
{
    public class PaymentReceiptReportDTO
    {
        public int PaymentReceiptID { get; set; }
        public int BillRecipientID { get; set; }
        public DateTime ReceiptSentDate { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public string PaymentReceiptURL { get; set; }
    }
}
