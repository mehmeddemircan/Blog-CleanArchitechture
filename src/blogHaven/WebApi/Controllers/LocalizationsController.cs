using Application.Constants;
using Application.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LocalizationsController : ControllerBase
    {

        private readonly IStringLocalizer<Messages> _localizer;

        public LocalizationsController(IStringLocalizer<Messages> localizer)
        {
            _localizer = localizer;
        }

        [HttpGet]
        public IActionResult GetMessage()
        {
            string message = _localizer[ValidationMessages.TitleIsRequired];

            var response = new
            {
                message = message,
                culture = CultureInfo.CurrentCulture.Name
            };

            return Ok(response);
        }
    }
}
