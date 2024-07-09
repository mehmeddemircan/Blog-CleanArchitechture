
using Application.Features.Comments.Queries.GetById;
using Application.Features.Comments.Queries.GetList;
using Application.Features.Comments.Queries.GetListByDynamic;
using Application.Features.Comments.Commands.Create;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCommentCommand createCommentCommand)
        {
            var result = await Mediator.Send(createCommentCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListCommentQuery getListCommentQuery = new() { PageRequest = pageRequest };
            var result = await Mediator.Send(getListCommentQuery);
            return Ok(result);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListCommentByDynamicQuery getListByDynamicModelQuery = new GetListCommentByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
            var result = await Mediator.Send(getListByDynamicModelQuery);
            return Ok(result);

        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCommentQuery getByIdCommentQuery)
        {
            var responseCommentByIdDto = await Mediator.Send(getByIdCommentQuery);
            return Ok(responseCommentByIdDto);
        }
    }
}
