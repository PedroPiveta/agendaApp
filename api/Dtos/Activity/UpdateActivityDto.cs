using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Activity
{
    public class UpdateActivityDto
    {

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? ActivityDatetime { get; set; }
        public bool IsRecurrent { get; set; }
        public int UserId { get; set; }
        public List<string> DiasSemana { get; set; } = new List<string>();    }
}