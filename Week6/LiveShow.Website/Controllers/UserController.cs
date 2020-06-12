using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LiveShow.Services.Models.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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

        public async Task<IActionResult> Artists()
        {
            var result = await service.GetArtists();
            return View(result);
        }

        [HttpGet]
        public IActionResult Register()
        {
            var user = new UserDto();
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDto user)
        {
            if (TryValidateModel(user))
            {
                var result = await service.Register(user);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Login");
                }
            }        
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            var userLoginDto = new UserLoginDto();
            return View(userLoginDto);
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            if (TryValidateModel(userLoginDto))
            {
                var response = await service.Login(userLoginDto);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Artists");
                }
                ViewBag.Error = "Invalid username or password.";
            }
            return View();
        }


    }
}
