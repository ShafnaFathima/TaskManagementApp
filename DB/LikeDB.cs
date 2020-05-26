using System.Collections.Generic;
using System.Linq;
using TaskManagement.Models;

namespace TaskManagement.DB
{
    public class LikeDB
    {
        private static List<Like> _likeList = new List<Like>();

        public static void AddLike(Like like)
        {
            _likeList.Add(like);
        }

        public static void RemoveLike(Like like)
        {
            _likeList.Remove(like);
        }

        public static List<Like> CountReactions(long commentId)
        {
            return _likeList.Where(like => like.CommentId == commentId).ToList();
        }

        public static Like HasUserLiked(long commentId, int userId)
        {
            return _likeList.FirstOrDefault(like => like.CommentId == commentId && like.UserId == userId);
        }
    }
}
