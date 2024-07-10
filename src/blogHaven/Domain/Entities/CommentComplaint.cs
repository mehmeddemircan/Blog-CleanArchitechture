using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CommentComplaint : Entity
    {

        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }
        public int ComplainerId { get; set; }
        public virtual User Complainer { get; set; }
        public string Message { get; set; }
    }
}
