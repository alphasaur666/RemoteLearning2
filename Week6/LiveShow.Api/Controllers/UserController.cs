using LiveShow.Services;
using LiveShow.Services.Models.Show;
using LiveShow.Services.Models.User;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Profile(int userId)
        {
            var userProfile = await userService.GetUser(userId);
            return Ok(userProfile);
        }

        [HttpGet("artists")]
        public IActionResult GetArtists()
        {
            var artists = userService.GetArtists();
            return Ok(artists);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto user)
        {
            var registerdUser = await userService.RegisterUser(user);
            return Ok(registerdUser);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateProfile(UserDto user)
        {
            var updatedUser = await userService.UpdateUser(user);
            return Ok(updatedUser);
        }
        
    }
}
