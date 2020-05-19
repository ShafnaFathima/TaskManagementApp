using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TaskManagement.Models;
using System.Runtime.CompilerServices;
using System.ComponentModel.Design;

namespace TaskManagement.DB

{
    public class TaskDB
    {
        private static List<Task> _tasks = new List<Task>();

        public static void AddTask(Task task)
        {
            _tasks.Add(task);
        }

        public static List<Task> GetTaskAssignedTo(int userId)
        {
            var tasksAssigned = _tasks.Where(t => t.AssignedToUserID == userId).ToList();
            return tasksAssigned;
        }
    }
}
