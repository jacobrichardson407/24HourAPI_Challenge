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
        // Get comment by post id
        //public IEnumerable<CommentListItem> GetCommentsByPostId()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query =
        //            ctx
        //            .Comments.Where(e =>  e.AuthorId == _authorId)
        //            .Select(
        //                e =>
        //                new CommentListItem
        //                {
        //                    PostId = e.PostId,
        //                    Title = e.Title
        //                }
        //                );
        //        return query.ToArray();
        //    }

        //}
    }
}
