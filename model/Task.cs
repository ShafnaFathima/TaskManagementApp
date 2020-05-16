using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagement.model
{
    public class Task
    {
        public string TaskName { get; set; }
        public int AssignedToUserID { get; set; }
        public int AssignedByUserID { get; set; }
 
        private long _taskId = DateTime.Now.Ticks;
        public long TaskId
        {
            get
            {
                return _taskId;
            }
        }
    }
}
