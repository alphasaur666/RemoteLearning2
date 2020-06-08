using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiveShow.Services;
using LiveShow.Services.Models.Followers;
using LiveShow.Services.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LiveShow.Api.Controllers
{
    public class FollowerController : LiveShowApiControllerBase
    {
        
        public IFollowerService followerService;

        public FollowerController(IFollowerService followerService)
        {
            this.followerService = followerService;
        }

        [HttpPost]
        public IActionResult Follow(FollowerDto follower)
        {
            var followerTask = followerService.AddFollower(follower);          
            return Ok(followerTask);
        }

        [HttpDelete]
        public IActionResult Unfollow(FollowerDto follower)
        {
            var unfollowTask = followerService.RemoveFollower(follower);
            return Ok(unfollowTask);
        }
        
        
    }
}
