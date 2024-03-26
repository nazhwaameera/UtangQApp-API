using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtangQApp_API_BLL.DTOs.Users
{
    public class LoginTokenDTO
    {
        public int? UserID { get; set; }
        public string? Username { get; set; }
        public string? Token { get; set; }
    }
}
