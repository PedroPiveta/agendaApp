using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Activity
{
    public class UpdateActivityDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? ActivityDatetime { get; set; } = null;
        [Required]
        [DefaultValue(false)]
        public bool IsRecurrent { get; set; } = false;
        [DefaultValue(false)]
        public bool? IsAnnual { get; set; } = false;
        public List<string> DiasSemana { get; set; } = new List<string>();
    }
}