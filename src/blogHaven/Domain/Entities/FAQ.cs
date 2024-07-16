using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FAQ : Entity
    {
     
        public string Question { get; set; }

        public string? QuestionPhoto { get; set; }
        
        public string Answer { get; set; }

        public string? AnswerPhoto { get; set; }
    }
}
