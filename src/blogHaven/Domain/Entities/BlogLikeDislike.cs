using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BlogLikeDislike : Entity
    {
        public int BlogId { get; set; }
        public virtual  Blog Blog { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public DateTime ActionedOn { get; set; }
        public bool IsLiked { get; set; }
    }
}
