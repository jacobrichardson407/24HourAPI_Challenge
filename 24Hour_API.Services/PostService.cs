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
    public class PostService
    {
        private readonly Guid _authorId;
        public PostService(Guid AuthorId)
        {
            _authorId = AuthorId;
        }
        // POST(Create a Post)
        public bool CreatePost(PostCreate model)
        {
            var entity = new Post()
            {
                PostId = model.PostId,
                Title = model.Title,
                Text = model.Text
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Post.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        // GET ALL Posts
        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx

            }
        }
        // POST (Create a Comment on a Post using a Foreign Key relationship)
        // GET Comments By Post Id
        // POST(Create) a Reply to a Comment using a Foreign Key relationship
        // GET Replies By Comment Id


    }
}
