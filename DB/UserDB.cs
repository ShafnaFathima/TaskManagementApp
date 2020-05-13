using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Linq;
using TaskManagement.model;

namespace TaskManagement.DB
{
     public class UserDB
    {
        private static List<User> userlist = new List<User>();

        public static void AddUser(User user)
        {
            userlist.Add(user);
        }
       public static User ValidLogin(int userid,string password)
        {
         return userlist.FirstOrDefault(user => user.UserID == userid && password.Equals(user.Password));
        }

        public static bool IsValidID(int id)
        {
            var isvalid = (from user in userlist
                           where user.UserID == id
                           select user).Any();
            return isvalid;
        }
     }
    
}
