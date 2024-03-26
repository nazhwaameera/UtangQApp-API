namespace UtangQApp_API_BLL.DTOs.Reports
{
    public class WalletBalanceReportDTO
    {
        public int UserID { get; set; }
        public decimal WalletBalance { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal WalletTransactionAmount { get; set; }
        public string TransactionDescription { get; set; }
    }
}
