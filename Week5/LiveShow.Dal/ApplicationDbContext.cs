using LiveShow.Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LiveShow.Dal
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Followings> Followings { get; set; }

        public DbSet<Attendances> Attendances { get; set; }

        public DbSet<Genres> Genres { get; set; }

        public DbSet<Notifications> Notifications { get; set; }

        public DbSet<Shows> Shows { get; set; }

        public DbSet<UserNotifications> UserNotifications { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public ApplicationDbContext() : base() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FollowersRelations(modelBuilder);
            UserNotificationRelations(modelBuilder);
            AttendancesRelations(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }


        private static void UserNotificationRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserNotifications>()
                .HasKey(c => new { c.UserId, c.NotificationId });

        }

        private static void AttendancesRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendances>()
                .HasKey(c => new { c.ShowId, c.AtendeeID });

            modelBuilder.Entity<User>()
                .HasMany(c => c.Attendances)
                .WithOne(f => f.Atendee)
                .OnDelete(DeleteBehavior.NoAction);
    
        }


        private static void FollowersRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Followings>()
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
