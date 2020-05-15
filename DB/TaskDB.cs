using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TaskManagement.model;
using System.Runtime.CompilerServices;
using System.ComponentModel.Design;

namespace TaskManagement.DB

{
    public class TaskDB
    {
        private static List<Task> tasks = new List<Task>();
        public static void AddTask(Task task)
        {
            tasks.Add(task);
        }
        public static List<Task> GetTaskAssignedTo(int userid)
        {
            var tasksassigned = tasks.Where(t => t.AssignedToUserID==userid).ToList();
            return tasksassigned;
        }
        public static List<Task> GetMyCurrentTasks(int myid)
        {
            var myCurrentTasks = tasks.Where(t => t.AssignedToUserID == myid).ToList();
            return myCurrentTasks;
        }
    }
}
