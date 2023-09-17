using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zthombe_API.Models;

namespace Zthombe_API.Controllers.Query
{
    [Route("api/[controller]")]
    [ApiController]
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
            var user = zthombeContext.Users.Where(p => p.UserId == userId).FirstOrDefault();
            return Ok(user);
        }
    }
}
