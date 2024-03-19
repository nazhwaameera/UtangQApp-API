using System.Collections;
using UtangQAppBLL.DTOs.Transaction;
using UtangQAppBLL.DTOs.User;

namespace UtangQApp_MVC.Models
{
	public class BillRecipientViewModel
	{
		public decimal TotalBillRecipientAmountByBillID { get; set; }
		public IEnumerable<UserDTO> Users { get; set; }
		public IEnumerable<UserDTO> Friends { get; set; }
		public IEnumerable<BillStatusDTO> BillStatuses { get; set; }
		public IEnumerable<TaxStatusDTO> TaxStatuses { get; set; }
		public IEnumerable<BillRecipientDTO> BillRecipients { get; set; }
	}
}
