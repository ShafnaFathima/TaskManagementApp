using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TaskManagement.model;

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
           var tasksassigned = from t in tasks
                                where t.AssignedToUserID==userid
                                select t;
            return tasksassigned.ToList();

        }
    }
}
