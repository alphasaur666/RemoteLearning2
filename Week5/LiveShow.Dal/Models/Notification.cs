using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiveShow.Dal.Models
{
    public class Notification
    {
        public long Id { get; set; } //pk
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public string Type { get; set; }
        public DateTime OriginalDateTime { get; set; }
        public string OriginalVenue { get; set; } //fk
        public long ShowId { get; set; } //fk


        public Show Show { get; set; }

        
        

    }
}
