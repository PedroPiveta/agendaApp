using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class UserActivity
    {
        public string UserId { get; set; } = string.Empty;
        public AppUser User { get; set; } = new AppUser();

        public int ActivityId { get; set; }
        public Activity Activity { get; set; } = new Activity();
    }
}