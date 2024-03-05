using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBO;

namespace UtangQAppDAL.Interfaces
{
    public interface IUser : ICrud<User>
    {
        User LoginUser (string Username, string UserPassword);
        User GetByUsername(string Username);
    }
}
