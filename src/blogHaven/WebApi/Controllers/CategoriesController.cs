using Application.BusinessAspects;
using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Commands.DeleteCategory;
using Application.Features.Categories.Commands.UpdateCategory;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Models;
using Application.Features.Categories.Queries.GetByIdCategory;
using Application.Features.Categories.Queries.GetListCategory;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var result = await Mediator.Send(createCategoryCommand);
            return Created("", result);
        }

        [HttpGet]
        [Authentication]
        [SecuredOperation("Admin")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListCategoryQuery getListCategoryQuery = new() { PageRequest = pageRequest };
            var result = await Mediator.Send(getListCategoryQuery);
            return Ok(result);
        }



        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCategoryQuery getByIdCategoryQuery)
        {
          var responseCategoryByIdDto = await Mediator.Send(getByIdCategoryQuery);
            return Ok(responseCategoryByIdDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            var responseUpdateCategoryDto = await Mediator.Send(updateCategoryCommand);
            return Ok(responseUpdateCategoryDto);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCategoryCommand deleteCategoryCommand)
        {
            var responseDeleteCategoryDto = await Mediator.Send(deleteCategoryCommand);
            return Ok(responseDeleteCategoryDto);
        }
    }
}
