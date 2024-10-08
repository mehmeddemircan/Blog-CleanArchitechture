﻿using Application.Constants;
using Application.Features.Blogs.Commands.Create;
using Application.Features.Blogs.Commands.Delete;
using Application.Features.Blogs.Commands.Update;
using Application.Features.Blogs.Queries.GetById;
using Application.Features.Blogs.Queries.GetList;
using Application.Features.Blogs.Queries.GetListByDynamic;
using Application.Resources;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogsController : BaseController
    {

      

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBlogCommand createBlogCommand)
        {
            var result = await Mediator.Send(createBlogCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListBlogQuery getListBlogQuery = new() { PageRequest = pageRequest };
            var result = await Mediator.Send(getListBlogQuery);
            return Ok(result);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListBlogByDynamicQuery getListByDynamicModelQuery = new GetListBlogByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
            var result = await Mediator.Send(getListByDynamicModelQuery);
            return Ok(result);

        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdBlogQuery getByIdBlogQuery)
        {
            var responseBlogByIdDto = await Mediator.Send(getByIdBlogQuery);
            return Ok(responseBlogByIdDto);
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteBlogCommand deleteBlogCommand)
        {
            var responseDeleteBlogDto = await Mediator.Send(deleteBlogCommand);
            return Ok(responseDeleteBlogDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBlogCommand updateBlogCommand)
        {
            var responseUpdateCategoryDto = await Mediator.Send(updateBlogCommand);
            return Ok(responseUpdateCategoryDto);
        }

       
    }
}
