using AutoMapper;
using LiveShow.Dal;
using LiveShow.Dal.Models;
using LiveShow.Services.Models.Attendance;
using LiveShow.Services.Models.Followers;
using LiveShow.Services.Models.User;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LiveShow.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public ClaimsIdentity Login(UserDto user)
        {
            var identity = new ClaimsIdentity(new[]
            {
             new Claim(ClaimTypes.Name, user.Username)
            },
            CookieAuthenticationDefaults.AuthenticationScheme);

            return identity;
        }

        public async Task<UserDto> RegisterUser(UserDto user)
        {
            var createdUser = mapper.Map<User>(user);
            await unitOfWork.UserRepository.AddAsync(createdUser);

            var returnedUser = mapper.Map<UserDto>(createdUser);
            return returnedUser;
        }

        public async Task<UserDto> GetUser(int userId)
        {
            var user = await unitOfWork.UserRepository.GetAsync(u => u.Id == userId);
            var userDto = mapper.Map<UserDto>(user);
            return userDto;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var users = unitOfWork.UserRepository.GetAll();
            var usersDto = mapper.Map<IEnumerable<UserDto>>(users);
            return usersDto;
        }

        public IEnumerable<UserDto> GetArtists()
        {
            var artists = unitOfWork.UserRepository.GetAll(u => u.Type == UserType.Artist);
            var artistsDto = mapper.Map<IEnumerable<UserDto>>(artists);
            return artistsDto;
        }

        public async Task<UserDto> UpdateUser(UserDto user)
        {
            var userToUpdate = mapper.Map<User>(user);
            await unitOfWork.UserRepository.UpdateAsync(userToUpdate);

            var returnedUpdatedUser = mapper.Map<UserDto>(userToUpdate);
            return returnedUpdatedUser;
        }

    }
}



