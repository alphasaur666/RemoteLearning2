using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiveShow.Services.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LiveShow.Website.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<ShowController> _logger;

        private readonly IApiService service;
        public UserController(ILogger<ShowController> logger, IApiService Service)
        {
            _logger = logger;
            service = Service;
        }

        public async Task<IActionResult> Index(int Id)
        {
            var result = await service.GetProfile(Id);
            return View(result);

        }

        public async Task<IActionResult> Artists()
        {
            var result = await service.GetArtists();
            return View(result);
        }
    }
}
