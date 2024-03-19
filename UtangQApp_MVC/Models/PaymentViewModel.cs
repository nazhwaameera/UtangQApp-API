using UtangQAppBLL.DTOs.User;
using UtangQAppBLL.DTOs.Transaction;
using UtangQAppBO;

namespace UtangQApp_MVC.Models
{
	public class PaymentViewModel
	{
		public WalletDTO Wallet { get; set; }
		public IEnumerable<BillRecipientWithDescDTO> BillRecipients { get; set; }
		public decimal AmountPending { get; set; }
		public decimal AmountPaid { get; set; }
		public decimal AmountAccepted { get; set; }
		public decimal AmountAwaiting{ get; set; }
		public decimal AmountOwed { get; set; }

	}
}
