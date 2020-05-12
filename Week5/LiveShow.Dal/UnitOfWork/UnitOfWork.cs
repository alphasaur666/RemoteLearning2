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
        private GenericRepository<Notification> notificationsRepository;
        private GenericRepository<Show> showsRepository;
        private GenericRepository<Following> followingsRepository;
        private GenericRepository<Attendance> attendancesRepository;
        private GenericRepository<Genre> genresRepository;
        


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

        public GenericRepository<Notification> NotificationsRepository
        {
            get
            {
                if (this.notificationsRepository == null)
                {
                    this.notificationsRepository = new GenericRepository<Notification>(context);
                }
                return notificationsRepository;
            }
        }

        public GenericRepository<Show> ShowsRepository
        {
            get
            {
                if (this.showsRepository == null)
                {
                    this.showsRepository = new GenericRepository<Show>(context);
                }
                return showsRepository;
            }
        }

        public GenericRepository<Following> FollowingsRepository
        {
            get
            {
                if (this.followingsRepository == null)
                {
                    this.followingsRepository = new GenericRepository<Following>(context);
                }
                return followingsRepository;
            }
        }

        public GenericRepository<Attendance> AttendancesRepository
        {
            get
            {
                if (this.attendancesRepository == null)
                {
                    this.attendancesRepository = new GenericRepository<Attendance>(context);
                }
                return attendancesRepository;
            }
        }

        public GenericRepository<Genre> GenresRepository
        {
            get
            {
                if (this.genresRepository == null)
                {
                    this.genresRepository = new GenericRepository<Genre>(context);
                }
                return genresRepository;
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
