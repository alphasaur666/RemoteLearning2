using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiveShow.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LiveShow.Website.Controllers
{
    public class GenreController : Controller
    {
        private readonly ILogger<GenreController> _logger;
        private readonly IApiService api;
        public GenreController(ILogger<GenreController> logger, IApiService apiService)
        {
            _logger = logger;
            api = apiService;
        }
        
        /*public async Task<IActionResult> Index()
        {
            var result = await api.GetGenres();
            return View(result);
        }
        public async Task<IActionResult> AddGenre()
        {
            var result = await api.Crea()
            return View(result);
        }
        */
    }
}
