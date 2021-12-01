using _24Hour_API.Data;
using _24Hour_API.Models;
using _24Hour_API.WebAPI.Models;
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
            }

        }
    }
}
