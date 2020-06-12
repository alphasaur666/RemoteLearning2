using LiveShow.Dal;
using LiveShow.Dal.Models;
using LiveShow.Services;
using LiveShow.Services.Models.Show;
using LiveShow.Services.Models.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LiveShow.Api.Controllers
{
    public class ShowController : LiveShowApiControllerBase
    {

        private readonly IShowService showService;

        public ShowController(IShowService showService)
        {
            this.showService = showService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var show = await showService.GetShow(id);
            return Ok(show);
        }

        [HttpGet]
        public IActionResult GetAllShows()
        {
            var shows = showService.GetAllShows();
            return Ok(shows);
        }

        [HttpGet("ByArtist")]
        public IActionResult GetAllShowsByArtist(UserDto artist)
        {
            var showsByArtist = showService.GetAllShowsByArtist(artist);
            return Ok(showsByArtist);
        }

        [HttpGet("ByVenue")]
        public IActionResult GetAllShowsByVenue(string venue)
        {
            var showsByVenue = showService.GetAllShowsByVenue(venue);
            return Ok(showsByVenue);
        }

        [HttpPost]
        public async Task<IActionResult> AddShow(ShowDto show)
        {
            var Show = await showService.AddShow(show);
            return Ok(Show);

        }

        [HttpPatch]
        public async Task<IActionResult> UpdateShow(ShowDto show)
        {
            var updatedShow = await showService.UpdateShow(show);
            return Ok(updatedShow);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShow(int id)
        {
            var deletedShow = await showService.DeleteShow(id);
            return Ok(deletedShow);      
        }
        
       
    }
}