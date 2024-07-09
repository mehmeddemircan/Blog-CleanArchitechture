using Application.Features.Comments.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Comments.Models
{
    public class ResponseCommentListModel : BasePageableModel
    {
        public IList<ResponseCommentListDto> Items { get; set; }
    }
}
