namespace UtangQApp_API_BLL.DTOs.Reports
{
    public class BillPaymentReportDTO
    {
        public decimal BillAmount { get; set; }
        public DateTime BillDate { get; set; }
        public string BillDescription { get; set; }
        public string PaymentStatus { get; set; }
    }
}
