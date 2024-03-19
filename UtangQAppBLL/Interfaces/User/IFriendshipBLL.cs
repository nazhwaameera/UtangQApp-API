using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBLL.DTOs.User;

namespace UtangQAppBLL.Interfaces.User
{
	public interface IFriendshipBLL : IHelperBLL<FriendshipDTO>
	{
		FriendshipDTO GetByUserID(int userID);
		void CreateFriendship(int UserID);
	}
}
