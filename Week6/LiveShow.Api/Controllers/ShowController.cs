using LiveShow.Services;
using LiveShow.Services.Models.Show;
using LiveShow.Services.Models.User;
using Microsoft.AspNetCore.Mvc;
using System;

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
            var show = showService.GetShow(id);
            return Ok(show);
        }

        [HttpPost]
        public IActionResult AddShow(ShowDto show)
        {
            var Show = showService.AddShow(show);
            if (Show != null)
            {
                return Created(Url.Action("Show"), show);
            }
            else
            {
                return Unauthorized("Your account can't do that!");
            }
            
        }

        [HttpPatch]
        public IActionResult UpdateShow(ShowDto show)
        {
            var updatedShow = showService.UpdateShow(show);
            return Ok(show);
        }

        [HttpDelete]
        public IActionResult DeleteShow(ShowDto show)
        {
            var deletedShow = showService.DeleteShow(show);
            return Ok("Deleted show!");           
        }
        
       
    }
}