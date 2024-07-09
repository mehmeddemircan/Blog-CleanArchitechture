using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BlogTag : Entity
    {
        public int TagId { get; set; }

        public virtual Tag Tag { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
