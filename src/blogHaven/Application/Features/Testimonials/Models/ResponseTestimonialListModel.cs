using Application.Features.Testimonials.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Testimonials.Models
{
    public class ResponseTestimonialListModel : BasePageableModel
    {
        public IList<ResponseTestimonialListDto> Items { get; set; }
    }
}
