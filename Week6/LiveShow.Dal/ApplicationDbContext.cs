using LiveShow.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace LiveShow.Dal
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Following> Followings { get; set; }

        public DbSet<Attendance> Attendances { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<UserNotification> UserNotifications { get; set; }

        public DbSet<Show> Shows { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FollowersRelations(modelBuilder);

            AttendancesRelations(modelBuilder);

            UserNotificationsRelations(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void UserNotificationsRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserNotification>()
                .HasKey(c => new {c.UserId, c.NotificationId});

            modelBuilder.Entity<UserNotification>()
                .HasOne(n => n.User)
                .WithMany(u => u.UserNotifications)
                .OnDelete(DeleteBehavior.NoAction);
        }

        private static void AttendancesRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                .HasKey(c => new {c.ShowId, c.AttendeeId});

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Show)
                .WithMany(g => g.Attendances)
                .OnDelete(DeleteBehavior.NoAction);
        }

        private static void FollowersRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Following>()
                .HasKey(c => new { c.FollowerId, c.FolloweeId });

            modelBuilder.Entity<User>()
                .HasMany(u => u.Followers)
                .WithOne(f => f.Followee)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Followees)
                .WithOne(f => f.Follower)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
