using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using TaskManagement.Models;
using TaskManagement.DB;
using TaskManagement.Util;
using System.Dynamic;

namespace TaskManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            User newUser = new User() { UserName = "USER1", UserID = 1, Password = "user1*" };
            UserDB.AddUser(newUser);
            User newUser1 = new User() { UserName = "USER2", UserID = 2, Password = "user2*" };
            UserDB.AddUser(newUser1);
            User newUser2 = new User() { UserName = "USER3", UserID = 3, Password = "user3*" };
            UserDB.AddUser(newUser2);

            bool login = true;
            do
            {
                User user = new User();
                while (true)
                {
                    Console.WriteLine("\nEnter your user ID");
                    int userid = int.Parse(Console.ReadLine());
                    Console.WriteLine("\nEnter your Password");
                    string password = Console.ReadLine();

                    user = UserDB.ValidLogin(userid, password);
                    if (user != null)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nTry again!!");
                    }
                }

                int userId = user.UserID;
                int choice;

                do
                {
                    Console.WriteLine("\nEnter your option " +
                     "\n1:AddTask" +
                     "\n2:List tasks assigned to me " +
                     "\n3:List tasks assigned to a user" +
                     "\n4:Logout and Login as new user" +
                     "\n5:Exit the application");
                    choice = int.Parse(Console.ReadLine());

                    // Creating a user menu

                    switch (choice)
                    {
                        case 1:
                            UtilityFunctions.AddTask(userId);
                            break;
                        case 2:
                            UtilityFunctions.GetMyTask(userId);
                            break;
                        case 3:
                            UtilityFunctions.GetUserTask(userId);
                            break;
                        case 4:
                            login = false;
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                    }
                } while (choice >= 1 && choice <= 3);
            } while (login == false);
        }
    }
}

