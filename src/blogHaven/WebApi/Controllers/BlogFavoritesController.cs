using Application.Features.BlogFavorites.Commands.Create;
using Application.Features.BlogFavorites.Commands.Delete;
using Application.Features.BlogFavorites.Commands.Update;
using Application.Features.BlogFavorites.Queries.GetById;
using Application.Features.BlogFavorites.Queries.GetList;
using Application.Features.BlogFavorites.Queries.GetListByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogFavoritesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBlogFavoriteCommand createBlogFavoriteCommand)
        {
            var result = await Mediator.Send(createBlogFavoriteCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListBlogFavoriteQuery getListBlogFavoriteQuery = new() { PageRequest = pageRequest };
            var result = await Mediator.Send(getListBlogFavoriteQuery);
            return Ok(result);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListBlogFavoriteByDynamicQuery getListByDynamicModelQuery = new GetListBlogFavoriteByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
            var result = await Mediator.Send(getListByDynamicModelQuery);
            return Ok(result);

        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdBlogFavoriteQuery getByIdBlogFavoriteQuery)
        {
            var responseBlogFavoriteByIdDto = await Mediator.Send(getByIdBlogFavoriteQuery);
            return Ok(responseBlogFavoriteByIdDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBlogFavoriteCommand updateBlogFavoriteCommand)
        {
            var responseUpdateBlogFavoriteDto = await Mediator.Send(updateBlogFavoriteCommand);
            return Ok(responseUpdateBlogFavoriteDto);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteBlogFavoriteCommand deleteBlogFavoriteCommand)
        {
            var responseDeleteBlogFavoriteDto = await Mediator.Send(deleteBlogFavoriteCommand);
            return Ok(responseDeleteBlogFavoriteDto);
        }
    }
}
