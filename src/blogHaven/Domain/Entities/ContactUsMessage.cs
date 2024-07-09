using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ContactUsMessage : Entity
    {
        public string Topic { get; set; }
        public string Content { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }

    }
}
