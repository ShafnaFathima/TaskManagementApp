using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Model;
using System.Linq;

namespace TaskManagement.DB

{
    public class CommentDB
    {
        private static List<Comment> _comments = new List<Comment>();
        
        public static void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        public static List<Comment> GetComments(long taskId)
        {
            var comments = _comments.Where(comment => comment.CommentToTaskId == taskId).ToList();
            return comments;
        }

        public static List<Comment> GetReplies(long commentId)
        {
            var replies = _comments.Where(comment => comment.ParentCommentId == commentId).ToList();
            return replies;
        }
    }
}
