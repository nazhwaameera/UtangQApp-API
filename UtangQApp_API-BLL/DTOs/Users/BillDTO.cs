﻿namespace UtangQApp_API_BLL.DTOs.Users
{
    public class BillDTO
    {
        public int BillID { get; set; }
        public int UserID { get; set; }
        public decimal BillAmount { get; set; }
        public DateTime BillDate { get; set; }
        public string BillDescription { get; set; }
        public decimal OwnerContribution { get; set; }

    }
}
