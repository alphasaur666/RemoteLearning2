using System;
using System.Collections.Generic;
using System.Text;

namespace LiveShow.Dal.Models
{
    public class UserNotification
    {
        public long UserId { get; set; }
        public long NotificationId { get; set; }
        public bool IsRead { get; set; }
        public User User { get; set; }

        public Notification Notification { get; set; }

    }
}
