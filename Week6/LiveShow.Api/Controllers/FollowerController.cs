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
        public async Task<IActionResult> Follow(FollowerDto follower)
        {
            var followerTask = await followerService.AddFollower(follower);
            return Ok(followerTask);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Unfollow(int id)
        {
            var unfollowTask = await followerService.RemoveFollower(id);
            return Ok(unfollowTask);
        }
        
        
    }
}
