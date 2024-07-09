using Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Application.Features.UserOperationClaims.Commands;
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
        public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
        {
            var result = await Mediator.Send(createUserOperationClaimCommand);
            return Created("", result);
        }

    }
}
