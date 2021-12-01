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
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        // GET ALL Posts
        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Posts.Where(e => e.AuthorId == _authorId)
                    .Select(
                        e =>
                        new PostListItem
                        {
                            PostId = e.PostId,
                            Title = e.Title
                        }
                        );
                return query.ToArray();
            }



        }
    }
}
