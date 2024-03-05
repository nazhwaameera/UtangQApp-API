using System;
using System.Collections.Generic;
using System.Text;

namespace UtangQAppBLL.DTOs.Transaction
{
    public class BillRecipientCreateDTO
    {
        public int BillID { get; set; }
        public int RecipientUserID { get; set; }
        public DateTime SentDate { get; set; }
        public int BillRecipientStatusID { get; set; }
        public int BillRecipientTaxStatusID { get; set; }
        public decimal BillRecipientAmount { get; set; }
    }
}
