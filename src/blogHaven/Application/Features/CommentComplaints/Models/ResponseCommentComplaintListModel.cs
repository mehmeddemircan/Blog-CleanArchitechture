using Application.Features.CommentComplaints.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CommentComplaints.Models
{
    public class ResponseCommentComplaintListModel : BasePageableModel
    {
        public IList<ResponseCommentComplaintListDto> Items { get; set; }
    }
}
