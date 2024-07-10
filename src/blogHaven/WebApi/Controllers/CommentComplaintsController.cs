using Application.Features.CommentComplaints.Commands.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

    }
}
