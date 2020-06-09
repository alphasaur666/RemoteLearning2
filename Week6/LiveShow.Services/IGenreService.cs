using LiveShow.Services.Models.Show;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LiveShow.Services
{
    public interface IGenreService
    {
        Task<GenreDto> CreateGenre(GenreDto genre);
        IEnumerable<GenreDto> GetAllGenres();
        Task<GenreDto> DeleteGenre(GenreDto genre);
        Task<GenreDto> UpdateGenre(GenreDto genre);
    }
}
