using Application.Features.CommentComplaints.Commands.Delete;
using Application.Features.CommentComplaints.Commands.Update;
using Application.Features.CommentComplaints.Queries.GetById;
using Application.Features.CommentComplaints.Queries.GetList;

using Application.Features.CommentComplaints.Commands.Create;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Features.CommentComplaints.Queries.GetListByDynamic;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentComplaintsController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCommentComplaintCommand createCommentComplaintCommand)
        {
            var result = await Mediator.Send(createCommentComplaintCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListCommentComplaintQuery getListCommentComplaintQuery = new() { PageRequest = pageRequest };
            var result = await Mediator.Send(getListCommentComplaintQuery);
            return Ok(result);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListCommentComplaintByDynamicQuery getListByDynamicModelQuery = new GetListCommentComplaintByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
            var result = await Mediator.Send(getListByDynamicModelQuery);
            return Ok(result);

        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCommentComplaintQuery getByIdCommentComplaintQuery)
        {
            var responseCommentComplaintByIdDto = await Mediator.Send(getByIdCommentComplaintQuery);
            return Ok(responseCommentComplaintByIdDto);
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCommentComplaintCommand deleteCommentComplaintCommand)
        {
            var responseDeleteCommentComplaintDto = await Mediator.Send(deleteCommentComplaintCommand);
            return Ok(responseDeleteCommentComplaintDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCommentComplaintCommand updateCommentComplaintCommand)
        {
            var responseUpdateCategoryDto = await Mediator.Send(updateCommentComplaintCommand);
            return Ok(responseUpdateCategoryDto);
        }

    }
}
