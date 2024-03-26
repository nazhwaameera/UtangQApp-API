using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtangQApp_API_BLL.DTOs.Users
{
    public class WalletBalanceDTO
    {
        public int UserID { get; set; }
        public decimal Amount { get; set; }
        public char OperationFlag { get; set; }
    }
}
