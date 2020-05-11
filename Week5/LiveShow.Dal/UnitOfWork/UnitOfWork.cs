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
        private GenericRepository<Notifications> notificationsRepository;
        private GenericRepository<Shows> showsRepository;
        private GenericRepository<Followings> followingsRepository;
        private GenericRepository<Attendances> attendancesRepository;
        private GenericRepository<Genres> genresRepository;
        


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

        public GenericRepository<Notifications> NotificationsRepository
        {
            get
            {
                if (this.notificationsRepository == null)
                {
                    this.notificationsRepository = new GenericRepository<Notifications>(context);
                }
                return notificationsRepository;
            }
        }

        public GenericRepository<Shows> ShowsRepository
        {
            get
            {
                if (this.showsRepository == null)
                {
                    this.showsRepository = new GenericRepository<Shows>(context);
                }
                return showsRepository;
            }
        }

        public GenericRepository<Followings> FollowingsRepository
        {
            get
            {
                if (this.followingsRepository == null)
                {
                    this.followingsRepository = new GenericRepository<Followings>(context);
                }
                return followingsRepository;
            }
        }

        public GenericRepository<Attendances> AttendancesRepository
        {
            get
            {
                if (this.attendancesRepository == null)
                {
                    this.attendancesRepository = new GenericRepository<Attendances>(context);
                }
                return attendancesRepository;
            }
        }

        public GenericRepository<Genres> GenresRepository
        {
            get
            {
                if (this.genresRepository == null)
                {
                    this.genresRepository = new GenericRepository<Genres>(context);
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
