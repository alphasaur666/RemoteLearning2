using System;
using System.ComponentModel.DataAnnotations;

namespace LiveShow.Dal.Models
{
    public class Notification
    {
        public int Id { get; private set; }

        public DateTime DateTime { get; private set; }

        public NotificationType Type { get; private set; }

        public DateTime? OriginalDateTime { get; private set; }

        public string OriginalVenue { get; private set; }
    
        public Show Show { get; private set; }

        public Notification(NotificationType type, Show show)
        {
            Type = type;
            Show = show ?? throw new ArgumentNullException(nameof(show));
            DateTime = DateTime.Now;
        }
        public Notification()
        {

        }
    }
}
