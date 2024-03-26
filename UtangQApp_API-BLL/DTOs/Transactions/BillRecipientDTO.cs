namespace UtangQApp_API_BLL.DTOs.Transactions
{
    public class BillRecipientDTO
    {
        public int BillRecipientID { get; set; }
        public int BillID { get; set; }
        public int RecipientUserID { get; set; }
        public DateTime SentDate { get; set; }
        public int BillRecipientStatusID { get; set; }
        public int BillRecipientTaxStatusID { get; set; }
        public decimal BillRecipientAmount { get; set; }
    }
}
