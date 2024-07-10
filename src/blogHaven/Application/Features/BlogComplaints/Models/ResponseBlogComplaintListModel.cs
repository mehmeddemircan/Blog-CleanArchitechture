using Application.Features.BlogComplaints.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogComplaints.Models
{
    public class ResponseBlogComplaintListModel : BasePageableModel
    {
        public IList<ResponseBlogComplaintListDto> Items { get; set; }
    }
}
