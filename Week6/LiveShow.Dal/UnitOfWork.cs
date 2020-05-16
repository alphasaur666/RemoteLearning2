using LiveShow.Dal.Models;

namespace LiveShow.Dal
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new Repository<User>(dbContext);
                }
                return userRepository;
            }
        }
        public IRepository<Following> FollowingRepository
        {
            get
            {
                if (this.followingRepository == null)
                {
                    this.followingRepository = new Repository<Following>(dbContext);
                }
                return followingRepository;
            }
        }
        public IRepository<Attendance> AttendanceRepository
        {
            get
            {
                if (this.attendanceRepository == null)
                {
                    this.attendanceRepository = new Repository<Attendance>(dbContext);
                }
                return attendanceRepository;
            }
        }
        public IRepository<Genre> GenreRepository
        {
            get
            {
                if (this.genreRepository == null)
                {
                    this.genreRepository = new Repository<Genre>(dbContext);
                }
                return genreRepository;
            }
        }

        public IRepository<Notification> NotificationRepository {
            get
            {
                if (this.notificationRepository == null)
                {
                    this.notificationRepository = new Repository<Notification>(dbContext);
                }
                return notificationRepository;
            }
        }

        public IRepository<UserNotification> UserNotificationRepository
        {
            get
            {
                if (this.userNotificationRepository == null)
                {
                    this.userNotificationRepository = new Repository<UserNotification>(dbContext);
                }
                return userNotificationRepository;
            }
        }
        public IRepository<Show> ShowRepository
        {
            get
            {
                if (this.showRepository == null)
                {
                    this.showRepository = new Repository<Show>(dbContext);
                }
                return showRepository;
            }
        }

        private IRepository<User> userRepository;
        private IRepository<Following> followingRepository;
        private IRepository<Attendance> attendanceRepository;
        private IRepository<Genre> genreRepository;
        private IRepository<Notification> notificationRepository;
        private IRepository<UserNotification> userNotificationRepository;
        private IRepository<Show> showRepository;

        private readonly ApplicationDbContext dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
