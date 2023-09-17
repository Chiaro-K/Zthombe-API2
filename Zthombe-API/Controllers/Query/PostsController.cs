using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zthombe.Data.Constants;
using Zthombe_API.Models;

namespace Zthombe_API.Controllers.Query
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        protected readonly ZthombeContext zthombeContext;

        public PostsController(ZthombeContext zthombeContext)
        {
            this.zthombeContext = zthombeContext;
        }

        [Route("GetPosts/{userId}")]
        [HttpGet]
        public IActionResult GetPosts(Guid userId)
        {
            var posts = zthombeContext.Posts.Where(p => p.UserId == userId).ToList();
            return Ok(posts);
        }

        [Route("{postId}")]
        [HttpGet]
        public IActionResult GetPost(Guid postId)
        {
            var post = zthombeContext.Posts.Where(p => p.PostId == postId).FirstOrDefault();
            return Ok(post);
        }
    }
}
