namespace UtangQApp_API_BLL.DTOs.Transactions
{
	public class BillRecipientWithDescDTO
	{
		public int BillRecipientID { get; set; }
		public int BillID { get; set; }
		public decimal BillRecipientAmount { get; set; }
		public string BillDescription { get; set; }
		public string Username { get; set; }
		public int RecipientUserID { get; set; }
		public DateTime SentDate { get; set; }
		public string BillRecipientStatus { get; set; }
		public string BillRecipientTax { get; set; }
	}
}
