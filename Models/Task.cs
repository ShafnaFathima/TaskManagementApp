using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagement.Models
{
    public class Task
    {
        private readonly long _TaskId = DateTime.Now.Ticks;
        public string TaskName { get; set; }
        public int AssignedToUserID { get; set; }
        public int AssignedByUserID { get; set; }
        public long TaskId
        {
            get
            {
                return _TaskId;
            }
        }
    }
}
