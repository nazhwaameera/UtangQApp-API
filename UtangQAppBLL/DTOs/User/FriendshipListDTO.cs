using System;
using System.Collections.Generic;
using System.Text;

namespace UtangQAppBLL.DTOs.User
{
	public class FriendshipListDTO
	{
		public int FriendshipListID { get; set; }
		public int? FriendshipID { get; set; }
		public int? SenderUserID { get; set; }
		public int? ReceiverUserID { get; set; }
		public int? FriendshipStatusID { get; set; }
	}
}
