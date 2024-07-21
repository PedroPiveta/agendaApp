using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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

        public DateTime? ActivityDatetime { get; set; }

        [Required]
        public bool IsRecurrent { get; set; }

        [Required]
        public int UserId { get; set; }

        public DiasSemana? DiasSemana { get; set; }
        public ICollection<UserActivity> UserActivities { get; set; }

    }
}