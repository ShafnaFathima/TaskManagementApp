﻿using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.model;
using TaskManagement.DB;
using System.Linq;

namespace TaskManagement
{
    public class Comment
    {
        private static List<Comment> Comments = new List<Comment>();
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public long CommentToTaskId { get; set; }
        private long _commentId = DateTime.UtcNow.Ticks;
        public long CommentId
        {
            get
            {
                return _commentId;

            }
        }
         public static void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public static List<Comment> GetComments(long taskid)
        {
            var comments = Comments.Where(comment => comment.CommentToTaskId == taskid).ToList();
            return comments;
        }
    }
}
