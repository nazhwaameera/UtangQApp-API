using System;
using System.Collections.Generic;
using System.Text;

namespace UtangQAppBO
{
    public class TaxStatus
    {
        public TaxStatus()
        {
            this.BillRecipients = new List<BillRecipient>();
        }

        public int TaxStatusID { get; set; }
        public string TaxStatusDescription { get; set; }

        public List<BillRecipient> BillRecipients { get; set; }
    }

}
