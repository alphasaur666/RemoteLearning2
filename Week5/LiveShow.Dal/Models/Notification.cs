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
        public NotificationType Type { get; set; }
        public DateTime OriginalDateTime { get; set; }
        public string OriginalVenue { get; set; } //fk

        public long ShowId { get; set; } //fk

        [Required]
        public Show Show { get; set; }

        public Notification(NotificationType notificationType, Show show)
        {
            notificationType = Type;
            Show = show ?? throw new ArgumentNullException(nameof(Show));
            DateTime = DateTime.Now;
        }

        
        

    }
}
