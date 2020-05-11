using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiveShow.Dal.Models
{
    public class Notifications
    {
        public long Id { get; set; } //pk
        public DateTime DateTime { get; set; }
        [Required]
        public UserType Type { get; set; }
        public DateTime OriginalDateTime { get; set; }
        public string OriginalVenue { get; set; } //fk
        public long ShowId { get; set; } //fk   f

        
        

    }
}
