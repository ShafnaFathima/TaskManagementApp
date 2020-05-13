using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using TaskManagement.model;
using TaskManagement.DB;

namespace TaskManagement
{
    class Program
    {
        static void Main(string[] args)
        {
           

            User newuser = new User() {Username="USER1",UserID=1,Password="user1*" };
            UserDB.AddUser(newuser);
            User newuser1 = new User() { Username = "USER2", UserID = 2, Password = "user2*" };
            UserDB.AddUser(newuser1);
            User newuser2 = new User() { Username = "USER3", UserID = 3, Password = "user3*" };
            UserDB.AddUser(newuser2);

            User user = new User();
            while(true)
            {
                Console.WriteLine("Enter your user ID");
                int userid = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter your Password");
                string password = Console.ReadLine();

                user = UserDB.ValidLogin(userid, password);
                if(user!=null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Try again!!");
                }
            }
            int Userid = user.UserID;
            char choice = 'y';
            
            while (choice.Equals('y'))
            {
                Task task = new Task();

                Console.WriteLine("enter task name");
                task.TaskName = Console.ReadLine();
                
                DateTime now = DateTime.Now;
                task.TaskId =now;
               
                int id=0;
                bool validid = false;
                while (validid == false)
                {
                    Console.WriteLine("Enter the user ID ");
                    id = int.Parse(Console.ReadLine());
                    validid = UserDB.IsValidID(id);
                }
                task.AssignedToUserID = id;
                task.AssignedByUserID = Userid;
                TaskDB.AddTask(task);
                Console.WriteLine("Do you want to continue adding tasks?(y/n)");
                choice = char.Parse(Console.ReadLine());
            }
            //get task assigned to user
            Console.WriteLine("Enter the user id whose tasks assigned are to be printed");
            int AssignedToUserId = int.Parse(Console.ReadLine());
            List<Task> tasklist = TaskDB.GetTaskAssignedTo(AssignedToUserId);
            foreach(Task task in tasklist)
            {
                Console.WriteLine("Task Name:"+task.TaskName);
                Console.WriteLine("Task ID:"+task.TaskId);
            }
           
        }
    }
}
