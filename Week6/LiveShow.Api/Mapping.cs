using AutoMapper;
using LiveShow.Dal.Models;
using LiveShow.Services.Models.Attendance;
using LiveShow.Services.Models.Followers;
using LiveShow.Services.Models.Notification;
using LiveShow.Services.Models.Show;
using LiveShow.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveShow.Api
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, UserDto>();
            CreateMap<Genre, GenreDto>();
            CreateMap<Show, ShowDto>();
            CreateMap<Attendance, AttendanceDto>();
            CreateMap<Following, FollowerDto>();
            CreateMap<Notification, NotificationDto>();

            CreateMap<UserDto, User>();
            CreateMap<GenreDto, Genre>();
            CreateMap<ShowDto, Show>();
            CreateMap<AttendanceDto, Attendance>();
            CreateMap<FollowerDto, Following>();
            CreateMap<NotificationDto, Notification>();
        }
    }
}
