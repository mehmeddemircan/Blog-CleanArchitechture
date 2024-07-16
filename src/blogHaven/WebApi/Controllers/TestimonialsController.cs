using Application.Features.Testimonials.Commands.Delete;
using Application.Features.Testimonials.Commands.Update;
using Application.Features.Testimonials.Queries.GetById;
using Application.Features.Testimonials.Queries.GetList;

using Application.Features.Testimonials.Commands.Create;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestimonialsController : BaseController
    {



        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTestimonialCommand createTestimonialCommand)
        {
            var result = await Mediator.Send(createTestimonialCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListTestimonialQuery getListTestimonialQuery = new() { PageRequest = pageRequest };
            var result = await Mediator.Send(getListTestimonialQuery);
            return Ok(result);
        }

    

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdTestimonialQuery getByIdTestimonialQuery)
        {
            var responseTestimonialByIdDto = await Mediator.Send(getByIdTestimonialQuery);
            return Ok(responseTestimonialByIdDto);
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteTestimonialCommand deleteTestimonialCommand)
        {
            var responseDeleteTestimonialDto = await Mediator.Send(deleteTestimonialCommand);
            return Ok(responseDeleteTestimonialDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTestimonialCommand updateTestimonialCommand)
        {
            var responseUpdateCategoryDto = await Mediator.Send(updateTestimonialCommand);
            return Ok(responseUpdateCategoryDto);
        }

    }
}
