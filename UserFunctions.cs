using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.model;
using TaskManagement.DB;

namespace TaskManagement
{
   public class UserFunctions
    {
        public static void AddTaskMethod(int Userid)
        {
            char choice = 'y';

            while (choice.Equals('y'))
            {
                model.Task task = new model.Task();

                Console.WriteLine("enter task name");
                task.TaskName = Console.ReadLine();
                int id = 0;
                bool validid = false;
                while (validid == false)
                {
                    Console.WriteLine("Enter a valid user ID ");
                    id = int.Parse(Console.ReadLine());
                    validid = UserDB.IsValidID(id);
                }
                task.AssignedToUserID = id;
                task.AssignedByUserID = Userid;
                TaskDB.AddTask(task);
                Console.WriteLine("Do you want to continue adding tasks?(y/n)");
                choice = char.Parse(Console.ReadLine());
            }
        }

       public static void GetUserTaskMethod()
        {
            bool validid = false;
            int AssignedToUserId = 0;
            while (validid == false)
            {
                Console.WriteLine("Enter a valid user id whose tasks assigned are to be printed");
                AssignedToUserId = int.Parse(Console.ReadLine());
                validid = UserDB.IsValidID(AssignedToUserId);
            }
            
            List<model.Task> tasklist = TaskDB.GetTaskAssignedTo(AssignedToUserId);
            if (tasklist.Count == 0)
            {
                Console.WriteLine("No tasks have been assigned to this user");
            }
            else
            {
                foreach (model.Task task in tasklist)
                {
                    Console.WriteLine("Task Name:" + task.TaskName);
                    Console.WriteLine("Task ID:" + task.TaskId);
                }
            }
        }

       public static void MyCurrentTaskMethod(int Userid)
        {
            List<model.Task> myTasklist = TaskDB.GetMyCurrentTasks(Userid);
            if (myTasklist.Count == 0)
            {
                Console.WriteLine("No tasks have been assigned");
            }
            else
            {
                foreach (model.Task task in myTasklist)
                {
                    Console.WriteLine("Task Name:" + task.TaskName);
                    Console.WriteLine("Task ID:" + task.TaskId);
                    Console.WriteLine("Assigned by:" + task.AssignedByUserID);
                }
            }
        }

    }
}
