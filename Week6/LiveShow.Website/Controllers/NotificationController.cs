using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LiveShow.Website.Controllers
{
    public class NotificationController : Controller
    {
        private readonly ILogger<NotificationController> _logger;
        private readonly IApiService api;

        public NotificationController(ILogger<NotificationController> logger, IApiService apiService)
        {
            _logger = logger;
            api = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await api.GetNotifications();
            return View(result);
        }  
    }
}
