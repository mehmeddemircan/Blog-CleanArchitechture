using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Tags.Dtos
{
    public class ResponseTagByIdDto : IDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
    }
}
