namespace UtangQApp_API_BLL.DTOs.Users
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public string UserFullName { get; set; }
        public string UserPhoneNumber { get; set; }
        public bool IsLocked { get; set; }
    }
}
