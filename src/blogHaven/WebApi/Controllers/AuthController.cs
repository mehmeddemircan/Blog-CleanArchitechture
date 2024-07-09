using Application.Features.Auth.Commands.Register;
using Application.Features.Auths.Commands.Login;
using Application.Features.Auths.Dtos;
using Application.Features.UserOperationClaims.Commands.Create;
using Core.Security.Dtos;
using Core.Security.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisterCommand registerCommand = new()
            {
                UserForRegisterDto = userForRegisterDto,
                IpAddress = GetIpAddress()
            };

            var registerResult = await Mediator.Send(registerCommand);

            // Kullanıcı kaydından sonra rol ekleme komutunu oluştur
            CreateUserOperationClaimCommand createUserOperationClaimCommand = new()
            {
                UserId = registerResult.RefreshToken.UserId ,
                OperationClaimId = 2  // User Role
            };

            // Rol ekleme komutunu gönder
            var roleResult = await Mediator.Send(createUserOperationClaimCommand);

            SetRefreshTokenToCookie(registerResult.RefreshToken);
            return Created("", registerResult.AccessToken);
        }

        private void SetRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.Now.AddDays(7) };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            LoginCommand loginCommand = new() { UserForLoginDto = userForLoginDto, IpAddress = GetIpAddress() };
            var result = await Mediator.Send(loginCommand);

            if (result.RefreshToken is not null)
                SetRefreshTokenToCookie(result.RefreshToken);

            return Ok(result.ToHttpResponse());
        }
    }
}
