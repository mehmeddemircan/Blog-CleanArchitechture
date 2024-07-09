
using Application.Features.Blogs.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogsController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBlogCommand createBlogCommand)
        {
            var result = await Mediator.Send(createBlogCommand);
            return Created("", result);
        }
    }
}
