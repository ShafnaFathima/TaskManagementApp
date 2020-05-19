using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models;
using TaskManagement.DB;
using System.Xml;

namespace TaskManagement.Util
{
    public class UserFunctions
    {
        public static void AddTask(int userId)
        {
            char choice = 'y';

            while (choice.Equals('y'))
            {
                Models.Task task = new Models.Task();

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
                task.AssignedByUserID = userId;
                TaskDB.AddTask(task);
                Console.WriteLine("Do you want to continue adding tasks?(y/n)");
                choice = char.Parse(Console.ReadLine());
            }
        }

        // Author is the one who comments and replies

        private static int _authorId;
        public static void GetUserTask(int myId)
        {
            bool validId = false;
            int assignedToUserId = 0;

            while (validId == false)
            {
                Console.WriteLine("Enter a valid user id whose tasks assigned are to be printed");
                assignedToUserId = int.Parse(Console.ReadLine());
                validId = UserDB.IsValidID(assignedToUserId);
            }

            _authorId = myId;
            UserFunctions.GetTask(assignedToUserId);
        }

        public static void GetMyTask(int myId)
        {
            _authorId = myId;
            UserFunctions.GetTask(myId);
        }

        // Prints tasks,comments and replies
        public static void GetTask(int userId)
        {

            List<Models.Task> MyTasklist = TaskDB.GetTaskAssignedTo(userId);

            if (MyTasklist.Count == 0)
            {
                Console.WriteLine("\nNo tasks have been assigned");
            }
            else
            {
                foreach (Models.Task task in MyTasklist)
                {
                    Console.WriteLine("\nTask Name:" + task.TaskName);
                    Console.WriteLine("Task ID:" + task.TaskId);
                    int assignedByUserID = task.AssignedByUserID;
                    string assignedByUserName = UserDB.GetUserName(assignedByUserID);
                    Console.WriteLine("Assigned by:" + assignedByUserName);
                    List<Comment> commentList = new List<Comment>();
                    commentList = CommentDB.GetComments(task.TaskId);

                    if (commentList.Count == 0)
                    {
                        Console.WriteLine("\nThere are no comments for this task!");
                    }
                    else
                    {
                        foreach (Comment comment in commentList)
                        {
                            string authorName = UserDB.GetUserName(comment.AuthorId);
                            Console.WriteLine("\nComment:" + comment.Content +
                                              "\nCommented By :" + authorName);
                            List<Comment> replyList = new List<Comment>();
                            replyList = CommentDB.GetReplies(comment.CommentId);

                            if (replyList.Count == 0)
                            {
                                Console.WriteLine("\nThere are no replies for this comment!");
                            }
                            else
                            {
                                foreach (Comment reply in replyList)
                                {
                                    string authorname = UserDB.GetUserName(reply.AuthorId);
                                    Console.WriteLine("\nReply:" + reply.Content +
                                        "\nReplied by: " + authorname);
                                }
                            }

                            char replyChoice = 'y';
                            while (replyChoice == 'y')
                            {
                                Console.WriteLine("Do you want to reply?(y/n)");
                                replyChoice = char.Parse(Console.ReadLine());
                                if (replyChoice == 'n')
                                {
                                    break;
                                }

                                UserFunctions.AddReplyMethod(comment.CommentId);
                            }
                        }
                    }

                    char commentChoice = 'y';
                    while (commentChoice == 'y')
                    {
                        Console.WriteLine("\nDo you want to add a comment?(y/n)");
                        commentChoice = char.Parse(Console.ReadLine());

                        if (commentChoice == 'n')
                        {
                            break;
                        }

                        UserFunctions.AddCommentMethod(task.TaskId);
                    }
                }
            }
        }

        public static void AddCommentMethod(long taskId)
        {
            Comment comment = new Comment();
            comment.AuthorId = _authorId;
            comment.ParentCommentId = 0;
            comment.CommentToTaskId = taskId;
            Console.WriteLine("Enter your comment");
            comment.Content = Console.ReadLine();
            Console.WriteLine("\nCommented Successfully!");
            CommentDB.AddComment(comment);
        }

        public static void AddReplyMethod(long parentCommentId)
        {
            Comment reply = new Comment();
            reply.AuthorId = _authorId;
            reply.ParentCommentId = parentCommentId;
            reply.CommentToTaskId = 0;
            Console.WriteLine("Enter your reply");
            reply.Content = Console.ReadLine();
            Console.WriteLine("\nReplied Successfully!");
            CommentDB.AddComment(reply);
        }
    }
}
