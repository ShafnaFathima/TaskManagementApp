using System.Collections.Generic;
using System.Linq;
using TaskManagement.Models;


namespace TaskManagement.DB
{
    public class UserDB
    {
        private static List<User> _userList = new List<User>();

        public static void AddUser(User user)
        {
            _userList.Add(user);
        }

        public static User ValidLogin(int userId, string password)
        {
            return _userList.FirstOrDefault(user => user.UserID == userId && password.Equals(user.Password));
        }

        public static bool IsValidID(int id)
        {
            var isValid = (from user in _userList
                           where user.UserID == id
                           select user).Any();
            return isValid;
        }

        public static string GetUserName(int id)
        {
            var user = _userList.First(user => user.UserID == id);
            return user.UserName;
        }
    }
}
