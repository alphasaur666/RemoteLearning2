using LiveShow.Services;
using LiveShow.Services.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace LiveShow.Api.Controllers
{
    public class UserController : LiveShowApiControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDto userLogin)
        {
            LoggedInUserDto loggedInUser = userService.Login(userLogin);

            return Ok(loggedInUser);
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            return Ok("logout");
        }

        [HttpGet]
        public IActionResult Profile()
        {
            return Ok("profile");
        }

        [HttpPost]
        public IActionResult Register(UserDto user)
        {
            return Created(Url.Action("Profile"), user);
        }

        [HttpPatch]
        public IActionResult UpdateProfile(UserDto user)
        {
            return Ok(user);
        }
    }
}
