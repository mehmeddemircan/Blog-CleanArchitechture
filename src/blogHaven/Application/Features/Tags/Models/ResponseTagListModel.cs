using Application.Features.Tags.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Tags.Models
{
    public class ResponseTagListModel : BasePageableModel
    {
        public IList<ResponseTagListDto> Items { get; set; }
    }
}
