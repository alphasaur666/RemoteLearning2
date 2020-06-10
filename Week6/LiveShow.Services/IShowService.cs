using LiveShow.Dal.Models;
using LiveShow.Services.Models.Show;
using LiveShow.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveShow.Services
{
    public interface IShowService
    {
        Task<ShowDto> GetShow(int showId);
        IEnumerable<ShowDto> GetAllShows();
        Task<ShowDto> AddShow(ShowDto show);
        Task<ShowDto> DeleteShow(int showId);
        Task<ShowDto> UpdateShow(ShowDto show);
        IEnumerable<ShowDto> GetAllShowsByArtist(UserDto artist);
        IEnumerable<ShowDto> GetAllShowsByVenue(string Venue);


    }
}
