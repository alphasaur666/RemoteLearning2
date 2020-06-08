using AutoMapper;
using LiveShow.Dal;
using LiveShow.Dal.Models;
using LiveShow.Services.Models.Attendance;
using LiveShow.Services.Models.Followers;
using LiveShow.Services.Models.User;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
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

        public LoggedInUserDto Login(UserLoginDto userLogin)
        {
            LoggedInUserDto loggedInUser = new LoggedInUserDto
            {
                SessionId = Guid.NewGuid()
            };
            return loggedInUser;
        }

        public void Logout(int userID)
        {
            
            // do the logout
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

    }
}



