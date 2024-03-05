using System;
using System.Collections.Generic;
using System.Text;

namespace UtangQAppBO
{
    public class BillRecipient
    {
        public int BillRecipientID { get; set; }
        public int BillID { get; set; }
        public int RecipientUserID { get; set; }
        public DateTime SentDate { get; set; }
        public int BillRecipientStatusID { get; set; }
        public int BillRecipientTaxStatusID { get; set; }
        public decimal BillRecipientAmount { get; set; }

        public User User { get; set; }
        public BillStatus BillStatus { get; set; }
        public TaxStatus TaxStatus { get; set; }
        public PaymentReceipt PaymentReceipt { get; set; }
    }
}
