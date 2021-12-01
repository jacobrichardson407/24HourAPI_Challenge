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
    public class CommentController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            CommentService commentService = CreateCommentService();
            var comments = commentService.GetCommentsByPostId(id);
            return Ok(comments);
        }
        public IHttpActionResult Post(CommentCreate comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateCommentService();

            if (!service.CreateComment(comment))
            {
                return InternalServerError();
            }
            return Ok();
        }
        private CommentService CreateCommentService()
        {
            var authorId = Guid.Parse(User.Identity.GetUserId());
            var postService = new CommentService(authorId);
            return postService;
        }
    }

}
