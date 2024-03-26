using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtangQApp_API_BLL.DTOs.Users
{
    public class FriendRequestDTO
    {
        public int FriendshipID { get; set; }
        public int SenderUserID { get; set; }
        public int ReceiverUserID { get; set; }
    }
}
