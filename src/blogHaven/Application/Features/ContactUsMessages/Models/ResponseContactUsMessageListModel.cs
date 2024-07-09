using Application.Features.ContactUsMessages.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ContactUsMessages.Models
{
    public class ResponseContactUsMessageListModel : BasePageableModel
    {
        public IList<ResponseContactUsMessageListDto> Items { get; set; }
    }
}
