using LiveShow.Services.Models.Followers;
using LiveShow.Services.Models.Notification;
using LiveShow.Services.Models.Show;
using LiveShow.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LiveShow.Website
{
    public interface IApiService
    {
        //Post
        Task<HttpResponseMessage> AddGenre(HttpContent genre);
        Task<HttpResponseMessage> AddShow(ShowDto show);
        Task<HttpResponseMessage> Follow(FollowerDto follower);
        Task<HttpResponseMessage> CreateNotification(HttpContent notification);
        Task<HttpResponseMessage> Register(UserDto userDto);
        Task<HttpResponseMessage> Login(UserLoginDto userLoginDto);
        Task<HttpResponseMessage> Attend(int showId);
        Task<HttpResponseMessage> FollowingsOfUser(UserDto user);

        //Deletes
        Task<HttpResponseMessage> DeleteShow(int ShowId);
        Task<HttpResponseMessage> DeleteGenre(int genreId);
        Task<HttpResponseMessage> Unfollow(int followerId);

        //Gets
        Task<NotificationDto> GetNotification(int notificationId);
        Task<List<NotificationDto>> GetNotifications();
        Task<List<UserDto>> GetAllShowsByVenue(string venue);
        Task<List<UserDto>> GetAllShowsByArtist(string venue);
        Task<List<UserDto>> GetArtists();
        Task<UserDto> GetLoggedUser();
        Task<List<ShowDto>> GetShows();
        Task<ShowDto> GetProfile(int id);
        Task<List<GenreDto>> GetGenres();

    }
}
