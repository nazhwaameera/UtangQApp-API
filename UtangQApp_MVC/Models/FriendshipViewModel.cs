using UtangQAppBLL.DTOs.User;

namespace UtangQApp_MVC.Models
{
	public class FriendshipViewModel
	{
		public IEnumerable<UserDTO> Users { get; set; }
		public IEnumerable<UserDTO> Friends { get; set; }
		public IEnumerable<UserDTO> NotFriends { get; set; }
		public FriendshipDTO? Friendship { get; set; }
		public IEnumerable<FriendshipListDTO>? FriendshipList { get; set; }
		public IEnumerable<FriendshipListDTO> IncomingRequest { get; set; }
		public IEnumerable<FriendshipStatusDTO> FriendshipStatuses { get; set; }
	}
}
