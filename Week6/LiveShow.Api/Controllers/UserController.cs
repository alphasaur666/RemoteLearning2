using LiveShow.Services;
using LiveShow.Services.Models.Show;
using LiveShow.Services.Models.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
        public IActionResult Login(UserDto userDto)
        {
            if (!string.IsNullOrEmpty(userDto.Username) && string.IsNullOrEmpty(userDto.Password))
            {
                return RedirectToAction("Login");
            }

            var identity = userService.Login(userDto);

             
            var principal = new ClaimsPrincipal(identity);
            var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return Ok(login); 
        }

        [HttpGet("logout")]
        public IActionResult Logout(int userID)
        {
            var logout = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok(logout);
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
