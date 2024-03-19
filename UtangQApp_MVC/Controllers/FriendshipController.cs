using Microsoft.AspNetCore.Mvc;
using UtangQAppBLL.Interfaces.User;
using UtangQApp_MVC.Models;
using UtangQAppBLL.DTOs.User;
using System.Text.Json;

namespace UtangQApp_MVC.Controllers
{
	public class FriendshipController : Controller
	{
		private UserDTO user = null;
		private readonly IUserBLL _userBLL;
		private readonly IFriendshipBLL _friendshipBLL;
		private readonly IFriendshipStatusBLL _friendshipStatusBLL;
		private readonly IFriendshipListBLL _friendshipListBLL;

		public FriendshipController(IUserBLL userBLL, IFriendshipBLL friendshipBLL, IFriendshipStatusBLL friendshipStatusBLL, IFriendshipListBLL friendshipListBLL)
		{
			_userBLL = userBLL;
			_friendshipBLL = friendshipBLL;
			_friendshipStatusBLL = friendshipStatusBLL;
			_friendshipListBLL = friendshipListBLL;
		}

		public IActionResult Index()
		{
			if (HttpContext.Session.GetString("user") == null)
			{
				return RedirectToAction("Login", "Users");
			}
			user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
			int userID = user.UserID;

			var users = _userBLL.GetAll();
			var friendshipStatuses = _friendshipStatusBLL.GetAll();
			var friendship = _friendshipBLL.GetByUserID(userID);
			var friendshipList = _friendshipListBLL.GetByUserID(userID);
			var friends = _userBLL.GetFriends(friendship?.FriendshipID ?? 0);
			var noFriendList = _userBLL.GetNonFriends(friendship?.FriendshipID ?? 0);
			var incomingRequest = _friendshipListBLL.GetPendingFriendRequestsByReceiverUserID(userID);

			var viewModel = new FriendshipViewModel
			{
				Users = users,
				FriendshipStatuses = friendshipStatuses,
				Friendship = friendship,
				FriendshipList = friendshipList,
				Friends = friends,
				NotFriends = noFriendList,
				IncomingRequest = incomingRequest
			};

			return View(viewModel);
		}
		[HttpPost]
		public IActionResult CreateFriendship()
		{
			user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
			int userID = user.UserID;
			try
			{
				_friendshipBLL.CreateFriendship(userID);
				return RedirectToAction("Index");
			}
			catch (System.Exception ex)
			{
				return RedirectToAction("Index");
			}
		}

		[HttpPost]
		public IActionResult SendRequest(int friendshipID, int selectedUserID)
		{
			user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
			int userID = user.UserID;
			try
			{
				_friendshipListBLL.CreateFriendRequest(friendshipID, userID, selectedUserID);
				return RedirectToAction("Index");
			}
			catch (System.Exception ex)
			{
				return RedirectToAction("Index");
			}
		}

		[HttpPost]
		public IActionResult AcceptFriendRequest(int requestId)
		{
			try
			{
				_friendshipListBLL.HandleFriendRequest(requestId, 2);
				return Ok("Friend request accepted successfully.");
			}
			catch (Exception ex)
			{
				// Log the exception or handle it accordingly
				return StatusCode(500, "An error occurred while accepting the friend request.");
			}
		}
		[HttpPost]
		public IActionResult RejectFriendRequest(int requestId)
		{
			try
			{
				_friendshipListBLL.HandleFriendRequest(requestId, 3);
				return Ok("Friend request accepted successfully.");
			}
			catch (Exception ex)
			{
				// Log the exception or handle it accordingly
				return StatusCode(500, "An error occurred while accepting the friend request.");
			}
		}
	}
}
