using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Enums;

namespace api.Dtos
{
    public class GetActivityDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? ActivityDatetime { get; set; }
        public bool IsRecurrent { get; set; }
        public int UserId { get; set; }
        public string? DiasSemana { get; set; } = string.Empty;
    }
}