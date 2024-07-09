using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Comments.Dtos
{
    public class ResponseCreateCommentDto : IDto
    {
        public string Content { get; set; }
        public int UserId { get; set; }
        public int BlogId { get; set; }
        public int? ParentId { get; set; }
    }
}
