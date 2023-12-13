using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Numerics;
using Zthombe.Data.Models;
using Zthombe_API.Models;

namespace Zthombe_API.Controllers.Command
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

        [HttpPost]
        [ProducesResponseType(typeof(PostModel), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(IEnumerable<ValidationError>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostModel request)
        {
            if (request.Title != null)
            {
                var post = new Post()
                {
                    Title = request.Title,
                    Description = request.Description,
                    ImageUrl = request.ImageUrl,
                    UserId = request.UserId,
                };

                await zthombeContext.AddAsync(post);
                var created = await zthombeContext.SaveChangesAsync();

                return Ok(created);
            }
            return BadRequest();
        }
        [Route("increment-view-count")]
        [HttpPatch]
        [ProducesResponseType(typeof(PostModel), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(IEnumerable<ValidationError>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> IncrementViewCount([FromBody] PatchPostModel request)
        {
            var post = zthombeContext.Posts.Where(p => p.PostId == request.PostId).FirstOrDefault();

            if (post != null)
            {
                post.ViewCount += 1;
                var updated = await zthombeContext.SaveChangesAsync();

                return Ok(updated);
            }
            return BadRequest();
        }

        [Route("save-post")]
        [HttpPost]
        [ProducesResponseType(typeof(PostModel), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(IEnumerable<ValidationError>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SavePost([FromBody] SavePostModel request)
        {
            var savedPost = new SavedPosts()
            {
                PostId = request.PostId,
                UserId = request.UserId
            };
            await zthombeContext.AddAsync(savedPost);

            var created = await zthombeContext.SaveChangesAsync();

            if (created > 0)
            {
                return Ok(created);
            }
            return BadRequest();
        }

        [Route("unsave-post")]
        [HttpDelete]
        [ProducesResponseType(typeof(PostModel), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(IEnumerable<ValidationError>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UnsavePost([FromBody] SavePostModel request)
        {
            var savedPost = await zthombeContext.SavedPosts.Where(p => p.PostId == request.PostId && p.UserId == request.UserId).FirstOrDefaultAsync();
            if (savedPost != null)
            {
                zthombeContext.Remove(savedPost);
            }

            var removed = await zthombeContext.SaveChangesAsync();

            if (removed > 0)
            {
                return Ok(removed);
            }
            return BadRequest();
        }
    }
}
