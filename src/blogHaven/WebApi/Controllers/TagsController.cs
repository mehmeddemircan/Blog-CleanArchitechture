
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Models;

using Application.Features.Tags.Commands.CreateTag;
using Application.Features.Tags.Dtos;
using Application.Features.Tags.Models;
using Application.Features.Tags.Queries.GetByIdTag;
using Application.Features.Tags.Queries.GetListTag;
using Application.Features.Tags.Queries.GetListTagByCategory;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTagCommand createTagCommand)
        {
            ResponseCreateTagDto result = await Mediator.Send(createTagCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListTagQuery getListTagQuery = new() { PageRequest = pageRequest };
            ResponseTagListModel result = await Mediator.Send(getListTagQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdTagQuery getByIdTagQuery)
        {
            ResponseTagByIdDto responseTagByIdDto = await Mediator.Send(getByIdTagQuery);
            return Ok(responseTagByIdDto);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListTagByDynamicQuery getListByDynamicModelQuery = new GetListTagByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
            ResponseTagListModel result = await Mediator.Send(getListByDynamicModelQuery);
            return Ok(result);

        }
    }
}
