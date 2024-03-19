using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using UtangQAppBLL.DTOs.User;
using UtangQAppBLL.Interfaces.User;

namespace UtangQApp_MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserBLL _userBLL;

        public UsersController(IUserBLL userBLL)
        {
			_userBLL = userBLL;
		}

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
			try
			{
                var user = _userBLL.LoginUser(Username, Password);
                var userDtoSerialize = JsonSerializer.Serialize(user);
                HttpContext.Session.SetString("user", userDtoSerialize);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Message = @"<div class='alert alert-danger'><strong>Error!&nbsp;</strong>" + ex.Message + "</div>";
                return View();
            }
			
		}

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserCreateDTO user)
        {
			try
            {
				_userBLL.Create(user);
				return RedirectToAction("Login");
			}
			catch (Exception ex)
            {
				ViewBag.Message = @"<div class='alert alert-danger'><strong>Error!&nbsp;</strong>" + ex.Message + "</div>";
				return View();
			}
		}

		public IActionResult Logout()
		{
			HttpContext.Session.Remove("user");
			return RedirectToAction("Login");
		}

	}
}
