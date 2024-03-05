using System;
using System.Collections.Generic;
using System.Text;

namespace UtangQAppBO
{
    public class Bill
    {
        public int BillID { get; set; }
        public int UserID { get; set; }
        public decimal BillAmount { get; set; }
        public DateTime BillDate { get; set; }
        public string BillDescription { get; set; }
        public decimal OwnerContribution { get; set; }


        public User User { get; set; }
    }
}
