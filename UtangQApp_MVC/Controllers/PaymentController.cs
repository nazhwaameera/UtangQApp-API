using Microsoft.AspNetCore.Mvc;
using UtangQAppBLL.Interfaces.Transaction;
using UtangQAppBLL.Interfaces.User;
using UtangQApp_MVC.Models;
using UtangQAppBLL;
using UtangQAppDAL;
using UtangQAppBLL.DTOs.User;
using UtangQAppBO;
using System.Text.Json;
using UtangQAppBLL.DTOs.Transaction;

namespace UtangQApp_MVC.Controllers
{
	public class PaymentController : Controller
	{
		private UserDTO user = null;
		private readonly IUserBLL _userBLL;
		private readonly IWalletBLL _walletBLL;
		private readonly IBillRecipientBLL _billRecipientBLL;
		private readonly IPaymentReceiptBLL _paymentReceiptBLL;
		private readonly IBillBLL _billBLL;

		public PaymentController(IUserBLL userBLL, IWalletBLL walletBLL, IBillRecipientBLL billRecipientBLL, IPaymentReceiptBLL paymentReceiptBLL, IBillBLL billBLL)
		{
			_userBLL = userBLL;
			_walletBLL = walletBLL;
			_billRecipientBLL = billRecipientBLL;
			_paymentReceiptBLL = paymentReceiptBLL;
			_billBLL = billBLL;
		}
		public IActionResult Index()
		{
			if (HttpContext.Session.GetString("user") == null)
			{
				return RedirectToAction("Login", "Users");
			}
			user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
			int userID = user.UserID;

			var wallet = _walletBLL.ReadWalletbyUserID(userID);
			var billRecipients = _billRecipientBLL.ReadBillRecipientByRecipientUserIDWithDescription(userID);
			var amountPending = _billBLL.GetTotalPendingAmountOwedProcedure(userID);
			var amountPaid = _billBLL.GetTotalBillAmountPaidProcedure(userID);
			var amountAccepted = _billBLL.GetTotalBillAmountAcceptedProcedure(userID);
			var amountAwaiting = _billBLL.GetTotalBillAmountAwaitingProcedure(userID);
			var amountOwed = amountPending + amountPaid + amountAccepted + amountAwaiting;
			var viewModel = new PaymentViewModel
			{
				Wallet = wallet,
				BillRecipients = billRecipients,
				AmountPending = amountPending,
				AmountPaid = amountPaid,
				AmountAccepted = amountAccepted,
				AmountAwaiting = amountAwaiting,
				AmountOwed = amountOwed
			};
			return View(viewModel);
		}

		[HttpGet]
		public IActionResult GetPayment(int billRecipientID)
		{
			// Call the BLL method to retrieve payment data
			try
			{
				// Retrieve payment data based on the billRecipientID
				var payment = _paymentReceiptBLL.ReadPaymentReceiptbyBillRecipientID(billRecipientID);

				if (payment != null)
				{
					return Json(new
					{
						success = true,
						payment = new
						{
							PaymentReceiptID = payment.PaymentReceiptID,
							BillRecipientID = payment.BillRecipientID,
							SentDate = payment.SentDate.ToString("yyyy-MM-dd"),
							ConfirmationDate = payment.ConfirmationDate.HasValue ? payment.ConfirmationDate.Value.ToString("yyyy-MM-dd") : ""

						}
					});
				}
				else
				{
					return Json(new { success = false, message = "Payment data not found" });
				}
			}
			catch (Exception ex)
			{
				return Json(new { success = false, message = "An error occurred while retrieving payment data", error = ex.Message });
			}
		}

		[HttpPost]
		public IActionResult AcceptBillRecipient(int requestId)
		{
			try
			{
				_billRecipientBLL.HandleIncomingBillRecipient(requestId, 4);
				return Ok("Friend request accepted successfully.");
			}
			catch (Exception ex)
			{
				// Log the exception or handle it accordingly
				return StatusCode(500, "An error occurred while accepting the friend request.");
			}
		}

		[HttpPost]
		public IActionResult MakePayment(int requestId)
		{
			try
			{
				_paymentReceiptBLL.CreatePaymentReceiptAndUpdateStatus(requestId, "example.com");
				return Ok("Payment created successfully.");
			}
			catch (Exception ex)
			{
				// Log the exception or handle it accordingly
				return StatusCode(500, "An error occurred while creating a payment receipt.");
			}
		}
	}
}
