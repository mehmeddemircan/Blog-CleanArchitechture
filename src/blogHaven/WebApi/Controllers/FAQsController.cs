using Application.Features.FAQs.Commands.Create;
using Application.Features.FAQs.Commands.Delete;
using Application.Features.FAQs.Commands.Update;
using Application.Features.FAQs.Queries.GetById;
using Application.Features.FAQs.Queries.GetList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FAQsController : BaseController
    {



        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateFAQCommand createFAQCommand)
        {
            var result = await Mediator.Send(createFAQCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListFAQQuery getListFAQQuery = new() { PageRequest = pageRequest };
            var result = await Mediator.Send(getListFAQQuery);
            return Ok(result);
        }



        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdFAQQuery getByIdFAQQuery)
        {
            var responseFAQByIdDto = await Mediator.Send(getByIdFAQQuery);
            return Ok(responseFAQByIdDto);
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteFAQCommand deleteFAQCommand)
        {
            var responseDeleteFAQDto = await Mediator.Send(deleteFAQCommand);
            return Ok(responseDeleteFAQDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFAQCommand updateFAQCommand)
        {
            var responseUpdateCategoryDto = await Mediator.Send(updateFAQCommand);
            return Ok(responseUpdateCategoryDto);
        }

    }
}
