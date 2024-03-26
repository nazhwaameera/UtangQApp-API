namespace UtangQApp_API_BLL.DTOs.Transactions
{
    public class WalletTransactionCreateDTO
    {
        public int WalletID { get; set; }
        public decimal WalletTransactionAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionDescription { get; set; }
    }
}
