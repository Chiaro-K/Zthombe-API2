using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zthombe_API.Models;

namespace Zthombe_API.Controllers.Query
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        protected readonly ZthombeContext zthombeContext;

        public UsersController(ZthombeContext zthombeContext)
        {
            this.zthombeContext = zthombeContext;
        }

        [Route("{userId}")]
        [HttpGet]
        public IActionResult GetUser(Guid userId)
        {
            //Create View Model
            //Create mapping profile
            //Only return count of posts

            var user = zthombeContext.Users
                .Include(u => u.Posts)
                .Where(p => p.UserId == userId).FirstOrDefault();
            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest();
        }

        [Route("firebaseUser/{fireId}")]
        [HttpGet]
        public IActionResult GetUserByFireId(string fireId)
        {
            var user = zthombeContext.Users.Where(p => p.FirebaseUserId == fireId).FirstOrDefault();

            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest();
        }
    }
}
