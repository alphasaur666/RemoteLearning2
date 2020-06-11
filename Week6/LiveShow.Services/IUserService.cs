using LiveShow.Dal.Models;
using LiveShow.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LiveShow.Services
{
    public interface IUserService
    {
        Task<UserDto> RegisterUser(UserDto user);
        Task<UserDto> GetUser(int userId);
        IEnumerable<UserDto> GetAllUsers();
        Task<UserDto> UpdateUser(UserDto user);
        IEnumerable<UserDto> GetArtists();
        Task<UserDto> GetUserByUsernameAndPassword(string username, string password);
        Task<bool> CheckCreditentials(string username, string password);
    }
}