using LiveShow.Dal.Models;
using Microsoft.EntityFrameworkCore;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FollowersRelations(modelBuilder);
            base.OnModelCreating(modelBuilder);
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
