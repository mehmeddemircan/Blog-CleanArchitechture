﻿using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category : Entity
    {

        public string Name { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public Category()
        {
            
        }

        public Category(int id,string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}
