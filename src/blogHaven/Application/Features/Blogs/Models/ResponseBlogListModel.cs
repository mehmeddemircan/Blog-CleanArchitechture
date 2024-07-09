using Application.Features.Blogs.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blogs.Models
{
    public class ResponseBlogListModel : BasePageableModel
    {
        public IList<ResponseBlogListDto> Items { get; set; }
    }
}
