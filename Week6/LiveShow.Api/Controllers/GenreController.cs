using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiveShow.Services;
using LiveShow.Services.Models.Show;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LiveShow.Api.Controllers
{
    [ApiController]
    public class GenreController : LiveShowApiControllerBase
    {
        public IGenreService genreService;

        public GenreController(IGenreService genreService)
        {
            this.genreService = genreService;
        }


        [HttpPost]
        public async Task<IActionResult> AddGenre(GenreDto genre)
        {
            var addedGenre = await genreService.CreateGenre(genre);
            return Ok(addedGenre);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGenre(GenreDto genre)
        {
            var deletedGenre = await genreService.DeleteGenre(genre);
            return Ok(deletedGenre);
        }

        [HttpGet]
        public IActionResult GetAllGenres()
        {
            var genres = genreService.GetAllGenres();
            return Ok(genres);
        }
    }
}
