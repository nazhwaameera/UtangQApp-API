using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UtangQAppBLL.DTOs.User
{
    public class UserCreateDTO
    {
        [Required]
        public string Username { get; set; }
		[Required]
		public string UserPassword { get; set; }
		[Required]
        [Compare("UserPassword", ErrorMessage = "Password and Confirm Password must match.")]
		public string UserConfirmPassword { get; set; }
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string UserFullName { get; set; }
        [Required]
        public string UserPhoneNumber { get; set; }
    }
}
