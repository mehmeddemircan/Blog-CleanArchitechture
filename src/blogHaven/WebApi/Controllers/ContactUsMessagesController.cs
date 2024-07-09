
using Application.Features.ContactUsMessages.Commands.Create;
using Application.Features.ContactUsMessages.Queries.GetById;
using Application.Features.ContactUsMessages.Queries.GetList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactUsMessagesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateContactUsMessageCommand createContactUsMessageCommand)
        {
            var result = await Mediator.Send(createContactUsMessageCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListContactUsMessageQuery getListContactUsMessageQuery = new() { PageRequest = pageRequest };
            var result = await Mediator.Send(getListContactUsMessageQuery);
            return Ok(result);
        }



        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdContactUsMessageQuery getByIdContactUsMessageQuery)
        {
            var responseContactUsMessageByIdDto = await Mediator.Send(getByIdContactUsMessageQuery);
            return Ok(responseContactUsMessageByIdDto);
        }

    }
}
