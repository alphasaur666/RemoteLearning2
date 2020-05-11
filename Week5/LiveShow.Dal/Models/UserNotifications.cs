using System;
using System.Collections.Generic;
using System.Text;

namespace LiveShow.Dal.Models
{
    public class UserNotifications
    {
        public long UserId { get; set; }
        public long NotificationId { get; set; }
        public bool IsRead { get; set; }
        public User User { get; set; }

        public Notifications Notification { get; set; }

    }
}
