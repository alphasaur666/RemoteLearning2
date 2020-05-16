using LiveShow.Dal;
using LiveShow.Services.Models.User;
using System;

namespace LiveShow.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public LoggedInUserDto Login(UserLoginDto userLogin)
        {
            LoggedInUserDto loggedInUser = new LoggedInUserDto
            {
                SessionId = Guid.NewGuid()
            };
            return loggedInUser;
        }

        public void Logout(long userId)
        {
            // do the logout
        }

        public void FollowAShow() { }
    }
}
