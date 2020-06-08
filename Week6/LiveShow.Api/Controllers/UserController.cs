using LiveShow.Services;
using LiveShow.Services.Models.Show;
using LiveShow.Services.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace LiveShow.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
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
            var loggedInUser = userService.Login(userLogin);
            return Ok(loggedInUser);
        }

        [HttpGet("logout")]
        public IActionResult Logout(int userID)
        {
            userService.Logout(userID);
            return Ok("Logged out!");
        }

        [HttpGet("{userId}")]
        public IActionResult Profile(int userId)
        {
            var userProfile = userService.GetUser(userId);
            return Ok(userProfile);
        }

        [HttpPost("register")]
        public IActionResult Register(UserDto user)
        {
            var registerdUser = userService.RegisterUser(user);
            return Created(Url.Action("Profile: "), registerdUser);
        }

        [HttpPatch]
        public IActionResult UpdateProfile(UserDto user)
        {
            return Ok(user);
        }
        
    }
}
