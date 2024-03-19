using Microsoft.AspNetCore.Mvc;
using UtangQAppBLL.DTOs.Transaction;
using UtangQAppBLL.Interfaces.User;
using UtangQAppBLL.Interfaces.Transaction;
using UtangQApp_MVC.Models;
using UtangQAppBLL;
using System.Text.Json;
using UtangQAppBLL.DTOs.User;
using UtangQAppBO;

namespace UtangQApp_MVC.Controllers
{
	public class BillRecipientController : Controller
	{
		private UserDTO user = null;
		private readonly IBillRecipientBLL _billRecipientBLL;
		private readonly IFriendshipBLL _friendshipBLL;
		private readonly IUserBLL _userBLL;
		private readonly IBillStatusBLL _billStatusBLL;
		private readonly ITaxStatusBLL _taxStatusBLL;

		public BillRecipientController(IBillRecipientBLL billRecipientBLL, IFriendshipBLL friendshipBLL, IUserBLL userBLL, IBillStatusBLL billStatusBLL, ITaxStatusBLL taxStatusBLL)
		{
			_billRecipientBLL = billRecipientBLL;
			_friendshipBLL = friendshipBLL;
			_userBLL = userBLL;
			_billStatusBLL = billStatusBLL;
			_taxStatusBLL = taxStatusBLL;

		}
		public IActionResult Details(int billID)
		{
			if (HttpContext.Session.GetString("user") == null)
			{
				return RedirectToAction("Login", "Users");
			}
			user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
			int userID = user.UserID;

			ViewData["BillID"] = billID;
			TempData["BillID"] = billID;


			var users = _userBLL.GetAll();
			var friendship = _friendshipBLL.GetByUserID(userID);
			var friends = _userBLL.GetFriends(friendship?.FriendshipID ?? 0);
			var billStatuses = _billStatusBLL.GetAll();
			var taxStatuses = _taxStatusBLL.GetAll();
			var billRecipients = _billRecipientBLL.GetBillRecipientsByBillID(billID);

			var viewModel = new BillRecipientViewModel
			{
				Users = users,
				TotalBillRecipientAmountByBillID = _billRecipientBLL.TotalBillRecipientAmountByBillID(billID),
				BillRecipients = billRecipients,
				Friends = friends,
				BillStatuses = billStatuses,
				TaxStatuses = taxStatuses
			};
			return View(viewModel);
		}

		[HttpPost]
		public IActionResult CreateBillRecipient([FromBody] BillRecipientCreateDTO data)
		{
			try
			{
				// Perform processing with the deserialized object
				_billRecipientBLL.Create(data);

				// Return appropriate response
				return Ok("Bill recipient created successfully");
			}
			catch (Exception ex)
			{
				// Handle the exception
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}

		[HttpPost]
		public IActionResult ConfirmPayment(int requestId)
		{
			try
			{
				_billRecipientBLL.UpdateBillRecipientPaymentStatus(requestId, 2);
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
