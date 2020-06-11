using LiveShow.Services.Models.Show;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveShow.Services.Models.Notification
{
    public class NotificationDto
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public NotificationTypeEnum Type { get; set; }

        public DateTime? OriginalDateTime { get; set; }

        public string OriginalVenue { get; set; }

        public ShowDto Show { get; set; }

        public int ShowId { get; set; }

    }
}
