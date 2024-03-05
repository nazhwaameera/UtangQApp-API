using System;
using System.Collections.Generic;
using System.Text;

namespace UtangQAppBLL.DTOs.User
{
    public class UserCreateDTO
    {
        public string Username { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public string UserFullName { get; set; }
        public string UserPhoneNumber { get; set; }
    }
}
