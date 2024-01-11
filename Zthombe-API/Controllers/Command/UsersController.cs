using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using Zthombe.Data.Constants;
using Zthombe.Data.Models;
using Zthombe_API.Models;

namespace Zthombe_API.Controllers.Command
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

        [HttpPost]
        [ProducesResponseType(typeof(UserModel), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(IEnumerable<ValidationError>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserModel request)
        {
            if (request.Username != null && request.FirebaseUserId != null)
            {
                var user = new User()
                {
                    Username = request.Username,
                    FirebaseUserId = request.FirebaseUserId
                };

                await zthombeContext.AddAsync(user);
                var created = await zthombeContext.SaveChangesAsync();

                return Ok(created);
            }
            return BadRequest();
        }
    }
}
