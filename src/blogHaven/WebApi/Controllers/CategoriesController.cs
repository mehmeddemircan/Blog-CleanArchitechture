using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Dtos;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            CreateCategoryDto result = await Mediator.Send(createCategoryCommand);
            return Created("", result);
        }
    }
}
