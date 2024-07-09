
using Application.Features.Comments.Queries.GetById;
using Application.Features.Comments.Queries.GetList;
using Application.Features.Comments.Queries.GetListByDynamic;
using Application.Features.Comments.Commands.Create;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Comments.Commands.Delete;
using Application.Features.Comments.Commands.Update;
using Application.Features.Comments.Queries.GetListByParentId;
using Application.Features.Comments.Queries.GetListByBlogId;

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

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCommentCommand deleteCommentCommand)
        {
            var responseDeleteCommentDto = await Mediator.Send(deleteCommentCommand);
            return Ok(responseDeleteCommentDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCommentCommand updateCommentCommand)
        {
            var responseUpdateCommentDto = await Mediator.Send(updateCommentCommand);
            return Ok(responseUpdateCommentDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetRepliesOfComment(int? parentId, [FromQuery] PageRequest pageRequest)
        {
            GetListCommentByParentIdQuery getListCommentQuery = new() { ParentId = parentId, PageRequest = pageRequest };
            var result = await Mediator.Send(getListCommentQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetListCommentByBlog(int BlogId ,[FromQuery] PageRequest pageRequest)
        {
            GetListCommentByBlogIdQuery getListCommenByBlogIdQuery = new() {BlogId = BlogId ,  PageRequest = pageRequest };
            var result = await Mediator.Send(getListCommenByBlogIdQuery);
            return Ok(result);
        }
    }
}
