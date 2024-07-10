using Application.Features.CommentLikeDislikes.Commands.Create;
using Application.Features.CommentLikeDislikes.Commands.Delete;
using Application.Features.CommentLikeDislikes.Commands.Update;
using Application.Features.CommentLikeDislikes.Queries.GetById;
using Application.Features.CommentLikeDislikes.Queries.GetList;
using Application.Features.CommentLikeDislikes.Queries.GetListByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentLikeDislikesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCommentLikeDislikeCommand createCommentLikeDislikeCommand)
        {
            var result = await Mediator.Send(createCommentLikeDislikeCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListCommentLikeDislikeQuery getListCommentLikeDislikeQuery = new() { PageRequest = pageRequest };
            var result = await Mediator.Send(getListCommentLikeDislikeQuery);
            return Ok(result);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListCommentLikeDislikeByDynamicQuery getListByDynamicModelQuery = new GetListCommentLikeDislikeByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
            var result = await Mediator.Send(getListByDynamicModelQuery);
            return Ok(result);

        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCommentLikeDislikeQuery getByIdCommentLikeDislikeQuery)
        {
            var responseCommentLikeDislikeByIdDto = await Mediator.Send(getByIdCommentLikeDislikeQuery);
            return Ok(responseCommentLikeDislikeByIdDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCommentLikeDislikeCommand updateCommentLikeDislikeCommand)
        {
            var responseUpdateCommentLikeDislikeDto = await Mediator.Send(updateCommentLikeDislikeCommand);
            return Ok(responseUpdateCommentLikeDislikeDto);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCommentLikeDislikeCommand deleteCommentLikeDislikeCommand)
        {
            var responseDeleteCommentLikeDislikeDto = await Mediator.Send(deleteCommentLikeDislikeCommand);
            return Ok(responseDeleteCommentLikeDislikeDto);
        }

    }
}
