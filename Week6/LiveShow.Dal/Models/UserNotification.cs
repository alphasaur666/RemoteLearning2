using System;

namespace LiveShow.Dal.Models
{
    public class UserNotification
    {
        public long UserId { get; private set; }

        public int NotificationId { get; private set; }

        public User User { get; private set; }

        public Notification Notification { get; private set; }

        public bool IsRead { get; private set; }

        protected UserNotification()
        {
        }

        public UserNotification(User user, Notification notification)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            Notification = notification ?? throw new ArgumentNullException(nameof(notification));
        }

        public void Read()
        {
            IsRead = true;
        }
    }

}
