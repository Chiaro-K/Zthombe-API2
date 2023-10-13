using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using Zthombe.Data.Constants;
using Zthombe_API.Models;

namespace Zthombe_API.Controllers.Command
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
    }
}
