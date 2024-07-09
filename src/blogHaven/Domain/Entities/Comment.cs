using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Comment : Entity
    {

        public string Content { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int? ParentId { get; set; }
        public Comment Parent { get; set; }
        public ICollection<Comment> Replies { get; set; } = new List<Comment>();
    }
}
