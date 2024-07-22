using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using api.Enums;

namespace api.Models
{
    [Table("activities")]
    public class Activity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? ActivityDatetime { get; set; } = new DateTime();
        [Required]
        public bool IsRecurrent { get; set; }
        public List<DiasSemana>? DiasSemana { get; set; } = new List<DiasSemana>();
        public string UserId { get; set; } = string.Empty;
        public AppUser? User { get; set; }
    }
}