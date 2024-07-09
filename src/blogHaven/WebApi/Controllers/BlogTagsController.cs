
using Application.Features.BlogTags.Commands.Create;
using Application.Features.BlogTags.Commands.Delete;
using Application.Features.BlogTags.Commands.Update;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogTagsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> AddTagToBlog([FromBody] CreateBlogTagCommand createBlogTagCommand)
        {
            var result = await Mediator.Send(createBlogTagCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBlogTagCommand updateBlogTagCommand)
        {
            var responseUpdateBlogTagDto = await Mediator.Send(updateBlogTagCommand);
            return Ok(responseUpdateBlogTagDto);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveTagFromBlog([FromRoute] DeleteBlogTagCommand deleteBlogTagCommand)
        {
            var responseDeleteBlogTagDto = await Mediator.Send(deleteBlogTagCommand);
            return Ok(responseDeleteBlogTagDto);
        }
    }
}
