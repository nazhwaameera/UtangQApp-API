using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBLL.DTOs.User;

namespace UtangQAppBLL.Interfaces.User
{
    public interface IUserBLL : ICrudBLL<UserDTO>
    {
        void Create(UserCreateDTO entity);
        UserDTO LoginUser(string Username, string UserPassword);
        UserDTO GetByUsername(string Username);
    }
}
