using _24Hour_API.Models;
using _24Hour_API.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24Hour_API.WebAPI.Controllers
{
    [Authorize]
    public class PostController : ApiController
    {
        public IHttpActionResult Get()
        {
            PostService postService = CreatePostService();
            var posts = postService.GetPosts();
            return Ok(posts);
        }
        public IHttpActionResult Post(PostCreate post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreatePostService();

            if (!service.CreatePost(post))
            {
                return InternalServerError();
            }
            return Ok();
        }
        private PostService CreatePostService()
        {
            var authorId = Guid.Parse(User.Identity.GetUserId());
            var postService = new PostService(authorId);
            return postService;
        }
    }
}
