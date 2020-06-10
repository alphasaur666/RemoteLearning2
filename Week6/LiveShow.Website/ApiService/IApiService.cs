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
        Task<List<UserDto>> GetArtists();
        Task<List<ShowDto>> GetShows();
        Task<ShowDto> GetProfile(int id);
        Task<List<GenreDto>> GetGenres();
        Task<HttpResponseMessage> Register(UserDto userDto);
        Task<HttpResponseMessage> Login(UserDto user);
    }
}
