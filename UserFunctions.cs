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

        public static bool GetUserTaskMethod()
        {
            bool validid = false;
            int assignedToUserId = 0;
            while (validid == false)
            {
                Console.WriteLine("Enter a valid user id whose tasks assigned are to be printed");
                assignedToUserId = int.Parse(Console.ReadLine());
                validid = UserDB.IsValidID(assignedToUserId);
            }

            List<model.Task> tasklist = TaskDB.GetTaskAssignedTo(assignedToUserId);

            if (tasklist.Count == 0)
            {
                Console.WriteLine("\nNo tasks have been assigned to this user");
                return false;
            }
            else
            {
                foreach (model.Task task in tasklist)
                {
                    Console.WriteLine("\nTask Name:" + task.TaskName);
                    Console.WriteLine("Task ID:" + task.TaskId);
                    List<Comment> comments = new List<Comment>();
                    comments = Comment.GetComments(task.TaskId);
                    if (comments.Count == 0)
                    {
                        Console.WriteLine("\nThere are no comments for this task!");
                    }
                    else
                    {
                        foreach (Comment comment in comments)
                        {
                            string authorName = UserDB.GetUserName(comment.AuthorId);
                            Console.WriteLine("\nComment:" +
                                    "\nCommentID: " + comment.CommentId +
                                    "\nCommented By :" + authorName +
                                    "\n" + comment.Content);
                        }
                    }
                }
            }
            return true;
        }

        public static bool MyCurrentTaskMethod(int Userid)
        {
            List<model.Task> MyTasklist = TaskDB.GetMyCurrentTasks(Userid);
            if (MyTasklist.Count == 0)
            {
                Console.WriteLine("\nNo tasks have been assigned");
                return false;
            }
            else
            {
                foreach (model.Task task in MyTasklist)
                {
                    Console.WriteLine("\nTask Name:" + task.TaskName);
                    Console.WriteLine("Task ID:" + task.TaskId);
                    int assignedByUserID = task.AssignedByUserID;
                    string assignedByUserName = UserDB.GetUserName(assignedByUserID);
                    Console.WriteLine("Assigned by:" + assignedByUserName);
                    List<Comment> comments = new List<Comment>();
                    comments = Comment.GetComments(task.TaskId);
                    if (comments.Count == 0)
                    {
                        Console.WriteLine("\nThere are no comments for this task!");
                    }
                    else
                    {
                        foreach (Comment comment in comments)
                        {
                            string authorName = UserDB.GetUserName(comment.AuthorId);
                            Console.WriteLine("Comment:" +
                                              "\nCommentID: " + comment.CommentId +
                                              "\nCommented By :" + authorName +
                                              "\n" + comment.Content);
                        }
                    }
                }
            }return true;
        }

        public static void AddCommentMethod(int Userid)
        {
            Comment comment = new Comment();
            Console.WriteLine("Which task do you want to comment?");
            comment.CommentToTaskId = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter your comment");
            comment.Content = Console.ReadLine();
            comment.AuthorId = Userid;
            Console.WriteLine("Commented Successfully!");
            Comment.AddComment(comment);
        }
    }
}
