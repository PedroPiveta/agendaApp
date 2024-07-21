using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Activity
{
    public class CreateActivityDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;        
        public string Description { get; set; } = string.Empty;
        public DateTime? ActivityDatetime { get; set; } = null;
        public bool IsRecurrent { get; set; }
        public List<string> DiasSemana { get; set; } = new List<string>();    
    }
}