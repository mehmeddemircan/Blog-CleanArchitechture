
using Application.Features.BlogLikeDislikes.Commands.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogLikeDislikesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBlogLikeDislikeCommand createBlogLikeDislikeCommand)
        {
            var result = await Mediator.Send(createBlogLikeDislikeCommand);
            return Created("", result);
        }
    }
}
