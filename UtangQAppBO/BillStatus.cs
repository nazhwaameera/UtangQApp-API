using System;
using System.Collections.Generic;
using System.Text;

namespace UtangQAppBO
{
    public class BillStatus
    {
        public BillStatus()
        {
            this.BillRecipients = new List<BillRecipient>();
        }

        public int BillStatusID { get; set; }
        public string BillStatusDescription { get; set; }

        public List<BillRecipient> BillRecipients { get; set; }
    }
}
