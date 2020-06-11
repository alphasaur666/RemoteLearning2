﻿namespace LiveShow.Services.Models.User
{
    public class UserDto
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public UserTypeEnum Type { get; set; }
    }
}