namespace UtangQApp_API_BLL.DTOs.Transactions
{
    public class PaymentReceiptCreateDTO
    {
        public int BillRecipientID { get; set; }
        public DateTime SentDate { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public string PaymentReceiptURL { get; set; }
    }
}
