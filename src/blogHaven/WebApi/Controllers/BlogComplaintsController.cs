using Application.Features.BlogComplaints.Commands.Create;
using Application.Features.BlogComplaints.Commands.Delete;
using Application.Features.BlogComplaints.Commands.Update;
using Application.Features.BlogComplaints.Queries.GetById;
using Application.Features.BlogComplaints.Queries.GetList;
using Application.Features.BlogComplaints.Queries.GetListByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogComplaintsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBlogComplaintCommand createBlogComplaintCommand)
        {
            var result = await Mediator.Send(createBlogComplaintCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListBlogComplaintQuery getListBlogComplaintQuery = new() { PageRequest = pageRequest };
            var result = await Mediator.Send(getListBlogComplaintQuery);
            return Ok(result);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListBlogComplaintByDynamicQuery getListByDynamicModelQuery = new GetListBlogComplaintByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
            var result = await Mediator.Send(getListByDynamicModelQuery);
            return Ok(result);

        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdBlogComplaintQuery getByIdBlogComplaintQuery)
        {
            var responseBlogComplaintByIdDto = await Mediator.Send(getByIdBlogComplaintQuery);
            return Ok(responseBlogComplaintByIdDto);
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteBlogComplaintCommand deleteBlogComplaintCommand)
        {
            var responseDeleteBlogComplaintDto = await Mediator.Send(deleteBlogComplaintCommand);
            return Ok(responseDeleteBlogComplaintDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBlogComplaintCommand updateBlogComplaintCommand)
        {
            var responseUpdateCategoryDto = await Mediator.Send(updateBlogComplaintCommand);
            return Ok(responseUpdateCategoryDto);
        }
    }
}
