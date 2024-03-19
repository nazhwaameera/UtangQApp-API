using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using UtangQApp_MVC.Models;
using UtangQAppBLL;
using UtangQAppBLL.DTOs.Transaction;
using UtangQAppBLL.DTOs.User;
using UtangQAppBLL.Interfaces.User;
using UtangQAppBO;

namespace UtangQApp_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private UserDTO user = null;
		private readonly IUserBLL _userBLL;
		private readonly IBillBLL _billBLL;
        private readonly IWalletBLL _walletBLL;
        private readonly IFriendshipBLL _friendshipBLL;
        private readonly IFriendshipListBLL _friendshipListBLL;

        public HomeController(ILogger<HomeController> logger, IUserBLL userBLL, IBillBLL billBLL, IWalletBLL walletBLL, 
            IFriendshipBLL friendshipBLL, IFriendshipListBLL friendshipListBLL )
        {
            _logger = logger;
            _userBLL = userBLL;
            _billBLL = billBLL;
            _walletBLL = walletBLL;
            _friendshipBLL = friendshipBLL;
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

            // bind data Bills by User ID
            var bills = _billBLL.ReadUserBills(userID);
            //bind data Wallet by User ID
            var wallet = _walletBLL.ReadWalletbyUserID(userID);
			var amountPending = _billBLL.GetTotalPendingAmountOwedProcedure(userID);
			var amountPaid = _billBLL.GetTotalBillAmountPaidProcedure(userID);
			var amountAccepted = _billBLL.GetTotalBillAmountAcceptedProcedure(userID);
			var amountAwaiting = _billBLL.GetTotalBillAmountAwaitingProcedure(userID);
			//bind data Friendship by User ID
			var friendship = _friendshipBLL.GetByUserID(userID);
            //bind data FriendshipList by User ID
            var friendshipList = _friendshipListBLL.GetByUserID(userID);
			var incomingRequest = _friendshipListBLL.GetPendingFriendRequestsByReceiverUserID(userID);

			var viewModel = new DashboardViewModel
            {
				TotalBillsCreated = _billBLL.GetTotalBillAmountCreatedProcedure(userID),
				TotalBillsUnassigned = _billBLL.CalculateTotalUnassignedBillAmount(userID),
				TotalBillsPaid = _billBLL.GetTotalBillAmountCreatedPaidProcedure(userID),
				TotalBillsPending = _billBLL.GetTotalBillAmountCreatedPendingProcedure(userID),
				TotalBillsAccepted = _billBLL.GetTotalBillAmountCreatedAcceptedProcedure(userID),
				TotalBillsAwaiting = _billBLL.GetTotalBillAmountCreatedAwaitingProcedure(userID),
				TotalBillsRejected = _billBLL.GetTotalBillAmountCreatedRejectedProcedure(userID),
				BillsToBePaidTotal = _billBLL.GetTotalPendingAmountOwedProcedure(userID),
                Bills = bills,
                Wallet = wallet,
				AmountPending = amountPending,
				AmountPaid = amountPaid,
				AmountAccepted = amountAccepted,
				AmountAwaiting = amountAwaiting,
				Friendship = friendship,
                FriendshipList = friendshipList,
				IncomingRequest = incomingRequest
			};

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateBill(decimal BillAmount, DateTime BillDate, decimal OwnerContribution, string BillDescription)
        {
			user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
			int userID = user.UserID;
			try
			{
				var bill = new BillCreateDTO
				{
                    UserID = userID,
					BillDate = BillDate,
					BillAmount = BillAmount,
					OwnerContribution = OwnerContribution,
					BillDescription = BillDescription,
				};

				_billBLL.Create(bill);

				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				return RedirectToAction("Index");
			}
		}

		[HttpPost]
		public IActionResult CreateWallet(decimal BalanceAmount)
		{
			user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
			int userID = user.UserID;
			try
			{
				var UserID = userID;
				var wallet = new WalletCreateDTO
				{
					UserID = UserID,
					WalletBalance = BalanceAmount,
				};
				_walletBLL.Create(wallet);

				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				return RedirectToAction("Index");
			}
		}

		[HttpPost]
        public IActionResult AddWalletBalance(decimal BalanceAmount)
        {
			user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
			int userID = user.UserID;
			try
            {
                var UserID = userID;
				_walletBLL.UpdateWalletBalance(userID, BalanceAmount, 'A');

				return RedirectToAction("Index");
			}
			catch (Exception ex)
            {
				return RedirectToAction("Index");
			}
		}

		[HttpPost]
		public IActionResult EditBill(int BillID, decimal BillAmount, DateTime BillDate, decimal OwnerContribution, string BillDescription)
		{
			user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
			int userID = user.UserID;
			try
			{
				var bill = new BillDTO
				{
					UserID = userID,
                    BillID = BillID,
					BillDate = BillDate,
					BillAmount = BillAmount,
					OwnerContribution = OwnerContribution,
					BillDescription = BillDescription,
				};

				_billBLL.Update(bill);

				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				return RedirectToAction("Index");
			}
		}

		[HttpPost]
        public IActionResult DeleteBill(int BillID)
        {
            try
            {
                _billBLL.Delete(BillID);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
				return RedirectToAction("Index");
			}
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
