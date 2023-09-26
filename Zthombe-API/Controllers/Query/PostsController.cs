﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
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

        [Route("getPosts/{postType}")]
        [HttpGet]
        public IActionResult GetPosts(string postType)
        {
            switch (postType)
            {
                case "Trending":
                    return Ok(zthombeContext.Posts.OrderByDescending(o => o.ViewCount).ToList());
                case "Recent":
                    return Ok(zthombeContext.Posts.OrderByDescending(o => o.DateCreated).ToList());
                case "Gifs":
                    return Ok(zthombeContext.Posts.Where(p => p.PostType == (int)PostType.Gifs));
                case "Videos":
                    return Ok(zthombeContext.Posts.Where(p => p.PostType == (int)PostType.Videos));
            }
            return BadRequest();
        }

        [Route("getUserUploads/{fireId}")]
        [HttpGet]
        public IActionResult GetUserUploads(string fireId)
        {
            var posts = zthombeContext.Posts.Include(i => i.User)
                .Where(p => p.User.FirebaseUserId == fireId).ToList();
            return Ok(posts);
        }

        [Route("{postId}")]
        [HttpGet]
        public IActionResult GetPost(Guid postId)
        {
            var post = zthombeContext.Posts.Where(p => p.PostId == postId).FirstOrDefault();
            return Ok(post);
        }

        [Route("postTypes")]
        [HttpGet]
        public IActionResult GetPostTypes()
        {
            return Ok(Enum.GetValues(typeof(PostType)).Cast<PostType>().ToList());
        }
    }
}
