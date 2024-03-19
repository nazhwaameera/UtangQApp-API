using UtangQAppBLL.DTOs.User;

namespace UtangQApp_MVC.Models
{
	public class DashboardViewModel
	{
		public decimal TotalBillsCreated { get; set; }
		public decimal TotalBillsUnassigned { get; set; }
		public decimal TotalBillsPaid { get; set; }
		public decimal TotalBillsPending { get; set; }
		public decimal TotalBillsAccepted { get; set; }
		public decimal TotalBillsAwaiting { get; set; }
		public decimal TotalBillsRejected { get; set; }
		public decimal BillsToBePaidTotal { get; set; }
		public decimal AmountPending { get; set; }
		public decimal AmountPaid { get; set; }
		public decimal AmountAccepted { get; set; }
		public decimal AmountAwaiting { get; set; }
		public IEnumerable<BillDTO>? Bills { get; set; }
		public WalletDTO? Wallet { get; set; }
		public IEnumerable<FriendshipListDTO> IncomingRequest { get; set; }
		public FriendshipDTO? Friendship { get; set; }
		public IEnumerable<FriendshipListDTO>? FriendshipList { get; set; }

	}
}
