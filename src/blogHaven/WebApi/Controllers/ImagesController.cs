using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImagesController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> AddImage(IFormFile file)
        {
            var result = await Mediator.Send(file);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }
    }
}
