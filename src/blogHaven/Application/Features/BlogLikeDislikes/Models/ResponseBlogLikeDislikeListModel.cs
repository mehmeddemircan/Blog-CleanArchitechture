using Application.Features.BlogLikeDislikes.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogLikeDislikes.Models
{
    public class ResponseBlogLikeDislikeListModel : BasePageableModel
    {
        public IList<ResponseBlogLikeDislikeListDto> Items { get; set; }
    }
}
