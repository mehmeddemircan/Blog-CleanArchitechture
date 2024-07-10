
using Application.Features.BlogLikeDislikes.Commands.Create;
using Application.Features.BlogLikeDislikes.Commands.Delete;
using Application.Features.BlogLikeDislikes.Commands.Update;
using Application.Features.BlogLikeDislikes.Queries.GetById;
using Application.Features.BlogLikeDislikes.Queries.GetList;

using Application.Features.BlogLikeDislikes.Queries.GetListByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
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

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListBlogLikeDislikeQuery getListBlogLikeDislikeQuery = new() { PageRequest = pageRequest };
            var result = await Mediator.Send(getListBlogLikeDislikeQuery);
            return Ok(result);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListBlogLikeDislikeByDynamicQuery getListByDynamicModelQuery = new GetListBlogLikeDislikeByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
            var result = await Mediator.Send(getListByDynamicModelQuery);
            return Ok(result);

        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdBlogLikeDislikeQuery getByIdBlogLikeDislikeQuery)
        {
            var responseBlogLikeDislikeByIdDto = await Mediator.Send(getByIdBlogLikeDislikeQuery);
            return Ok(responseBlogLikeDislikeByIdDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBlogLikeDislikeCommand updateBlogLikeDislikeCommand)
        {
            var responseUpdateBlogLikeDislikeDto = await Mediator.Send(updateBlogLikeDislikeCommand);
            return Ok(responseUpdateBlogLikeDislikeDto);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteBlogLikeDislikeCommand deleteBlogLikeDislikeCommand)
        {
            var responseDeleteBlogLikeDislikeDto = await Mediator.Send(deleteBlogLikeDislikeCommand);
            return Ok(responseDeleteBlogLikeDislikeDto);
        }
    }
}
