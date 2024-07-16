using Application.Features.FAQs.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FAQs.Models
{
    public class ResponseFAQListModel : BasePageableModel
    {
        public IList<ResponseFAQListDto> Items { get; set; }
    }
}
