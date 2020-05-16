using LiveShow.Services.Models.User;
using System;

namespace LiveShow.Services
{
    public interface IUserService
    {
        LoggedInUserDto Login(UserLoginDto userLogin);
        void Logout(long userId);
    }
}