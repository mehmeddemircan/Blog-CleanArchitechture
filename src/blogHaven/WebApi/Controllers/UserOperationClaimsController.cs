
using Application.Features.OperationClaims.Commands.CreateOperationClaim;

using Application.Features.UserOperationClaims.Commands.Create;
using Application.Features.UserOperationClaims.Commands.Delete;
using Application.Features.UserOperationClaims.Commands.Update;
using Application.Features.UserOperationClaims.Queries.GetById;
using Application.Features.UserOperationClaims.Queries.GetList;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserOperationClaimsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> AddRoleToUser([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
        {
            var result = await Mediator.Send(createUserOperationClaimCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListUserOperationClaimQuery getListUserOperationClaimQuery = new() { PageRequest = pageRequest };
            var result = await Mediator.Send(getListUserOperationClaimQuery);
            return Ok(result);
        }



        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdUserOperationClaimQuery getByIdUserOperationClaimQuery)
        {
            var responseUserOperationClaimByIdDto = await Mediator.Send(getByIdUserOperationClaimQuery);
            return Ok(responseUserOperationClaimByIdDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRoleOfUser([FromBody] UpdateUserOperationClaimCommand updateUserOperationClaimCommand)
        {
            var responseUpdateUserOperationClaimDto = await Mediator.Send(updateUserOperationClaimCommand);
            return Ok(responseUpdateUserOperationClaimDto);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveRoleOfUser([FromRoute] DeleteUserOperationClaimCommand deleteUserOperationClaimCommand)
        {
            var responseDeleteUserOperationClaimDto = await Mediator.Send(deleteUserOperationClaimCommand);
            return Ok(responseDeleteUserOperationClaimDto);
        }
    }
}
