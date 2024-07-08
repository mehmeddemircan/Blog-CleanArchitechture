using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Tag  : Entity
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public Tag() { }

        public Tag(string name, int categoryId, Category category)
        {
            Name = name;
            CategoryId = categoryId;
            Category = category;
        }
    }
}
