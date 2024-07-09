using Application.Features.ContactUsMessages.Commands.Create;
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

    }
}
