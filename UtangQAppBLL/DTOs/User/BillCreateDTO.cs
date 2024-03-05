using System;
using System.Collections.Generic;
using System.Text;

namespace UtangQAppBLL.DTOs.User
{
    public class BillCreateDTO
    {
        public int UserID { get; set; }
        public decimal BillAmount { get; set; }
        public DateTime BillDate { get; set; }
        public string BillDescription { get; set; }
        public decimal OwnerContribution { get; set; }

    }
}
