

using Application.Features.Users.Commands.Delete;
using Application.Features.Users.Queries.GetById;
using Application.Features.Users.Queries.GetList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListUserQuery getListUserQuery = new() { PageRequest = pageRequest };
            var result = await Mediator.Send(getListUserQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdUserQuery getByIdUserQuery)
        {
            var responseUserByIdDto = await Mediator.Send(getByIdUserQuery);
            return Ok(responseUserByIdDto);
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserCommand deleteUserCommand)
        {
            var responseDeleteUserDto = await Mediator.Send(deleteUserCommand);
            return Ok(responseDeleteUserDto);
        }

    }
}
