using System;
using System.Collections.Generic;
using UtangQAppBLL.DTOs.User;
using UtangQAppBLL.Interfaces.User;
using UtangQAppBO;
using UtangQAppDAL;
using UtangQAppDAL.Interfaces;

namespace UtangQAppBLL
{
    public class UserBLL : IUserBLL
    {
        private readonly IUser _userDAL;
        public UserBLL()
        {
            _userDAL = new UserDAL();
        }
        public void Create(UserCreateDTO entity)
        {
            try
            {
                var user = new User
                {
                    Username = entity.Username,
                    UserPassword = entity.UserPassword,
                    UserEmail = entity.UserEmail,
                    UserFullName = entity.UserFullName,
                    UserPhoneNumber = entity.UserPhoneNumber
                };
                _userDAL.Create(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _userDAL.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserDTO Get(int id)
        {
            UserDTO userDTO = new UserDTO();
            try
            {
                var user = _userDAL.Get(id);
                userDTO.UserID = user.UserID;
                userDTO.Username = user.Username;
                userDTO.UserPassword = user.UserPassword;
                userDTO.UserEmail = user.UserEmail;
                userDTO.UserFullName = user.UserFullName;
                userDTO.UserPhoneNumber = user.UserPhoneNumber;
                userDTO.IsLocked = user.IsLocked;
                return userDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<UserDTO> GetAll()
        {
            List<UserDTO> userDTOs = new List<UserDTO>();
            var usersDAL = _userDAL.GetAll();
            foreach (var user in usersDAL)
            {
                UserDTO userDTO = new UserDTO
                {
                    UserID = user.UserID,
                    Username = user.Username,
                    UserPassword = user.UserPassword,
                    UserEmail = user.UserEmail,
                    UserFullName = user.UserFullName,
                    UserPhoneNumber = user.UserPhoneNumber,
                    IsLocked = user.IsLocked
                };
                userDTOs.Add(userDTO);
            }
            return userDTOs;
        }

        public UserDTO GetByUsername(string Username)
        {
            UserDTO userDTO = new UserDTO();
            try
            {
                var user = _userDAL.GetByUsername(Username);
                userDTO.UserID = user.UserID;
                userDTO.Username = user.Username;
                userDTO.UserPassword = user.UserPassword;
                userDTO.UserEmail = user.UserEmail;
                userDTO.UserFullName = user.UserFullName;
                userDTO.UserPhoneNumber = user.UserPhoneNumber;
                userDTO.IsLocked = user.IsLocked;
                return userDTO;
            }
            catch (Exception ex)
            {
                return new UserDTO();
            }
        }

        public UserDTO LoginUser(string Username, string UserPassword)
        {
            UserDTO userDTO = null;
            try
            {
                var user = _userDAL.LoginUser(Username, UserPassword);
                if(user != null)
                {
                    userDTO = new UserDTO
                    {
                        UserID = user.UserID,
                        Username = user.Username,
                        UserPassword = user.UserPassword,
                        UserEmail = user.UserEmail,
                        UserFullName = user.UserFullName,
                        UserPhoneNumber = user.UserPhoneNumber,
                        IsLocked = user.IsLocked
                    };
                }
            }
            catch (Exception ex)
            {
                return userDTO;
            }
            return userDTO;
        }

        public void Update(UserDTO entity)
        {
            try
            {
                var user = new User
                {
                    UserID = entity.UserID,
                    Username = entity.Username,
                    UserPassword = entity.UserPassword,
                    UserEmail = entity.UserEmail,
                    UserFullName = entity.UserFullName,
                    UserPhoneNumber = entity.UserPhoneNumber,
                    IsLocked = entity.IsLocked
                };
                _userDAL.Update(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
