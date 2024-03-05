using System;
using System.Collections.Generic;
using System.Text;

namespace UtangQAppBO
{
    public class View_BillRecipientStatusReport
    {
        public int BillRecipientID { get; set; }
        public int BillID { get; set; }
        public DateTime SentDate { get; set; }
        public string Status { get; set; }
    }
}
