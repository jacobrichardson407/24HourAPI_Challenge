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
    public class CommentService
    {
        private readonly Guid _authorId;
        public CommentService(Guid AuthorId)
        {
            _authorId = AuthorId;
        }
        // Create comment
        public bool CreateComment(CommentCreate model)
        {
            var entity = new Comment()
            {
                CommentId = model.CommentId,
                Text = model.Text
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CommentListItem> GetCommentsByPostId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Comments.Where(e => e.PostId == id && e.AuthorId == _authorId)
                    .Select(
                        e =>
                        new CommentListItem
                        {
                            CommentId = e.CommentId,
                            Text = e.Text
                        }
                        );
                return entity.ToArray();
            }

        }
    }
}
