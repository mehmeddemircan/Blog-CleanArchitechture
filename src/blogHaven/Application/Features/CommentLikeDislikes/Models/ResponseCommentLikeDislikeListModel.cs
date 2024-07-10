using Application.Features.CommentLikeDislikes.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CommentLikeDislikes.Models
{
    public class ResponseCommentLikeDislikeListModel : BasePageableModel
    {
        public IList<ResponseCommentLikeDislikeListDto> Items { get; set; }
    }
}
