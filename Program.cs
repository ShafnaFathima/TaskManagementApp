using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using TaskManagement.model;
using TaskManagement.DB;
using System.Dynamic;

namespace TaskManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            User newuser = new User() { Username = "USER1", UserID = 1, Password = "user1*" };
            UserDB.AddUser(newuser);
            User newuser1 = new User() { Username = "USER2", UserID = 2, Password = "user2*" };
            UserDB.AddUser(newuser1);
            User newuser2 = new User() { Username = "USER3", UserID = 3, Password = "user3*" };
            UserDB.AddUser(newuser2);
            //come here again after logout
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

                int Userid = user.UserID;
                int todo;
                do
                {
                    Console.WriteLine("\nEnter your option " +
                     "\n1:AddTask" +
                     "\n2:List tasks assigned to me " +
                     "\n3:List tasks assigned to a user" +
                     "\n4:Logout and Login as new user" +
                     "\n5:Exit the application");
                    todo = int.Parse(Console.ReadLine());
                    /*creating a user menu*/
                    switch (todo)
                    {

                        case 1:
                            UserFunctions.AddTaskMethod(Userid);
                            break;
                        case 2:
                            bool isTaskAssigned = UserFunctions.MyCurrentTaskMethod(Userid);
                            char choice = 'y';
                            while (isTaskAssigned == true && choice == 'y')
                            {
                                Console.WriteLine("\nDo you want to add a comment?(y/n)");
                                choice = char.Parse(Console.ReadLine());
                                if (choice == 'y')
                                {
                                    UserFunctions.AddCommentMethod(Userid);

                                }
                            }
                            break;
                        case 3:
                            bool isTaskassigned = UserFunctions.GetUserTaskMethod();
                            char userchoice = 'y';
                            while (isTaskassigned == true && userchoice == 'y')
                            {
                                Console.WriteLine("\nDo you want to add a comment?(y/n)");
                                userchoice = char.Parse(Console.ReadLine());
                                if (userchoice == 'y')
                                {
                                    UserFunctions.AddCommentMethod(Userid);

                                }
                            }
                            break;
                        case 4:
                            login = false;
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                    }
                } while (todo >= 1 && todo <= 3);
            } while (login == false);
        }
    }
}

