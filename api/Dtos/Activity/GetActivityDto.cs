using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Enums;

namespace api.Dtos
{
    public class GetActivityDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? ActivityDatetime { get; set; }
        public bool IsRecurrent { get; set; }
        public bool? IsAnnual { get; set; }
        public string UserId { get; set; } = string.Empty;
        public List<string> DiasSemana { get; set; } = new List<string>();    
    }
}