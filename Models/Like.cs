using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagement.Models
{
    public class Like
    {
        public int UserId { get; set; }
        public long CommentId { get; set; }
        public string Reaction { get; set; } 
    }
}
