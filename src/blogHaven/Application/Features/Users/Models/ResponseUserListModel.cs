using Application.Features.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Models
{
    public class ResponseUserListModel
    {
        public IList<ResponseUserListDto> Items { get; set; }
    }
}
