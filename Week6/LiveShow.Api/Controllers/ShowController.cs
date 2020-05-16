using LiveShow.Services;
using LiveShow.Services.Models.Show;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Details(int id)
        {
            ShowDto show = showService.GetShow(id);
            return Ok(show);
        }
    }
}