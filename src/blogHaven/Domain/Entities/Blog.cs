using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Blog : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ThumbNailImage { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<BlogTag> BlogTags { get; set; }

    }
}
