using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBO;

namespace UtangQAppDAL.Interfaces
{
	public interface IFriendship : IHelper<Friendship>
	{
		Friendship GetByUserID(int userID);
		void CreateFriendship(int UserID);
	}
}
