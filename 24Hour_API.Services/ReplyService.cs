using _24Hour_API.Data;
using _24Hour_API.Models;
using _24Hour_API.WebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour_API.Services
{
    public class ReplyService
    {
        private readonly Guid _authorId;
        public ReplyService(Guid AuthorId)
        {
            _authorId = AuthorId;
        }
        // Create reply
        public bool CreateReply(ReplyCreate model)
        {
            var entity = new Reply()
            {
                ReplyId = model.ReplyId,
                Text = model.Text
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
<<<<<<< HEAD
        //Get reply by comment id
        public IEnumerable<ReplyListItem> GetReplyByCommentId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Replies.Where(e => e.CommentId == id && e.AuthorId == _authorId)
                    .Select(
                        e =>
                        new ReplyListItem
                        {
                            ReplyId = e.ReplyId,
                            Text = e.Text
                        }
                        );
                return entity.ToArray();
=======
        // Get reply by comment id
        public IEnumerable<ReplyListItem> GetReplyByCommentId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Replies.Where(e => e.CommentId == id && e.AuthorId == _authorId)
                    .Select(
                        e =>
                        new ReplyListItem
                        {
                            ReplyId = e.ReplyId,
                            Text = e.Text
                        }
                        );
<<<<<<< HEAD
                return entity.ToArray();
=======
                return query.ToArray();
>>>>>>> a72c1098c3df45f5706a25666688c216359e845d
>>>>>>> d7cbfb920a8b6bdb73b45cadc67fefa331e46d06
            }

        }
    }
}
