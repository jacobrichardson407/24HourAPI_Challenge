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
    public class ReplyController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            ReplyService replyService = CreateReplyService();
<<<<<<< HEAD
            var posts = replyService.GetReplyByCommentId(id);
=======
           var posts = replyService.GetReplyByCommentId(id);
>>>>>>> d7cbfb920a8b6bdb73b45cadc67fefa331e46d06
            return Ok(posts);
        }
        public IHttpActionResult Post(ReplyCreate reply)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateReplyService();

            if (!service.CreateReply(reply))
            {
                return InternalServerError();
            }
            return Ok();
        }
        private ReplyService CreateReplyService()
        {
            var authorId = Guid.Parse(User.Identity.GetUserId());
            var replyService = new ReplyService(authorId);
            return replyService;
        }
    }
}
