using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LiveShow.Website.Controllers
{
    public class FollowingsController : Controller
    {
        private readonly ILogger<FollowingsController> _logger;
        private readonly IApiService api;

        public FollowingsController(ILogger<FollowingsController> logger, IApiService apiService)
        {
            _logger = logger;
            api = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await api.GetLoggedUser();
            var followings = await api.FollowingsOfUser(user);
            return View(followings);
        }
    }
}
