using LiveShow.Dal.Models;
using LiveShow.Dal.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveShow.Dal.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        private GenericRepository<User> userRepository;
        private GenericRepository<Notification> notificationRepository;
        private GenericRepository<Show> showRepository;
        private GenericRepository<Following> followingRepository;
        private GenericRepository<Attendance> attendanceRepository;
        private GenericRepository<Genre> genreRepository;
        


        public GenericRepository<User> UserRepository
        {
            get
            {
                if(this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
            }
        }

        public GenericRepository<Notification> NotificationRepository
        {
            get
            {
                if (this.notificationRepository == null)
                {
                    this.notificationRepository = new GenericRepository<Notification>(context);
                }
                return notificationRepository;
            }
        }

        public GenericRepository<Show> ShowRepository
        {
            get
            {
                if (this.showRepository == null)
                {
                    this.showRepository = new GenericRepository<Show>(context);
                }
                return showRepository;
            }
        }

        public GenericRepository<Following> FollowingRepository
        {
            get
            {
                if (this.followingRepository == null)
                {
                    this.followingRepository = new GenericRepository<Following>(context);
                }
                return followingRepository;
            }
        }

        public GenericRepository<Attendance> AttendanceRepository
        {
            get
            {
                if (this.attendanceRepository == null)
                {
                    this.attendanceRepository = new GenericRepository<Attendance>(context);
                }
                return attendanceRepository;
            }
        }

        public GenericRepository<Genre> GenresRepository
        {
            get
            {
                if (this.genreRepository == null)
                {
                    this.genreRepository = new GenericRepository<Genre>(context);
                }
                return genreRepository;
            }
        }


        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
