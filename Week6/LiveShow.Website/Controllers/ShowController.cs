using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LiveShow.Website.Controllers
{
    public class ShowController : Controller
    {
        private readonly ILogger<ShowController> _logger;
        private readonly IApiService api;

        public ShowController(ILogger<ShowController> logger, IApiService apiService)
        {
            _logger = logger;
            api = apiService;

        }

        public async Task<IActionResult> Index()
        {
            var result = await api.GetShows();
            return View(result);
        }
    }
}
