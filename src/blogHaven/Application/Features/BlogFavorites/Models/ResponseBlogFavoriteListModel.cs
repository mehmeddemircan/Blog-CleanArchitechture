using Application.Features.BlogFavorites.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogFavorites.Models
{
    public class ResponseBlogFavoriteListModel : BasePageableModel
    {
        public IList<ResponseBlogFavoriteListDto> Items { get; set; }
    }
}
