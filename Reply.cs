using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TaskManagement
{
    public class Reply
    {
        private static List<Reply> _replies = new List<Reply>();
        public long ReplyToComment { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        private long _replyId = DateTime.UtcNow.Ticks;
        public long ReplyId
        {
            get
            {
                return _replyId;
            }
        }
        
        public static void AddReply(Reply reply)
        {
            _replies.Add(reply);
        }

        public static List<Reply> GetReplies(long commentid)
        {
            var replies = _replies.Where(reply => reply.ReplyToComment == commentid).ToList();
            return replies;
        }
    }
}
