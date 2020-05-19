using System;
using System.Collections.Generic;
using System.Text;


namespace TaskManagement.Models
{
    public class Comment
    {
        private readonly long _CommentId = DateTime.UtcNow.Ticks;
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public long CommentToTaskId { get; set; }
        public long ParentCommentId { get; set; }

        public long CommentId
        {
            get
            {
                return _CommentId;
            }
        }
    }
}
