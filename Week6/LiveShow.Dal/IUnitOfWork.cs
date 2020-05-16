using LiveShow.Dal.Models;

namespace LiveShow.Dal
{
    public interface IUnitOfWork
    {
        IRepository<User> UserRepository { get; }
        IRepository<Following> FollowingRepository { get; }
        IRepository<Attendance> AttendanceRepository { get; }
        IRepository<Genre> GenreRepository { get; }
        IRepository<Notification> NotificationRepository { get; }
        IRepository<UserNotification> UserNotificationRepository { get; }
        IRepository<Show> ShowRepository { get; }
    }
}