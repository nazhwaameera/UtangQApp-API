using System;
using System.Collections.Generic;
using System.Text;

namespace UtangQAppBLL.DTOs.User
{
    public class WalletDTO
    {
        public int WalletID { get; set; }
        public int UserID { get; set; }
        public decimal WalletBalance { get; set; }
    }
}
