namespace UtangQApp_API_BLL.DTOs.Reports
{
    public class TransactionHistoryReportDTO
    {
        public DateTime TransactionDate { get; set; }
        public decimal TransactionAmount { get; set; }
        public string TransactionDescription { get; set; }
    }
}
