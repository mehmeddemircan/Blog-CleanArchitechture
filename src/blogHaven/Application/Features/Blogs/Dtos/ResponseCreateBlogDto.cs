using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blogs.Dtos
{
    public class ResponseCreateBlogDto : IDto
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public string? ThumbNailImage { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
