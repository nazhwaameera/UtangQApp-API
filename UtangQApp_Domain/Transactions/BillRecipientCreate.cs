
namespace UtangQApp_Domain.Transactions
{
    public class BillRecipientCreate
    {
        public int BillID { get; set; }
        public int RecipientUserID { get; set; }
        public int TotalUsers { get; set; }
        public bool IsSplitEvenly { get; set; }
        public string TaxStatusDescription { get; set; }
        public decimal TaxCharged { get; set; }
    }
}
