using LiveShow.Dal.Models;
using LiveShow.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveShow.Services
{
    public interface IUserService
    {
        LoggedInUserDto Login(UserLoginDto userLogin);
        void Logout(int userId);
        Task<UserDto> RegisterUser(UserDto user);
        Task<UserDto> GetUser(int userId);
        IEnumerable<UserDto> GetAllUsers();
        Task<UserDto> UpdateUser(UserDto user);
        IEnumerable<UserDto> GetArtists();


    }
}